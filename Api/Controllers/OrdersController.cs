using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs.RequestDTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        // ***
        [HttpPost]
        public async Task<ActionResult> Create(CreateOrderDto request)
        {
            var response = await _ordersService.CreateOrder(request);
            if (response.Succeeded == true)
                return Ok(response);
            else 
                return BadRequest();
        }

        // [HttpGet]
        // public async Task<ActionResult> GetAll()
        // {
        //     // return Ok(await _ordersService.GetAll());
        //     return Ok("GRRR");
        // }

        [HttpGet]
        public ActionResult GetWithinDateInterval([FromQuery] DateTime startDate,[FromQuery] DateTime finishDate)
        {
            return Ok(_ordersService.GetAllWithinRange(startDate, finishDate));
            
        }

    }
}