using KyrsovKpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    class Enterdata
    {
       
        internal static void Addcustomer(string comName,string CN, string T, string adr, string city, string reg, string post,
            string country,string phone, string fax)
        {
            using (var db = new TradeDB())
            {
                Customers cust = new Customers
                {
                    
                    CompanyName = comName,
                    ContactName = CN,
                    ContactTitle = T,
                    Address = adr,
                    City = city,
                    Region = reg,
                    PostalCode = post,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };
                // 3. Добавление сущностного объекта в таблицу Customers
                db.Customers.Add(cust);
                // 4. Вызов метода SaveChanges
                db.SaveChanges();
                
            }
        }

        internal static void AddSupplier(string comName, string CN, string T, string adr, string city, string reg, string post,
            string country, string phone, string fax)
        {
            using (var db = new TradeDB())
            {
                Suppliers supplier = new Suppliers
                {

                    CompanyName = comName,
                    ContactName = CN,
                    ContactTitle = T,
                    Address = adr,
                    City = city,
                    Region = reg,
                    PostalCode = post,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };
                // 3. Добавление сущностного объекта в таблицу Customers
                db.Suppliers.Add(supplier);
                // 4. Вызов метода SaveChanges
                db.SaveChanges();

            }
        }

    }
}
