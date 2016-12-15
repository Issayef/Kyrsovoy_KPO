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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public CustomerForm _customerForm;
        public MakeDealForm _supplyerForm;
        public BossForm _bossForm;


        private void button3_Click(object sender, EventArgs e)
        {
            _customerForm=new CustomerForm();
            _customerForm.Owner=this;
            _customerForm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _bossForm = new BossForm();
            _bossForm.Owner = this;
            _bossForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _supplyerForm = new MakeDealForm();
            _supplyerForm.Owner = this;
            _supplyerForm.ShowDialog();
        }
    }
}
