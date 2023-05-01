using System;
using System.Data;
using Spectre.Console;

namespace EisenhowerMain
{
    public class EisenhowerMain
    {
        static public void Main(String[] args)
        {
            TodoMatrix matrix = new TodoMatrix();
            Display display = new Display();
            Input getInput = new Input();
            display.Print("Welcome to Eisenhower Matrix!");
            ShowMenu(matrix, display, getInput);
        }

        static void ShowMenu(TodoMatrix matrix, Display display, Input getInput)
        {
            display.Print("\nWhat would you like to do? (Press q to quit any time)\n" +
                              "Exit - exit application\n" +
                              "Show - show TODO items by status\n" +
                              "Add - add an item\n" +
                              "Mark - mark item done/undone\n" +
                              "Remove - remove item\n" +
                              "Archive - archive items (remove all done)\n" +
                              "Matrix - Show whole matrix\n" +
                              "Save - save sample list to list.csv\n" +
                              "Load - load sample list from list.csv\n" +
                              "Menu - show menu");
            ChooseMenuOption(matrix, display, getInput);
        }

        static void ChooseMenuOption(TodoMatrix matrix, Display display, Input getInput)
        {
            string userInput = getInput.GetInput();
            switch (userInput)
            {
                case "Exit":
                    Exit();
                    break;
                case "Show":
                    ShownToDoItemsByStatus(matrix, display, getInput);
                    ShowMenu(matrix, display, getInput);
                    break;
                case "Add":
                    AddItem(matrix, display, getInput);
                    ShowMenu(matrix, display, getInput);
                    break;
                case "Mark":
                    MarkItem(matrix, display, getInput);
                    ShowMenu(matrix, display, getInput);
                    break;
                case "Remove": 
                    RemoveItem(matrix, display, getInput);
                    ShowMenu(matrix, display, getInput);
                    break;
                case "Archive":
                    ArchiveItems(matrix, display, getInput);
                    ShowMenu(matrix, display, getInput);
                    break;
                case "Matrix":
                    ShowMatrix2(matrix, display, getInput);
                    ShowMenu(matrix, display, getInput);
                    break;
                case "Save":
                    SaveMatrix(matrix, display, getInput);
                    ShowMenu(matrix, display, getInput);
                    break;
                case "Load":
                    LoadMatrix(matrix, display, getInput);
                    ShowMenu(matrix, display, getInput);
                    break;
                case "Menu":
                    ShowMenu(matrix, display, getInput);
                    break;
                default:
                    //Console.Clear();
                    //ShowMenu();
                    display.Print("Please provide the right command");
                    ChooseMenuOption(matrix, display, getInput);
                    break;
            }
        }

        static void Exit()
        {
            //Not Implemented
        }

        static void QuarterOptions(Display display)
        {
            display.Print("Please provide symbol of status you would like to use:\n" +
                              "IU - urgent & important items\n" +
                              "IN - not urgent & important items\n" +
                              "NU - urgent & not important items\n" +
                              "NN - not urgent & not important items");   
        }

        static void ShownToDoItemsByStatus(TodoMatrix matrix, Display display, Input getInput)
        {
            QuarterOptions(display);
            string option = getInput.GetInput();
            TodoQuarter quarter = matrix.GetQuarter(option);
            int index = 1;
            foreach (var item in quarter.GetItems() )
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan difference = currentTime.Subtract(item.Get_deadline());
                if (item.Get_Status() == false)
                {
                    if (difference.Days > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (difference.Days <= 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (difference.Days == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                Console.WriteLine(index + ". " + item);
                index++;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void AddItem(TodoMatrix matrix, Display display, Input getInput)
        {
            display.Print("Please provide title of the task:");
            string title = getInput.GetInput();
            display.Print("Please provide deadline data in format yyyy-mm-dd");
            string datestring = getInput.GetInput();
            DateTime data = DateTime.Parse(datestring);
            display.Print("Is this item important? parse true or false");
            bool isImportant = Convert.ToBoolean(getInput.GetInput());
            
            matrix.AddItem(title,data,isImportant);
        }

        static void MarkItem(TodoMatrix matrix, Display display, Input getInput)
        {
            display.Print("Please provide title of the task to mark:");
            string title = getInput.GetInput();
            foreach (var quarter in matrix.GetQuarters())
            {
                foreach (var item in quarter.Value.GetItems())
                {
                    if (title == item.Get_title())
                    {
                        item.Mark();
                        break;
                    }
                }
            }
        }

        static void RemoveItem(TodoMatrix matrix, Display display, Input getInput)
        {
            QuarterOptions(display);
            string option = getInput.GetInput();
            TodoQuarter quarter = matrix.GetQuarter(option);            
            display.Print("Please provide index of the task to remove:");
            int index = Convert.ToInt32(getInput.GetInput()) - 1;
            quarter.GetItems().RemoveAt(index);
        }

        static void ArchiveItems(TodoMatrix matrix, Display display, Input getInput)
        {
            foreach (var quarter in matrix.GetQuarters())
            {
                quarter.Value.GetItems().RemoveAll(item => item._isDone);
            }
        }

        static void ShowMatrix(TodoMatrix matrix, Display display, Input getInput)
        {
            int ItemLength = 10;
            foreach (var quarter in matrix.GetQuarters())
            {
                int index = 0;
                foreach (var item in quarter.Value.GetItems())
                {
                    string Length = index + ". " + item;
                    if (Length.Length > ItemLength)
                    {
                        ItemLength = Length.Length;
                    }
                }
            }
            
            string important = "I\nm\np\no\nr\nt\na\nn\nt";
            string notimportant = "N\no\nt\n \nI\nm\np\no\nr\nt\na\nn\nt";
            
            string IU = matrix.GetQuarter("IU").TurnListIntoString();
            string IN = matrix.GetQuarter("IN").TurnListIntoString();
            string NU = matrix.GetQuarter("NU").TurnListIntoString();
            string NN = matrix.GetQuarter("NN").TurnListIntoString();

            var table = new Table();
            
            table.Border = TableBorder.Ascii2;
            
            table.AddColumn("");
            table.AddColumn("Urgent");
            table.AddColumn("Not Urgent");
            

            table.AddRow(important, IU, IN);
            table.AddRow("-", new string('-',ItemLength),new string('-',ItemLength));
            table.AddRow(notimportant, NU, NN);

            AnsiConsole.Write(table);
        }

        static void ShowMatrix2(TodoMatrix matrix, Display display, Input getInput)
        {
            display.PrintMatrix(matrix);
        }

        static void SaveMatrix(TodoMatrix matrix, Display display, Input getInput)
        {
            DateTime currentTime = DateTime.Now;
            DateTime deadlineNotUrgent = currentTime.AddDays(25);
            DateTime deadlineUrgent = currentTime.AddDays(1);
            matrix.AddItem("(testing important, urgent)", deadlineUrgent, true);
            matrix.AddItem("(testing important, not urgent)", deadlineNotUrgent, true);
            matrix.AddItem("(important, not urgent 2)", deadlineNotUrgent, true);
            matrix.AddItem("(testing not important, urgent)", deadlineUrgent);
            matrix.AddItem("(testing not important, not urgent)", deadlineNotUrgent);
            matrix.SaveItemsToFile("list.csv");
            display.Print("List generated and saved to list.csv, type \"Matrix\" to display");
        }

        static void LoadMatrix(TodoMatrix matrix, Display display, Input getInput)
        {
            matrix.AddItemsFromFile("list.csv");
            display.Print("List loaded from list.csv, type \"Matrix\" to display");
        }

    }
}
