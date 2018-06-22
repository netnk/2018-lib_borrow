using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using lib_borrow;
using System.Threading;
using System.IO;


namespace lib_borrow
{
    public partial class Form1 : Form
    {
        private string string1, string2, string3;

        public string String1  //(userName)
        {
            set
            {
                string1 = value;
            }
        }
        public string String2  //(userlocation)
        {
            set
            {
                string2 = value;
            }
        }
        public string String3  //(userid)
        {
            set
            {
                string3 = value;
            }
        }
        public void SetValue()
        {
            lbl_loginname.Text = string1;
            lbl_loginlocation.Text = string2;
        }

        lib_borrow.all_setting libhp = new all_setting();
        lib_borrow.sqlhp sqlhp = new lib_borrow.sqlhp();

        public Form1()
        {
            InitializeComponent();
            libhp.datagv_format(dataGridView_lt, dataGridView_hist, dataGridView_hs);
            lbl_opacurl.Text = string.Format("middleware: {0}", libhp.ini_opacurl());
            

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)  //
        {
            string get = string.Empty;

            if (libhp.ini_mode() == "0")
            {
                string opacurl = libhp.ini_opacurl();
                string userid = string3;
                string url = string.Format("http://{0}/getservice.ashx?mode=6&userid={1}", opacurl, userid);
                libhp.getservice(url);
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }


        }

        private void pic_lt1_Click(object sender, EventArgs e)  //
        {
            label18.Text = "0";
            libhp.clean_control(txt_readerid, txt_barcode, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs0, pic_lt1, panel_lt);
            libhp.hide_control(pic_hs1, panel_hs);
            libhp.datagv_clean(dataGridView_lt, dataGridView_hs, dataGridView_hist);
            txt_readerid.Focus();
            txt_barcode.Enabled = false;

        }

        private void pic_lt0_Click(object sender, EventArgs e)  //
        {
            label18.Text = "0";
            libhp.clean_control(txt_readerid, txt_barcode, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs0, pic_lt1, panel_lt);
            libhp.hide_control(pic_hs1, panel_hs);
            libhp.datagv_clean(dataGridView_lt, dataGridView_hs, dataGridView_hist);
            txt_readerid.Focus();
            txt_barcode.Enabled = false;

        }

        private void pic_hs1_Click(object sender, EventArgs e)  //
        {
            libhp.clean_control(txt_readerid, txt_barcode, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs1, pic_lt0, panel_hs);
            libhp.hide_control(pic_lt1, panel_lt);
            libhp.datagv_clean(dataGridView_lt, dataGridView_hs, dataGridView_hist);
            txt_barcode2.Focus();


            DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
            dgvImage.HeaderText = "";

            DataGridViewTextBoxColumn dgvBarcode = new DataGridViewTextBoxColumn();
            dgvBarcode.HeaderText = "";

            DataGridViewTextBoxColumn dgvId = new DataGridViewTextBoxColumn();
            dgvId.HeaderText = "";

            DataGridViewTextBoxColumn dgvTitle = new DataGridViewTextBoxColumn();
            dgvTitle.HeaderText = "";

            DataGridViewTextBoxColumn dgvCheckOut = new DataGridViewTextBoxColumn();
            dgvCheckOut.HeaderText = "";

            DataGridViewTextBoxColumn dgvReturn = new DataGridViewTextBoxColumn();
            dgvReturn.HeaderText = "";
            dgvReturn.DefaultCellStyle.ForeColor = Color.Red;

            DataGridViewTextBoxColumn dgvResult = new DataGridViewTextBoxColumn();
            dgvResult.HeaderText = "";

            dataGridView_hs.Columns.Add(dgvImage);
            dataGridView_hs.Columns.Add(dgvId);
            dataGridView_hs.Columns.Add(dgvBarcode);
            dataGridView_hs.Columns.Add(dgvTitle);
            dataGridView_hs.Columns.Add(dgvCheckOut);
            dataGridView_hs.Columns.Add(dgvReturn);
            dataGridView_hs.Columns.Add(dgvResult);

            dataGridView_hs.Columns[0].Width = 30;
            dataGridView_hs.Columns[1].Width = 50;
            dataGridView_hs.Columns[2].Width = 90;
            dataGridView_hs.Columns[3].Width = 250;
            dataGridView_hs.Columns[4].Width = 150;
            dataGridView_hs.Columns[5].Width = 150;
            dataGridView_hs.Columns[6].Width = 280;

            dataGridView_hs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_hs.AllowUserToAddRows = false;

            label18.Text = 0.ToString();

        }

