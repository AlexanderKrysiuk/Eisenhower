using System;
using System.Collections.Generic;
using EisenhowerMain;

namespace EisenhowerMain
{
    public class Display
    {
        public Display()
        {

        }

        public void PrintMatrix(TodoMatrix matrix)
        {
            Dictionary<string, TodoQuarter> todoQuarters = matrix.GetQuarters();
            foreach (KeyValuePair<string, TodoQuarter> entry in todoQuarters)
            {
                switch (entry.Key)
                {
                    case "IU":
                        Print("Important, urgent:");
                        PrintRed(entry.Value.ToString());
                        break;
                    case "IN":
                        Print("Important, not urgent:");
                        PrintGreen(entry.Value.ToString());
                        break;
                    case "NU":
                        Print("Not important, urgent:");
                        PrintRed(entry.Value.ToString());
                        break;
                    case "NN":
                        Print("Not important, not urgent:");
                        PrintGreen(entry.Value.ToString());
                        break;
                }
            }
        }

        private void Print(string text)
        {
            Console.WriteLine(text);
        }

        private void PrintGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}