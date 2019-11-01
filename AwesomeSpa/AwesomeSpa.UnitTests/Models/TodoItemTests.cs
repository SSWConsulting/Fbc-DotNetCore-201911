using AwesomeSpa.Models;
using Xunit;
using Shouldly;

namespace AwesomeSpa.UnitTests.Models
{
    public class TodoItemTests
    {
        [Fact]
        public void ToString_GivenValidTodoItem_ReturnsCorrectResult()
        {
            // Arrange
            var todoItem = new TodoItem
            {
                Id = 1,
                Title = "Do this thing.",
                Done = false,
            };

            // Act
            var result = todoItem.ToString();

            // Assert
            result.ShouldBe("Id: 1, Title: Do this thing., Done: Not Complete");
        }
    }
}
