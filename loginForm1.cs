using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using lib_borrow;

namespace lib_borrow
{
    public partial class loginForm1 : Form
    {
        lib_borrow.all_setting libhp = new all_setting();
        lib_borrow.sqlhp sqlhp = new lib_borrow.sqlhp();

        public loginForm1()
        {
            InitializeComponent();

            pic_url_setting.BackColor = Color.Transparent;
            pic_url_setting.Parent = this.panel_bg_pic;
            //MessageBox.Show(libhp.GetMyIp());
            lbl_myipx.Text = string.Format(libhp.GetMyIp());
            lbl_opacurl.Text = string.Format(libhp.ini_opacurl());
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
            if (checkBox1.Checked)
            {
                string id = txt_userid.Text.Trim();
                if (id == string.Empty || id == null)
                {
                    MessageBox.Show("ERROR", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_userid.Focus();
                    return;
                }
                else
                {
                    OfflineForm frm1 = new OfflineForm();
                    this.Hide();
                    frm1.String1 = id;
                    frm1.SetValue();
                    frm1.Show();
                }
            }
            else
            {

                if (txt_userid.Text.Trim() == string.Empty || txt_userid.Text.Trim() == null)
                {
                    MessageBox.Show("ERROR", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_userid.Focus();
                    return;
                }

                workingForm1 frm = new workingForm1();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
                frm.BringToFront();

                string opacurl = libhp.ini_opacurl();
                string id = txt_userid.Text.Trim();
                string pwd = txt_pwd.Text.Trim();
                string url = string.Format("http://{0}/getservice.ashx?mode=1&userid={1}&pwd={2}", opacurl, id, pwd);

                try
                {
                    string get = string.Empty;
                    
                    if (libhp.ini_mode() == "0")
                    {
                        get = libhp.getservice(url);
                    }
                    else
                    {                       
                        get = sqlhp.admin_login(id, pwd);
                    }
                    

                    Checkadmi m = JsonConvert.DeserializeObject<Checkadmi>(get);

                    switch (m.result.ToString())
                    {
                        case "0":
                            {
                                frm.Close();

                                Form1 frm1 = new Form1();
                                this.Hide();
                                frm1.String1 = m.userid;
                                frm1.String2 = m.location;
                                frm1.String3 = id;
                                frm1.SetValue();
                                frm1.Show();

                                break;
                            }
                        default:
                            {
                                Thread.Sleep(1000);
                                frm.Close();
                                MessageBox.Show(m.msg.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                libhp.clean_control(txt_userid, txt_pwd);
                                txt_userid.Focus();
                                break;
                            }
                    }
                }
                catch
                {
                    Thread.Sleep(10000);
                    MessageBox.Show("ERROR", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
            }


        }

        private void txt_userid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                pic_login.Focus();
                pictureBox2_Click(sender, e);
            }

        }

        private void txt_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                pic_login.Focus();
                pictureBox2_Click(sender, e);
            }
        }
    }
}
