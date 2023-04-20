using System;

namespace EisenhowerMain
{
    internal class Display
    {
        public readonly string ChooseTodo = "choose todo item by index: ";

        public readonly string NotUrgentImportant = @"
-------------------------------
not urgent & important items
";

        public readonly string NotUrgentNotImportant = @"
-------------------------------
not urgent & not important items
";


        public readonly string QuarterMenu = @"
-------------------------------
Options:
1. Add todo
2. Delete todo
3. Mark todo
4. Unmark todo
5. back
";


        public readonly string StartMenu = @"
-------------------------------
1. urgent & important items
2. not urgent & important items
3. urgent & not important items
4. not urgent & not important items
5. Add todo
6. Archive marked todos
7. Load files from .csv
8. Save files to .csv
9. Quit
";


        public readonly string UrgentImportant = @"
-------------------------------
urgent & important items
";

        public readonly string UrgentNotImportant = @"
-------------------------------
urgent & not important items
";


        public readonly string WrongInput = @"
-------------------------------
wrong input, try again
------------------------------";


        public void DisplayChooseTodo()
        {
            Console.WriteLine(ChooseTodo);
        }


        public void DisplayQuarterInformation1()
        {
            Console.WriteLine(UrgentImportant);
        }

        public void DisplayQuarterInformation2()
        {
            Console.WriteLine(NotUrgentImportant);
        }

        public void DisplayQuarterInformation3()
        {
            Console.WriteLine(UrgentNotImportant);
        }

        public void DisplayQuarterInformation4()
        {
            Console.WriteLine(NotUrgentNotImportant);
        }


        public void ClearScreen()
        {
            Console.Clear();
        }

        public void DisplayTodos(TodoMatrix todoMatrix)
        {
            Console.WriteLine(todoMatrix.ToString());
        }


        public void DisplayStartMenu()
        {
            Console.WriteLine(StartMenu);
        }


        public void DisplayQuarterMenu()
        {
            Console.WriteLine(QuarterMenu);
        }


        public void DisplayWrongInputMessage()
        {
            Console.WriteLine(WrongInput);
        }
    }
}