using System.Diagnostics;
using System.Xml.Serialization;
using StoreAppLibrary.Logic;

    /* ========== NOTES ==========
    the stores constructor will take in the type of store they want and 
    each individual method will take the customer name, The Stores History
    after a customer makes a order the reciept is for the customer
    so there will be two seperate serialization
    */

namespace StoreApp.App {
    public class Program : GlobalMethods {
        private static string? EntryName;
        private static int EntryNumber;
        private static bool BackToMainMenu;
        static void Main(){
            // Console.WriteLine("Welcome To The Block\n\n What Store Do You Want?");

            // int action = ChooseAction();

            // while (action != 0)
            // {
            //      Console.WriteLine("You CHose "+action);
            //      action = ChooseAction();
            // }
            // // string b = "store";
            // // Stores Store = new(b);
            // // Store
            // Product A = new Product("Space Suit", "Appreal", 40.29M);
            // Product B = new Product("Eggs", "Food", 10.29M);

            // FoodStoreInventory F = new FoodStoreInventory();
            // F.ShoppingList.Add(A);
            // F.ShoppingList.Add(B);
            // decimal total = F.CheckOut();
            // Console.WriteLine("Yo Output IS "+total);

            List<FoodStore>? FoodRecords = ReadRecordsFromFoodStore("../FoodHistory");
            List<FoodStore>? ShoeRecords = ReadRecordsFromFoodStore("../ShoeHistory");
            // Console.WriteLine("\tWelcome To The Block\n\n\tWhat Store Do You Want?");
            // // while (EntryName == null || EntryName.Length <= 0)
            // // {
            // // Thread.Sleep(3000);
            // // EntryName = Console.ReadLine();
            // // }
            //   while (EntryName == null || EntryName.Length <= 0 )
            // {
            //     Thread.Sleep(1000);
            //     Console.Write("1.\t Food Store,\n2.\t Shoe Store\n");
            //     EntryName = Console.ReadLine();
            //     bool validchoice = int.TryParse(EntryName, out EntryNumber);
            //     if (!validchoice || (EntryNumber > 4 && EntryNumber < 0) )
            //     {
            //         Console.WriteLine("Thats not the right store");
            //         Console.WriteLine();
            //         EntryName=null;
            //         continue;
            //     }
            // }
            MainIntroDuction();
            //^^ local
            // int f =0;
            // UserStringToInt(EntryName, "1.\t Food Store,\n2.\t Shoe Store\n", 
            // "Thats not the right store", EntryNumber);
            // GlobalMethods a =new GlobalMethods();
            // GlobalMethods.UserStringToInt();
            // GlobalMethods.UserStringToInt(EntryName, "1.\t Food Store,\n2.\t Shoe Store\n", 
            // "Thats not the right store", EntryNumber);
            // GlobalMethods.UserStringToInt(EntryName, "1.\t Food Store,\n2.\t Shoe Store\n", 
            // "Thats not the right store");
            // GlobalMethods.UserStringToInt("1.\t Food Store,\n2.\t Shoe Store\n", 
            // "Thats not the right store");
            //^^ Global .. THE GLOBAL IDEA DOESNT WORK IN C# .NET
            // Stores store = new(EntryName);
            Stores store = new(GlobalChoose);
            Console.WriteLine(store.CustomerName);
            Console.WriteLine(store.CustomerActionNumber);
            Console.WriteLine(store.StoreName);
            Console.WriteLine(store.CustomerFoodSelectionNumber);
            // Console.WriteLine(EntryNumber);
            Console.WriteLine(GlobalNumber);
             while (true){
                Console.WriteLine("======="); //skipping a line
                Console.WriteLine("STOs COMIN'");
                // Console.WriteLine("Play a round With RoBo? (y/n) ");
                if(EntryNumber == 1){
                // Console.WriteLine("Choose From Our Selection Here");
                store.FoodStoreMarket();
                 Console.WriteLine(store.CustomerName);
            Console.WriteLine(store.CustomerActionNumber);
            Console.WriteLine(store.StoreName);
            Console.WriteLine(store.CustomerFoodSelectionNumber);
            Console.WriteLine("");
            break;
            } else if(EntryNumber == 2){
                // Console.WriteLine("What Are You Trying To Sell?");
                store.ShoeStoreMarket();
                 Console.WriteLine(store.CustomerName);
            Console.WriteLine(store.CustomerActionNumber);
            Console.WriteLine(store.StoreName);
            break;
            }

                // string? Input = Console.ReadLine();

                // if (Input?.ToLower() != "y" || Input == null) { 
                //     Console.WriteLine("&&&& END OF GAME &&&&");
                //     break; 
                //     }

                // game.PlayRound();
            }
        }

        // private static int ChooseAction(){
        //     int choice = 0;
        //     Console.WriteLine("choose 0 to quit,\n 1 to add a item,\n 2 to add to cart,\n 3 for checkout");
        //     choice = int.Parse(Console.ReadLine());
        //     return choice;
        // }

    private static List<FoodStore>? ReadRecordsFromFoodStore(string FilePath){
        XmlSerializer Serializer = new(typeof(List<Serialization.Inventory>));
    try{
       using StreamReader Reader = new(FilePath);
        //  List<Record> Records = (List<Record>?)Serializer.Deserializer(Reader);
         var Records = (List<Serialization.Inventory>?)Serializer.Deserialize(Reader);
          if (Records is null) throw new InvalidDataException();
                return Records.Select(x => x.CreateOrder()).ToList();
    }
    catch (System.Exception)
    {
        
        return null;
    } 
        }
    private static List<FoodStore>? ReadRecordsFromShoeStore(string FilePath){
        XmlSerializer Serializer = new(typeof(List<Serialization.Inventory>));
    try {
            using StreamReader Reader = new(FilePath);
                //  List<Record> Records = (List<Record>?)Serializer.Deserializer(Reader);
                var Records = (List<Serialization.Inventory>?)Serializer.Deserialize(Reader);
                if (Records is null) throw new InvalidDataException();
                return Records.Select(x => x.CreateOrder()).ToList();
        }
    catch (System.Exception)    {
        return null;
        } 
    }

    private static void MainIntroDuction(){
        if(BackToMainMenu == false){
        Console.WriteLine("\tWelcome To The Block\n\n\tWhat Store Do You Want?");
        } else {
            Console.WriteLine("\tWelcome Back To Da Block\n\n\tA New Store?");
            Console.WriteLine("\tWelcome Back To Da Block\n\tA New Store?");
        }
            // while (EntryName == null || EntryName.Length <= 0)
            // {
            // Thread.Sleep(3000);
            // EntryName = Console.ReadLine();
            // }
              while (EntryName == null || EntryName.Length <= 0 )
            {
                Thread.Sleep(1000);
                Console.Write("1.\t Food Store,\n2.\t Shoe Store\n");
                EntryName = Console.ReadLine();
                bool validchoice = int.TryParse(EntryName, out EntryNumber);
                if (!validchoice || (EntryNumber > 4 && EntryNumber < 0) )
                {
                    Console.WriteLine("Thats not the right store");
                    Console.WriteLine();
                    EntryName=null;
                    continue;
                }
            }
    }

    }
}