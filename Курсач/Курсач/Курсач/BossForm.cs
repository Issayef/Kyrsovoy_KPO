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
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm log = new LoginForm();
            log.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BossSuppliesForm bos = new BossSuppliesForm();
            bos.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockForm sklad = new StockForm();
            sklad.ShowDialog();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StatisticForm statistic = new StatisticForm();
            statistic.ShowDialog();
        }
    }
}
