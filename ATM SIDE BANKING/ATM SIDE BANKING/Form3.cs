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
using System.IO;
using System.Speech.Synthesis;
namespace ATM_SIDE_BANKING
{
    public partial class Form3 : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        string mpass;
        int i;
        SpeechSynthesizer b;
        public Form3()
        {
            InitializeComponent();
        }
        static class RandomUtil
        {
            public static string GetRandomString()
            {
                string path = Path.GetRandomFileName();
                path = path.Replace(".", "");
                return path;
            }
        }

        private void connection()
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\CARD\\WindowsFormsApplication3\\WindowsFormsApplication3\\cardless.mdf;Integrated Security=True;Connect Timeout=30");
            cn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("Enter the OTP");
                }
               
                connection();
                string s;
                s = "select * from acholder where acnum=" + Convert.ToInt64(textBox3.Text) + " and pass='" + textBox2.Text + "'";
                cm = new SqlCommand(s, cn);
                SqlDataReader rs = cm.ExecuteReader();
                b = new SpeechSynthesizer();
                b.Speak("Your details is in verification. Please Wait");

                if (rs.HasRows)
                {
                   passwordchange();

                    Form4 f = new Form4(textBox3.Text);
                  //  Form f = new Form4();
                    f.Show();
                    this.Hide();

                }
                cn.Close();
               
            }
            catch (Exception)
            {
                b = new SpeechSynthesizer();
                b.Speak("INCORRECT OTP.. PLEASE TRY AGAIN ");
                MessageBox.Show("Incorrect OTP. Please try again");
                
            }
            

            }


        private void passwordchange()
        { 
            cn.Close();
            connection();
            string s;
            mpass = "";
            mpass = RandomUtil.GetRandomString();
            s = "update acholder set pass='" + mpass + "'" + "where acnum=" + Convert.ToInt64(textBox3.Text);
            cm = new SqlCommand(s, cn);
            cm.ExecuteNonQuery();

        }
   
        private void button2_Click(object sender, EventArgs e)
        {
           Form n= new Form2();
           n.Show();
           this.Hide();
                


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            b = new SpeechSynthesizer();
            b.Speak("Enter the Account Number and The One time password you have received");
            timer1.Start();
            timer1.Enabled = true;
            i = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 1000)
            {
                timer1.Stop();
                this.Close();
                timer1.Enabled = false;
            }
        }
    }
}
