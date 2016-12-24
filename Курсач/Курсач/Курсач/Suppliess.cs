using KyrsovKpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    class Suppliess
    {
        internal static void addSupply(string name, DateTime supplydate, decimal price)
        {
            using (var db = new TradeDB())
            {
                Supply supply = new Supply
                {

                    CompanyName = name,
                    SupplyDate = supplydate,
                    TotalPrice = price
                };
                // 3. Добавление сущностного объекта в таблицу Customers
                db.Supply.Add(supply);
                // 4. Вызов метода SaveChanges
                db.SaveChanges();

            }
        }
        internal static void addSupplyDetails(string prodName, int units, decimal price, int id)
        {
            using (var db = new TradeDB())
            {
                SupplyDetails ord = new SupplyDetails
                {
                    SupplyID = id,
                    ProductName = prodName,
                    Quantity = (short)units,
                    UnitPrice = price
                };
                // 3. Добавление сущностного объекта в таблицу Customers
                db.SupplyDetails.Add(ord);
                // 4. Вызов метода SaveChanges
                db.SaveChanges();

            }
        }
    }
}
