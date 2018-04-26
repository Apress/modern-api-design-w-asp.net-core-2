using Microsoft.AspNetCore.Mvc;
using System;

namespace Exceptions
{
    [Route("~/broken")]
    public class ExampleController
    {
        public string Get(int id)
        {
            throw new ArgumentNullException();
        }
    }
}
