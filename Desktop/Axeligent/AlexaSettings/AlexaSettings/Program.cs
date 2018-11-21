using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlexaSettings
{
    class Program
    {
        private static void Main(string[] args)
        {
            var alexa = new Alexa();
            Console.WriteLine(alexa.Talk()); //print hello, i am Alexa

            alexa.Configure(x =>
            {
                x.GreetingMessage = "Hello {OwnerName}, I'm at your service";
                x.OwnerName = "Bob Marley";
            });

            Console.WriteLine(alexa.Talk()); //print Hello Bob Marley, I'm at your service

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();

        }

        public class Alexa
        {
            public Input input;
            public string Talk()
            {
                if (input == null)
                    return "hello, i am Alexa";
                else
                    return input.getMessage();
            }
            //Delligate Declaration
            public delegate void ConfigureDeligate(Input input);
            public void Configure(ConfigureDeligate input)
            {
                this.input = new Input();
                input.Invoke(this.input);
            }

        }
        //Input class to prepare 
        public class Input
        {
            public string GreetingMessage;
            public string OwnerName;
            public string getMessage()
            {
                return GreetingMessage.Replace("{OwnerName}", OwnerName);
            }
        }

    }

}
