using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using lib_borrow;

namespace lib_borrow
{
    class sqlhp
    {
        lib_borrow.all_setting libhp = new all_setting();
       
       
        public string admin_login(string userid, string pwd)  
        {
            string host = libhp.ini_opacurl();
            string st = string.Format("server={0};database=database;User ID=user;Password=pwd;Trusted_Connection=false;",host);

            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("exec dbo.wsrv_checkadmi @id='{0}', @pwd='{1}';", userid, pwd);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                Checkadmi checkadmi = new Checkadmi();
                checkadmi.result = dt.Rows[0][0].ToString();
                checkadmi.msg = dt.Rows[0][1].ToString();
                checkadmi.userid = dt.Rows[0][2].ToString();
                checkadmi.location = dt.Rows[0][3].ToString();

                string result = JsonConvert.SerializeObject(checkadmi);

                return result;
            }


        }

        
        public string reader_login(string readerid)  
        {

            string host = libhp.ini_opacurl();
            string st = string.Format("server={0};database=database;User ID=user;Password=pwd;Trusted_Connection=false;", host);

            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string result = string.Empty;
                string sql = string.Format("exec dbo.wsrv_login @id='{0}', @pwd='', @needpwd=0;", readerid);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                int s = Convert.ToInt32(dt.Rows[0][0].ToString());

                switch (s)
                {
                    case 0:
                        {
                            Login login = new Login();
                            login.result = dt.Rows[0][0].ToString();
                            login.msg = dt.Rows[0][1].ToString();
                            login.reader01 = dt.Rows[0][13].ToString();
                            login.reader02 = dt.Rows[0][2].ToString();
                            login.reader72 = dt.Rows[0][4].ToString();
                            login.yxrq = dt.Rows[0][29].ToString();
                            login.yyrgnum = Convert.ToInt32(dt.Rows[0][34].ToString());
                            login.fk = Convert.ToSingle(dt.Rows[0][12].ToString());
                            login.tsk = Convert.ToInt32(dt.Rows[0][6].ToString());
                            login.tsy = Convert.ToInt32(dt.Rows[0][7].ToString());
                            login.fsk = Convert.ToInt32(dt.Rows[0][8].ToString());
                            login.fsy = Convert.ToInt32(dt.Rows[0][9].ToString());
                            login.qkk = Convert.ToInt32(dt.Rows[0][10].ToString());
                            login.qky = Convert.ToInt32(dt.Rows[0][11].ToString());

                            result = JsonConvert.SerializeObject(login);
                            return result;
                        }
                    default:
                        {
                            Login login = new Login();
                            login.result = dt.Rows[0][0].ToString();
                            login.msg = dt.Rows[0][1].ToString();
                            result = JsonConvert.SerializeObject(login);
                            return result;


                        }
                }


            }

        }


       
        public string borrow(string readerid, string barcode, string userid, string userlocation)
        {

            string host = libhp.ini_opacurl();
            string st = string.Format("server={0};database=database;User ID=user;Password=pwd;Trusted_Connection=false;", host);

            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("exec dbo.wsrv_borrow @reader01='{0}', @acce01='{1}', @hist15=0, @autosave=1, @clearborrortmp=1, @sent05='{2}', @hist13='{3}';", readerid, barcode, userid, userlocation);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                Borrow borrow = new Borrow();
                borrow.result = dt.Rows[0][0].ToString();
                borrow.msg = dt.Rows[0][1].ToString();
                borrow.datatype = dt.Rows[0][9].ToString();
                borrow.acce01 = dt.Rows[0][2].ToString();
                borrow.cata12 = dt.Rows[0][4].ToString();
                borrow.sent01 = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                borrow.sent02 = dt.Rows[0][3].ToString() + " 23:59";


                string result = JsonConvert.SerializeObject(borrow);
                return result;
            }

        }

       
        public string book_return(string barcode, string returntime, string userid, string userlocation)
        {
            string host = libhp.ini_opacurl();
            string st = string.Format("server={0};database=database;User ID=user;Password=pwd;Trusted_Connection=false;", host);


            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("exec dbo.wsrv_return @acce01='{0}', @i1=1, @i2=1, @autosave=1,@hist01 = '{1}', @sent06 = '{2}', @hist14='{3}',@returntype = 1, @stoptype=1;", barcode, returntime, userid, userlocation);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                Book_return book_return = new Book_return();
                book_return.result = dt.Rows[0][0].ToString();
                book_return.msg = dt.Rows[0][1].ToString();
                book_return.cata11 = dt.Rows[0][13].ToString();
                book_return.acce01 = dt.Rows[0][2].ToString();
                book_return.cata12 = dt.Rows[0][8].ToString();
                book_return.sent02 = dt.Rows[0][3].ToString() + " 23:59";
                book_return.hist01 = dt.Rows[0][4].ToString();
                book_return.overday = dt.Rows[0][19].ToString();
                book_return.hist03 = dt.Rows[0][6].ToString();

                string result = JsonConvert.SerializeObject(book_return);
                return result;
            }

        }

        
        public string book_hist(string readerid)
        {
            string host = libhp.ini_opacurl();
            string st = string.Format("server={0};database=database;User ID=user;Password=pwd;Trusted_Connection=false;", host);
            
            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("select top(25) ROW_NUMBER() OVER(ORDER BY sent01 desc) 'id' ,acce01 '',hcata12 '',cata13 '',Convert(varchar(20),sent01,120) as '',Convert(varchar(20),sent02,120) as '',Convert(varchar(20),hist01,120) as '' from hist where hreader01 = '{0}' order by id;", readerid);
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                string result = JsonConvert.SerializeObject(dt);
                return result;
            }
        }


    }
}
