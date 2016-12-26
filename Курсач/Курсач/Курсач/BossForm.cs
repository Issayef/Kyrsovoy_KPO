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
        

        private void button1_Click(object sender, EventArgs e)  // выходим из профиля, заново открываем форму инициализации пользователя
        {
            this.Hide();
            LoginForm log = new LoginForm();
            log.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)  // открываем окно работы с поставками
        {
            BossSuppliesForm bos = new BossSuppliesForm();
            bos.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)    //открываем окно наличия товара на складе
        {
            StockForm sklad = new StockForm();
            sklad.ShowDialog();
        }

        private void close_button_Click(object sender, EventArgs e)  // выход из приложения
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) // открываем окно просмотра статистики
        {
            StatisticForm statistic = new StatisticForm();
            statistic.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CatalogForm catalog = new CatalogForm();
            catalog.ShowDialog();
        }
    }
}
