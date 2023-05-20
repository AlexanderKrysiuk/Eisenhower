using System;
using System.Collections.Generic;

namespace EisenhowerMain
{

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
            ToDoItems.RemoveAll(item => item.GetStatus());
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
        
        public string TurnListIntoString()
        {
            int index = 1;
            string items = "";
            foreach (var item in GetItems())
            {
                if (item.GetStatus() == false)
                {
                    DateTime currentTime = DateTime.Now;
                    TimeSpan difference = currentTime.Subtract(item.GetDeadline());
            
                    switch (difference.Days)
                    {
                        case var expression when difference.Days > 3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case var expression when difference.Days <= 3:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case var expression when difference.Days == 0:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                items += index + ". " + item +"\n";
                index++;
                Console.ForegroundColor = ConsoleColor.White;
            }
            return items;
        }
    }

}