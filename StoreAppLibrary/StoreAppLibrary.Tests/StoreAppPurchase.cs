using System;
using Xunit;
using Xunit.Sdk;

namespace StoreAppLibrary.Tests{
    class StoreAppPurchase{
        public void OrderHistoryTest_WriteOrder(){
            var xml = new App.Serialization.Receipt{
                CustomerName = "walldo",
                CustomerProduct = "Cake",
                ProductPrice = 40.00,
            };
            try{
               var Order = xml.CreateOrder();
            }
            catch (ArgumentException)
            {
                
                return null;
            }
            throw new XunitException("expected an ArgumentException");
        }
        
    }
}