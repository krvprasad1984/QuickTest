using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConstructionGame
{
  public class Program
    {
        private static void Main(string[] args)
        {
            var myHouse = new Building()
            .AddKitchen()
            .AddBedroom("master")
            .AddBedroom("guest")
            .AddBalcony();

            myHouse.Build();

            //kitchen, master room, guest room, balcony
            Console.WriteLine(myHouse.Describe());

            myHouse.AddKitchen().AddBedroom("another");

            //before build the house description still is as before
            //kitchen, master room, guest room, balcony
            Console.WriteLine(myHouse.Describe());
            myHouse.Build();

            //it only shows the kitchen after build
            //kitchen, master room, guest room, balcony, kitchen, another room
            Console.WriteLine(myHouse.Describe());
            Console.ReadKey();
        }

        
    }
  public class Building
    {

        //StringBuilder desc = new StringBuilder("");
        List<string> finDesc = new List<string>();
        static string postbuild;

        // Implimentation of fluent interfaces

        public Building AddKitchen()
        {
            finDesc.Add("Kitchen");
            Console.Write("Kitchen added. Build Pending");
            Console.WriteLine("\n");
            //Return "this" will allow "var myHouse = new Building().AddKitchen().AddBedroom("master").AddBedroom("guest")" kind of calls
            // by showing what we are returning in current "Building"
            return this;
        }

        public Building AddBalcony()
        {
            finDesc.Add("Balcony");
            Console.WriteLine("Balcony Added. Build Pending");
            Console.WriteLine("\n");
            return this;

        }
        public Building AddBedroom(String b)
        {
            finDesc.Add(b + " room");
            Console.WriteLine(b+"room Added. Build Pending");
            Console.WriteLine("\n");
            return this;

        }
        public void Build()
        {
            postbuild = string.Join(",", finDesc.ToArray());
            Console.WriteLine("\n");
            Console.WriteLine("Pending Builds Completed");
            Console.WriteLine("\n");
            //return finDesc;
        }
        public string Describe()
        {
            string x = postbuild;
            //Console.ReadKey();
            return x;
        }
    }


    }
