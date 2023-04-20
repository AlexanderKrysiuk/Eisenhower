using System;
using System.Collections.Generic;

namespace EisenhowerMain
{
    internal class Input
    {
        public readonly List<string> QuarterMenu = new List<string> { "1", "2", "3", "4", "5" };
        public readonly List<string> StartMenu = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private readonly Display _display = new Display();
        private TodoMatrix _todoMatrix = new TodoMatrix();


        public string UserInputYesOrNo()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput == "y" || userInput == "n") return userInput;
                _display.DisplayWrongInputMessage();
            }
        }


        public int ChooseTodoByIndex()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput != null)
                {
                    var index = short.Parse(userInput) - 1;
                    return index;
                }
            }
        }


        public string UserInputStartMenu()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (StartMenu.Contains(input)) return input;
                _display.DisplayWrongInputMessage();
            }
        }


        public string UserInputQuarterMenu()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (StartMenu.Contains(input)) return input;
                _display.DisplayWrongInputMessage();
            }
        }


        public string NewTodoTitle()
        {
            var input = Console.ReadLine();
            return input;
        }


        public DateTime NewTodoDeadline()
        {
            while (true)
            {
                var input = Console.ReadLine();
                DateTime dateTime;
                if (DateTime.TryParse(input, out dateTime)) return dateTime;
                _display.DisplayWrongInputMessage();
            }
        }
    }
}