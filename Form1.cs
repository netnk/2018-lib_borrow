using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using lib_borrow;


namespace lib_borrow
{
    public partial class Form1 : Form
    {
        private string string1;
        public string String1
        {
            set
            {
                string1 = value;
            }            
        }
        public void SetValue()
        {
            this.lbl_loginid.Text = string1;
        }

        public Form1()
        {
            InitializeComponent();

            textBox1.Focus();

            lbl_loginid.Parent = pictureBox1;
            lbl_loginid.BackColor = System.Drawing.Color.Transparent;

            label1.Parent = pictureBox1;
            label1.BackColor = System.Drawing.Color.Transparent;
           

        }
        
        private void button1_Click(object sender, EventArgs e)  //
        {
            string ip = ini_url();
            string readerid = textBox1.Text;
            string url = string.Format("http://{0}/getservice.ashx?mode=2&readerid={1}", ip, readerid);
            string get = getservice(url);            

            Login m = JsonConvert.DeserializeObject<Login>(get);
            // MessageBox.Show(m.field);

            textBox1.Text = m.field;
            lbl_field.Text = m.field;
            lbl_field.Text = m.field;
            lbl_field.Text = m.field;
            lbl_field.Text = m.field.ToString();
            lbl_field.Text = m.field.ToString();
            lbl_tsk.Text = m.tsk.ToString();
            lbl_tsy.Text = m.tsy.ToString();
            lbl_fsk.Text = m.fsk.ToString();
            lbl_fsy.Text = m.fsy.ToString();
            lbl_qkk.Text = m.qkk.ToString();
            lbl_qky.Text = m.qky.ToString();

            switch (m.result.ToString())
            {
                case "0":
                    {
                        textBox2.Enabled = true;
                        textBox2.Focus();

                        dataGridView1.Rows.Clear();
                        break;
                    }
                default:
                    {
                        MessageBox.Show(m.msg.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox2.Text = string.Empty;
                        break;
                    }
            }

           

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                button1.Focus();
                button1_Click(sender, e);
            }

            if (e.KeyCode == Keys.F10)

            {
                textBox2.Focus();
            }
        }  //

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                button2.Focus();
                button2_Click(sender, e);
            }

            if (e.KeyCode == Keys.F9)

            {
                textBox1.Focus();
            }

        }  //

        private void button2_Click(object sender, EventArgs e)  //
        {
            string ip = ini_url();
            string userid = textBox1.Text.Trim();
            string barcode = textBox2.Text.Trim();
            string field = lbl_field.Text;
            string field = lbl_field.Text;
            string url = string.Format("http://{0}/getservice.ashx?mode=3&field={1}&field={2}&field={3}&field={4}",ip, userid, field,field,field);
           // MessageBox.Show(url);
            string get = getservice(url);

            Borrow m = JsonConvert.DeserializeObject<Borrow>(get);
            //  MessageBox.Show(m.cata12);

            switch(m.result.ToString())
            {
                case "0":
                    {
                        dataGridView1.AllowUserToAddRows = false;  //

                        DataGridViewRowCollection rows = dataGridView1.Rows;
                        rows.Insert(0, new Object[] { m.field, m.field, "", m.field, m.field, field });  //
                        dataGridView1.Rows[0].Cells[4].Style.ForeColor = Color.Red;  //
                       
                        if (dataGridView1.Rows.Count > 0)
                        {
                            for (int count = 0; count < dataGridView1.Rows.Count; count++)
                            {
                                dataGridView1.Rows[0].Selected = true;
                                dataGridView1.FirstDisplayedScrollingRowIndex = 0;              
                                dataGridView1.Rows[count].HeaderCell.Value = Convert.ToString(count + 1);  //
                            }
                        }

                        int field_total = Convert.ToInt32(lbl_field.Text);  //
                        tsy_field += 1;
                        lbl_field.Text = tsy_field.ToString();

                        textBox2.Text = string.Empty;
                        break;
                    }
                default:
                    {
                        MessageBox.Show(m.field.ToString(),"Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox2.Text = string.Empty;
                        break;
                    }                
            }

            //MessageBox.Show(m.field);
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
        }  //

        private string getservice(string url)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                string result = wc.DownloadString(url);
                return result;
            }
        }  // 

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)  //
        {
            Form2 frm = new Form2();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Location = new Point(0, 0);
            frm.Show();
            frm.BringToFront();
        }

        private void pic_lt1_Click(object sender, EventArgs e)  //
        {
         
            pic_hs0.Visible = true;
            pic_lt1.Visible = true;
            pic_hs1.Visible = false;

            pictureBox6.Visible = false;
            dataGridView2.Visible = false;
            label8.Visible = false;
            textBox3.Visible = false;
            MessageBox.Show("1");
        }

        private void pic_lt0_Click(object sender, EventArgs e)  //
        {

           

            pic_hs0.Visible = true;
            pic_lt1.Visible = true;
            pic_hs1.Visible = false;

            pictureBox6.Visible = false;
            dataGridView2.Visible = false;
            label8.Visible = false;
            textBox3.Visible = false;
            MessageBox.Show("1");
        }

        private void pic_hs1_Click(object sender, EventArgs e)  //
        {
            

            pic_hs1.Visible = true;
            pic_lt0.Visible = true;
            pic_lt1.Visible = false;

            pictureBox6.Visible = true;
            dataGridView2.Visible = true;
            label8.Visible = true;
            textBox3.Visible = true;
            textBox3.Focus();
            MessageBox.Show("2");
        }

        private void pic_hs0_Click(object sender, EventArgs e)  //
        {
            

            pic_hs1.Visible = true;
            pic_lt0.Visible = true;
            pic_lt1.Visible = false;

            pictureBox6.Visible = true;
            dataGridView2.Visible = true;
            label8.Visible = true;
            textBox3.Visible = true;
            textBox3.Focus();

            MessageBox.Show("2");
        }
    }
}
