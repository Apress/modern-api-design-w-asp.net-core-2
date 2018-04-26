using System.Threading.Tasks;
using AwesomeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeApi.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository peopleRepository;
        public PeopleController(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }
        [HttpGet("{id}")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Get(int? id)
        {
            if (id.HasValue)
            {
                var person = await peopleRepository.GetOneAsync(id.Value);
                if (person == null)
                {
                    return NotFound();
                }
                return Ok(person);
            }
            return BadRequest();
        }
    }
}
