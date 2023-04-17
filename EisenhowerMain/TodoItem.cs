using System;

namespace EisenhowerMain {
public class TodoItem
    {
        // Attributes
        private string _title;
        private DateTime _deadline;
        private bool _isDone;
        
        //Constructor
        public TodoItem(string title, DateTime deadline, bool isDone)
        {
            _title = title;
            _deadline = deadline;
            _isDone = isDone;
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

        public override string ToString()
        {
            string doneStatus = _isDone ? "[x]" : "[ ]";
            string formatedDeadline = _deadline.ToString("d-M");
            return $"{doneStatus} {formatedDeadline} {_title}";
        }
    }
}