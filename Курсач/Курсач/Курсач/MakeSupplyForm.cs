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
    public partial class MakeSupplyForm : Form
    {
        public MakeSupplyForm()
        {
            InitializeComponent();
            InitializeListBox();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
        }
        public double total = 0;
        void InitializeListBox()   //Добавление категории товара в ListBox1
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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //Добавление товаров в выбранной категории
        {
            int Selected = listBox1.SelectedIndex; // переменная для выбранного товара в listBox1
            if (Selected == 0) // выводит в listBox2 все товары из категории[0] выбранный в listBox1
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)  //Цена за единицу товара
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
                    textBox2.Text = item.UnitPrice.ToString();
                }
            }
        }
        void getPrice()         // метод расчета цены при добавлении товара
        {
            int n = dataGridView1.Rows.Count;
            int count;
            double price;
            count = Convert.ToInt32(dataGridView1.Rows[n - 2].Cells[1].Value);
            price = Convert.ToDouble(dataGridView1.Rows[n - 2].Cells[2].Value);
            total = total + count * price;
            label3.Text = total.ToString();
        }
        void editPrice()   // метод расчета цены при изменении количества товара
        {
            int n = dataGridView1.Rows.Count;
            int count;
            double price;
            count = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            price = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
            total = total + count * price;
            label3.Text = total.ToString();
        }
        void deletePrice()     // метод расчета цены при удалении товара
        {
            int n = dataGridView1.Rows.Count;
            int count;
            double price;
            count = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            price = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
            total = total - count * price;
            label3.Text = total.ToString();
        }
        private void add_button_Click(object sender, EventArgs e)   // добавить товар к заказу
        {
            int n = dataGridView1.Rows.Add();
            string s = listBox2.SelectedItem.ToString();
            dataGridView1.Rows[n].Cells[0].Value = s;
            dataGridView1.Rows[n].Cells[1].Value = textBox1.Text.ToString();
            dataGridView1.Rows[n].Cells[2].Value = textBox2.Text.ToString();
            getPrice();
        }

        private void edit_button_Click(object sender, EventArgs e)   // изменение количества товара
        {
            deletePrice();
            dataGridView1.SelectedRows[0].Cells[1].Value = textBox1.Text;
            editPrice();
        }

        private void delete_button_Click(object sender, EventArgs e)   // удалить выбранный товар из заказа
        {
            deletePrice();
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }

        private void save_button_Click(object sender, EventArgs e) // сохранить поставку
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Products";
            dt.Columns.Add("ProductName");
            dt.Columns.Add("UnitsInStock");
            dt.Columns.Add("UnitPrice");
            ds.Tables.Add(dt);

            DataTable dt1 = new DataTable();
            dt1.TableName = "Supplies";
            dt1.Columns.Add("CompanyName");
            dt1.Columns.Add("SupplyDate");
            dt1.Columns.Add("TotalPrice");
            ds.Tables.Add(dt1);

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row = ds.Tables["Products"].NewRow();
                if (r.Cells[0].Value != null)
                {
                    row["ProductName"] = r.Cells[0].Value.ToString();
                    row["UnitsInStock"] = r.Cells[1].Value.ToString();
                    row["UnitPrice"] = r.Cells[2].Value.ToString();
                    ds.Tables["Products"].Rows.Add(row);
                }

            }
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                DataRow row = ds.Tables["Supplies"].NewRow();
                if (r.Cells[0].Value != null)
                {
                    row["CompanyName"] = r.Cells[0].Value.ToString();
                    row["SupplyDate"] = r.Cells[1].Value.ToString();
                    row["TotalPrice"] = r.Cells[2].Value.ToString();
                    ds.Tables["Supplies"].Rows.Add(row);
                }

            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"E:\Поставки";
            saveFileDialog1.Filter = "XML File|*.xml";
            saveFileDialog1.Title = "Save an XML File";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                ds.WriteXml(fileName);
            }
        }

        private void back_button_Click(object sender, EventArgs e)  // закрыть форму
        {
            this.Close();
        }

        private void add_button1_Click(object sender, EventArgs e)   // добавляет данные о поставке в dataGridView2
        {
            int n1 = dataGridView2.Rows.Add();
            dataGridView2.Rows[n1].Cells[0].Value = textBox3.Text;
            dataGridView2.Rows[n1].Cells[1].Value = DateTime.Now;
            dataGridView2.Rows[n1].Cells[2].Value = label3.Text;
        }

        private void close_button_Click(object sender, EventArgs e) // закрыть приложение
        {
            Application.Exit();
        }
    }
}
