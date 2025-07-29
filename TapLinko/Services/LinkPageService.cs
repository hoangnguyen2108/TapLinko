using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TapLinko.Data;
using TapLinko.Models;
using TapLinko.Models.ViewModel;

namespace TapLinko.Services
{
    public class LinkPageService : ILinkPageService
    {
        private ApplicationDbContext _context;
        public LinkPageService(ApplicationDbContext context)
        {
            _context = context;
        }
        // LinkPage 
        // check duplicate

        public async Task<bool> IsDuplicateLinkPageAsync(LinkPageUserVM vm)
        {
            return await _context.LinkPages.AnyAsync(lp =>
                lp.LinkPageTitle == vm.LinkPageTitle &&
                lp.Bio == vm.Bio &&
                lp.ProfileImageUrl == vm.ProfileImageUrl &&
                lp.BannerImageUrl == vm.BannerImageUrl
            );
        }

        // Index 
        public async Task<List<LinkPageUserVM>> Index()
        {
            // List of Link
            var list = await _context.LinkPages.Select(c => new LinkPageUserVM
            {
                LinkPageId = c.LinkPageId,
                LinkPageTitle = c.LinkPageTitle,
                Bio = c.Bio,
                ProfileImageUrl = c.ProfileImageUrl,
                BannerImageUrl = c.BannerImageUrl
            }).ToListAsync();

            return list;
        }

        // Mostly for Get 

        public async Task<LinkPageUserVM> GetDetail(string id)
        {
            var product = await _context.LinkPages.FindAsync(id);

            if (product == null)
            {
                return null;
            }
            var user = await _context.Users.FindAsync(product.UserId);

            var model = new LinkPageUserVM
            {
                LinkPageId = product.LinkPageId,
                LinkPageTitle = product.LinkPageTitle,
                Bio = product.Bio,
                ProfileImageUrl = product.ProfileImageUrl,
                BannerImageUrl = product.BannerImageUrl,
                UserId = product.UserId,
                Name = user?.UserName

            };


            return model;
        }

        // Edit 
        public async Task<bool> Edit(string id, LinkPageUserVM vMs)
        {

            var product = await _context.LinkPages.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            product.LinkPageTitle = vMs.LinkPageTitle;
            product.Bio = vMs.Bio;

            await _context.SaveChangesAsync();

            return true;

        }

        // Delete 
        public async Task<bool> Delete(string id, LinkPageUserVM vMs)
        {
            var product = await _context.LinkPages.FindAsync(id);

            if (product == null)
            {
                return false;
            }
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        // Create 
        public async Task<bool> Create(LinkPageUserVM vMs)
        {


            var model = new LinkPage
            {
                LinkPageTitle = vMs.LinkPageTitle,
                Bio = vMs.Bio,
                UserId = vMs.UserId

            };

            _context.LinkPages.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
