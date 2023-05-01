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

            // section for saving file //

           // matrix.AddItem("(testing important, urgent)", deadlineUrgent, true);
            //matrix.AddItem("(testing important, not urgent)", deadlineNotUrgent, true);
            //matrix.AddItem("(important, not urgent 2)", deadlineNotUrgent, true);
            //matrix.AddItem("(testing not important, urgent)", deadlineUrgent);
            //matrix.AddItem("(testing not important, not urgent)", deadlineNotUrgent);
            //matrix.SaveItemsToFile("h.csv");

            // endsection //

            matrix.AddItemsFromFile("h.csv");
            Display display = new Display();
            Input input = new Input();
            display.PrintMatrix(matrix);
            string getInput = input.GetInput();
        }
    }
}
