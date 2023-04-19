using System;
using System.Collections.Generic;

namespace EisenhowerMain
{
    public class TodoQuarter
    {
        public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();


        public List<TodoItem> AddItem(string title, DateTime deadline)
        {
            TodoItems.Add(new TodoItem(title, deadline) { Title = title, Deadline = deadline });
            return TodoItems;
        }


        public void RemoveItem(int index)
        {
            TodoItems.RemoveAt(index);
        }


        public List<TodoItem> ArchiveItems()
        {
            for (var i = 0; i < TodoItems.Count; i++)
                if (TodoItems[i].IsDone == true)
                    TodoItems.RemoveAt(i);
            return TodoItems;
        }


        public TodoItem GetItem(int index)
        {
            return TodoItems[index];
        }


        public List<TodoItem> GetItems()
        {
            return TodoItems;
        }


        public override string ToString()
        {
            var quartString = "";


            for (var i = 0; i < TodoItems.Count; i++)
            {
                TodoItem todoItem = TodoItems[i];
                quartString += string.Format("{0}. {1} \n", i + 1, todoItem.ToString());
            }

            return quartString;
        }
    }
}

