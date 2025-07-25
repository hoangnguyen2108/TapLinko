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
        public async Task<bool> IsUserNameTakenAsync(string name, int excludeUserId = 0)
        {
            return await _context.Users
                .Where(u => u.UserId != excludeUserId)
                .AnyAsync(u => u.Name == name);
        }

        // mostly for Summary View Index

        public async Task<List<LinkPageUserVM>> Index()
        {
            var summaryUser = await _context.Users.Select(c => new LinkPageUserVM
            {
                UserId = c.UserId,
                Name = c.Name
            }).ToListAsync();


            return summaryUser;
        }

        // Create Function

        public async Task<bool> Create(LinkPageUserVM vMs)
        {

            var model = new User
            {
                Name = vMs.Name
            };


            _context.Users.Add(model);
            await _context.SaveChangesAsync();



            return true;
        }

        // Mostly Http Get

        public async Task<LinkPageUserVM> GetDetail(int id)
        {
            var product = await _context.Users.FindAsync(id);

            var model = new LinkPageUserVM
            {
                UserId = product.UserId,
                Name = product.Name
            };

            return model;
        }

        // Edit - Update
        public async Task<bool> Edit(int id, LinkPageUserVM vMs)
        {
            var product = await _context.Users.FindAsync(id);

            if (product == null)
            {
                return false;
            }
            product.Name = vMs.Name;

            await _context.SaveChangesAsync();
            return true;
        }

        // Delete

        public async Task<bool> Delete(int id, LinkPageUserVM vMs)
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
