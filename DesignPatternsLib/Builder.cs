using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Builder
{
    public class BuilderApplication
    {
        public void Run()
        {
            Console.WriteLine(
                "\n====================================================================================\n");
            Console.WriteLine("\t\tBUILDER");
            Console.WriteLine(
                "\tConstruct complex objects step by step. Allows to produce different representations \n\tof an object using same construction code.\n");
            Console.WriteLine("\n\tWhen to use?");
            Console.WriteLine("\tIf you have really long constructors");
            Console.WriteLine("\tIf you want to create different representations of same product\n");

            var carDirector = new CarDirector();
            var builder = new CarBuilder();

            carDirector.CreateSportsCar(builder);
            var sportsCar = builder.GetCar();

            carDirector.CreateSuv(builder);
            var suv = builder.GetCar();

            //OR

            builder.Reset();
            builder.SetSeats(10);
            builder.SetEngine("rocket");
            builder.SetGps();
            builder.SetTripComputer();
            var rocketCar = builder.GetCar();

            Console.WriteLine(sportsCar);
            Console.WriteLine(suv);
            Console.WriteLine(rocketCar);

            Console.WriteLine(
                "\n====================================================================================\n");
        }
    }

    public class Car
    {
        private int _seats;
        private string _engineType;
        private bool _hasTripComputer;
        private bool _hasGps;

        public Car(int seats, string engine, bool hasTripComputer, bool hasGps)
        {
            _seats = seats;
            _engineType = engine;
            _hasTripComputer = hasTripComputer;
            _hasGps = hasGps;
        }

        public override string ToString()
        {
            return $"Seats: {_seats} Engine: {_engineType} TripComputer: {_hasTripComputer} GPS: {_hasGps}";
        }
    }

 

    public interface IBuilder
    {
        void Reset();
        void SetSeats(int seats);
        void SetEngine(string engine);
        void SetTripComputer();
        void SetGps();
    }

    public class CarBuilder : IBuilder
    {
        private int _seats;
        private string _engineType;
        private bool _hasTripComputer;
        private bool _hasGps;

        public CarBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._seats = 0;
            this._engineType = "";
            this._hasGps = false;
            this._hasTripComputer = false;
        }

        public void SetSeats(int seats)
        {
            _seats = seats;
        }

        public void SetEngine(string engine)
        {
            _engineType = engine;
        }

        public void SetTripComputer()
        {
            _hasTripComputer = true;
        }

        public void SetGps()
        {
            _hasGps = true;
        }

        public Car GetCar()
        {
            var car = new Car(_seats, _engineType, _hasTripComputer, _hasGps);
            this.Reset();
            return car;
        }

    }

    public class CarDirector
    {
        public void CreateSportsCar(IBuilder builder)
        {
            builder.Reset();
            builder.SetSeats(2);
            builder.SetEngine("sport");
            builder.SetTripComputer();
            builder.SetGps();
        }
        public void CreateSuv(IBuilder builder)
        {
            builder.Reset();
            builder.SetSeats(4);
            builder.SetEngine("suv");
            builder.SetGps();
        }
    }
}
