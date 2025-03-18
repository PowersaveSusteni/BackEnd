using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Services.CircuitBreaker;
using Microsoft.VisualStudio.Services.Common;
using Newtonsoft.Json;
using OtpNet;
using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

public class AccountSignedInItem
{
    public string CustomId { get; set; } = "";
    public string CurrencyCode { get; set; } = "";
    public string CustomLogo { get; set; } = "";
    public string UserId { get; set; } = "";
    public string UserName { get; set; } = "";
    public int SuperAdmin { get; set; } = 0;
    public int SuperBruker { get; set; } = 0;
    public int CustomerCount { get; set; } = 0;
    public string Email { get; set; } = "";
    public string Mobil { get; set; } = "";
    public string Password { get; set; } = "";
    public int LogOnOk { get; set; } = 0;
    public string? SecretKey { get; set; } = "";
    public int SmsCode { get; set; } = 0;
    public DateTime? SmsCodeTimeStampt { get; set; } = null;
    public int AutLevel { get; set; } = 0;
    public string ErrorText { get; set; } = "";
    public string ErrorTextHjelp { get; set; } = "";
    public string oAuthUrl { get; set; } = "";
    public int RunVersion { get; set; } = 0;
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class AccountLogOnInfoItem
{
    public string UserId { get; set; } = "support";
    public string Password { get; set; } = "Morten09gutt";
    public string Server { get; set; } = "kddb09";
    public string Database { get; set; } = "susteni";
    public string? CustomerGuid { get; set; } = "";
    public string? ShipGuid { get; set; } = "";
    public string? Currency { get; set; } = "";
    public int RunVersion { get; set; } = 0;
    public ParametersItem Parameters { get; set; } = new ParametersItem();
}

public class ParametersItem
{
    public string? filter { get; set; } = "";
    public string? order { get; set; } = "";
    public string? field { get; set; } = "";
    public string? fieldValue { get; set; } = "";
    public int numbers { get; set; } = 100;
    public bool yesno { get; set; } = false;
}

public class CustomerUserItem
{
    public string UserGuid { get; set; } = "";
    public string UserId { get; set; } = "";
    public string UserName { get; set; } = "";
    public string AktivCustomerGuid { get; set; } = "";
    public bool Activ { get; set; } = false;
}

public class ReturnValueItem
{
    public bool Success { get; set; } = true;
    public List<ErrorItem> Error { get; set; } = new();
    public int Status { get; set; } = 0;
    public string Description { get; set; } = "";
    public string NewGuid { get; set; } = "";
    public string NewId { get; set; } = "";
    public bool Refresh { get; set; } = false;
    public string Base64String { get; set; } = "";

}

public class AccountUserItem
{
    public string? UserGuid { get; set; } = ""; 
    public string UserId { get; set; } = "";
    public string UserName { get; set; } = "";
    public string Firstname { get; set; } = "";
    public string Lastname { get; set; } = "";
    public bool SuperBruker { get; set; } = false;
    public bool SuperAdmin { get; set; } = false;
    public string? Password { get; set; } = "";
    public string? Mobil { get; set; } = "";
    public string? Email { get; set; } = "";
    public string? AktivCustomerGuid { get; set; } = "";
    public int AuthLevel { get; set; } = 0;
    public string? oAuthUrl { get; set; } = "";
    public bool Activ { get; set; } = true;
    public string SecretKey { get; set; } = "";
    public string? SmsCode { get; set; } = "";
    public int RunVersion { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}


public class AccountPassordItem
{
    public string UserId { get; set; } = "";
    public string Password { get; set; } = "";

}


public class UsersShipItem
{
    public string UserShipGuid { get; set; } = "";
    public string ShipGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public bool active { get; set; } = false;
}

public class UsersShipsItem
{
    public string ShipGuidList { get; set; } = "";
    public string UserId { get; set; } = "";
    public string CustomerGuid { get; set; } = "";
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class BrukerItem
{
    public string BrukerId { get; set; } = "";
    public string Passord { get; set; } = "";
 
}


namespace SusteniWebServices.Controllers
{

