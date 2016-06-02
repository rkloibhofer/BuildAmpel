using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace BuildAmpelRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            string check = "y";
            string input;
            string ipaddress;

            Console.WriteLine("Build Ampel Testing\n\n");
            Console.WriteLine("Insert the ip adress of the Build Ampel (192.168.124.250):");
            ipaddress = "http://" + Console.ReadLine();


            do
            {

                Console.Clear();

                
                Console.WriteLine("Following options are available (Press the number you want to try): \n");
                Console.WriteLine(" 1 - Building Successful\n 2 - Building Failed\n 3 - Build Successful\n 4 - Build Failed");
                Console.WriteLine("----------------------------------------------------------------------\n");

                input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("You choose option 1.");
                    GetRequest(ipaddress + "/building-successfull");
                }
                else if (input == "2")
                {
                    Console.WriteLine("You choose option 2.");
                    GetRequest(ipaddress + "/building-failed");
                }
                else if (input == "3")
                {
                    Console.WriteLine("You choose option 3.");
                    GetRequest(ipaddress + "/build-successfull");
                }
                else if (input == "4")
                {
                    Console.WriteLine("You choose option 4.");
                    GetRequest(ipaddress + "/build-failed");
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }

                check = Console.ReadLine();
                

            } while (check == "y" || check == "Y");

            // Keep the console window open in debug mode.
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey();
        }

        async static void GetRequest(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        Console.WriteLine("Option was Successful executed");
                        Console.WriteLine("\n\nWant to try it again? (y/n)");
                    }
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Error: Wrong IP-Address!!!");
            }
        }
    }
}
