using System;

namespace DesignPatternsLib
{
    public class FactoryMethodApplication
    {
        private Dialog _dialog;
        public void Run()
        {
            Console.WriteLine("\n====================================================================================\n");
            Console.WriteLine("\t\tFACTORY METHOD");
            Console.WriteLine("\tProvides an interface for creating objects in base class, but\n\tallows derived class to change type of objects that will be created.\n");
            Console.WriteLine("\tWhen to use?");
            Console.WriteLine("\tIf you don`t know exact types and dependencies of the objects\n\tyour code will work with\n");
            Console.WriteLine("\tIf you want your users to easily extend internal components\n");
            Console.WriteLine("\tIf you want to reuse existing objects\n");
            _dialog = new WindowsDialog();
            _dialog.Render();

            Console.WriteLine();

            _dialog = new WebDialog();
            _dialog.Render();

            Console.WriteLine();

            _dialog = new LinuxDialog();
            _dialog.Render();

            Console.WriteLine("\n====================================================================================\n");

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
            Console.WriteLine("Rendering Windows Button on the screen");
        }

        public void OnClick()
        {
            Console.WriteLine("Windows Button was clicked.");
        }
    }

    public class HtmlButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering HtmlButton on the screen");
        }

        public void OnClick()
        {
            Console.WriteLine("Html button was clicked");
        }
    }

    public class LinuxButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Linux Button on the screen");
        }

        public void OnClick()
        {
            Console.WriteLine("Linux button was clicked");
        }
    }
}
