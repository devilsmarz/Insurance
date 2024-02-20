using BeautyTrackSystem.DLL.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Insurance.DLL.Models.Entities
{
    public class AgentModel
    {
        public Int32? Id { get; set; }
        [MaxLength(255)]
        public String? Address { get; set; }
        [MaxLength(255)]
        public String? Phone { get; set; }
        [MaxLength(20)]
        public String? Name { get; set; }
        public BranchModel? Branch { get; set; }
        public UserEntityModel? User { get; set; }
        public IEnumerable<ContractModel>? Contracts { get; set; }
    }
}
