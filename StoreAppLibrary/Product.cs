using System.Text;
namespace StoreAppLibrary.Logic {
    /// <summary>
    ///This is for making a broad selection of products.
    /// Can be specified to any product.
    /// </summary>

    public class Product {
        internal string? Name {get; set;}
        internal string? Type {get; set;}
        internal decimal Price {get; set;}

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

        public override string ToString()
        {
            // return base.ToString();
            return "Name: "+Name+" Type: "+Type+" Price: "+Price;
        }
    }
}