using KyrsovKpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Курсач
{
    public partial class EnterDataForm : Form
    {
        public EnterDataForm()
        {
            InitializeComponent();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new TradeDB())
            {
                Customers cust = new Customers
                {

                    //CompanyName = textBox1.Text.ToString(),
                    ContactName = "Александр Ерохин",
                    ContactTitle = "Owner",
                    Address = "1017 Maple Leaf",
                    City = "Moscow",
                    Region = "MC",
                    PostalCode = "555555",
                    Country = "Russia",
                    Phone = "+7(800)123-4567",
                    Fax = "None"
                };
                // 3. Добавление сущностного объекта в таблицу Customers
                db.Customers.Add(cust);

                // 4. Вызов метода SaveChanges
                db.SaveChanges();
               
            }
        }
        
    }
}
