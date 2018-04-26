using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ConventionExample.Controllers
{
    public class PeopleController
    {
        private readonly IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            this._peopleService = peopleService;
        }
        
        public IActionResult Get()
        {
            var people = _peopleService.GetAllPeople();
            return new OkObjectResult(people);
        }
        public IActionResult Get(int id)
        {
            if (_peopleService.DoesExists(id))
            {
                var person = _peopleService.GetOnePerson(id);
                return new OkObjectResult(person);
            }
            return new NotFoundResult();
        }
        public IActionResult Post(Person person)
        {
            if (_peopleService.Validated(person))
            {
                _peopleService.Create(person);
                return new CreatedAtRouteResult(nameof(this.Get), person.Id);
            }
            return new BadRequestResult();
        }
    }
}
