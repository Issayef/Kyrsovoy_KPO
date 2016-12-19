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
                    label9.Text = item.UnitsInStock.ToString();
                    textBox2.Text = item.UnitPrice.ToString();
                    label11.Text = (item.UnitsInStock-item.UnitsOnOrder).ToString();
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
            int n=dataGridView1.Rows.Add();
            string s= listBox2.SelectedItem.ToString();
            dataGridView1.Rows[n].Cells[0].Value = s;
            dataGridView1.Rows[n].Cells[1].Value = textBox1.Text.ToString();
            dataGridView1.Rows[n].Cells[2].Value = textBox2.Text.ToString();
            getPrice();
            
        }

        public double total = 0;
        void getPrice()
        {
            //int n = dataGridView1.Rows.Add();
            int n = dataGridView1.Rows.Count;
            int count;
            double price;
            count = Convert.ToInt32(dataGridView1.Rows[n-2].Cells[1].Value);
            price = Convert.ToDouble(dataGridView1.Rows[n-2].Cells[2].Value);
            total = total + count * price;
            label3.Text = total.ToString();
        }
        void editPrice()
        {
            //int n = dataGridView1.Rows.Add();
            int n = dataGridView1.Rows.Count;
            int count;
            double price;
            count = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            price = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
            total = total + count * price;
            label3.Text = total.ToString();
        }
        void deletePrice()
        {
            //int n = dataGridView1.Rows.Add();
            int n = dataGridView1.Rows.Count;
            int count;
            double price;
            count = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            price = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
            total = total - count * price;
            label3.Text = total.ToString();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Products";
            dt.Columns.Add("ProductName");
            dt.Columns.Add("UnitsOnOrder");
            dt.Columns.Add("UnitPrice");
            ds.Tables.Add(dt);

            DataTable dt1 = new DataTable();
            dt1.TableName = "Orders";
            dt1.Columns.Add("ShipName");
            dt1.Columns.Add("OrderDate");
            dt1.Columns.Add("RequiredDate");
            ds.Tables.Add(dt1);

            foreach (DataGridViewRow r in dataGridView1.Rows) {
                DataRow row = ds.Tables["Products"].NewRow();
                if (r.Cells[0].Value != null)
                {
                    row["ProductName"] = r.Cells[0].Value.ToString();
                    row["UnitsOnOrder"] = r.Cells[1].Value.ToString();
                    row["UnitPrice"] = r.Cells[2].Value.ToString();
                    ds.Tables["Products"].Rows.Add(row);
                }
                
            }
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                DataRow row = ds.Tables["Orders"].NewRow();
                if (r.Cells[0].Value != null)
                {
                    row["ShipName"] = r.Cells[0].Value.ToString();
                    row["OrderDate"] = r.Cells[1].Value.ToString();
                    row["RequiredDate"] = r.Cells[2].Value.ToString();
                    ds.Tables["Orders"].Rows.Add(row);
                }

            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML File|*.xml";
            saveFileDialog1.Title = "Save an XML File";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                ds.WriteXml(fileName);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("E:\\Data.xml");
            foreach (DataRow item in ds.Tables["Products"].Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["UnitsOnOrder"];
                dataGridView1.Rows[n].Cells[2].Value = item["UnitPrice"];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deletePrice();
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deletePrice();
            dataGridView1.SelectedRows[0].Cells[1].Value = textBox1.Text;
            editPrice();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int n1 = dataGridView2.Rows.Add();
            dataGridView2.Rows[n1].Cells[0].Value = textBox3.Text;
            dataGridView2.Rows[n1].Cells[1].Value = DateTime.Now;
            dataGridView2.Rows[n1].Cells[2].Value = DateTime.Now.AddDays(7);
        }
    }
}
