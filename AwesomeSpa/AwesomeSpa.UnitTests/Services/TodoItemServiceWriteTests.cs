using AwesomeSpa.Models;
using AwesomeSpa.Services;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace AwesomeSpa.UnitTests.Services
{
    public class TodoItemServiceWriteTests : TestBase
    {
        [Fact]
        public async Task Add_Should_Given()
        {
            var todoItem = new TodoItem
            {
                Id = 5,
                Title = "Write my test examples.",
                Done = false
            };

            var service = new TodoItemService(base.Context);

            await service.Add(todoItem);

            var entity = await Context.TodoItems.FindAsync(todoItem.Id);

            entity.ShouldNotBeNull();
        }
    }
}
