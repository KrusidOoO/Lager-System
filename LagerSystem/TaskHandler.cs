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
        public void Search()
        {
            Console.Clear();
            string getProduct = "";
            Console.WriteLine();
            for (int i = 0; i < this.Product().Count(); i++)
            {
                Console.WriteLine(this.Product()[i]);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Please input the product you want to know more about: ");
            string productSearch = Console.ReadLine();
            int x = this.Product().IndexOf(productSearch);
            Console.WriteLine();
            if (this.Product()[x].Contains(productSearch))
                getProduct = this.Product()[x];
            Console.WriteLine();
            int index = this.Product().IndexOf(productSearch);

            var getSerial = this.Serial().ElementAt(index);
            var getAmount = this.Amount().ElementAt(index);
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
                    for (int i = 0; i < this.Product().Count(); i++)
                    {
                        Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("So you want to add a product to the site, \nfirstly enter the serial number of the product");
                    AddSerial = Console.ReadLine();
                    if (this.Serial().Contains(AddSerial))
                    {
                        Console.WriteLine("Error! Serial number already exists");
                        keyInfo = Console.ReadKey();
                    }
                    else if (!this.Serial().Contains(AddSerial))
                    {
                        Console.WriteLine("Success! Serial number has been added \nPress Enter on your keyboard to continue");
                        this.Serial().Add(AddSerial);
                        keyInfo = Console.ReadKey();
                    }
                } while (keyInfo.Key != ConsoleKey.Enter);
                do
                {
                    Console.Clear();
                    Console.WriteLine("Here is a list of serial numbers, products and amount on the website");
                    for (int i = 0; i < this.Amount().Count(); i++)
                    {
                        Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Now what is the name of the product you want to add?");
                    AddProduct = Console.ReadLine();
                    if (this.Product().Contains(AddProduct))
                    {
                        Console.WriteLine("Error! Product name already exists");
                        keyInfo = Console.ReadKey();
                    }
                    else if (!this.Product().Contains(AddProduct))
                    {
                        Console.WriteLine("Success! Product name added \nPress Enter on your keyboard to continue");
                        this.Product().Add(AddProduct);
                        keyInfo = Console.ReadKey();

                    }
                } while (keyInfo.Key != ConsoleKey.Enter);
                Console.Clear();
                Console.WriteLine("Here is a list of serial numbers, products and amount on the website");
                for (int i = 0; i < this.Amount().Count(); i++)
                {
                    Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Enter the amount there is of the product");
                AddAmount = Console.ReadLine();
                this.Amount().Add(AddAmount);
                Console.Clear();
                for (int i = 0; i < this.Amount().Count(); i++)
                {
                    Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Are you happy with your changes? Then press Enter to return to the main menu,\notherwise press any other key on the keyboard");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Enter);

        }

        public void RemoveAndEdit()
        {
            Console.WriteLine("Please enter the action you want to take");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. Edit a Serial number, product or amount");
            Console.WriteLine("2. Delete a set of Serial number, product and amount");

            if(keyInfo.KeyChar=='1')
            {

            }
            else if (keyInfo.KeyChar == '2')
            {
                if (Serial().Any()&&Product().Any()&&Amount().Any())
                {
                    Serial().RemoveAt(Serial().Count - 1);
                    Product().RemoveAt(Product().Count - 1);
                    Amount().RemoveAt(Amount().Count - 1);
                }
            }
        }
        public void ListOfItems()
        {
            Console.Clear();
            Console.WriteLine("Here is a list of the products in storage");
            for (int i = 0; i < this.Serial().Count(); i++)
            {
                Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
            


    }
}
