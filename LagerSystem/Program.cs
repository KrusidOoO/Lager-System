using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace LagerSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool LoginOK = false;
            int tries=0;
            string name;
            string password;
            String[] userNames = { "Andreas Gregersen", "admin","2ndAdmin" };
            String[] passWords = { "1234", "admin","2ndAdmin" };
            List<string> SerialNumbers = new List<string>() {"4100","4101","4102","4103","4104","4105" };
            List<string> ProductName = new List<string>() { "Gloves".ToLower(), "Trousers".ToLower(), "Jeans", "T-shirts", "Overalls", "Turtle neck"};
            List<string> Amount = new List<string>() { "15", "25", "50", "100", "10", "5"};

            do
            {
                Console.Clear();
                tries++;
                Console.WriteLine("Please enter your name");
                name = Console.ReadLine();
                Console.WriteLine("Please enter your password");
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
                    Console.WriteLine();
                    Console.WriteLine("Hello there and welcome to the storage managment program");
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine("Please enter the number on the keyboard of the menu that you want to get to");
                    Console.WriteLine("1. Find a product, serial number and amount of said product");
                    Console.WriteLine("2. Add a product, together with a serial number and how big the amount of said product is");
                    Console.WriteLine("3. Remove a product, serial number and amount");
                    Console.WriteLine("4. Gets a list of all the products");
                    myChoiceOfKey = Console.ReadKey(true);

                    //Finding a product
                    if (myChoiceOfKey.KeyChar == '1')
                    {
                        Console.Clear();
                        string getProduct = "";
                        Console.WriteLine("Please input the product you want to know more of");
                        string productSearch = Console.ReadLine();
                        int x = ProductName.IndexOf(productSearch);
                        Console.WriteLine();
                        if (ProductName[x].Contains(productSearch))
                            getProduct = ProductName[x];
                        Console.WriteLine();
                        int index = ProductName.IndexOf(productSearch);

                        var getSerialNumber = SerialNumbers.ElementAt(index);
                        var getAmount = Amount.ElementAt(index);
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("#" + getSerialNumber + " : " + char.ToUpper(getProduct[0])+getProduct.Substring(1) + "\nAmount: " + getAmount);
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                    }

                    //Adding a product with serial number and amount
                    if(myChoiceOfKey.KeyChar=='2')
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("So you wish to add a product to the site, firstly enter the serial number you want to give it");
                            string AddSerial = Console.ReadLine();
                            if (SerialNumbers.Contains(AddSerial))
                            {
                                Console.WriteLine("Error! serial number already exists");
                                Console.ReadKey();
                                break;
                            }
                            SerialNumbers.Add(AddSerial);
                            Console.WriteLine("Success! Now, what is the name of the product?");
                            string AddProduct = Console.ReadLine();
                            if(ProductName.Contains(AddProduct))
                            {
                                Console.WriteLine("Error! Product name already exists");
                                Console.ReadKey();
                                break;
                            }
                            ProductName.Add(AddProduct);

                        } while (myChoiceOfKey.Key != ConsoleKey.Escape);
                    }

                    //Removing/changing a product and/or serial number and/or amount
                    if(myChoiceOfKey.KeyChar=='3')
                    {

                    }
                    //Getting a list of the products in stock
                    if (myChoiceOfKey.KeyChar == '4')
                    {
                        Console.Clear();
                        Console.WriteLine("Here is a list of our products");
                        for (int i=0; i < ProductName.Count(); i++)
                        {
                            Console.WriteLine(ProductName[i]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                    }

                } while (myChoiceOfKey.Key != ConsoleKey.Escape);

            }
        }
    }
}
