using System;

namespace EisenhowerMain {
public class TodoItem
    {
        // Attributes
        private string Title;
        private DateTime Deadline;
        private bool IsDone;
        
        //Constructor
        public TodoItem(string Title, DateTime Deadline, bool IsDone)
        {
            this.Title = Title;
            this.Deadline = Deadline;
            this.IsDone = IsDone;
        }

        //Instance Methods
        public string GetTitle()
        {
            return Title;
        }

        public DateTime GetDeadLine()
        {
            return Deadline;
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
            string doneStatus = IsDone ? "[x]" : "[ ]";
            string formatedDeadline = Deadline.ToString("d-M");
            return $"{doneStatus} {formatedDeadline} {Title}";
        }
    }
}