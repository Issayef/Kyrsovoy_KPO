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
    public partial class BossSuppliesForm : Form
    {
        public BossSuppliesForm()
        {
            InitializeComponent();
            label2.Text = Company.Capital.ToString();
        }
        string path;

        private void open_button_Click(object sender, EventArgs e)  // выбираем заранее сохраненный файл поставки и открываем его в приложении
        {
            dataGridView1.Rows.Clear();   // очищаем dataGridView1 
            dataGridView2.Rows.Clear();    //очищаем dataGridView1 
            DataSet ds = new DataSet();

            System.IO.Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"E:\Поставки";
            openFileDialog1.Filter = "XML File(*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)  // если файл открылся, 
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)   // и он не является пустым, считываем
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
                    dataGridView1.Rows[n].Cells[1].Value = item["UnitsInStock"];
                    dataGridView1.Rows[n].Cells[2].Value = item["UnitPrice"];
                }
                foreach (DataRow item in ds.Tables["Supplies"].Rows) 
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item["CompanyName"].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item["SupplyDate"];
                    dataGridView2.Rows[n].Cells[2].Value = item["TotalPrice"];
                }
            }
        }

        private void accept_button_Click(object sender, EventArgs e)   // одобрить поставку
        {
            string companyname = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            DateTime supplydate = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells[1].Value);
            decimal totalprice = Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[2].Value);
            Suppliess.addSupply(companyname, supplydate, totalprice);
            Company.withdrawal(totalprice);
            label2.Text = Company.Capital.ToString();
            string f2 = Company.Capital.ToString();
            File.WriteAllText("E:\\company.txt", f2);
            int n = dataGridView1.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    string prodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    int units = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    decimal price = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);

                    string name = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    DateTime suppldate = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells[1].Value);
                    Products.updateforSupply(prodName, units, price);
                    using (var db = new TradeDB())
                    {
                        var query = from b in db.Supply
                                    where b.SupplyDate == suppldate && b.CompanyName == name
                                    select b;
                        foreach (var item in query)
                        {
                            int id = item.SupplyID;
                            Suppliess.addSupplyDetails(prodName, units, price, id);
                        }
                    }
                }
            }
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            File.Delete(path);
        }

        private void delete_button_Click(object sender, EventArgs e) // удалить поставку
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            File.Delete(path);
        }

        private void close_button_Click(object sender, EventArgs e)  // выйти из приложения
        {
            Application.Exit();
        }

        private void back_button_Click(object sender, EventArgs e) // закрыть форму
        {
            this.Close();
        }
    }
}
