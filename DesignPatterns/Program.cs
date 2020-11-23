using System;
using System.Runtime.CompilerServices;
using DesignPatternsLib;
using DesignPatternsLib.Abstract;
using DesignPatternsLib.Factory;
using DesignPatternsLib.Builder;
using DesignPatternsLib.Prototype;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {

            #region CreationalPatterns
            
            PrintIntroductionTo("CREATIONAL DESIGN PATTERNS");
            PrintCreationalTextBetween(1, "Factory Method");
            new FactoryMethodApplication().Run();

            PrintCreationalTextBetween(2, "Abstract Factory");
            new AbstractFactoryApplication().Run();

            PrintCreationalTextBetween(3, "Builder");
            new BuilderApplication().Run();

            PrintCreationalTextBetween(4, "Prototype");
            new PrototypeApplication().Run();
            #endregion

        }

        private static void PrintIntroductionTo(string patternsCategory)
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            Console.WriteLine($"\t\t\t{patternsCategory}");
            Console.WriteLine(
                "\n====================================================================================");
            Console.WriteLine(
            "====================================================================================\n");
        }

        private static void PrintCreationalTextBetween(int index, string patternName)
        {
            Console.WriteLine($"\t\t    CREATIONAL PATTERN {index}/5 - {patternName}");
        }
    }
}
