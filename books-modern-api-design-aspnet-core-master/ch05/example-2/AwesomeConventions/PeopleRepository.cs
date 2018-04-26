using System.Collections.Generic;

namespace AwesomeConventions
{
    public class PeopleRepository : IPeopleRepository
    {
        public IEnumerable<string> All => new string[] { "Fanie", "John", "Joe" };
    }
}
