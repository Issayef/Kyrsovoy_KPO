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
    public partial class MakeDealForm : Form
    {
        public MakeDealForm()
        {
            InitializeComponent();
            InitializeListBox();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Application.Exit();
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
                                where b.CategoryID == 1
                                select b;
                    foreach (var item in query)
                    {
                        listBox2.Items.Add(item.ProductName);
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
                        listBox2.Items.Add(item.ProductName);
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
                        listBox2.Items.Add(item.ProductName);
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
                        listBox2.Items.Add(item.ProductName);
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
                        listBox2.Items.Add(item.ProductName);
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
                        listBox2.Items.Add(item.ProductName);
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
                        listBox2.Items.Add(item.ProductName);
                    }

                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            string s = listBox2.SelectedItem.ToString();
            using (var db = new TradeDB())
            {
                var query = from b in db.Products
                            where b.ProductName == s
                            select b;
                foreach (var item in query)
                {
                    textBox1.Text = item.UnitsInStock.ToString();
                    textBox2.Text = item.UnitPrice.ToString();
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
            //var column1 = new DataGridViewTextBoxColumn();
            //var column2 = new DataGridViewCheckBoxColumn();
            //var column3 = new DataGridViewCheckBoxColumn();
            //column1.HeaderText = "Столбец1"; column1.Name = "Column1";
            //column2.HeaderText = "Столбец2"; column2.Name = "Column2";
            //column3.HeaderText = "Столбец3"; column2.Name = "Column3";
            //dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2,column3 });

            int n=dataGridView1.Rows.Add();
            string s= listBox2.SelectedItem.ToString();
            dataGridView1.Rows[n].Cells[0].Value = s;
            dataGridView1.Rows[n].Cells[1].Value = textBox1.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBox2.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Заказ";
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Количество");
            dt.Columns.Add("Стоимость");
            ds.Tables.Add(dt);

            foreach (DataGridViewRow r in dataGridView1.Rows) {
                DataRow row = ds.Tables["Заказ"].NewRow();
                if (r.Cells[0].Value != null)
                {
                    row["Наименование"] = r.Cells[0].Value.ToString();
                    row["Количество"] = r.Cells[1].Value.ToString();
                    row["Стоимость"] = r.Cells[2].Value.ToString();
                    ds.Tables["Заказ"].Rows.Add(row);
                }
                
            }
            ds.WriteXml("E:\\Data.xml");
            
        }
    }
}
