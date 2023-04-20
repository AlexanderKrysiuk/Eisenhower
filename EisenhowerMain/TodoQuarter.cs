using System;
using System.Collections.Generic;

namespace EisenhowerMain
{
    public class TodoQuarter
    {
        //Instance Attributes
        private readonly List<TodoItem> _toDoItems;

        //Constructor
        public TodoQuarter()
        {
            _toDoItems = new List<TodoItem>();
        }

        //Instance Methods
        public void AddItem(string title, DateTime deadline)
        {
            var item = new TodoItem(title, deadline, true);
            _toDoItems.Add(item);
        }


        public void RemoveItem(int index)
        {
            _toDoItems.RemoveAt(index);
        }


        public void ArchiveItems()
        {
            _toDoItems.RemoveAll(item => item.IsDone);
        }


        public TodoItem GetItem(int index)
        {
            return _toDoItems[index];
        }


        public List<TodoItem> GetItems()
        {
            return _toDoItems;
        }


        public override string ToString()
        {
            var result = "";
            foreach (var item in _toDoItems) result += item.ToString();


            return result.TrimEnd();
        }
    }
}