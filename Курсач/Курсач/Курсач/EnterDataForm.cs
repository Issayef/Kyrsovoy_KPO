using KyrsovKpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CompanyName = textBox1.Text;
            string ContactName = textBox2.Text;
            string ContactTitle = textBox3.Text;
            string Address = textBox4.Text;
            string City = textBox5.Text;
            string Region = textBox6.Text;
            string PostalCode = textBox7.Text;
            string Country = textBox8.Text;
            string Phone = textBox9.Text;
            string Fax = textBox10.Text;

            AddCustomer.Addcustomer(CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode,
               Country, Phone, Fax);
            MessageBox.Show("Данные успешно сохранены!");

        }
        
    }
}
