using BeautyTrackSystem.DLL.Enums;
using Insurance.DLL.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace BeautyTrackSystem.DLL.Models.Entities
{
    public class UserEntityModel
    {
        public Int32? Id { get; set; }
        [MaxLength(255)]
        public String? Email { get; set; }
        [MaxLength(20)]
        public String? Phone { get; set; }
        [MaxLength(255)]
        public String? Name { get; set; }
        public Byte[]? PasswordHash { get; set; }
        public Byte[]? PasswordSalt { get; set; }
        public Roles? RoleId { get; set; }
        public IEnumerable<AgentModel>? Agents { get; set; }
    }
}
