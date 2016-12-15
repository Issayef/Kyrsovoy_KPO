using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyrsovKpo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TradeDB())
            {
                
                // Display all Blogs from the database 
                var query = from b in db.Products
                            orderby b.ProductName
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.ProductName);
                }
                Console.WriteLine();
                
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
