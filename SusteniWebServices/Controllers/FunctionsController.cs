using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using System;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Collections.Generic;

public class MenuItem
{
    public string Function { get; set; } = "";
    public string FunctionGuid { get; set; } = "";
    public string MainMenu { get; set; } = "";
    public string Title { get; set; } = "";
    public string URL { get; set; } = "";
    public string Icon { get; set; } = "";
    public int Order { get; set; } = 0;
    public int AuthNiva { get; set; } = 0;
    public bool SuperAdmin { get; set; } = false;
}

public class FilerItem
{
    public string CustomerGuid { get; set; } = "";
    public string LinkGuid { get; set; } = "";
    public string FilNavn { get; set; } = "";
    public string Ext { get; set; } = "";
    public string byte64string { get; set; } = "";

    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class HelpSystemItem
{
    public string? HelpGuid { get; set; } = "";
    public int Modul { get; set; } = 0;
    public string? ModulName { get; set; } = "";
    public string? Screen { get; set; } = "";
    public string? Title { get; set; } = "";
    public string? Info { get; set; } = "";
    public bool Active { get; set; } = false;
    public string? Kategori { get; set; } = "";
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class TypeFuelItem
{
    public string? FuelTypeGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public double CarbonContent { get; set; } = 0;
    public double Cf { get; set; } = 0;
    public double DensityMGO { get; set; } = 0;
    public double Metan { get; set; } = 0;
    public double Lystgass { get; set; } = 0;
    public double NOx { get; set; } = 0;
    public double SOx { get; set; } = 0;
    public double CarbonContent2 { get; set; } = 0;
    public double Cf2 { get; set; } = 0;
    public double DensityMGO2 { get; set; } = 0;
    public double Metan2 { get; set; } = 0;
    public double Lystgass2 { get; set; } = 0;
    public double NOx2 { get; set; } = 0;
    public double SOx2 { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class TypeShipItem
{
    public string? ShipTypeGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class TypeEquipmentItem
{
    public string? EquipmentTypesGuid { get; set; } = "";
    public int Type { get; set; } = 0;
    public string Name { get; set; } = "";
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class TypePowerProductionItem
{
    public string? TypeGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public int Order { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class EquipmentLibraryItem
{
    public string LibraryGuid { get; set; } = "";
    public string ProfileName { get; set; } = "";
    public string EquipmentType { get; set; } = "";
    public string FunctionDescription { get; set; } = "";
    public string Notes { get; set; } = "";
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class GeneratorVendorItem
{
    public string? GeneratorVendorGuid { get; set; } = "";
    public string Vendor { get; set; } = "";
    public ErrorItem? Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class GeneratorModelItem
{
    public string? GeneratorModelGuid { get; set; } = "";
    public string GeneratorVendorGuid { get; set; } = "";
    public string Model { get; set; } = "";
    public string TypeGuid { get; set; } = "";
    public string FuelTypeGuid { get; set; } = "";
    public int kW { get; set; } = 0;
    public Double KgDieselkWh { get; set; } = 0;
    public Single EfficientMotorSwitchboard { get; set; } = 0;
    public Single MaintenanceCost { get; set; } = 0;
    public bool PowerProduction { get; set; } = true;
    public ErrorItem? Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}


public class GeneratorImportItem
{
    public string GeneratorModelGuid { get; set; } = "";
    public string ShipGuid { get; set; } = "";
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class GeneratorVendorModelItem
{
    public string GeneratorVendorGuid { get; set; } = "";
    public string Vendor { get; set; } = "";
    public string GeneratorModelGuid { get; set; } = "";
    public string Model { get; set; } = "";
}

public class FuelComsuptionImportItem
{
    public string FromGuid { get; set; } = "";
    public string GeneratorGuid { get; set; } = "";
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

namespace SusteniWebServices.Controllers
{

    [Route("/[controller]")]
    [ApiController]

    public class FunctionsController : ControllerBase
    {

        [Route("GetMenus")]
        [HttpPost]
        public string GetMenus(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT [Function], FunctionGuid, MainMenu, Title, URL, Icon, [Order], AuthNiva, SuperAdmin FROM MenuFunction";
            if (logonInfo.Parameters.filter != "") { 
                sql += " WHERE " + logonInfo.Parameters.filter + " AND (SuperAdmin = 0 OR (SELECT SuperAdmin FROM Users WHERE UserId=SUSER_SNAME()) = 1)"; 
            }
            else
            {
                sql += "WHERE (SuperAdmin = 0 OR (SELECT SuperAdmin FROM Users WHERE UserId=SUSER_SNAME()) = 1)";
            }
            sql += " ORDER BY [Order]";
            List<MenuItem> items = new();


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
                MenuItem item = new();
                if (!rdr.IsDBNull(rdr.GetOrdinal("Function"))) { item.Function = rdr.GetString(rdr.GetOrdinal("Function")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("FunctionGuid"))) { item.FunctionGuid = rdr.GetString(rdr.GetOrdinal("FunctionGuid")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("MainMenu"))) { item.MainMenu = rdr.GetString(rdr.GetOrdinal("MainMenu")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Title"))) { item.Title = rdr.GetString(rdr.GetOrdinal("Title")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("URL"))) { item.URL = rdr.GetString(rdr.GetOrdinal("URL")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Icon"))) { item.Icon = rdr.GetString(rdr.GetOrdinal("Icon")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("AuthNiva"))) { item.AuthNiva = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("AuthNiva"))); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("SuperAdmin"))) { item.SuperAdmin = rdr.GetBoolean(rdr.GetOrdinal("SuperAdmin")); }
                items.Add(item);
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        #region Help system


        [Route("GetHelpSystemListe")]
        [HttpPost]
        public string GetHelpSystemListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT HelpGuid, HelpSystem.Modul, Modules.Title ModuleName, Screen, HelpSystem.Title, Info, Active, Kategori FROM HelpSystem INNER JOIN Modules ON HelpSystem.Modul=Modules.Modul";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<HelpSystemItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        HelpSystemItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpGuid"))) { item.HelpGuid = rdr.GetString(rdr.GetOrdinal("HelpGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Modul"))) { item.Modul = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Modul"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ModuleName"))) { item.ModulName = rdr.GetString(rdr.GetOrdinal("ModuleName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Screen"))) { item.Screen = rdr.GetString(rdr.GetOrdinal("Screen")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Title"))) { item.Title = rdr.GetString(rdr.GetOrdinal("Title")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Info"))) { item.Info = rdr.GetString(rdr.GetOrdinal("Info")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kategori"))) { item.Kategori = rdr.GetString(rdr.GetOrdinal("Kategori")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetHelpSystem")]
        [HttpPost]
        public string GetHelpSystem(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT HelpGuid, Modul, Screen, Title, Info, Active, Kategori FROM HelpSystem";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            HelpSystemItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpGuid"))) { item.HelpGuid = rdr.GetString(rdr.GetOrdinal("HelpGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Modul"))) { item.Modul = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Modul"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Screen"))) { item.Screen = rdr.GetString(rdr.GetOrdinal("Screen")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Title"))) { item.Title = rdr.GetString(rdr.GetOrdinal("Title")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Info"))) { item.Info = rdr.GetString(rdr.GetOrdinal("Info")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kategori"))) { item.Kategori = rdr.GetString(rdr.GetOrdinal("Kategori")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetHelpSystem")]
        [HttpPost]
        public string SetHelpSystem(HelpSystemItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            if (item.HelpGuid == null)
            {
                string GeneratorGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO HelpSystem() VALUES()";


                CsqlIS(ref sql, "HelpGuid", GeneratorGuid);
                CsqlII(ref sql, "Modul", item.Modul);
                CsqlIS(ref sql, "Screen", item.Screen);
                CsqlIS(ref sql, "Title", item.Title);
                CsqlIS(ref sql, "Info", item.Info);
                CsqlIB(ref sql, "Active", item.Active);
                CsqlIS(ref sql, "Kategori", item.Kategori);

            }
            else
            {
                HelpSystemItem itemOld = new();
                itemOld = GetHelpSystemInternal(logonInfo, item.HelpGuid);
                sql = "UPDATE HelpSystem SET WHERE HelpGuid='" + item.HelpGuid + "'"; CsqlUS(ref sql, "HelpGuid", item.HelpGuid, itemOld.HelpGuid);
                CsqlUI(ref sql, "Modul", item.Modul, itemOld.Modul);
                CsqlUS(ref sql, "Screen", item.Screen, itemOld.Screen);
                CsqlUS(ref sql, "Title", item.Title, itemOld.Title);
                CsqlUS(ref sql, "Info", item.Info, itemOld.Info);
                CsqlUB(ref sql, "Active", item.Active, itemOld.Active);
                CsqlUS(ref sql, "Kategori", item.Kategori, itemOld.Kategori);
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
                item.Error.ErrorCode = 20;
                item.Error.Message = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }


        [Route("RemoveHelpSystem")]
        [HttpPost]
        public string RemoveHelpSystem(AccountLogOnInfoItem logonInfo)
        {
            string conString;
            ReturnValueItem retur = new();

            string sql = "DELETE FROM HelpSystem";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            HelpSystemItem item = new();


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
                    ErrorItem e = new();
                    e.ErrorCode = 20;
                    e.Message = ex.Message;
                    retur.Error.Add(e);
                    transaction.Rollback();
                }
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        private HelpSystemItem GetHelpSystemInternal(AccountLogOnInfoItem logonInfo, string HelpGuid) 
        {
            string conString;

            string sql = "SELECT HelpGuid, Modul, Screen, Title, Info, Active, Kategori FROM HelpSystem WHERE HelpGuid='" + HelpGuid + "'";

            HelpSystemItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpGuid"))) { item.HelpGuid = rdr.GetString(rdr.GetOrdinal("HelpGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Modul"))) { item.Modul = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Modul"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Screen"))) { item.Screen = rdr.GetString(rdr.GetOrdinal("Screen")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Title"))) { item.Title = rdr.GetString(rdr.GetOrdinal("Title")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Info"))) { item.Info = rdr.GetString(rdr.GetOrdinal("Info")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kategori"))) { item.Kategori = rdr.GetString(rdr.GetOrdinal("Kategori")); }
                    }
                }
            }

            return item;
        }

        #endregion

        #region Fuel type

        [Route("GetTypeFuelList")]
        [HttpPost]
        public string GetTypeFuelList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT FuelTypeGuid, Name, CarbonContent, Cf, DensityMGO, Metan, Lystgass, NOx, SOx FROM FuelType";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<TypeFuelItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        TypeFuelItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CarbonContent"))) { item.CarbonContent = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("CarbonContent"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Cf"))) { item.Cf = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Cf"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("DensityMGO"))) { item.DensityMGO = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("DensityMGO"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Metan"))) { item.Metan = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Metan"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Lystgass"))) { item.Lystgass = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Lystgass"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOx"))) { item.NOx = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("NOx"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOx"))) { item.SOx = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("SOx"))); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetTypeFuel")]
        [HttpPost]
        public string GetTypeFuel(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT FuelTypeGuid, Name, CarbonContent, Cf, DensityMGO, Metan, Lystgass, NOx, SOx FROM FuelType";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            TypeFuelItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CarbonContent"))) { item.CarbonContent = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("CarbonContent"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Cf"))) { item.Cf = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Cf"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("DensityMGO"))) { item.DensityMGO = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("DensityMGO"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Metan"))) { item.Metan = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Metan"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Lystgass"))) { item.Lystgass = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Lystgass"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOx"))) { item.NOx = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("NOx"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOx"))) { item.SOx = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("SOx"))); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetTypeFuel")]
        [HttpPost]
        public string SetTypeFuel(TypeFuelItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            if (item.FuelTypeGuid == null)
            {
                string FuelTypeGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO _FuelType() Values()";
                CsqlIS(ref sql, "FuelTypeGuid", FuelTypeGuid);
                CsqlIS(ref sql, "Name", item.Name);
                CsqlIF(ref sql, "CarbonContent", item.CarbonContent);
                CsqlIF(ref sql, "Cf", item.Cf);
                CsqlIF(ref sql, "DensityMGO", item.DensityMGO);
                CsqlIF(ref sql, "Metan", item.Metan);
                CsqlIF(ref sql, "Lystgass", item.Lystgass);
                CsqlIF(ref sql, "NOx", item.NOx);
                CsqlIF(ref sql, "SOx", item.SOx);
            }
            else
            {
                TypeFuelItem itemOld = new();
                itemOld = GetTypeFuelInternal(logonInfo, item.FuelTypeGuid);
                sql = "UPDATE _FuelType SET WHERE FuelTypeGuid='" + item.FuelTypeGuid + "'"; CsqlUS(ref sql, "FuelTypeGuid", item.FuelTypeGuid, itemOld.FuelTypeGuid);
                CsqlUS(ref sql, "Name", item.Name, itemOld.Name);
                CsqlUF(ref sql, "CarbonContent", item.CarbonContent, itemOld.CarbonContent);
                CsqlUF(ref sql, "Cf", item.Cf, itemOld.Cf);
                CsqlUF(ref sql, "DensityMGO", item.DensityMGO, itemOld.DensityMGO);
                CsqlUF(ref sql, "Metan", item.Metan, itemOld.Metan);
                CsqlUF(ref sql, "Lystgass", item.Lystgass, itemOld.Lystgass);
                CsqlUF(ref sql, "NOx", item.NOx, itemOld.NOx);
                CsqlUF(ref sql, "SOx", item.SOx, itemOld.SOx);
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
                item.Error.ErrorCode = 20;
                item.Error.Message = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        private TypeFuelItem GetTypeFuelInternal(AccountLogOnInfoItem logonInfo, string FuelTypeGuid)
        {
            string conString;

            string sql = "SELECT FuelTypeGuid, Name, CarbonContent, Cf, DensityMGO, Metan, Lystgass, NOx, SOx FROM FuelType WHERE FuelTypeGuid = '" + FuelTypeGuid + "'";

            TypeFuelItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CarbonContent"))) { item.CarbonContent = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("CarbonContent"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Cf"))) { item.Cf = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Cf"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("DensityMGO"))) { item.DensityMGO = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("DensityMGO"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Metan"))) { item.Metan = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Metan"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Lystgass"))) { item.Lystgass = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Lystgass"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOx"))) { item.NOx = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("NOx"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOx"))) { item.SOx = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("SOx"))); }
                    }
                }
            }

            return item;
        }


        [Route("RemoveTypeFuel")]
        [HttpPost]
        public string RemoveTypeFuel(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "DELETE FROM FuelType WHERE " + logonInfo.Parameters.filter;

            SqlConnection cnn;
            SqlCommand cmd;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

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
                retur.Status = 20;
                retur.Description = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        #endregion

        #region Type ship

        [Route("GetTypeShipList")]
        [HttpPost]
        public string GetTypeShipList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ShipTypeGuid, Name FROM ShipType";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<TypeShipItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        TypeShipItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetTypeShip")]
        [HttpPost]
        public string GetTypeShip(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ShipTypeGuid, Name FROM ShipType";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            TypeShipItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetTypeShip")]
        [HttpPost]
        public string SetTypeShip(TypeShipItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            if (item.ShipTypeGuid == null)
            {
                string ShipTypeGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO ShipType() Values()";
                CsqlIS(ref sql, "ShipTypeGuid", ShipTypeGuid);
                CsqlIS(ref sql, "Name", item.Name);

            }
            else
            {
                TypeShipItem itemOld = new();
                itemOld = GetTypeShipInternal(logonInfo, item.ShipTypeGuid);
                sql = "UPDATE ShipType SET WHERE ShipTypeGuid ='" + item.ShipTypeGuid + "'"; 
                CsqlUS(ref sql, "Name", item.Name, itemOld.Name);
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
                item.Error.ErrorCode = 20;
                item.Error.Message = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        private TypeShipItem GetTypeShipInternal(AccountLogOnInfoItem logonInfo, string ShipTypeGuid)
        {
            string conString;

            string sql = "SELECT ShipTypeGuid, Name FROM ShipType WHERE ShipTypeGuid = '" + ShipTypeGuid + "'";

            TypeShipItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                    }
                }
            }

            return item;
        }


        [Route("RemoveTypeShip")]
        [HttpPost]
        public string RemoveTypeShip(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "DELETE FROM ShipType WHERE " + logonInfo.Parameters.filter;

            SqlConnection cnn;
            SqlCommand cmd;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

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
                retur.Status = 20;
                retur.Description = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("GetShipTypeGeneratorsListe")]
        [HttpPost]
        public string GetShipTypeGeneratorsListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GeneratorGuid, ShipTypeGuid, Name, FuelTypeGuid, TypeGuid, kW, KgDieselkWh, EfficientMotorSwitchboard, MaintenanceCost, PowerProduction, [Order], Standard FROM ShipTypeGenerators";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipTypeGeneratorsItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipTypeGeneratorsItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = (int)rdr.GetInt32(rdr.GetOrdinal("kW")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = rdr.GetDouble(rdr.GetOrdinal("KgDieselkWh")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EfficientMotorSwitchboard"))) { item.EfficientMotorSwitchboard = rdr.GetDouble(rdr.GetOrdinal("EfficientMotorSwitchboard")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = rdr.GetDouble(rdr.GetOrdinal("MaintenanceCost")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = (int)rdr.GetInt16(rdr.GetOrdinal("Order")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Standard"))) { item.Standard = rdr.GetBoolean(rdr.GetOrdinal("Standard")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetShipTypeGenerators")]
        [HttpPost]
        public string GetShipTypeGenerators(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GeneratorGuid, ShipTypeGuid, Name, FuelTypeGuid, TypeGuid, kW, KgDieselkWh, EfficientMotorSwitchboard, MaintenanceCost, PowerProduction, [Order], Standard FROM ShipTypeGenerators";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            ShipTypeGeneratorsItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = (int)rdr.GetInt32(rdr.GetOrdinal("kW")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = rdr.GetDouble(rdr.GetOrdinal("KgDieselkWh")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EfficientMotorSwitchboard"))) { item.EfficientMotorSwitchboard = rdr.GetDouble(rdr.GetOrdinal("EfficientMotorSwitchboard")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = rdr.GetDouble(rdr.GetOrdinal("MaintenanceCost")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Standard"))) { item.Standard = rdr.GetBoolean(rdr.GetOrdinal("Standard")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = (int)rdr.GetInt16(rdr.GetOrdinal("Order")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetShipTypeGenerators")]
        [HttpPost]
        public string SetShipTypeGenerators(ShipTypeGeneratorsItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;
            ReturnValueItem returnValue = new ReturnValueItem();    

            if (item.GeneratorGuid == null)
            {
                item.GeneratorGuid = Guid.NewGuid().ToString();

                returnValue.NewGuid = item.GeneratorGuid;

                sql = "INSERT INTO ShipTypeGenerators() Values()";

                CsqlIS(ref sql, "GeneratorGuid", item.GeneratorGuid);
                CsqlIS(ref sql, "ShipTypeGuid", item.ShipTypeGuid);
                CsqlIS(ref sql, "Name", item.Name);
                CsqlIS(ref sql, "FuelTypeGuid", item.FuelTypeGuid);
                CsqlIS(ref sql, "TypeGuid", item.TypeGuid);
                CsqlII(ref sql, "kW", item.kW);
                CsqlIF(ref sql, "KgDieselkWh", item.KgDieselkWh);
                CsqlIF(ref sql, "EfficientMotorSwitchboard", item.EfficientMotorSwitchboard);
                CsqlIF(ref sql, "MaintenanceCost", item.MaintenanceCost);
                CsqlIB(ref sql, "PowerProduction", item.PowerProduction);
                CsqlII(ref sql, "[Order]", item.Order);
                CsqlIB(ref sql, "Standard", item.Standard);
            }
            else
            {
                ShipTypeGeneratorsItem itemOld = new();
                itemOld = GetShipTypeGeneratorsInternal(logonInfo, item.GeneratorGuid);
                sql = "UPDATE ShipTypeGenerators SET WHERE GeneratorGuid='" + item.GeneratorGuid + "'"; CsqlUS(ref sql, "GeneratorGuid", item.GeneratorGuid, itemOld.GeneratorGuid);
                CsqlUS(ref sql, "ShipTypeGuid", item.ShipTypeGuid, itemOld.ShipTypeGuid);
                CsqlUS(ref sql, "Name", item.Name, itemOld.Name);
                CsqlUS(ref sql, "FuelTypeGuid", item.FuelTypeGuid, itemOld.FuelTypeGuid);
                CsqlUS(ref sql, "TypeGuid", item.TypeGuid, itemOld.TypeGuid);
                CsqlUI(ref sql, "kW", item.kW, itemOld.kW);
                CsqlUF(ref sql, "KgDieselkWh", item.KgDieselkWh, itemOld.KgDieselkWh);
                CsqlUF(ref sql, "EfficientMotorSwitchboard", item.EfficientMotorSwitchboard, itemOld.EfficientMotorSwitchboard);
                CsqlUF(ref sql, "MaintenanceCost", item.MaintenanceCost, itemOld.MaintenanceCost);
                CsqlUB(ref sql, "PowerProduction", item.PowerProduction, itemOld.PowerProduction);
                CsqlUI(ref sql, "[Order]", item.Order, itemOld.Order);
                CsqlUB(ref sql, "Standard", item.Standard, itemOld.Standard);
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
                ErrorItem e = new ErrorItem();
                e.Message = ex.Message;
                e.ErrorCode = 20;
                returnValue.Error.Add(e);
                returnValue.Success = false;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(returnValue);

            return output;
        }

        [Route("GetShipTypeGeneratorsInternal")]
        [HttpPost]
        public ShipTypeGeneratorsItem GetShipTypeGeneratorsInternal(AccountLogOnInfoItem logonInfo, string GeneratorGuid)
        {
            string conString;

            string sql = "SELECT GeneratorGuid, ShipTypeGuid, Name, FuelTypeGuid, TypeGuid, kW, KgDieselkWh, EfficientMotorSwitchboard, MaintenanceCost, PowerProduction, [Order], Standard FROM ShipTypeGenerators WHERE GeneratorGuid = '" + GeneratorGuid + "'";

            ShipTypeGeneratorsItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = rdr.GetInt32(rdr.GetOrdinal("kW")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = rdr.GetDouble(rdr.GetOrdinal("KgDieselkWh")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EfficientMotorSwitchboard"))) { item.EfficientMotorSwitchboard = rdr.GetDouble(rdr.GetOrdinal("EfficientMotorSwitchboard")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = rdr.GetDouble(rdr.GetOrdinal("MaintenanceCost")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Standard"))) { item.Standard = rdr.GetBoolean(rdr.GetOrdinal("Standard")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = rdr.GetInt16(rdr.GetOrdinal("Order")); }
                    }
                }
            }

            return item;
        }

        [Route("RemoveShipTypeGenerators")]
        [HttpPost]
        public string RemoveShipTypeGenerators(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";

            ReturnValueItem returnValue = new ReturnValueItem();

            sql = "DELETE FROM ShipTypeGenerators WHERE GeneratorGuid='" + logonInfo.Parameters.filter + "'";


            SqlConnection cnn;
            SqlCommand cmd;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

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
                ErrorItem e = new ErrorItem();
                e.Message = ex.Message;
                e.ErrorCode = 20;
                returnValue.Error.Add(e);
                returnValue.Success = false;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(returnValue);

            return output;
        }


        [Route("GetShipTypeOperationModesListe")]
        [HttpPost]
        public string GetShipTypeOperationModesListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT OperationModeGuid, ShipTypeGuid, Name, [Order], HoursPrYear, NumberGenerators, Standard FROM ShipTypeOperationModes";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipTypeOperationModesItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipTypeOperationModesItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = rdr.GetInt16(rdr.GetOrdinal("Order")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = rdr.GetInt32(rdr.GetOrdinal("HoursPrYear")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumberGenerators"))) { item.NumberGenerators = rdr.GetInt16(rdr.GetOrdinal("NumberGenerators")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Standard"))) { item.Standard = rdr.GetBoolean(rdr.GetOrdinal("Standard")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetShipTypeOperationModes")]
        [HttpPost]
        public string GetShipTypeOperationModes(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT OperationModeGuid, ShipTypeGuid, Name, [Order], HoursPrYear, NumberGenerators, Standard FROM ShipTypeOperationModes";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            ShipTypeOperationModesItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = (int)rdr.GetInt16(rdr.GetOrdinal("Order")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = (int)rdr.GetInt32(rdr.GetOrdinal("HoursPrYear")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumberGenerators"))) { item.NumberGenerators = (int)rdr.GetInt16(rdr.GetOrdinal("NumberGenerators")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Standard"))) { item.Standard = rdr.GetBoolean(rdr.GetOrdinal("Standard")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetShipTypeOperationModes")]
        [HttpPost]
        public string SetShipTypeOperationModes(ShipTypeOperationModesItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            ReturnValueItem retur = new();

            if (item.OperationModeGuid == null)
            {
                string OperationModeGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO ShipTypeOperationModes() Values()";


                CsqlIS(ref sql, "OperationModeGuid", OperationModeGuid);
                CsqlIS(ref sql, "ShipTypeGuid", item.ShipTypeGuid);
                CsqlIS(ref sql, "Name", item.Name);
                CsqlII(ref sql, "[Order]", item.Order);
                CsqlII(ref sql, "HoursPrYear", item.HoursPrYear);
                CsqlII(ref sql, "NumberGenerators", item.NumberGenerators);
                CsqlIB(ref sql, "Standard", item.Standard);

            }
            else
            {
                ShipTypeOperationModesItem itemOld = new();
                itemOld = GetShipTypeOperationModesInternal(logonInfo, item.OperationModeGuid);
                sql = "UPDATE ShipTypeOperationModes SET WHERE OperationModeGuid='" + item.OperationModeGuid + "'"; 
                CsqlUS(ref sql, "Name", item.Name, itemOld.Name);
                CsqlUI(ref sql, "[Order]", item.Order, itemOld.Order);
                CsqlUI(ref sql, "HoursPrYear", item.HoursPrYear, itemOld.HoursPrYear);
                CsqlUI(ref sql, "NumberGenerators", item.NumberGenerators, itemOld.NumberGenerators);
                CsqlUB(ref sql, "Standard", item.Standard, itemOld.Standard);
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
                ErrorItem e = new ErrorItem();
                e.ErrorCode = 20;
                e.Message = ex.Message;
                retur.Error.Add(e);
                retur.Success = false;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("GetShipTypeOperationModesInternal")]
        [HttpPost]
        public ShipTypeOperationModesItem GetShipTypeOperationModesInternal(AccountLogOnInfoItem logonInfo, string OperationModeGuid)
        {
            string conString;

            string sql = "SELECT OperationModeGuid, ShipTypeGuid, Name, [Order], HoursPrYear, NumberGenerators, Standard FROM ShipTypeOperationModes WHERE OperationModeGuid = '" + OperationModeGuid + "'";

            ShipTypeOperationModesItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = rdr.GetInt16(rdr.GetOrdinal("Order")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = rdr.GetInt32(rdr.GetOrdinal("HoursPrYear")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumberGenerators"))) { item.NumberGenerators = rdr.GetInt16(rdr.GetOrdinal("NumberGenerators")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Standard"))) { item.Standard = rdr.GetBoolean(rdr.GetOrdinal("Standard")); }
                    }
                }
            }

            return item;
        }


        [Route("RemoveShipTypeOperationModes")]
        [HttpPost]
        public string RemoveShipTypeOperationModes(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";

            ReturnValueItem retur = new();


            sql = "DELETE FROM ShipTypeOperationModes WHERE OperationModeGuid='" + logonInfo.Parameters.filter + "'";


            SqlConnection cnn;
            SqlCommand cmd;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

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
                ErrorItem e = new ErrorItem();
                e.ErrorCode = 20;
                e.Message = ex.Message;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        #endregion

        #region Type Power production

        [Route("GetTypePowerProduction")]
        [HttpPost]
        public string GetTypePowerProduction(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT TypeGuid, Name, [Order] FROM PowerProductionType";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            TypePowerProductionItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetTypePowerProduction")]
        [HttpPost]
        public string SetTypePowerProduction(TypePowerProductionItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            if (item.TypeGuid == null)
            {
                string TypeGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO PowerProductionType() Values()";
                CsqlIS(ref sql, "TypeGuid", TypeGuid);
                CsqlIS(ref sql, "Name", item.Name);
                CsqlII(ref sql, "[Order]", item.Order);

            }
            else
            {
                TypePowerProductionItem itemOld = new();
                itemOld = GetTypePowerProductionInternal(logonInfo, item.TypeGuid);
                sql = "UPDATE PowerProductionType SET WHERE TypeGuid='" + item.TypeGuid + "'"; 
                CsqlUS(ref sql, "Name", item.Name, itemOld.Name);
                CsqlUI(ref sql, "[Order]", item.Order, itemOld.Order);
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
                item.Error.ErrorCode = 20;
                item.Error.Message = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        private TypePowerProductionItem GetTypePowerProductionInternal(AccountLogOnInfoItem logonInfo, string TypeGuid)
        {
            string conString;

            string sql = "SELECT TypeGuid, Name, [Order] FROM PowerProductionType WHERE TypeGuid = '" + TypeGuid + "'";

            TypePowerProductionItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                    }
                }
            }

            return item;
        }

        [Route("GetTypePowerProductionList")]
        [HttpPost]
        public string GetTypePowerProductionList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT TypeGuid, Name, [Order] FROM PowerProductionType";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<TypePowerProductionItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        TypePowerProductionItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("RemoveTypePowerProduction")]
        [HttpPost]
        public string RemoveTypePowerProduction(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "DELETE FROM PowerProductionType WHERE " + logonInfo.Parameters.filter;

            SqlConnection cnn;
            SqlCommand cmd;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

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
                retur.Status = 20;
                retur.Description = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        #endregion

        #region Type Equipment

        [Route("SetTypeEquipment")]
        [HttpPost]
        public string SetTypeEquipment(TypeEquipmentItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            if (item.EquipmentTypesGuid == null)
            {
                string EquipmentTypesGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO EquipmentTypes() Values()";
                CsqlIS(ref sql, "EquipmentTypesGuid", EquipmentTypesGuid);
                CsqlII(ref sql, "Type", item.Type);
                CsqlIS(ref sql, "Name", item.Name);
            }
            else
            {
                TypeEquipmentItem itemOld = new();
                itemOld = GetTypeEquipmentInternal(logonInfo, item.EquipmentTypesGuid);
                sql = "UPDATE EquipmentTypes SET WHERE EquipmentTypesGuid='" + item.EquipmentTypesGuid + "'"; 
                CsqlUI(ref sql, "Type", item.Type, itemOld.Type);
                CsqlUS(ref sql, "Name", item.Name, itemOld.Name);
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
                item.Error.ErrorCode = 20;
                item.Error.Message = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("GetTypeEquipment")]
        [HttpPost]
        public string GetTypeEquipment(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT Type, Name, EquipmentTypesGuid FROM EquipmentTypes";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            TypeEquipmentItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentTypesGuid"))) { item.EquipmentTypesGuid = rdr.GetString(rdr.GetOrdinal("EquipmentTypesGuid")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("GetTypeEquipmentList")]
        [HttpPost]
        public string GetTypeEquipmentList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT Type, Name, EquipmentTypesGuid FROM EquipmentTypes";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<TypeEquipmentItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        TypeEquipmentItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentTypesGuid"))) { item.EquipmentTypesGuid = rdr.GetString(rdr.GetOrdinal("EquipmentTypesGuid")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        private TypeEquipmentItem GetTypeEquipmentInternal(AccountLogOnInfoItem logonInfo, string EquipmentTypesGuid)
        {
            string conString;

            string sql = "SELECT Type, Name, EquipmentTypesGuid FROM EquipmentTypes WHERE EquipmentTypesGuid = '" + EquipmentTypesGuid + "'";

            TypeEquipmentItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentTypesGuid"))) { item.EquipmentTypesGuid = rdr.GetString(rdr.GetOrdinal("EquipmentTypesGuid")); }
                    }
                }
            }

            return item;
        }


        [Route("RemoveTypeEquipment")]
        [HttpPost]
        public string RemoveTypeEquipment(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "DELETE FROM EquipmentTypes WHERE " + logonInfo.Parameters.filter;

            SqlConnection cnn;
            SqlCommand cmd;

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

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
                retur.Status = 20;
                retur.Description = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }



        #endregion

        #region Equipment library

        [Route("GetEquipmentLibraryListe")]
        [HttpPost]
        public string GetEquipmentLibraryListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT LibraryGuid, ProfileName, EquipmentType, FunctionDescription, Notes FROM EquipmentLibrary";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<EquipmentLibraryItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        EquipmentLibraryItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LibraryGuid"))) { item.LibraryGuid = rdr.GetString(rdr.GetOrdinal("LibraryGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfileName"))) { item.ProfileName = rdr.GetString(rdr.GetOrdinal("ProfileName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentType"))) { item.EquipmentType = rdr.GetString(rdr.GetOrdinal("EquipmentType")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FunctionDescription"))) { item.FunctionDescription = rdr.GetString(rdr.GetOrdinal("FunctionDescription")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Notes"))) { item.Notes = rdr.GetString(rdr.GetOrdinal("Notes")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetEquipmentLibrary")]
        [HttpPost]
        public string GetEquipmentLibrary(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT LibraryGuid, ProfileName, EquipmentType, FunctionDescription, Notes FROM EquipmentLibrary";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            EquipmentLibraryItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LibraryGuid"))) { item.LibraryGuid = rdr.GetString(rdr.GetOrdinal("LibraryGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfileName"))) { item.ProfileName = rdr.GetString(rdr.GetOrdinal("ProfileName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentType"))) { item.EquipmentType = rdr.GetString(rdr.GetOrdinal("EquipmentType")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FunctionDescription"))) { item.FunctionDescription = rdr.GetString(rdr.GetOrdinal("FunctionDescription")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Notes"))) { item.Notes = rdr.GetString(rdr.GetOrdinal("Notes")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetEquipmentLibrary")]
        [HttpPost]
        public string SetEquipmentLibrary(EquipmentLibraryItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            if (item.LibraryGuid == null)
            {
                string LibraryGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO EquipmentLibrary() Values()";


                CsqlIS(ref sql, "LibraryGuid", LibraryGuid);
                CsqlIS(ref sql, "ProfileName", item.ProfileName);
                CsqlIS(ref sql, "EquipmentType", item.EquipmentType);
                CsqlIS(ref sql, "FunctionDescription", item.FunctionDescription);
                CsqlIS(ref sql, "Notes", item.Notes);

            }
            else
            {
                EquipmentLibraryItem itemOld = new();
                itemOld = GetEquipmentLibraryInternal(logonInfo, item.LibraryGuid);
                sql = "UPDATE EquipmentLibrary SET WHERE LibraryGuid='" + item.LibraryGuid + "'"; 
                CsqlUS(ref sql, "ProfileName", item.ProfileName, itemOld.ProfileName);
                CsqlUS(ref sql, "EquipmentType", item.EquipmentType, itemOld.EquipmentType);
                CsqlUS(ref sql, "FunctionDescription", item.FunctionDescription, itemOld.FunctionDescription);
                CsqlUS(ref sql, "Notes", item.Notes, itemOld.Notes);
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
                item.Error.ErrorCode = 20;
                item.Error.Message = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        private EquipmentLibraryItem GetEquipmentLibraryInternal(AccountLogOnInfoItem logonInfo, string LibraryGuid)
        {
            string conString;

            string sql = "SELECT LibraryGuid, ProfileName, EquipmentType, FunctionDescription, Notes FROM EquipmentLibrary WHERE LibraryGuid = '" + LibraryGuid + "'";

            EquipmentLibraryItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LibraryGuid"))) { item.LibraryGuid = rdr.GetString(rdr.GetOrdinal("LibraryGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfileName"))) { item.ProfileName = rdr.GetString(rdr.GetOrdinal("ProfileName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentType"))) { item.EquipmentType = rdr.GetString(rdr.GetOrdinal("EquipmentType")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FunctionDescription"))) { item.FunctionDescription = rdr.GetString(rdr.GetOrdinal("FunctionDescription")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Notes"))) { item.Notes = rdr.GetString(rdr.GetOrdinal("Notes")); }
                    }
                }
            }

            return item;
        }


        #endregion

        #region Vendor

        [Route("GetGeneratorVendor")]
        [HttpPost]
        public string GetGeneratorVendor(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GeneratorVendorGuid, Vendor FROM GeneratorVendor";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            GeneratorVendorItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorVendorGuid"))) { item.GeneratorVendorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorVendorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Vendor"))) { item.Vendor = rdr.GetString(rdr.GetOrdinal("Vendor")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }


        [Route("SetGeneratorVendor")]
        [HttpPost]
        public string SetGeneratorVendor(GeneratorVendorItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;
            ReturnValueItem retur = new();

            if (item.GeneratorVendorGuid == null)
            {
                string GeneratorVendorGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO GeneratorVendor() Values()";


                CsqlIS(ref sql, "GeneratorVendorGuid", GeneratorVendorGuid);
                CsqlIS(ref sql, "Vendor", item.Vendor);

            }
            else
            {
                GeneratorVendorItem itemOld = new();
                itemOld = GetGeneratorVendorInternal(logonInfo, item.GeneratorVendorGuid);
                sql = "UPDATE GeneratorVendor SET WHERE GeneratorVendorGuid = '" + item.GeneratorVendorGuid  + "'"; CsqlUS(ref sql, "GeneratorVendorGuid", item.GeneratorVendorGuid, itemOld.GeneratorVendorGuid);
                CsqlUS(ref sql, "Vendor", item.Vendor, itemOld.Vendor);
                if (sql.IndexOf("SET WHERE") > -1)
                {
                    sql = "";
                }
            }

            if (sql != "") { 
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
                    ErrorItem e = new();
                    e.ErrorCode = 20;
                    e.Message = ex.Message;
                    retur.Error.Add(e);
                    transaction.Rollback();
                }
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("GetGeneratorVendorList")]
        [HttpPost]
        public string GetGeneratorVendorList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GeneratorVendorGuid, Vendor FROM GeneratorVendor";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<GeneratorVendorItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        GeneratorVendorItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorVendorGuid"))) { item.GeneratorVendorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorVendorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Vendor"))) { item.Vendor = rdr.GetString(rdr.GetOrdinal("Vendor")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        private GeneratorVendorItem GetGeneratorVendorInternal(AccountLogOnInfoItem logonInfo, string GeneratorVendorGuid)
        {
            string conString;

            string sql = "SELECT GeneratorVendorGuid, Vendor FROM GeneratorVendor WHERE GeneratorVendorGuid = '" + GeneratorVendorGuid + "'";

            GeneratorVendorItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorVendorGuid"))) { item.GeneratorVendorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorVendorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Vendor"))) { item.Vendor = rdr.GetString(rdr.GetOrdinal("Vendor")); }
                    }
                }
            }

            return item;
        }


        [Route("RemoveGeneratorVendor")]
        [HttpPost]
        public string RemoveGeneratorVendor(GeneratorVendorItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;
            ReturnValueItem retur = new();

            if (item.GeneratorVendorGuid != null && item.GeneratorVendorGuid.Length>0) { 
                List<GeneratorModelItem> items = GetGeneratorModelInternalList(logonInfo, item.GeneratorVendorGuid);

                sql = "DELETE FROM GeneratorVendor WHERE GeneratorVendorGuid = '" + item.GeneratorVendorGuid + "'";
                foreach(GeneratorModelItem itm in items)
                {
                    sql += ";DELETE FROM GeneratorModel WHERE GeneratorModelGuid = '" + itm.GeneratorModelGuid + "'";
                    sql += ";DELETE FROM FuelConsumptions WHERE LinkGuid = '" + itm.GeneratorModelGuid + "'";
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
                    ErrorItem e = new();
                    e.ErrorCode = 20;
                    e.Message = ex.Message;
                    retur.Error.Add(e);
                    transaction.Rollback();
                }
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        #endregion

        #region Model

        [Route("GetGeneratorModel")]
        [HttpPost]
        public string GetGeneratorModel(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GeneratorModelGuid, GeneratorVendorGuid, Model, FuelTypeGuid, TypeGuid, kW, KgDieselkWh, EfficientMotorSwitchboard, MaintenanceCost, PowerProduction FROM GeneratorModel";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            GeneratorModelItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModelGuid"))) { item.GeneratorModelGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModelGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorVendorGuid"))) { item.GeneratorVendorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorVendorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Model"))) { item.Model = rdr.GetString(rdr.GetOrdinal("Model")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = (int)rdr.GetInt32(rdr.GetOrdinal("kW")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EfficientMotorSwitchboard"))) { item.EfficientMotorSwitchboard = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("EfficientMotorSwitchboard"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("MaintenanceCost"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetGeneratorModel")]
        [HttpPost]
        public string SetGeneratorModel(GeneratorModelItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            ReturnValueItem retur = new();

            if (item.GeneratorModelGuid == null)
            {
                string GeneratorModelGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO GeneratorModel() Values()";

                CsqlIS(ref sql, "GeneratorModelGuid", GeneratorModelGuid);
                CsqlIS(ref sql, "GeneratorVendorGuid", item.GeneratorVendorGuid);
                CsqlIS(ref sql, "Model", item.Model);
                CsqlIS(ref sql, "FuelTypeGuid", item.FuelTypeGuid);
                CsqlIS(ref sql, "TypeGuid", item.TypeGuid);
                CsqlII(ref sql, "kW", item.kW);
                CsqlIF(ref sql, "KgDieselkWh", item.KgDieselkWh);
                CsqlIF(ref sql, "EfficientMotorSwitchboard", item.EfficientMotorSwitchboard);
                CsqlIF(ref sql, "MaintenanceCost", item.MaintenanceCost);
                CsqlIB(ref sql, "PowerProduction", item.PowerProduction);
            }
            else
            {
                GeneratorModelItem itemOld = new();
                itemOld = GetGeneratorModelInternal(logonInfo, item.GeneratorModelGuid);
                sql = "UPDATE GeneratorModel SET WHERE GeneratorModelGuid = '" + item.GeneratorModelGuid + "'"; 
                CsqlUS(ref sql, "GeneratorVendorGuid", item.GeneratorVendorGuid, itemOld.GeneratorVendorGuid);
                CsqlUS(ref sql, "Model", item.Model, itemOld.Model);
                CsqlUS(ref sql, "TypeGuid", item.TypeGuid, itemOld.TypeGuid);
                CsqlUI(ref sql, "kW", item.kW, itemOld.kW);
                CsqlUF(ref sql, "KgDieselkWh", item.KgDieselkWh, itemOld.KgDieselkWh);
                CsqlUF(ref sql, "EfficientMotorSwitchboard", item.EfficientMotorSwitchboard, itemOld.EfficientMotorSwitchboard);
                CsqlUF(ref sql, "MaintenanceCost", item.MaintenanceCost, itemOld.MaintenanceCost);
                CsqlUB(ref sql, "PowerProduction", item.PowerProduction, itemOld.PowerProduction);

                if (sql.IndexOf("SET WHERE")>-1)
                {
                    sql = "";
                }
                
            }

            if (sql != "") { 

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
                    ErrorItem e = new();
                    e.ErrorCode = 20;
                    e.Message = ex.Message;
                    retur.Error.Add(e);
                    transaction.Rollback();
                }
            }
            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("RemoveGeneratorModel")]
        [HttpPost]
        public string RemoveGeneratorModel(GeneratorModelItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            ReturnValueItem retur = new();

            sql = "DELETE FROM GeneratorModel WHERE GeneratorModelGuid = '" + item.GeneratorModelGuid + "'";
            sql += ";DELETE FROM FuelConsumptions WHERE LinkGuid = '" + item.GeneratorModelGuid + "'";

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
                ErrorItem e = new();
                e.ErrorCode = 20;
                e.Message = ex.Message;
                retur.Error.Add(e);
                transaction.Rollback();
            }
            
            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        private GeneratorModelItem GetGeneratorModelInternal(AccountLogOnInfoItem logonInfo, string GeneratorModelGuid)
        {
            string conString;

            string sql = "SELECT GeneratorModelGuid, GeneratorVendorGuid, Model FROM GeneratorModel WHERE GeneratorModelGuid = '" + GeneratorModelGuid + "'";

            GeneratorModelItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModelGuid"))) { item.GeneratorModelGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModelGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorVendorGuid"))) { item.GeneratorVendorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorVendorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Model"))) { item.Model = rdr.GetString(rdr.GetOrdinal("Model")); }
                    }
                }
            }

            return item;
        }

        private List<GeneratorModelItem> GetGeneratorModelInternalList(AccountLogOnInfoItem logonInfo, string GeneratorVendorGuid)
        {
            string conString;

            string sql = "SELECT GeneratorModelGuid, GeneratorVendorGuid, Model FROM GeneratorModel WHERE GeneratorVendorGuid = '" + GeneratorVendorGuid + "'";

            List<GeneratorModelItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        GeneratorModelItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModelGuid"))) { item.GeneratorModelGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModelGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorVendorGuid"))) { item.GeneratorVendorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorVendorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Model"))) { item.Model = rdr.GetString(rdr.GetOrdinal("Model")); }
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        [Route("ImportGeneratorModel")]
        [HttpPost]
        public string ImportGeneratorModel(GeneratorImportItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            ReturnValueItem retur = new();

            string generatorGuid = Guid.NewGuid().ToString();

            sql = "INSERT INTO  Generators(GeneratorGuid, ShipGuid, Name, FuelTypeGuid, TypeGuid, kW, KgDieselkWh, EfficientMotorSwitchboard, MaintenanceCost, PowerProduction) " +
                "SELECT '" + generatorGuid + "' GeneratorGuid, '" + item.ShipGuid + "' ShipGuid, Model Name, FuelTypeGuid, TypeGuid, kW, KgDieselkWh, EfficientMotorSwitchboard, MaintenanceCost, PowerProduction " +
                "FROM GeneratorModel " +
                "WHERE (GeneratorModelGuid = '" + item.GeneratorModelGuid + "')";
            sql += ";INSERT INTO FuelConsumptions SELECT FuelConsGuid, '" + generatorGuid + "' LinkGuid, Effect, KgDieselkWh " +
                            "FROM FuelConsumptions " +
                            "WHERE(LinkGuid = '" + item.GeneratorModelGuid + "')";

            if (sql != "")
            {

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
                    ErrorItem e = new();
                    e.ErrorCode = 20;
                    e.Message = ex.Message;
                    retur.Error.Add(e);
                    transaction.Rollback();
                }
            }
            string output = JsonConvert.SerializeObject(retur);

            return output;
        }



        [Route("GetGeneratorModelList")]
        [HttpPost]
        public string GetGeneratorModelList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GeneratorModelGuid, GeneratorVendorGuid, Model FROM GeneratorModel";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<GeneratorModelItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        GeneratorModelItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModelGuid"))) { item.GeneratorModelGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModelGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorVendorGuid"))) { item.GeneratorVendorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorVendorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Model"))) { item.Model = rdr.GetString(rdr.GetOrdinal("Model")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetGeneratorVendorModelList")]
        [HttpPost]
        public string GetGeneratorVendorModelList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GV.GeneratorVendorGuid, GV.Vendor, GM.GeneratorModelGuid, GM.Model " +
                "FROM GeneratorVendor AS GV INNER JOIN " +
                "GeneratorModel AS GM ON GV.GeneratorVendorGuid = GM.GeneratorVendorGuid " +
                "ORDER BY GV.Vendor, GM.Model";

            List<GeneratorVendorModelItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        GeneratorVendorModelItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorVendorGuid"))) { item.GeneratorVendorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorVendorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Vendor"))) { item.Vendor = rdr.GetString(rdr.GetOrdinal("Vendor")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModelGuid"))) { item.GeneratorModelGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModelGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Model"))) { item.Model = rdr.GetString(rdr.GetOrdinal("Model")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("ImportFuelComsuption")]
        [HttpPost]
        public string ImportFuelComsuption(FuelComsuptionImportItem item)
        {
            string conString;

            ReturnValueItem retur = new();

            string sql = "DELETE FROM FuelConsumptions WHERE LinkGuid='" + item.GeneratorGuid + "'";
            sql += ";INSERT INTO FuelConsumptions SELECT FuelConsGuid, '" + item.GeneratorGuid + "' LinkGuid, Effect, KgDieselkWh " +
                "FROM FuelConsumptions " +
                "WHERE(LinkGuid = '" + item.FromGuid + "')";

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
                ErrorItem e = new();
                e.ErrorCode = 20;
                e.Message = ex.Message;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        #endregion

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
            strWhere = SQLQ.Substring(p1 -1);
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
