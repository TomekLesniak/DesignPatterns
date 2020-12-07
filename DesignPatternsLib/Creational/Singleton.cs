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
            UseAccentColor();
            Console.WriteLine("\tHow to implement?");
            UsePrimaryColor();
            Console.WriteLine("\t1. Add a private static field to the class for storing the singleton instance.\n");
            Console.WriteLine("\t2. Declare a public static creation method for getting the singleton instance\n");
            Console.WriteLine("\t3. Implement “lazy initialization” inside the static method. It\r\n\tshould create a new object on its first call and put it into the\r\n\tstatic field. The method should always return that instance on all subsequent calls.\n");
            Console.WriteLine("\t4. Make the constructor of the class private. The static method of\r\n\tthe class will still be able to call the constructor, but not the other objects.\r\n");
            Console.WriteLine("\t5. Go over the client code and replace all direct calls to the singleton’s \r\n\tconstructor with calls to its static creation method.\n\n");

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
