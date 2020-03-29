using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IIngredientsService _ingredientsService;

        public StockController(IIngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }

        [HttpGet("ingredients/{id}")]
        public async Task<ActionResult<IngredientOnStock>> Get(Guid id)
        {
            IngredientOnStock searchedIngredient = await _ingredientsService.Get(id);

            if(searchedIngredient != null)
                return Ok(searchedIngredient);
            else
                return NotFound();
        }

        [HttpGet("ingredients")]
        public async Task<ActionResult<List<IngredientOnStock>>> GetAll()
        {
            var all = await _ingredientsService.GetAll();
            if (all != null)
                return Ok(all);
            else
                return NotFound();
        }

        // [HttpPost("ingredients")]
        // public async Task<ActionResult<string>> Add(IngredientDto addDto)
        // {
        //
        // }
    }
}