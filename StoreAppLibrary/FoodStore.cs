namespace StoreAppLibrary.Logic{
    public class FoodStore {
        private CustomerChoice Customer { get; }
        private StoreInventory Inventory { get; }

        /*
            could make properties that make up a product here
        */
        // private List<Product>? FoodItems {get; set;}
        //^^ using the interface instead of putting it here
        // private List<Product>? ShoppingList {get; set;}
        //^^ using the interface instead of putting it here
        //^^ 
        private DateTime Date { get; }
        // public TransactionResult Result => ConfirmTransaction(Customer, Inventory);
        //^^ old one
        public TransactionResult Result => ConfirmTransaction(Customer);
        // public FoodStore(){
        //     FoodItems = new List<Product>();
        //     ShoppingList = new List<Product>();
        //     //^^ creates a new type of list
        // }
        //^^ using the interface instead of putting it here
        // public FoodStore(DateTime date, CustomerChoice customer, StoreInventory inventory){
        //     this.Date = date;
        //     this.Customer = customer;
        //     this.Inventory = inventory;
        // }
        //^^ old one
        public FoodStore(DateTime date, CustomerChoice customer){
            this.Date = date;
            this.Customer = customer;
            // this.Inventory = inventory;
        }

        // private static TransactionResult ConfirmTransaction(CustomerChoice Customer, StoreInventory Inventory){
        //     return (Customer, Inventory) switch {
        //         (CustomerChoice.Buy, StoreInventory.Money) => TransactionResult.Confirmed,
        //         (CustomerChoice.Complain, StoreInventory.Products) => TransactionResult.Deined,
        //         (CustomerChoice.Sell, StoreInventory.Money) => TransactionResult.Return,
        //         _ => throw new InvalidOperationException(),
        //     };
        // }
        private static TransactionResult ConfirmTransaction(CustomerChoice Customer){
            return (Customer) switch {
                (CustomerChoice.Buy) => TransactionResult.Confirmed,
                (CustomerChoice.Complain) => TransactionResult.Deined,
                (CustomerChoice.Sell) => TransactionResult.Return,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}