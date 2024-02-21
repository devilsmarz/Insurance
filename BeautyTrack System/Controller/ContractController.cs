using DLL;
using Insurance.DLL.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace BeautyTrack_System.Controller
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private ApplicationContext _applicationContext { get; set; }
        public ContractController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        // GET: api/<ContractController>
        [HttpGet]
        public IEnumerable<ContractModel> Get()
        {
            return _applicationContext.Contracts.ToList();
        }

        // GET api/<ContractController>/5
        [HttpGet("{id}")]
        public ContractModel Get(int id)
        {
            return _applicationContext.Contracts.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<ContractController>
        [HttpPost]
        public void Post([FromBody] ContractModel value)
        {
            var model = new ContractModel()
            {
                Amount = value.Amount,
                Date = value.Date,
                Insurance_Type = value.Insurance_Type,
                TarifRate = value.TarifRate,
                Type = value.Type,
                Branch = _applicationContext.Branches.FirstOrDefault(x => x.Id == value.Branch.Id),
                Agent = _applicationContext.Agents.FirstOrDefault(x => x.Id == value.Agent.Id),
                ClientEmail = value.ClientEmail,
                ClientName = value.ClientName,
                ClientPassportCode = value.ClientPassportCode,
                ClientPatronymic = value.ClientPatronymic,
                ClientPhone = value.ClientPhone,
                ClientSurname = value.ClientSurname,
            };

            _applicationContext.Contracts.Add(model);
            _applicationContext.SaveChanges();
        }
        [HttpGet("getContractExcel")]
        public ActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var contracts = _applicationContext.Contracts.ToList();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Contracts");

                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Date";
                worksheet.Cells[1, 3].Value = "Amount";
                worksheet.Cells[1, 4].Value = "TarifRate";
                worksheet.Cells[1, 5].Value = "Insurance_Type";
                worksheet.Cells[1, 6].Value = "ClientName";
                worksheet.Cells[1, 7].Value = "ClientSurname";
                worksheet.Cells[1, 8].Value = "ClientPatronymic";
                worksheet.Cells[1, 9].Value = "ClientPassportCode";
                worksheet.Cells[1, 10].Value = "ClientPhone";
                worksheet.Cells[1, 11].Value = "ClientEmail";
                worksheet.Cells[1, 12].Value = "Type";

                int row = 2;
                foreach (var contract in contracts)
                {
                    worksheet.Cells[row, 1].Value = contract.Id;
                    worksheet.Cells[row, 2].Value = contract.Date;
                    worksheet.Cells[row, 3].Value = contract.Amount;
                    worksheet.Cells[row, 4].Value = contract.TarifRate;
                    worksheet.Cells[row, 5].Value = contract.Insurance_Type;
                    worksheet.Cells[row, 6].Value = contract.ClientName;
                    worksheet.Cells[row, 7].Value = contract.ClientSurname;
                    worksheet.Cells[row, 8].Value = contract.ClientPatronymic;
                    worksheet.Cells[row, 9].Value = contract.ClientPassportCode;
                    worksheet.Cells[row, 10].Value = contract.ClientPhone;
                    worksheet.Cells[row, 11].Value = contract.ClientEmail;
                    worksheet.Cells[row, 12].Value = contract.Type;
                    row++;
                }

                MemoryStream stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Contracts.xlsx");
            }
        }
    }
}
