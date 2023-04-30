using System;
using System.ComponentModel.DataAnnotations;
using EisenhowerMain;

namespace EisenhowerCore
{
    public class EisenhowerMain
    {  
        static public void Main(String[] args) 
        { 
            TodoMatrix matrix = new TodoMatrix();
            DateTime currentTime = DateTime.Now;
            DateTime deadlineNotUrgent = currentTime.AddDays(25);
            DateTime deadlineUrgent = currentTime.AddDays(1);
            matrix.AddItem("(testing important, urgent)", deadlineUrgent, true);
            matrix.AddItem("(testing important, not urgent)", deadlineNotUrgent, true);
            matrix.AddItem("(important, not urgent 2)", deadlineNotUrgent, true);
            matrix.AddItem("(testing not important, urgent)", deadlineUrgent);
            matrix.AddItem("(testing not important, not urgent)", deadlineNotUrgent);
            Console.Write(matrix.ToString());


            
            matrix.SaveItemsToFile("h.csv");
            matrix.AddItemsFromFile("h.csv");
            Display display = new Display();
            display.PrintMatrix(matrix);
            Console.ReadLine();
        }
    }
}
