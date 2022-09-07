using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RightController : ControllerBase
    {
        private IRightLogic _rightLogic;
        public RightController(IRightLogic rightLogic) 
        {
            this._rightLogic = rightLogic;
        }

        [HttpGet]
        public async Task<List<RightModel>> GetAllRight()
        {
            var res = await _rightLogic.GetAllRight();
            return res;
        }

        [HttpPost]
        public async Task<string> SaveRight(RightRequestModel rightRequestModel)
        {
            var res = await _rightLogic.SaveRight(rightRequestModel);
            return res;
        }
        
    }
}
