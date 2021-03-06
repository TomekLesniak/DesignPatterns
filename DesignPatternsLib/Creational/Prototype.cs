﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Prototype
{
    public class PrototypeApplication : ConsoleDecorator
    {
        public void Run()
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            UseAccentColor();
            Console.WriteLine("\t\tPROTOTYPE");
            UsePrimaryColor();
            Console.WriteLine(
                "\tLets you copy existing objects without making code dependent on their classes\n\tRemember that copying is often impossible, as you work with interface not implementation ");
            UseAccentColor();
            Console.WriteLine("\n\tWhen to use?");
            UsePrimaryColor();
            Console.WriteLine(
                "\tIf you want to copy object without depending on it");
            Console.WriteLine(
            "\tIf you want to provide a prototype registry for frequently used prototypes\n");
            UseAccentColor();
            Console.WriteLine("\tHow to implement?");
            UsePrimaryColor();
            Console.WriteLine("\t1. Create the prototype interface and declare the clone method\r\n\tin it. Or just add the method to all classes of an existing class\r\n\thierarchy, if you have one.\r\n");
            Console.WriteLine("\t2. A prototype class must define the alternative constructor that\r\n\taccepts an object of that class as an argument. The constructor\r\n\tmust copy the values of all fields defined in the class from the\r\n\tpassed object into the newly created instance. If you’re changing a subclass, you must call \r\n\tthe parent constructor to let the superclass handle the cloning of its private fields.\n");
            Console.WriteLine("\t3. The cloning method usually consists of just one line: running\r\n\ta new operator with the prototypical version of the constructor. Note, that every class must explicitly override the cloning\r\n\tmethod and use its own class name along with the new operator. Otherwise, the cloning method may produce an object of\r\n\ta parent class.\n");
            Console.WriteLine("\t4. Optionally, create a centralized prototype registry to store a\r\n\tcatalog of frequently used prototypes.\r\n\n");

            var rectangle = new Rectangle(1, 2, "red", 10, 20);
            var circle = new Circle(15, 12, "blue", 25);

            var clonedRectangle = rectangle.Clone();
            Console.WriteLine($"\tCloned Rectangle: {clonedRectangle}");

            var clonedCircle = circle.Clone();
            Console.WriteLine($"\tCloned Circle: {clonedCircle}");


            Console.WriteLine(
                "\n====================================================================================\n");

        }
    }

    public abstract class Shape
    {
        private int _x;
        private int _y;
        private string _color;

        protected Shape(int x = 0, int y = 0, string color = "white")
        {
            _x = x;
            _y = y;
            _color = color;
        }

        protected Shape(Shape source)
        {
            _x = source._x;
            _y = source._y;
            _color = source._color;
        }

        public abstract Shape Clone();

        public override string ToString()
        {
            return $"({_x}, {_y})";
        }
    }

    public class Rectangle : Shape
    {
        private int _width;
        private int _height;

        public Rectangle(int x, int y, string color, int width, int height) : base(x, y, color)
        {
            this._width = width;
            this._height = height;
        }

        public Rectangle(Rectangle source) : base(source)
        {
            this._width = source._width;
            this._height = source._height;
        }

        public override Shape Clone()
        {
            return new Rectangle(this);
        }

        public override string ToString()
        {
            return base.ToString() + $" width {_width}, height {_height}";
        }
    }

    public class Circle : Shape
    {
        private int _radius;

        public Circle(int x, int y, string color, int radius) : base(x, y, color)
        {
            this._radius = radius;
        }

        public Circle(Circle source) : base(source)
        {
            this._radius = source._radius;
        }

        public override Shape Clone()
        {
            return new Circle(this);
        }

        public override string ToString()
        {
            return base.ToString() + $" radius: {_radius}";
        }
    }
}
