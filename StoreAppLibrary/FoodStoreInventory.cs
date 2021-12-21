using System.Collections.Generic;

/*  ==== NOTES ====
You cannot, because IEnumerable<T> does not necessarily represent a collection to which items can be added. In fact, it does not necessarily represent a collection at all! For example:

IEnumerable<string> ReadLines()
{
     string s;
     do
     {
          s = Console.ReadLine();
          yield return s;
     } while (!string.IsNullOrEmpty(s));
}

IEnumerable<string> lines = ReadLines();
lines.Add("foo") // so what is this supposed to do??
What you can do, however, is create a new IEnumerable object (of unspecified type), which, when enumerated, will provide all items of the old one, plus some of your own. You use Enumerable.Concat for that:

 items = items.Concat(new[] { "foo" });
This will not change the array object (you cannot insert items into to arrays, anyway). But it will create a new object that will list all items in the array, and then "Foo". Furthermore, that new object will keep track of changes in the array (i.e. whenever you enumerate it, you'll see the current values of items).

*/

namespace StoreAppLibrary.Logic {
    public class FoodStoreInventory : ShoppingCart, StoreInterface  {
        private List<Product[]> FoodItems {get; set;}
        private List<Product> _ShoppingList;
        public List<Product> ShoppingList {get{
            //^^ not the same type
            //^^ so when adding and removing from this list its not correct logic and syntax wise
            return _ShoppingList;
        } set{
            this._ShoppingList = value;
        }}
        private List<Product> _CustomerOwnedItems;
        public List<Product> CustomerOwnedItems {get{
           //ITEMS THAT THE CUSTOMER BOUGHT
            return _CustomerOwnedItems;
        } set{
            this._CustomerOwnedItems = value;
        }}
        private String _Name;
        private String _Type;
        private int _Price;
        public string Name {
            get {
                return _Name;
            }
            set {
                this._Name = value;
            }
        } 
        public string Type {
            get {
                return _Type;
            }
            set {
                this._Type = value;
            }
        } 
        public int Price {
            get {
                return _Price;
            }
            set {
                this._Price = value;
            }
        } 
        /*
                Product A  = new Product("Yum Yum", "cat food", 10.00M);
                Product B = new Product("Pasta", "carbohydrates", 20.00M);
                Product C = new Product("Cake", "dessert", 7.99M);
                Product D = new Product("Dragon Fruit", "Fruit", 5.99M);
                Product E = new Product("Waffles", "Breakfast", 8.99M);
        */
        // private IEnumerable<Product> _FoodList;
        private List<Product> _FoodList;
        private bool BackToStoreMenu = false;
        private string CustomerName;
        internal int CustomerActionNumber = 0;
        internal int CustomerFoodSelectionNumber = 0;
        // public IEnumerable<Product> FoodList {
        //     get {
        //         yield return new Product {ID = 1, Quantity = 1000, Name = "Cookies",  Type="Desserts", Price=10.00M};
        //         yield return new Product {ID = 2, Quantity = 1000, Name = "Pasta",  Type="carbohydrates", Price=30.00M};
        //         yield return new Product {ID = 3, Quantity = 1000, Name = "Cake",  Type="Desserts", Price=7.99M};
        //         yield return new Product {ID = 4, Quantity = 1000, Name = "Dragon Fruit",  Type="Fruit", Price=5.99M};
        //         yield return new Product {ID = 5, Quantity = 1000, Name = "Waffles",  Type="Breakfast", Price=9.99M};
        //     }
        //     set {
        //         this._FoodList = value;
        //     }
        // }
    //    public List<Product> FoodList {
    //         get {
    //             return _FoodList;
    //         }
    //         set {
    //             this._FoodList = value;
    //         }
    //     }
        public List<Product> FoodList = new List<Product>{
            new Product(1, 1000, "Cookies", "Desserts", 10.00M),
            new Product(2, 1000, "Pasta", "carbohydrates", 30.00M),
            new Product(3, 1000, "Cake", "Desserts", 7.99M),
            new Product(4, 1000, "Dragon Fruit", "Fruit", 5.99M),
            new Product(5, 1000, "Waffles", "Breakfast", 9.99M),
        };
        // public int NumberOfItems {get{
        //     return FoodList.Count
        // }}
            //    public void ShowList(){
            // var ItemsList = new FoodStoreInventory();
            // foreach(Product Item in ItemsList.FoodList){
            //     Console.WriteLine("We Got' " + Item);
            // }
               public void ShowList(){
                   //^^ might envolve the records as a parameter
                //    FoodList.Add(new Product(1, 1000, "Cookies", "Desserts", 10.00M));
                //    FoodList.Add(new Product(2, 1000, "Pasta", "carbohydrates", 30.00M));
                //    FoodList.Add(new Product(3, 1000, "Cake", "Desserts", 7.99M));
                //    FoodList.Add(new Product(4, 1000, "Dragon Fruit", "Fruit", 5.99M));
                //    FoodList.Add(new Product(4, 1000, "Waffles", "Breakfast", 9.99M));
            // var ItemsList = new FoodStoreInventory();
            // foreach(Product Item in ItemsList.FoodList){
            //     Console.WriteLine("We Got' " + Item);
            // }
            foreach(Product Item in FoodList){
                Console.WriteLine("We Got' " + Item);
            }
            
            // for(int number = 1; number < ItemsList.FoodList; number++){
            //     Console.WriteLine("What We Got' " + Item);
            // }
//             foreach(var item in .Select((value, i) => new { i, value }))
// {
//     var value = item.value;
//     var index = item.i;
// }
        }
        public int NumberOfFood(){
            return FoodList.Count();
        }
        public int QuantityOfFood(int number){
            var a = 0;
            foreach (var item in FoodList)
            {
                // FoodList.ForEach(r => {
                // if(item.Quantity > r.Quantity){
                //     // return false;
                //     Console.WriteLine("We Dont Have That");
                //     a = 0;
                // } else {
                // }
                // });
                //  a = item.Quantity;
                if(number > item.Quantity){
                     Console.WriteLine("We Dont Have That");
                    a = 0;
                } else if(number < item.Quantity){
                     Console.WriteLine("We Got That");
                    a = item.Quantity;
                } else if(number == item.Quantity){
                      Console.WriteLine("This Is Our Last Supply");
                    a = item.Quantity;
                }
            //    return a;
            }
             return a;
        }
//substract from yield Quantity and add entire object to customer list
//ListName.Count for total Items
//var result = firms.Except(trackedFirms); // returns all the firms except those in trackedFirms

// public void TakeFood(IEnumerable<Product> product, List<Product> CustomerList){
// public void TakeFood(int Selection, List<Product> CustomerList){
// public void TakeFood(int Selection, int PickedQuantity, List<Product> CustomerList){
public void TakeFood(int Selection, int PickedQuantity){
    //if the name is the same as the customer item than you plus one that items quantity (DONE)
    //substract from quantity if customer has the item or not (DONE)
    //if customer doenst have the item add the entire item as is (DONE)
    // var l = product.GetEnumerator().Current.Quantity;
    // var l = product.GetEnumerator().Current.Quantity;

    //      IDEAS
    // create ids for each product and have user put in a number and check if number matches that id
    //^^ than thats their product than look at the quantity subsstract from it
    //^^^ than check to see if user have that whole item, if customer doesnt add whole item
    //^^^^ if they dont add quantity
    Product? SelectedItem = null;
            //   foreach (var item in ShoppingList)
            // //adding to the list
            // {
            //     Product? UpdatedItem = null;
            //     // Console.WriteLine(ShoppingList);
            //     //^^ not showing when nothing is added
            //     if(Selection == item.ID && item.Quantity >= 1){
            //         Console.WriteLine("I Have SOmething in here");
            //         item.Quantity += 1;
            //         UpdatedItem = item;
            //     } else {
            //         Console.WriteLine("I Have Nothing In here");
            //     }
            //         Console.WriteLine(item);
            //     //THE ITEM .... NOT THE LIST

            // }
            // List<Product> FoodListTOLIST = FoodList.ToList();
            //^ not sure if its working

            //   var newlist = FoodList.Select(point => {
            //         point.Quantity = 1;
            //         return point;
            //     }).ToList();
            //^^ works but might be a better way

            // foreach (var item in FoodList)
            // //for the list here
            // {
            //     // FoodList.ForEach(a => a.Quantity -= 1);
            //     //^^ not here
            //     if (Selection == item.ID)
            //     {
            //         // FoodList.ForEach(a => a.Quantity -= 1);
            //         //^^ not here
            //         if (CustomerList.Contains(item))
            //         {
            //             // item.Quantity -= 1;
            //             item.Quantity -= Selection;
            //             // FoodList.ForEach(a => {
            //             // if(a.ID == item.ID){
            //             // }
            //             // });
            //             // item.Quantity += 1;
            //             // SelectedItem = item;
            //             CustomerList.ForEach(d =>
            //             {
            //                 if (d.ID == item.ID)
            //                 {
            //                     // item.Quantity += 1;
            //                     // d.Quantity += 1;
            //                     d.Quantity += Selection;
            //                 }
            //             });
            //         }
            //         else
            //         {
            //             // FoodList.ForEach(a =>
            //             // {
            //             //     if (a.ID == item.ID)
            //             //     {
            //             //     }
            //             // });
            //                     // item.Quantity -= 1;
            //                     item.Quantity -= Selection;
                            
            //             // item.Quantity += 1;
            //             // item.Quantity = 1;
            //             CustomerList.ForEach(d => {
            //                 if(d.ID == item.ID){

            //                     // d.Quantity += 1;
            //                     // SelectedItem = item;
            //                 }
            //             });
            //             // item.Quantity = 1;
            //             // SelectedItem = item;
            //             // CustomerList.Add(SelectedItem);
            //             CustomerList.Add(new Product(item.ID, Selection, item.Name, item.Type, item.Price));
            //             Console.WriteLine("NEW ITEM");

            //         }
            //         // FoodList.ForEach(a => a.Quantity -= 1);
            //         //^^ not here

            //     }

            //     Console.WriteLine(item);
            // }
    //  FoodList.ForEach(a => {
    //             // Console.WriteLine(a);
    //         if(a.ID == Selection){
    //             // a.Quantity -= 1;
    //             a.Quantity -= Selection;
    //             // SelectedItem = 
    //         }
    //         });
    //             // item.Quantity += 1;
    //     // item.Quantity = 1;
    //     CustomerList.ForEach(d => {
    //             Console.WriteLine(d);
    //         if(d.ID == Selection){
    //             // d.Quantity += 1;
    //             // SelectedItem = d;
    //         }
    //     });
    // FoodList.Where(w => w.ID == Selection).ToList().ForEach( x => {
    //     if(CustomerList.Contains(x)){
    //         x.Quantity += 1;
    //         FoodList.ForEach(c => {
    //             if(c.ID == Selection){
    //                 c.Quantity -= 1;
    //             }
    //         });
    //     } else {
    //         SelectedItem = x;
    //     }
    // });
    var CustomerItem = new Product(0, 0, "", "", 0);
             foreach (var item in FoodList)
                    //for the list here
                    {
                        Console.WriteLine("Inside for each loop");
                        // FoodList.ForEach(a => a.Quantity -= 1);
                        //^^ not here
                        if (Selection == item.ID)
                        {
                            Console.WriteLine("item IS THE SAME as selection");
                            // FoodList.ForEach(a => a.Quantity -= 1);
                            //^^ not here
                            // foreach(var g in CustomerList){
                                //cant do nested foreach in C#
                                // Console.WriteLine("SECOND FOR EACH");
                               var CompareCustomerList = ShoppingList.Exists(x => x.ID == Selection);
                            if (CompareCustomerList)
                            {
                                // CustomerList.Where(x => {
                                //     if(x.ID == item.ID){
                                //          Console.WriteLine("I Have this");
                                // // item.Quantity -= 1;
                                // item.Quantity -= PickedQuantity;
                                // x.Quantity += PickedQuantity;
                                // return true;
                                //     } else {
                                //                   item.Quantity -= PickedQuantity;
                                // CustomerItem.ID = item.ID;
                                // CustomerItem.Quantity += PickedQuantity;
                                // CustomerItem.Name = item.Name;
                                // CustomerItem.Type = item.Type;
                                // CustomerItem.Price = item.Price;   
                                // // CustomerList.Add(new Product(item.ID, Selection, item.Name, item.Type, item.Price));
                                // CustomerList.Add(CustomerItem);
                                // Console.WriteLine("NEW ITEM");
                                // return false;
                                //     }

                                // });
                                //^^^ not this way .. it doenst work
                                Console.WriteLine("Seems Like You Got This Product\n");
                                // item.Quantity -= 1;
                                item.Quantity -= PickedQuantity;
                                // FoodList.ForEach(a => {
                                // if(a.ID == item.ID){
                                // }
                                // });
                                // item.Quantity += 1;
                                // SelectedItem = item;
                                // CustomerItem.ID = item.ID;
                                // CustomerItem.Quantity += Selection;
                                // CustomerItem.Name = item.Name;
                                // CustomerItem.Type = item.Type;
                                // CustomerItem.Price = item.Price;
                                ShoppingList.ForEach(d =>
                                {
                                    Console.WriteLine("I'll Add It To Your");
                                    // if (d.ID == item.ID)
                                    // {
                                    //     // item.Quantity += 1;
                                    //     // d.Quantity += 1;
                                    //     d.Quantity += PickedQuantity;
                                    // }
                                    if (d.ID == Selection)
                                    {
                                        Console.WriteLine("Here You Go");
                                        //^^^ this text isnt showing either
                                        // item.Quantity += 1;
                                        // d.Quantity += 1;
                                        d.Quantity += PickedQuantity;
                                    }
                                });
                            }
                            else
                            {
                                // FoodList.ForEach(a =>
                                // {
                                //     if (a.ID == item.ID)
                                //     {
                                //     }
                                // });
                                        // item.Quantity -= 1;
                                        item.Quantity -= PickedQuantity;
                                CustomerItem.ID = item.ID;
                                CustomerItem.Quantity += PickedQuantity;
                                CustomerItem.Name = item.Name;
                                CustomerItem.Type = item.Type;
                                CustomerItem.Price = item.Price;   
                                // CustomerList.Add(new Product(item.ID, Selection, item.Name, item.Type, item.Price));
                                ShoppingList.Add(CustomerItem);
                                Console.WriteLine("NEW ITEM");
                            }
                            // FoodList.ForEach(a => a.Quantity -= 1);
                            //^^ not here
                            // }
                        }

                        Console.WriteLine(item);
                    }
           
                // Console.WriteLine(CustomerItem);
                // item.Quantity = 1;
                // SelectedItem = item;
        // CustomerList.Add(SelectedItem);
    // Console.WriteLine(SelectedItem);
    // List<Product> NewItem = FoodList.ToList();
    Console.WriteLine("==============");
    // ShoppingList.Add(NewItem);
    // ShoppingList.Add(SelectedItem);
    // Console.WriteLine(ShoppingList);
    Console.WriteLine(ShoppingList);
    foreach(var item in ShoppingList){
        Console.WriteLine(item);
    }
   
   
}
public void RemoveFood(int Selection, List<Product> CustomerList){
    //if the name is the same as the customer item than you plus one that items quantity (DONE)
    //substract from quantity if customer has the item or not
    //if customer doenst have the item add the entire item as is
    // var l = product.GetEnumerator().Current.Quantity;
    // var l = product.GetEnumerator().Current.Quantity;

    //      IDEAS
    // create ids for each product and have user put in a number and check if number matches that id
    //^^ than thats their product than look at the quantity subsstract from it
    //^^^ than check to see if user have that whole item, if customer doesnt add whole item
    //^^^^ if they dont add quantity
    Product? SelectedItem = null;
    //   foreach (var item in ShoppingList)
    // //adding to the list
    // {
    //     Product? UpdatedItem = null;
    //     // Console.WriteLine(ShoppingList);
    //     //^^ not showing when nothing is added
    //     if(Selection == item.ID && item.Quantity >= 1){
    //         Console.WriteLine("I Have SOmething in here");
    //         item.Quantity += 1;
    //         UpdatedItem = item;
    //     } else {
    //         Console.WriteLine("I Have Nothing In here");
    //     }
    //         Console.WriteLine(item);
    //     //THE ITEM .... NOT THE LIST
      
    // }
    // List<Product> FoodListTOLIST = FoodList.ToList();
    //^ not sure if its working
  
//   var newlist = FoodList.Select(point => {
//         point.Quantity = 1;
//         return point;
//     }).ToList();
    //^^ works but might be a better way
    
    foreach (var item in FoodList)
    //for the list here
    {
    if(Selection == item.ID){
        if(CustomerList.Contains(item)){
            item.Quantity += 1;
            // SelectedItem = item;
        } else {
        item.Quantity = 1;
        SelectedItem = item;
        Console.WriteLine("NEW ITEM");
        CustomerList.Add(SelectedItem);
        }
        
    } else {
        Console.WriteLine("You Got this item already");
    }
        
    }
    Console.WriteLine(SelectedItem);
    // List<Product> NewItem = FoodList.ToList();
    Console.WriteLine("==============");
    Console.WriteLine(FoodList);
    // ShoppingList.Add(NewItem);
    // ShoppingList.Add(SelectedItem);
    // Console.WriteLine(ShoppingList);
    Console.WriteLine(CustomerList);
    foreach(var item in ShoppingList){
        Console.WriteLine(item);
    }
   
}
        public FoodStoreInventory(){
            FoodItems = new List<Product[]>();
            ShoppingList = new List<Product>();
            //^^ creates a new type of list
        }
        public FoodStoreInventory(List<Product> UserList){
            FoodItems = new List<Product[]>();
            this.ShoppingList = UserList;
            //^^ creates a new type of list
        }
        // public FoodStoreInventory(DateTime date, CustomerChoice customer, StoreInventory inventory){
        //     this.Date = date;
        //     this.Customer = customer;
        //     this.Inventory = inventory;
        // }

