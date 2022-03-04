using BCF.BusinessLogic.Interfaces;
using BCF.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BetterCallFrank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class VehicleController : ControllerBase
    {
        public readonly IVehicleService VehicleService;

        public VehicleController(IVehicleService _VehicleService)
        {
            VehicleService = _VehicleService;
        }

        [HttpGet("getVehicles")]
        public ActionResult<IEnumerable<VehicleDTO>> GetAll()
        {
            var vehicles = VehicleService.GetAll();
            return Ok(vehicles);
        }
    }
}
