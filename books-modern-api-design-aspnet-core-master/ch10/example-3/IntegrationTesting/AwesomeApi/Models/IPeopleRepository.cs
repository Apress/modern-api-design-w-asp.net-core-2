using System.Threading.Tasks;

namespace AwesomeApi.Models
{
    public interface IPeopleRepository
    {
        Task<PersonDto> GetOneAsync(int id);
    }
}