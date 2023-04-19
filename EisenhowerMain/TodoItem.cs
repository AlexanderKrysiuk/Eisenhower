using System;

namespace EisenhowerMain
{
    public class TodoItem
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }


        public TodoItem(string title, DateTime deadline)
        {
            this.Title = title;
            this.Deadline = deadline;
            this.IsDone = false;
        }


        string GetTitle()
        {
            return this.Title;
        }


        DateTime GetDeadline()
        {
            return this.Deadline;
        }


        public bool Mark()
        {
            return this.IsDone = true;
        }


        public bool Unmark()
        {
            return this.IsDone = false;
        }


        // to override
        public override string ToString()
        {
            String tdTitle = GetTitle();
            DateTime tdDeadline = GetDeadline();
            if (IsDone == false)
            {
                return string.Format("[ ] {0} {1}", tdDeadline.ToString("dd/MM"), tdTitle);
            }
            else
                return string.Format("[X] {0} {1}", tdDeadline.ToString("dd/MM"), tdTitle);
        }
    }
}