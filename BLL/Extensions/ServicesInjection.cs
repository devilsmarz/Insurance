using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.BLL.Services.Realization;
using Microsoft.Extensions.DependencyInjection;

namespace BeautyTrackSystem.BLL.Extensions
{
    public static class ServicesInjection
    {
        public static void AddServiceInjection(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}
