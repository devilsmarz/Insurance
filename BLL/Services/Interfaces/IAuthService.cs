using BeautyTrack_System.Bll.Models;
using BeautyTrackSystem.BLL.Models;
using BeautyTrackSystem.BLL.Models.Responses;

namespace BeautyTrackSystem.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<UserModel>> Register(RegisterModel registerModel);
        Task<ServiceResponse<JwtModel>> Login(LoginModel loginModel);
    }
}
