using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Insurance.DLL.Models.Entities
{
    public class ContractModel
    {
        public Int32? Id { get; set; }
        public DateTime? Date { get; set; }
        public Decimal? Amount { get; set; }
        public Decimal? TarifRate { get; set; }
        [MaxLength(255)]
        public String? Insurance_Type { get; set; }
        [MaxLength(255)]
        public String? Type { get; set; }
        public BranchModel? Branch { get; set; }
        public AgentModel? Agent { get; set; }
    }
}
