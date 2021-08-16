using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }

        public bool IsEdit { get; set; } = false;
    }

