namespace GraphQLSample.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Person[] Friends { get; set; } = new Person[] { };
    }
}
