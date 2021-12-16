﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Server
{
    [Route("toppings")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ToppingsController : Controller
    {
        private readonly PizzaStoreContext _db;

        public ToppingsController(PizzaStoreContext db)
        {
            _db = db;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Topping>>> GetToppings()
        {
            return Ok(await _db.Toppings.OrderBy(t => t.Id).ToListAsync());
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Topping>> DetailTopping([FromQuery] int id)
        {
            var topping = await _db.Toppings.FindAsync(id);
            if (topping == null)
                return NotFound();
            return Ok(topping);
        }

        [HttpPost]
        public async Task<ActionResult> PostTopping([FromBody] Topping topping)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
                
            await _db.Toppings.AddAsync(topping);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutTopping([FromBody] Topping topping)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
                
            _db.Toppings.Update(topping);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTopping([FromQuery] int id)
        {
            var topping = await _db.Toppings.FindAsync(id);
            if (topping == null) return NotFound();
            _db.Toppings.Remove(topping);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
