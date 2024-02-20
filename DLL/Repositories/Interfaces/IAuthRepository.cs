using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.DLL.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task AddUser(UserEntityModel userEntityModel);
        Task<Boolean> IsUserExistByEmail(String email);
        Task<UserEntityModel> Get(String email);
    }
}
