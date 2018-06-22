using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using lib_borrow;
using Newtonsoft.Json;
using System.IO;

namespace lib_borrow
{
    public partial class Form2 : Form
    {
        lib_borrow.all_setting libhp = new all_setting();

        public Form2()
        {
            InitializeComponent();
            textBox1.Text = libhp.ini_opacurl();

            switch (libhp.ini_mode())
            {
                case "0":
                    {
                        radio_webservice.Checked = true;
                        textBox1.Text = libhp.ini_opacurl();
                        break;
                    }
                case "1":
                    {
                        radio_mssql.Checked = true;
                        textBox1.Text = libhp.ini_opacurl();
                        break;
                    }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radio_webservice.Checked)
            {
                libhp.write_url_json("0", textBox1.Text.Trim());
            }
            else
            {
                libhp.write_url_json("1", textBox1.Text.Trim());
            }

            this.Close();
        }
    }
}
