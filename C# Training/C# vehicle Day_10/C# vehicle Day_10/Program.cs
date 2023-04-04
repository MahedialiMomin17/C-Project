using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__vehicle_Day_10
{
    internal class Program
    {
        class Vehicle
        {
            private string model;
            private int year;
            private double pricePerKm;

            public string Model
            {
                get { return model; }
                set { model = value; }
            }

            public int Year
            {
                get { return year; }
                set { year = value; }
            }

            public double PricePerKm
            {
                get { return pricePerKm; }
                set { pricePerKm = value; }
            }
        }

        class OlaRide : Vehicle
        {
            private string pickup;
            private string drop;
            private double distance;

            public OlaRide(string model, int year, double pricePerKm, string pickup, string drop, double distance)
            {
                this.Model = model;
                this.Year = year;
                this.PricePerKm = pricePerKm;
                this.pickup = pickup;
                this.drop = drop;
                this.distance = distance;
            }

            public double CalculateFare()
            {
                return distance * PricePerKm;
            }

            public void PrintData()
            {
                Console.WriteLine("Model: {0}\n", Model);
                Console.WriteLine("Year: {0}\n", Year);
                Console.WriteLine("Price per Km: {0}\n", PricePerKm);
                Console.WriteLine("Pickup: {0}\n", pickup);
                Console.WriteLine("Drop: {0}\n", drop);
                Console.WriteLine("Distance: {0} Km\n", distance);
                Console.WriteLine("Fare: Rs. {0}\n", CalculateFare());
            }
        }


        static void Main(string[] args)
        {
            // Initialize a new Ola ride
            OlaRide ride = new OlaRide("Honda City", 2018, 12.5, "Anand", "Ahmedabad", 50.5);

            // Print the ride details and fare
            ride.PrintData();

            Console.ReadKey();
        }


    }
}
