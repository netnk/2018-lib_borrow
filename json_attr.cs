using System;
using System.Collections.Generic;


public class SetHost
{
    public string mode { get; set; }
    public string host { get; set; }
    public string client { get; set; }
    
}

public class Checkadmi
{
    public string result { get; set; }
    public string msg { get; set; }
    public string userid { get; set; }
    public string location { get; set; }
}

public class Login
{
    public string result { get; set; }
    public string msg { get; set; }
    public string reader01 { get; set; }  
    public string reader02 { get; set; }  
    public string reader72 { get; set; }  //
    public string yxrq { get; set; }  //
    public int yyrgnum { get; set; }  //
    public float fk { get; set; }  //

    public int tsk { get; set; }  //
    public int tsy { get; set; }  //
    public int fsk { get; set; }  //
    public int fsy { get; set; }  //
    public int qkk { get; set; }  //
    public int qky { get; set; }  //
}


public class Borrow
{
    public string result { get; set; }
    public string msg { get; set; }
    public string datatype { get; set; }  //
    public string acce01 { get; set; }  //
    public string cata12 { get; set; }  //
    public string sent01 { get; set; }  //
    public string sent02 { get; set; }  //
}

public class Book_return
{
    public string result { get; set; }
    public string msg { get; set; }
    public string cata11 { get; set; }  //，, , 
    public string acce01 { get; set; }  //
    public string cata12 { get; set; }  //
    public string sacce48 { get; set; }  //
    public string sent02 { get; set; }  //
    public string hist01 { get; set; }  //
    public string overday { get; set; }  //
    public string hist03 { get; set; }  //
    public string sord04 { get; set; }  //
}


public class Book_hist
{
    public string acce01 { get; set; }
    public string hcata12 { get; set; }
    public string cata13 { get; set; }
    public string sent01 { get; set; }
    public string hist01 { get; set; }
}
