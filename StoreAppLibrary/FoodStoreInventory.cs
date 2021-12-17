namespace StoreAppLibrary.Logic {
    public class FoodStoreInventory : StoreInterface {
        private List<Product[]> FoodItems {get; set;}
        private List<Product> _ShoppingList;
        public List<Product> ShoppingList {get{
            return _ShoppingList;
        } set{
            this._ShoppingList = value;
        }}
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
            }
            ShoppingList.Clear();
            return Description;
        }
    }
}