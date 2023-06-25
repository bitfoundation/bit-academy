using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        private List<TodoItem> TodoList = new();
        private List<TodoItem> FilteredTodoList = new();
        private string TodoName { get; set; }
        public string NewName { get; set; }
        private string SearchTerm;
        private string FilterValue;

        public void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(TodoName))
            {
                var newTask = new TodoItem()
                {
                    Id = TodoList.Count() + 1,
                    Title = TodoName,

                    IsDone = false
                };

                TodoList.Add(newTask);
                Filter();
                TodoName = null;
            }
        }

        public void DeleteTodoItem(TodoItem todo)
        {
            TodoList.Remove(todo);
            Filter();
        }

        public void EditTodoItem(TodoItem todo)
        {
            todo.IsEdit = true;
        }

        public void EditTodo(TodoItem todo)
        {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                todo.IsEdit = false;
                todo.Title = NewName;
                NewName = null;
            }
        }

        public void CancelEditTodo(TodoItem todo)
        {
            todo.IsEdit = false;
            NewName = null;
        }

        private void HandleTodoChange(TodoItem todo)
        {
            todo.IsDone = !todo.IsDone;
            Filter();
        }

        private void HandleClear()
        {
            HandleSearch("");
        }

        private void HandleSearch(string searchTerm)
        {
            SearchTerm = searchTerm;
            Filter();
        }

        private void HandleFilterChange(ChangeEventArgs e)
        {
            FilterValue = (string)e.Value;
            Filter();
        }

        private void Filter()
        {
            FilteredTodoList = TodoList.Where(item =>
            {
                var result = string.IsNullOrWhiteSpace(SearchTerm) || item.Title.ToLower().Contains(SearchTerm.ToLower());
                if (result is false) return false;
                if (string.IsNullOrWhiteSpace(FilterValue) is false)
                {
                    switch (FilterValue)
                    {
                        case "Active":
                            return !item.IsDone;
                        case "Completed":
                           return item.IsDone;
                    }

                }
                return true;
            }).ToList();

        }
    }
}

