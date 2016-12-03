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
    public partial class EnterDataForm : Form
    {
        public EnterDataForm()
        {
            InitializeComponent();
        }
        public CustomerForm _customerForm;

        private void button2_Click(object sender, EventArgs e)
        {
            //_customerForm = new CustomerForm();
            //_customerForm.Owner = this;
            //_customerForm.ShowDialog();
            Close();
        }
    }
}
