using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using lib_borrow;

namespace lib_borrow
{
    public partial class Form2 : Form
    {
        lib_borrow.all_setting libhp = new all_setting();

        public Form2()
        {
            InitializeComponent();
            libhp.ini_url();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            libhp.write_url(textBox1.Text.Trim());
            this.Close();            
        }
    }
}
