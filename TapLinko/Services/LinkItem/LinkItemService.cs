using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TapLinko.Data;
using TapLinko.Models;
using TapLinko.Models.ViewModel;

namespace TapLinko.Services.LinkItem
{
    public class LinkItemService : ILinkItemService
    {
        private ApplicationDbContext _context;
        public LinkItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index
        public async Task<List<LinkPageLinkItemVM>> Index(int id)
        {

            var summary = _context.LinkItems.OrderBy(c => c.Order).Select(c => new LinkPageLinkItemVM
            {
                LinkItemId = c.LinkItemId,
                Label = c.Label,
                Url = c.Url,
                Order = c.Order,
                ClickCount = c.ClickCount

            }).ToList();
            return summary;
        }

        // Mostly for get 

        public async Task<LinkPageLinkItemVM> GetDetail(int id)
        {
            var product = await _context.LinkItems.FindAsync(id);

            if (product == null)
            {
                return null;
            }



            var model = new LinkPageLinkItemVM
            {
                LinkItemId = product.LinkItemId,
                Label = product.Label,
                Url = product.Url,
                Order = product.Order,
                ClickCount = product.ClickCount,
                LinkPageId = product.LinkPageId
            };

            return model;
        }

        // Edit
        public async Task<bool> Edit(int id, LinkPageLinkItemVM vMs)
        {
            var product = await _context.LinkItems.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            product.Label = vMs.Label;
            product.Url = vMs.Url;
            product.Order = vMs.Order;
            product.LinkPageId = vMs.LinkPageId;

            await _context.SaveChangesAsync();
            return true;

        }

        // Create 
        public async Task<(bool Success, string? ErrorMessage)> CreateAsync(LinkPageLinkItemVM vMs)
        {
            int maxOrder = await _context.LinkItems.CountAsync() + 2;

            if (vMs.Order >= maxOrder)
            {
                return (false, $"Order must be less than {maxOrder}.");
            }

            var model = new Models.LinkItem
            {
                Label = vMs.Label,
                Url = vMs.Url,
                Order = vMs.Order,
                LinkPageId = vMs.LinkPageId
            };

            _context.LinkItems.Add(model);
            await _context.SaveChangesAsync();

            return (true, null);
        }

        // delete

        public async Task<bool> Delete(int id, LinkPageLinkItemVM vMs)
        {
            var product = await _context.LinkItems.FindAsync(id);

            if (product == null)
            {
                return false;
            }
            _context.LinkItems.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
