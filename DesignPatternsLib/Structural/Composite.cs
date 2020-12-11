using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Structural
{
    public class Composite : ConsoleDecorator
    {
        public void Run()
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            UseAccentColor();
            Console.WriteLine("\t\tComposite");
            UsePrimaryColor();
            Console.WriteLine("\tLets you compose objects into tree structures and then work with them as they were individual objects\n");
            UseAccentColor();
            Console.WriteLine("\tWhen to use?");
            UsePrimaryColor();
            Console.WriteLine("\tWhen you have to implement tree-like object structure. It let you have either \n\tsimple objects or composed containers by working with common interface");
            Console.WriteLine("\tWhen you want the client code to treat both simple and complex objects uniformly");
            UseAccentColor();
            Console.WriteLine("\tHow to implement?");
            UsePrimaryColor();
            Console.WriteLine("\t1. Make sure that core model of your app can be represented as tree structure.\n\tTry to break it down into simple elements and containers. Remember that \n\tcontainers must be able to contain both simple elements and other containers.\n");
            Console.WriteLine("\t2. Declare the component interface with methods that makes sense for single and complex objects.\n");
            Console.WriteLine("\t3. Create a leaf class to represent simple elements. May have multiple different leaf classes.\n");
            Console.WriteLine("\t4. Create a container class to represent complex elements. In this class, provide an array\n\tof common interface. Remember it should delegate most of the work to sub elements\n");
            Console.WriteLine("\t5. Define the methods for adding and removing of child elements in container.\n\tYou can add those in interface so client would treat ALL elements the same.\n");

            var imageEditor = new ImageEditor();
            imageEditor.Load();
            imageEditor.Draw();


            Console.WriteLine(
                "\n====================================================================================\n");

        }

        public class ImageEditor
        {
            private List<IGraphic> _allGraphics = new List<IGraphic>();

            public void Load()
            {
                var compoundGraphic = new CompoundGraphic();
                compoundGraphic.Add(new Circle(1,2,3));
                compoundGraphic.Add(new Dot(6,5));
                compoundGraphic.Add(new Dot(6,1));
                compoundGraphic.Add(new Circle(10,20,30));
                compoundGraphic.Add(new Dot(2,3));

                _allGraphics.Add(compoundGraphic);
            }

            public void MergeSelectedIntoCompoundGraphic(List<IGraphic> selectedComponents)
            {
                var group = new CompoundGraphic();
                foreach (var selected in selectedComponents)
                {
                    group.Add(selected);
                    _allGraphics.Remove(selected);
                }
                _allGraphics.Add(group);
            }

            public void Draw()
            {
                foreach (var element in _allGraphics)
                {
                    element.Draw();
                }
            }
        }

        public interface IGraphic
        {
            void Move(int x, int y);
            void Draw();
        }

        public class Dot : IGraphic
        {
            protected int _x;
            protected int _y;

            public Dot(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public void Move(int x, int y)
            {
                _x += x;
                _y += y;
            }

            public virtual void Draw()
            {
                Console.WriteLine($"\tDrawing dot at ({_x}, {_y})");
            }
        }

        public class Circle : Dot
        {
            private int _radius;

            public Circle(int x, int y, int radius) : base(x, y)
            {
                _radius = radius;
            }

            public override void Draw()
            {
                Console.WriteLine($"\tDrawing circle at ({_x}, {_y}) with radius {_radius}");
            }
        }

        public class CompoundGraphic : IGraphic
        {
            private List<IGraphic> _children;

            public CompoundGraphic()
            {
                _children = new List<IGraphic>();
            }

            public void Add(IGraphic graphic)
            {
                _children.Add(graphic);
            }

            public void Remove(IGraphic graphic)
            {
                _children.Remove(graphic);
            }

            public void Move(int x, int y)
            {
                foreach (var child in _children)
                {
                    child.Move(x, y);
                }
            }

            public void Draw()
            {
                foreach (var child in _children)
                {
                    child.Draw();
                }
            }
        }
    }
}
