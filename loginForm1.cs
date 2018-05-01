using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace lib_borrow
{
    public partial class loginForm1 : Form
    {
        public loginForm1()
        {
            InitializeComponent();

            pictureBox1.BackColor = Color.Transparent;           

        }
        
        private string ini_url()
        {
            using (FileStream fs = new FileStream("host.ini", FileMode.Open))
            {
                using (StreamReader rw = new StreamReader(fs))
                {
                    string result = rw.ReadLine();
                    return result;
                }
            }
        }  

        private string getservice(string url)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                string result = wc.DownloadString(url);
                return result;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)  
        {
            Form2 frm = new Form2();
            frm.StartPosition = FormStartPosition.CenterScreen;            
            frm.Show();
            frm.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string ip = ini_url();
            string id = textBox1.Text.Trim();
            string pwd = textBox2.Text.Trim();
            string url = string.Format("http://{0}/getservice.ashx?mode=1&userid={1}&pwd={2}", ip, id, pwd);
            string get = getservice(url);

            Checkadmi m = JsonConvert.DeserializeObject<Checkadmi>(get);

            switch (m.result.ToString())
            {
                case "0":
                    {
                        //  MessageBox.Show("Success!!");
                        Form1 frm1 = new Form1();
                        frm1.String1 = m.userid;
                        frm1.SetValue();
                        frm1.ShowDialog();
                        this.Enabled = false;

                        break;
                    }
                default:
                    {
                        MessageBox.Show(m.msg.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox1.Focus();
                        break;
                    }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)  //
        {
            if (e.KeyCode == Keys.Enter)

            {
                pictureBox2.Focus();
                pictureBox2_Click(sender, e);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)  //
        {
            if (e.KeyCode == Keys.Enter)

            {
                pictureBox2.Focus();
                pictureBox2_Click(sender, e);
            }
        }
    }
}
