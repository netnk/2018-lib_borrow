using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace lib_borrow
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            using (FileStream fs = new FileStream("host.ini", FileMode.Open))
            {
                using (StreamReader rw = new StreamReader(fs))
                {
                    textBox1.Text = rw.ReadLine();  
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (FileStream fs = new FileStream("host.ini", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {                    
                    writer.WriteLine(textBox1.Text.Trim());  
                }
            }



            this.Close();

            
        }
    }
}
