using DLL;
using Insurance.DLL.Models.Entities;
using Microsoft.AspNetCore.Mvc;

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
                User = _applicationContext.Users.FirstOrDefault(x => x.Id == value.User.Id),
            };

            _applicationContext.Agents.Add(model);
            _applicationContext.SaveChanges();
        }
    }
}