        private void pic_hs0_Click(object sender, EventArgs e)  //
        {

            libhp.clean_control(txt_readerid, txt_barcode, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs1, pic_lt0, panel_hs);
            libhp.hide_control(pic_lt1, panel_lt);
            libhp.datagv_clean(dataGridView_lt, dataGridView_hs, dataGridView_hist);
            txt_barcode2.Focus();


            DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
            dgvImage.HeaderText = "";

            DataGridViewTextBoxColumn dgvBarcode = new DataGridViewTextBoxColumn();
            dgvBarcode.HeaderText = "";

            DataGridViewTextBoxColumn dgvId = new DataGridViewTextBoxColumn();
            dgvId.HeaderText = "";

            DataGridViewTextBoxColumn dgvTitle = new DataGridViewTextBoxColumn();
            dgvTitle.HeaderText = "";

            DataGridViewTextBoxColumn dgvCheckOut = new DataGridViewTextBoxColumn();
            dgvCheckOut.HeaderText = "";

            DataGridViewTextBoxColumn dgvReturn = new DataGridViewTextBoxColumn();
            dgvReturn.HeaderText = "";
            dgvReturn.DefaultCellStyle.ForeColor = Color.Red;

            DataGridViewTextBoxColumn dgvResult = new DataGridViewTextBoxColumn();
            dgvResult.HeaderText = "";

            dataGridView_hs.Columns.Add(dgvImage);
            dataGridView_hs.Columns.Add(dgvId);
            dataGridView_hs.Columns.Add(dgvBarcode);
            dataGridView_hs.Columns.Add(dgvTitle);
            dataGridView_hs.Columns.Add(dgvCheckOut);
            dataGridView_hs.Columns.Add(dgvReturn);
            dataGridView_hs.Columns.Add(dgvResult);

            dataGridView_hs.Columns[0].Width = 30;
            dataGridView_hs.Columns[1].Width = 50;
            dataGridView_hs.Columns[2].Width = 90;
            dataGridView_hs.Columns[3].Width = 250;
            dataGridView_hs.Columns[4].Width = 150;
            dataGridView_hs.Columns[5].Width = 150;
            dataGridView_hs.Columns[6].Width = 280;

            dataGridView_hs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_hs.AllowUserToAddRows = false;

            label18.Text = 0.ToString();

        }

        private void pic_logo_btn_Click(object sender, EventArgs e)  //
        {
        }

