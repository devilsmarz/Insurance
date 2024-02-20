using BeautyTrack_System.Bll.Models;
using BeautyTrackSystem.BLL.Extensions;
using BeautyTrackSystem.BLL.Mapper;
using BeautyTrackSystem.BLL.Models;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;

namespace BeautyTrackSystem.BLL.Services.Realization
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ServiceResponse<JwtModel>> Login(LoginModel loginModel)
        {
            ServiceResponse<JwtModel> serviceResponse = new ServiceResponse<JwtModel>();
            UserEntityModel userEntityModel =  await _authRepository.Get(loginModel.Email);
            if (userEntityModel == null)
            {
                serviceResponse.Message = "Incorrect username or password";
                return serviceResponse;
            }

            Boolean isPasswordValid = PasswordHelper
                .VerifyPasswordHash(loginModel.Password, userEntityModel.PasswordHash, userEntityModel.PasswordSalt);

            if (!isPasswordValid)
            {
                serviceResponse.Message = "Incorrect username or password";
                return serviceResponse;
            }

            JwtModel jwtViewModel = TokenGen.GenerateToken(userEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = jwtViewModel;
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserModel>> Register(RegisterModel registerModel)
        {
            ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();

            Boolean isUserExists = await _authRepository.IsUserExistByEmail(registerModel.Email);

            if (isUserExists)
            {
                serviceResponse.Message = "User already exist";
                return serviceResponse;
            }

            UserEntityModel user = MapperInitializer.GetUserEntityModel(registerModel);
            PasswordModel passwordModel = PasswordHelper.CreatePasswordHash(registerModel.Password);
            user.PasswordHash = passwordModel.PasswordHash;
            user.PasswordSalt = passwordModel.PasswordSalt;
            await _authRepository.AddUser(user);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = MapperInitializer.GetUserModel(user);
            return serviceResponse;
        }
    }
}
