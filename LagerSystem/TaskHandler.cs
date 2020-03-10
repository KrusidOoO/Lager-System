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
            Console.WriteLine("\nHere is a list of the products in storage.\n");
            for (int i = 0; i < this.Product().Count(); i++)
            {
                Console.WriteLine(this.Product()[i]);
                Console.WriteLine();
            }
            Console.WriteLine("\nPlease input the product/product name, you want to know more about: ");
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
            Console.WriteLine("\n#" + getSerial + " : " + char.ToUpper(getProduct[0])+getProduct.Substring(1) + "\nAmount: " + getAmount + "\n----------------------------------\nPress any key to return to the main menu");
            Console.ReadKey();
            return;
        }
        public void Addition()
        {
            string AddSerial;
            string AddProduct;
            string AddAmount;
            int counter = 0;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Here is a list of serial numbers, products/product names and amount in storage\n-----------------------------------------------");
                    for (int i = 0; i < this.Product().Count(); i++)
                    {
                        Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
                    }
                    Console.WriteLine("\n-----------------------------------------------\nSo you want to add a product to the site\nFirstly enter the serial number you want to add\n(note: it cannot be a serial number that already exists in the list above):");
                    counter++;
                    AddSerial = Console.ReadLine();
                    if (this.Serial().Contains(AddSerial)||counter<1)
                    {
                        Console.Clear();
                        Console.WriteLine("Error! Serial number already exists\nPress any key to retry");
                        Console.ReadKey();
                    }
                    else if (!this.Serial().Contains(AddSerial)||counter>1)
                    {
                        Console.Clear();
                        Console.WriteLine("Success! Serial number has been added \nPress Enter on your keyboard to continue");
                        this.Serial().Add(AddSerial);
                        keyInfo = Console.ReadKey();
                    }
                    else if(this.Serial().Contains(AddSerial)&&counter<1)
                        this.Serial().RemoveAt(this.Serial().Count - 1);
                } while (keyInfo.Key != ConsoleKey.Enter);
                do
                {
                    Console.Clear();
                    Console.WriteLine("Here is a list of serial numbers, products/product names and amount in storage");
                    for (int i = 0; i < this.Amount().Count(); i++)
                    {
                        Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
                    }
                    Console.WriteLine("\nEnter the product name you want to add\n(note: it cannot be a product name that already exists in the list above):");
                    AddProduct = Console.ReadLine();
                    if (this.Product().Contains(AddProduct))
                    {
                        Console.Clear();
                        Console.WriteLine("Error! Product name already exists");
                        keyInfo = Console.ReadKey();
                    }
                    else if (!this.Product().Contains(AddProduct))
                    {
                        Console.Clear();
                        Console.WriteLine("Success! Product name added \nPress Enter on your keyboard to continue");
                        this.Product().Add(AddProduct);
                        keyInfo = Console.ReadKey();
                    }
                } while (keyInfo.Key != ConsoleKey.Enter);
                Console.Clear();
                Console.WriteLine("Here is a list of serial numbers, products/product names and amount in storage");
                for (int i = 0; i < this.Amount().Count(); i++)
                {
                    Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
                }
                Console.WriteLine("\nEnter the amount there is of the product:");
                AddAmount = Console.ReadLine();
                this.Amount().Add(AddAmount);
                Console.Clear();
                for (int i = this.Amount().Count()-1; i < this.Amount().Count(); i++)
                {
                    Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
                }
                Console.WriteLine("\nAre you happy with your changes? Then press Enter to return to the main menu,\notherwise press any other key on the keyboard\n(note: if you press any other key on the keyboard, your addition to the storage will be lost)");
                keyInfo = Console.ReadKey();

                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    this.Serial().RemoveAt(this.Serial().Count - 1);
                    this.Product().RemoveAt(this.Product().Count - 1);
                    this.Amount().RemoveAt(this.Amount().Count - 1);
                }
                else if(keyInfo.Key==ConsoleKey.Enter)
                {

                }

            } while (keyInfo.Key != ConsoleKey.Enter);

        }
        public void RemoveAndEdit()
        {
            Console.Clear();
            Console.WriteLine("Please enter the action you want to take\n----------------------------------------\n1. Edit a Serial number, product or amount\n2. Delete a set of Serial number, product and amount");
            keyInfo = Console.ReadKey();
            switch (keyInfo.KeyChar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("\n----------------------------------------------\nSo you want to edit a product, so let us do that\nHere is a list of the available products to edit\n------------------------------------------------");
                    for (int i = 0; i < this.Product().Count(); i++)
                    {
                        Console.WriteLine(this.Serial()[i] + " " +
                            this.Product()[i] + " " + this.Amount()[i]);
                        Console.WriteLine();
                    }
                    Console.WriteLine("---------------------------------------------" + "\nPlease enter the name of the product you want to edit");
                    string getProductName;
                    string changedProduct;
                    string changedAmount;
                    getProductName = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("----------------------------------------------\nOkay, so you want to edit " + getProductName + "\nEnter the changes you want to apply to product/product name");
                    this.Product()[this.Product().FindIndex(ind => ind.Equals(getProductName))] = changedProduct = Console.ReadLine();
                    int y = this.Product().IndexOf(changedProduct);
                    var getAmount = this.Amount().ElementAt(y);
                    Console.Clear();
                    Console.WriteLine("----------------------------------------------\nEnter the changes you want to apply to amount");
                    this.Amount()[this.Amount().FindIndex(ind => ind.Equals(getAmount))]= changedAmount = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("----------------------------------------------\nChanges completed\nPress any key to return to the main menu");
                    Console.ReadKey();
                    break;
                case '2':
                    string getProduct;
                    Console.Clear();
                    for (int i = 0; i < this.Product().Count(); i++)
                    {
                        Console.WriteLine(this.Serial()[i] + " " +
                            this.Product()[i] + " " + this.Amount()[i]);
                        Console.WriteLine();
                    }
                    Console.WriteLine("--------------------------------------------\nPlease enter the name of the product you want to delete.");
                    getProduct = Console.ReadLine();
                    int x = this.Product().IndexOf(getProduct);
                    this.Serial().RemoveAt(x);
                    this.Product().RemoveAt(x);
                    this.Amount().RemoveAt(x);
                    Console.Clear();
                    for (int i = 0; i < this.Product().Count(); i++)
                    {
                        Console.WriteLine(this.Serial()[i] + " " +
                            this.Product()[i] + " " + this.Amount()[i]);
                        Console.WriteLine();
                    }
                    Console.WriteLine("----------------\nDelete completed");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
        public void ListOfItems()
        {
            Console.Clear();
            Console.WriteLine("Here is a list of the products in storage\n" + "-----------------------------------------");
            for (int i = 0; i < this.Serial().Count(); i++)
            {
                Console.WriteLine("#" + this.Serial()[i] + " : " + this.Product()[i] + "\nAmount: " + this.Amount()[i]);
            }
            Console.WriteLine("\n----------------------------------------\n\nPress any key to return to the main menu");
            Console.ReadKey();
        }
    }
}
