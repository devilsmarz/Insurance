using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance.DLL.Models.Entities
{
    public class ContractModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? Id { get; set; }
        public Int32? BranchId { get; set; }
        public DateTime? Date { get; set; }
        public Decimal? Amount { get; set; }
        public Decimal? TarifRate { get; set; }
        [MaxLength(255)]
        public String? Insurance_Type { get; set; }
        [MaxLength(255)]
        public String? ClientName { get; set; }
        public String? ClientSurname { get; set; }
        public String? ClientPatronymic { get; set; }
        public String? ClientPassportCode { get; set; }
        public String? ClientPhone { get; set; }
        public String? ClientEmail { get; set; }
        public String? Type { get; set; }
        public BranchModel? Branch { get; set; }
        public AgentModel? Agent { get; set; }
    }
}
