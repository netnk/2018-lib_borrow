using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using lib_borrow;

namespace lib_borrow
{
    public partial class loginForm1 : Form
    {
        lib_borrow.all_setting libhp = new all_setting();

        public loginForm1()
        {
            InitializeComponent();

            pictureBox1.BackColor = Color.Transparent;           

        }

        private void pictureBox1_Click(object sender, EventArgs e)  //URL
        {
            Form2 frm = new Form2();
            frm.StartPosition = FormStartPosition.CenterScreen;            
            frm.Show();
            frm.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string field = libhp.ini_url();
            string id = textBox1.Text.Trim();
            string pwd = textBox2.Text.Trim();
            string url = string.Format("http://{0}/getservice.ashx?mode=1&userid={1}&pwd={2}", field, id, pwd);
            string get = libhp.getservice(url);

            Checkadmi m = JsonConvert.DeserializeObject<Checkadmi>(get);

            switch (m.field.ToString())
            {
                case "0":
                    {
                        //  MessageBox.Show("Success!!");
                        Form1 frm1 = new Form1();
                        frm1.String1 = m.field;
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
