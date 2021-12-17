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
    public class Stores : Global {
        List<FoodStore>? FoodStoreHistory = new List<FoodStore>();
        List<ShoeStore>? ShoeStoreHistory = new List<ShoeStore>();

        // private readonly StoreInterface Employee;
        // private XmlSerializer Serializer { get; } = new(typeof(List<Xml.Inventory>));
        internal string StoreName;
        internal string CustomerName;
        internal int CustomerNumberChoice = 0;
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
            Console.WriteLine($"AYE!! What was ya name again? I got short term memory");
            string? MyName = Console.ReadLine();
            this.CustomerName = MyName;
            Console.WriteLine($"OH!! Welcome {CustomerName}, Here Is Yo' CHoices");
            Console.WriteLine("1.\t Buy,\n 2.\t Sell\n 3.\t Look\n 4.\t Complain");
            string? Choose = null;
            // string? Choose = Console.ReadLine();
            // int Customer=0;
            // while (Choose == null || Choose.Length <= 0 )
            // {
            //     Console.Write("What's your choice? ");
            //     Choose = Console.ReadLine();
            //     bool validchoice = int.TryParse(Choose, out Customer);
            //     if (!validchoice || (Customer > 4 && Customer < 0) )
            //     {
            //         Console.WriteLine("Invalid Choice, Try Again!");
            //         Console.WriteLine();
            //         Choose=null;
            //         continue;
            //     }
            // }
            //^^ local

            UserStringToInt(Choose, "What's your choice? ", "Invalid Choice, Try Again!", CustomerNumberChoice);
            //^^ Global
                    // Moves CPUChoice = CPUMoves.DecideMove();
            Console.WriteLine();// skipping a line
            CustomerChoice CustomerChoice = (CustomerChoice)(CustomerNumberChoice - 1);
            // if(CustomerChoice.){

            // }

            Console.WriteLine($"Your Transaction is [{CustomerChoice}]");
            // Console.WriteLine($"The Computer Move Was [{CPUChoice}]");
            // OurInventory(CustomerChoice);
            // YourRecipet(CustomerChoice);
          
        }
        
        public void FoodStoreMarket(List<FoodStore>? Records = null){
            if(this.FoodStoreHistory != null){
                this.FoodStoreHistory = Records;
            };
            this.StoreName = "Food Store";
            IntroDuction();
            if(this.CustomerNumberChoice == 0){
                Console.WriteLine("Choose From Our Selection Here");
            } else if(this.CustomerNumberChoice == 1){
                Console.WriteLine("What Are You Trying To Sell?");
            } else if(this.CustomerNumberChoice == 2){
                Console.WriteLine("What Are You Looking at?");
            } else if(this.CustomerNumberChoice == 3){
                Console.WriteLine("What Are You Complaining about??");
            }

        }
        public void ShoeStoreMarket(List<ShoeStore>? Records = null){
            if(this.ShoeStoreHistory != null){
                this.ShoeStoreHistory = Records;
            };
            this.StoreName = "Shoe Store";
           IntroDuction();
            if(this.CustomerNumberChoice == 0){
                Console.WriteLine("Choose From Our Selection Here");
            } else if(this.CustomerNumberChoice == 1){
                Console.WriteLine("What Are You Trying To Sell?");
            } else if(this.CustomerNumberChoice == 2){
                Console.WriteLine("What Are You Looking at?");
            } else if(this.CustomerNumberChoice == 3){
                Console.WriteLine("What Are You Complaining about??");
            }

        }
    }
}

