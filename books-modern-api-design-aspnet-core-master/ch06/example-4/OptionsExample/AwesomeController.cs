using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OptionsExample
{
    [Route("api/[controller]")]
    public class AwesomeController : Controller
    {

        private readonly AwesomeOptions awesomeOptions;
        private readonly AwesomeOptions.BazOptions bazOptions;

        public AwesomeController(IOptionsSnapshot<AwesomeOptions> awesomeOptions, IOptions<AwesomeOptions.BazOptions> bazOptions)
        {
            this.awesomeOptions = awesomeOptions.Value;
            this.bazOptions = bazOptions.Value;
        }
        
        public IActionResult Get()
        {
            return Ok();
        }

    }
}
