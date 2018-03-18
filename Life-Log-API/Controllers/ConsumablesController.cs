﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Life_Log_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Life_Log_API.Controllers
{
    [Route("api/[controller]")]
    public class ConsumablesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Consumable> Get()
        {
            var allConsumables = new Consumable[]
            {
                new Consumable { Name = "Buffalo Wings" },
                new Consumable { Name = "TV" },
                new Consumable { Name = "Podcast" }
            };
            return allConsumables;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
