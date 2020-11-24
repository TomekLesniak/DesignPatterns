using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib
{
    public class SingletonApplication : ConsoleDecorator
    {
        public void Run()
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            UseAccentColor();
            Console.WriteLine("\t\tSINGLETON");
            UsePrimaryColor();
            Console.WriteLine(
                "\tEnsure that class has only one instance, while providing global access point to that instance");
            UseAccentColor();
            Console.WriteLine("\n\tWhen to use?");
            UsePrimaryColor();
            Console.WriteLine(
                "\tIf you want just single instance available to all clients, e.g database");
            Console.WriteLine(
                "\tIf you want to have strict control over global variables\n");

            var accessPointOne = Database.GetInstance();
            var accessPointTwo = Database.GetInstance();

            accessPointOne.Query("AP1: UPDATE table SET id = 1");
            accessPointTwo.Query("AP2: SELECT * FROM ...");



            Console.WriteLine(
                "\n====================================================================================\n");
        }
    }

    public class Database
    {
        private static Database _instance;

        private Database()
        {
            // Connection to a database server
        }

        public static Database GetInstance()
        {
            if (_instance == null)
            {
                // If multi-threading, lock threads
                Console.WriteLine("\tSingleton called for the first time - creating new instance");
                _instance = new Database();
            }

            return _instance;
        }

        public void Query(string sql)
        {
            // Can use caching here to improve
            Console.WriteLine($"\t{sql}");
        }


    }
}
