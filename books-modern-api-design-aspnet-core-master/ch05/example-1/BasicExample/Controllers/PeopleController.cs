using Microsoft.AspNetCore.Mvc;
using Shared;

namespace BasicExample.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            this._peopleService = peopleService;
        }
        
        public IActionResult Get()
        {
            var people = _peopleService.GetAllPeople();
            return Ok(people);
        }
        public IActionResult Get(int id)
        {
            if (_peopleService.DoesExists(id))
            {
                var person = _peopleService.GetOnePerson(id);
                return Ok(person);
            }
            return NotFound();
        }
        public IActionResult Post(Person person)
        {
            if (_peopleService.Validated(person))
            {
                _peopleService.Create(person);
                return CreatedAtAction(nameof(this.Get), person.Id);
            }
            return BadRequest();
        }
    }
}
