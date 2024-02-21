using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Insurance.DLL.Models.Entities
{
    public class BranchModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? Id { get; set; }
        [MaxLength(255)]
        public String? Address { get; set; }
        [MaxLength(255)]
        public String? Phone { get; set; }
        [MaxLength(20)]
        public String? Name { get; set; }
        public IEnumerable<AgentModel>? Agents { get; set; } = default;
        public IEnumerable<ContractModel>? Contracts { get; set; } = default;

    }
}
