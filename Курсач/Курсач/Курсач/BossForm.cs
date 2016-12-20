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
    public partial class BossForm : Form
    {
        public BossForm()
        {
            InitializeComponent();
        }
        public SaveForm _saveForm;
        public StatisticForm _statForm;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _saveForm = new SaveForm();
            _saveForm.Owner = this;
            _saveForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockForm sklad = new StockForm();
            sklad.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _statForm = new StatisticForm();
            _statForm.Owner = this;
            _statForm.ShowDialog();
        }
    }
}
