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
    public partial class StatisticForm : Form
    {
        public TradeDB db = new TradeDB();
        public StatisticForm()
        {
            InitializeComponent();
            ChooseType();
        }
        public void ChooseType()   // выбор статистики которую мы хотим посмотреть(поставки/продажи)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Продажи");
            comboBox1.Items.Add("Поставки");
        }
        public void Sale(DateTime _fromDate, DateTime _toDate)   // вывод данных о продажах
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

        public void Delivery(DateTime _fromDate, DateTime _toDate)  // вывод данных о поставках
        {
            var query = from b in db.Supply
                        where b.SupplyDate > _fromDate && b.SupplyDate < _toDate
                        select b;

            foreach (var item in query)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item.SupplierID;
                dataGridView1.Rows[n].Cells[1].Value = item.CompanyName;
                dataGridView1.Rows[n].Cells[2].Value = item.SupplyDate;
                dataGridView1.Rows[n].Cells[3].Value = item.TotalPrice;
            }
        }
        public void OrderInfo()     // вывод информации об отдельном заказе(продаже/поставке), включая информацию о наименовании товара, количестве и стоимости
        {
            dataGridView2.Rows.Clear();
            if (comboBox1.SelectedItem.ToString() == "Продажи")
            {
                int SelOrderID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var query = from b in db.OrderDetails
                            where b.OrderID == SelOrderID
                            select b;
                foreach (var item in query)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item.ProductName;
                    dataGridView2.Rows[n].Cells[1].Value = item.UnitPrice;
                    dataGridView2.Rows[n].Cells[2].Value = item.Quantity;
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Поставки")
            {
                int SelOrderID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var query = from b in db.SupplyDetails
                            where b.SupplyID == SelOrderID
                            select b;
                foreach (var item in query)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item.ProductName;
                    dataGridView2.Rows[n].Cells[1].Value = item.UnitPrice;
                    dataGridView2.Rows[n].Cells[2].Value = item.Quantity;
                }
            }
        }

        public DateTime StringToDate(string str)  // метод преобразования типа строки в формат DateTime
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

        private void getstat_button_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (radioButton3.Checked)   // статистика за период который мы указали
            {
                if (textBox1.Text != "" && textBox2.Text != "")  // проверка введены ли данные временного интервала
                {
                    using (var db = new TradeDB())
                    {

                        DateTime _fromDate = StringToDate(textBox1.Text);
                        DateTime _toDate = StringToDate(textBox2.Text);

                        if (_fromDate < _toDate)      // проверка того, чтобы начальная дата не превышала конечную
                        {

                            if (comboBox1.SelectedItem.ToString() == "Продажи")
                            {
                                Sale(_fromDate, _toDate);
                            }

                            if (comboBox1.SelectedItem.ToString() == "Поставки")
                            {
                                Delivery(_fromDate, _toDate);
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
            if (radioButton1.Checked)    //статистика за последний месяц
            {
                DateTime _fromDate = DateTime.Now.AddMonths(-1); ; 
                DateTime _toDate = DateTime.Now;

                if (_fromDate < _toDate)  // проверка того, чтобы начальная дата не превышала конечную
                {

                    if (comboBox1.SelectedItem.ToString() == "Продажи")
                    {
                        Sale(_fromDate, _toDate);
                    }

                    if (comboBox1.SelectedItem.ToString() == "Поставки")
                    {
                        Delivery(_fromDate, _toDate);
                    }
                }
            }
            if (radioButton2.Checked)     // статистика за последний год
            {
                DateTime _fromDate = DateTime.Now.AddYears(-1); 
                DateTime _toDate = DateTime.Now;

                if (_fromDate < _toDate)   // проверка того, чтобы начальная дата не превышала конечную
                {
                    if (comboBox1.SelectedItem.ToString() == "Продажи")
                    {
                        Sale(_fromDate, _toDate);
                    }

                    if (comboBox1.SelectedItem.ToString() == "Поставки")
                    {
                        Delivery(_fromDate, _toDate);
                    }
                }
            }
        }

        private void info_button_Click(object sender, EventArgs e)
        {
            OrderInfo();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
