using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Structural
{
    public class Adapter : ConsoleDecorator
    {
        public void Run()
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            UseAccentColor();
            Console.WriteLine("\t\tAdapter");
            UsePrimaryColor();
            Console.WriteLine("\tAllows objects with incompatible interfaces to collaborate\n");
            UseAccentColor();
            Console.WriteLine("\tWhen to use?");
            UsePrimaryColor();
            Console.WriteLine("\tUse the Adapter class when you want to use some existing\r\n\tclass, but its interface isn’t compatible with the rest of your code.\r");
            Console.WriteLine("\tUse the pattern when you want to reuse several existing subclasses that lack some \r\n\tcommon functionality that can’t be added to the superclass\r");
            UseAccentColor();
            Console.WriteLine("\n\tHow to implement?");
            UsePrimaryColor();
            Console.WriteLine("\t1. Make sure there are two classes: Usefull service class which you can`t change\n\t and one or more client classes that would benefit using this service\n");
            Console.WriteLine("\t2. Declare the client interface and describe how clients communicate with the service\n");
            Console.WriteLine("\t3. Create the adapter class and make it follow the client interface. Leave other methods empty for now\n");
            Console.WriteLine("\t4. Add fields to adapter class to store a reference to the service object.\n\tThe common practice is to initialize this field via constructor, but\n\t you can also pass it to the adapter when calling methods\n");
            Console.WriteLine("\t5. Implement all methods of the client interface in adapter class. Adapter should delegate most of the real work\n\tto the service object, handling only data format conversion\n");
            Console.WriteLine("\t6. Clients should use the adapter via the client interface. This will let you change or extend the adapter\n\twithout affecting the client code\n");

            var hole = new RoundHole(5);
            var rpeg = new RoundPeg(5);
            Console.WriteLine($"\thole(5) fits rpeg compatible(5) = {hole.Fits(rpeg)}");

            var smallSqpeg = new SquarePeg(5);
            var largeSqpeg = new SquarePeg(10);

            //hole.Fits(smallSqpeg); Incompatible

            var smallSqpegAdapter = new SquarePegAdapter(smallSqpeg);
            var largeSqpegAdapter = new SquarePegAdapter(largeSqpeg);

            Console.WriteLine($"\thole(5) fits smallSqpegAdapter(5) = {hole.Fits(smallSqpegAdapter)}");
            Console.WriteLine($"\thole(5) fits largeSqpegAdapter(10) = {hole.Fits(largeSqpegAdapter)}");


            Console.WriteLine(
                "\n====================================================================================\n");
        }
    }

    public class RoundHole
    {
        public float Radius { get; private set; }

        public RoundHole(float radius)
        {
            Radius = radius;
        }

        public bool Fits(RoundPeg peg)
        {
            return Radius >= peg.Radius;
        }
    }

    public class RoundPeg
    {
        public float Radius { get; private set; }

        public RoundPeg(float radius)
        {
            Radius = radius;
        }
    }

    public class SquarePeg
    {
        public float Width { get; set; }

        public SquarePeg(float width)
        {
            Width = width;
        }
    }

    public class SquarePegAdapter : RoundPeg
    {
        private SquarePeg _peg;
        public SquarePegAdapter(SquarePeg peg) : base(peg.Width * (float) Math.Sqrt(2) / 2)
        {
            _peg = peg;
        }
    }
}
