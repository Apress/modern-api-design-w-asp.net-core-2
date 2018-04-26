using System.Net.Http;
using System.Threading.Tasks;

namespace AwesomeApi.Models
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly HttpClient client;
        public PeopleRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<PersonDto> GetOneAsync(int id)
        {
            var personResponse = await client.GetAsync($"https://api.awesome.io/customers/names/{id}");
            var personName = await personResponse.Content.ReadAsStringAsync();

            return new PersonDto
            {
                Id = id,
                Name = personName
            };
        }
    }
}