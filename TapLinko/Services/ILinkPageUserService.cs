using TapLinko.Models.ViewModel;

namespace TapLinko.Services
{
    public interface ILinkPageUserService
    {
        Task<bool> Create(LinkPageUserVM vMs);
        Task<bool> Delete(int id, LinkPageUserVM vMs);
        Task<bool> Edit(int id, LinkPageUserVM vMs);
        Task<LinkPageUserVM> GetDetail(int id);
        Task<List<LinkPageUserVM>> Index();
        Task<bool> IsUserNameTakenAsync(string name, int excludeUserId = 0);
    }
}