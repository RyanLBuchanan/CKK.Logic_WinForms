//using CKK.Logic.Models;
//using System;

//namespace CKK
//{
//    class ShoppingCartImplementation
//    {
        

//        public static void Main(string[] args)
//        {
//            int quant = 0;
//            Product prod = new Product();
//            Customer cust = new Customer();
//            ShoppingCart myCart = new ShoppingCart(cust);
//            Store mikesGeneral = new Store();
//            Console.WriteLine("Welcome to Corey's Knick Knacks");
//            var input = "";
//            while (input != "4")
//            {
//                Console.WriteLine(GetMenu());
//                input = Console.ReadLine();
//                Console.Clear();
//                switch (input)
//                {
//                    case "1":
//                        myCart.AddProduct(prod, quant);
//                        Console.WriteLine("Which product do you want to add?");
                 


//                        break;
//                    case "2":
//                        myCart.RemoveProduct(prod, quant);
//                        break;
//                    case "3":
//                        myCart.GetTotal();
//                        break;
//                }
//            }

//            Console.WriteLine("Thanks for coming!");
//            Console.WriteLine("Press any key to continue...");
//            Console.ReadKey();
//        }

        
      

//        public static string GetMenu()
//        {
//            return
//                "What would you like to do?\n" +
//                "1. Add Product to my shopping cart\n" +
//                "2. Remove Product to my shopping cart\n" +
//                "3. Get total of shopping cart items\n" +
//                "4. Exit";
//        }
//    }
//}
