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
    public partial class EmployerForm : Form
    {
        public EmployerForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("E:\\Data.xml");
            foreach (DataRow item in ds.Tables["Products"].Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["UnitsOnOrder"];
                dataGridView1.Rows[n].Cells[2].Value = item["UnitPrice"];
            }
            foreach (DataRow item in ds.Tables["Orders"].Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = item["ShipName"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["OrderDate"];
                dataGridView2.Rows[n].Cells[2].Value = item["RequiredDate"];
            }
        }
    }
}
