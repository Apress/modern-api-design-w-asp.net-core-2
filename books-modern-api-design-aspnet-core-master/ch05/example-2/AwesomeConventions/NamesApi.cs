using AwesomeConventions;
using Microsoft.AspNetCore.Mvc;

namespace Api.People
{
    public class NamesApi
    {
        private readonly IPeopleRepository people;
        public NamesApi(IPeopleRepository people)
        {
            this.people = people;
        }
        public IActionResult Get()
        {
            return new OkObjectResult(people.All);
        }
    }
}