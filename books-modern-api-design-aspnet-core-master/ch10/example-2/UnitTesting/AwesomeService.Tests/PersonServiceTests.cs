using Moq;
using Xunit;

namespace AwesomeService.Tests
{
    public class PersonServiceTests
    {
        [Fact]
        public void Return_Count_Of_Letters()
        {
            var personRepositoryMock = new Mock<IPersonRepository>();
            personRepositoryMock.Setup(p => p.GetNames()).Returns(new string[] { "Fanie", "Gerald", "Mike" });
            PersonService personService = new PersonService(personRepositoryMock.Object);
            var actualResult = personService.CountLetters();
            var expectedResult = 15;
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
