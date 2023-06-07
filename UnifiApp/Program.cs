using System;
using System.Collections.Generic;

namespace UnifiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Unifi App";
            Console.ForegroundColor = ConsoleColor.White;

            // Create a list of products
            List<Product> products = new List<Product>()
            {
                new Product("Dream Machine Professional", "All-in-one, enterprise-grade UniFi Gateway Console designed to host the full UniFi application suite.\r\nIncludes full UniFi application suite for device management\r\n\r\n3.5+ Gbps routing\r\n\r\n(1) 10G SFP+, (8) GbE RJ45 LAN ports\r\n\r\n(1) 10G SFP+, (1) GbE RJ45 WAN ports\r\n\r\n1.3\" touchscreen\r\n\r\n3.5\" HDD bay", 379.00),
                new Product("Dream Wall", "Wall-mountable UniFi Gateway Console with a built-in high-speed access point, network video recorder, and PoE switch.\r\nIntegrated Enterprise WiFi6 (4x4 MIMO)\r\n\r\nFull UniFi OS and UniFi application support\r\n\r\n3.5+ Gbps routing\r\n\r\n(1) 10G SFP+, (17) GbE RJ45 LAN ports including (4) PoE++, (4) PoE+, and (4) PoE ports\r\n\r\n(1) 10G SFP+, (1) 2.5GbE RJ45 WAN ports\r\n\r\n4.7\" touchscreen for management\r\n\r\nIntegrated 128 GB SSD & pre-installed 512 GB microSD cardn", 999.00),
                new Product("U6 Professional", "High-performance, ceiling-mounted WiFi 6 access point designed for large offices.\r\n1,500 ft² coverage\r\n\r\n350+ connected devices\r\n\r\nWiFi6 (4x4 MIMO)\r\n\r\nPowered using PoE", 159.00)
            };
            

            // Run the menu system
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("========== Unifi App ==========");
                Console.WriteLine("1. Displayed Products");
                Console.WriteLine("2. Product Details");
                Console.WriteLine("3. Purchase");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("0. Exit");
                Console.WriteLine("===============================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayProducts(products);
                        break;
                    case "2":
                        ProductDetails(products);
                        break;
                    case "3":
                        PurchaseProduct(products);
                        break;
                    case "4":
                        Checkout();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

            } while (!exit);
        }

        static void DisplayProducts(List<Product> products)
        {
            Console.Clear();
            Console.WriteLine("========== Displayed Products ==========");
            foreach (Product product in products)
            {
                Console.WriteLine($"Name: {product.Name}");
            }
            Console.WriteLine("=======================================");
        }

        static void ProductDetails(List<Product> products)
        {
            Console.Clear();
            Console.WriteLine("========== Product Details ==========");
            Console.WriteLine("Enter the index of the product to view details:");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name}");
            }

            Console.Write("Enter the product index: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index >= 1 && index <= products.Count)
                {
                    Product product = products[index - 1];
                    Console.WriteLine($"Name: {product.Name}");
                    Console.WriteLine($"Description: {product.Description}");
                    Console.WriteLine($"Price: {product.Price}");
                }
                else
                {
                    Console.WriteLine("Invalid product index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        static void PurchaseProduct(List<Product> products)
        {
            // array to store purchased products
            String[] purchasedProducts;
            Console.Clear();
            Console.WriteLine("========== Purchase Product ==========");
            Console.WriteLine("Enter the index of the product to purchase:");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name}");
            }

            Console.Write("Enter the product index: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index >= 1 && index <= products.Count)
                {
                    Product product = products[index - 1];
                    // Add to purchased products
                    purchasedProducts = new string[] { product.Name };
                    Console.Write("Enter your full name: ");
                    string fullName = Console.ReadLine();

                    Console.WriteLine("Select method of payment:");
                    Console.WriteLine("1. Cash");
                    Console.WriteLine("2. Debit Card");
                    Console.WriteLine("3. Credit Card");
                    Console.Write("Enter your payment choice: ");
                    if (int.TryParse(Console.ReadLine(), out int paymentChoice))
                    {
                        if (paymentChoice >= 1 && paymentChoice <= 3)
                        {
                            PaymentMethod paymentMethod = (PaymentMethod)paymentChoice;
                            // Implement purchase logic here
                            Console.WriteLine($"You purchased {product.Name} using {paymentMethod}.");
                            // Check if array is not empty to print the values
                            if (purchasedProducts.Length > 0)
                            {
                                foreach (string purchase in purchasedProducts)
                                {
                                    Console.WriteLine(purchase);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid payment choice.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        static void Checkout()
        {
            Console.Clear();
            Console.WriteLine("========== Checkout ==========");
            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Select method of payment:");
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Debit Card");
            Console.WriteLine("3. Credit Card");
            Console.Write("Enter your payment choice: ");
            if (int.TryParse(Console.ReadLine(), out int paymentChoice))
            {
                if (paymentChoice >= 1 && paymentChoice <= 3)
                {
                    PaymentMethod paymentMethod = (PaymentMethod)paymentChoice;
                    // Implement checkout logic here
                    Console.WriteLine("Checkout completed.");
                }
                else
                {
                    Console.WriteLine("Invalid payment choice.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }

    // Product class
    class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }

    // Enum for payment method
    enum PaymentMethod
    {
        Cash = 1,
        DebitCard,
        CreditCard
    }
}
