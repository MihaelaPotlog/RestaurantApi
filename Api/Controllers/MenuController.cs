using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using Service.DTOs;
using Service.DTOs.RequestDTOs;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        private readonly ILogger<MenuController> _logger;

        public MenuController(ILogger<MenuController> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDish(string id)
        {
            var response = await _menuService.Get(id);
            if(response.Succeeded == true)
                return Ok(await _menuService.Get(id));
            return NotFound(response);
        }
        [HttpGet]
        public async Task<ActionResult> GetMenu()
        {
            return Ok(await _menuService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> AddDish(CreateDishDto request)
        {
            var dish = await _menuService.Create(request);
            Uri uri = new Uri($"http://localhost:5000/api/menu/{dish.Id}");
            return Created(uri, dish);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(string id)
        {
            if (await _menuService.Delete(id) == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateDish(string id, ModifyDishDto request)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ReplaceDish(string id, ModifyDishDto request)
        {
            await _menuService.Replace(id, request);
            return NoContent();
        }

    }
}
