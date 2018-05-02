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

        lib_borrow.all_setting libhp = new all_setting();

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
            string opacurl = libhp.ini_opacurl();
            string readerid = textBox1.Text;
            string url = string.Format("http://{0}/getservice.ashx?mode=2&readerid={1}", opacurl, readerid);
            string get = libhp.getservice(url);            

            Login m = JsonConvert.DeserializeObject<Login>(get);
            // MessageBox.Show(m.reader02);

            textBox1.Text = m.reader01;
            lbl_reader02.Text = m.reader02;
            lbl_reader72.Text = m.reader72;
            lbl_yxrq.Text = m.yxrq;
            lbl_yyrgnum.Text = m.yyrgnum.ToString();
            lbl_fk.Text = m.fk.ToString();
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
                        
                        string url2 = string.Format("http://{0}/getservice.ashx?mode=5&readerid={1}", opacurl, readerid);
                        string get2 = libhp.getservice(url2);

                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(get2);
                        dataGridView3.DataSource = dt;
                       
                        textBox2.Enabled = true;
                        textBox2.Focus();

                        dataGridView1.Rows.Clear();

                        break;
                    }
                default:
                    {
                        MessageBox.Show(m.msg.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        libhp.clean_control(textBox2);
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
            string opacurl = libhp.ini_opacurl();
            string userid = textBox1.Text.Trim();
            string field = textBox2.Text.Trim();
            string field = lbl_loginid.Text;
            string field = lbl_reader72.Text;
            string url = string.Format("http://{0}/wgetservice.ashx?mode=3&readerid={1}&field={2}&field={3}&field={4}",opacurl, userid, field,field,field);
           // MessageBox.Show(url);
            string get = libhp.getservice(url);

            Borrow m = JsonConvert.DeserializeObject<Borrow>(get);
            //  MessageBox.Show(m.cata12);

            switch(m.result.ToString())
            {
                case "0":
                    {                       

                        dataGridView1.ColumnCount = 6;
                        dataGridView1.Columns[0].Name = "field";
                        dataGridView1.Columns[1].Name = "field";
                        dataGridView1.Columns[2].Name = "field";
                        dataGridView1.Columns[3].Name = "field";
                        dataGridView1.Columns[4].Name = "field";
                        dataGridView1.Columns[5].Name = "field";
                       
                        dataGridView1.Rows.Insert(0, m.field, m.field, "", m.field, m.field, field);
                       
                        if (dataGridView1.Rows.Count > 0)
                        {
                            for (int count = 0; count < dataGridView1.Rows.Count; count++)
                            {
                                dataGridView1.Rows[0].Selected = true;
                                dataGridView1.FirstDisplayedScrollingRowIndex = 0;              
                                dataGridView1.Rows[count].HeaderCell.Value = Convert.ToString(count + 1);  //
                            }
                        }

                        

                        int tsy_total = Convert.ToInt32(lbl_tsy.Text);  //
                        tsy_total += 1;
                        lbl_tsy.Text = tsy_total.ToString();

                        libhp.clean_control(textBox2);
                        break;
                    }
                default:
                    {
                        MessageBox.Show(m.msg.ToString(),"Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        libhp.clean_control(textBox2);
                        break;
                    }                
            }

            //MessageBox.Show(m.result);
        }      

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)  //
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
            groupBox1.Visible = true;
            groupBox2.Visible = false;

            textBox1.Focus();
            textBox2.Enabled = false;

            libhp.clean_control(textBox1, textBox2, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs0, pic_lt1);           
            pic_hs1.Visible = false;

            DataTable dt = new DataTable();
            dt.Clear();           
            dataGridView3.DataSource = dt;
            dataGridView1.DataSource = null;

            MessageBox.Show("1");
           
        }

        private void pic_lt0_Click(object sender, EventArgs e)  //
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;

            textBox1.Focus();
            textBox2.Enabled = false;

            libhp.clean_control(textBox1, textBox2, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs0, pic_lt1);           
            pic_hs1.Visible = false;

            DataTable dt = new DataTable();
            dt.Clear();            
            dataGridView3.DataSource = dt;
            dataGridView1.DataSource = null;

         

            MessageBox.Show("1");
        }

        private void pic_hs1_Click(object sender, EventArgs e)  //
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;

            libhp.clean_control(textBox1, textBox2, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs1, pic_lt0);          
            pic_lt1.Visible = false;
          
            DataTable dt = new DataTable();
            dt.Clear();           
            dataGridView3.DataSource = dt;
            dataGridView1.DataSource = null;

            MessageBox.Show("2");
        }

        private void pic_hs0_Click(object sender, EventArgs e)  //
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;




            libhp.clean_control(textBox1, textBox2, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs1, pic_lt0);         
            pic_lt1.Visible = false;

            DataTable dt = new DataTable();
            dt.Clear();            
            dataGridView3.DataSource = dt;
            dataGridView1.DataSource = null;

           
            

            MessageBox.Show("2");
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)  //
        {
            dataGridView3.Columns[0].HeaderText = "field";
            dataGridView3.Columns[0].Width = 100;
            dataGridView3.Columns[1].HeaderText = "field";
            dataGridView3.Columns[1].Width = 250;
            dataGridView3.Columns[2].HeaderText = "field";
            dataGridView3.Columns[2].Width = 70;
            dataGridView3.Columns[3].HeaderText = "field";
            dataGridView3.Columns[4].HeaderText = "field";

            /*
            for (int i=0; i<dataGridView3.Rows.Count;i++)
            {
                dataGridView3.Rows[i].Cells[3].Style.ForeColor = Color.Red;
            }
            */
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)  //
        {
            dataGridView1.ColumnCount = 6;

            dataGridView1.Columns[0].Width = 100;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[4].Style.ForeColor = Color.Red;
            }
        }

       
    }
}
