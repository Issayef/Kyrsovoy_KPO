﻿using KyrsovKpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    class Orderr
    {
        internal static int GetFree(int OnStock,int onOrder)
        {
            return OnStock - onOrder;
        }
        internal static void addOrder(string name,DateTime ordate, DateTime req, decimal price) {
            using (var db = new TradeDB())
            {
                Orders ord = new Orders
                {

                    ShipName = name,
                    OrderDate = ordate,
                    RequiredDate = req,
                    TotalPrice=price
                };
                // 3. Добавление сущностного объекта в таблицу Customers
                db.Orders.Add(ord);
                // 4. Вызов метода SaveChanges
                db.SaveChanges();

            }
        }
        internal static void addOrderDetails(string prodName, int units, decimal price,int id)
        {
            using (var db = new TradeDB())
            {
                OrderDetails ord = new OrderDetails
                {
                    OrderID= id,
                    ProductName = prodName,
                    Quantity = (short)units,
                    UnitPrice = price
                };
                // 3. Добавление сущностного объекта в таблицу Customers
                db.OrderDetails.Add(ord);
                // 4. Вызов метода SaveChanges
                db.SaveChanges();

            }
        }


    }
}
