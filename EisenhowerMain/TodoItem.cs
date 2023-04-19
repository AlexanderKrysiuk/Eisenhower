using System;

namespace EisenhowerMain {
public class TodoItem
    {
        // Attributes
        private readonly string _title;
        private readonly DateTime _deadline;
        public bool isDone;
        
        //Constructor
        public TodoItem(string title, DateTime deadline)
        {
            _title = title;
            _deadline = deadline;
            isDone = false;
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
            isDone = true;
        }

        public void Unmark()
        {
            isDone = false;
        }

        public override string ToString()
        {
            string doneStatus = isDone ? "[x]" : "[ ]";
            string formattedDeadline = _deadline.ToString("d-M");
            return $"{doneStatus} {formattedDeadline} {_title}";
        }
    }
}