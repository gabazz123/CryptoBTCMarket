using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoBTCMarket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessingFunctions.WiriteXMLData(ProcessingFunctions.AddRow(ProcessingFunctions.DataTable(), ProcessingFunctions.ExtractData()));
            dataGridView1.DataSource = ProcessingFunctions.ReadXMLData();
        }
    }
}
