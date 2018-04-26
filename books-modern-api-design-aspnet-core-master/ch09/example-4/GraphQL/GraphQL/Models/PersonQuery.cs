using GraphQL.Types;

namespace GraphQLSample.Models
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPersonRepository personRepository)
        {
            Field<PersonType>("person",
            arguments: new QueryArguments(
            new QueryArgument<IntGraphType>() { Name = "id" }),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                return personRepository.GetOne(id);
            });
            Field<ListGraphType<PersonType>>("people",
            resolve: context =>
            {
                return personRepository.GetAll();
            });
        }
    }
}
