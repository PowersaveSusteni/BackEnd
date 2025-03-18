using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;


public class CustomerItem
{
    public string? CustomerGuid { get; set; } = "";
    public string CustomerName { get; set; } = "";
    public string? Adresse { get; set; } = "";
    public string? Zip { get; set; } = "";
    public string? City { get; set; } = "";
    public string? Phone { get; set; } = "";
    public string? EPost { get; set; } = "";
    public string? OrgNr { get; set; } = "";
    public string? Logo { get; set; } = "";
    public double OilPrice { get; set; } = 0;
    public string? CurrencyCode { get; set; } = "";
    public string? Byte64Picture { get; set; } = "";
    public int NumberLicense { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class ZipCityItem
{
    public string ZipCode { get; set; } = "";
    public string City { get; set; } = "";
    public string Country { get; set; } = "";

}

namespace SusteniWebServices.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {

        [Route("GetCustomer")]
        [HttpPost]
        public string GetCustomer(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT CustomerGuid, CustomerName, Adresse, Zip, Phone, EPost, OrgNr, Logo, OilPrice, CurrencyCode, Pictures.byte64Picture, NumberLicense " +
                "FROM Customer LEFT OUTER JOIN Pictures ON Customer.Logo=Pictures.PictureGuid ";
            if (logonInfo.Parameters.filter != null) { sql += " WHERE " + logonInfo.Parameters.filter; }

            CustomerItem item = new();

            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader rdr;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            cnn = new SqlConnection(conString);
            cnn.Open();

            cmd = new SqlCommand(sql, cnn);
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerGuid"))) { item.CustomerGuid = rdr.GetString(rdr.GetOrdinal("CustomerGuid")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerName"))) { item.CustomerName = rdr.GetString(rdr.GetOrdinal("CustomerName")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Adresse"))) { item.Adresse = rdr.GetString(rdr.GetOrdinal("Adresse")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Zip"))) { item.Zip = rdr.GetString(rdr.GetOrdinal("Zip")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Phone"))) { item.Phone = rdr.GetString(rdr.GetOrdinal("Phone")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("EPost"))) { item.EPost = rdr.GetString(rdr.GetOrdinal("EPost")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("OrgNr"))) { item.OrgNr = rdr.GetString(rdr.GetOrdinal("OrgNr")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("CurrencyCode"))) { item.CurrencyCode = rdr.GetString(rdr.GetOrdinal("CurrencyCode")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Logo"))) { item.Logo = rdr.GetString(rdr.GetOrdinal("Logo")); }                
                if (!rdr.IsDBNull(rdr.GetOrdinal("OilPrice"))) { item.OilPrice = Convert.ToDouble(rdr.GetValue(rdr.GetOrdinal("OilPrice"))); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("NumberLicense"))) { item.NumberLicense = rdr.GetInt16(rdr.GetOrdinal("NumberLicense")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("byte64Picture"))) { item.Byte64Picture = rdr.GetString(rdr.GetOrdinal("byte64Picture")); }
            }

            string output = JsonConvert.SerializeObject(item);

           return output;
        }

        [Route("SetCustomer")]
        [HttpPost]
        public string SetCustomer(CustomerItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();

            ReturnValueItem retur = new();
            retur.Status = 1;

            logonInfo = item.logonInfo;

            if (item.CustomerGuid == null)
            {
                string customerGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO Customer() Values()";


                CsqlIS(ref sql, "CustomerGuid", customerGuid);
                CsqlIS(ref sql, "CustomerName", item.CustomerName);
                CsqlIS(ref sql, "Adresse", item.Adresse);
                CsqlIS(ref sql, "Zip", item.Zip);
                CsqlIS(ref sql, "City", item.City);
                CsqlIS(ref sql, "Phone", item.Phone);
                CsqlIS(ref sql, "EPost", item.EPost);
                CsqlIS(ref sql, "OrgNr", item.OrgNr);
                CsqlIS(ref sql, "Logo", item.Logo);
                CsqlIS(ref sql, "CurrencyCode", item.CurrencyCode);
                CsqlIF(ref sql, "OilPrice", item.OilPrice);
                CsqlII(ref sql, "NumberLicense", item.NumberLicense);

                sql += ";UPDATE Users SET AktivCustomerGuid='" + customerGuid + "' WHERE UserId = '" + logonInfo.UserId + "'";
            }
            else
            {
                CustomerItem itemOld = new();
                itemOld = GetCustomerInternal(logonInfo, item.CustomerGuid);
                sql = "UPDATE Customer SET WHERE CustomerGuid ='" + item.CustomerGuid + "'"; 
                CsqlUS(ref sql, "CustomerName", item.CustomerName, itemOld.CustomerName);
                CsqlUS(ref sql, "Adresse", item.Adresse, itemOld.Adresse);
                CsqlUS(ref sql, "Zip", item.Zip, itemOld.Zip);
                CsqlUS(ref sql, "City", item.City, itemOld.City);
                CsqlUS(ref sql, "Phone", item.Phone, itemOld.Phone);
                CsqlUS(ref sql, "EPost", item.EPost, itemOld.EPost);
                CsqlUS(ref sql, "OrgNr", item.OrgNr, itemOld.OrgNr);
                CsqlUS(ref sql, "Logo", item.Logo, itemOld.Logo);
                CsqlUS(ref sql, "CurrencyCode", item.CurrencyCode, itemOld.CurrencyCode);
                CsqlUF(ref sql, "OilPrice", item.OilPrice, itemOld.OilPrice);
                CsqlUI(ref sql, "NumberLicense", item.NumberLicense, itemOld.NumberLicense);
            }


            SqlConnection cnn;
            SqlCommand cmd;

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            cnn = new SqlConnection(conString);
            cnn.Open();

            SqlTransaction transaction = cnn.BeginTransaction();

            cmd = new SqlCommand(sql, cnn);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 1000;

            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                retur.Status = -20;
                retur.Description = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        private CustomerItem GetCustomerInternal(AccountLogOnInfoItem logonInfo, string CustomerGuid)
        {
            string conString;

            string sql = "SELECT CustomerGuid, CustomerName, Adresse, Zip, Phone, EPost, OrgNr, Logo, OilPrice, NumberLicense FROM Customer WHERE CustomerGuid = '" + CustomerGuid + "'";

            CustomerItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerGuid"))) { item.CustomerGuid = rdr.GetString(rdr.GetOrdinal("CustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerName"))) { item.CustomerName = rdr.GetString(rdr.GetOrdinal("CustomerName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Adresse"))) { item.Adresse = rdr.GetString(rdr.GetOrdinal("Adresse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Zip"))) { item.Zip = rdr.GetString(rdr.GetOrdinal("Zip")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Phone"))) { item.Phone = rdr.GetString(rdr.GetOrdinal("Phone")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EPost"))) { item.EPost = rdr.GetString(rdr.GetOrdinal("EPost")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OrgNr"))) { item.OrgNr = rdr.GetString(rdr.GetOrdinal("OrgNr")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Logo"))) { item.Logo = rdr.GetString(rdr.GetOrdinal("Logo")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OilPrice"))) { item.OilPrice = Convert.ToDouble(rdr.GetValue(rdr.GetOrdinal("OilPrice"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumberLicense"))) { item.NumberLicense = rdr.GetInt16(rdr.GetOrdinal("NumberLicense")); }
                        
                    }
                }
            }

            return item;
        }


        [Route("GetCustomerList")]
        [HttpPost]
        public string GetCustomerList(AccountLogOnInfoItem logonInfo)
        {
            string conString;
            string sql = "SELECT CustomerGuid, CustomerName, Adresse, Zip, Phone, EPost, OrgNr, Logo FROM Customer ";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            List<CustomerItem> items = new();

            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader rdr;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            cnn = new SqlConnection(conString);
            cnn.Open();

            cmd = new SqlCommand(sql, cnn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                CustomerItem item = new();
                if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerGuid"))) { item.CustomerGuid = rdr.GetString(rdr.GetOrdinal("CustomerGuid")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerName"))) { item.CustomerName = rdr.GetString(rdr.GetOrdinal("CustomerName")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Adresse"))) { item.Adresse = rdr.GetString(rdr.GetOrdinal("Adresse")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Zip"))) { item.Zip = rdr.GetString(rdr.GetOrdinal("Zip")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Phone"))) { item.Phone = rdr.GetString(rdr.GetOrdinal("Phone")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("EPost"))) { item.EPost = rdr.GetString(rdr.GetOrdinal("EPost")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("OrgNr"))) { item.OrgNr = rdr.GetString(rdr.GetOrdinal("OrgNr")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Logo"))) { item.Logo = rdr.GetString(rdr.GetOrdinal("Logo")); }
                items.Add(item);
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("RemoveCustomer")]
        [HttpPost]
        public string RemoveCustomer(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "DELETE FROM Customer WHERE " + logonInfo.Parameters.filter;

            ReturnValueItem retur = new();

            SqlConnection cnn;
            SqlCommand cmd;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            cnn = new SqlConnection(conString);
            cnn.Open();

            cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("GetCity")]
        [HttpPost]
        public string GetCity(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT City, Country FROM Citys INNER JOIN Country ON Citys.CountryCode=Country.CountryCode ";
            if (logonInfo.Parameters.filter != null) { sql += " WHERE " + logonInfo.Parameters.filter; }

            ZipCityItem item = new();

            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader rdr;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            cnn = new SqlConnection(conString);
            cnn.Open();

            cmd = new SqlCommand(sql, cnn);
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("City"))) { item.City = rdr.GetString(rdr.GetOrdinal("City")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Country"))) { item.Country = rdr.GetString(rdr.GetOrdinal("Country")); }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }


        [Route("SetLogo")]
        [HttpPost]
        public string SetLogo(FilerItem item)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            if (item.byte64string.Substring(0, 4) == "data")
            {
                item.byte64string = item.byte64string.Substring(item.byte64string.IndexOf("base64") + 7);
            }

            string pictureGuid = Guid.NewGuid().ToString();

            sql = "INSERT INTO Pictures() VALUES()";
            CsqlIS(ref sql, "PictureGuid", pictureGuid);
            CsqlIS(ref sql, "LinkGuid", item.LinkGuid);
            CsqlIS(ref sql, "byte64Picture", item.byte64string);

            sql += ";UPDATE Customer SET Logo='" + pictureGuid + "' WHERE CustomerGuid='" + item.LinkGuid + "'";

            SqlConnection cnn;
            SqlCommand cmd;

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            cnn = new SqlConnection(conString);
            cnn.Open();

            SqlTransaction transaction = cnn.BeginTransaction();

            cmd = new SqlCommand(sql, cnn);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 1000;

            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                retur.Status = -1;
                retur.Description = ex.Message; 
                transaction.Rollback();
            }


            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        #region Generelle funksjoner

        private int GetNextValue(AccountLogOnInfoItem logonInfo, string Tabell, string Felt, string Where)
        {
            int lngVerdi = 0;

            string conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                SqlCommand cmd;
                SqlDataReader rdr;

                cnn.Open();
                string sql = "";


                if (Where.Length > 0)
                    sql = "SELECT Max(" + Felt + ") FROM " + Tabell + " WHERE " + Where;

                lngVerdi = -1;

                try
                {
                    cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 1000;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                            lngVerdi = Convert.ToInt32(rdr.GetValue(0));
                        else
                            lngVerdi = 0;
                    }

                    lngVerdi += 1;
                }
                catch (SqlException ex)
                {
                    var st = new StackTrace(ex, true);
                }

            }

            return lngVerdi;
        }


        private string ReadValue(AccountLogOnInfoItem logonInfo, string sql)
        {
            string retur = "";

            string conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                SqlCommand cmd;
                SqlDataReader rdr;

                cnn.Open();

                try
                {
                    cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 1000;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0)) retur = rdr.GetString(0);
                    }
                }
                catch (SqlException ex)
                {
                    var st = new StackTrace(ex, true);
                }

            }

            return retur;
        }

        private void CsqlIS(ref string SQLQ, string strField, string? strValue)
        {
            int p1;
            int p2;
            int P3;
            string sqlData = "";
            int l;

            if (strValue == null)
                return;

            strValue = strValue.Trim();
            if (strValue == "")
                return;

            p1 = Strings.InStr(SQLQ, ")");
            p2 = Strings.InStr(SQLQ, "(");
            P3 = Strings.InStr(SQLQ, "values") + 7;
            l = Strings.Len(SQLQ);

            sqlData = "'" + strValue.Replace("'", "''") + "'";

            if (SQLQ.Length > 5 & (p1 > 0 & p2 > 0))
            {
                if (SQLQ.Substring(p2 - 1, 2) == "()")
                    SQLQ = SQLQ.Substring(0, p1 - 1) + strField + ") values(" + sqlData + ")";
                else
                    SQLQ = SQLQ.Substring(0, p1 - 1) + "," + strField + ") values(" + SQLQ.Substring(p1 + 8, l - P3) + "," + sqlData + ")";
            }
        }

        private void CsqlII(ref string SQLQ, string strField, int Value)
        {
            int p1;
            int p2;
            int P3;
            string sqlData = "";
            int l;

            if (Information.IsDBNull(Value))
                return;

            p1 = Strings.InStr(SQLQ, ")");
            p2 = Strings.InStr(SQLQ, "(");
            P3 = Strings.InStr(SQLQ, "values") + 7;
            l = Strings.Len(SQLQ);

            sqlData = Value.ToString().Replace(",", ".");

            if (SQLQ.Length > 5 & (p1 > 0 & p2 > 0))
            {
                if (SQLQ.Substring(p2, 2) == "()")
                    SQLQ = SQLQ.Substring(0, p1 - 1) + strField + ") values(" + sqlData + ")";
                else
                    SQLQ = SQLQ.Substring(0, p1 - 1) + "," + strField + ") values(" + SQLQ.Substring(p1 + 8, l - P3) + "," + sqlData + ")";
            }
        }

        private void CsqlIB(ref string SQLQ, string strField, bool bolValue)
        {
            int p1;
            int p2;
            int P3;
            string sqlData = "";
            string strValue = "";

            int l;

            if (Information.IsDBNull(strValue))
                return;

            p1 = Strings.InStr(SQLQ, ")");
            p2 = Strings.InStr(SQLQ, "(");
            P3 = Strings.InStr(SQLQ, "values") + 7;
            l = Strings.Len(SQLQ);

            if (bolValue == true)
                strValue = "1";
            else
                strValue = "0";


            if (SQLQ.Length > 5 & (p1 > 0 & p2 > 0))
            {
                if (SQLQ.Substring(p2 - 1, 2) == "()")
                    SQLQ = SQLQ.Substring(0, p1 - 1) + strField + ") values(" + sqlData + ")";
                else
                    SQLQ = SQLQ.Substring(0, p1 - 1) + "," + strField + ") values(" + SQLQ.Substring(p1 + 8, l - P3) + "," + strValue + ")";
            }
        }

        private void CsqlIF(ref string SQLQ, string strField, float fltValue)
        {
            int p1;
            int p2;
            int P3;
            string sqlData = "";
            int l;

            if (Information.IsDBNull(fltValue))
                return;

            p1 = Strings.InStr(SQLQ, ")");
            p2 = Strings.InStr(SQLQ, "(");
            P3 = Strings.InStr(SQLQ, "values") + 7;
            l = Strings.Len(SQLQ);

            sqlData = fltValue.ToString().Replace(",", ".");

            if (SQLQ.Length > 5 & (p1 > 0 & p2 > 0))
            {
                if (SQLQ.Substring(p2 - 1, 2) == "()")
                    SQLQ = SQLQ.Substring(0, p1 - 1) + strField + ") values(" + sqlData + ")";
                else
                    SQLQ = SQLQ.Substring(0, p1 - 1) + "," + strField + ") values(" + SQLQ.Substring(p1 + 8, l - P3) + "," + sqlData + ")";
            }
        }

        private void CsqlIF(ref string SQLQ, string strField, double fltValue)
        {
            int p1;
            int p2;
            int P3;
            string sqlData = "";
            int l;

            if (Information.IsDBNull(fltValue))
                return;

            p1 = Strings.InStr(SQLQ, ")");
            p2 = Strings.InStr(SQLQ, "(");
            P3 = Strings.InStr(SQLQ, "values") + 7;
            l = Strings.Len(SQLQ);

            sqlData = fltValue.ToString().Replace(",", ".");

            if (SQLQ.Length > 5 & (p1 > 0 & p2 > 0))
            {
                if (SQLQ.Substring(p2 - 1, 2) == "()")
                    SQLQ = SQLQ.Substring(0, p1 - 1) + strField + ") values(" + sqlData + ")";
                else
                    SQLQ = SQLQ.Substring(0, p1 - 1) + "," + strField + ") values(" + SQLQ.Substring(p1 + 8, l - P3) + "," + sqlData + ")";
            }
        }
        private void CsqlID(ref string SQLQ, string strField, string strType, DateTime dtValue)
        {
            int p1;
            int p2;
            int P3;
            string sqlData = "";
            int l;

            if (Information.IsDBNull(dtValue))
                return;

            if (Information.IsDate(dtValue) && dtValue.Year <= 1753)
                return;

            p1 = Strings.InStr(SQLQ, ")");
            p2 = Strings.InStr(SQLQ, "(");
            P3 = Strings.InStr(SQLQ, "values") + 7;
            l = Strings.Len(SQLQ);

            switch (strType)
            {
                case "D":
                    {
                        sqlData = "'" + dtValue.ToString("yyyy-MM-dd") + "T00:00:00' ";
                        break;
                    }

                case "T":
                    {
                        sqlData = "'" + dtValue.ToString("yyyy-MM-dd") + "T" + dtValue.ToString("HH:mm:ss") + "'";
                        break;
                    }
            }

            if (SQLQ.Length > 5 & (p1 > 0 & p2 > 0))
            {
                if (SQLQ.Substring(p2 - 1, 2) == "()")
                    SQLQ = SQLQ.Substring(0, p1 - 1) + strField + ") values(" + sqlData + ")";
                else
                    SQLQ = SQLQ.Substring(0, p1 - 1) + "," + strField + ") values(" + SQLQ.Substring(p1 + 8, l - P3) + "," + sqlData + ")";
            }
        }


        private void CsqlUS(ref string SQLQ, string strField, string? strValue, string? strOldValue)
        {
            int p1;
            int p2;
            string sqlData = "";
            int l;
            string strWhere;
            string strNewSQL = "";
            string strTekst;

            if (strValue == null) { strValue = ""; }

            if (Information.IsNothing(strOldValue))
                strOldValue = "";
            if (Information.IsNothing(strValue))
                strValue = "";

            if (strValue == strOldValue)
                return;


            strTekst = strValue;


            p1 = Strings.InStrRev(SQLQ, "WHERE");
            p2 = Strings.InStr(SQLQ, "SET");
            l = Strings.Len(SQLQ);
            strWhere = SQLQ.Substring(p1 - 1);
            strNewSQL = SQLQ.Substring(0, p1 - 1);


            if (strTekst == null)
                strTekst = "";

            if (strTekst.Length == 0)
                sqlData = "," + strField + "=NULL ";
            else
            {
                sqlData = "," + strField + "='" + strValue.Replace("'", "''") + "' ";
            }

            if (p1 - p2 == 4)
                SQLQ = sqlData.Substring(1);
            else
                SQLQ = sqlData;

            strNewSQL = string.Concat(strNewSQL, SQLQ, strWhere);
            SQLQ = strNewSQL;
        }

        private void CsqlUB(ref string SQLQ, string strField, bool bolValue, bool bolOldValue)
        {
            int p1;
            int p2;
            string sqlData = "";
            int l;
            string strWhere;
            string strNewSQL = "";


            if (bolValue == bolOldValue)
                return;

            p1 = Strings.InStrRev(SQLQ, "WHERE");
            p2 = Strings.InStr(SQLQ, "SET");
            l = Strings.Len(SQLQ);
            strWhere = SQLQ.Substring(p1 - 1);
            strNewSQL = SQLQ.Substring(0, p1 - 1);

            if (bolOldValue == true)
                sqlData = "1";
            else
                sqlData = "0";

            sqlData = "," + strField + "=" + sqlData + " ";

            if (p1 - p2 == 4)
                SQLQ = sqlData.Substring(1);
            else
                SQLQ = sqlData;

            strNewSQL = string.Concat(strNewSQL, SQLQ, strWhere);
            SQLQ = strNewSQL;
        }

        private void CsqlUI(ref string SQLQ, string strField, int intValue, int intOldValue)
        {
            int p1;
            int p2;
            string sqlData = "";
            int l;
            string strWhere;
            string strNewSQL = "";

            if (intValue == intOldValue)
                return;

            p1 = Strings.InStrRev(SQLQ, "WHERE");
            p2 = Strings.InStr(SQLQ, "SET");
            l = Strings.Len(SQLQ);
            strWhere = SQLQ.Substring(p1 - 1);
            strNewSQL = SQLQ.Substring(0, p1 - 1);


            sqlData = "," + strField + "=" + intValue.ToString().Replace(",", ".") + " ";

            if (p1 - p2 == 4)
                SQLQ = sqlData.Substring(1);
            else
                SQLQ = sqlData;

            strNewSQL = string.Concat(strNewSQL, SQLQ, strWhere);
            SQLQ = strNewSQL;
        }

        private void CsqlUF(ref string SQLQ, string strField, float fltValue, float fltOldValue)
        {
            int p1;
            int p2;
            string sqlData = "";
            int l;
            string strWhere;
            string strNewSQL = "";

            if (fltValue == fltOldValue)
                return;

            p1 = Strings.InStrRev(SQLQ, "WHERE");
            p2 = Strings.InStr(SQLQ, "SET");
            l = Strings.Len(SQLQ);
            strWhere = SQLQ.Substring(p1 - 1);
            strNewSQL = SQLQ.Substring(0, p1 - 1);


            sqlData = "," + strField + "=" + fltValue.ToString().Replace(",", ".") + " ";

            if (p1 - p2 == 4)
                SQLQ = sqlData.Substring(1);
            else
                SQLQ = sqlData;

            strNewSQL = string.Concat(strNewSQL, SQLQ, strWhere);
            SQLQ = strNewSQL;
        }
        private void CsqlUF(ref string SQLQ, string strField, double fltValue, double fltOldValue)
        {
            int p1;
            int p2;
            string sqlData = "";
            int l;
            string strWhere;
            string strNewSQL = "";

            if (fltValue == fltOldValue)
                return;

            p1 = Strings.InStrRev(SQLQ, "WHERE");
            p2 = Strings.InStr(SQLQ, "SET");
            l = Strings.Len(SQLQ);
            strWhere = SQLQ.Substring(p1 - 1);
            strNewSQL = SQLQ.Substring(0, p1 - 1);


            sqlData = "," + strField + "=" + fltValue.ToString().Replace(",", ".") + " ";

            if (p1 - p2 == 4)
                SQLQ = sqlData.Substring(1);
            else
                SQLQ = sqlData;

            strNewSQL = string.Concat(strNewSQL, SQLQ, strWhere);
            SQLQ = strNewSQL;
        }

        private void CsqlUD(ref string SQLQ, string strField, string strType, DateTime dtValue, DateTime dtOldValue)
        {
            int p1;
            int p2;
            int p3;

            string sqlData = "";
            int l;
            string strWhere;
            string strNewSQL = "";

            if (dtValue == dtOldValue)
                return;

            p1 = Strings.InStrRev(SQLQ, "WHERE");
            p2 = Strings.InStr(SQLQ, "SET");
            p3 = Strings.InStr(SQLQ, "values") + 7;

            l = Strings.Len(SQLQ);
            strWhere = SQLQ.Substring(p1);
            strNewSQL = SQLQ.Substring(0, p1 - 1);

            switch (strType)
            {
                case "D":
                    {
                        if (dtValue.Year > 1800)
                            sqlData = "," + strField + "='" + dtValue.ToString("yyyy-MM-dd") + "' ";
                        else
                            sqlData = "," + strField + "=NULL ";
                        break;
                    }

                case "T":
                    {
                        if (dtValue.Year > 1800)
                            sqlData = "," + strField + "='" + dtValue.ToString("yyyy-MM-dd") + "T" + dtValue.ToString("HH:mm:ss") + "' ";
                        else
                            sqlData = "," + strField + "=NULL ";
                        break;
                    }
            }

            if (SQLQ.Length > 5 & (p1 > 0 & p2 > 0))
            {
                if (SQLQ.Substring(p2 - 1, 2) == "()")
                    SQLQ = SQLQ.Substring(0, p1 - 1) + strField + ") values(" + sqlData + ")";
                else
                    SQLQ = SQLQ.Substring(0, p1 - 1) + "," + strField + ") values(" + SQLQ.Substring(p1 + 8, l - p3) + "," + sqlData + ")";
            }
        }

        #endregion


    }

}
