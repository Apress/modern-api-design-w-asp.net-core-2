using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomFormatter
{
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {
        public IActionResult Get()
        {
            IEnumerable<PersonDto> result = new PersonDto[]{
                new PersonDto { FirstName = "Fanie", LastName = "Reynders" },
                new PersonDto { FirstName = "Joe", LastName = "Soap" }
            };
            return Ok(result);
        }
    }
}
