using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
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

        public string write_url(string str)  //寫入INI檔用
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

        public void clean_control(params Control[] ctols)  //切換畫面時清除控制項
        {

            //Reference
            //https://dotblogs.com.tw/kyleshen/2013/10/10/123562

            foreach (Control ctol in ctols)
            {
                if (ctol.Name == "control_name" || ctol.Name == "control_name" || ctol.Name == "control_name" || ctol.Name == "control_name" || ctol.Name == "control_name" || ctol.Name == "control_name")
                {
                    ctol.Text = "0";
                }
                else
                {
                    ctol.Text = string.Empty;
                }
               
            }       
        }

    }
}
