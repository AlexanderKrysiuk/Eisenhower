using System;

namespace EisenhowerMain
{
    public class EisenhowerMain
    {
        static TodoQuarter Quarter = new TodoQuarter();
        static public void Main(String[] args)
        {
            ShowMenu();
            ChooseMenuOption();
            /*
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
            */
        }

        static void ShowMenu()
        {
            Console.WriteLine("Welcome to Eisenhower Matrix App. What would You like to do?");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - shown TODO items by status\n" +
                              "  - urgent & important items\n" +
                              "  - not urgent & important items\n" +
                              "  - urgent & not important items\n" +
                              "  - not urgent & not important items");
            Console.WriteLine("2 - add an item");
            Console.WriteLine("3 - mark item done/undone");
            Console.WriteLine("4 - remove item");
            Console.WriteLine("5 - archive items (remove all done)");
        }

        static void ChooseMenuOption()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Exit();
                    break;
                case "1":
                    ShownToDoItemsByStatus();
                    break;
                case "2": 
                    AddItem();
                    break;
                case "3":
                    MarkItem();
                    break;
                case "4": 
                    RemoveItem();
                    break;
                case "5":
                    ArchiveItems();
                    break;
                default:
                    Console.Clear();
                    ShowMenu();
                    Console.WriteLine("Please provide right number");
                    ChooseMenuOption();
                    break;
            }
        }

        static void Exit()
        {
            //Not Implemented
        }

        static void ShownToDoItemsByStatus()
        {
            //Not Implemented
        }

        static void AddItem()
        {
            Console.WriteLine("Please provide title of the task:");
            string title = Console.ReadLine();
            Console.WriteLine("Please provide deadline data in format yyyy-mm-dd");
            string datestring = Console.ReadLine();
            DateTime data = DateTime.Parse(datestring);
            Quarter.AddItem(title,data);
        }

        static void MarkItem()
        {
            //Not Implemented
        }

        static void RemoveItem()
        {
            // Not Implemented
        }

        static void ArchiveItems()
        {
            // Not Implemented
        }
    }
}
