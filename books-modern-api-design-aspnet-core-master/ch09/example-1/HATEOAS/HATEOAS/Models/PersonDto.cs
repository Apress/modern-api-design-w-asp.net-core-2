namespace HATEOAS.Models
{
    public class PersonDto : Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
