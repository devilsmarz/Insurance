namespace BeautyTrackSystem.BLL.Helpers
{
    public static class ConfigurationHelper
    {
        public static String JwtSecretKey => Environment.GetEnvironmentVariable("JWT_TOP_SECRET_KEYYES_JUST_FOR_EXAMPLE_PURPOSES_BUT_MAKE_IT_LONGER");
    }
}
