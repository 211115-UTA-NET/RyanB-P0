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
    public class FoodStoreInventory : StoreInterface {
        private List<Product[]> FoodItems {get; set;}
        private List<Product> _ShoppingList;
        public List<Product> ShoppingList {get{
            //^^ not the same type
            //^^ so when adding and removing from this list its not correct logic and syntax wise
            return _ShoppingList;
        } set{
            this._ShoppingList = value;
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
        public IEnumerable<Product> FoodList {
            get {
                yield return new Product {ID = 1, Quantity = 1000, Name = "Cookies",  Type="Desserts", Price=10.00M};
                yield return new Product {ID = 2, Quantity = 1000, Name = "Pasta",  Type="carbohydrates", Price=30.00M};
                yield return new Product {ID = 3, Quantity = 1000, Name = "Cake",  Type="Desserts", Price=7.99M};
                yield return new Product {ID = 4, Quantity = 1000, Name = "Dragon Fruit",  Type="Fruit", Price=5.99M};
                yield return new Product {ID = 5, Quantity = 1000, Name = "Waffles",  Type="Breakfast", Price=9.99M};
            }
        }
        // public int NumberOfItems {get{
        //     return FoodList.Count
        // }}
               public void ShowList(){
            var ItemsList = new FoodStoreInventory();
            foreach(Product Item in ItemsList.FoodList){
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
//substract from yield Quantity and add entire object to customer list
//ListName.Count for total Items
//var result = firms.Except(trackedFirms); // returns all the firms except those in trackedFirms

// public void TakeFood(IEnumerable<Product> product, List<Product> CustomerList){
public void TakeFood(int Selection, List<Product> CustomerList){
    //                  ^^^ changing to int or double
    //if the name is the same as the customer item than you plus one that items quantity
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
    foreach (var item in FoodList)
    //for the list here
    {
    // var Selection = product.GetEnumerator().Current.ID;
    // var StoreStock = ShoppingList.GetEnumerator().Current.ID;
    // if(Selection == product)

    // var Selection = Selection.GetEnumerator().Current.ID;
    // var StoreStock = ShoppingList.GetEnumerator().Current.ID;
    
    if(Selection == item.ID){
        SelectedItem = item;
    }
    // Console.WriteLine(item);
        
    }
    Console.WriteLine(SelectedItem);
    // List<Product> NewItem = FoodList.ToList();
    Console.WriteLine("==============");
    // CustomerList.Add(SelectedItem);
    // ShoppingList.Add(NewItem);
    ShoppingList.Add(SelectedItem);
    Console.WriteLine(ShoppingList);
    //  foreach (var item in ShoppingList)
    // //adding to the list
    // {
    //     Console.WriteLine()
    // }
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

        public decimal CheckOut(){
            string description = "";
            decimal totalCost = 0;
            foreach (var item in ShoppingList)
            {
                description = item.Name + " " + item.Type;
                totalCost += item.Price;    
            }
            ShoppingList.Clear();
            return totalCost;
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
    }
}