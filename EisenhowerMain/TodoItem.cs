using System;

namespace EisenhowerMain
{
    public class TodoItem
    {
        // Attributes
        private string _title;
        private DateTime _deadline;
        private bool _isDone;

        //Constructor
        public TodoItem(string title, DateTime deadline)
        {
            _title = title;
            _deadline = deadline;
            _isDone = false;
        }

        //Instance Methods
        public string GetTitle()
        {
            return _title;
        }

        public DateTime GetDeadline()
        {
            return _deadline;
        }

        public void Mark()
        {
            _isDone = true;
        }

        public void Unmark()
        {
            _isDone = false;
        }

        public bool GetStatus()
        {
            return _isDone;
        }

        public override string ToString()
        {
            string doneStatus = _isDone ? "{x}" : "{ }";
            string formattedDeadline = _deadline.ToString("d-M");
            return $"{doneStatus} {formattedDeadline} {_title}";
        }
    }
}