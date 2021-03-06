﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Курсач
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // кнопка авторизации
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = @"Data Source = tcp: 85.143.78.47; Initial Catalog = TradeDB; User ID = Pavel; Password = 12345";
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Loginn where UserName = '" + textBox1.Text + "'and Password = '" + textBox2.Text + "'", myCon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (radioButton1.Checked)
                {
                    this.Hide();
                    BossForm _bossForm = new BossForm();
                    _bossForm.ShowDialog();
                }
                if (radioButton2.Checked)
                {
                    this.Hide();
                    EmployerForm _employerForm = new EmployerForm();
                    _employerForm.ShowDialog();
                }
                if (radioButton3.Checked)
                {
                    this.Hide();
                    CustomerForm _customerForm = new CustomerForm();
                    _customerForm.ShowDialog();
                }
                if (radioButton4.Checked)
                {
                    this.Hide();
                    SupplierForm _supplierForm = new SupplierForm();
                    _supplierForm.ShowDialog();
                }

            }
            else
            if (dt.Rows[0][0].ToString() == "2")
            {
                if (radioButton1.Checked)
                {
                    this.Hide();
                    BossForm _bossForm = new BossForm();
                    _bossForm.ShowDialog();
                }
                if (radioButton2.Checked)
                {
                    this.Hide();
                    EmployerForm _employerForm = new EmployerForm();
                    _employerForm.ShowDialog();
                }
                if (radioButton3.Checked)
                {
                    this.Hide();
                    CustomerForm _customerForm = new CustomerForm();
                    _customerForm.ShowDialog();
                }
                if (radioButton4.Checked)
                {
                    this.Hide();
                    SupplierForm _supplierForm = new SupplierForm();
                    _supplierForm.ShowDialog();
                }
            }
            else
            if (dt.Rows[0][0].ToString() == "3")
            {
                if (radioButton1.Checked)
                {
                    this.Hide();
                    BossForm _bossForm = new BossForm();
                    _bossForm.ShowDialog();
                }
                if (radioButton2.Checked)
                {
                    this.Hide();
                    EmployerForm _employerForm = new EmployerForm();
                    _employerForm.ShowDialog();
                }
                if (radioButton3.Checked)
                {
                    this.Hide();
                    CustomerForm _customerForm = new CustomerForm();
                    _customerForm.ShowDialog();
                }
                if (radioButton4.Checked)
                {
                    this.Hide();
                    SupplierForm _supplierForm = new SupplierForm();
                    _supplierForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Введен неправильный логин или пароль!");
                textBox1.Clear();
                textBox2.Clear();
            }
            
        }

        private void button2_Click(object sender, EventArgs e) // закрыть приложение
        {
            Application.Exit();
        }

        
    }
}
