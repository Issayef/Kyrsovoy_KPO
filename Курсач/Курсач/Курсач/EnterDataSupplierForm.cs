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
    public partial class EnterDataSupplierForm : Form
    {
        public EnterDataSupplierForm()
        {
            InitializeComponent();
        }


        private void save_button_Click(object sender, EventArgs e)
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

            Enterdata.AddSupplier(CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode,
               Country, Phone, Fax);
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
