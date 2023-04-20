using System;
using EisenhowerMain;

namespace EisenhowerCore
{
    public class EisenhowerMain
    {  
        static public void Main(String[] args) 
        { 
            TodoMatrix matrix = new TodoMatrix();
            DateTime currentTime = DateTime.Now;
            DateTime deadlineNotUrgent = currentTime.AddDays(-10);
            DateTime deadlineUrgent = currentTime.AddDays(-1);
            matrix.AddItem("(testing important, urgent)", deadlineUrgent, true);
            matrix.AddItem("(testing important, not urgent)", deadlineNotUrgent, true);
            matrix.AddItem("(testing important, not urgent 2)", deadlineNotUrgent, true);
            matrix.AddItem("(testing not important, urgent)", deadlineUrgent);
            matrix.AddItem("(testing not important, not urgent)", deadlineNotUrgent);
            Console.Write(matrix.ToString());
            Console.ReadLine();
        }
    }
}
