using AwesomeSpa.Data;
using AwesomeSpa.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeSpa.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _context.TodoItems
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TodoItem> Get(long id)
        {
            var entity = await _context
                .TodoItems
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

            return entity;
        }

        public async Task Add(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);

            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> Update(long id, TodoItem todoItem)
        {
            var entity = await _context.TodoItems.FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            entity.Title = todoItem.Title;
            entity.Done = todoItem.Done;
            entity.Completed = todoItem.Completed;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TodoItem> Delete(long id)
        {
            var entity = await _context.TodoItems.FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            _context.TodoItems.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
