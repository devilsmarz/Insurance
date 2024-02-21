using DLL;
using Insurance.DLL.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyTrack_System.Controller
{
    [Authorize]
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
            var agentModel = _applicationContext.Agents.Include(p => p.Contracts).FirstOrDefault(x => x.Id == id);
            if (agentModel == null)
            {
                return 0;
            }
            TaxModel taxModel = new TaxModel();
            Int32 salary = agentModel.Contracts.Count()*taxModel.Bonus + taxModel.Salary;
            return salary;
        }
    }
}
