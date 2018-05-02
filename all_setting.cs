using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace lib_borrow
{
    class all_setting
    {
        public string ini_url()  // URL
        {
            using (FileStream fs = new FileStream("host.ini", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string result = sr.ReadLine();
                    return result;
                }
            }
        }  

        public string write_url(string str)  //
        {
            using (FileStream fs = new FileStream("host.ini", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(str);
                    return string.Empty;
                }
            }
        }  

        public string getservice(string url)  //
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                string result = wc.DownloadString(url);
                return result;
            }
        }  

        public void clean_control(params Control[] ctols)  //
        {

            //Reference
            //https://dotblogs.com.tw/kyleshen/2013/10/10/123562

            foreach (Control ctol in ctols)
            {
                if (ctol.Name == "lbl_tsk" || ctol.Name == "lbl_tsy" || ctol.Name == "lbl_fsk" || ctol.Name == "lbl_fsy" || ctol.Name == "lbl_qkk" || ctol.Name == "lbl_qky")
                {
                    ctol.Text = "0";
                }                
                else
                {
                    ctol.Text = string.Empty;
                }
               
            }       
        }      

        public string write_log(string str)  //
        {
            using (FileStream fs = new FileStream("log.txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(str);
                    return string.Empty;
                }
            }
        }

        public void display_control(params Control[] ctols)  //
        {
            //Reference
            //https://dotblogs.com.tw/kyleshen/2013/10/10/123562

            foreach (Control ctol in ctols)
            {
                ctol.Visible = true;
            }
        }

    }
}
