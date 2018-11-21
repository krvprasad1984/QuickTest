using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Userclass
{
    class Program
    {
        //GIVEN CODE
        private static void Main(string[] args)
        {
            while (true)
            {
                var user = new User();
                Console.WriteLine("please enter the username, or q to exit");
                var userName = Console.ReadLine();
                if (userName == "q")
                {
                   break;
                }
                user.Add(userName);
                Console.WriteLine($"number of addedUser {user.GetUsersCount()}");
            }

        }
        //MY CODE 
        class User
        {
            //Declaring a static List to store multiple entries
            private static List<string> users = new List<string>();
            //Add Function to append, entered username to list
            public void Add(string userName)
            {
                //Adding the username at as the last item in the list
                users.Add(userName);
            }
            public int GetUsersCount()
            {
                //Returns number of usernames stored in List
                return users.Count;
            }
        }

    }       
}
