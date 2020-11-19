using System;
using DesignPatternsLib;
using DesignPatternsLib.Abstract;
using DesignPatternsLib.Factory;
using DesignPatternsLib.Builder;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //new FactoryMethodApplication().Run();
            //new AbstractFactoryApplication().Run();
            new BuilderApplication().Run();
        }
    }
}
