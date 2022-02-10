using BCF.BusinessLogic.Interfaces;
using BCF.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BetterCallFrank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class WarehouseController : ControllerBase
    {
        public readonly IWarehouseService warehouseService;

        public WarehouseController(IWarehouseService _warehouseService)
        {
            warehouseService = _warehouseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WarehouseDTO>> GetAll()
        {
            var warehouses = warehouseService.GetAll();
            return Ok(warehouses);
        }

        [HttpPost("seedDatabase")]
        public async Task<IActionResult> SeedDatabase()
        {
            try
            {
                await warehouseService.SeedDatabase();
                return Ok("Database has been seeded successfully.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
