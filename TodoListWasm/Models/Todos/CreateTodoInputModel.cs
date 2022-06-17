﻿using System.ComponentModel.DataAnnotations;

namespace TodoListWasm.Models.Todos
{
    public class CreateTodoInputModel
    {
        [Required]
        [MinLength(5)]
        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public int UserId { get; set; }
    }
}
