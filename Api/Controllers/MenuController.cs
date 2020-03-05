using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IDishesService _menuService;

        private readonly ILogger<MenuController> _logger;

        public MenuController(ILogger<MenuController> logger, IDishesService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }

        [HttpGet]
        public IActionResult GetMenu()
        {
            // ...
            return Ok();
        }

        [HttpPost]
        public IActionResult AddDish()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteDish()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDish()
        {
            return Ok();
        }

    }
}
