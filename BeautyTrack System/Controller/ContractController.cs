using DLL;
using Insurance.DLL.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeautyTrack_System.Controller
{
    [Route("api/[controller]")]
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
            };

            _applicationContext.Contracts.Add(model);
            _applicationContext.SaveChanges();
        }
    }
}
