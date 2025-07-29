using TapLinko.Models.ViewModel;

namespace TapLinko.Services
{
    public interface ILinkPageService
    {
        Task<bool> Create(LinkPageUserVM vMs);
        Task<bool> Delete(string id, LinkPageUserVM vMs);
        Task<bool> Edit(string id, LinkPageUserVM vMs);
        Task<LinkPageUserVM> GetDetail(string id);
        Task<List<LinkPageUserVM>> Index();
        Task<bool> IsDuplicateLinkPageAsync(LinkPageUserVM vm);
    }
}