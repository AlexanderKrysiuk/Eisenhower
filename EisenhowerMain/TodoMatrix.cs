using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using EisenhowerMain.Model;

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
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string text = reader.ReadLine();
                    string[] quarters;
                    quarters = text.Split(';');
                    foreach (string quarter in quarters)
                    {
                        if (quarter.Length < 1)
                        {
                            return;
                        }
                        string importance = quarter[1].ToString();
                        string entries = quarter.Remove(0, 4);
                        string[] items = entries.Split("} ");
                        foreach (string item in items)
                        {
                            if (item.Length > 5)
                            {

                                string itemName = GetItemName(item);

                                DateTime deadline = GetItemDeadline(item);

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
        }

        private DateTime GetItemDeadline(string item)
        {
            int dateSeparator = item.IndexOf("-");
            string itemDate;
            if (dateSeparator < 2)
            {
                itemDate = item.Substring(dateSeparator - 1, 4);
            }
            else
            {
                itemDate = item.Substring(dateSeparator - 2, 4);
            }
            itemDate = itemDate.Replace(" ", String.Empty);
            string day = itemDate.Split("-")[0];
            string month = itemDate.Split("-")[1];
            DateTime deadline = new DateTime();
            if (day.Length == 1)
            {
                if (month.Length == 1)
                {
                    deadline = DateTime.ParseExact(itemDate, "d-M", CultureInfo.InvariantCulture);
                }
                else
                {
                    deadline = DateTime.ParseExact(itemDate, "d-MM", CultureInfo.InvariantCulture);
                }
            }
            else
            {
                if (month.Length == 1)
                {
                    deadline = DateTime.ParseExact(itemDate, "dd-M", CultureInfo.InvariantCulture);
                }
                else
                {
                    deadline = DateTime.ParseExact(itemDate, "dd-MM", CultureInfo.InvariantCulture);
                }
            }
            return deadline;
        }

        private string GetItemName(string item)
        {
            int offset = item.Split(" ")[0].Length;
            string itemName = item.Substring(offset, item.Length - offset);

            if (itemName[itemName.Length - 2] == '{')
            {
                itemName = itemName.Substring(0, itemName.Length - 2);
            }
            itemName = itemName.Substring(1, itemName.Length - 1);
            return itemName;
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

        public void SaveItemsToDatabase(IItemsDao itemsDao, bool overwrite)
        {
            foreach (KeyValuePair<string, TodoQuarter> entry in todoQuarters)
            {
                bool importance = false;
                if (entry.Key[0] == 'I')
                {
                    importance = true;
                }
                foreach (TodoItem item in entry.Value.GetItems())
                {
                    itemsDao.Save(item.Get_title(), item.Get_deadline(), importance, overwrite);
                }
            }
        }

        public void ArchiveItems()
        {
            foreach (KeyValuePair<string, TodoQuarter> entry in todoQuarters)
            {
                foreach (TodoItem item in entry.Value.GetItems())
                {
                    if (item.Get_Status())
                    {
                        entry.Value.GetItems().Remove(item);
                    }
                }
            }
        }

        public string GetStatus(DateTime deadline, bool isImportant)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan difference = deadline.Subtract(currentTime);
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