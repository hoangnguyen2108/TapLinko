using TapLinko.Models.ViewModel;

namespace TapLinko.Services.LinkItem
{
    public interface ILinkItemService
    {
        Task<(bool Success, string? ErrorMessage)> CreateAsync(LinkPageLinkItemVM vMs);
        Task<bool> Delete(int id, LinkPageLinkItemVM vMs);
        Task<bool> Edit(int id, LinkPageLinkItemVM vMs);
        Task<LinkPageLinkItemVM> GetDetail(int id);
        Task<List<LinkPageLinkItemVM>> Index(int id);
    }
}