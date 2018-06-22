using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib_borrow;

namespace lib_borrow
{
    public partial class OfflineForm : Form
    {
        private string string1;
        public string String1  //從loginForm1帶過來的值(userName)
        {
            set
            {
                string1 = value;
            }
        }
        public void SetValue()
        {
            lbl_loginname.Text = string1;
        }


        lib_borrow.all_setting libhp = new all_setting();

        public OfflineForm()
        {
            InitializeComponent();
            libhp.datagv_format(dataGridView_lt, dataGridView_hist, dataGridView_hs);
            libhp.hide_control(pic_Export_Excel, pic_Export_Excel2);
        }

        private void pic_Export_Excel_Click(object sender, EventArgs e)  //
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string ReadFile = string.Format("./log/{0}_borrow.txt", date);
            DataTable dt = libhp.TXT_To_DataTable(ReadFile);
            libhp.DataTableToExcel(dt, "borrow");
            MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void pic_Export_Excel2_Click(object sender, EventArgs e)  //
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string ReadFile = string.Format("./log/{0}_return.txt", date);
            DataTable dt = libhp.TXT_To_DataTable(ReadFile);
            libhp.DataTableToExcel(dt, "return");
            MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void OfflineForm_FormClosed(object sender, FormClosedEventArgs e)
        {           
            Application.Exit();
        }

        private void pic_logout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Login Out？", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {              
                Application.Exit();

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        private void pic_tab_hist0_Click(object sender, EventArgs e)
        {
           
        }

        private void pic_tab_hist1_Click(object sender, EventArgs e)
        {
           
        }

        private void pic_lt0_Click(object sender, EventArgs e)  //
        {

            libhp.clean_control(txt_readerid, txt_barcode, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs0, pic_lt1, panel_lt);
            libhp.hide_control(pic_hs1, panel_hs, pic_Export_Excel, pic_Export_Excel2);
            libhp.datagv_clean(dataGridView_lt, dataGridView_hs, dataGridView_hist);
            txt_readerid.Focus();
            txt_barcode.Enabled = false;
        }

        private void pic_lt1_Click(object sender, EventArgs e)  //
        {

            libhp.clean_control(txt_readerid, txt_barcode, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs0, pic_lt1, panel_lt);
            libhp.hide_control(pic_hs1, panel_hs, pic_Export_Excel, pic_Export_Excel2);
            libhp.datagv_clean(dataGridView_lt, dataGridView_hs, dataGridView_hist);
            txt_readerid.Focus();
            txt_barcode.Enabled = false;
        }

        private void pic_hs0_Click(object sender, EventArgs e)  //
        {
            libhp.clean_control(txt_readerid, txt_barcode, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs1, pic_lt0, panel_hs);
            libhp.hide_control(pic_lt1, panel_lt, pic_Export_Excel, pic_Export_Excel2);
            libhp.datagv_clean(dataGridView_lt, dataGridView_hs, dataGridView_hist);
            txt_barcode2.Focus();
        }

        private void pic_hs1_Click(object sender, EventArgs e)  //
        {
            libhp.clean_control(txt_readerid, txt_barcode, lbl_reader02, lbl_reader72, lbl_yxrq, lbl_yyrgnum, lbl_fk, lbl_tsk, lbl_tsy, lbl_fsk, lbl_fsy, lbl_qkk, lbl_qky);
            libhp.display_control(pic_hs1, pic_lt0, panel_hs);
            libhp.hide_control(pic_lt1, panel_lt, pic_Export_Excel, pic_Export_Excel2);
            libhp.datagv_clean(dataGridView_lt, dataGridView_hs, dataGridView_hist);
            txt_barcode2.Focus();
        }

        private void btn_barcode_Click(object sender, EventArgs e)
        {
            string readerid = txt_readerid.Text;
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            txt_barcode.Enabled = true;
            txt_barcode.Focus();

            dataGridView_lt.ColumnCount = 7;
            dataGridView_lt.Columns[0].Name = "";
            dataGridView_lt.Columns[1].Name = "";
            dataGridView_lt.Columns[2].Name = "";
            dataGridView_lt.Columns[3].Name = "";
            dataGridView_lt.Columns[4].Name = "";
            dataGridView_lt.Columns[5].Name = "";
            dataGridView_lt.Columns[6].Name = "";
            libhp.datagv_field_width(dataGridView_lt);
            dataGridView_lt.Rows.Insert(0, dataGridView_lt.Rows.Count + 1, txt_barcode.Text, "", "", date, "", string1);  //
            dataGridView_lt.CurrentCell = dataGridView_lt.Rows[0].Cells[0];
            libhp.write_log(0, date, readerid, txt_barcode.Text, "", "");
            libhp.clean_control(txt_barcode);
            libhp.display_control(pic_Export_Excel);
        }

        private void btn_readerid_Click(object sender, EventArgs e)
        {
            string readerid = txt_readerid.Text;
            txt_barcode.Enabled = true;
            txt_barcode.Focus();
        }

        private void btn_hs_Click(object sender, EventArgs e)  //
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            dataGridView_hs.ColumnCount = 9;
            dataGridView_hs.Columns[0].Name = "";
            dataGridView_hs.Columns[1].Name = "";
            dataGridView_hs.Columns[2].Name = "";
            dataGridView_hs.Columns[3].Name = "";
            dataGridView_hs.Columns[4].Name = "";
            dataGridView_hs.Columns[5].Name = "";
            dataGridView_hs.Columns[6].Name = "";
            dataGridView_hs.Columns[7].Name = "";
            dataGridView_hs.Columns[8].Name = "";

            libhp.datagv_field_width(dataGridView_hs);

            dataGridView_hs.Rows.Insert(0, dataGridView_hs.Rows.Count + 1, txt_barcode2.Text, string.Empty, string.Empty, string.Empty, date, string.Empty, string.Empty, string1);  //
            dataGridView_hs.CurrentCell = dataGridView_hs.Rows[0].Cells[0];
            libhp.write_log(1, date, "", txt_barcode2.Text, "0", date);
            libhp.clean_control(txt_barcode2);
            libhp.display_control(pic_Export_Excel2);

        }

        private void OfflineForm_Load(object sender, EventArgs e)
        {
            string readerid = txt_readerid.Text;
            pic_tab_hist0.Enabled = false;
            pic_tab_hist0.Enabled = false;
            txt_barcode.Enabled = false;
        }

        private void OfflineForm_KeyDown(object sender, KeyEventArgs e)  //
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
                            MessageBox.Show("ID Number?", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            MessageBox.Show("ID Number?", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            MessageBox.Show("ID Number?", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            MessageBox.Show("ID Number?", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        btn_hs.Focus();
                        btn_hs_Click(sender, e);
                        break;
                    }
            }
        }

        private void pic_tab_lt0_Click(object sender, EventArgs e)  //
        {
            libhp.display_control(pic_tab_lt1, pic_tab_hist0, dataGridView_lt, label10, txt_barcode, pic_barcode);
            libhp.hide_control(pic_tab_lt0, pic_tab_hist1, dataGridView_hist);
            txt_barcode.Focus();
        }

        private void pic_tab_lt1_Click(object sender, EventArgs e)  //
        {
            libhp.display_control(pic_tab_lt1, pic_tab_hist0, dataGridView_lt, label10, txt_barcode, pic_barcode);
            libhp.hide_control(pic_tab_lt0, pic_tab_hist1, dataGridView_hist);
            txt_barcode.Focus();
        }
    }
}
