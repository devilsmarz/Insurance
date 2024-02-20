using BeautyTrack_System.Bll.Models;
using BeautyTrackSystem.BLL.Models;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class MapperInitializer
    {
        public static UserEntityModel GetUserEntityModel(RegisterModel registerModel)
        {
            UserEntityModel user = new UserEntityModel
            {
                Name = registerModel.Name,
                Phone = registerModel.Phone,
                Email = registerModel.Email
            };
            return user;
        }
        public static UserModel GetUserModel(UserEntityModel userEntityModel)
        {
            UserModel user = new UserModel
            {
                Name = userEntityModel.Name,
                Phone = userEntityModel.Phone,
                Email = userEntityModel.Email,
                Agents = userEntityModel.Agents,
                Id = userEntityModel.Id
            };
            return user;
        }
    }
}
