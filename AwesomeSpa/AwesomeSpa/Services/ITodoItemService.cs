using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeSpa.Models;

namespace AwesomeSpa.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetAll();

        Task<TodoItem> Get(long id);

        Task Add(TodoItem todoItem);
        
        Task<TodoItem> Update(long id, TodoItem todoItem);
        
        Task<TodoItem> Delete(long id);
    }
}