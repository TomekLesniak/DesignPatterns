using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib
{
    public abstract class ConsoleDecorator
    {
        protected void UsePrimaryColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        protected void UseAccentColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        /*
         * public void Run()
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            UseAccentColor();
            Console.WriteLine("\t\NAME");
            UsePrimaryColor();
            Console.WriteLine("\tWHAT DOES\n");
            UseAccentColor();
            Console.WriteLine("\tWhen to use?");
            UsePrimaryColor();
            Console.WriteLine("\tWHEN");
            UseAccentColor();
            Console.WriteLine("\tHow to implement?");
            UsePrimaryColor();
            Console.WriteLine("\t1. \n");
            


            Console.WriteLine(
                "\n====================================================================================\n");

        }
         */
    }
}