    [Route("/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {

        [Route("AccessToken")]
        [HttpPost]
        public string AccessToken(AccountSignedInItem item)
        {
            string conString;
            string sql = "SELECT UserId, UserName, AktivCustomerGuid, AuthLevel, Activ FROM Users WHERE UserId='" + item.UserId + "'";
            int authLevel = 0;

            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader rdr;

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            try
            {

                cnn = new SqlConnection(conString);
                cnn.Open();

                cmd = new SqlCommand(sql, cnn);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(3)) { authLevel = (Int16)rdr.GetValue(3); }
                    if (authLevel == 0)
                    {
                        item.LogOnOk = 2;
                    } 
                    else if (authLevel == 1)
                    {
                        item.LogOnOk = 1;
                    }
                    item.AutLevel = authLevel;
                }

            }
            catch (Exception ex)
            {
                item.ErrorText = ex.Message;
            }

            string output = JsonConvert.SerializeObject(item);

            return output;

        }

        [Route("SignIn")]
        [HttpPost]
        public string SignIn()
        {
            string conString;
            string sql = "SELECT COUNT(*) FROM Users WHERE UserId='abc'";

            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader rdr;

            conString = @"server=officeDB.kirkedata.no;User Id=g6admin;password=xyz123;database=susteni;TrustServerCertificate=True";

            cnn = new SqlConnection(conString);
            cnn.Open();

            cmd = new SqlCommand(sql, cnn);
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                int antall = (int)rdr.GetValue(0);

                if (antall > 0)
                {

                };
            }

            string output = "";

            return output;

        }

