using TapLinko.Models.ViewModel;

namespace TapLinko.Services
{
    public interface ILinkPageUserService
    {
        Task<bool> Delete(string id, LinkPageUserVM vMs);
        Task<bool> Edit(string id, LinkPageUserVM vMs);
        Task<LinkPageUserVM?> GetDetail(string id);
        Task<List<LinkPageUserVM>> Index();
        Task<bool> IsUserNameTakenAsync(string fullName, string? excludeUserId = null);
    }
}