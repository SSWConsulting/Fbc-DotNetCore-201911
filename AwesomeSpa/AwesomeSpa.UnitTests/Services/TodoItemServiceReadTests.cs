using Xunit;
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
        }
    }
}
