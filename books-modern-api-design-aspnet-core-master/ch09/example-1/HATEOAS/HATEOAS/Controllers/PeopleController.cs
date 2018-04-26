using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HATEOAS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HATEOAS.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private List<PersonDto> people = new List<PersonDto>
        {
            new PersonDto { Id = 1, Name = "Fanie", Email = "fanie@reynders.co"},
            new PersonDto { Id = 2, Name = "Maarten", Email = "maarten@example.com"},
            new PersonDto { Id = 3, Name = "Marcel", Email = "marcel@example.com"},
        };

        //...
        [HttpGet(Name = "get-people")]
        public IActionResult Get()
        {
            var result = new ResourceList<PersonDto>(people);
            result.Items.ForEach(p =>
            {
                p.Links.Add(new Link("self", Url.Link("get-people", new { id = p.Id }), "GET"));
                p.Links.Add(new Link("get-person", Url.Link("get-person", new { id = p.Id }), "GET"));
            });
            result.Links.Add(new Link("create-person", Url.Link("create-person", null), "POST"));

            return Ok(result);
        }
        [HttpGet("{id}", Name = "get-person")]
        public IActionResult Get(int id)
        {
            var person = people.SingleOrDefault(p => p.Id == id);
            person.Links.Add(new Link("self", Url.Link("get-person", new { id }), "GET"));
            person.Links.Add(new Link("update-person", Url.Link("update-person", new { id }), "UPDATE"));
            person.Links.Add(new Link("delete-person", Url.Link("delete-person", new { id }), "DELETE"));
            return Ok(person);
        }
        [HttpPost(Name = "create-person")]
        public IActionResult Post([FromBody]PersonDto person)
        {
            person.Id = people.Count() + 1;
            people.Add(person);

            return CreatedAtAction(nameof(Get), person.Id);
        }
        [HttpPut("{id}", Name = "update-person")]
        public IActionResult Put(int id, [FromBody]PersonDto person)
        {
            //update logic 

            return Ok();
        }
        [HttpDelete("{id}", Name = "delete-person")]
        public IActionResult Delete(int id)
        {
            //delete logic 

            return Ok();
        }
    }
}
