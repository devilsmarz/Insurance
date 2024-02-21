using DLL;
using Insurance.DLL.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTrack_System.Controller
{
    public class TaxController : ControllerBase
    {
        private ApplicationContext _applicationContext { get; set; }
        public TaxController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [HttpGet("{id}")]
        public Int32 Get(int id)
        {
            var agentModel = _applicationContext.Agents.FirstOrDefault(x => x.Id == id);
            TaxModel taxModel = new TaxModel();
            Int32 salary = agentModel.Contracts.Count()*taxModel.Bonus + taxModel.Salary;
            return salary;
        }
    }
}
