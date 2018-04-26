using System.Collections.Generic;

namespace GraphQLSample.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetOne(int id);
    }
}
