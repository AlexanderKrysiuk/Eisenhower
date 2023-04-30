using EisenhowerCore;
using EisenhowerMain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Globalization;

namespace EisenhowerMain
{

    public class TodoMatrix
    {
        string filepath = "matrix.csv";
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
            using(StreamReader reader = new StreamReader(filename))
            {
                while(!reader.EndOfStream)
                {
                    string text = reader.ReadLine();
                    string[] quarters;
                    quarters = text.Split(';');
                    foreach (string quarter in quarters)
                    {
                        if (quarter.Length == 0)
                        {
                            return;
                        }
                        string importance = quarter[0].ToString();
                        string entries = quarter.Substring(0,4);
                        string[] items = entries.Split("] ");
                        foreach (string item in items)
                        {
                            if (item.Length < 5)
                            {
                                return;
                            }
                            string itemName = Regex.Replace(item, @"[\d-]", string.Empty);
                            itemName = itemName.Remove(0, 5);
                            
                            int dateSeparator = item.IndexOf("-");
                            if (dateSeparator < 2)
                            {
                                return;
                            }
                            itemName = itemName.Remove(itemName.Length - 1, 2);
                            string itemDate = item.Substring(dateSeparator - 2, 4);
                            itemDate = itemDate.Replace(" ", String.Empty);
                            DateTime deadline = DateTime.ParseExact(itemDate, "dd-M", CultureInfo.InvariantCulture);

                            if (importance == "I")
                            {
                                AddItem(itemName, deadline, true);
                            }
                            else
                            {
                                AddItem(itemName, deadline, false);
                            }
                        }

                    }

                }
            }
        }

        public void SaveItemsToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write)))
            {
                string text = "";
                foreach (KeyValuePair<string, TodoQuarter> entry in todoQuarters)
                {
                    text += "#";
                    text += entry.Key;
                    text += ",";
                    text += entry.Value.ToString();
                    text += ";";
                }
                    writer.WriteLine(text);
            }
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
                writtenMatrix += ";\n";
            }
            return writtenMatrix;
        }


    }
}