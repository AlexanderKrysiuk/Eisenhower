using System;
using System.Data;
using Spectre.Console;

namespace EisenhowerMain
{
    public class EisenhowerMain
    {
        static TodoMatrix Matrix = new TodoMatrix();
        static public void Main(String[] args)
        {
            ShowMenu();
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
            Console.WriteLine("Welcome to Eisenhower Matrix App. What would You like to do?\n" +
                              "Exit - exit application\n" +
                              "Show - show TODO items by status\n" +
                              "Add - add an item\n" +
                              "Mark - mark item done/undone\n" +
                              "Remove - remove item\n" +
                              "Archive - archive items (remove all done)\n" +
                              "Matrix - Show Whole Matrix\n" +
                              "Menu - show menu");
            ChooseMenuOption();
        }

        static void ChooseMenuOption()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "Exit":
                    Exit();
                    break;
                case "Show":
                    ShownToDoItemsByStatus();
                    ChooseMenuOption();
                    break;
                case "Add":
                    AddItem();
                    ChooseMenuOption();
                    break;
                case "Mark":
                    MarkItem();
                    ChooseMenuOption();
                    break;
                case "Remove": 
                    RemoveItem();
                    ChooseMenuOption();
                    break;
                case "Archive":
                    ArchiveItems();
                    ChooseMenuOption();
                    break;
                case "Matrix":
                    ShowMatrix();
                    ChooseMenuOption();
                    break;
                case "Menu":
                    ShowMenu();
                    ChooseMenuOption();
                    break;
                default:
                    Console.Clear();
                    //ShowMenu();
                    Console.WriteLine("Please provide right number");
                    ChooseMenuOption();
                    break;
            }
        }

        static void Exit()
        {
            ArchiveItems();
            Matrix.SaveItemsToFile("Database");
            Console.WriteLine("The data has been successfully saved to the CSV file");
        }

        static void QuarterOptions()
        {
            Console.WriteLine("Please provide symbol of status You would like to use:\n" +
                              "IU - urgent & important items\n" +
                              "IN - not urgent & important items\n" +
                              "NU - urgent & not important items\n" +
                              "NN - not urgent & not important items");   
        }

        static void ShownToDoItemsByStatus()
        {
            QuarterOptions();
            string option = Console.ReadLine();
            TodoQuarter quarter = Matrix.GetQuarter(option);
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

        static void AddItem()
        {
            Console.WriteLine("Please provide title of the task:");
            string title = Console.ReadLine();
            Console.WriteLine("Please provide deadline data in format yyyy-mm-dd");
            string datestring = Console.ReadLine();
            DateTime data = DateTime.Parse(datestring);
            Console.WriteLine("Is this item important? parse true or false");
            bool isImportant = Convert.ToBoolean(Console.ReadLine());
            
            Matrix.AddItem(title,data,isImportant);
        }

        static void MarkItem()
        {
            Console.WriteLine("Please provide title of the task to mark:");
            string title = Console.ReadLine();
            foreach (var quarter in Matrix.GetQuarters())
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

        static void RemoveItem()
        {
            QuarterOptions();
            string option = Console.ReadLine();
            TodoQuarter quarter = Matrix.GetQuarter(option);            
            Console.WriteLine("Please provide index of the task to remove:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            quarter.GetItems().RemoveAt(index);
        }

        static void ArchiveItems()
        {
            foreach (var quarter in Matrix.GetQuarters())
            {
                quarter.Value.GetItems().RemoveAll(item => item._isDone);
            }
        }

        static void ShowMatrix()
        {
            int ItemLength = 10;
            foreach (var quarter in Matrix.GetQuarters())
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
            
            string important = "Important";
            string notimportant = "Not Important";
            
            //string IU = Matrix.GetQuarter("IU").TurnListIntoString();
            //string IN = Matrix.GetQuarter("IN").TurnListIntoString();
            //string NU = Matrix.GetQuarter("NU").TurnListIntoString();
            //string NN = Matrix.GetQuarter("NN").TurnListIntoString();

            var table = new Table();
            
            table.Border = TableBorder.Ascii2;
            
            table.AddColumn("");
            table.AddColumn("Urgent");
            table.AddColumn("Not Urgent");
            
            for (int index = 0; index < important.Length; index++)
            {
                string taskIU;
                TodoQuarter quarterIU = Matrix.GetQuarter("IU");
                if (index >= 0 && index < quarterIU.GetItems().Count)
                {
                    TodoItem IUitem = quarterIU.GetItem(index);
                    taskIU = IUitem.ToString();
                }
                else
                {
                    taskIU = "";
                }
                
                
                
                string character = important[index].ToString();
                table.AddRow(character, " 05-10 Spanie","Jakiś inny string");
            }
            table.AddEmptyRow();

            for (int index = 0; index < notimportant.Length; index++)
            {
                string character = notimportant[index].ToString();
                table.AddRow(character, "kolejny string", "następny string");
            }

            AnsiConsole.Write(table);
        }
    }
}
