using System;
using System.Collections.Generic;

namespace EisenhowerMain { 

    public class TodoQuarter
    {
        //Instance Attributes
        private readonly List<TodoItem> _todoItems;
        
        //Constructor
        public TodoQuarter()
        {
            _todoItems = new List<TodoItem>();
        }
        
        //Instance Methods
        public void AddItem(string title, DateTime deadline)
        {
            TodoItem item = new TodoItem(title, deadline);
            _todoItems.Add(item);
        }

        public void RemoveItem(int index)
        {
            _todoItems.RemoveAt(index);
        }

        public void ArchiveItems()
        {
            _todoItems.RemoveAll(item => item.isDone);
        }

        public TodoItem GetItem(int index)
        {
            return _todoItems[index];
        }

        public List<TodoItem> GetItems()
        {
            return _todoItems;
        }

        public override string ToString()
        {
            string result = "";
            foreach (TodoItem item in _todoItems)
            {
                result += item.ToString();
            }

            return result.TrimEnd();
        }
    }

}