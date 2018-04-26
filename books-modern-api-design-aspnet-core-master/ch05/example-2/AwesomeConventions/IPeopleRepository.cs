using System.Collections.Generic;

namespace AwesomeConventions
{
    public interface IPeopleRepository
    {
        IEnumerable<string> All { get; }
    }
}
