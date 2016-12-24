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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }
        public EnterDataSupplierForm _enterDataForm;
        public MakeSupplyForm _makeSupplyForm;

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
            
        }

        private void makedeal_button_Click(object sender, EventArgs e)
        {
            _makeSupplyForm = new MakeSupplyForm();
            _makeSupplyForm.Owner = this;
            _makeSupplyForm.ShowDialog();
        }

        private void EnterData_button_Click(object sender, EventArgs e)
        {
            _enterDataForm = new EnterDataSupplierForm();
            _enterDataForm.Owner = this;
            _enterDataForm.ShowDialog();
        }
    }
}
