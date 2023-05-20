using System;
using EisenhowerMain.Model;
using EisenhowerMain.Manager;
using Spectre.Console;

namespace EisenhowerMain
{
    public class EisenhowerMain
    {
        static TodoMatrix matrix = new TodoMatrix();
        static Display display = new Display();
        static Input getInput = new Input();
        static MatrixDbManager manager = new MatrixDbManager();
        static IItemsDao itemsDao = new MssqlItemsDao(manager.ConnectionString);
        static bool IsConnectedToDb = false;


        static public void Main(String[] args)
        { 
            display.Print("Welcome to Eisenhower Matrix!");
            ShowMenu();
        }

        static void ShowMenu()
        {
            display.Print("\nWhat would you like to do? (Press q to quit any time)\n" +
                              "Exit - exit application\n" +
                              "Connect - connect to database\n" +
                              "Show - show TODO items by status\n" +
                              "Add - add an item\n" +
                              "Mark - mark item done/undone\n" +
                              "Remove - remove item\n" +
                              "Archive - archive items (remove all done)\n" +
                              "Matrix - Show whole matrix\n" +
                              "Save - save sample list to list.csv\n" +
                              "Load - load sample list from list.csv\n" +
                              "Menu - show menu");
            ChooseMenuOption();
        }

        static void ChooseMenuOption()
        {
            string userInput = getInput.GetInput();
            switch (userInput)
            {
                case "Exit":
                    Exit();
                    break;
                case "Connect":
                    ConnectToDb();
                    break;
                case "Show":
                    ShownToDoItemsByStatus();
                    break;
                case "Add":
                    AddItem();
                    ShowMatrix();
                    break;
                case "Mark":
                    MarkItem();
                    ShowMatrix();
                    break;
                case "Remove": 
                    RemoveItem();
                    ShowMatrix();
                    break;
                case "Archive":
                    ArchiveItems();
                    ShowMatrix();
                    break;
                case "Matrix":
                    ShowMatrix();
                    break;
                case "Save":
                    SaveMatrix();
                    break;
                case "Load":
                    LoadMatrix();
                    ShowMatrix();
                    break;
                case "Menu":
                    ShowMenu();
                    break;
                default:
                    //Console.Clear();
                    //ShowMenu();
                    display.Print("Please provide the right command");
                    ChooseMenuOption();
                    break;
            }
            ShowMenu();
        }

        static void Exit()
        {
            ArchiveItems();
            SaveMatrix();
            display.Print("Bye!");
            Environment.Exit(0);
        }

        static void ConnectToDb()
        {
            manager.Connect();
            IsConnectedToDb = true;
            display.Print("Connected to database");
        }

        static void QuarterOptions(Display display)
        {
            display.Print("Please provide symbol of status you would like to use:\n" +
                              "IU - urgent & important items\n" +
                              "IN - not urgent & important items\n" +
                              "NU - urgent & not important items\n" +
                              "NN - not urgent & not important items");   
        }

        static void ShownToDoItemsByStatus()
        {
            QuarterOptions(display);
            string option = getInput.GetInput();
            TodoQuarter quarter = matrix.GetQuarter(option);
            int index = 1;
            foreach (var item in quarter.GetItems() )
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan difference = currentTime.Subtract(item.GetDeadline());
                if (item.GetStatus() == false)
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

        static void AddItem()
        {
            display.Print("Please provide title of the task.\nMake sure not to use the characters '{' and '}'");
            string title = getInput.GetInput();
            display.Print("Please provide deadline data in format yyyy-mm-dd");
            string datestring = getInput.GetInput();
            DateTime data = DateTime.Parse(datestring);
            display.Print("Is this item important? (y/n)");
            bool isImportant = GetYesOrNo();
            //bool isImportant = Convert.ToBoolean(getInput.GetInput());
            
            matrix.AddItem(title,data,isImportant);
            display.Print("Added item.");
        }

        static bool GetYesOrNo()
        {
            string input = getInput.GetInput();
            while (true)
            {
                if (input.ToUpper() == "Y")
                {
                    return true;
                }
                else if (input.ToUpper() == "N")
                {
                    return false;
                }
                else
                {
                    display.Print("Please enter y or n");
                    input = getInput.GetInput();
                }
            }
        }

        static void MarkItem()
        {
            display.Print("Please provide title of the task to mark.");
            string title = getInput.GetInput();
            foreach (var quarter in matrix.GetQuarters())
            {
                foreach (var item in quarter.Value.GetItems())
                {
                    if (title == item.GetTitle())
                    {
                        item.Mark();
                        display.Print("Marked item.");
                        break;
                    }
                }
            }
        }

        static void RemoveItem()
        {
            QuarterOptions(display);
            string option = getInput.GetInput();
            TodoQuarter quarter = matrix.GetQuarter(option);            
            display.Print("Please provide the number of the task to remove (starting from 1):");
            int index = Convert.ToInt32(getInput.GetInput()) - 1;
            display.Print($"Are you sure you want to remove {quarter.GetItem(index).GetTitle()} (y/n)?");
            bool confirmation = GetYesOrNo();
            if (confirmation) {
                quarter.GetItems().RemoveAt(index);
                display.Print("Removed item.");
            }
        }

        static void ArchiveItems()
        {
            foreach (var quarter in matrix.GetQuarters())
            {
                quarter.Value.GetItems().RemoveAll(item => item.GetStatus());
            }
        }

        static void ShowMatrix()
        {
            int itemLength = 10;
            foreach (var quarter in matrix.GetQuarters())
            {
                int index = 0;
                foreach (var item in quarter.Value.GetItems())
                {
                    string length = index + ". " + item;
                    if (length.Length > itemLength)
                    {
                        itemLength = length.Length;
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
            table.AddRow("-", new string('-',itemLength),new string('-',itemLength));
            table.AddRow(notimportant, NU, NN);

            AnsiConsole.Write(table);
        }

        static void SaveMatrix()
        {
            if (IsConnectedToDb)
            {
                SaveMatrixDao();
                display.Print("Saved to database");
            }
            else
            {
                matrix.SaveItemsToFile("list.csv");
                display.Print("Saved to list.csv");
            }
            
        }

        static void SaveMatrixDao()
        {
            display.Print("Overwrite current database entries? (y/n)");
            bool overwrite = GetYesOrNo();
            matrix.SaveItemsToDatabase(itemsDao, overwrite);
        }

        static void LoadMatrix()
        {
            if (IsConnectedToDb)
            {
                LoadMatrixDao();
                display.Print("List loaded from database");
            }
            else
            {
                matrix.AddItemsFromFile("list.csv");
                display.Print("List loaded from list.csv");
            }
        }

        static void LoadMatrixDao()
        {
            display.Print("Overwrite current matrix? (y/n)");
            bool overwrite = GetYesOrNo();
            itemsDao.Load(matrix, overwrite);
        }

    }
}
