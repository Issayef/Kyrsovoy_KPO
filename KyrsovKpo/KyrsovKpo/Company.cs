using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsovKpo
{
    public class Company
    {
        private string CompanyName;
        private double Capital;

        public Company()
        {
            CompanyName = "";
            Capital = 15000;
        }
        public Company(string name, double capital)
        {
            CompanyName = name;
            Capital = capital;
        }
        public String getInfo()
        {
            return String.Format("CompanyName: " + CompanyName + "; Capital left: " + Capital);
        }
        void deposit(double money)
        {
            if (money < 0)
                MessageBox.Show("Разрешена только положительная сумма");
		else
		Capital += money;
        }
        //списание денег фирмы
        void withdrawal(double money)
        {
            if (money < 0)
                MessageBox.Show("Разрешена только положительная сумма");
            if (Capital > money)
                Capital -= money;
            else
                MessageBox.Show("У фирмы не достаточно денег для проведения операции");
        }
        public void calculateTotalPrice()
        {

        }
        public void showStatictic() { }


    }
}
