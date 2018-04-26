using System.Collections.Generic;

namespace Shared
{
    /// <summary>
    /// Mock implementation
    /// </summary>
    public class PeopleService : IPeopleService
    {
        public void Create(Person person)
        {
            // add person to data store
        }

        public bool DoesExists(int id)
        {
            //check if exists
            return true;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            //retrieve people from data store
            return new Person[]
            {
                new Person{ Id = 1, Name = "Sam"},
                new Person{ Id = 2, Name = "John"},
                new Person{ Id = 3, Name = "Trevor"},
            };
        }

        public Person GetOnePerson(int id)
        {
            //retrieve one person
            return new Person { Id = 2, Name = "John" };
        }

        public bool Validated(Person id)
        {
            //do validation
            return true;
        }
    }
}
