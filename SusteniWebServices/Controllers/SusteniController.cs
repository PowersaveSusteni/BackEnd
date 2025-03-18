using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using static System.Net.Mime.MediaTypeNames;


public class ErrorItem
{
    public int ErrorCode { get; set; } = 0;
    public string Message { get; set; } = "";

}

namespace SusteniWebServices.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class SusteniController : ControllerBase
    {


        #region Generelle funksjoner



        //public void CsqlIS(ref string SQLQ, string strField, string strValue)
        //{
        //    int p1;
        //    int p2;
        //    int P3;
        //    string sqlData = "";
        //    int l;

        //    if (Information.IsDBNull(strValue))
        //        return;

        //    strValue = strValue.Trim();
        //    if (strValue == "")
        //        return;

        //    p1 = Strings.InStr(SQLQ, ")");
        //    p2 = Strings.InStr(SQLQ, "(");
        //    P3 = Strings.InStr(SQLQ, "values") + 7;
        //    l = Strings.Len(SQLQ);

        //    sqlData = "'" + strValue.Replace("'", "''") + "'";

        //    if (SQLQ.Length > 5 & (p1 > 0 & p2 > 0))
        //    {
        //        if (SQLQ.Substring(p2, 2) == "()")
        //            SQLQ = SQLQ.Substring(0, p1 - 1) + strField + ") values(" + SQLQ.Substring(p1 + 10, l - P3) + sqlData + ")";
        //        else
        //            SQLQ = SQLQ.Substring(0, p1 - 1) + "," + strField + ") values(" + SQLQ.Substring(p1 + 9, l - P3) + "," + sqlData + ")";
        //    }
        //}

        //public void CsqlII(ref string SQLQ, string strField, int Value)
        //{
        //    int p1;
        //    int p2;
        //    int P3;
        //    string sqlData = "";
        //    int l;

        //    if (Information.IsDBNull(Value))
        //        return;

        //    p1 = Strings.InStr(SQLQ, ")");
        //    p2 = Strings.InStr(SQLQ, "(");
        //    P3 = Strings.InStr(SQLQ, "values") + 7;
        //    l = Strings.Len(SQLQ);

        //    sqlData = Value.ToString().Replace(",", ".");

        //    if (SQLQ.Length > 5 & (p1 > 0 & p2 > 0))
        //    {
        //        if (SQLQ.Substring(p2, 2) == "()")
        //            SQLQ = SQLQ.Substring(0, p1 - 1) + strField + ") values(" + SQLQ.Substring(p1 + 10, l - P3) + sqlData + ")";
        //        else
        //            SQLQ = SQLQ.Substring(0, p1 - 1) + "," + strField + ") values(" + SQLQ.Substring(p1 + 9, l - P3) + "," + sqlData + ")";
        //    }
        //}


        #endregion

    }
}
