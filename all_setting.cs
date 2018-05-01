using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace lib_borrow
{
    class all_setting
    {
        public string ini_url()
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

        public string write_url(string str)
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


    }
}
