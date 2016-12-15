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
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
            InitializeListBox();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Selected = listBox1.SelectedIndex;
            if (Selected == 0)
            {
                listBox2.Items.Clear();
                using (var db = new TradeDB())
                {
                    var query = from b in db.Products
                                where b.CategoryID==1
                                select b;
                    foreach (var item in query)
                    {
                        listBox2.Items.Add(item.ProductName+"-"+item.UnitsInStock);
                    }
                    
                }
            }
            if (Selected == 1)
            {
                listBox2.Items.Clear();
                using (var db = new TradeDB())
                {
                    var query = from b in db.Products
                                where b.CategoryID == 2
                                select b;
                    foreach (var item in query)
                    {
                        listBox2.Items.Add(item.ProductName + "-" + item.UnitsInStock);
                    }

                }
            }
            if (Selected == 2)
            {
                listBox2.Items.Clear();
                using (var db = new TradeDB())
                {
                    var query = from b in db.Products
                                where b.CategoryID == 1002
                                select b;
                    foreach (var item in query)
                    {
                        listBox2.Items.Add(item.ProductName + "-" + item.UnitsInStock);
                    }

                }
            }
            if (Selected == 3)
            {
                listBox2.Items.Clear();
                using (var db = new TradeDB())
                {
                    var query = from b in db.Products
                                where b.CategoryID == 1003
                                select b;
                    foreach (var item in query)
                    {
                        listBox2.Items.Add(item.ProductName + "-" + item.UnitsInStock);
                    }

                }
            }
            if (Selected == 4)
            {
                listBox2.Items.Clear();
                using (var db = new TradeDB())
                {
                    var query = from b in db.Products
                                where b.CategoryID == 1009
                                select b;
                    foreach (var item in query)
                    {
                        listBox2.Items.Add(item.ProductName + "-" + item.UnitsInStock);
                    }

                }
            }
            if (Selected == 5)
            {
                listBox2.Items.Clear();
                using (var db = new TradeDB())
                {
                    var query = from b in db.Products
                                where b.CategoryID == 1010
                                select b;
                    foreach (var item in query)
                    {
                        listBox2.Items.Add(item.ProductName + "-" + item.UnitsInStock);
                    }

                }
            }
            if (Selected == 6)
            {
                listBox2.Items.Clear();
                using (var db = new TradeDB())
                {
                    var query = from b in db.Products
                                where b.CategoryID == 1012
                                select b;
                    foreach (var item in query)
                    {
                        listBox2.Items.Add(item.ProductName + "-" + item.UnitsInStock);
                    }

                }
            }
        }

        void InitializeListBox()
        {
            using (var db = new TradeDB())
            {
                var query = from b in db.Categories
                            select b;
                foreach (var item in query)
                {
                    listBox1.Items.Add(item.CategoryName);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
