using AwesomeSpa.Services;
using Xunit;
using Shouldly;
using System.Threading.Tasks;
using System.Linq;

namespace AwesomeSpa.UnitTests.Services
{
    [Collection("ReadTests")]
    public class TodoItemServiceReadTests
    {
        private readonly TestBase _testBase;

        public TodoItemServiceReadTests(TestBase testBase)
        {
            _testBase = testBase;
        }

        [Fact]
        public async Task GetAll_ShouldReturn4Items()
        {
            // Arrange
            var service = new TodoItemService(_testBase.Context);

            // Act
            var result = await service.GetAll();

            // Assert
            result.Count().ShouldBe(4);
        }
    }
}
