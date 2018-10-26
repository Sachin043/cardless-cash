using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_SIDE_BANKING
{
    public partial class Form5 : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        
        public Form5()
        {
            InitializeComponent();
        }
        private void connection()
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\CARD\\WindowsFormsApplication3\\WindowsFormsApplication3\\cardless.mdf;Integrated Security=True;Connect Timeout=30");
            cn.Open();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void label2_Click(object sender, EventArgs e)
        {
        
        }
        private void Form5_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
