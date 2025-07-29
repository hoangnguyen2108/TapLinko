using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TapLinko.Data;
using TapLinko.Models;
using TapLinko.Models.ViewModel;

namespace TapLinko.Services
{
    public class LinkPageUserService : ILinkPageUserService
    {
        private ApplicationDbContext _context;
        public LinkPageUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // check duplicated name
        public async Task<bool> IsUserNameTakenAsync(string fullName, string? excludeUserId = null)
        {
            return await _context.Users
                .Where(u => u.Id != excludeUserId)
                .AnyAsync(u => (u.FirstName + " " + u.LastName) == fullName);
        }

        // mostly for Summary View Index

        public async Task<List<LinkPageUserVM>> Index()
        {
            var summaryUser = await _context.Users.Select(c => new LinkPageUserVM
            {
                UserId = c.Id,
                Name = c.UserName
            }).ToListAsync();


            return summaryUser;
        }

        // Detail

        public async Task<LinkPageUserVM?> GetDetail(string id)
        {
            var user = await _context.Users
                .Include(u => u.LinkPage) // 👈 Make sure to load LinkPage
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            var linkPage = user.LinkPage;

            var model = new LinkPageUserVM
            {
                UserId = user.Id,
                Name = user.UserName,
                LinkPageId = linkPage?.LinkPageId ?? 0, // Safe fallback
                LinkPageTitle = linkPage?.LinkPageTitle,
                Bio = linkPage?.Bio,
                ProfileImageUrl = linkPage?.ProfileImageUrl,
                BannerImageUrl = linkPage?.BannerImageUrl
            };

            return model;
        }


        // Edit - Update
        public async Task<bool> Edit(string id, LinkPageUserVM vMs)
        {
            var product = await _context.Users.FindAsync(id);

            if (product == null)
            {
                return false;
            }
            product.UserName = vMs.Name;

            await _context.SaveChangesAsync();
            return true;
        }

        // Delete

        public async Task<bool> Delete(string id, LinkPageUserVM vMs)
        {
            var product = await _context.Users.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            _context.Users.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
