namespace BeautyTrackSystem.BLL.Models
{
    public class PasswordModel
    {
        public Byte[] PasswordHash { get; set; }
        public Byte[] PasswordSalt { get; set; }
    }
}
