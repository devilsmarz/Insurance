using BeautyTrack_System.API.Models;
using BeautyTrack_System.Bll.Models;
using BeautyTrack_System.Models;
using BeautyTrackSystem.BLL.Models;

namespace BeautyTrack_System.Mapper
{
    public class MapperInitializer
    {
        public static LoginModel GetLoginModel(LoginViewModel loginViewModel)
        {
            LoginModel login = new LoginModel
            {
                Email = loginViewModel.Email,
                Password = loginViewModel.Password
            };
            return login;
        }

        public static RegisterModel GetRegisterModel(RegisterViewModel registerViewModel)
        {
            RegisterModel registerModel = new RegisterModel 
            {
                Phone = registerViewModel.Phone,
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password
            };

            return registerModel;
        }
    }
}
