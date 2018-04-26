using System.Collections.Generic;

namespace Shared
{
    public interface IPeopleService
    {
        IEnumerable<Person> GetAllPeople();
        bool DoesExists(int id);
        bool Validated(Person id);
        Person GetOnePerson(int id);
        void Create(Person person);
    }
}