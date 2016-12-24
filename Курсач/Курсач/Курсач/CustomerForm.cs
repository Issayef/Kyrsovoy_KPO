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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        public EnterDataForm _enterDataForm;
        public MakeDealForm _makeDealForm;
        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _enterDataForm = new EnterDataForm();
            _enterDataForm.Owner = this;
            _enterDataForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _makeDealForm = new MakeDealForm();
            _makeDealForm.Owner = this;
            _makeDealForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Owner = this;
            login.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
