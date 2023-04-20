using System;
using System.Collections.Generic;

namespace EisenhowerMain
{
    public class TodoMatrix
    {
        private readonly Dictionary<string, TodoQuarter> _todoQuarters = new Dictionary<string, TodoQuarter>();


        public TodoMatrix()
        {
            _todoQuarters.Add("IU", new TodoQuarter());
            _todoQuarters.Add("IN", new TodoQuarter());
            _todoQuarters.Add("NU", new TodoQuarter());
            _todoQuarters.Add("NN", new TodoQuarter());
        }


        public Dictionary<string, TodoQuarter> GetQuarters()
        {
            return _todoQuarters;
        }


        public TodoQuarter GetQuarter(string status)
        {
            foreach (var entry in _todoQuarters)
                if (entry.Key == status)
                    return entry.Value;
            var other = new TodoQuarter();
            return other;
        }


        public void AddItem(string title, DateTime deadline, bool isImportant)
        {
            var status = GetStatus(deadline, isImportant);
            _todoQuarters[status].AddItem(title, deadline);
        }


        public void AddItem(string title, DateTime deadline)
        {
            var status = GetStatus(deadline, false);
            _todoQuarters[status].AddItem(title, deadline);
        }


        public void AddItemsFromFile(string filename)
        {
        }


        public void SaveItemsToFile(string filename)
        {
        }


        public void ArchiveItems()
        {
            foreach (var entry in _todoQuarters)
            foreach (var item in entry.Value.GetItems())
                if (item.IsDone)
                    entry.Value.GetItems().Remove(item);
        }


        public string GetStatus(DateTime deadline, bool isImportant)
        {
            var currentTime = DateTime.Now;
            var difference = currentTime.Subtract(deadline);
            if (difference.Days > 3)
            {
                if (isImportant)
                    return "IN";
                return "NN";
            }

            if (isImportant)
                return "IU";
            return "NU";
        }


        public override string ToString()
        {
            var writtenMatrix = "";
            foreach (var entry in _todoQuarters)
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

        public void SaveItems()
        {
            throw new NotImplementedException();
        }

        public void AddItem()
        {
            throw new NotImplementedException();
        }
    }
}