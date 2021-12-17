namespace StoreAppLibrary.Logic {
    public class FoodStoreInventory : StoreInterface {
        private List<Product> FoodItems {get; set;}
        public List<Product> ShoppingList {get; set;}
        public FoodStoreInventory(){
            FoodItems = new List<Product>();
            ShoppingList = new List<Product>();
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
            decimal totalCost = 0;
            foreach (var item in ShoppingList)
            {
                totalCost += item.Price;    
            }
            ShoppingList.Clear();
            return totalCost;
        }
    }
}