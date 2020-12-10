using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Structural
{
    public class Bridge : ConsoleDecorator
    {
        public void Run()
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            UseAccentColor();
            Console.WriteLine("\t\tBridge");
            UsePrimaryColor();
            Console.WriteLine(
                "\tSplit a large class or set of closely related classes into two separate \n\thierarchies -abstraction and implementation- which can be developed independently of each other\n");
            UseAccentColor();
            Console.WriteLine("\tWhen to use?");
            UsePrimaryColor();
            Console.WriteLine("\tIf you want to divide and organize monolthic class that has several \n\tvariants of some functionality(e.g. various database servers)");
            Console.WriteLine("\tWhen you need to extend a class in several independent dimensions\n\tThe original class delegates the related work to the objects belonging to \n\tthose hierarchies instead of doing everything on its own.");
            Console.WriteLine("\tIf you need to be able to switch implementations at runtime(reassigning field)");
            Console.WriteLine("\n\tDon`t confuse with Strategy pattern! It`s about intent and problem being addressed");
            UseAccentColor();
            Console.WriteLine("\tHow to implement?");
            UsePrimaryColor();
            Console.WriteLine("\t1. Identify the orthogonal dimensions in your classes.\n\t(e.g. abstraction/platform, domain/infrastructure, front-end/back-end, interface/implementation)\n");
            Console.WriteLine("\t2. Check what operations the client needs and define them in base abstraction class(not abstract)\n");
            Console.WriteLine("\t3. Determinte the operations available on all platforms. Declare the ones the abstraction needs in interface\n");
            Console.WriteLine("\t4. Create concrete implementations, but make sure they all follow the interface\n");
            Console.WriteLine("\t5. Add reference field to interface. It should delegate most of the work to the implementation object\n");
            Console.WriteLine("\t6. If you have several variants of logic, extends base abstraction class\n");
            Console.WriteLine("\t7. Client(app) must pass an implementation object to the abstraction constructor. That`s all for client.\n");

            var remote = new RemoteControl(new Radio());
            remote.TogglePower();
            remote.VolumeUp();

            var advancedRemote = new AdvancedRemoteControl(new Tv());
            advancedRemote.Mute();

            Console.WriteLine(
                "\n====================================================================================\n");
        }
    }

    public class RemoteControl
    {
        protected IDevice _device;

        public RemoteControl(IDevice device)
        {
            _device = device;
        }

        public void TogglePower()
        {
            if (_device.IsEnabled())
            {
                _device.Disable();
            }
        }

        public void VolumeDown()
        {
            _device.SetVolume(_device.GetVolume() - 1);
        }

        public void VolumeUp()
        {
            _device.SetVolume(_device.GetVolume() + 1);
        }

        public void ChannelDown()
        {
            _device.SetChannel(_device.GetChannel() - 1);
        }

        public void ChannelUp()
        {
            _device.SetChannel(_device.GetChannel() + 1);
        }
    }

    public class AdvancedRemoteControl : RemoteControl
    {
        public AdvancedRemoteControl(IDevice device) : base(device)
        { }

        public void Mute()
        {
            _device.SetVolume(0);
        }
    }

    public interface IDevice
    {
        bool IsEnabled();
        void Enable();
        void Disable();
        int GetVolume();
        void SetVolume(int percentage);
        int GetChannel();
        void SetChannel(int channel);
    }

    public class Radio : IDevice
    {
        private bool _isEnabled = false;
        private int _volume;
        private int _channel;

        public bool IsEnabled()
        {
            return _isEnabled;
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }

        public int GetVolume()
        {
            return _volume;
        }

        public void SetVolume(int percentage)
        {
            _volume = percentage;
        }

        public int GetChannel()
        {
            return _channel;
        }

        public void SetChannel(int channel)
        {
            _channel = channel;
        }
    }

    public class Tv : IDevice
    {
        private bool _isEnabled = false;
        private int _volume;
        private int _channel;

        public bool IsEnabled()
        {
            return _isEnabled;
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }

        public int GetVolume()
        {
            return _volume;
        }

        public void SetVolume(int percentage)
        {
            _volume = percentage;
        }

        public int GetChannel()
        {
            return _channel;
        }

        public void SetChannel(int channel)
        {
            _channel = channel;
        }
    }
}