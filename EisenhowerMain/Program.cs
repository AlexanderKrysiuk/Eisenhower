using System;
using System.Collections.Generic;
using System.Text;


namespace EisenhowerMain
{
    class Program
    {
        public readonly TodoMatrix TodoMatrix = new TodoMatrix();
        public readonly Display Display = new Display();

        public Input Input = new Input();
        //public TodoQuarter todoQuarter = new TodoQuarter();


        public void Main()
        {
            while (true)
            {
                Display.ClearScreen();
                Display.DisplayTodos(TodoMatrix);
                Display.DisplayStartMenu();
                string userInput = Input.UserInputStartMenu();
                if (userInput == "9")
                {
                    Environment.Exit(1);
                }
                else
                {
                    if (userInput == "8")
                    {
                        TodoMatrix.SaveItems();
                    }

                    if (userInput == "7")
                    {
                        TodoMatrix.LoadItems();
                    }

                    if (userInput == "6")
                    {
                        TodoMatrix.ArchiveItems();
                    }

                    if (userInput == "5")
                    {
                        Console.WriteLine("title of your todo: ");
                        string title = Input.NewTodoTitle();
                        Console.WriteLine("deadline (DD/MM/YYYY): ");
                        DateTime deadline = Input.NewTodoDeadline();
                        Console.WriteLine("is it important? (y/n): ");
                        string yesOrNo = Input.UserInputYesOrNo();
                        if (yesOrNo == "y")
                        {
                            TodoMatrix.AddItem(title, deadline, true);
                        }
                        else
                        {
                            TodoMatrix.AddItem(title, deadline, false);
                        }
                    }
                    else
                    {
                        if (userInput == "4")
                        {
                            Display.DisplayQuarterInformation4();
                            TodoQuarter quarterNotImportantNotUrgent =
                                TodoMatrix.GetQuarter(TodoMatrix.QuarterType.NotImportantNotUrgent);
                            quarterNotImportantNotUrgent.ToString();
                            Console.Write(quarterNotImportantNotUrgent);
                            Display.DisplayQuarterMenu();
                            string userInputforQuarter = Input.UserInputQuarterMenu();
                            if (userInputforQuarter == "5")
                            {
                            }

                            if (userInputforQuarter == "4")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                TodoItem todo = quarterNotImportantNotUrgent.GetItem(index);
                                todo.Unmark();
                            }

                            if (userInputforQuarter == "3")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                TodoItem todo = quarterNotImportantNotUrgent.GetItem(index);
                                todo.Mark();
                            }

                            if (userInputforQuarter == "2")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                quarterNotImportantNotUrgent.RemoveItem(index);
                            }

                            if (userInputforQuarter == "1")
                            {
                                Console.WriteLine("title of your todo: ");
                                string title = Input.NewTodoTitle();
                                Console.WriteLine("deadline (DD/MM/YYYY): ");
                                DateTime deadline = Input.NewTodoDeadline();
                                Console.WriteLine("is it important? (y/n): ");
                                string yesOrNo = Input.UserInputYesOrNo();
                                if (yesOrNo == "y")
                                {
                                    TodoMatrix.AddItem(title, deadline, true);
                                }
                                else
                                {
                                    TodoMatrix.AddItem(title, deadline, false);
                                }
                            }
                        }

                        if (userInput == "3")
                        {
                            Display.DisplayQuarterInformation3();
                            TodoQuarter quarterNotImportantUrgent =
                                TodoMatrix.GetQuarter(TodoMatrix.QuarterType.NotImportantUrgent);
                            quarterNotImportantUrgent.ToString();
                            Console.Write(quarterNotImportantUrgent);
                            Display.DisplayQuarterMenu();
                            string userInputforQuarter = Input.UserInputQuarterMenu();
                            if (userInputforQuarter == "5")
                            {
                            }

                            if (userInputforQuarter == "4")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                TodoItem todo = quarterNotImportantUrgent.GetItem(index);
                                todo.Unmark();
                            }

                            if (userInputforQuarter == "3")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                TodoItem todo = quarterNotImportantUrgent.GetItem(index);
                                todo.Mark();
                            }

