using DLL;
using Insurance.DLL.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeautyTrack_System.Controller
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private ApplicationContext _applicationContext { get; set; }
        public BranchController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        // GET: api/<BranchController>
        [HttpGet]
        public IEnumerable<BranchModel> Get()
        {
            return _applicationContext.Branches.ToList();
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public BranchModel Get(int id)
        {
            return _applicationContext.Branches.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<BranchController>
        [HttpPost]
        public void Post([FromBody] BranchModel value)
        {
            _applicationContext.Branches.Add(value);
            _applicationContext.SaveChanges();
        }
        [HttpGet("getBranchExcel")]
        public ActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var branches = _applicationContext.Branches.ToList();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Branches");

                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Address";
                worksheet.Cells[1, 3].Value = "Phone";
                worksheet.Cells[1, 4].Value = "Name";

                int row = 2;
                foreach (var branch in branches)
                {
                    worksheet.Cells[row, 1].Value = branch.Id;
                    worksheet.Cells[row, 2].Value = branch.Address;
                    worksheet.Cells[row, 3].Value = branch.Phone;
                    worksheet.Cells[row, 4].Value = branch.Name;
                    row++;
                }

                MemoryStream stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Branches.xlsx");
            }
        }
    }
}
