using DLL;
using Insurance.DLL.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeautyTrack_System.Controller
{
    [Route("api/[controller]")]
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
    }
}
