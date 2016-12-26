using KyrsovKpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class CatalogForm : Form
    {
        public CatalogForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var db = new TradeDB())
            {
                var query = from b in db.Customers
                            select b;
                foreach (var item in query)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item.CustomerID;
                    dataGridView1.Rows[n].Cells[1].Value = item.CompanyName;
                    dataGridView1.Rows[n].Cells[2].Value = item.ContactName;
                    dataGridView1.Rows[n].Cells[3].Value = item.ContactTitle;
                    dataGridView1.Rows[n].Cells[4].Value = item.Country;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var db = new TradeDB())
            {
                var query = from b in db.Suppliers
                            select b;
                foreach (var item in query)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item.SupplierID;
                    dataGridView1.Rows[n].Cells[1].Value = item.CompanyName;
                    dataGridView1.Rows[n].Cells[2].Value = item.ContactName;
                    dataGridView1.Rows[n].Cells[3].Value = item.ContactTitle;
                    dataGridView1.Rows[n].Cells[4].Value = item.Country;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
