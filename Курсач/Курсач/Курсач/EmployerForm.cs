using KyrsovKpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class EmployerForm : Form
    {
        public EmployerForm()
        {
            InitializeComponent();
            label2.Text = Company.Capital.ToString();
        }
        string path;
        private void button3_Click(object sender, EventArgs e) // открытие проводника для выбора имеющихся заказов
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            DataSet ds = new DataSet();

            System.IO.Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"E:\Заказы";
            openFileDialog1.Filter = "XML File(*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            path = openFileDialog1.FileName;
                            string fileName = openFileDialog1.FileName;
                            ds.ReadXml(fileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }


                foreach (DataRow item in ds.Tables["Products"].Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["ProductName"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["UnitsOnOrder"];
                    dataGridView1.Rows[n].Cells[2].Value = item["PriceForSale"];
                }
                foreach (DataRow item in ds.Tables["Orders"].Rows)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item["ShipName"].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item["OrderDate"];
                    dataGridView2.Rows[n].Cells[2].Value = item["RequiredDate"];
                    dataGridView2.Rows[n].Cells[3].Value = item["TotalPrice"];
                }
            }

            
        }

        private void button4_Click(object sender, EventArgs e)  // принятие заказа
        {
            string companyname = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            DateTime orderdate = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells[1].Value);
            DateTime reqdate = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells[2].Value);
            decimal totalprice = Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[3].Value);
            Orderr.addOrder(companyname, orderdate, reqdate, totalprice);
            Company.deposit(totalprice);
            label2.Text = Company.Capital.ToString();
            string f2 = Company.Capital.ToString();
            File.WriteAllText("E:\\company.txt", f2);
            int n = dataGridView1.Rows.Count;
            for (int i = 0;i< n;i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null) // проверка условия ненулевой строки
                {
                    string prodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    int units = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    decimal price = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);

                    string name = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    DateTime ordate = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells[1].Value);
                    Products.updProduct(prodName, units, price);
                    using (var db = new TradeDB())
                    {
                        var query = from b in db.Orders
                                    where b.OrderDate == ordate && b.ShipName == name
                                    select b;
                        foreach (var item in query)
                        {
                            int id = item.OrderID;
                            Orderr.addOrderDetails(prodName, units, price, id);
                        }
                    }
                }
            }
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            File.Delete(path);

        }

        private void close_button_Click(object sender, EventArgs e) // закрыть приложение
        {
            Application.Exit();
        }

        private void back_button_Click(object sender, EventArgs e) // выйти из профиля для повторной инициализации пользователя
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();

        }

        private void delete_button_Click(object sender, EventArgs e)  // удалить заказ
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            File.Delete(path);
        }

        private void button1_Click(object sender, EventArgs e)     // количество товара на складе
        {
            string s = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            using (var db = new TradeDB())
            {
                var query = from b in db.Products
                            where b.ProductName == s
                            select b;
                foreach (var item in query)
                {
                    label4.Text =item.UnitsInStock.ToString();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
