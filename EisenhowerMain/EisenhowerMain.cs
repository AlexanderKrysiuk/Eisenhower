﻿using System;

namespace EisenhowerMain
{
    public class EisenhowerMain
    {
        static TodoMatrix Matrix = new TodoMatrix();
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
                    //ShowMenu();
                    Console.WriteLine("Please provide right number");
                    ChooseMenuOption();
                    break;
            }
        }

        static void Exit()
        {
            //Not Implemented
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
                Console.WriteLine(index + ". " + item);
                index++;
            }
            ChooseMenuOption();
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
            
            //ShowMenu();
            ChooseMenuOption();
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
            //ShowMenu();
            ChooseMenuOption();
        }

        static void RemoveItem()
        {
            QuarterOptions();
            string option = Console.ReadLine();
            TodoQuarter quarter = Matrix.GetQuarter(option);            
            Console.WriteLine("Please provide index of the task to remove:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            quarter.GetItems().RemoveAt(index);
            ChooseMenuOption();
        }

        static void ArchiveItems()
        {
            foreach (var quarter in Matrix.GetQuarters())
            {
                quarter.Value.GetItems().RemoveAll(item => item._isDone == true);
            }
            ChooseMenuOption();
        }
    }
}
