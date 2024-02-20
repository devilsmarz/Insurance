using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;
using DLL;
using Microsoft.EntityFrameworkCore;

namespace BeautyTrackSystem.DLL.Repositories.Realization
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationContext _applicationContext;
        public AuthRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task AddUser(UserEntityModel userEntityModel)
        {
            _applicationContext.Users.Add(userEntityModel);
            await _applicationContext.SaveChangesAsync();

        }

        public async Task<UserEntityModel> Get(String email)
        {
            UserEntityModel userEntityModel = 
                 await _applicationContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
            return userEntityModel;
        }

        public async Task<Boolean> IsUserExistByEmail(String email)
        {
            Boolean success = await _applicationContext.Users.AnyAsync(x => x.Email == email);
            return success;

        }
    }
}