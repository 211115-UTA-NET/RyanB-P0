using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
// using StoreAppLibrary.Logic;
using Xml = StoreApp.App.Serialization;

/* ============== NOTES ==============
    if the stores name equals 'Food Store' write the history to "../FoodHistory.xml"
    if the stores name equals 'Shoe Store' write the history to "../ShoeHistory.xml"

*/

namespace StoreAppLibrary.Logic {
    public class Stores : GlobalMethods {
        List<FoodStore>? FoodStoreHistory = new List<FoodStore>();
        //^^ FOR XML FILE
        // List<FoodStoreInventory>? FoodStoreInventory = new List<FoodStoreInventory>();
        FoodStoreInventory FoodStoreInventory = new FoodStoreInventory();
        //^^ FOR INVENTORY OF PRODUCTS
        List<ShoeStore>? ShoeStoreHistory = new List<ShoeStore>();
        //^^ FOR XML FILE
        List<ShoeStoreInventory>? ShoeStoreInventory = new List<ShoeStoreInventory>();
        //^^ FOR INVENTORY OF PRODUCTS

        // private readonly StoreInterface Employee;
        // private XmlSerializer Serializer { get; } = new(typeof(List<Xml.Inventory>));
        private string _StoreName;
        public string StoreName {
            get {
                return _StoreName;
            }
            set {
                this._StoreName = value;
            }
        }
        internal string CustomerName;
        internal int CustomerActionNumber = 0;
        internal int CustomerFoodSelectionNumber = 0;
        internal bool BackToStoreMenu = false;
    /*the stores constructor will take in the type of store they want and 
    each individual method will take the customer name, The Stores History
    after a customer makes a order the reciept is for the customer
    so there will be two seperate serialization
    */
        public Stores(string StoreName){
            this.StoreName = StoreName;
            // this.CustomerName = CustomerName;
        }