        // public CustomerChoice CustomerOrder(){
        //     Random random = new();
        //     return (CustomerChoice)random.Next(3);
        //     //^^ possible for employee to randomly react or make new logic for employee
        // }

        // public decimal CheckOut(){
        public void CheckOut(){
            // string description = "";
            // decimal totalCost = 0;
            // foreach (var item in ShoppingList)
            // {
            //     description = item.Name + " " + item.Type;
            //     totalCost += item.Price;    
            // }
            // // ShoppingList.Clear();
            // //^^ BAD LOGIC
            // return totalCost;
             var CustomerItem = new Product(0, 0, "", "", 0);
              string description = "";
             decimal totalCost = 0;
             foreach (var item in ShoppingList){
                        if (item.Price >= 25.00M){
                            Console.WriteLine("OH MY!! Do You Want A Coupon");
                               var CompareCustomerList = ShoppingList.Exists(x => x.ID == 0);
                            if (CompareCustomerList){
                                Console.WriteLine("See you got dem COokies\n");
                                Console.WriteLine("....Aye Let get a Cookie");
                                // item.Quantity -= 1;
                            }
                            else
                            {
                                Console.WriteLine("NIce Food Selection");
                            }
                            // FoodList.ForEach(a => a.Quantity -= 1);
                            //^^ not here
                            // }
                        }
                        description = item.ToString();
                        //              ^^^^ Product String
                        totalCost = (item.Quantity*item.Price);
                        Console.WriteLine(item);
                    }
           
                // Console.WriteLine(CustomerItem);
                // item.Quantity = 1;
                // SelectedItem = item;
        // CustomerList.Add(SelectedItem);
    // Console.WriteLine(SelectedItem);
    // List<Product> NewItem = FoodList.ToList();
    Console.WriteLine("==============");
    // ShoppingList.Add(NewItem);
    // ShoppingList.Add(SelectedItem);
    // Console.WriteLine(ShoppingList);
    Console.WriteLine(ShoppingList);
    // foreach(var item in ShoppingList){
    //     Console.WriteLine(item);
    // }
        }

