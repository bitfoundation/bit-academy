using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        public List<TodoItem> TodoList = new();
        public string TodoName { get; set; }
        public string NewName { get; set; }
        string SearchTerm { get; set; } = "";

        //public List<TodoItem> ResultSearch => TodoList.Where(item => item.Title.ToLower().Contains(SearchTerm.ToLower())).ToList();

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
                TodoName = null;
            }
        }

        public void DeleteTodoItem(TodoItem todo)
        {
            TodoList.Remove(todo);
        }

        //public void CompleteTodoItem(TodoItem todo)
        //{
        //    todo.IsDone = !todo.IsDone;
        //}

        public void CheckAll()
        {
            foreach (TodoItem todo in TodoList)
            {
                todo.IsDone = true;
            }
        }

        public void ClearCompleted()
        {
            TodoList.RemoveAll(todo => todo.IsDone);
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
    }
}

