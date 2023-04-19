using System;
using System.Collections.Generic;
using System.Text;
using EisenhowerMain;

namespace EisenhowerMain { 

    public class TodoQuarter
    {
        //Instance Attributes
        private List<TodoItem> ToDoItems;
        
        //Constructor
        public TodoQuarter()
        {
            ToDoItems = new List<TodoItem>();
        }
        
        //Instance Methods
        public void AddItem(string title, DateTime deadline)
        {
            TodoItem item = new TodoItem(title, deadline);
            ToDoItems.Add(item);
        }

        public void RemoveItem(int index)
        {
            ToDoItems.RemoveAt(index);
        }

        public void ArchiveItems()
        {
            ToDoItems.RemoveAll(item => item._isDone);
        }

        public TodoItem GetItem(int index)
        {
            return ToDoItems[index];
        }

        public List<TodoItem> GetItems()
        {
            return ToDoItems;
        }

        public override string ToString()
        {
            string result = "";
            foreach (TodoItem item in ToDoItems)
            {
                result += item.ToString();
            }

            return result.TrimEnd();
        }
    }

}