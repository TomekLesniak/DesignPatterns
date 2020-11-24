using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Abstract
{
    public class AbstractFactoryApplication : ConsoleDecorator
    {
        
        public void Run()
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            UseAccentColor();
            Console.WriteLine("\t\tABSTRACT FACTORY");
            UsePrimaryColor();
            Console.WriteLine(
                "\tProduce families of related objects(e.g GUI, furniture, car types etc) \n\twithout specifying their concrete classes");
            UseAccentColor();
            Console.WriteLine("\n\tWhen to use?");
            UsePrimaryColor();
            Console.WriteLine(
                "\tIf code need to work with various families of related products and \n\tyou don`t want to depend on concrete classes - extensibility\n");

            new AbstractFactoryConfiguration(new WindowsFactory()).Render();
            new AbstractFactoryConfiguration(new MacFactory()).Render();

            Console.WriteLine(
                "\n====================================================================================\n");

        }
    }

    public class AbstractFactoryConfiguration
    {
        private IGuiFactory _guiFactory;
        public AbstractFactoryConfiguration(IGuiFactory factory)
        {
            this._guiFactory = factory;
        }

        public void Render()
        {
            _guiFactory.CreateButton().Paint();
            _guiFactory.CreateCheckbox().Paint();
        }
    }

    public interface IGuiFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    public class WindowsFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }
    }

    public class MacFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }

    public interface IButton
    {
        void Paint();
    }

    public class WindowsButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("\tPainting Windows Button");
        }
    }

    public class MacButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("\tPainting Mac Button");
        }
    }

    public interface ICheckbox
    {
        void Paint();
    }

    public class WindowsCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("\tPainting Windows Checkbox");
        }
    }

    public class MacCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("\tPainting Mac Checkbox");
        }
    }
}
