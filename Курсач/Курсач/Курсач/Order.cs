using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    class Order
    {
        internal static int GetFree(int OnStock,int onOrder)
        {
            return OnStock - onOrder;
        }
        
    }
}
