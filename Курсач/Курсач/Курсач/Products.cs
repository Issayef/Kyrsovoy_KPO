using KyrsovKpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    class Products
    {
        internal static void updProduct(string prodName, int units, decimal price)
        {
            using (var db = new TradeDB())
            {
                
                var cust = db.Products.Where(x => x.ProductName == prodName).FirstOrDefault();
                cust.ProductName = prodName;
                cust.UnitsOnOrder = cust.UnitsOnOrder+units;
                cust.UnitsInStock = cust.UnitsInStock-units;
                cust.PriceForSale = price;  
                // 4. Вызов метода SaveChanges
                db.SaveChanges();

            }
        }
        internal static void updateforSupply(string prodName, int units, decimal price)
        {
            using (var db = new TradeDB())
            {

                var cust = db.Products.Where(x => x.ProductName == prodName).FirstOrDefault();
                cust.ProductName = prodName;
                cust.UnitsInStock = cust.UnitsInStock+units;
                cust.PriceForSale = price * 1.2m;
                cust.UnitPrice = price;
                // 4. Вызов метода SaveChanges
                db.SaveChanges();

            }
        }
    }
}
