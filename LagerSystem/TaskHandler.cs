using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LagerSystem
{
    class TaskHandler
    {
        ConsoleKeyInfo keyInfo;
        Item Data = new Item();
        TaskHandler TH = new TaskHandler();
        readonly List<string> SerialNumb = new List<string>();

        
        public List<string> Serial()
        {
            List<string> SerialNumb = Data.GetSerial();
            return SerialNumb;
        }
        public List<string> Product()
        {
            List<string> ProductNam = Data.GetProduct();
            return ProductNam;
        }
        public List<string> Amount()
        {
            List<string> ProdAmount = Data.GetAmount();
            return ProdAmount;
        }
        
        public class GetProduct
        {
            
        }

        public void Search()
        {
            Console.Clear();
            string getProduct = "";
            Console.WriteLine("Please input the product you want to know more about: ");
            string productSearch = Console.ReadLine();
            int x = TH.Product().IndexOf(productSearch);
            Console.WriteLine();
            if (TH.Product()[x].Contains(productSearch))
                getProduct = TH.Product()[x];
            Console.WriteLine();
            int index = TH.Product().IndexOf(productSearch);

            var getSerial = TH.Serial().ElementAt(index);
            var getAmount = TH.Amount().ElementAt(index);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("#" + getSerial + " : " + char.ToUpper(getProduct[0])+getProduct.Substring(1) + "\nAmount: " + getAmount);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            return;
        }
        public void Addition()
        {
            string AddSerial;
            string AddProduct;
            string AddAmount;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Here is a list of serial numbers, products and amount on the website");
                    for (int i = 0; i < TH.Product().Count(); i++)
                    {
                        Console.WriteLine("#" + TH.Serial()[i] + " : " + TH.Product()[i] + "\nAmount: " + TH.Amount()[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("So you want to add a product to the site, \nfirstly enter the serial number of the product");
                    AddSerial = Console.ReadLine();
                    if (TH.Serial().Contains(AddSerial))
                    {
                        Console.WriteLine("Error! Serial number already exists");
                        keyInfo = Console.ReadKey();
                    }
                    else if (!TH.Serial().Contains(AddSerial))
                    {
                        Console.WriteLine("Success! Serial number has been added \nPress 0 on your keyboard to continue");
                        TH.Serial().Add(AddSerial);
                        keyInfo = Console.ReadKey();
                    }
                } while (keyInfo.Key != ConsoleKey.D0);
                do
                {
                    Console.Clear();
                    Console.WriteLine("Here is a list of serial numbers, products and amount on the website");
                    for (int i = 0; i < TH.Amount().Count(); i++)
                    {
                        Console.WriteLine("#" + TH.Serial()[i] + " : " + TH.Product()[i] + "\nAmount: " + TH.Amount()[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Now what is the name of the product you want to add?");
                    AddProduct = Console.ReadLine();
                    if (TH.Product().Contains(AddProduct))
                    {
                        Console.WriteLine("Error! Product name already exists");
                        keyInfo = Console.ReadKey();
                    }
                    else if (!TH.Product().Contains(AddProduct))
                    {
                        Console.WriteLine("Success! Product name added \nPress 0 on your keyboard to continue");
                        TH.Product().Add(AddProduct);
                        keyInfo = Console.ReadKey();

                    }
                } while (keyInfo.Key != ConsoleKey.D0);
                Console.Clear();
                Console.WriteLine("Here is a list of serial numbers, products and amount on the website");
                for (int i = 0; i < TH.Amount().Count(); i++)
                {
                    Console.WriteLine("#" + TH.Serial()[i] + " : " + TH.Product()[i] + "\nAmount: " + TH.Amount()[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Enter the amount there is of the product");
                AddAmount = Console.ReadLine();
                TH.Amount().Add(AddAmount);

                for (int i = 0; i < TH.Product().Count(); i++)
                {
                    Console.WriteLine("#" + TH.Serial()[i] + " : " + TH.Product()[i] + "\nAmount: " + TH.Amount()[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Are you happy with your changes? Then press Escape to return to the main menu,\notherwise press any other key on the keyboard");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Escape);

        }

        public void ListOfItems()
        {
            Console.Clear();
            Console.WriteLine("Here is a list of the products in storage");
            for (int i = 0; i < TH.Serial().Count(); i++)
            {
                Console.WriteLine("#" + TH.Serial()[i] + " : " + TH.Product()[i] + "\nAmount: " + TH.Amount()[i]);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
            


    }
}
