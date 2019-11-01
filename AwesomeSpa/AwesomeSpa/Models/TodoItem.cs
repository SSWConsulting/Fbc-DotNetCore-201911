using System;
using System.ComponentModel.DataAnnotations;

namespace AwesomeSpa.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(250)]
        // TODO: This should also be unique.
        public string Title { get; set; }

        public bool Done { get; set; }

        // TODO: This is required, if Done is true
        public DateTime? Completed { get; set; }

        public override string ToString()
        {
            if (!Done)
            {
                return $"Id: {Id}, Title: {Title}, Done: Not Complete";
            }

            return $"Id: {Id}, Title: {Title}, Done: {Completed.Value.ToShortDateString()}";
        }
    }
}