        private void IntroDuction(){
            
            string? MyName = null;
            
            if(BackToStoreMenu == false){
                Console.WriteLine($"AYE!! What was ya name again? I got short term memory");
                MyName = Console.ReadLine();
                this.CustomerName = MyName;
                Console.WriteLine($"OH!! Welcome {CustomerName}, Here Is Yo' CHoices");
                Console.WriteLine(" 1.\t Buy,\n 2.\t Sell\n 3.\t Look\n 4.\t Complain");
            } else {
                Console.WriteLine($"Hey {CustomerName}, Is There Anything Else You Need?");
                Console.WriteLine(" 1.\t Buy,\n 2.\t Sell\n 3.\t Look\n 4.\t Complain");
            }
            string? Choose = null;
            // string? Choose = Console.ReadLine();
            int Customer=0;
            while (Choose == null || Choose.Length <= 0 )
            {
                
                Console.Write("What's your choice? ");
                Choose = Console.ReadLine();
                bool validchoice = int.TryParse(Choose, out CustomerActionNumber);
                if (!validchoice || (CustomerActionNumber > 4 || CustomerActionNumber < 0) )
                {
                    Console.WriteLine("We Dont know What That Is.., Tell Us Again!");
                    Console.WriteLine();
                    Choose=null;
                    continue;
                }
            }
            //^^ local

            // UserStringToInt(Choose, "What's your choice? ", "Invalid Choice, Try Again!", CustomerNumberChoice);
            // UserStringToInt(Choose, "What's your choice? ", "Invalid Choice, Try Again!");
            // UserStringToInt("What's your choice? ", "Invalid Choice, Try Again!");
            // Console.WriteLine(GlobalNumber);
            //^^ Global .. THE GLOBAL IDEA DOESNT WORK IN C# .NET
                    // Moves CPUChoice = CPUMoves.DecideMove();
            Console.WriteLine();// skipping a line
            CustomerChoice CustomerChoice = (CustomerChoice)(CustomerActionNumber - 1);
            // CustomerChoice CustomerChoice = (CustomerChoice)(CustomerNumberChoice - 1);
            // CustomerChoice CustomerChoice = (CustomerChoice)(GlobalNumber - 1);
            // if(CustomerChoice.){

            // }
            if(CustomerActionNumber == 1){
            Console.WriteLine($"What Would You Like To [{CustomerChoice}]?");
            } else if(CustomerActionNumber == 2){
                Console.WriteLine($"What Are You Trying To [{CustomerChoice}]?");
            } else if(CustomerActionNumber == 3){
                Console.WriteLine($"What Are You [{CustomerChoice}]ing For?");
            } else if(CustomerActionNumber == 4){
                Console.WriteLine($"What Are You [{CustomerChoice}]ing About?");
            }
            // Console.WriteLine($"The Computer Move Was [{CPUChoice}]");
            // OurInventory(CustomerChoice);
            // YourRecipet(CustomerChoice);
          
        }
        
        
        public void FoodStoreMarket(List<FoodStore>? Records = null){
            //                                ^^^ this shold display the updated inventory when not null
            if(Records != null){
                this.FoodStoreHistory = Records;
            };
            this.StoreName = "Food Store";
            IntroDuction();
             if(CustomerActionNumber == 1){
                 if(Records == null){
                Console.WriteLine($"YOUR AT THE {StoreName}, Check Out Our Food");
                //USE THE FOOD STORE INVENTORY WHEN RECORDS IS NULL START
                // Product[] FOOD = new Product[5];
                // FOOD[0] = new Product("Yum Yum", "cat food", 10.00M);
                // FOOD[1] = new Product("Pasta", "carbohydrates", 20.00M);
                // FOOD[2] = new Product("Cake", "dessert", 7.99M);
                // FOOD[3] = new Product("Dragon Fruit", "Fruit", 5.99M);
                // FOOD[4] = new Product("Waffles", "Breakfast", 8.99M);
                // FoodStoreInventory.Add(FOOD);
                // Product FOOD = new Product("Waffles", "Breakfast", 8.99M);
                // printFoodInventory(FOOD);
                // FoodStoreInventory = FOOD.ToList();
                // ShoppingList = FOOD.ToList();
               Product A  = new Product("Yum Yum", "cat food", 10.00M);
                Product B = new Product("Pasta", "carbohydrates", 20.00M);
                Product C = new Product("Cake", "dessert", 7.99M);
                Product D = new Product("Dragon Fruit", "Fruit", 5.99M);
                Product E = new Product("Waffles", "Breakfast", 8.99M);
                // FoodStoreInventory.Add(A);
                // FoodStoreInventory.ShoppingList.Add(A);
                // FoodStoreInventory.ShoppingList.ToArray<FOOD>;
                // FoodStoreInventory.FoodItems.ToArray(FOOD);
                // List<Product> FOODList = new List<Product>(FOOD);
                Console.WriteLine("\n1. 'Yum Yum', 'cat food', 10.00M\n2. 'Pasta', 'carbohydrates', 20.00M\n3. 'Cake', 'dessert', 7.99M\n4. 'Dragon Fruit', 'Fruit', 5.99M\n5. 'Waffles', 'Breakfast', 8.99M");
                string? Choose = null;
                // int NewNumber = 0;
                 while (Choose == null || Choose.Length <= 0 )
            {
                Console.Write("What chu tryna eat? ");
                Choose = Console.ReadLine();
                bool validchoice = int.TryParse(Choose, out CustomerFoodSelectionNumber);
                if (!validchoice || (CustomerFoodSelectionNumber > 5 || CustomerFoodSelectionNumber < 0) )
                {
                    Console.WriteLine("We Dont Have That.. TRY AGAIN!!");
                    Console.WriteLine();
                    Choose=null;
                    continue;
                }
              
                if(CustomerFoodSelectionNumber == 1){
                    FoodStoreInventory.ShoppingList.Add(A);
                } else if(CustomerFoodSelectionNumber == 2){
                    FoodStoreInventory.ShoppingList.Add(B);
                } else if(CustomerFoodSelectionNumber == 3){
                    FoodStoreInventory.ShoppingList.Add(C);
                }  else if(CustomerFoodSelectionNumber == 4){
                    FoodStoreInventory.ShoppingList.Add(D);
                } else if(CustomerFoodSelectionNumber == 5){
                    FoodStoreInventory.ShoppingList.Add(E);
                }
                /*
                    In C# code runs from top to bottom in order. so the if statement 
                    was stopping the logic up top
                */
                  if(validchoice){
                    Choose = null;
                    string? input = null;
                    printFoodInventory(FoodStoreInventory);
                    Console.WriteLine("Do you want more before you buy? (Y/N)\nPress Anything else To Go Back");
                    input = Console.ReadLine();
                    if(input?.ToUpper() == "N"){
                        break;
                    } else if(input?.ToUpper() == "Y"){
                        continue;
                    } else {
                        BackToStoreMenu = true;
                        IntroDuction();
                    }
                }
            }
                printFoodInventory(FoodStoreInventory);
                Console.WriteLine("\nYOUR ORDER DESCRIPTION\n");
                Console.WriteLine(FoodStoreInventory);
                // FoodStoreInventory list = new FoodStoreInventory(FOOD);
                //USE THE FOOD STORE INVENTORY WHEN RECORDS IS NULL END
                 } else {
                     Console.WriteLine("Here Is Our Updated Inventory");
                     Console.WriteLine(Records);
                     Console.WriteLine("Pick Your Food Again");
                 }
                
                
                //USE THE FOOD STORE HISTORY TO RECORD THEIR ORDER START

                //USE THE FOOD STORE HISTORY TO RECORD THEIR ORDER END
            } else if(CustomerActionNumber == 2){
                Console.WriteLine("What Are You Trying To Sell?");
            } else if(CustomerActionNumber == 3){
                Console.WriteLine("What Are You Looking at?");
            } else if(CustomerActionNumber == 4){
                Console.WriteLine("What Are You Complaining about??");
            }

            // if(GlobalNumber == 0){
            //     Console.WriteLine("Choose From Our Selection Here");
            // } else if(GlobalNumber == 1){
            //     Console.WriteLine("What Are You Trying To Sell?");
            // } else if(GlobalNumber == 2){
            //     Console.WriteLine("What Are You Looking at?");
            // } else if(GlobalNumber == 3){
            //     Console.WriteLine("What Are You Complaining about??");
            // }

        }
        public void ShoeStoreMarket(List<ShoeStore>? Records = null){
            if(Records != null){
                this.ShoeStoreHistory = Records;
            };
            this.StoreName = "Shoe Store";
           IntroDuction();
            if(GlobalNumber == 0){
                Console.WriteLine("Choose From Our Selection Here");
            } else if(GlobalNumber == 1){
                Console.WriteLine("What Are You Trying To Sell?");
            } else if(GlobalNumber == 2){
                Console.WriteLine("What Are You Looking at?");
            } else if(GlobalNumber == 3){
                Console.WriteLine("What Are You Complaining about??");
            }

        }

        private void printFoodInventory(FoodStoreInventory inventory){
            foreach (var item in inventory.ShoppingList)
            {
                Console.WriteLine("Food " + item);
            }
        }
    }
}

