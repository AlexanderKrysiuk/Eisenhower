using EisenhowerCore;
using EisenhowerMain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EisenhowerMain
{

    public class TodoMatrix
    {
        private Dictionary<string, TodoQuarter> todoQuarters = new Dictionary<string, TodoQuarter>();

        public TodoMatrix()
        {
            todoQuarters.Add("IU", new TodoQuarter());
            todoQuarters.Add("IN", new TodoQuarter());
            todoQuarters.Add("NU", new TodoQuarter());
            todoQuarters.Add("NN", new TodoQuarter());
        }

        public Dictionary<string, TodoQuarter> GetQuarters()
        {
            return todoQuarters;
        }

        public TodoQuarter GetQuarter(string status)
        {
            foreach (KeyValuePair<string, TodoQuarter> entry in todoQuarters)
            {
                if (entry.Key == status)
                {
                    return entry.Value;
                }
            }
            TodoQuarter other = new TodoQuarter();
            return other;
        }

        public void AddItem(string title, DateTime deadline, bool isImportant)
        {
            string status = GetStatus(deadline, isImportant);
            todoQuarters[status].AddItem(title, deadline);
        }

        public void AddItem(string title, DateTime deadline)
        {
            string status = GetStatus(deadline, false);
            todoQuarters[status].AddItem(title, deadline);
        }

        public void AddItemsFromFile(string filename)
        {

        }

        public void SaveItemsToFile(string filename)
        {

        }

        public void ArchiveItems()
        {
            foreach (KeyValuePair<string, TodoQuarter> entry in todoQuarters)
            {
                foreach (TodoItem item in entry.Value.GetItems())
                {
                    if (item._isDone == true)
                    {
                        entry.Value.GetItems().Remove(item);
                    }
                }
            }
        }

        public string GetStatus(DateTime deadline, bool isImportant)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan difference = currentTime.Subtract(deadline);
            if (difference.Days > 3)
            {
                if (isImportant)
                {
                    return "IN";
                }
                else
                {
                    return "NN";
                }
            }
            else
            {
                if (isImportant)
                {
                    return "IU";
                }
                else
                {
                    return "NU";
                }
            }
        }

        public override string ToString()
        {
            string writtenMatrix = "";
            foreach (KeyValuePair<string, TodoQuarter> entry in todoQuarters)
            {
                switch (entry.Key)
                {
                    case "IU":
                        writtenMatrix += "Important, urgent: ";
                        break;
                    case "IN":
                        writtenMatrix += "Important, not urgent: ";
                        break;
                    case "NU":
                        writtenMatrix += "Not important, urgent: ";
                        break;
                    case "NN":
                        writtenMatrix += "Not important, not urgent: ";
                        break;
                }
                writtenMatrix += entry.Value.ToString();
                writtenMatrix += "\n";
            }
            return writtenMatrix;
        }
    }
}