namespace StoreAppLibrary.Logic {
    public class Product {
        private string? Name {get; set;}
        private string? Type {get; set;}
        public decimal Price {get; set;}

        public Product() {
            Name = "Nuclear Waste";
            Type = "Liquid";
            Price = 0.00M;
        } 

        public Product(string name, string type, decimal price){
            Name = name;
            Type = type;
            Price = price;
        }
    }
}