using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Life_Log_API.Models;
using Life_Log_API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Life_Log_API.Controllers
{
    [Route("api/[controller]")]
    public class ConsumablesController : Controller
    {

        private readonly IConsumablesService _consumablesService;

        public ConsumablesController(IConsumablesService ConsumablesService)
        {
            _consumablesService = ConsumablesService ?? throw new ArgumentNullException(nameof(ConsumablesService));
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Consumable> Get()
        {
            var allConsumables = _consumablesService.Get();
            return allConsumables;
        }
            
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var requestedConsumable = _consumablesService.Get(id);
                return Ok(requestedConsumable);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Consumable consumableToSave)
        {
            var newConsumable = _consumablesService.Post(consumableToSave);
            return Ok(newConsumable);
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
