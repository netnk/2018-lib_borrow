using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Data;
using System.Windows.Forms;
using NPOI;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Diagnostics;
using Newtonsoft.Json;


namespace lib_borrow
{
    class all_setting
    {
        public string ini_opacurl()  //
        {
            using (FileStream fs = new FileStream("setting.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    SetHost m = JsonConvert.DeserializeObject<SetHost>(sr.ReadLine());
                    string result = m.host;
                    return result;
                }
            }
        }

        public string ini_mode()  //
        {
            using (FileStream fs = new FileStream("setting.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    SetHost m = JsonConvert.DeserializeObject<SetHost>(sr.ReadLine());
                    string result = m.mode;
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

        public string write_url_json(string mode, string host)  //
        {
            using (FileStream fs = new FileStream("setting.json", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    SetHost sh = new SetHost();
                    sh.mode = mode;
                    sh.host = host;
                    sh.client = GetMyIp();

                    string str = JsonConvert.SerializeObject(sh);
                    writer.WriteLine(str);
                    return string.Empty;
                }
            }
        }

        public string getservice(string url)  //
        {
            url = UrlEncode(url);
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                string result = wc.DownloadString(url);
                return result;
            }
        }

        public string UrlEncode(string url)  //
        {
            url = HttpUtility.UrlEncode(url);
            url = url.Replace("%3a", ":");
            url = url.Replace("%2f", "/");
            url = url.Replace("%3f", "?");
            url = url.Replace("%3d", "=");
            url = url.Replace("%26", "&");
            url = url.Replace("%3c", "");
            url = url.Replace("%3e", "");
            return url;
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

        public void write_log(int behavior, string sent01, string readerid, string barcode, string sacce48, string sent02)  //
        {
            switch (behavior)
            {
                case 0:  //borrow
                    {
                        string date = DateTime.Now.ToString("yyyy-MM-dd");
                        using (StreamWriter writer = new StreamWriter(string.Format("./log/{0}_borrow.txt",date), true))
                        {
                            string result = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", sent01, behavior, readerid, barcode, sacce48, sent02);
                            writer.WriteLine(result);
                        }

                        break;
                    }
                case 1:  //return
                    {
                        string date = DateTime.Now.ToString("yyyy-MM-dd");
                        using (StreamWriter writer = new StreamWriter(string.Format("./log/{0}_return.txt",date), true))
                        {
                            string result = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", sent01, behavior, readerid, barcode, "", sent02);
                            writer.WriteLine(result);
                        }

                        break;
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

        public void hide_control(params Control[] ctols)  //
        {
            //Reference
            //https://dotblogs.com.tw/kyleshen/2013/10/10/123562

            foreach (Control ctol in ctols)
            {
                ctol.Visible = false;
            }
        }

        public void datagv_color_format(DataGridViewCellFormattingEventArgs formatting)  //
        {
            if (formatting.Value != null)
            {
                formatting.CellStyle.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void datagv_format(params DataGridView[] datagvs)  //
        {
            foreach (DataGridView datagv in datagvs)
            {
                datagv.EnableHeadersVisualStyles = false;
                datagv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                datagv.ReadOnly = true;
                datagv.RowHeadersVisible = false;
                datagv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                datagv.GridColor = System.Drawing.Color.White;
                datagv.AllowUserToAddRows = false;
                datagv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                datagv.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12);
                datagv.BorderStyle = System.Windows.Forms.BorderStyle.None;

                if (datagv.Name == "dataGridView_lt")
                {
                    datagv.Size = new System.Drawing.Size(960, 350);
                }
                else
                {
                    datagv.Size = new System.Drawing.Size(960, 393);
                }
            }
        }

        public void datagv_clean(params DataGridView[] datagvs)  //
        {
            foreach (DataGridView datagv in datagvs)
            {
                if (datagv.Name == "dataGridView_hist")
                {
                    datagv.DataSource = null;
                }
                else
                {
                    datagv.Rows.Clear();
                    datagv.Columns.Clear();
                }

            }
        }

        public void datagv_field_width(params DataGridView[] datagvs)  //
        {
            foreach (DataGridView datagv in datagvs)
            {

                datagv.Columns[0].Width = 30;  //;

                for (int i = 1; i < datagv.Columns.Count; i++)
                {
                    if (datagv.Columns[i].Name == "" || datagv.Columns[i].Name == "")
                    {
                        datagv.Columns[i].Width = 90;
                    }
                    else if (datagv.Columns[i].Name == "")
                    {
                        datagv.Columns[i].Width = 130;
                    }
                    else if (datagv.Columns[i].Name == "" || datagv.Columns[i].Name == "" || datagv.Columns[i].Name == "")
                    {
                        datagv.Columns[i].Width = 70;
                    }

                }

            }
        }

        public DataTable TXT_To_DataTable(string file)  //
        {
            //Ref:
            //http://einboch.pixnet.net/blog/post/244504010-%E7%B4%94%E6%96%87%E5%AD%97%E6%AA%94%E6%A1%88%28%E4%BE%8B%E5%A6%82%3Atxt%2Ccsv%29%E8%BD%89%E6%88%90datatable%E7%9A%84%E6%96%B9%E6%B3%95

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            StreamReader sr = new StreamReader(file, System.Text.Encoding.Default);
           
            ds.Tables.Add("jack1");

            ds.Tables["jack1"].Columns.Add("", typeof(string));
            ds.Tables["jack1"].Columns.Add("", typeof(string));
            ds.Tables["jack1"].Columns.Add("", typeof(string));
            ds.Tables["jack1"].Columns.Add("", typeof(string));
            ds.Tables["jack1"].Columns.Add("", typeof(string));
            ds.Tables["jack1"].Columns.Add("", typeof(string));


            string Alldata = sr.ReadToEnd();
            string[] rows = Alldata.Split('\n');
            
            foreach (string r in rows)
            {
                string[] items = r.Split('\t');
                ds.Tables["jack1"].Rows.Add(items);
            }

            sr.Close();
            dt = ds.Tables[0];
            
            return dt;
        }

        public void DataTableToExcel(DataTable dt, string behavior)  //
        {
            //Ref:
            //http://einboch.pixnet.net/blog/post/274497938-%E4%BD%BF%E7%94%A8npoi%E7%94%A2%E7%94%9Fexcel%E6%AA%94%E6%A1%88

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            IWorkbook wb = new XSSFWorkbook();
            ISheet ws;
            ws = wb.CreateSheet("Sheet1");

            ws.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ws.GetRow(0).CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ws.GetRow(i + 1).CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            using (FileStream fs = new FileStream(string.Format("./xls/{0}_{1}_offline.xlsx",date, behavior), FileMode.Create))
            {
                wb.Write(fs);
                fs.Close();
            }
        }

        public string GetMyIp()  //
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "ipconfig.exe";    
            cmd.StartInfo.Arguments = "/all";       
                                                    
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.CreateNoWindow = true;

            cmd.Start();
            string info = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
            cmd.Close();

            if (info.IndexOf("IPv4 Address. . . . . . . . . . . :") > -1)
            {
                int info_start = info.IndexOf("IPv4 Address. . . . . . . . . . . :") + 36;
                int info_end = info.IndexOf("(", info_start);

                return info.Substring(info_start, info_end - info_start);
            }
            else
            {
                int info_start = info.IndexOf("IPv4 位址 . . . . . . . . . . . . :") + 34;
                int info_end = info.IndexOf("(", info_start);

                return info.Substring(info_start, info_end - info_start);
            }

           
        }  

    }
}
