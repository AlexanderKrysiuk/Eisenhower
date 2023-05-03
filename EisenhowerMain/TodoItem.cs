using System;

namespace EisenhowerMain
{
    public class TodoItem
    {
        // Attributes
        private readonly string _title;
        private readonly DateTime _deadline;
        public bool _isDone;

        //Constructor
        public TodoItem(string title, DateTime deadline)
        {
            _title = title;
            _deadline = deadline;
            _isDone = false;
        }

        //Instance Methods
        public string Get_title()
        {
            return _title;
        }

        public DateTime Get_deadline()
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

        public bool Get_Status()
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