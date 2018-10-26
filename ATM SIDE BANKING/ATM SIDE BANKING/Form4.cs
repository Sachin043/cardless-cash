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
using System.Speech.Synthesis;

namespace ATM_SIDE_BANKING
{
    public partial class Form4 : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        long fbal;
        SpeechSynthesizer b;
        public Form4(string ss)
        {
            InitializeComponent();
            textBox2.Text = ss;
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            button4.Visible = false;
            connection();
            string s = "select * from acholder where acnum=" + Convert.ToInt64(textBox2.Text);
            cm = new SqlCommand(s, cn);
            SqlDataReader rs = cm.ExecuteReader();
            rs.Read();
            long amt = Convert.ToInt64(rs.GetValue(4));
            amt = amt - Convert.ToInt64(textBox1.Text);
            if (amt >= 500)
            {
                fbal = amt;
                updatebalance();
                b = new SpeechSynthesizer();
                b.Speak("Your transaction is under process. PLEASE WAIT");
                
                b.Speak("Please collect the Amount");
                MessageBox.Show("Please collect the Amount");
            }
            else
            {
                b.Speak("Insufficient Amount");
            }
            cn.Close();
            

        }
        private void updatebalance()
        {
            cn.Close();
            connection();
            string s;
            s = "update acholder set opbal=" + fbal + " where acnum=" + Convert.ToInt64(textBox2.Text);
            cm = new SqlCommand(s, cn);
            cm.ExecuteNonQuery();
            cn.Close();
        }
        private void connection()
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\CARD\\WindowsFormsApplication3\\WindowsFormsApplication3\\cardless.mdf;Integrated Security=True;Connect Timeout=30");
            cn.Open();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Visible = true;
            textBox1.Visible = true;
            button4.Visible = true;
            b = new SpeechSynthesizer();
            b.Speak("Enter the Amount");
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            button4.Visible = false;
            connection();
            
            string s = "select * from acholder where acnum=" + Convert.ToInt64(textBox2.Text);
            
            cm = new SqlCommand(s, cn);
            SqlDataReader rs = cm.ExecuteReader();
            rs.Read();
            long amt = Convert.ToInt64(rs.GetValue(4));
            b = new SpeechSynthesizer();
            b.Speak("Your current Balance is  "+  amt.ToString());
            MessageBox.Show("  Your current Balance is  "+  amt.ToString());
            cn.Close();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            button4.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