                            if (userInputforQuarter == "2")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                quarterNotImportantUrgent.RemoveItem(index);
                            }

                            if (userInputforQuarter == "1")
                            {
                                Console.WriteLine("title of your todo: ");
                                string title = Input.NewTodoTitle();
                                Console.WriteLine("deadline (DD/MM/YYYY): ");
                                DateTime deadline = Input.NewTodoDeadline();
                                Console.WriteLine("is it important? (y/n): ");
                                string yesOrNo = Input.UserInputYesOrNo();
                                if (yesOrNo == "y")
                                {
                                    TodoMatrix.AddItem(title, deadline, true);
                                }
                                else
                                {
                                    TodoMatrix.AddItem(title, deadline, false);
                                }
                            }
                        }

                        if (userInput == "2")
                        {
                            Display.DisplayQuarterInformation2();
                            TodoQuarter quarterImportantNotUrgent =
                                TodoMatrix.GetQuarter(TodoMatrix.QuarterType.ImportantNotUrgent);
                            quarterImportantNotUrgent.ToString();
                            Console.Write(quarterImportantNotUrgent);
                            Display.DisplayQuarterMenu();
                            string userInputforQuarter = Input.UserInputQuarterMenu();
                            if (userInputforQuarter == "5")
                            {
                            }

                            if (userInputforQuarter == "4")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                TodoItem todo = quarterImportantNotUrgent.GetItem(index);
                                todo.Unmark();
                            }

                            if (userInputforQuarter == "3")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                TodoItem todo = quarterImportantNotUrgent.GetItem(index);
                                todo.Mark();
                            }

                            if (userInputforQuarter == "2")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                quarterImportantNotUrgent.RemoveItem(index);
                            }

                            if (userInputforQuarter == "1")
                            {
                                Console.WriteLine("title of your todo: ");
                                string title = Input.NewTodoTitle();
                                Console.WriteLine("deadline (DD/MM/YYYY): ");
                                DateTime deadline = Input.NewTodoDeadline();
                                Console.WriteLine("is it important? (y/n): ");
                                string yesOrNo = Input.UserInputYesOrNo();
                                if (yesOrNo == "y")
                                {
                                    TodoMatrix.AddItem(title, deadline, true);
                                }
                                else
                                {
                                    TodoMatrix.AddItem(title, deadline, false);
                                }
                            }
                        }

                        if (userInput == "1")
                        {
                            Display.DisplayQuarterInformation1();
                            TodoQuarter quarterImportantUrgent =
                                TodoMatrix.GetQuarter(TodoMatrix.QuarterType.ImportantUrgent);
                            quarterImportantUrgent.ToString();
                            Console.Write(quarterImportantUrgent);
                            Display.DisplayQuarterMenu();
                            string userInputforQuarter = Input.UserInputQuarterMenu();
                            if (userInputforQuarter == "5")
                            {
                            }

                            if (userInputforQuarter == "4")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                TodoItem todo = quarterImportantUrgent.GetItem(index);
                                todo.Unmark();
                            }

                            if (userInputforQuarter == "3")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                TodoItem todo = quarterImportantUrgent.GetItem(index);
                                todo.Mark();
                            }

                            if (userInputforQuarter == "2")
                            {
                                Display.DisplayChooseTodo();
                                int index = Input.ChooseTodoByIndex();
                                quarterImportantUrgent.RemoveItem(index);
                            }

                            if (userInputforQuarter == "1")
                            {
                                Console.WriteLine("title of your todo: ");
                                string title = Input.NewTodoTitle();
                                Console.WriteLine("deadline (DD/MM/YYYY): ");
                                DateTime deadline = Input.NewTodoDeadline();
                                Console.WriteLine("is it important? (y/n): ");
                                string yesOrNo = Input.UserInputYesOrNo();
                                if (yesOrNo == "y")
                                {
                                    TodoMatrix.AddItem(title, deadline, true);
                                }
                                else
                                {
                                    TodoMatrix.AddItem(title, deadline, false);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}