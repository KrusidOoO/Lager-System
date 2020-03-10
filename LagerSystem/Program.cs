using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LagerSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskHandler TH = new TaskHandler();
            bool LoginOK = false;
            int tries=0;
            string name;
            string password;
            String[] userNames = { "Andreas Gregersen", "admin","2ndAdmin" };
            String[] passWords = { "1234", "admin","2ndAdmin" };
            do
            {
                Console.Clear();
                tries++;
                Console.WriteLine("\n--------------------------" +
                                  "\n| Please enter your name |" +
                                  "\n--------------------------");
                name = Console.ReadLine();
                Console.WriteLine("\n------------------------------" +
                                  "\n| Please enter your password |" +
                                  "\n------------------------------");
                password = Console.ReadLine();
                for(int i=0;i<3;i++)
                {
                    if (name == userNames[i] && password == passWords[i])
                        LoginOK = true;
                }
            } while (tries < 3 && !LoginOK);

            if (LoginOK == true)
            {
            ConsoleKeyInfo myChoiceOfKey;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\nHello there and welcome to the storage managment program" +
                                      "\n--------------------------------------------------------" +
                                      "\nPlease enter the number on the keyboard of the menu that you want to get to" +
                                      "\n1. Find a product, serial number and amount of said product" +
                                      "\n2. Add a product, together with a serial number and \nhow big the amount of said product is" +
                                      "\n3. Remove or change a product, serial number and/or amount" +
                                      "\n4. Gets a list of all the products" +
                                      "\n\nPress Escape to exit the application." +
                                      "\n--------------------------------------------------------");
                    myChoiceOfKey = Console.ReadKey(true);
                    switch (myChoiceOfKey.KeyChar)
                    {
                //Finding a product
                        case '1':
                            TH.Search();
                            break;
                //Adding a product with serial number and amount
                        case '2':
                            TH.Addition();
                            break;
                //Removing/changing a product and/or serial number and/or amount
                        case '3':
                            TH.RemoveAndEdit();
                            break;
                //Getting a list of the products in stock
                        case '4':
                            TH.ListOfItems();
                            break;
                        default:
                            break;
                    }
                } while (myChoiceOfKey.Key != ConsoleKey.Escape);
            }
        }
    }
}
