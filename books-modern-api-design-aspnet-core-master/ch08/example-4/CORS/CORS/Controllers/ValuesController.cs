using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CORS.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AwesomePolicy2")]
    public class ValuesController : Controller
    {
        // GET api/values
        [EnableCors("AnotherAwesomePolicy")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [DisableCors]
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

     
    }
}
