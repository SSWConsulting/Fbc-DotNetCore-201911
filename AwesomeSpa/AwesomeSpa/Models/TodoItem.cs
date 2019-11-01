using System;
using System.ComponentModel.DataAnnotations;

namespace AwesomeSpa.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

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