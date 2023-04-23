using System;


namespace EisenhowerMain
{
    class Program
    {
        private readonly TodoMatrix _todoMatrix = new TodoMatrix();
        private readonly Display _display = new Display();

        private readonly Input _input = new Input();


        public void Main()
        {
            while (true)
            {
                _display.ClearScreen();
                _display.DisplayTodos(_todoMatrix);
                _display.DisplayStartMenu();
                string userInput = _input.UserInputStartMenu();
                if (userInput == "9")
                {
                    Environment.Exit(1);
                }
                else
                {
                    if (userInput == "8")
                    {
                        _todoMatrix.SaveItems();
                    }

                    if (userInput == "7")
                    {
                        _todoMatrix.AddItem();
                    }

                    if (userInput == "6")
                    {
                        _todoMatrix.ArchiveItems();
                    }

                    if (userInput == "5")
                    {
                        Console.WriteLine("title of your todo: ");
                        string title = _input.NewTodoTitle();
                        Console.WriteLine("deadline (DD/MM/YYYY): ");
                        DateTime deadline = _input.NewTodoDeadline();
                        Console.WriteLine("is it important? (y/n): ");
                        string yesOrNo = _input.UserInputYesOrNo();
                        if (yesOrNo == "y")
                        {
                            _todoMatrix.AddItem(title, deadline);
                        }
                        else
                        {
                            _todoMatrix.AddItem(title, deadline);
                        }
                    }
                    else
                    {
                        if (userInput == "4")
                        {
                            _display.DisplayQuarterInformation4();
                            TodoQuarter quarterNotImportantNotUrgent =
                                _todoMatrix.GetQuarter(_todoMatrix.AddItem());
                            var s = quarterNotImportantNotUrgent.ToString();
                            Console.Write(s);
                            _display.DisplayQuarterMenu();
                            string userInputForQuarter = _input.UserInputQuarterMenu();
                            if (userInputForQuarter == "5")
                            {
                            }

                            if (userInputForQuarter == "4")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                TodoItem todo = quarterNotImportantNotUrgent.GetItem(index);
                                todo.Unmark();
                            }

                            if (userInputForQuarter == "3")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                TodoItem todo = quarterNotImportantNotUrgent.GetItem(index);
                                todo.Mark();
                            }

                            if (userInputForQuarter == "2")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                quarterNotImportantNotUrgent.RemoveItem(index);
                            }

                            if (userInputForQuarter == "1")
                            {
                                Console.WriteLine("title of your todo: ");
                                string title = _input.NewTodoTitle();
                                Console.WriteLine("deadline (DD/MM/YYYY): ");
                                DateTime deadline = _input.NewTodoDeadline();
                                Console.WriteLine("is it important? (y/n): ");
                                string yesOrNo = _input.UserInputYesOrNo();
                                if (yesOrNo == "y")
                                {
                                    _todoMatrix.AddItem(title, deadline);
                                }
                                else
                                {
                                    _todoMatrix.AddItem(title, deadline);
                                }
                            }
                        }

                        if (userInput == "3")
                        {
                            _display.DisplayQuarterInformation3();
                            TodoQuarter quarterNotImportantUrgent =
                                _todoMatrix.GetQuarter(_todoMatrix.AddItem());
                            var s = quarterNotImportantUrgent.ToString();
                            Console.Write(s);
                            _display.DisplayQuarterMenu();
                            string userInputForQuarter = _input.UserInputQuarterMenu();
                            if (userInputForQuarter == "5")
                            {
                            }

                            if (userInputForQuarter == "4")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                TodoItem todo = quarterNotImportantUrgent.GetItem(index);
                                todo.Unmark();
                            }

                            if (userInputForQuarter == "3")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                TodoItem todo = quarterNotImportantUrgent.GetItem(index);
                                todo.Mark();
                            }

                            if (userInputForQuarter == "2")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                quarterNotImportantUrgent.RemoveItem(index);
                            }

                            if (userInputForQuarter == "1")
                            {
                                Console.WriteLine("title of your todo: ");
                                string title = _input.NewTodoTitle();
                                Console.WriteLine("deadline (DD/MM/YYYY): ");
                                DateTime deadline = _input.NewTodoDeadline();
                                Console.WriteLine("is it important? (y/n): ");
                                string yesOrNo = _input.UserInputYesOrNo();
                                if (yesOrNo == "y")
                                {
                                    _todoMatrix.AddItem(title, deadline);
                                }
                                else
                                {
                                    _todoMatrix.AddItem(title, deadline);
                                }
                            }
                        }

                        if (userInput == "2")
                        {
                            _display.DisplayQuarterInformation2();
                            TodoQuarter quarterImportantNotUrgent =
                                _todoMatrix.GetQuarter(_todoMatrix.AddItem());
                            var s = quarterImportantNotUrgent.ToString();
                            Console.Write(s);
                            _display.DisplayQuarterMenu();
                            string userInputForQuarter = _input.UserInputQuarterMenu();
                            if (userInputForQuarter == "5")
                            {
                            }

                            if (userInputForQuarter == "4")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                TodoItem todo = quarterImportantNotUrgent.GetItem(index);
                                todo.Unmark();
                            }

                            if (userInputForQuarter == "3")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                TodoItem todo = quarterImportantNotUrgent.GetItem(index);
                                todo.Mark();
                            }

                            if (userInputForQuarter == "2")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                quarterImportantNotUrgent.RemoveItem(index);
                            }

                            if (userInputForQuarter == "1")
                            {
                                Console.WriteLine("title of your todo: ");
                                string title = _input.NewTodoTitle();
                                Console.WriteLine("deadline (DD/MM/YYYY): ");
                                DateTime deadline = _input.NewTodoDeadline();
                                Console.WriteLine("is it important? (y/n): ");
                                string yesOrNo = _input.UserInputYesOrNo();
                                if (yesOrNo == "y")
                                {
                                    _todoMatrix.AddItem(title, deadline);
                                }
                                else
                                {
                                    _todoMatrix.AddItem(title, deadline);
                                }
                            }
                        }

                        if (userInput == "1")
                        {
                            _display.DisplayQuarterInformation1();
                            TodoQuarter quarterImportantUrgent =
                                _todoMatrix.GetQuarter(_todoMatrix.AddItem());
                            var s = quarterImportantUrgent.ToString();
                            Console.Write(s);
                            _display.DisplayQuarterMenu();
                            string userInputForQuarter = _input.UserInputQuarterMenu();
                            if (userInputForQuarter == "5")
                            {
                            }

                            if (userInputForQuarter == "4")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                TodoItem todo = quarterImportantUrgent.GetItem(index);
                                todo.Unmark();
                            }

                            if (userInputForQuarter == "3")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                TodoItem todo = quarterImportantUrgent.GetItem(index);
                                todo.Mark();
                            }

                            if (userInputForQuarter == "2")
                            {
                                _display.DisplayChooseTodo();
                                int index = _input.ChooseTodoByIndex();
                                quarterImportantUrgent.RemoveItem(index);
                            }

                            if (userInputForQuarter == "1")
                            {
                                Console.WriteLine("title of your todo: ");
                                string title = _input.NewTodoTitle();
                                Console.WriteLine("deadline (DD/MM/YYYY): ");
                                DateTime deadline = _input.NewTodoDeadline();
                                Console.WriteLine("is it important? (y/n): ");
                                string yesOrNo = _input.UserInputYesOrNo();
                                if (yesOrNo == "y")
                                {
                                    _todoMatrix.AddItem(title, deadline);
                                }
                                else
                                {
                                    _todoMatrix.AddItem(title, deadline);
                                }
                            }
                        }
                    }
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}