        private void dataGridView_lt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)  //
        {
            if (dataGridView_lt.Columns[e.ColumnIndex].Name == "")
            {
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        private void dataGridView_hs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)  //
        {
            if (dataGridView_hs.Columns[e.ColumnIndex].Name == "")
            {
                libhp.datagv_color_format(e);
            }
        }

        private void dataGridView_hist_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)  //
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)  //
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    {
                        pic_lt1.Focus();
                        pic_lt1_Click(sender, e);
                        txt_readerid.Focus();
                        break;
                    }
                case Keys.F2:
                    {
                        pic_hs1.Focus();
                        pic_hs1_Click(sender, e);
                        txt_barcode2.Focus();
                        break;
                    }
                case Keys.Escape:
                    {
                        pic_lt1.Focus();
                        pic_lt1_Click(sender, e);
                        txt_readerid.Focus();
                        break;
                    }
                case Keys.F8:
                    {
                        txt_readerid.Focus();
                        break;
                    }
                case Keys.F9:
                    {
                        if (txt_barcode.Visible == true)
                        {
                            txt_barcode.Focus();
                        }
                        break;
                    }
            }
        }

        private void txt_readerid_KeyDown(object sender, KeyEventArgs e)  //
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (txt_readerid.Text == string.Empty)
                        {
                            MessageBox.Show("CodeNumber", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_barcode.Enabled = false;
                            libhp.clean_control(txt_readerid, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk);
                            libhp.datagv_clean(dataGridView_lt, dataGridView_hs, dataGridView_hist);
                            return;
                        }
                        btn_readerid.Focus();
                        btn_readerid_Click(sender, e);
                        break;
                    }
                case Keys.F9:
                    {
                        if (txt_readerid.Text == string.Empty)
                        {
                            MessageBox.Show("CodeNumber", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_barcode.Enabled = false;
                            return;
                        }
                        txt_barcode.Focus();
                        break;
                    }
            }
        }

        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)  //
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (txt_barcode.Text == string.Empty)
                        {
                            MessageBox.Show("CodeNumber", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        btn_barcode.Focus();
                        btn_barcode_Click(sender, e);
                        break;
                    }
                case Keys.F8:
                    {
                        txt_readerid.Focus();
                        break;
                    }
            }

        }

        private void txt_barcode2_KeyDown(object sender, KeyEventArgs e)  //
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (txt_barcode2.Text == string.Empty)
                        {
                            MessageBox.Show("CodeNumber?", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        btn_hs.Focus();
                        btn_hs_Click(sender, e);
                        break;
                    }
            }
        }

        private void btn_hs_Click(object sender, EventArgs e)  //
        {

            string opacurl = libhp.ini_opacurl();
            string barcode = txt_barcode2.Text.Trim();
            string hist01 = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string userid = string1;
            string userlocation = string2;
            string url = string.Format("http://{0}/getservice.ashx?mode=4&barcode={1}&userid={2}&userlocation={3}", opacurl, barcode, userid, userlocation);
            string get = string.Empty;

            if (libhp.ini_mode() == "0")
            {
                get = libhp.getservice(url);
            }
            else
            {
                get = sqlhp.book_return(barcode, hist01, userid, userlocation);
            }


            Book_return m = JsonConvert.DeserializeObject<Book_return>(get);

            switch (m.result.ToString())
            {
                case "0":
                    {

                        int i = Convert.ToInt32(label18.Text) + 1;
                        dataGridView_hs.Rows.Insert(0, Image.FromFile("c:\\check.png"), i, m.acce01, m.cata12, m.sent02, m.hist01, m.msg);
                        dataGridView_hs.CurrentCell = dataGridView_hs.Rows[0].Cells[0];
                        dataGridView_hs.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                        dataGridView_hs.ClearSelection();


                       
                        libhp.clean_control(txt_barcode2);

                        label18.Text = i.ToString();

                        break;
                    }
                default:
                    {
                        
                        int i = Convert.ToInt32(label18.Text) + 1;
                        dataGridView_hs.Rows.Insert(0, Image.FromFile("c:\\notice.png"), i, m.acce01, m.cata12, "", "", m.msg);
                        dataGridView_hs.CurrentCell = dataGridView_hs.Rows[0].Cells[0];
                        dataGridView_hs.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow;
                        dataGridView_hs.ClearSelection();

                      
                        libhp.clean_control(txt_barcode2);

                        label18.Text = i.ToString();

                        break;
                    }
            }


        }

        private void btn_barcode_Click(object sender, EventArgs e)  //
        {
            
            string opacurl = libhp.ini_opacurl();
            string userid = txt_readerid.Text.Trim();
            string barcode = txt_barcode.Text.Trim();
            string sent05 = lbl_loginname.Text;
            string hist13 = lbl_reader72.Text;
            string url = string.Format("http://{0}/getservice.ashx?mode=3&readerid={1}&barcode={2}&sent05={3}&hist13={4}", opacurl, userid, barcode, sent05, hist13);
            string get = string.Empty;

            if (libhp.ini_mode() == "0")
            {
                get = libhp.getservice(url);
            }
            else
            {
                get = sqlhp.borrow(userid, barcode, sent05, hist13);
            }

            Borrow m = JsonConvert.DeserializeObject<Borrow>(get);

            switch (m.result.ToString())
            {
                case "0":
                    {
                        int i = Convert.ToInt32(label18.Text) + 1 ;
                        dataGridView_lt.Rows.Insert(0, Image.FromFile("c:\\check.png"), i , m.acce01, m.cata12, m.sent01, m.sent02, m.msg);                                              
                        dataGridView_lt.CurrentCell = dataGridView_lt.Rows[0].Cells[0];
                        dataGridView_lt.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                        dataGridView_lt.ClearSelection();

                        switch (m.datatype.ToString())
                        {
                            case "0":
                                {
                                    int tsy_total = Convert.ToInt32(lbl_tsy.Text);  //
                                    tsy_total += 1;
                                    lbl_tsy.Text = tsy_total.ToString();
                                    break;
                                }
                            case "1":
                                {
                                    int fsy_total = Convert.ToInt32(lbl_fsy.Text);
                                    fsy_total += 1;
                                    lbl_fsy.Text = fsy_total.ToString();
                                    break;
                                }
                            case "2":
                                {
                                    int qky_total = Convert.ToInt32(lbl_qky);
                                    qky_total += 1;
                                    lbl_qky.Text = qky_total.ToString();
                                    break;
                                }
                        }

                        ////   libhp.write_log(0, m.sent01, userid, m.acce01, "", m.sent02);                       

                        libhp.clean_control(txt_barcode);
                        label18.Text = i.ToString();

                        break;
                    }
                default:
                    {

                        int i = Convert.ToInt32(label18.Text) + 1;                     
                        dataGridView_lt.Rows.Insert(0, Image.FromFile("c:\\notice.png"), i, m.acce01, m.cata12, "", "", m.msg );                                              
                        dataGridView_lt.CurrentCell = dataGridView_lt.Rows[0].Cells[0];
                        dataGridView_lt.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow;
                        dataGridView_lt.ClearSelection();

                        libhp.clean_control(txt_barcode);
                        label18.Text = i.ToString();

                        break;
                    }
            }


        }

        private void btn_readerid_Click(object sender, EventArgs e)  //
        {


            workingForm1 frm = new workingForm1();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.Activate();

            string opacurl = libhp.ini_opacurl();
            string readerid = txt_readerid.Text;
            string url = string.Format("http://{0}/getservice.ashx?mode=2&readerid={1}", opacurl, readerid);

            string get = string.Empty;

            if (libhp.ini_mode() == "0")
            {
                get = libhp.getservice(url);
            }
            else
            {
                get = sqlhp.reader_login(readerid);
            }



            Login m = JsonConvert.DeserializeObject<Login>(get);

            txt_readerid.Text = m.reader01;
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
                        frm.Close();
                        string url2 = string.Format("http://{0}/getservice.ashx?mode=5&readerid={1}", opacurl, readerid);

                        string get2 = string.Empty;

                        if (libhp.ini_mode() == "0")
                        {
                            get2 = libhp.getservice(url2);
                        }
                        else
                        {
                            get2 = sqlhp.book_hist(readerid);
                        }

                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(get2);
                        dataGridView_hist.DataSource = dt;
                        if (dt.Rows.Count <= 0)
                        {
                            //MessageBox.Show("not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_barcode.Enabled = true;
                            txt_barcode.Focus();
                            return;
                        }
                        libhp.datagv_field_width(dataGridView_hist);
                        libhp.datagv_clean(dataGridView_lt);
                        libhp.clean_control(txt_barcode);
                        txt_barcode.Enabled = true;
                        txt_barcode.Focus();


                        DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
                        dgvImage.HeaderText = "";                        

                        DataGridViewTextBoxColumn dgvBarcode = new DataGridViewTextBoxColumn();
                        dgvBarcode.HeaderText = "";                      

                        DataGridViewTextBoxColumn dgvId = new DataGridViewTextBoxColumn();
                        dgvId.HeaderText = "";

                        DataGridViewTextBoxColumn dgvTitle = new DataGridViewTextBoxColumn();
                        dgvTitle.HeaderText = "";

                        DataGridViewTextBoxColumn dgvCheckOut = new DataGridViewTextBoxColumn();
                        dgvCheckOut.HeaderText = "";

                        DataGridViewTextBoxColumn dgvReturn = new DataGridViewTextBoxColumn();
                        dgvReturn.HeaderText = "";
                        dgvReturn.DefaultCellStyle.ForeColor = Color.Red;

                        DataGridViewTextBoxColumn dgvResult = new DataGridViewTextBoxColumn();
                        dgvResult.HeaderText = "";
                       
                        dataGridView_lt.Columns.Add(dgvImage);
                        dataGridView_lt.Columns.Add(dgvId);
                        dataGridView_lt.Columns.Add(dgvBarcode);
                        dataGridView_lt.Columns.Add(dgvTitle);
                        dataGridView_lt.Columns.Add(dgvCheckOut);
                        dataGridView_lt.Columns.Add(dgvReturn);
                        dataGridView_lt.Columns.Add(dgvResult);

                        dataGridView_lt.Columns[0].Width = 30;
                        dataGridView_lt.Columns[1].Width = 50;
                        dataGridView_lt.Columns[2].Width = 90;
                        dataGridView_lt.Columns[3].Width = 250;
                        dataGridView_lt.Columns[4].Width = 150;
                        dataGridView_lt.Columns[5].Width = 150;
                        dataGridView_lt.Columns[6].Width = 280;

                        dataGridView_lt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView_lt.AllowUserToAddRows = false;

                        

                        break;
                    }
                default:
                    {
                        frm.Close();
                        libhp.clean_control(txt_barcode, txt_readerid, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk);
                        libhp.datagv_clean(dataGridView_hist, dataGridView_lt);
                        MessageBox.Show(m.msg.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_barcode.Enabled = false;

                        break;
                    }
            }


        }

        private void pic_tab_lt1_Click(object sender, EventArgs e)  //
        {
            libhp.display_control(pic_tab_lt1, pic_tab_hist0, dataGridView_lt, label10, txt_barcode, pic_barcode);
            libhp.hide_control(pic_tab_lt0, pic_tab_hist1, dataGridView_hist);
            txt_barcode.Focus();
        }

        private void pic_tab_lt0_Click(object sender, EventArgs e)  //
        {
            libhp.display_control(pic_tab_lt1, pic_tab_hist0, dataGridView_lt, label10, txt_barcode, pic_barcode);
            libhp.hide_control(pic_tab_lt0, pic_tab_hist1, dataGridView_hist);
            txt_barcode.Focus();
        }

        private void pic_tab_hist1_Click(object sender, EventArgs e)  //
        {
            if (dataGridView_hist.Rows.Count <= 0)
            {
                MessageBox.Show("not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            libhp.display_control(pic_tab_hist1, pic_tab_lt0, dataGridView_hist);
            libhp.hide_control(pic_tab_hist0, pic_tab_lt1, dataGridView_lt, label10, txt_barcode, pic_barcode);

        }

        private void pic_tab_hist0_Click(object sender, EventArgs e)  //
        {
            if (dataGridView_hist.Rows.Count <= 0)
            {
                MessageBox.Show("not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            libhp.display_control(pic_tab_hist1, pic_tab_lt0, dataGridView_hist);
            libhp.hide_control(pic_tab_hist0, pic_tab_lt1, dataGridView_lt, label10, txt_barcode, pic_barcode);
        }

        private void pic_logout_Click(object sender, EventArgs e)  //
        {


            DialogResult dialogResult = MessageBox.Show("Login Out？", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {

                string get = string.Empty;

                if (libhp.ini_mode() == "0")
                {
                    string opacurl = libhp.ini_opacurl();
                    string userid = string3;
                    string url = string.Format("http://{0}/getservice.ashx?mode=6&userid={1}", opacurl, userid);
                    libhp.getservice(url);
                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        private void Form1_Load(object sender, EventArgs e)  //
        {



            libhp.display_control(pic_hs0, pic_lt1, panel_lt, pic_tab_lt1, pic_tab_hist0, dataGridView_lt, label10, txt_barcode, pic_barcode);
            libhp.hide_control(pic_hs1, panel_hs, pic_tab_lt0, pic_tab_hist1, dataGridView_hist);
            txt_barcode.Enabled = false;


        }

        //private void v_gv_lt()  //
        //{

        //    dataGridView_lt.ColumnCount = 7;
        //    dataGridView_lt.Columns[0].Name = "";
        //    dataGridView_lt.Columns[1].Name = "";
        //    dataGridView_lt.Columns[1].Width = 40;
        //    dataGridView_lt.Columns[2].Name = "";
        //    dataGridView_lt.Columns[3].Name = "";
        //    dataGridView_lt.Columns[3].Width = 100;
        //    dataGridView_lt.Columns[4].Name = "";
        //    dataGridView_lt.Columns[4].Width = 140;
        //    dataGridView_lt.Columns[5].Name = "";
        //    dataGridView_lt.Columns[5].Width = 140;
        //    dataGridView_lt.Columns[6].Name = "";

        //}

        //private void v_gv_hs()  //
        //{
        //    dataGridView_hs.ColumnCount = 6;
        //    dataGridView_hs.Columns[0].Name = "";
        //    dataGridView_hs.Columns[1].Name = "";
        //    dataGridView_hs.Columns[2].Name = "";
        //    dataGridView_hs.Columns[3].Name = "";
        //    dataGridView_hs.Columns[4].Name = "";
        //    dataGridView_hs.Columns[5].Name = "";
        //}

    }
}
