using DLL;
using Insurance.DLL.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeautyTrack_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private ApplicationContext _applicationContext { get; set; }
        public AgentController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        // GET: api/<AgentController>
        [HttpGet]
        public IEnumerable<AgentModel> Get()
        {
            return _applicationContext.Agents.ToList();
        }

        // GET api/<AgentController>/5
        [HttpGet("{id}")]
        public AgentModel Get(int id)
        {
            return _applicationContext.Agents.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<AgentController>
        [HttpPost]
        public void Post([FromBody] AgentModel value)
        {
            var model = new AgentModel()
            {
                Address = value.Address,
                Branch = _applicationContext.Branches.FirstOrDefault(x => x.Id == value.Branch.Id),
                Name = value.Name,
                Phone = value.Phone,
            };

            _applicationContext.Agents.Add(model);
            _applicationContext.SaveChanges();
        }

        [HttpGet("getAgentExcel")]
        public ActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var agents = _applicationContext.Agents.ToList();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Agents");

                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Address";
                worksheet.Cells[1, 3].Value = "Phone";
                worksheet.Cells[1, 4].Value = "Name";

                int row = 2;
                foreach (var agent in agents)
                {
                    worksheet.Cells[row, 1].Value = agent.Id;
                    worksheet.Cells[row, 2].Value = agent.Address;
                    worksheet.Cells[row, 3].Value = agent.Phone;
                    worksheet.Cells[row, 4].Value = agent.Name;
                    row++;
                }

                MemoryStream stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Agents.xlsx");
            }
        }
    }
}
