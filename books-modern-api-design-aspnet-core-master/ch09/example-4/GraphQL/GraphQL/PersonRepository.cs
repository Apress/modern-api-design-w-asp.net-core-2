using System.Collections.Generic;
using System.Linq;

namespace GraphQLSample.Models
{
    public class PersonRepository : IPersonRepository
    {
        Person[] friends;
        Person[] people;
        public PersonRepository()
        {
            friends = new Person[]
                    {
                new Person{Id = 4, Email = "friend1@email.com", Name = "Friend 1"},
                new Person{Id = 5, Email = "friend2@email.com", Name = "Friend 2"},
                new Person{Id = 6, Email = "friend3@email.com", Name = "Friend 3"},
                    };
            people = new Person[]
               {
                new Person{Id = 1, Email = "joe@email.com", Name = "Joe", Friends = friends},
                new Person{Id = 2, Email = "will@email.com", Name = "Will", Friends = friends},
                new Person{Id = 3, Email = "sam@email.com", Name = "Sam", Friends = friends}
               };
        }
        public IEnumerable<Person> GetAll()
        {
            return people;
        }

        public Person GetOne(int id)
        {
            return people.Single(p => p.Id == id);
        }
    }
}