        [Route("GetUserInfo")]
        [HttpPost]
        public string GetUserInfo(AccountLogOnInfoItem logonInfo)
        {
            string conString;
            string sql = "SELECT Users.UserId, Users.UserName, Customer.CustomerGuid, Customer.CurrencyCode, Users.SuperAdmin, Users.SuperBruker, Users.RunVersion, Pictures.byte64Picture " +
                "FROM Users INNER JOIN Customer ON Users.AktivCustomerGuid = Customer.CustomerGuid LEFT OUTER JOIN " +
                "Pictures ON Customer.Logo = Pictures.PictureGuid WHERE(Users.UserId = '" + logonInfo.UserId + "')";

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            AccountSignedInItem item = new();

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserId"))) { item.UserId = rdr.GetString(rdr.GetOrdinal("UserId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserName"))) { item.UserName = rdr.GetString(rdr.GetOrdinal("UserName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerGuid"))) { item.CustomId = rdr.GetString(rdr.GetOrdinal("CustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CurrencyCode"))) { item.CurrencyCode = rdr.GetString(rdr.GetOrdinal("CurrencyCode")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SuperAdmin"))) { item.SuperAdmin = Convert.ToInt16(rdr.GetBoolean(rdr.GetOrdinal("SuperAdmin"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SuperBruker"))) { item.SuperBruker = Convert.ToInt16(rdr.GetBoolean(rdr.GetOrdinal("SuperBruker"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RunVersion"))) { item.RunVersion = rdr.GetInt16(rdr.GetOrdinal("RunVersion")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("byte64Picture"))) { item.CustomLogo = rdr.GetString(rdr.GetOrdinal("byte64Picture")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;

        }


        [Route("GetAccountUser")]
        [HttpPost]
        public string GetAccountUser(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT UserGuid, UserId, UserName, Firstname, Lastname, SuperBruker, SuperAdmin, RunVersion, Mobil, Email, AktivCustomerGuid, AuthLevel, Activ, SecretKey, SmsCode, SmsCodeTimeStampt FROM Users";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }

            AccountUserItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserGuid"))) { item.UserGuid = rdr.GetString(rdr.GetOrdinal("UserGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserId"))) { item.UserId = rdr.GetString(rdr.GetOrdinal("UserId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserName"))) { item.UserName = rdr.GetString(rdr.GetOrdinal("UserName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Firstname"))) { item.Firstname = rdr.GetString(rdr.GetOrdinal("Firstname")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Lastname"))) { item.Lastname = rdr.GetString(rdr.GetOrdinal("Lastname")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SuperBruker"))) { item.SuperBruker = rdr.GetBoolean(rdr.GetOrdinal("SuperBruker")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SuperAdmin"))) { item.SuperAdmin = rdr.GetBoolean(rdr.GetOrdinal("SuperAdmin")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Mobil"))) { item.Mobil = rdr.GetString(rdr.GetOrdinal("Mobil")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Email"))) { item.Email = rdr.GetString(rdr.GetOrdinal("Email")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("AktivCustomerGuid"))) { item.AktivCustomerGuid = rdr.GetString(rdr.GetOrdinal("AktivCustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("AuthLevel"))) { item.AuthLevel = (Int16)rdr.GetValue(rdr.GetOrdinal("AuthLevel")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Activ"))) { item.Activ = rdr.GetBoolean(rdr.GetOrdinal("Activ")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SecretKey"))) { item.SecretKey = rdr.GetString(rdr.GetOrdinal("SecretKey")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SmsCode"))) { item.SmsCode = rdr.GetValue(rdr.GetOrdinal("SmsCode")).ToString(); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RunVersion"))) { item.RunVersion = rdr.GetInt16(rdr.GetOrdinal("RunVersion")); }
                        //if (!rdr.IsDBNull(rdr.GetOrdinal("SmsCodeTimeStampt"))) { item.SmsCodeTimeStampt = rdr.GetDateTime(rdr.GetOrdinal("SmsCodeTimeStampt")); }
                        if (item.SecretKey.Length > 0) {
                            string SecretKey = item.SecretKey;
                            item.oAuthUrl = "otpauth://totp/Susteni?secret=" + SecretKey;
                        }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        private AccountUserItem GetAccountUserInfo(AccountLogOnInfoItem logonInfo, string UserId)
        {
            string conString;

            string sql = "SELECT UserGuid, UserId, UserName, SuperAdmin, SuperBruker, RunVersion, Firstname, Lastname, Mobil, Email, AktivCustomerGuid, AuthLevel, Activ, SecretKey, SmsCode, SmsCodeTimeStampt FROM Users";
            sql += " WHERE UserId = '" + UserId + "'"; 

            AccountUserItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserGuid"))) { item.UserGuid = rdr.GetString(rdr.GetOrdinal("UserGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserId"))) { item.UserId = rdr.GetString(rdr.GetOrdinal("UserId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserName"))) { item.UserName = rdr.GetString(rdr.GetOrdinal("UserName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Firstname"))) { item.Firstname = rdr.GetString(rdr.GetOrdinal("Firstname")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Lastname"))) { item.Lastname = rdr.GetString(rdr.GetOrdinal("Lastname")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Mobil"))) { item.Mobil = rdr.GetString(rdr.GetOrdinal("Mobil")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Email"))) { item.Email = rdr.GetString(rdr.GetOrdinal("Email")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("AktivCustomerGuid"))) { item.AktivCustomerGuid = rdr.GetString(rdr.GetOrdinal("AktivCustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("AuthLevel"))) { item.AuthLevel = (Int16)rdr.GetValue(rdr.GetOrdinal("AuthLevel")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Activ"))) { item.Activ = rdr.GetBoolean(rdr.GetOrdinal("Activ")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SuperAdmin"))) { item.SuperAdmin = rdr.GetBoolean(rdr.GetOrdinal("SuperAdmin")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SuperBruker"))) { item.SuperBruker = rdr.GetBoolean(rdr.GetOrdinal("SuperBruker")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SecretKey"))) { item.SecretKey = rdr.GetString(rdr.GetOrdinal("SecretKey")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SmsCode"))) { item.SmsCode = rdr.GetString(rdr.GetOrdinal("SmsCode")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RunVersion"))) { item.RunVersion = rdr.GetInt16(rdr.GetOrdinal("RunVersion")); }
                        //if (!rdr.IsDBNull(rdr.GetOrdinal("SmsCodeTimeStampt"))) { item.SmsCodeTimeStampt = rdr.GetDateTime(rdr.GetOrdinal("SmsCodeTimeStampt")); }
                    }
                }
            }

            return item;
        }


        [Route("SetAccountUser")]
        [HttpPost]
        public string SetAccountUser(AccountUserItem item)
        {
            string conString;
            string sql = "";

            ReturnValueItem retur = new();

            if (item.UserGuid == null || item.UserGuid == "")
            {
                string UserGuid = Guid.NewGuid().ToString();
                retur.NewGuid = UserGuid;

                sql = "INSERT INTO Users() VALUES()";
                CsqlI(ref sql, "UserGuid", UserGuid);
                CsqlI(ref sql, "UserId", item.UserId);
                if (item.UserName == null || item.UserName.Length == 0)
                {
                    item.UserName = item.Firstname + " " + item.Lastname;
                }

                CsqlI(ref sql, "UserName", item.UserName);
                CsqlI(ref sql, "Firstname", item.Firstname);
                CsqlI(ref sql, "Lastname", item.Lastname);
                CsqlI(ref sql, "Mobil", item.Mobil);
                CsqlI(ref sql, "Email", item.Email);
                CsqlI(ref sql, "AktivCustomerGuid", item.AktivCustomerGuid);
                CsqlI(ref sql, "AuthLevel", item.AuthLevel);
                CsqlI(ref sql, "Activ", item.Activ);
                CsqlI(ref sql, "SuperAdmin", item.SuperAdmin);
                CsqlI(ref sql, "SuperBruker", item.SuperBruker);
                byte[] key = KeyGeneration.GenerateRandomKey(40);
                string SecretKey = Base32Encoder.Encode(key);
                CsqlI(ref sql, "SecretKey", SecretKey);
                CsqlI(ref sql, "RunVersion", item.RunVersion);
                retur.Status = 1;
            }
            else
            {
                AccountUserItem itemOld = new();
                itemOld = GetAccountUserInfo(item.logonInfo, item.UserId);

                if (item.Firstname != itemOld.Firstname || item.Lastname != itemOld.Lastname)
                {
                    retur.Status= 2;
                }

                item.UserName = item.Firstname + " " + item.Lastname;

                sql = "UPDATE Users SET WHERE UserId='" + item.UserId + "'";
                CsqlU(ref sql, "Firstname", item.Firstname, itemOld.Firstname);
                CsqlU(ref sql, "Lastname", item.Lastname, itemOld.Lastname);
                CsqlU(ref sql, "UserName", item.UserName, itemOld.UserName);
                CsqlU(ref sql, "Mobil", item.Mobil, itemOld.Mobil);
                CsqlU(ref sql, "Email", item.Email, itemOld.Email);
                CsqlU(ref sql, "AktivCustomerGuid", item.AktivCustomerGuid, itemOld.AktivCustomerGuid);
                CsqlU(ref sql, "AuthLevel", item.AuthLevel, itemOld.AuthLevel);
                CsqlU(ref sql, "Activ", item.Activ, itemOld.Activ);
                CsqlU(ref sql, "SuperAdmin", item.SuperAdmin, itemOld.SuperAdmin);
                CsqlU(ref sql, "SuperBruker", item.SuperBruker, itemOld.SuperBruker);
                CsqlU(ref sql, "RunVersion", item.RunVersion, itemOld.RunVersion);

                if (itemOld.SecretKey == null || itemOld.SecretKey == "")
                {
                    byte[] key = KeyGeneration.GenerateRandomKey(40);
                    string SecretKey = Base32Encoder.Encode(key);
                    CsqlU(ref sql, "SecretKey", SecretKey, "");
                }
            }

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlTransaction transaction = cnn.BeginTransaction();

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
            }
            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

    
        [Route("GetCustomerUserList")]
        [HttpPost]
        public string GetCustomerUserList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT U.UserGuid, U.UserId, U.UserName, U.AktivCustomerGuid, U.Activ " +
                "FROM Users AS U INNER JOIN Customer_Users AS CU ON U.UserId = CU.UserId ";

            if (logonInfo.Parameters.filter != null && logonInfo.Parameters.filter.Length>0 )
            {
                sql += " WHERE " + logonInfo.Parameters.filter;
            }
            else
            {
                sql += "AND CU.CustomerGuid  = (SELECT AktivCustomerGuid FROM Users WHERE UserId=SUSER_SNAME()) ORDER BY U.UserName";

            }
            List<CustomerUserItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        CustomerUserItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserGuid"))) { item.UserGuid = rdr.GetString(rdr.GetOrdinal("UserGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserId"))) { item.UserId = rdr.GetString(rdr.GetOrdinal("UserId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserName"))) { item.UserName = rdr.GetString(rdr.GetOrdinal("UserName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("AktivCustomerGuid"))) { item.AktivCustomerGuid = rdr.GetString(rdr.GetOrdinal("AktivCustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Activ"))) { item.Activ = rdr.GetBoolean(rdr.GetOrdinal("Activ")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetUserShipList")]
        [HttpPost]
        public string GetUserShipList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT US.UserShipGuid, S.ShipGuid, S.Name " +
                "FROM Ship S INNER JOIN Users_Ship US ON S.ShipGuid=US.ShipGuid";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<UsersShipItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        UsersShipItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserShipGuid"))) { item.UserShipGuid = rdr.GetString(rdr.GetOrdinal("UserShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (item.UserShipGuid != "")
                        {
                            item.active = true;
                        }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("SetUserShipsList")]
        [HttpPost]
        public string SetUserShipsList(UsersShipsItem item)
        {
            ReturnValueItem retur = new();

            string sql = "DELETE FROM Users_Ship WHERE CustomerGuid='" + item.CustomerGuid + "' AND UserId='" + item.UserId + "'";
            ExecuteSQL(item.logonInfo, sql);

            string[] arrShip = item.ShipGuidList.Split(':');

            foreach (string s in arrShip)
            {
                if (s != "Ships") { 
                    string userShipGuid = Guid.NewGuid().ToString();
                    sql = "INSERT INTO Users_Ship(UserShipGuid, UserId, ShipGuid, CustomerGuid) VALUES('" + userShipGuid + "','" + item.UserId + "','" + s + "','" + item.CustomerGuid + "')";
                    ExecuteSQL(item.logonInfo, sql);
                }
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("GetUserShipsItems")]
        [HttpPost]
        public string GetUserShipsItems(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT US.UserShipGuid, S.ShipGuid, S.Name " +
                "FROM Ship S LEFT OUTER JOIN Users_Ship US ON S.ShipGuid=US.ShipGuid";
            if (logonInfo.Parameters.filter != "") { sql += " AND " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<UsersShipItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        UsersShipItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserShipGuid"))) { item.UserShipGuid = rdr.GetString(rdr.GetOrdinal("UserShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (item.UserShipGuid != "")
                        {
                            item.active = true;
                        }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("SendSMS")]
        [HttpPost]
        public string SendSMS(AccountUserItem item)
        {
            //SMSWebServiceSoap smsKlient = new();
            //string strLev_GUID = "99af6a7e-baff-4390-937e-05f95be9c73a";
            string strKode = "";
            string strSQL = "";

            ReturnValueItem retur = new();

            VBMath.Randomize();
            strKode = Conversion.Int(VBMath.Rnd() * 1000000).ToString();
            strKode = "5555";

            retur.Status = 1;

            AccountUserItem itemUser = GetAccountUserInfo(item.logonInfo, item.UserId);

            //string sSmsGuid;
            //sSmsGuid = smsKlient.registrerSMSV2Async("00000100-ea6f-403a-a1a0-1bf4f775dd3d", "KipWeb", "L1c3ns30S3rv1c3", DateTime.Now, false, "999901", "", strKode);
            
            //if (sSmsGuid.Length > 4 && sSmsGuid.Length == 36 & sSmsGuid.Substring(0, 4) != "Feil")
            //{
            //    string Message = strKode.ToString();

            //    reciever = itemUser.Mobil;

            //    bResultat = smsKlient.sendSMSV2Async(sSmsGuid, Message, reciever, "KipWeb", "00000100-ea6f-403a-a1a0-1bf4f775dd3d", false, itemUser.UserName);

            //    if (bResultat)
            //    {
                    strSQL = "UPDATE Users SET SMSCode=" + strKode + " WHERE UserId='" + item.UserId + "'";
                    ExecuteSQL(item.logonInfo, strSQL);
            //    }
            //}

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("VerifySMSKode")]
        [HttpPost]
        public string VerifySMSKode(AccountUserItem item)
        {
            string sql = "";
            string conString = "";

            AccountUserItem itemDB = new();
            ReturnValueItem retur = new();

            sql = @"SELECT SecretKey, SMSCode FROM Users WHERE UserId = '" + item.UserId + "'";

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SecretKey"))) { itemDB.SecretKey = rdr.GetString(rdr.GetOrdinal("SecretKey")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SMSCode"))) { itemDB.SmsCode = rdr.GetString(rdr.GetOrdinal("SMSCode")); }
                    }
                }
            }

            if (itemDB.SmsCode == item.SmsCode)
            {
                retur.Status = 1;
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("VerifyUser")]
        [HttpPost]
        public string VerifyUser(AccountUserItem item)
        {
            string sql = "";
            string conString = "";

            sql = @"SELECT SecretKey FROM Users WHERE UserId = '" + item.UserId + "'";

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            AccountUserItem itemDB = new();
            ReturnValueItem retur = new();

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SecretKey"))) { itemDB.SecretKey = rdr.GetString(rdr.GetOrdinal("SecretKey")); }
                    }
                }
            }

            if (itemDB.SecretKey.Length > 0)
            {
                //itemDB.SecretKey = Decrypt(itemDB.SecretKey);
                var key = Base32Encoder.Decode(itemDB.SecretKey);
                var Otp = new Totp(key);
                var VerifyCode = Otp.ComputeTotp();
                if (VerifyCode == item.SmsCode.ToString())
                    retur.Status = 1;
                else
                    retur.Status = -1;
            }


            string output = JsonConvert.SerializeObject(retur);

            return output;
        }



        [Route("SetActiveCustomerUser")]
        [HttpPost]
        public string SetActiveCustomerUser(CustomerItem item)
        {
            string sql = "";

            ReturnValueItem retur = new();
            retur.Status = 1;

            sql = "UPDATE Users SET AktivCustomerGuid='" + item.CustomerGuid + "' WHERE UserId = '" + item.logonInfo.UserId + "'";

            ExecuteSQL(item.logonInfo, sql);

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("SetCustomerUsers")]
        [HttpPost]
        public string SetCustomerUsers(AccountUserItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            string CustomerUserGuid = Guid.NewGuid().ToString();

            sql = "INSERT INTO Customer_Users() Values()";


            CsqlI(ref sql, "CustomerUserGuid", CustomerUserGuid);
            CsqlI(ref sql, "CustomerGuid", item.AktivCustomerGuid);
            CsqlI(ref sql, "UserId", item.UserId);

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
                item.Error.ErrorCode = 20;
                item.Error.Message = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        #region Opprett brukere
        [Route("CreateUser")]
        [HttpPost]
        public string CreateUser(AccountUserItem item)
        {
            ReturnValueItem retur = new ReturnValueItem();

            if (item.Password != null)
            {
                if (!Eksisterer(item.UserId))
                {
                    if (!LoginEksisterer(item.UserId))
                        OpprettLogon(item.UserId, item.Password);
                    OpprettBruker(item.UserId);
                }
                string result = SetAccountUser(item);
                if (result != null)
                {
                   var retur2 = JsonConvert.DeserializeObject<ReturnValueItem>(result);
                   if (retur2 != null)
                    {
                        retur.NewGuid = retur2.NewGuid;
                    }
                }
                SetCustomerUsers(item);
                retur.Status = 1;
            }
            else
            {
                retur.Status = -1;
                retur.Description = "You have to endter a passrod";
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }



        private bool LoginEksisterer(string LogonId)
        {
            string sql = "sp_HelpLogins '" + LogonId + "'";

            bool bolRetur = false;

            string conString = @"server=kddb09;User Id=sa;password=tigergutt;database=susteni;TrustServerCertificate=True";


            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0)) { bolRetur = true; }
                    }
                }
            }

            return bolRetur;
        }


        private bool Eksisterer(string LogonId, bool bDatabaseUser = false)
        {
            string sql;

            bool bolRetur = false;

            string conString = @"server=kddb09;User Id=sa;password=tigergutt;database=susteni;TrustServerCertificate=True";

            sql = "SELECT name FROM [sys].[server_principals] WHERE name = N'" + LogonId + "'";
            if (bDatabaseUser)
                sql = "SELECT name FROM [sys].[database_principals] WHERE name = N'" + LogonId + "'";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string name = "";

                        if (!rdr.IsDBNull(0)) { name = rdr.GetString(0); }
                        if (name.ToUpper() == LogonId.ToUpper()) { bolRetur = true; }
                    }
                }
            }

            return bolRetur;
        }

        private bool OpprettLogon(string LogonId, string Passord)
        {
            string strSQLE;
            strSQLE = "CREATE LOGIN [" + LogonId + "] WITH PASSWORD=N'" + Passord + "', DEFAULT_DATABASE=[Susteni], DEFAULT_LANGUAGE=[Norsk], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF";
            ExecuteSQLAdmin(strSQLE);
            return true;
        }

        private bool OpprettBruker(string LogonId)
        {
            string strSQLE;
            strSQLE = "CREATE USER [" + LogonId + "] FOR LOGIN [" + LogonId + "] WITH DEFAULT_SCHEMA=[dbo]";
            ExecuteSQLAdmin(strSQLE);


            strSQLE = "sp_addrolemember N'Admin', N'" + LogonId + "'";
            ExecuteSQLAdmin(strSQLE);

            return true;
        }

        #endregion

        [Route("ChangeUsersPassword")]
        [HttpPost]
        public ReturnValueItem ChangeUsersPassword(AccountPassordItem Item)
        {
            ReturnValueItem retur = new();
            string strSQL = "";

            if (Item.UserId == null || Item.UserId.Length == 0)
            {
                retur.Success = false;
                return retur;
            }

            if (Eksisterer(Item.UserId))
            {
                strSQL = "ALTER LOGIN [" + Item.UserId + "] WITH PASSWORD = '" + Item.Password + "';";

                ExecuteSQLAdmin(strSQL);
            }

            retur.Success = true;
            return retur;
        }


        [Route("DropUserAccount")]
        [HttpPost]
        public string DropUserAccount(AccountUserItem item)
        {
            ReturnValueItem retur = new ReturnValueItem();

            string sql = "DROP USER " + item.UserId;
            ExecuteSQLAdmin(sql);

            sql = "DROP LOGIN " + item.UserId;
            ExecuteSQLAdmin(sql);

            sql = "DELETE FROM Customer_Users WHERE Userid='" + item.UserId + "'";
            ExecuteSQLAdmin(sql);

            sql = "DELETE FROM Users WHERE Userid='" + item.UserId + "'";
            ExecuteSQLAdmin(sql);


            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        #region Hjelpefunksjoner

        private string Decrypt(string cipherText)
        {
            if (cipherText == null || cipherText.Length == 0)
                return "";

            string passPhrase = "KirkedataAS";
            string saltValue = "myKdValue";
            string hashAlgorithm = "SHA1";

            int passwordIterations = 2;
            string initVector = "@5B2c1D6e9F4g2H0";

            int keySize = 256;
            // Convert strings defining encryption key characteristics into byte
            // arrays. Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // Convert our ciphertext into a byte array.
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate decryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Define cryptographic stream (always use Read mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold ciphertext;
            // plaintext is never longer than ciphertext.
            byte[] plainTextBytes = new byte[cipherTextBytes.Length - 1 + 1];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            // Return decrypted string.   
            return plainText;
        }


        //private string exeKIPCreateUser(AccountLogOnInfoItem logonInfo, AccountUserItem Item)
        //{
        //    string conString;

        //    conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

        //    if (!Eksisterer(logonInfo, Item.UserId, false))
        //    {
        //        if (!LoginEksisterer(logonInfo, Item.UserId))
        //        {
        //            OpprettLogon(logonInfo, Item.UserId, "");
        //        }
        //    }

        //    OpprettBruker(logonInfo, Item.UserId);

        //    return "";
        //}

        //public bool Eksisterer(AccountLogOnInfoItem logonInfo, string LogonId, bool bDatabaseUser = false)
        //{
        //    string sql;
        //    string conString;

        //    conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

        //    bool retur = false;

        //    using (SqlConnection cnn = new SqlConnection(conString))
        //    {
        //        cnn.Open();

        //        sql = "SELECT name FROM [sys].[server_principals] WHERE name = N'" + LogonId + "'";
        //        if (bDatabaseUser)
        //            sql = "SELECT name FROM [sys].[database_principals] WHERE name = N'" + LogonId + "'";

        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand(sql, cnn);
        //            using (SqlDataReader rdr = cmd.ExecuteReader())
        //            {
        //                while (rdr.Read())
        //                {
        //                    if (rdr.GetString(0) == LogonId)
        //                    {
        //                        retur = true;
        //                    }
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            retur = false;
        //        }

        //        if (cnn.State == ConnectionState.Open) cnn.Close();
        //        cnn.Dispose();
        //    }
        //    return retur;
        //}

        //public bool OpprettLogon(AccountLogOnInfoItem logonInfo, string LogonId, string Passord)
        //{
        //    string sql;
        //    sql = "CREATE LOGIN [" + LogonId + "] WITH PASSWORD=N'" + Passord + "', DEFAULT_DATABASE=[" + logonInfo.Database + "], DEFAULT_LANGUAGE=[Norsk], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF";

        //    ExecuteSQL(logonInfo, sql);
        //    return true;
        //}

        //public bool OpprettBruker(AccountLogOnInfoItem logonInfo, string LogonId)
        //{
        //    string sql;
        //    sql = "CREATE USER [" + LogonId + "] FOR LOGIN [" + LogonId + "] WITH DEFAULT_SCHEMA=[dbo]";
        //    ExecuteSQL(logonInfo, sql);

        //    sql = "sp_addrolemember N'Admin', N'" + LogonId + "'";
        //    ExecuteSQL(logonInfo, sql);

        //    return true;
        //}

        //public bool LoginEksisterer(AccountLogOnInfoItem logonInfo, string LogonId)
        //{
        //    string sql;
        //    string conString;
        //    bool retur = false;

        //    conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

        //    using (SqlConnection cnn = new SqlConnection(conString))
        //    {
        //        cnn.Open();

        //        sql = "sp_HelpLogins '" + LogonId + "'";

        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand(sql, cnn);

        //            using (SqlDataReader rdr = cmd.ExecuteReader())
        //            {
        //                while (rdr.Read())
        //                {
        //                   if (rdr.GetString(0) == LogonId)
        //                    {
        //                        retur = true;
        //                    }
        //                }
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //        }

        //        if (cnn.State == ConnectionState.Open) cnn.Close();
        //        cnn.Dispose();
        //    }

        //    return retur;
        //}



        #endregion

        #region Generelle funksjoner

        private bool ExecuteSQL(AccountLogOnInfoItem logonInfo, string sql)
        {
            string conString;
            bool retur = true;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlTransaction transaction = cnn.BeginTransaction();

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
                    retur = false;
                    transaction.Rollback();
                }

            }

            return retur;
        }


        private bool ExecuteSQLAdmin(string sql)
        {
            bool retur = true;

            string conString = @"server=kddb09;User Id=sa;password=tigergutt;database=susteni;TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlTransaction transaction = cnn.BeginTransaction();

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
                    retur = false;
                    transaction.Rollback();
                }

            }

            return retur;
        }


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
        private void CsqlI(ref string SQLQ, string strField, string? strValue)
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

        private void CsqlI(ref string SQLQ, string strField, int Value)
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

        private void CsqlI(ref string SQLQ, string strField, bool bolValue)
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

        private void CsqlI(ref string SQLQ, string strField, float fltValue)
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

        private void CsqlI(ref string SQLQ, string strField, string strType, DateTime dtValue)
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


        private void CsqlU(ref string SQLQ, string strField, string? strValue, string? strOldValue)
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

        private void CsqlU(ref string SQLQ, string strField, bool bolValue, bool bolOldValue)
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

            if (bolValue == true)
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

        private void CsqlU(ref string SQLQ, string strField, int intValue, int intOldValue)
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

        private void CsqlU(ref string SQLQ, string strField, float fltValue, float fltOldValue)
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

        private void CsqlU(ref string SQLQ, string strField, string strType, DateTime dtValue, DateTime dtOldValue)
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
