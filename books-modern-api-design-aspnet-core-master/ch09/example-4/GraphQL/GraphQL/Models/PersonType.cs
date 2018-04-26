using GraphQL.Types;

namespace GraphQLSample.Models
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Email);
            Field<ListGraphType<PersonType>>("friends");
        }
    }
}
