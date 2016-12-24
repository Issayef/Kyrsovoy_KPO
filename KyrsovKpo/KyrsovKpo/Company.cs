using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsovKpo
{
    public class Company
    {
        private string CompanyName= "Progers";
        static string s=File.ReadAllText("E:\\company.txt");
        public static decimal Capital = Convert.ToDecimal(s);



        public Company(string name, decimal capital)
        {
            CompanyName = name;
            Capital = capital;
        }
        public String getInfo()
        {
            return String.Format("CompanyName: " + CompanyName + "; Capital left: " + Capital);
        }
        public static void deposit(decimal money)
        {
            if (money < 0)
                MessageBox.Show("Разрешена только положительная сумма");
		else
		Capital += money;
        }
        //списание денег фирмы
        public static void withdrawal(decimal money)
        {
            if (money < 0)
                MessageBox.Show("Разрешена только положительная сумма");
            if (Capital > money)
                Capital -= money;
            else
                MessageBox.Show("У фирмы не достаточно денег для проведения операции");
        }
    }
}
