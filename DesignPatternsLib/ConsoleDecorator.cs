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
    }
}
