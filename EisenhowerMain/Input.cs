using System;
using System.Collections.Generic;
using System.Text;

namespace EisenhowerMain
{
    public class Input
    {
        public Input()
        {

        }

        public string GetInput()
        {
            string input = Console.ReadLine();
            if (input.ToUpper() == "Q")
            {
                Environment.Exit(0);
            }
            return input;
        }
    }
}