using KyrsovKpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
            ChooseGood();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void ChooseGood()
        {
            comboBox1.Items.Clear();


            using (var db = new TradeDB())
            {
                var query = from b in db.Categories
                            select b;

                foreach (var item in query)
                {
                    comboBox1.Items.Add(item.CategoryName);
                }

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                using (var db = new TradeDB())
                {

                    DateTime _fromDate = StringToDate(textBox1.Text);
                    DateTime _toDate = StringToDate(textBox2.Text);

                    if (_fromDate < _toDate)
                    {
                        if (radioButton2.Checked)
                        {
                            var query = from b in db.Orders
                                        where b.OrderDate > _fromDate && b.OrderDate < _toDate
                                        select b;
                            foreach (var item in query)
                            {
                                int n = dataGridView1.Rows.Add();
                                dataGridView1.Rows[n].Cells[0].Value = item.OrderID;
                                dataGridView1.Rows[n].Cells[1].Value = item.ShipName;
                                dataGridView1.Rows[n].Cells[2].Value = item.OrderDate;
                                dataGridView1.Rows[n].Cells[3].Value = item.TotalPrice;
                            }
                        }
                        if (radioButton1.Checked)
                        {
                            var query = from b in db.Suppliers
                                      //  where b.Order > _fromDate && b.OrderDate < _toDate
                                        select b;
                            foreach (var item in query)
                            {
                                int n = dataGridView1.Rows.Add();
                                dataGridView1.Rows[n].Cells[0].Value = item.SupplierID;
                                dataGridView1.Rows[n].Cells[1].Value = item.CompanyName;
                                dataGridView1.Rows[n].Cells[2].Value = item.Phone;
                                dataGridView1.Rows[n].Cells[3].Value = item.Fax;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Начальная дата не может быть больше конечной!");
                    }
                }

            }
            else
            {
                MessageBox.Show("Введите временные данные!");
            }    
        }

        public DateTime StringToDate(string str)
        {
            int[] date1 = new int[3];
            string[] split = str.Split('.');
            int i = 0;
            foreach (string item in split)
            {
                date1[i] = int.Parse(item);
                i++;
            }
            DateTime Date = new DateTime(date1[2], date1[1], date1[0]);
            return Date;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