    /// <summary>
    ///Overrided ToString() method
    /// CUSTOM FOR FOOD STORE
    /// </summary>

        public override string ToString()
        {
             string Description = "";
            foreach (var item in ShoppingList)
            {
                 Description += "Name: "+item.Name + " " + "Type: " + item.Type+"\n";
                //  Description +="Quantity: "+item.Quantity + "Name: "+item.Name + " " + "Type: " + item.Type+"\n";
                //  ^^ this would be wrong because it will return the total quantity
            }
            ShoppingList.Clear();
            return Description;
        }
         public void IntroDuction(bool BackToStoreMenu){
            
            string? MyName = null;
            
            if(BackToStoreMenu == false){
                Console.WriteLine($"AYE!! What was ya name again? I got short term memory");
                MyName = Console.ReadLine();
                this.CustomerName = MyName;
                Console.WriteLine($"OH!! Welcome {CustomerName}, Here Is Yo' CHoices");
                Console.WriteLine($" 0.\t Back To Main Menu,\n 1.\t {(CustomerChoice)(0)},\n 2.\t {(CustomerChoice)(1)}\n 3.\t {(CustomerChoice)(2)}\n 4.\t {(CustomerChoice)(3)}\n");
            } else {
                Console.WriteLine($"Hey {CustomerName}, Is There Anything Else You Need?");
                Console.WriteLine($" 0.\t Back To Main Menu,\n 1.\t {(CustomerChoice)(0)},\n 2.\t {(CustomerChoice)(1)}\n 3.\t {(CustomerChoice)(2)}\n 4.\t {(CustomerChoice)(3)}\n");
                // MyName = Console.ReadLine();
            }
        
        }
    }
}