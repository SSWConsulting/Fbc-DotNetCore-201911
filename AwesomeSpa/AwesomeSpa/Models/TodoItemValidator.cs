using AwesomeSpa.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeSpa.Models
{
    public class TodoItemValidator : AbstractValidator<TodoItem>
    {
        private readonly ApplicationDbContext _context;

        public TodoItemValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .MaximumLength(250)
                .NotEmpty()
                .MustAsync(BeAUniqueTitle)
                .WithMessage("Title must be unique.");

            RuleFor(v => v.Completed)
                .Must(HaveCompletedDateWhenDoneIsTrue)
                .WithMessage("Please specify the date/time this item was done!");
        }

        public bool HaveCompletedDateWhenDoneIsTrue(TodoItem item, DateTime? completed)
        {
            return !item.Done ||
                    item.Completed.HasValue;
        }

        public async Task<bool> BeAUniqueTitle(TodoItem item, string title, 
            CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .Where(t => t.Id != item.Id)
                .AllAsync(l => l.Title != title);
        }
    }
}
