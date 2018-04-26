using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Collections.Generic;
using System.Linq;

namespace AttributeRoutingExample.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            this._peopleService = peopleService;
        }

        // GET api/people
        [HttpGet("")]
        public IEnumerable<string> Get()
        {
            return _peopleService.GetAllPeople().Select(p=>p.Name);
        }

        // GET api/people/top
        [HttpGet("top/{n}")]
        public IEnumerable<string> GetTopN(int n)
        {
            return _peopleService.GetAllPeople().Take(n).Select(p => p.Name);
        }

        [HttpPost("~/api/person")]
        public IEnumerable<string> Post(Person person)
        {
            _peopleService.Create(person);

            return _peopleService.GetAllPeople().Select(p => p.Name);
        }
    }
}
