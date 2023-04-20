using System;

namespace EisenhowerMain
{
    public class TodoItem
    {
        private readonly DateTime _deadline;

        public bool IsDone;

        // Attributes
        private readonly string _title;

        //Constructor
        public TodoItem(string title, DateTime deadline, bool isDone)
        {
            _title = title;
            _deadline = deadline;
            IsDone = isDone;
        }


        //Instance Methods
        public string GetTitle()
        {
            return _title;
        }


        public DateTime GetDeadLine()
        {
            return _deadline;
        }


        public void Mark()
        {
            IsDone = true;
        }


        public void Unmark()
        {
            IsDone = false;
        }


        public override string ToString()
        {
            var doneStatus = IsDone ? "[x]" : "[ ]";
            var formatedDeadline = _deadline.ToString("d-M");
            return $"{doneStatus} {formatedDeadline} {_title}";
        }
    }
}