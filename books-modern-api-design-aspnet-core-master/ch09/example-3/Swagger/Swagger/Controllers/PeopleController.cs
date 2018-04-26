using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swagger.Models;

namespace Swagger.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        [HttpGet]
        [Produces(typeof(IEnumerable<PersonDto>))]
        public IActionResult Get()
        {
            return Ok(new PersonDto[] { });
        }

        [HttpGet("{id}")]
        [Produces(typeof(PersonDto))]
        public IActionResult Get(int id)
        {
            return Ok(new PersonDto { });
        }

        [HttpPost]
        public IActionResult Post([FromBody]PersonDto person)
        {
            return CreatedAtAction(nameof(Get), new { id = person.Id });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PersonDto person)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
