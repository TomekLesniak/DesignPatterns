using System;
using System.Runtime.CompilerServices;
using DesignPatternsLib;
using DesignPatternsLib.Abstract;
using DesignPatternsLib.Factory;
using DesignPatternsLib.Builder;
using DesignPatternsLib.Prototype;
using DesignPatternsLib.Structural;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            UsePrimaryColor();

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

            PrintCreationalTextBetween(5, "Singleton");
            new SingletonApplication().Run();

            #endregion

            #region Structural

            PrintIntroductionTo("STRUCTURAL DESIGN PATTERNS");
            PrintStructuralTextBetween(1, "Adapter");
            new Adapter().Run();

            PrintStructuralTextBetween(2, "Bridge");
            new Bridge().Run();

            #endregion

        }

        private static void PrintIntroductionTo(string patternsCategory)
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            UseAccentColor();
            Console.WriteLine($"\t\t\t{patternsCategory}");
            UsePrimaryColor();
            Console.WriteLine(
                "\n====================================================================================");
            Console.WriteLine(
            "====================================================================================\n");
        }

        private static void PrintCreationalTextBetween(int index, string patternName)
        {
            UseAccentColor();
            Console.WriteLine($"\t\t    CREATIONAL PATTERN {index}/5 - {patternName}");
            UsePrimaryColor();
        }
        private static void PrintStructuralTextBetween(int index, string patternName)
        {
            UseAccentColor();
            Console.WriteLine($"\t\t    STRUCTURAL PATTERN {index}/7 - {patternName}");
            UsePrimaryColor();
        }

        private static void UseAccentColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private static void UsePrimaryColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
