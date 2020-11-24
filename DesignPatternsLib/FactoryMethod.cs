using System;

namespace DesignPatternsLib.Factory
{
    public class FactoryMethodApplication
    {
        private Dialog _dialog;

        public void Run()
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            Console.WriteLine("\t\tFACTORY METHOD");
            Console.WriteLine(
                "\tProvides an interface for creating objects in base class, but\n\tallows derived class to change type of objects that will be created.\n");
            Console.WriteLine("\tWhen to use?");
            Console.WriteLine(
                "\tIf you don`t know exact types and dependencies of the objects\n\tyour code will work with\n");
            Console.WriteLine("\tIf you want your users to easily extend internal components");
            Console.WriteLine("\tIf you want to reuse existing objects\n");
            Console.WriteLine("\tHow to implement?");
            Console.WriteLine("\t1. Make all products follow the same interface. This interface should \n\tdeclare methods that make sense in every product.\n");
            Console.WriteLine("\t2. Add an empty factory method inside the creator class. The return type \n\tof the method should match the common product interface.\n");
            Console.WriteLine("\t3. In the creator’s code find all references to product constructors.\r\n\tOne by one, replace them with calls to the factory method,\r\n\twhile extracting the product creation code into the factory method\n");
            Console.WriteLine("\t4. Now, create a set of creator subclasses for each type of product \r\n\tlisted in the factory method. Override the factory method\r\n\tin the subclasses and extract the appropriate \r\n\tbits of construction code from the base method.\n");
            Console.WriteLine("\t5. If there are too many product types and it doesn’t make sense\r\n\tto create subclasses for all of them, you can reuse the control\r\n\tparameter from the base class in subclasses.");
            Console.WriteLine("\t6. If, after all of the extractions, the base factory method has\r\n\tbecome empty, you can make it abstract. If there’s something\r\n\tleft, you can make it a default behavior of the method.\n\n");
            _dialog = new WindowsDialog();
            _dialog.Render();

            Console.WriteLine();

            _dialog = new WebDialog();
            _dialog.Render();

            Console.WriteLine();

            _dialog = new LinuxDialog();
            _dialog.Render();

            Console.WriteLine(
                "\n====================================================================================\n");

        }
    }

    public interface IButton
    {
        void Render();
        void OnClick();
    }

    public abstract class Dialog
    {
        public abstract IButton CreateButton();

        public void Render()
        {
            var button = CreateButton();
            button.Render();
            button.OnClick();
        }
    }

    public class WindowsDialog : Dialog
    {
        public override IButton CreateButton()
        {
            return new WindowsButton();
        }
    }

    public class WebDialog : Dialog
    {
        public override IButton CreateButton()
        {
            return new HtmlButton();
        }
    }

    public class LinuxDialog : Dialog
    {
        public override IButton CreateButton()
        {
            return new LinuxButton();
        }
    }

    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("\tRendering Windows Button on the screen");
        }

        public void OnClick()
        {
            Console.WriteLine("\tWindows Button was clicked.");
        }
    }

    public class HtmlButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("\tRendering HtmlButton on the screen");
        }

        public void OnClick()
        {
            Console.WriteLine("\tHtml button was clicked");
        }
    }

    public class LinuxButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("\tRendering Linux Button on the screen");
        }

        public void OnClick()
        {
            Console.WriteLine("\tLinux button was clicked");
        }
    }
}