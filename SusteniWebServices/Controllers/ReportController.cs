using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.Profile;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Xml;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using Telerik.Reporting.Services.Engine;
using static SQLite.SQLite3;
using Spire.Doc.Documents;
using Spire.Pdf.Exporting.XPS.Schema;
using Spire.Doc;
using Spire.Doc.Fields;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Reflection;


public class VarTypeItem
{
    public string Navn { get; set; } = "";
    public string Verdi { get; set; } = "";
}

public class ReportPreview
{
    public string RapId { get; set; } = "";
    public string shipGuid { get; set; } = "";
    public string base64String { get; set; } = "";
    public AccountLogOnInfoItem logonInfo { get; set; } = new();

}

public class ReportImageItem
{
    public string id { get; set; } = "";
    public string ProfilGuid { get; set; } = "";
    public string Profile { get; set; } = "";
    public string Tittel { get; set; } = "";
    public string Image { get; set; } = "";
    public AccountLogOnInfoItem logonInfo { get; set; } = new();
}

public class ReportPreviewItem
{
    public string Base64String { get; set; } = "";
    public string ErrorTekst { get; set; } = "";
    public int ErrorCode { get; set; } = 0;
}

public class ReportItem
{
    public string? ReportGuid { get; set; } = "";
    public string CustomerGuid { get; set; } = "";
    public int PrintCount { get; set; } = 0;
    public string Filnavn { get; set; } = "";
    public string RapId { get; set; } = "";
    public int RapType { get; set; } = 0;
    public string Tittel { get; set; } = "";
    public string? Beskrivelse { get; set; } = "";
    public string? Kategori { get; set; } = "";
    public string Skjerm { get; set; } = "";
    public int Orientering { get; set; } = 0;
    public bool HarFiler { get; set; } = false;
    public bool KreverSelektering { get; set; } = false;
    public DateTime? LastPrintDate { get; set; } = null;
    public DateTime? DatoEndret { get; set; } = null;
    public bool Aktiv { get; set; } = false;
    public bool SkjulBunntekst { get; set; } = false;
    public int Sortering { get; set; } = 0;
    public string OpprettetAv { get; set; } = "";
    public DateTime? OpprettetDate { get; set; } = null;
    public string? EndretAv { get; set; } = "";
    public DateTime? EndretDato { get; set; } = null;
    public string? SlettetAv { get; set; } = "";
    public DateTime? SlettetDato { get; set; } = null;
    public string Mappe { get; set; } = "";
    public int RegType { get; set; } = 0;

    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class GetReportItems
{
    public string? RapId { get; set; } = "";
    public string? Screen { get; set; } = "";
    public string? Category { get; set; } = "";
    public int RapType { get; set; } = 0;
    public bool Preview { get; set; } = false;
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class ReportItems
{
    public bool Success { get; set; } = true;
    public List<ErrorItem> ErrorInfo { get; set; } = new();

    public List<ReportListeItem> items { get; set; } = new();
}

public class ReportListeItem
{
    public string Fellesraad { get; set; } = "";
    public string Eier { get; set; } = "";
    public string RapId { get; set; } = "";
    public string Filnavn { get; set; } = "";
    public string fileGuid { get; set; } = "";
    public string Skjerm { get; set; } = "";
    public string Tittel { get; set; } = "";
    public string Beskrivelse { get; set; } = "";
    public string Mappe { get; set; } = "";
    public string Preview { get; set; } = "";
    public int RapType { get; set; } = 0;
    public bool HarFiler { get; set; } = false;
    public bool Aktiv { get; set; } = true;
    public bool Skjul { get; set; } = false;
    public bool Godkjent { get; set; } = false;
    public bool EgenSelektering { get; set; } = false;
    public bool KunEnRecord { get; set; } = false;
    public int ProgramId { get; set; } = 0;
}

public class DocumentListeItem
{
    public string fileGuid = "";
    public string Tittel = "";
}
public class GetReportItem
{
    public string RapId { get; set; } = "";
    public string CustomerGuid { get; set; } = "";
    public bool Preview { get; set; } = false;

    public List<VarTypeItem> Verdier = new List<VarTypeItem>();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class UploadReportFilerItem
{
    public string? RapId { get; set; } = "";
    public string? CustomerGuid { get; set; }
    public string? ReportFilesGuid { get; set; }
    public DateTime? Dato { get; set; }
    public string? FilNavn { get; set; }
    public string? Ext { get; set; } = "";
    public string Base64String { get; set; } = "";
    public string? Preview { get; set; }
    public int? Versjon { get; set; }
    public bool ErstattSiste { get; set; }
    public string EndretAv { get; set; } = "";
    public DateTime? EndretDato { get; set; }
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ReportFilesItem
{
    public string ReportFilesGuid { get; set; } = "";
    public string RapportGuid { get; set; } = "";
    public string RapId { get; set; } = "";
    public string CustomerGuid { get; set; } = "";
    public DateTime? Dato { get; set; } = null;
    public string FilNavn { get; set; } = "";
    public string Preview { get; set; } = "";
    public int Versjon { get; set; } = 0;
    public string EndretAv { get; set; } = "";
    public DateTime? EndretDato { get; set; } = null;
    public bool BeholdTopptekst { get; set; } = false;
    public bool BeholdBunntekst { get; set; } = false;
}

public class ReportQuestionItem
{
    public string ReportSporsmalGuid { get; set; } = "";
    public string RapId { get; set; } = "";
    public string Kode { get; set; } = "";
    public int Type { get; set; } = 0;
    public string TypeNavn { get; set; } = "";
    public string Tekst { get; set; } = "";
    public int PosX { get; set; } = 0;
    public int PosY { get; set; } = 0;
    public int Vidde { get; set; } = 0;
    public int Hoyde { get; set; } = 0;
    public string? Font { get; set; } = "";
    public bool Uthevet { get; set; } = false;
    public int Storrelse { get; set; } = 0;
    public string? Farge { get; set; } = "";
    public int ReturVerdi { get; set; } = 0;
    public string? SQL { get; set; } = "";
    public string? StandardVerdi { get; set; } = "";
    public string? OpprettetAv { get; set; } = "";
    public DateTime? OpprettetDate { get; set; } = null;
    public string? EndretAv { get; set; } = "";
    public DateTime? EndretDato { get; set; } = null;
    public string? SlettetAv { get; set; } = "";
    public DateTime? SlettetDato { get; set; } = null;
    public bool SkalerBredde { get; set; } = false;
    public bool SkalerHoyde { get; set; } = false;
    public bool Flytt { get; set; } = false;
    public bool Flerlinje { get; set; } = false;
    public List<ReportValueListItems> Values { get; set; } = new List<ReportValueListItems>();

    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ReportValueListItems
{
    public string Kode { get; set; }
    public string Verdi { get; set; }
    public List<string> Verdiliste { get; set; }
}

public class ReportSQLItem
{
    public string? ReportSQLGuid { get; set; } = "";
    public string RapId { get; set; } = "";
    public int Type { get; set; } = 0;
    public int Stadie { get; set; } = 0;
    public string Kode { get; set; } = "";
    public int Rekkefolge { get; set; } = 0;
    public string? Format { get; set; } = "";
    public string SQL { get; set; } = "";
    public string? OpprettetAv { get; set; } = "";
    public DateTime? OpprettetDate { get; set; } = null;
    public string? EndretAv { get; set; } = "";
    public DateTime? EndretDato { get; set; } = null;
    public string? SlettetAv { get; set; } = "";
    public DateTime? SlettetDato { get; set; } = null;
    public string? IsNotNullField { get; set; } = "";
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class SQLVerdierItem
{
    public string FeltNavn = "";
    public string Verdi = "";
    public string FontNavn = "";
    public string ForeColor = "";
    public string BackColor = "";
    public string Type = "";
    public int FormeltType = -1;
}

public class DemoValuesItem
{
    public string Name = "";
    public string Value = "";
}

public class TemplateSQLItem
{
    public string Kode { get; set; } = "";
    public string Tabell { get; set; } = "";
    public string Felt { get; set; } = "";
    public string SQL { get; set; } = "";
    public int Type { get; set; } = 0;
    public string IsNotNullField { get; set; } = "";
    public string Select_Guid { get; set; } = "";
    public int Stadie { get; set; } = 0;
}


public class DocumentItems
{
    public string Tittel { get; set; }
    public string RapId { get; set; }
    public string MasterVerdier { get; set; }
    public string MasterNavn { get; set; }
    public List<DocumentValueListItem> Verdier { get; set; } = new List<DocumentValueListItem>();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class DocumentValueListItem
{
    public string Kode { get; set; }
    public string Verdi { get; set; }
    //public List<string> Verdiliste { get; set; }
}


namespace SusteniWebServices.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        #region Rapport definitation

        [Route("GetReportList")]
        [HttpPost]
        public string GetReportList(GetReportItems item)
        {
            string strSQL = "";

            strSQL = @"SELECT RapId, Tittel, Beskrivelse, Mappe, Filnavn, Skjerm, RapType, Aktiv, HarFiler = (SELECT COUNT(*) FROM REPORT_FILES WHERE RapId=REPORT.RapId)
                FROM Report";

            if (item.RapType >= 0)
            {
                strSQL += " WHERE RapType=" + item.RapType + "";
            }

            if (item.Screen != null && item.Screen.Length>0)
            {
                if (item.RapType == -1) { strSQL += " WHERE "; } else { strSQL += " AND "; }
                strSQL += "Skjerm='" + item.Screen + "'";
            }
            strSQL += " ORDER BY Skjerm, Mappe, Tittel";

            string conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            ReportItems Report = new ReportItems();
            List<ReportListeItem> ReportItems = new List<ReportListeItem>();

            using (SqlConnection cnnG6 = new SqlConnection(conString))
            {
                cnnG6.Open();

                try
                {
                    SqlCommand objCom = cnnG6.CreateCommand();
                    objCom.CommandType = CommandType.Text;
                    objCom.CommandText = strSQL;

                    SqlDataReader objDR = objCom.ExecuteReader(CommandBehavior.CloseConnection);

                    {
                        while (objDR.Read())
                        {
                            ReportListeItem ReportItem = new ReportListeItem();
                            if (!objDR.IsDBNull(objDR.GetOrdinal("Rapid"))) ReportItem.RapId = objDR.GetString(objDR.GetOrdinal("Rapid"));
                            if (!objDR.IsDBNull(objDR.GetOrdinal("Filnavn"))) ReportItem.Filnavn = objDR.GetString(objDR.GetOrdinal("Filnavn"));
                            if (!objDR.IsDBNull(objDR.GetOrdinal("Skjerm"))) ReportItem.Skjerm = objDR.GetString(objDR.GetOrdinal("Skjerm"));
                            if (!objDR.IsDBNull(objDR.GetOrdinal("Mappe"))) ReportItem.Mappe = objDR.GetString(objDR.GetOrdinal("Mappe"));
                            if (!objDR.IsDBNull(objDR.GetOrdinal("Tittel"))) ReportItem.Tittel = objDR.GetString(objDR.GetOrdinal("Tittel"));
                            if (!objDR.IsDBNull(objDR.GetOrdinal("Beskrivelse"))) ReportItem.Beskrivelse = objDR.GetString(objDR.GetOrdinal("Beskrivelse"));
                            if (!objDR.IsDBNull(objDR.GetOrdinal("RapType"))) ReportItem.RapType = Convert.ToInt16(objDR.GetValue(objDR.GetOrdinal("RapType")));
                            if (!objDR.IsDBNull(objDR.GetOrdinal("Aktiv"))) ReportItem.Aktiv = (bool)objDR.GetValue(objDR.GetOrdinal("Aktiv"));
                            if ((int)objDR.GetValue(objDR.GetOrdinal("HarFiler")) > 0)
                                ReportItem.HarFiler = true;
                            else
                                ReportItem.HarFiler = false;

                            if (ReportItem.Mappe.Length == 0)
                                ReportItem.Mappe = "Missing";

                            if (item.Preview)
                            {
                                string sql = "";
                                sql = "SELECT TOP 1 Preview FROM REPORT_FILES WHERE RapId = '" + ReportItem.RapId + "' AND (CustomerGuid IS NULL OR CustomerGuid='" + item.logonInfo.CustomerGuid + "') ORDER BY CustomerGuid DESC, Dato DESC";

                                SqlConnection cnnG6B = new SqlConnection(conString);
                                cnnG6B.Open();

                                SqlCommand command1 = new SqlCommand(sql, cnnG6B);
                                byte[] img = (byte[])command1.ExecuteScalar();
                                if (img != null && img.Length > 0)
                                {
                                    ReportItem.Preview = Convert.ToBase64String(img);
                                }
                                else
                                    try
                                    {
                                        byte[] data = System.IO.File.ReadAllBytes("images/document-text-graph.png");
                                        ReportItem.Preview = Convert.ToBase64String(data);
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                cnnG6B.Close();
                            }

                            ReportItems.Add(ReportItem);
                        }
                    }

                    Report.items = ReportItems;
                }
                catch (SqlException ex)
                {
                    ErrorItem error = new();
                    error.Message = ex.Message;
                    error.ErrorCode = ex.ErrorCode;

                    Report.Success = false;
                    Report.ErrorInfo.Add(error);
                }
            }

            string output = JsonConvert.SerializeObject(Report);

            return output;
        }


        [Route("GetReportDocumentList")]
        [HttpPost]
        public string GetReportDocumentList(GetReportItems item)
        {
            string strSQL = "";

            strSQL = @"SELECT R.Tittel, RF.ReportFilesGuid " +
                    "FROM   Report AS R INNER JOIN Report_Files AS RF ON R.RapId = RF.RapId " +
                    "WHERE  (R.Skjerm = '" + item.Screen + "') AND (R.Mappe = 'Dokumentation') ";

            strSQL += " ORDER BY Tittel";

            string conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            ReportItems Report = new ReportItems();
            List<DocumentListeItem> ReportItems = new List<DocumentListeItem>();

            using (SqlConnection cnnG6 = new SqlConnection(conString))
            {
                cnnG6.Open();

                try
                {
                    SqlCommand objCom = cnnG6.CreateCommand();
                    objCom.CommandType = CommandType.Text;
                    objCom.CommandText = strSQL;

                    SqlDataReader objDR = objCom.ExecuteReader(CommandBehavior.CloseConnection);

                    {
                        while (objDR.Read())
                        {
                            DocumentListeItem ReportItem = new DocumentListeItem();
                            if (!objDR.IsDBNull(objDR.GetOrdinal("ReportFilesGuid"))) ReportItem.fileGuid = objDR.GetString(objDR.GetOrdinal("ReportFilesGuid"));
                            if (!objDR.IsDBNull(objDR.GetOrdinal("Tittel"))) ReportItem.Tittel = objDR.GetString(objDR.GetOrdinal("Tittel"));

                            ReportItems.Add(ReportItem);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    ErrorItem error = new();
                    error.Message = ex.Message;
                    error.ErrorCode = ex.ErrorCode;

                    Report.Success = false;
                    Report.ErrorInfo.Add(error);
                }
            }

            string output = JsonConvert.SerializeObject(ReportItems);

            return output;
        }

        [Route("GetReportDocument")]
        [HttpPost]
        public string GetReportDocument(AccountLogOnInfoItem LogonInfo)
        {
            string conString;

            conString = @"server=" + LogonInfo.Server + ";User Id=" + LogonInfo.UserId + ";password=" + LogonInfo.Password + ";database=" + LogonInfo.Database + ";TrustServerCertificate=True";

            SqlConnection connection = new SqlConnection(conString);

            string sql = "SELECT Fil FROM Report_Files WHERE ReportFilesGuid=@ReportFilesGuid ";

            connection.Open();
            SqlCommand command1 = new SqlCommand(sql, connection);
            SqlParameter myparam = command1.Parameters.Add("@ReportFilesGuid", SqlDbType.NVarChar, 40);
            myparam.Value = LogonInfo.Parameters.fieldValue;
            byte[] img = (byte[])command1.ExecuteScalar();

            string base64string = Convert.ToBase64String(img);

            return base64string;
        }

        [Route("GetReport")]
        [HttpPost]
        public string GetReport(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT PrintCount, Filnavn, RapId, CustomerGuid, RapType, RapportGuid, Tittel, Beskrivelse, Kategori, Skjerm, Orientering, LastPrintDate, DatoEndret, Aktiv, SkjulBunntekst, Sortering, OpprettetAv, OpprettetDate, EndretAv, EndretDato, SlettetAv, SlettetDato, Mappe, RegType FROM Report";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            ReportItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapportGuid"))) { item.ReportGuid = rdr.GetString(rdr.GetOrdinal("RapportGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PrintCount"))) { item.PrintCount = (Int16)rdr.GetValue(rdr.GetOrdinal("PrintCount")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Filnavn"))) { item.Filnavn = rdr.GetString(rdr.GetOrdinal("Filnavn")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerGuid"))) { item.CustomerGuid = rdr.GetString(rdr.GetOrdinal("CustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapType"))) { item.RapType = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("RapType"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tittel"))) { item.Tittel = rdr.GetString(rdr.GetOrdinal("Tittel")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Beskrivelse"))) { item.Beskrivelse = rdr.GetString(rdr.GetOrdinal("Beskrivelse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kategori"))) { item.Kategori = rdr.GetString(rdr.GetOrdinal("Kategori")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Skjerm"))) { item.Skjerm = rdr.GetString(rdr.GetOrdinal("Skjerm")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Orientering"))) { item.Orientering = (Int16)rdr.GetValue(rdr.GetOrdinal("Orientering")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LastPrintDate"))) { item.LastPrintDate = rdr.GetDateTime(rdr.GetOrdinal("LastPrintDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("DatoEndret"))) { item.DatoEndret = rdr.GetDateTime(rdr.GetOrdinal("DatoEndret")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Aktiv"))) { item.Aktiv = rdr.GetBoolean(rdr.GetOrdinal("Aktiv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SkjulBunntekst"))) { item.SkjulBunntekst = rdr.GetBoolean(rdr.GetOrdinal("SkjulBunntekst")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Sortering"))) { item.Sortering = (Int16)rdr.GetValue(rdr.GetOrdinal("Sortering")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDate"))) { item.OpprettetDate = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetAv"))) { item.SlettetAv = rdr.GetString(rdr.GetOrdinal("SlettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetDato"))) { item.SlettetDato = rdr.GetDateTime(rdr.GetOrdinal("SlettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Mappe"))) { item.Mappe = rdr.GetString(rdr.GetOrdinal("Mappe")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RegType"))) { item.RegType = (Int16)rdr.GetValue(rdr.GetOrdinal("RegType")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetReport")]
        [HttpPost]
        public string SetReport(ReportItem item)
        {

            string conString;
            string sql = "";

            ReturnValueItem retur = new();

            if (item.ReportGuid == null || item.ReportGuid == "")
            {
                string RapportGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO Report() Values()";

                item.RapId = NextRapId(item.logonInfo, "SD");
                retur.NewGuid = RapportGuid;
                retur.NewId = item.RapId;
                retur.Refresh = true;

                CsqlIS(ref sql, "RapportGuid", RapportGuid);
                CsqlIS(ref sql, "Filnavn", item.Filnavn);
                CsqlIS(ref sql, "RapId", item.RapId);
                CsqlIS(ref sql, "CustomerGuid", item.CustomerGuid);
                CsqlII(ref sql, "RapType", item.RapType);
                CsqlII(ref sql, "PrintCount", item.PrintCount);
                CsqlIS(ref sql, "Tittel", item.Tittel);
                CsqlIS(ref sql, "Beskrivelse", item.Beskrivelse);
                CsqlIS(ref sql, "Kategori", item.Kategori);
                CsqlIS(ref sql, "Skjerm", item.Skjerm);
                CsqlII(ref sql, "Orientering", item.Orientering);
                CsqlIB(ref sql, "Aktiv", item.Aktiv);
                CsqlIB(ref sql, "SkjulBunntekst", item.SkjulBunntekst);
                CsqlII(ref sql, "Sortering", item.Sortering);
                CsqlIS(ref sql, "OpprettetAv", item.logonInfo.UserId);
                CsqlID(ref sql, "OpprettetDate", "D", DateTime.Today);
                CsqlIS(ref sql, "Mappe", item.Mappe);
                CsqlII(ref sql, "RegType", item.RegType);
            }
            else
            {
                ReportItem itemOld = new();
                itemOld = GetReportInternal(item.logonInfo, item.ReportGuid);
                sql = "UPDATE Report SET WHERE RapportGuid ='" + item.ReportGuid + "'"; 
                CsqlUS(ref sql, "Filnavn", item.Filnavn, itemOld.Filnavn);
                CsqlUS(ref sql, "RapId", item.RapId, itemOld.RapId);
                CsqlUS(ref sql, "CustomerGuid", item.CustomerGuid, itemOld.CustomerGuid);
                CsqlUI(ref sql, "RapType", item.RapType, itemOld.RapType);
                CsqlUS(ref sql, "RapportGuid", item.ReportGuid, itemOld.ReportGuid);
                CsqlUS(ref sql, "Tittel", item.Tittel, itemOld.Tittel);
                CsqlUS(ref sql, "Beskrivelse", item.Beskrivelse, itemOld.Beskrivelse);
                CsqlUS(ref sql, "Kategori", item.Kategori, itemOld.Kategori);
                CsqlUS(ref sql, "Skjerm", item.Skjerm, itemOld.Skjerm);
                CsqlUI(ref sql, "Orientering", item.Orientering, itemOld.Orientering);
                CsqlUB(ref sql, "Aktiv", item.Aktiv, itemOld.Aktiv);
                CsqlUB(ref sql, "SkjulBunntekst", item.SkjulBunntekst, itemOld.SkjulBunntekst);
                CsqlUI(ref sql, "Sortering", item.Sortering, itemOld.Sortering);
                CsqlUS(ref sql, "EndretAv", item.EndretAv, itemOld.EndretAv);
                CsqlUD(ref sql, "EndretDato", "T", DateTime.Today, itemOld.EndretDato);
                CsqlUS(ref sql, "Mappe", item.Mappe, itemOld.Mappe);
                CsqlUI(ref sql, "RegType", item.RegType, itemOld.RegType);

                if ( item.RapType != itemOld.RapType || item.Tittel != itemOld.Tittel) {
                    retur.Refresh = true;
                }
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

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        private string NextRapId(AccountLogOnInfoItem logonInfo, string RapId)
        {
            int intTeller;
            string strTeller;
            string strPrefix = "";

            if (RapId == null || RapId.Length == 0)
            {
                RapId = "SD";
                strPrefix = "SD";
            }
            else
                for (int i = 0; i <= RapId.Length - 1; i++)
                {
                    if (Information.IsNumeric(RapId.Substring(i, 1)))
                    {
                        strPrefix = RapId.Substring(0, i);
                        break;
                    }
                }


            if (strPrefix.Length == 0)
                strPrefix = RapId;

            intTeller = ReadValue(logonInfo, "SELECT TOP 1 cast(substring(rapid,3,5) as int) FROM Report WHERE LEFT(RapId,2)='" + strPrefix + "' AND SubString(RapId,3,1) IN ('0','1','2','3','4','5','6','7','8','9')  ORDER BY cast(substring(rapid,3,5) as int) DESC", 1);

            intTeller += 1;
            if (intTeller < 100)
                strTeller = "00" + intTeller.ToString();
            else
                strTeller = intTeller.ToString();
            RapId = strPrefix + strTeller;

            return RapId;
        }

        private ReportItem GetReportInternal(AccountLogOnInfoItem logonInfo, string RapportGuid)
        {
            string conString;

            string sql = "SELECT PrintCount, Filnavn, RapId, CustomerGuid, RapType, RapportGuid, Tittel, Beskrivelse, Kategori, Skjerm, Orientering, LastPrintDate, DatoEndret, Aktiv, SkjulBunntekst, Sortering, OpprettetAv, OpprettetDate, EndretAv, EndretDato, SlettetAv, SlettetDato, Mappe, RegType FROM Report WHERE RapportGuid = '" + RapportGuid  + "'";
            ReportItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PrintCount"))) { item.PrintCount = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("PrintCount"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Filnavn"))) { item.Filnavn = rdr.GetString(rdr.GetOrdinal("Filnavn")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerGuid"))) { item.CustomerGuid = rdr.GetString(rdr.GetOrdinal("CustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapType"))) { item.RapType = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("RapType"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapportGuid"))) { item.ReportGuid = rdr.GetString(rdr.GetOrdinal("RapportGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tittel"))) { item.Tittel = rdr.GetString(rdr.GetOrdinal("Tittel")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Beskrivelse"))) { item.Beskrivelse = rdr.GetString(rdr.GetOrdinal("Beskrivelse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kategori"))) { item.Kategori = rdr.GetString(rdr.GetOrdinal("Kategori")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Skjerm"))) { item.Skjerm = rdr.GetString(rdr.GetOrdinal("Skjerm")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Orientering"))) { item.Orientering = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Orientering"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LastPrintDate"))) { item.LastPrintDate = rdr.GetDateTime(rdr.GetOrdinal("LastPrintDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("DatoEndret"))) { item.DatoEndret = rdr.GetDateTime(rdr.GetOrdinal("DatoEndret")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Aktiv"))) { item.Aktiv = rdr.GetBoolean(rdr.GetOrdinal("Aktiv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SkjulBunntekst"))) { item.SkjulBunntekst = rdr.GetBoolean(rdr.GetOrdinal("SkjulBunntekst")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Sortering"))) { item.Sortering = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Sortering"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDate"))) { item.OpprettetDate = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetAv"))) { item.SlettetAv = rdr.GetString(rdr.GetOrdinal("SlettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetDato"))) { item.SlettetDato = rdr.GetDateTime(rdr.GetOrdinal("SlettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Mappe"))) { item.Mappe = rdr.GetString(rdr.GetOrdinal("Mappe")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RegType"))) { item.RegType = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("RegType"))); }
                    }
                }
            }

            return item;
        }


        [Route("RemoveReport")]
        [HttpPost]
        public string RemoveReport(ReportItem item)
        {

            string conString;
            string sql = "";

            ReturnValueItem retur = new();

            sql = "DELETE FROM Report_SQL WHERE RapId='" + item.RapId + "'";
            sql += ";DELETE FROM Report_Files WHERE RapId='" + item.RapId + "'";
            sql += ";DELETE FROM Report_Formel WHERE RapId='" + item.RapId + "'";
            sql += ";DELETE FROM Report_Question WHERE RapId='" + item.RapId + "'";
            sql += ";DELETE FROM Report WHERE RapId='" + item.RapId + "'";

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
                retur.Success = false;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("uploadReportFile")]
        [HttpPost]
        public string uploadReportFile(UploadReportFilerItem item)
        {
            string sql = "";
            ReturnValueItem retur = new();

            string conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            if (item.Base64String.Length > 0)
            {
                byte[] MyDoc = Convert.FromBase64String(item.Base64String);
                string ReportfilerGuid = "";

                if (item.ErstattSiste)
                    ReportfilerGuid = ReadValue(item.logonInfo, "SELECT TOP 1 ReportFilesGUID FROM REPORT_FILES WHERE RapId='" + item.RapId + "' ORDER BY Versjon DESC");
                else
                {
                    ReportfilerGuid = Guid.NewGuid().ToString();
                    string strFilnavn = ReadValue(item.logonInfo, "SELECT Filnavn FROM REPORT WHERE RapId='" + item.RapId + "'");
                    int intVersjon;
                    intVersjon = ReadValue(item.logonInfo, "SELECT MAX(Versjon) FROM REPORT_FILES WHERE RapId='" + item.RapId + "'",0);
                    intVersjon++;
                    sql = "INSERT INTO REPORT_FILES(ReportFilesGuid, RapId, FilNavn, Versjon, Dato) VALUES('" + ReportfilerGuid + "','" + item.RapId + "','" + strFilnavn + "'," + intVersjon + ",GetDate())";
                    ExecuteSQL(conString, sql);
                }

                byte[] reportBytes = Convert.FromBase64String(item.Base64String);

                sql = "UPDATE REPORT_FILES SET Fil=@reportFile, Dato=GetDate() WHERE ReportFilesGuid='" + ReportfilerGuid + "'";

                SqlConnection con = new SqlConnection(conString);
                con.Open();

                try
                {
                SqlCommand com = new SqlCommand(sql, con);  
                com.CommandType = CommandType.Text;
                SqlParameter par = com.Parameters.Add("@reportFile", SqlDbType.Binary, reportBytes.Length);
                par.Value = reportBytes;
                com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ErrorItem err = new();
                    err.Message = ex.Message;
                    retur.Success = false;
                    retur.Error.Add(err);
                }



                //if (item.Ext == ".docx")
                //    TumbImage = exeKIPLagImageFromDoc(LogonInfo, item.Base64String, item.RapId);



                retur.Success = true;
                //if (TumbImage != null)
                //    retur.InfoText = Convert.ToBase64String(TumbImage);
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;

        }


        [Route("uploadReportPreview")]
        [HttpPost]
        public string uploadReportPreview(UploadReportFilerItem item)
        {
            string sql = "";
            ReturnValueItem retur = new();

            string conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            if (item.Base64String.Length > 0)
            {
                byte[] MyDoc = Convert.FromBase64String(item.Base64String);
                string ReportfilerGuid = "";


                byte[] reportBytes = Convert.FromBase64String(item.Base64String);

                sql = "UPDATE REPORT_FILES SET Preview=@reportFile WHERE ReportFilesGuid='" + item.ReportFilesGuid + "'";

                SqlConnection con = new SqlConnection(conString);
                con.Open();

                try
                {
                    SqlCommand com = new SqlCommand(sql, con);
                    com.CommandType = CommandType.Text;
                    SqlParameter par = com.Parameters.Add("@reportFile", SqlDbType.Binary, reportBytes.Length);
                    par.Value = reportBytes;
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ErrorItem err = new();
                    err.Message = ex.Message;
                    retur.Success = false;
                    retur.Error.Add(err);
                }



                //if (item.Ext == ".docx")
                //    TumbImage = exeKIPLagImageFromDoc(LogonInfo, item.Base64String, item.RapId);



                retur.Success = true;
                //if (TumbImage != null)
                //    retur.InfoText = Convert.ToBase64String(TumbImage);
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;

        }


        [Route("GetReportFilesList")]
        [HttpPost]
        public string GetReportFilesList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ReportFilesGuid, RapportGuid, RapId, CustomerGuid, Dato, FilNavn, Preview, Versjon, EndretAv, EndretDato, BeholdTopptekst, BeholdBunntekst FROM Report_Files";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ReportFilesItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ReportFilesItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ReportFilesGuid"))) { item.ReportFilesGuid = rdr.GetString(rdr.GetOrdinal("ReportFilesGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapportGuid"))) { item.RapportGuid = rdr.GetString(rdr.GetOrdinal("RapportGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerGuid"))) { item.CustomerGuid = rdr.GetString(rdr.GetOrdinal("CustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Dato"))) { item.Dato = rdr.GetDateTime(rdr.GetOrdinal("Dato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FilNavn"))) { item.FilNavn = rdr.GetString(rdr.GetOrdinal("FilNavn")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Versjon"))) { item.Versjon = (Int16)rdr.GetValue(rdr.GetOrdinal("Versjon")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BeholdTopptekst"))) { item.BeholdTopptekst = rdr.GetBoolean(rdr.GetOrdinal("BeholdTopptekst")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BeholdBunntekst"))) { item.BeholdBunntekst = rdr.GetBoolean(rdr.GetOrdinal("BeholdBunntekst")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetReportFileImagePreview")]
        [HttpPost]
        public string GetReportFileImagePreview(AccountLogOnInfoItem LogonInfo)
        {
            string conString;
            string base64String = "";

            conString = @"server=" + LogonInfo.Server + ";User Id=" + LogonInfo.UserId + ";password=" + LogonInfo.Password + ";database=" + LogonInfo.Database + ";TrustServerCertificate=True";

            SqlConnection connection = new SqlConnection(conString);

            string sql = "SELECT TOP 1 Preview FROM Report_Files WHERE ReportFilesGuid=@RapId  ORDER BY CustomerGuid DESC, Dato DESC";

            try
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand(sql, connection);
                SqlParameter myparam = command1.Parameters.Add("@RapId", SqlDbType.NVarChar, 40);
                myparam.Value = LogonInfo.Parameters.field;
                byte[] img = (byte[])command1.ExecuteScalar();

                if (img != null && img.Length > 0)
                {
                    base64String = Convert.ToBase64String(img);
                }
            }

            catch { }

            
            

            return base64String;
        }


        [Route("GetReportQuestionList")]
        [HttpPost]
        public string GetReportQuestionList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT RapId, Kode, Type, Tekst, PosX, PosY, Vidde, Hoyde, Font, Uthevet, Storrelse, Farge, ReturVerdi, SQL, StandardVerdi, SkalerBredde, SkalerHoyde, Flytt, Flerlinje, OpprettetAv, OpprettetDate, EndretAv, EndretDato, SlettetAv, SlettetDato, RapportSporsmalGuid FROM Report_Question";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ReportQuestionItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ReportQuestionItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kode"))) { item.Kode = rdr.GetString(rdr.GetOrdinal("Kode")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tekst"))) { item.Tekst = rdr.GetString(rdr.GetOrdinal("Tekst")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PosX"))) { item.PosX = (int)rdr.GetValue(rdr.GetOrdinal("PosX")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PosY"))) { item.PosY = (int)rdr.GetValue(rdr.GetOrdinal("PosY")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Vidde"))) { item.Vidde = (int)rdr.GetValue(rdr.GetOrdinal("Vidde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Hoyde"))) { item.Hoyde = (int)rdr.GetValue(rdr.GetOrdinal("Hoyde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Font"))) { item.Font = rdr.GetString(rdr.GetOrdinal("Font")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Uthevet"))) { item.Uthevet = rdr.GetBoolean(rdr.GetOrdinal("Uthevet")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Storrelse"))) { item.Storrelse = (int)rdr.GetValue(rdr.GetOrdinal("Storrelse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Farge"))) { item.Farge = rdr.GetString(rdr.GetOrdinal("Farge")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ReturVerdi"))) { item.ReturVerdi = (int)rdr.GetValue(rdr.GetOrdinal("ReturVerdi")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SQL"))) { item.SQL = rdr.GetString(rdr.GetOrdinal("SQL")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("StandardVerdi"))) { item.StandardVerdi = rdr.GetString(rdr.GetOrdinal("StandardVerdi")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SkalerBredde"))) { item.SkalerBredde = rdr.GetBoolean(rdr.GetOrdinal("SkalerBredde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SkalerHoyde"))) { item.SkalerHoyde = rdr.GetBoolean(rdr.GetOrdinal("SkalerHoyde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Flytt"))) { item.Flytt = rdr.GetBoolean(rdr.GetOrdinal("Flytt")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Flerlinje"))) { item.Flerlinje = rdr.GetBoolean(rdr.GetOrdinal("Flerlinje")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDate"))) { item.OpprettetDate = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetAv"))) { item.SlettetAv = rdr.GetString(rdr.GetOrdinal("SlettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetDato"))) { item.SlettetDato = rdr.GetDateTime(rdr.GetOrdinal("SlettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapportSporsmalGuid"))) { item.ReportSporsmalGuid = rdr.GetString(rdr.GetOrdinal("RapportSporsmalGuid")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetReportQuestion")]
        [HttpPost]
        public string GetReportQuestion(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT RapId, Kode, Type, Tekst, PosX, PosY, Vidde, Hoyde, Font, Uthevet, Storrelse, Farge, ReturVerdi, SQL, StandardVerdi, SkalerBredde, SkalerHoyde, Flytt, Flerlinje, OpprettetAv, OpprettetDate, EndretAv, EndretDato, SlettetAv, SlettetDato, RapportSporsmalGuid FROM Report_Question";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            ReportQuestionItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kode"))) { item.Kode = rdr.GetString(rdr.GetOrdinal("Kode")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tekst"))) { item.Tekst = rdr.GetString(rdr.GetOrdinal("Tekst")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PosX"))) { item.PosX = (int)rdr.GetValue(rdr.GetOrdinal("PosX")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PosY"))) { item.PosY = (int)rdr.GetValue(rdr.GetOrdinal("PosY")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Vidde"))) { item.Vidde = (int)rdr.GetValue(rdr.GetOrdinal("Vidde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Hoyde"))) { item.Hoyde = (int)rdr.GetValue(rdr.GetOrdinal("Hoyde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Font"))) { item.Font = rdr.GetString(rdr.GetOrdinal("Font")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Uthevet"))) { item.Uthevet = rdr.GetBoolean(rdr.GetOrdinal("Uthevet")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Storrelse"))) { item.Storrelse = (int)rdr.GetValue(rdr.GetOrdinal("Storrelse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Farge"))) { item.Farge = rdr.GetString(rdr.GetOrdinal("Farge")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ReturVerdi"))) { item.ReturVerdi = (int)rdr.GetValue(rdr.GetOrdinal("ReturVerdi")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SQL"))) { item.SQL = rdr.GetString(rdr.GetOrdinal("SQL")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("StandardVerdi"))) { item.StandardVerdi = rdr.GetString(rdr.GetOrdinal("StandardVerdi")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SkalerBredde"))) { item.SkalerBredde = rdr.GetBoolean(rdr.GetOrdinal("SkalerBredde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SkalerHoyde"))) { item.SkalerHoyde = rdr.GetBoolean(rdr.GetOrdinal("SkalerHoyde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Flytt"))) { item.Flytt = rdr.GetBoolean(rdr.GetOrdinal("Flytt")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Flerlinje"))) { item.Flerlinje = rdr.GetBoolean(rdr.GetOrdinal("Flerlinje")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDate"))) { item.OpprettetDate = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetAv"))) { item.SlettetAv = rdr.GetString(rdr.GetOrdinal("SlettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetDato"))) { item.SlettetDato = rdr.GetDateTime(rdr.GetOrdinal("SlettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapportSporsmalGuid"))) { item.ReportSporsmalGuid = rdr.GetString(rdr.GetOrdinal("RapportSporsmalGuid")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetReportQuestion")]
        [HttpPost]
        public string SetReportQuestion(ReportQuestionItem item)
        {

            string conString;
            string sql = "";

            ReturnValueItem retur = new();

            if (item.ReportSporsmalGuid == null)
            {
                string ReportSporsmalGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO Report_Question() Values()";

                CsqlIS(ref sql, "RapportSporsmalGuid", ReportSporsmalGuid);
                CsqlIS(ref sql, "RapId", item.RapId);
                CsqlIS(ref sql, "Kode", item.Kode);
                CsqlII(ref sql, "Type", item.Type);
                CsqlIS(ref sql, "Tekst", item.Tekst);
                CsqlII(ref sql, "PosX", item.PosX);
                CsqlII(ref sql, "PosY", item.PosY);
                CsqlII(ref sql, "Vidde", item.Vidde);
                CsqlII(ref sql, "Hoyde", item.Hoyde);
                CsqlIS(ref sql, "Font", item.Font);
                CsqlIB(ref sql, "Uthevet", item.Uthevet);
                CsqlII(ref sql, "Storrelse", item.Storrelse);
                CsqlIS(ref sql, "Farge", item.Farge);
                CsqlII(ref sql, "ReturVerdi", item.ReturVerdi);
                CsqlIS(ref sql, "SQL", item.SQL);
                CsqlIS(ref sql, "StandardVerdi", item.StandardVerdi);
                CsqlIB(ref sql, "SkalerBredde", item.SkalerBredde);
                CsqlIB(ref sql, "SkalerHoyde", item.SkalerHoyde);
                CsqlIB(ref sql, "Flytt", item.Flytt);
                CsqlIB(ref sql, "Flerlinje", item.Flerlinje);
                CsqlIS(ref sql, "OpprettetAv", item.OpprettetAv);
                if (item.OpprettetDate != null) { CsqlID(ref sql, "OpprettetDate", "D", (DateTime)item.OpprettetDate); }
            }
            else
            {
                ReportQuestionItem itemOld = new();
                itemOld = GetReportQuestionInternal(item.logonInfo, item.ReportSporsmalGuid);
                sql = "UPDATE Report_Question SET WHERE RapportSporsmalGuid = '" + item.ReportSporsmalGuid  + "'"; 
                CsqlUS(ref sql, "RapId", item.RapId, itemOld.RapId);
                CsqlUS(ref sql, "Kode", item.Kode, itemOld.Kode);
                CsqlUI(ref sql, "Type", item.Type, itemOld.Type);
                CsqlUS(ref sql, "Tekst", item.Tekst, itemOld.Tekst);
                CsqlUI(ref sql, "PosX", item.PosX, itemOld.PosX);
                CsqlUI(ref sql, "PosY", item.PosY, itemOld.PosY);
                CsqlUI(ref sql, "Vidde", item.Vidde, itemOld.Vidde);
                CsqlUI(ref sql, "Hoyde", item.Hoyde, itemOld.Hoyde);
                CsqlUS(ref sql, "Font", item.Font, itemOld.Font);
                CsqlUB(ref sql, "Uthevet", item.Uthevet, itemOld.Uthevet);
                CsqlUI(ref sql, "Storrelse", item.Storrelse, itemOld.Storrelse);
                CsqlUS(ref sql, "Farge", item.Farge, itemOld.Farge);
                CsqlUI(ref sql, "ReturVerdi", item.ReturVerdi, itemOld.ReturVerdi);
                CsqlUS(ref sql, "SQL", item.SQL, itemOld.SQL);
                CsqlUS(ref sql, "StandardVerdi", item.StandardVerdi, itemOld.StandardVerdi);
                CsqlUB(ref sql, "SkalerBredde", item.SkalerBredde, itemOld.SkalerBredde);
                CsqlUB(ref sql, "SkalerHoyde", item.SkalerHoyde, itemOld.SkalerHoyde);
                CsqlUB(ref sql, "Flytt", item.Flytt, itemOld.Flytt);
                CsqlUB(ref sql, "Flerlinje", item.Flerlinje, itemOld.Flerlinje);
                CsqlUS(ref sql, "EndretAv", item.EndretAv, itemOld.EndretAv);
                if (item.EndretDato != null) { CsqlUD(ref sql, "EndretDato", "D", (DateTime)item.EndretDato, (DateTime)itemOld.EndretDato); }
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
                retur.Success = false;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        private ReportQuestionItem GetReportQuestionInternal(AccountLogOnInfoItem logonInfo, string RapportSporsmalGuid)
        {
            string conString;

            string sql = "SELECT RapId, Kode, Type, Tekst, PosX, PosY, Vidde, Hoyde, Font, Uthevet, Storrelse, Farge, ReturVerdi, SQL, StandardVerdi, SkalerBredde, SkalerHoyde, Flytt, Flerlinje, OpprettetAv, OpprettetDate, EndretAv, EndretDato, SlettetAv, SlettetDato, RapportSporsmalGuid FROM Report_Question WHERE RapportSporsmalGuid = '" + RapportSporsmalGuid + "'";

            ReportQuestionItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kode"))) { item.Kode = rdr.GetString(rdr.GetOrdinal("Kode")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tekst"))) { item.Tekst = rdr.GetString(rdr.GetOrdinal("Tekst")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PosX"))) { item.PosX = (int)rdr.GetValue(rdr.GetOrdinal("PosX")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PosY"))) { item.PosY = (int)rdr.GetValue(rdr.GetOrdinal("PosY")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Vidde"))) { item.Vidde = (int)rdr.GetValue(rdr.GetOrdinal("Vidde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Hoyde"))) { item.Hoyde = (int)rdr.GetValue(rdr.GetOrdinal("Hoyde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Font"))) { item.Font = rdr.GetString(rdr.GetOrdinal("Font")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Uthevet"))) { item.Uthevet = rdr.GetBoolean(rdr.GetOrdinal("Uthevet")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Storrelse"))) { item.Storrelse = (int)rdr.GetValue(rdr.GetOrdinal("Storrelse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Farge"))) { item.Farge = rdr.GetString(rdr.GetOrdinal("Farge")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ReturVerdi"))) { item.ReturVerdi = (int)rdr.GetValue(rdr.GetOrdinal("ReturVerdi")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SQL"))) { item.SQL = rdr.GetString(rdr.GetOrdinal("SQL")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("StandardVerdi"))) { item.StandardVerdi = rdr.GetString(rdr.GetOrdinal("StandardVerdi")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SkalerBredde"))) { item.SkalerBredde = rdr.GetBoolean(rdr.GetOrdinal("SkalerBredde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SkalerHoyde"))) { item.SkalerHoyde = rdr.GetBoolean(rdr.GetOrdinal("SkalerHoyde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Flytt"))) { item.Flytt = rdr.GetBoolean(rdr.GetOrdinal("Flytt")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Flerlinje"))) { item.Flerlinje = rdr.GetBoolean(rdr.GetOrdinal("Flerlinje")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDate"))) { item.OpprettetDate = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetAv"))) { item.SlettetAv = rdr.GetString(rdr.GetOrdinal("SlettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetDato"))) { item.SlettetDato = rdr.GetDateTime(rdr.GetOrdinal("SlettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapportSporsmalGuid"))) { item.ReportSporsmalGuid = rdr.GetString(rdr.GetOrdinal("RapportSporsmalGuid")); }
                    }
                }
            }

            return item;
        }

        [Route("GetReportSQLListe")]
        [HttpPost]
        public string GetReportSQLListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ReportSQLGuid, RapId, Type, Stadie, Kode, Rekkefolge, Format, SQL, OpprettetAv, OpprettetDate, EndretAv, EndretDato, SlettetAv, SlettetDato, IsNotNullField FROM Report_SQL ";
            if (logonInfo.Parameters.field != "") { sql += " WHERE RapId = '" + logonInfo.Parameters.field + "' "; }
            sql += "ORDER BY Rekkefolge";

            List<ReportSQLItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ReportSQLItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ReportSQLGuid"))) { item.ReportSQLGuid = rdr.GetString(rdr.GetOrdinal("ReportSQLGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Stadie"))) { item.Stadie = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Stadie"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kode"))) { item.Kode = rdr.GetString(rdr.GetOrdinal("Kode")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Rekkefolge"))) { item.Rekkefolge = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Rekkefolge"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Format"))) { item.Format = rdr.GetString(rdr.GetOrdinal("Format")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SQL"))) { item.SQL = rdr.GetString(rdr.GetOrdinal("SQL")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDate"))) { item.OpprettetDate = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetAv"))) { item.SlettetAv = rdr.GetString(rdr.GetOrdinal("SlettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetDato"))) { item.SlettetDato = rdr.GetDateTime(rdr.GetOrdinal("SlettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("IsNotNullField"))) { item.IsNotNullField = rdr.GetString(rdr.GetOrdinal("IsNotNullField")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetReportSQL")]
        [HttpPost]
        public string GetReportSQL(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ReportSQLGuid, RapId, Type, Stadie, Kode, Rekkefolge, Format, SQL, OpprettetAv, OpprettetDate, EndretAv, EndretDato, SlettetAv, SlettetDato, IsNotNullField FROM Report_SQL";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            ReportSQLItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ReportSQLGuid"))) { item.ReportSQLGuid = rdr.GetString(rdr.GetOrdinal("ReportSQLGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Stadie"))) { item.Stadie = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Stadie"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kode"))) { item.Kode = rdr.GetString(rdr.GetOrdinal("Kode")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Rekkefolge"))) { item.Rekkefolge = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Rekkefolge"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Format"))) { item.Format = rdr.GetString(rdr.GetOrdinal("Format")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SQL"))) { item.SQL = rdr.GetString(rdr.GetOrdinal("SQL")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDate"))) { item.OpprettetDate = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetAv"))) { item.SlettetAv = rdr.GetString(rdr.GetOrdinal("SlettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetDato"))) { item.SlettetDato = rdr.GetDateTime(rdr.GetOrdinal("SlettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("IsNotNullField"))) { item.IsNotNullField = rdr.GetString(rdr.GetOrdinal("IsNotNullField")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetReportSQL")]
        [HttpPost]
        public string SetReportSQL(ReportSQLItem item)
        {

            string conString;
            string sql = "";

            ReturnValueItem retur = new();

            if (item.ReportSQLGuid == null || item.ReportSQLGuid == "")
            {
                string ReportSQLGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO Report_SQL() Values()";

                CsqlIS(ref sql, "ReportSQLGuid", ReportSQLGuid);
                CsqlIS(ref sql, "RapId", item.RapId);
                CsqlII(ref sql, "Type", item.Type);
                CsqlII(ref sql, "Stadie", item.Stadie);
                CsqlIS(ref sql, "Kode", item.Kode);
                CsqlII(ref sql, "Rekkefolge", item.Rekkefolge);
                CsqlIS(ref sql, "Format", item.Format);
                CsqlIS(ref sql, "OpprettetAv", item.OpprettetAv);
                if (item.OpprettetDate != null) { CsqlID(ref sql, "OpprettetDate", "T", (DateTime)item.OpprettetDate); }
                CsqlIS(ref sql, "IsNotNullField", item.IsNotNullField);
                CsqlIS(ref sql, "SQL", item.SQL);
            }
            else
            {
                ReportSQLItem itemOld = new();
                itemOld = GetReportSQLInternal(item.logonInfo, item.ReportSQLGuid);
                sql = "UPDATE Report_SQL SET WHERE ReportSQLGuid ='" + item.ReportSQLGuid  + "'"; 
                CsqlUI(ref sql, "Type", item.Type, itemOld.Type);
                CsqlUI(ref sql, "Stadie", item.Stadie, itemOld.Stadie);
                CsqlUS(ref sql, "Kode", item.Kode, itemOld.Kode);
                CsqlUI(ref sql, "Rekkefolge", item.Rekkefolge, itemOld.Rekkefolge);
                CsqlUS(ref sql, "Format", item.Format, itemOld.Format);
                CsqlUS(ref sql, "EndretAv", item.logonInfo.UserId, "");
                CsqlUD(ref sql, "EndretDato", "T", DateTime.Now, null);
                CsqlUS(ref sql, "IsNotNullField", item.IsNotNullField, itemOld.IsNotNullField);
                CsqlUS(ref sql, "SQL", item.SQL, itemOld.SQL);
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
                retur.Success = false;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        private ReportSQLItem GetReportSQLInternal(AccountLogOnInfoItem logonInfo, string ReportSQLGuid)
        {
            string conString;

            string sql = "SELECT ReportSQLGuid, RapId, Type, Stadie, Kode, Rekkefolge, Format, SQL, OpprettetAv, OpprettetDate, EndretAv, EndretDato, SlettetAv, SlettetDato, IsNotNullField FROM Report_SQL WHERE ReportSQLGuid = '" + ReportSQLGuid + "'";

            ReportSQLItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ReportSQLGuid"))) { item.ReportSQLGuid = rdr.GetString(rdr.GetOrdinal("ReportSQLGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Stadie"))) { item.Stadie = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Stadie"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kode"))) { item.Kode = rdr.GetString(rdr.GetOrdinal("Kode")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Rekkefolge"))) { item.Rekkefolge = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("Rekkefolge"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Format"))) { item.Format = rdr.GetString(rdr.GetOrdinal("Format")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SQL"))) { item.SQL = rdr.GetString(rdr.GetOrdinal("SQL")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDate"))) { item.OpprettetDate = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetAv"))) { item.SlettetAv = rdr.GetString(rdr.GetOrdinal("SlettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetDato"))) { item.SlettetDato = rdr.GetDateTime(rdr.GetOrdinal("SlettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("IsNotNullField"))) { item.IsNotNullField = rdr.GetString(rdr.GetOrdinal("IsNotNullField")); }
                    }
                }
            }

            return item;
        }


        #endregion

        #region Dupliser rapport

        [Route("DuplicateReport")]
        [HttpPost]
        public string DuplicateReport(AccountLogOnInfoItem logonInfo)
        {
            if (logonInfo.Parameters.field == null)
            {
                return "";
            }
            string conString;
            string RapId = logonInfo.Parameters.field;
            string NewRapId = "";
            string? ReportGuid;
            ReturnValueItem retur = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            if (logonInfo.Parameters.field != null && logonInfo.Parameters.field.Length>0) { 
                ReportItem item = GetReportInternal(conString, logonInfo.Parameters.field);
                if (item != null)
                {
                    ReportGuid = item.ReportGuid;
                    item.RapId = "SD";
                    item.ReportGuid = "";
                    item.Aktiv = true;
                    if (logonInfo.Parameters.fieldValue != null)
                        item.Tittel = logonInfo.Parameters.fieldValue;
                    item.logonInfo = logonInfo;

                    string returText = SetReport(item);
                    if (returText != null)
                    {
                        ReturnValueItem? returReport = JsonConvert.DeserializeObject<ReturnValueItem>(returText);
                        if (returReport != null)
                        {
                            NewRapId = returReport.NewGuid;
                            retur.Refresh = true;

                            string sql = "INSERT INTO Report_Files(ReportFilesGuid, RapportGuid, RapId, CustomerGuid, Dato, FilNavn, Fil, Preview, Versjon)" +
                                "SELECT lower(newid()) ReportFilesGuid, '" + NewRapId + "' RapportGuid, '" + returReport.NewId + "' RapId, CustomerGuid, Dato, FilNavn, Fil, Preview, Versjon " +
                                "FROM Report_Files WHERE RapId='" + RapId + "'";

                            ExecuteSQL(conString, sql);

                            returText = GetReportSQLListe(logonInfo);

                            if (returText != null)
                            {
                                List<ReportSQLItem>? itmSQL = JsonConvert.DeserializeObject<List<ReportSQLItem>>(returText);
                                if (itmSQL != null)
                                {
                                    foreach (ReportSQLItem itmS in itmSQL)
                                    {
                                        ReportSQLItem itmRSQL = new ReportSQLItem();
                                        itmRSQL.RapId = returReport.NewId;
                                        itmRSQL.Kode = itmS.Kode;
                                        itmRSQL.Type = itmS.Type;
                                        itmRSQL.Stadie = itmS.Stadie;
                                        itmRSQL.SQL = itmS.SQL;
                                        itmRSQL.Rekkefolge = itmS.Rekkefolge;
                                        itmRSQL.logonInfo = logonInfo;
                                        SetReportSQL(itmRSQL);
                                    }
                                }
                          
                            }
                 
                        }

                    }

                }
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;

        }

        private ReportItem GetReportInternal(string conString, string RapId)
        {
            string sql = "SELECT PrintCount, Filnavn, RapId, CustomerGuid, RapType, RapportGuid, Tittel, Beskrivelse, Kategori, Skjerm, Orientering, LastPrintDate, DatoEndret, Aktiv, SkjulBunntekst, Sortering, OpprettetAv, OpprettetDate, EndretAv, EndretDato, SlettetAv, SlettetDato, Mappe, RegType FROM Report";
            sql += " WHERE RapId='" + RapId + "'";

            ReportItem item = new();

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapportGuid"))) { item.ReportGuid = rdr.GetString(rdr.GetOrdinal("RapportGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PrintCount"))) { item.PrintCount = (Int16)rdr.GetValue(rdr.GetOrdinal("PrintCount")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Filnavn"))) { item.Filnavn = rdr.GetString(rdr.GetOrdinal("Filnavn")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapId"))) { item.RapId = rdr.GetString(rdr.GetOrdinal("RapId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerGuid"))) { item.CustomerGuid = rdr.GetString(rdr.GetOrdinal("CustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RapType"))) { item.RapType = Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("RapType"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tittel"))) { item.Tittel = rdr.GetString(rdr.GetOrdinal("Tittel")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Beskrivelse"))) { item.Beskrivelse = rdr.GetString(rdr.GetOrdinal("Beskrivelse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kategori"))) { item.Kategori = rdr.GetString(rdr.GetOrdinal("Kategori")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Skjerm"))) { item.Skjerm = rdr.GetString(rdr.GetOrdinal("Skjerm")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Orientering"))) { item.Orientering = (Int16)rdr.GetValue(rdr.GetOrdinal("Orientering")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LastPrintDate"))) { item.LastPrintDate = rdr.GetDateTime(rdr.GetOrdinal("LastPrintDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("DatoEndret"))) { item.DatoEndret = rdr.GetDateTime(rdr.GetOrdinal("DatoEndret")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Aktiv"))) { item.Aktiv = rdr.GetBoolean(rdr.GetOrdinal("Aktiv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SkjulBunntekst"))) { item.SkjulBunntekst = rdr.GetBoolean(rdr.GetOrdinal("SkjulBunntekst")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Sortering"))) { item.Sortering = (Int16)rdr.GetValue(rdr.GetOrdinal("Sortering")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDate"))) { item.OpprettetDate = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDate")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretAv"))) { item.EndretAv = rdr.GetString(rdr.GetOrdinal("EndretAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EndretDato"))) { item.EndretDato = rdr.GetDateTime(rdr.GetOrdinal("EndretDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetAv"))) { item.SlettetAv = rdr.GetString(rdr.GetOrdinal("SlettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SlettetDato"))) { item.SlettetDato = rdr.GetDateTime(rdr.GetOrdinal("SlettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Mappe"))) { item.Mappe = rdr.GetString(rdr.GetOrdinal("Mappe")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("RegType"))) { item.RegType = (Int16)rdr.GetValue(rdr.GetOrdinal("RegType")); }
                    }
                }
            }

            return item;
        }


        #endregion

        #region Produksjon

        [Route("ShowTelerikReport")]
        [HttpPost]
        public string ShowTelerikReport(GetReportItem item)
        {
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

            ReportPreviewItem Retur = new();

            string conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            byte[] MyDoc;

            MyDoc = FinnSiste(item.logonInfo, item.RapId);
            if (MyDoc == null || MyDoc.Length == 0)
            {
                Retur.ErrorTekst = "Finner ikke rapport filen";

            }
            else
            {

                string strSQL;
                string strFormelNavn = "";
                string strFormelTekst;
                int intFormelType;
                int intFormelVerdiType;
                string strFormler = "";
                bool bolFormelFunnet = false;

                MemoryStream stream = new MemoryStream(MyDoc);

                using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stream, settings))
                {
                    Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();

                    Telerik.Reporting.Report rPub = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                    using (SqlConnection cnnG6 = new SqlConnection(conString))
                    {
                        cnnG6.Open();
                        if (cnnG6.State == ConnectionState.Closed)
                            cnnG6.Open();

                        strSQL = "SELECT FormelNavn, FormelTekst, FormelType, FormelVerdiType FROM REPORT_FORMEL WHERE RapId='" + item.RapId + "'";

                        try
                        {
                            SqlCommand cmdRapFormel = cnnG6.CreateCommand();
                            cmdRapFormel.CommandType = CommandType.Text;
                            cmdRapFormel.CommandText = strSQL;

                            SqlDataReader drRapFormel = cmdRapFormel.ExecuteReader(CommandBehavior.CloseConnection);

                            {
                                while (drRapFormel.Read())
                                {
                                    if (!drRapFormel.IsDBNull(drRapFormel.GetOrdinal("FormelNavn")))
                                        strFormelNavn = drRapFormel.GetString(drRapFormel.GetOrdinal("FormelNavn"));
                                    else
                                        strFormelNavn = "";
                                    if (!drRapFormel.IsDBNull(drRapFormel.GetOrdinal("FormelTekst")))
                                        strFormelTekst = drRapFormel.GetString(drRapFormel.GetOrdinal("FormelTekst"));
                                    else
                                        strFormelTekst = "";
                                    if (!drRapFormel.IsDBNull(drRapFormel.GetOrdinal("FormelType")))
                                        intFormelType = (int)drRapFormel.GetValue(drRapFormel.GetOrdinal("FormelType"));
                                    else
                                        intFormelType = 0;
                                    if (!drRapFormel.IsDBNull(drRapFormel.GetOrdinal("FormelVerdiType")))
                                        intFormelVerdiType = (int)drRapFormel.GetValue(drRapFormel.GetOrdinal("FormelVerdiType"));
                                    else
                                        intFormelVerdiType = 0;
                                    bolFormelFunnet = false;
                                    {
                                        var drRapSQL = rPub;
                                        foreach (var r in drRapSQL.ReportParameters)
                                        {
                                            if (r.Name.ToUpper() == strFormelNavn.ToUpper())
                                            {
                                                bolFormelFunnet = true;
                                                foreach (var var in item.Verdier)
                                                {
                                                    if (var.Navn.Length > 0 && var.Navn.ToUpper() == strFormelTekst.Replace("#", "").ToUpper())
                                                    {
                                                        // If intFormelVerdiType = 2 Then
                                                        // var.Verdi = var.Verdi.Substring(8, 2) & "." & var.Verdi.Substring(5, 2) & ". " & var.Verdi.Substring(0, 4)
                                                        // End If
                                                        if (intFormelVerdiType == 3)
                                                        {
                                                            if (var.Verdi == "on" | var.Verdi == "1")
                                                                var.Verdi = "true";
                                                            else
                                                                var.Verdi = "false";
                                                        }
                                                        if (var.Verdi.Length > 0)
                                                            strFormelTekst = System.Text.RegularExpressions.Regex.Replace(strFormelTekst, "#" + var.Navn.ToUpper() + "#", var.Verdi, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                                        else if (var.Navn.Length > 0 && var.Verdi.Length == 0)
                                                            strFormelTekst = System.Text.RegularExpressions.Regex.Replace(strFormelTekst, "#" + var.Navn.ToUpper() + "#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                                        break;
                                                    }
                                                }
                                                if (r.MultiValue == true && strFormelTekst.IndexOf(":") > 0)
                                                {
                                                    string[] arrValue;
                                                    arrValue = strFormelTekst.Split(":");
                                                    r.Value = arrValue;
                                                }
                                                else if (strFormelTekst.IndexOf(":") > 0)
                                                {
                                                    string[] arrValue;
                                                    arrValue = strFormelTekst.Split(":");
                                                    r.Value = arrValue[0];
                                                }
                                                else
                                                    r.Value = strFormelTekst;
                                                break;
                                            }
                                        }
                                    }
                                    if (!bolFormelFunnet)
                                        strFormler += strFormelNavn + " - ";
                                }
                            }

                            drRapFormel.Close();
                            cmdRapFormel.Dispose();
                        }
                        catch (SqlException ex)
                        {
                            Retur.ErrorTekst = ex.Message;
                        }

                        if (Retur.ErrorTekst != null)
                        {
                            try
                            {
                                {
                                    foreach (var r in rPub.ReportParameters)
                                    {
                                        switch (r.Name.ToUpper())
                                        {
                                            case "CUSTOMERGUID":
                                                {
                                                    r.Value = item.logonInfo.CustomerGuid;
                                                    break;
                                                }

                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Retur.ErrorTekst = ex.Message;
                            }

                        }


                        if (cnnG6.State == ConnectionState.Open)
                            cnnG6.Close();
                        cnnG6.Dispose();
                    }

                    if (Retur.ErrorTekst  == null || Retur.ErrorTekst == "")
                    {
                   
                        try
                        {
                            System.Collections.Hashtable deviceInfo = new System.Collections.Hashtable();
                            Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
                            var connectionStringHandler2 = new ReportConnectionStringManager(conString);

                            instanceReportSource.ReportDocument = rPub;
                            var reportSource2 = connectionStringHandler2.UpdateReportSource(instanceReportSource);
                            Telerik.Reporting.Processing.RenderingResult result = reportProcessor.RenderReport("PDF", reportSource2, deviceInfo);

                            if (result.DocumentBytes != null && result.DocumentBytes.Length > 0)
                                Retur.Base64String = Convert.ToBase64String(result.DocumentBytes);
                            else if (result.Errors.Count() > 0)
                            {
                                foreach (var e in result.Errors)
                                    Retur.ErrorTekst += e.Message;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.InnerException != null)
                                Retur.ErrorTekst = ex.InnerException.Message;
                            else
                                Retur.ErrorTekst = ex.Message;
                            if (strFormler.Length > 0)
                                Retur.ErrorTekst += "Manglender formler: " + strFormler;
                            Retur.ErrorCode = 9;
                        }
                    
                    }
                }
            }
            string output = JsonConvert.SerializeObject(Retur);

            return output;
        }


        private byte[] FinnSiste(AccountLogOnInfoItem LogonInfo, string RapId)
        {
            string conString;

            conString = @"server=" + LogonInfo.Server + ";User Id=" + LogonInfo.UserId + ";password=" + LogonInfo.Password + ";database=" + LogonInfo.Database + ";TrustServerCertificate=True";

            SqlConnection connection = new SqlConnection(conString);
            
            string sql = "SELECT TOP 1 Fil FROM Report_Files WHERE RapId=@RapId ORDER BY CustomerGuid DESC, Dato DESC";

            connection.Open();
            SqlCommand command1 = new SqlCommand(sql, connection);
            SqlParameter myparam = command1.Parameters.Add("@RapId", SqlDbType.NVarChar, 30);
            myparam.Value = RapId;
            byte[] img = (byte[])command1.ExecuteScalar();

            return img;
        }


        private byte[] GetPrewviewImage(AccountLogOnInfoItem LogonInfo, string RapId)
        {
            string conString;

            conString = @"server=" + LogonInfo.Server + ";User Id=" + LogonInfo.UserId + ";password=" + LogonInfo.Password + ";database=" + LogonInfo.Database + ";TrustServerCertificate=True";

            SqlConnection connection = new SqlConnection(conString);

            string sql = "SELECT TOP 1 * FROM Report_Files WHERE RapId=@RapId  ORDER BY CustomerGuid DESC, Dato DESC";

            connection.Open();
            SqlCommand command1 = new SqlCommand(sql, connection);
            SqlParameter myparam = command1.Parameters.Add("@RapId", SqlDbType.NVarChar, 30);
            myparam.Value = RapId;
            byte[] img = (byte[])command1.ExecuteScalar();

            return img;
        }

        #endregion

        #region Documents


        [Route("GetReportScreens")]
        [HttpPost]
        public string GetReportScreens(AccountLogOnInfoItem logonInfo)
        {
            string conString;
            string sql = "";
            sql = @"SELECT DISTINCT Skjerm
                  FROM REPORT R LEFT OUTER JOIN REPORT_FILES RF ON R.RapId=RF.RapId ";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            List<string> arrayKategori = new List<string>();

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string strKategori;
                            strKategori = rdr.GetString(0);
                            arrayKategori.Add(strKategori);
                        }
                    }
                }
                catch (SqlException ex)
                {
                }
            }

            string output = JsonConvert.SerializeObject(arrayKategori);

            return output;
        }


        [Route("GetTemplateList")]
        [HttpPost]
        public string GetTemplateList(AccountLogOnInfoItem logonInfo)
        {
            string conString;
            string sql = "";
            string ReportFilesGuid = "";

            sql = "SELECT ReportFilesGuid = (SELECT TOP 1 ReportFilesGuid FROM REPORT_FILES WHERE RapId=REPORT.RapId), RapId, Tittel, Beskrivelse, Kategori, Filnavn, Skjerm, RapType, Aktiv, HarFiler = (SELECT COUNT(*) FROM REPORT_FILES WHERE RapId=REPORT.RapId) " +
                "FROM REPORT ";

            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            List<ReportListeItem> arrayRapport = new List<ReportListeItem>();

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ReportListeItem stRapportListe = new();

                            if (!rdr.IsDBNull(rdr.GetOrdinal("ReportFilesGuid"))) ReportFilesGuid = rdr.GetString(rdr.GetOrdinal("ReportFilesGuid"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Rapid"))) stRapportListe.RapId = rdr.GetString(rdr.GetOrdinal("Rapid"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Skjerm"))) stRapportListe.Skjerm = rdr.GetString(rdr.GetOrdinal("Skjerm"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Tittel"))) stRapportListe.Tittel = rdr.GetString(rdr.GetOrdinal("Tittel"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Beskrivelse"))) stRapportListe.Beskrivelse = rdr.GetString(rdr.GetOrdinal("Beskrivelse"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("RapType"))) stRapportListe.RapType = (Int16)rdr.GetValue(rdr.GetOrdinal("RapType"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Aktiv"))) stRapportListe.Aktiv = rdr.GetBoolean(rdr.GetOrdinal("Aktiv"));
                            if (Convert.ToInt16(rdr.GetValue(rdr.GetOrdinal("HarFiler"))) > 0)
                                stRapportListe.HarFiler = true;
                            else
                                stRapportListe.HarFiler = false;

                            if (logonInfo.Parameters.yesno)
                            {
                                logonInfo.Parameters.field = ReportFilesGuid;
                                stRapportListe.Preview = GetReportFileImagePreview(logonInfo);
                            }

                            arrayRapport.Add(stRapportListe);
                        }
                    }
                }
                catch (SqlException ex)
                {

                }
            }
            string output = JsonConvert.SerializeObject(arrayRapport);

            return output;
        }

        [Route("GetSQLInformasjon")]
        [HttpPost]
        public string GetSQLInformasjon(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            List<DemoValuesItem> listDemovalues = new();
            List<TemplateSQLItem> listSQL = new();
            
            string sql = "";

            List<SQLVerdierItem> arrSQLVerdier = new();
            List<SQLVerdierItem> arrtmpVerdi = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            if (logonInfo.Parameters.field != null)
            {
                listDemovalues = FinnDemoVerdier(conString, logonInfo.Parameters.field);
            }

            //arrtmpVerdi = StandardJournalFelt(logonInfo);
            //foreach (var itm in arrtmpVerdi)
            //{
            //    if (itm.FeltNavn.IndexOf("GUID") == -1)
            //        arrSQLVerdier.Add(itm);
            //}

            listSQL.Clear();
            listSQL = FinnHoved(logonInfo);

            foreach (TemplateSQLItem item in listSQL)
            {
                foreach (DemoValuesItem A in listDemovalues)
                {
                    item.SQL = Regex.Replace(item.SQL, "#" + A.Name.ToUpper() + "#", A.Value, RegexOptions.IgnoreCase);
                }
                    

                if (item.SQL.Length > 0)
                {
                    foreach (TemplateSQLItem rS in listSQL)
                    {
                        if (rS.Type <= 2)
                        {
                            using (SqlConnection cnnG6 = new SqlConnection(conString))
                            {
                                SqlConnection cnnG63 = new SqlConnection(conString);
                                cnnG63.Open();

                                if (cnnG63.State == ConnectionState.Closed)
                                    cnnG63.Open();
                                SqlCommand cmdBB = cnnG63.CreateCommand();
                                cmdBB.CommandType = CommandType.Text;
                                cmdBB.CommandText = rS.SQL;

                                try
                                {
                                    SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);
                                    {
                                        if (drBB.Read())
                                        {
                                            for (var i = 0; i <= drBB.FieldCount - 1; i++)
                                            {
                                                if (!drBB.IsDBNull(i))
                                                    item.SQL = item.SQL.Replace("<RS." + drBB.GetName(i).ToUpper() + ">", drBB.GetValue(i).ToString());
                                            }
                                        }
                                    }
                                    drBB.Close();
                                }
                                catch (Exception ex)
                                {
                                }

                                cmdBB.Dispose();
                            }
                        }
                    }
                  
                }
            }

            foreach (TemplateSQLItem item in listSQL)
            {
                if (item.Type == 1 || item.Type == 2)
                {
                    arrtmpVerdi = HentListeFlettefelt(conString, item.SQL, logonInfo.Parameters.field);
                    foreach (var itm in arrtmpVerdi)
                    {
                        if (itm.FeltNavn.IndexOf("Guid") == -1)
                            arrSQLVerdier.Add(itm);
                    }
                }
                else if (item.Type == 3)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "Blokk";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 5)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkListe";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 6)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkListeA";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 7)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkListe1";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 9)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkHeader";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 10)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkImage";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
            }

            //ColSQL = FinnFormler(LogonInfo, RapId);

            //foreach (SrcRapportFormel rSQL in ColSQL)
            //{
            //    foreach (SrcDemo A in colDemoverdier)
            //        rSQL.FormelTekst = System.Text.RegularExpressions.Regex.Replace(rSQL.FormelTekst, "#" + A.Navn.ToUpper + "#", A.Verdi, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //    if (rSQL.FormelTekst.Length > 0)
            //    {
            //        if (rSQL.FormelTekst.IndexOf("<RS") > -1)
            //        {
            //            using (SqlClient.SqlConnection cnnG6 = new SqlClient.SqlConnection(sConStringWS))
            //            {
            //                SqlClient.SqlConnection cnnG63 = new SqlClient.SqlConnection(sConStringWS);
            //                cnnG63.Open();


            //                if (cnnG63.State == ConnectionState.Closed)
            //                    cnnG63.Open();
            //                SqlClient.SqlCommand cmdBB = cnnG63.CreateCommand;
            //                cmdBB.CommandType = CommandType.Text;
            //                cmdBB.CommandText = strSQL;

            //                try
            //                {
            //                    SqlClient.SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);
            //                    {
            //                        var withBlock = drBB;
            //                        if (withBlock.Read)
            //                        {
            //                            for (var i = 0; i <= withBlock.FieldCount - 1; i++)
            //                            {
            //                                if (!withBlock.IsDBNull(i))
            //                                    rSQL.FormelTekst = rSQL.FormelTekst.Replace("<RS." + withBlock.GetName(i).ToString.ToUpper + ">", withBlock.GetValue(i));
            //                            }
            //                        }
            //                    }
            //                    drBB.Close();
            //                }
            //                catch (Exception ex)
            //                {
            //                }

            //                cmdBB.Dispose();
            //            }
            //        }

            //        strSQL = rSQL.FormelTekst;

            //        // If Not strSQL.IndexOf(" TOP") > 0 Then
            //        // strSQL = System.Text.RegularExpressions.Regex.Replace(strSQL, "SELECT ", "SELECT TOP 1 ", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            //        // End If

            //        strSQL = strSQL.Replace("#FELLESRAAD#", LogonInfo.AktivFellesraad);

            //        rSQL.FormelTekst = strSQL;
            //    }
            //}

            //foreach (SrcRapportFormel sql in ColSQL)
            //{
            //    if (sql.FormelType == 5)
            //    {
            //        int verdi;
            //        verdi = ReadValue(sql.FormelTekst, 0, true);
            //        for (var i = 0; i <= sql.Antall; i++)
            //        {
            //            SrcSQLVerdier stSQLVerdi = new SrcSQLVerdier();
            //            stSQLVerdi.FeltNavn = sql.FormelNavn + i.ToString();
            //            stSQLVerdi.FontNavn = "Wingdings 2";
            //            stSQLVerdi.Type = "Boolean";
            //            stSQLVerdi.FormeltType = sql.FormelType;
            //            if (i == verdi)
            //                stSQLVerdi.Verdi = Strings.Chr(82);
            //            else
            //                stSQLVerdi.Verdi = Strings.Chr(163);
            //            arrSQLVerdier.Add(stSQLVerdi);
            //        }
            //    }
            //}


            //arrtmpVerdi = StandardFelt(LogonInfo);
            //foreach (var itm in arrtmpVerdi)
            //{
            //    if (itm.FeltNavn.IndexOf("GUID") == -1)
            //        arrSQLVerdier.Add(itm);
            //}

            string output = JsonConvert.SerializeObject(arrSQLVerdier);

            return output;
        }


        private List<SQLVerdierItem> GetSQLInformasjonInternal(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            List<DemoValuesItem> listDemovalues = new();
            List<TemplateSQLItem> listSQL = new();

            string sql = "";

            List<SQLVerdierItem> arrSQLVerdier = new();
            List<SQLVerdierItem> arrtmpVerdi = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            if (logonInfo.Parameters.field != null)
            {
                listDemovalues = FinnDemoVerdier(conString, logonInfo.Parameters.field);
            }

            //arrtmpVerdi = StandardJournalFelt(logonInfo);
            //foreach (var itm in arrtmpVerdi)
            //{
            //    if (itm.FeltNavn.IndexOf("GUID") == -1)
            //        arrSQLVerdier.Add(itm);
            //}

            listSQL.Clear();
            listSQL = FinnHoved(logonInfo);

            foreach (TemplateSQLItem item in listSQL)
            {
                foreach (DemoValuesItem A in listDemovalues)
                {
                    item.SQL = Regex.Replace(item.SQL, "#" + A.Name.ToUpper() + "#", A.Value, RegexOptions.IgnoreCase);
                }


                if (item.SQL.Length > 0)
                {
                    foreach (TemplateSQLItem rS in listSQL)
                    {
                        if (rS.Type <= 2)
                        {
                            using (SqlConnection cnnG6 = new SqlConnection(conString))
                            {
                                SqlConnection cnnG63 = new SqlConnection(conString);
                                cnnG63.Open();

                                if (cnnG63.State == ConnectionState.Closed) cnnG63.Open();

                                SqlCommand cmdBB = cnnG63.CreateCommand();
                                cmdBB.CommandType = CommandType.Text;
                                cmdBB.CommandText = rS.SQL;

                                try
                                {
                                    SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);
                                    {
                                        if (drBB.Read())
                                        {
                                            for (var i = 0; i <= drBB.FieldCount - 1; i++)
                                            {
                                                if (!drBB.IsDBNull(i))
                                                    item.SQL = item.SQL.Replace("<RS." + drBB.GetName(i).ToUpper() + ">", drBB.GetValue(i).ToString());
                                            }
                                        }
                                    }
                                    drBB.Close();
                                }
                                catch (Exception ex)
                                {
                                }

                                cmdBB.Dispose();
                            }
                        }
                    }

                }
            }

            foreach (TemplateSQLItem item in listSQL)
            {
                if (item.Type == 1 || item.Type == 2)
                {
                    arrtmpVerdi = HentListeFlettefelt(conString, item.SQL, logonInfo.Parameters.field);
                    foreach (var itm in arrtmpVerdi)
                    {
                        if (itm.FeltNavn.IndexOf("Guid") == -1)
                            arrSQLVerdier.Add(itm);
                    }
                }
                else if (item.Type == 3)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "Blokk";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 5)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkListe";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 6)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkListeA";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 7)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkListe1";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 9)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkHeader";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
                else if (item.Type == 10)
                {
                    SQLVerdierItem stSQLVerdi = new SQLVerdierItem();
                    stSQLVerdi.FeltNavn = item.Kode;
                    stSQLVerdi.Verdi = item.SQL;
                    stSQLVerdi.ForeColor = "white";
                    stSQLVerdi.BackColor = "darkred";
                    stSQLVerdi.Type = "BlokkImage";
                    arrSQLVerdier.Add(stSQLVerdi);
                }
            }

            //ColSQL = FinnFormler(LogonInfo, RapId);

            //foreach (SrcRapportFormel rSQL in ColSQL)
            //{
            //    foreach (SrcDemo A in colDemoverdier)
            //        rSQL.FormelTekst = System.Text.RegularExpressions.Regex.Replace(rSQL.FormelTekst, "#" + A.Navn.ToUpper + "#", A.Verdi, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //    if (rSQL.FormelTekst.Length > 0)
            //    {
            //        if (rSQL.FormelTekst.IndexOf("<RS") > -1)
            //        {
            //            using (SqlClient.SqlConnection cnnG6 = new SqlClient.SqlConnection(sConStringWS))
            //            {
            //                SqlClient.SqlConnection cnnG63 = new SqlClient.SqlConnection(sConStringWS);
            //                cnnG63.Open();


            //                if (cnnG63.State == ConnectionState.Closed)
            //                    cnnG63.Open();
            //                SqlClient.SqlCommand cmdBB = cnnG63.CreateCommand;
            //                cmdBB.CommandType = CommandType.Text;
            //                cmdBB.CommandText = strSQL;

            //                try
            //                {
            //                    SqlClient.SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);
            //                    {
            //                        var withBlock = drBB;
            //                        if (withBlock.Read)
            //                        {
            //                            for (var i = 0; i <= withBlock.FieldCount - 1; i++)
            //                            {
            //                                if (!withBlock.IsDBNull(i))
            //                                    rSQL.FormelTekst = rSQL.FormelTekst.Replace("<RS." + withBlock.GetName(i).ToString.ToUpper + ">", withBlock.GetValue(i));
            //                            }
            //                        }
            //                    }
            //                    drBB.Close();
            //                }
            //                catch (Exception ex)
            //                {
            //                }

            //                cmdBB.Dispose();
            //            }
            //        }

            //        strSQL = rSQL.FormelTekst;

            //        // If Not strSQL.IndexOf(" TOP") > 0 Then
            //        // strSQL = System.Text.RegularExpressions.Regex.Replace(strSQL, "SELECT ", "SELECT TOP 1 ", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            //        // End If

            //        strSQL = strSQL.Replace("#FELLESRAAD#", LogonInfo.AktivFellesraad);

            //        rSQL.FormelTekst = strSQL;
            //    }
            //}

            //foreach (SrcRapportFormel sql in ColSQL)
            //{
            //    if (sql.FormelType == 5)
            //    {
            //        int verdi;
            //        verdi = ReadValue(sql.FormelTekst, 0, true);
            //        for (var i = 0; i <= sql.Antall; i++)
            //        {
            //            SrcSQLVerdier stSQLVerdi = new SrcSQLVerdier();
            //            stSQLVerdi.FeltNavn = sql.FormelNavn + i.ToString();
            //            stSQLVerdi.FontNavn = "Wingdings 2";
            //            stSQLVerdi.Type = "Boolean";
            //            stSQLVerdi.FormeltType = sql.FormelType;
            //            if (i == verdi)
            //                stSQLVerdi.Verdi = Strings.Chr(82);
            //            else
            //                stSQLVerdi.Verdi = Strings.Chr(163);
            //            arrSQLVerdier.Add(stSQLVerdi);
            //        }
            //    }
            //}


            //arrtmpVerdi = StandardFelt(LogonInfo);
            //foreach (var itm in arrtmpVerdi)
            //{
            //    if (itm.FeltNavn.IndexOf("GUID") == -1)
            //        arrSQLVerdier.Add(itm);
            //}

            return arrSQLVerdier;
        }

        private List<TemplateSQLItem> FinnHoved(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql;
            List<TemplateSQLItem> sqlCol = new List<TemplateSQLItem>();

            sql = @"SELECT ReportSQLGuid, SQL, Kode, Type, IsNotNullField 
                  FROM REPORT_SQL ";

            if (logonInfo.Parameters.field != "") { sql += " WHERE RapId='" + logonInfo.Parameters.field + "'"; }
            sql += " ORDER BY Rekkefolge, Kode";

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";


            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            TemplateSQLItem item = new();
                            if (!rdr.IsDBNull(rdr.GetOrdinal("SQL"))) item.SQL = rdr.GetString(rdr.GetOrdinal("SQL"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Kode"))) item.Kode = rdr.GetString(rdr.GetOrdinal("Kode"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) item.Type = (Int16)rdr.GetValue(rdr.GetOrdinal("Type"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("IsNotNullField"))) item.IsNotNullField = rdr.GetString(rdr.GetOrdinal("IsNotNullField"));
                            sqlCol.Add(item);                        }
                    }
                }
                catch (SqlException ex)
                {
                }
            }

            return sqlCol;

        }

        private List<DemoValuesItem> FinnDemoVerdier(string conString, string RapId)
        {
            List<DemoValuesItem> listDemovalues = new();
            string sql;

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                sql = "SELECT Navn, Verdi FROM REPORT_DEMOVALUES";

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            DemoValuesItem A = new DemoValuesItem();
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Navn"))) A.Name = rdr.GetString(rdr.GetOrdinal("Navn"));
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Verdi"))) A.Value = rdr.GetString(rdr.GetOrdinal("Verdi"));
                            listDemovalues.Add(A);
                        }
                    }
                }
                catch (SqlException ex)
                {
 
                }

                return listDemovalues;
            }
        }

        private List<SQLVerdierItem> HentListeFlettefelt(string conString, string sql, string RapId)
        {
            System.Type strType;
            string strFeltNavn = "";

            List<SQLVerdierItem> arrSQLVerdier = new List<SQLVerdierItem>();

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmdHovedSQL = cnn.CreateCommand();
                cmdHovedSQL.CommandType = CommandType.Text;
                cmdHovedSQL.CommandText = sql;

                try
                {
                    SqlDataReader drHovedSQL = cmdHovedSQL.ExecuteReader();
                    DataTable schemaTable = drHovedSQL.GetSchemaTable();

                    {
                        if (drHovedSQL.Read())
                        {
                            for (var i = 0; i <= drHovedSQL.FieldCount - 1; i++)
                            {
                                var stSQLVerdier = new SQLVerdierItem();

                                stSQLVerdier.FeltNavn = drHovedSQL.GetName(i);
                                if (strFeltNavn.IndexOf("GUID") == -1)
                                {
                                    strType = drHovedSQL.GetFieldType(i);
                                    if (!drHovedSQL.IsDBNull(i))
                                    {
                                        if (strType.Name == "Boolean")
                                        {
                                            if (drHovedSQL.GetBoolean(i) == true)
                                            {
                                                stSQLVerdier.FontNavn = "Wingdings 2";
                                                stSQLVerdier.Verdi = Strings.Chr(82).ToString();
                                            }
                                            else
                                            {
                                                stSQLVerdier.FontNavn = "Wingdings 2";
                                                stSQLVerdier.Verdi = Strings.Chr(163).ToString();
                                            }
                                            stSQLVerdier.Type = "Boolean";
                                        }
                                        else if (strType.Name == "DateTime")
                                        {
                                            stSQLVerdier.Verdi = drHovedSQL.GetValue(i).ToString().Substring(0, 10);
                                            stSQLVerdier.Type = "Value";
                                        }
                                        else if (strType.Name == "Image")
                                        {
                                            stSQLVerdier.Verdi = drHovedSQL.GetValue(i).ToString().Substring(0, 10);
                                            stSQLVerdier.Type = "Image";
                                        }
                                        else
                                        {
                                            stSQLVerdier.Verdi = drHovedSQL.GetValue(i).ToString();
                                            stSQLVerdier.Type = "Value";
                                        }
                                    }
                                }
                                arrSQLVerdier.Add(stSQLVerdier);
                            }

                            sql = "SELECT * FROM REPORT_FORMEL WHERE RapId='" + RapId + "'";
                            if (cnn.State == ConnectionState.Closed)
                                cnn.Open();

                            SqlCommand cmdFormelSQL = cnn.CreateCommand();
                            cmdFormelSQL.CommandType = CommandType.Text;
                            cmdFormelSQL.CommandText = sql;

                            try
                            {
                                string strKode = "";
                                int intType = 0;
                                int intAntall = 10;

                                SqlDataReader drFormelSQL = cmdFormelSQL.ExecuteReader();
                                {
                                    while (drFormelSQL.Read())
                                    {
                                        var stSQLVerdi = new SQLVerdierItem();
                                        if (!drFormelSQL.IsDBNull(drFormelSQL.GetOrdinal("FormelNavn"))) strKode = drFormelSQL.GetString(drFormelSQL.GetOrdinal("FormelNavn"));
                                        if (!drFormelSQL.IsDBNull(drFormelSQL.GetOrdinal("FormelType"))) intType = (Int16)drFormelSQL.GetValue(drFormelSQL.GetOrdinal("FormelType"));
                                        if (!drFormelSQL.IsDBNull(drFormelSQL.GetOrdinal("Antall"))) intAntall = (Int16)drFormelSQL.GetValue(drFormelSQL.GetOrdinal("Antall"));
                                        if (!drFormelSQL.IsDBNull(drFormelSQL.GetOrdinal("FormelTekst"))) sql = drFormelSQL.GetString(drFormelSQL.GetOrdinal("FormelTekst"));

                                        if (intAntall == 0)
                                            intAntall = 10;
                                        {
                                            for (var i = 0; i <= drHovedSQL.FieldCount - 1; i++)
                                            {
                                                if (!drHovedSQL.IsDBNull(i))
                                                    sql = sql.Replace("<RS." + drHovedSQL.GetName(i).ToString().ToUpper() + ">", drFormelSQL.GetValue(i).ToString());
                                            }
                                        }

                                        using (SqlConnection cnnG6b = new SqlConnection(conString))
                                        {
                                            cnnG6b.Open();

                                            SqlCommand cmdBB = cnnG6b.CreateCommand();
                                            cmdBB.CommandType = CommandType.Text;
                                            cmdBB.CommandText = sql;

                                            SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);
                                            {
                                                if (intType == 2 && drBB.Read())
                                                {
                                                    stSQLVerdi.FeltNavn = strKode;
                                                    if (!drBB.IsDBNull(0))
                                                    {
                                                        strType = drBB.GetFieldType(0);
                                                        if (strType.Name == "Boolean")
                                                        {
                                                            if (drBB.GetBoolean(0) == true)
                                                            {
                                                                stSQLVerdi.FontNavn = "Wingdings 2";
                                                                stSQLVerdi.Verdi = Strings.Chr(82).ToString();
                                                            }
                                                            else
                                                            {
                                                                stSQLVerdi.FontNavn = "Wingdings 2";
                                                                stSQLVerdi.Verdi = Strings.Chr(163).ToString();
                                                            }
                                                            stSQLVerdi.Type = "Boolean";
                                                        }
                                                        else if (strType.Name == "Value")
                                                        {
                                                            stSQLVerdi.Verdi = drBB.GetValue(0).ToString().Substring(0, 10);
                                                            stSQLVerdi.Type = "DateTime";
                                                        }
                                                        else
                                                        {
                                                            stSQLVerdi.Verdi = drBB.GetValue(0).ToString();
                                                            stSQLVerdi.Type = "Value";
                                                        }
                                                        arrSQLVerdier.Add(stSQLVerdi);
                                                    }
                                                }
                                                else if (intType == 5)
                                                {
                                                    int intVerdi = 0;
                                                    if (drBB.Read())
                                                    {
                                                        if (!drBB.IsDBNull(0))
                                                            intVerdi = (Int16)drBB.GetValue(0);
                                                        else
                                                            intVerdi = 0;
                                                    }
                                                    for (var i = 0; i <= intAntall - 1; i++)
                                                    {
                                                        var stSQLVerdi2 = new SQLVerdierItem();

                                                        stSQLVerdi2.FeltNavn = strKode + i;
                                                        if (i == intVerdi)
                                                        {
                                                            stSQLVerdi2.FontNavn = "Wingdings 2";
                                                            stSQLVerdi.Verdi = Strings.Chr(82).ToString();
                                                        }
                                                        else
                                                        {
                                                            stSQLVerdi2.FontNavn = "Wingdings 2";
                                                            stSQLVerdi.Verdi = Strings.Chr(163).ToString();
                                                        }
                                                        stSQLVerdi.Type = "Choose";
                                                        arrSQLVerdier.Add(stSQLVerdi2);
                                                    }
                                                }
                                            }
                                            drBB.Close();
                                            cmdBB.Dispose();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        else
                            for (var i = 0; i <= drHovedSQL.FieldCount - 1; i++)
                            {
                                var stSQLVerdier3 = new SQLVerdierItem();

                                strFeltNavn = drHovedSQL.GetName(i);
                                if (strFeltNavn.IndexOf("GUID") == -1)
                                {
                                    stSQLVerdier3.FeltNavn = strFeltNavn;
                                    arrSQLVerdier.Add(stSQLVerdier3);
                                }
                            }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return arrSQLVerdier;
        }


        [Route("GetDocumentTemplate")]
        [HttpPost]
        public string GetDocumentTemplate(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            byte[] MyDoc;

            string strBase64Dokument = "";

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            if (logonInfo.Parameters.field != null)
            {
                MyDoc = FinnSiste(logonInfo, logonInfo.Parameters.field);
                if (MyDoc != null && MyDoc.Length > 0)
                    strBase64Dokument = Convert.ToBase64String(MyDoc);
            }

            return strBase64Dokument;
        }

        [Route("SetDocumentTemplate")]
        [HttpPost]
        public string SetDocumentTemplate(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            byte[] MyDoc;

            string strBase64Dokument = "";

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            if (logonInfo.Parameters.field != null)
            {
                MyDoc = FinnSiste(logonInfo, logonInfo.Parameters.field);
                if (MyDoc != null && MyDoc.Length > 0)
                    strBase64Dokument = Convert.ToBase64String(MyDoc);
            }

            return strBase64Dokument;
        }


        [Route("CreateSpireDoc")]
        [HttpPost]
        public string CreateSpireDoc(DocumentItems item)
        {
            int intFormelAntall = 0;
            ReportPreviewItem Retur = new();
            string strBase64Dokument = "";

            string conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            byte[] MyDoc;

            MyDoc = FinnSiste(item.logonInfo, item.RapId);
            if (MyDoc == null || MyDoc.Length == 0)
            {
                Retur.ErrorTekst = "Finner ikke rapport filen";

            }
            else
            {

                using (SqlConnection cnnG6 = new SqlConnection(conString))
                {
                    cnnG6.Open();

                    SqlConnection cnnG62 = new SqlConnection(conString);
                    cnnG62.Open();

                    SqlConnection cnnG63 = new SqlConnection(conString);
                    cnnG63.Open();

                    SqlConnection cnnG6F = new SqlConnection(conString);
                    cnnG6F.Open();

                    MemoryStream stream = new MemoryStream(MyDoc);

                    string styleTH = "";
                    string styleTT = "";
                    string styleH = "";

                    Spire.Doc.Document doc = new Spire.Doc.Document(stream);
                    Spire.Doc.Section s = doc.Sections[0];

                    foreach (Style stil in doc.Styles)
                    {
                        if (stil.Name == "TableH")
                            styleTH = "TableH";
                        else if (stil.Name == "TableT")
                            styleTT = "TableT";
                        else if (stil.Name == "Heading 2")
                            styleH = "Heading 2";
                    }

                    string strSQL;
                    int intType = 0;
                    int intStadie = 0;
                    string strKode = "";
                    int i = 0;
                    string strTekst = "";
                    int intVerdi;
                    Type strType;
                    string strRegId = "";
                    DataTable strRegIdTabell = null;
                    List<VarTypeItem> arrFV = new List<VarTypeItem>();

                    TextSelection selImage = doc.FindString("<<ImageShip>>", false, true);

                    if (selImage != null && item.logonInfo.Parameters.fieldValue != null)
                    {
                        Spire.Doc.Fields.TextRange trI = selImage.GetAsOneRange();
                        var par = trI.OwnerParagraph;

                        Spire.Doc.Section? section = par.Owner.Owner as Spire.Doc.Section;

                        par.Text = "";

                        ShipController sc = new ShipController();

                        string base64string = sc.GetShipPicture(conString, item.logonInfo.Parameters.fieldValue);
                        byte[] img = Convert.FromBase64String(base64string);
                        MemoryStream ms = new MemoryStream(img);
                        Bitmap p = new Bitmap(ms);

                        DocPicture pic = par.AppendPicture(p);
                    }

                    strSQL = "SELECT TOP 1 Type, Stadie, Kode, Rekkefolge, Format, SQL FROM REPORT_SQL WHERE RapId='" + item.RapId + "' AND Stadie=1 ";
                    try
                    {
                        SqlCommand cmdHovedSQL = cnnG6.CreateCommand();
                        cmdHovedSQL.CommandType = CommandType.Text;
                        cmdHovedSQL.CommandText = strSQL;

                        SqlDataReader drHovedSQL = cmdHovedSQL.ExecuteReader();

                        {
                            if (drHovedSQL.Read())
                            {
                                if (!drHovedSQL.IsDBNull(drHovedSQL.GetOrdinal("SQL")))
                                    strSQL = drHovedSQL.GetString(drHovedSQL.GetOrdinal("SQL"));
                                else
                                    strSQL = "";
                                if (!drHovedSQL.IsDBNull(drHovedSQL.GetOrdinal("Type")))
                                    intType = Convert.ToInt16(drHovedSQL.GetValue(drHovedSQL.GetOrdinal("Type")));
                                else
                                    intType = 0;

                                if (item.Verdier.Count>0)
                                {
                                    foreach (var var in item.Verdier)
                                    {
                                        if (var.Kode.Length > 0 && var.Verdi != null && var.Verdi.Length > 0)
                                            strSQL = System.Text.RegularExpressions.Regex.Replace(strSQL, "#" + var.Kode.ToUpper() + "#", var.Verdi, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                        else if (var.Kode.Length > 0 && var.Verdi != null && var.Verdi.Length == 0)
                                            strSQL = System.Text.RegularExpressions.Regex.Replace(strSQL, "#" + var.Kode.ToUpper() + "#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                    }
                                }
                            }
                            else
                                strSQL = "";
                        }
                        drHovedSQL.Close();

                        if (strSQL.Length == 0)
                            goto StandardVerdier;

                        cmdHovedSQL.CommandText = strSQL;
                        drHovedSQL = cmdHovedSQL.ExecuteReader();
                        {
                            if (intType == 2)
                            {
                                if (drHovedSQL.Read())
                                {
                                    strType = drHovedSQL.GetFieldType(0);
                                    if (strType.Name == "String")
                                    {
                                        if (!drHovedSQL.IsDBNull(0))
                                        {
                                            strRegId = drHovedSQL.GetString(0);
                                            strRegIdTabell = drHovedSQL.GetSchemaTable();
                                        }
                                    }
                                    else
                                        strRegId = "";

                                    for (i = 0; i <= drHovedSQL.FieldCount - 1; i++)
                                    {
                                        if (!drHovedSQL.IsDBNull(i))
                                        {
                                            strType = drHovedSQL.GetFieldType(i);
                                            if (strType.Name == "Boolean")
                                            {
                                                if (drHovedSQL.GetBoolean(i) == true)
                                                {
                                                    doc.Replace("<<" + drHovedSQL.GetName(i).ToString() + "J>>", Strings.Chr(82).ToString(), false, false);
                                                    doc.Replace("<<" + drHovedSQL.GetName(i).ToString() + "J>>", Strings.Chr(82).ToString(), false, false);
                                                    doc.Replace("<<" + drHovedSQL.GetName(i).ToString() + "N>>", Strings.Chr(163).ToString(), false, false);
                                                }
                                                else
                                                {
                                                    doc.Replace("<<" + drHovedSQL.GetName(i).ToString() + "N>>", Strings.Chr(82).ToString(), false, false);
                                                    doc.Replace("<<" + drHovedSQL.GetName(i).ToString() + "J>>", Strings.Chr(163).ToString(), false, false);
                                                }
                                            }
                                            else
                                                doc.Replace("<<" + drHovedSQL.GetName(i).ToString() + ">>", drHovedSQL.GetValue(i).ToString(), false, false);
                                        }
                                        else
                                            doc.Replace("<<" + drHovedSQL.GetName(i).ToString() + ">>", "", false, false);
                                        VarTypeItem fv = new VarTypeItem();
                                        fv.Navn = drHovedSQL.GetName(i).ToString();
                                        fv.Verdi = drHovedSQL.GetValue(i).ToString();
                                        arrFV.Add(fv);
                                    }

                                    // UTFØRER SQL SELECT
                                    strSQL = "SELECT Type, Stadie, Kode, Rekkefolge, Format, SQL FROM REPORT_SQL WHERE RapId='" + item.RapId + "' AND Stadie>1 ORDER BY Stadie, Rekkefolge";
                                    string strLastKode = "";
                                    try
                                    {
                                        SqlCommand cmdRapSQL = cnnG62.CreateCommand();
                                        cmdRapSQL.CommandType = CommandType.Text;
                                        cmdRapSQL.CommandText = strSQL;

                                        SqlDataReader drRapSQL = cmdRapSQL.ExecuteReader();

                                        {
                                            while (drRapSQL.Read())
                                            {
                                                if (!drRapSQL.IsDBNull(drRapSQL.GetOrdinal("Kode")))
                                                    strKode = drRapSQL.GetString(drRapSQL.GetOrdinal("Kode")).ToUpper();
                                                else
                                                    strKode = "";
                                                if (strKode != strLastKode)
                                                {
                                                    strLastKode = strKode;
                                                    if (!drRapSQL.IsDBNull(drRapSQL.GetOrdinal("Type")))
                                                        intType = Convert.ToInt16(drRapSQL.GetValue(drRapSQL.GetOrdinal("Type")));
                                                    else
                                                        intType = 0;
                                                    if (!drRapSQL.IsDBNull(drRapSQL.GetOrdinal("Stadie")))
                                                        intStadie = Convert.ToInt16(drRapSQL.GetValue(drRapSQL.GetOrdinal("Stadie")));
                                                    else
                                                        intStadie = 0;
                                                    if (!drRapSQL.IsDBNull(drRapSQL.GetOrdinal("SQL")))
                                                        strSQL = drRapSQL.GetString(drRapSQL.GetOrdinal("SQL"));
                                                    else
                                                        strSQL = "";
                                                    foreach (var var in item.Verdier)
                                                    {
                                                        if (var.Kode.Length > 0 && var.Verdi.Length > 0)
                                                            strSQL = System.Text.RegularExpressions.Regex.Replace(strSQL, "#" + var.Kode.ToUpper() + "#", var.Verdi, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                                        else if (var.Kode.Length > 0 && var.Verdi.Length == 0)
                                                            strSQL = System.Text.RegularExpressions.Regex.Replace(strSQL, "#" + var.Kode.ToUpper() + "#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                                    }

                                                    switch (intType)
                                                    {
                                                        case 2:
                                                            {
                                                                foreach (var f in arrFV)
                                                                    strSQL = strSQL.Replace("<RS." + f.Navn.ToUpper() + ">", f.Verdi);
                                                                if (cnnG63.State == ConnectionState.Closed)
                                                                    cnnG63.Open();
                                                                SqlCommand cmdFlette = cnnG63.CreateCommand();
                                                                cmdFlette.CommandType = CommandType.Text;
                                                                cmdFlette.CommandText = strSQL;
                                                                SqlDataReader drFlette = cmdFlette.ExecuteReader();
                                                                {
                                                                    if (drFlette.HasRows)
                                                                    {
                                                                        while (drFlette.Read())
                                                                        {
                                                                            for (i = 0; i <= drFlette.FieldCount - 1; i++)
                                                                            {
                                                                                if (!drFlette.IsDBNull(i))
                                                                                {
                                                                                    strType = drFlette.GetFieldType(i);
                                                                                    if (strType.Name == "Boolean")
                                                                                    {
                                                                                        if (drFlette.GetBoolean(i) == true)
                                                                                        {
                                                                                            doc.Replace("<<" + drFlette.GetName(i).ToUpper() + "J>>", Strings.Chr(82).ToString(), false, false);
                                                                                            doc.Replace("<<" + drFlette.GetName(i).ToUpper() + "N>>", Strings.Chr(163).ToString(), false, false);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            doc.Replace("<<" + drFlette.GetName(i).ToUpper() + "N>>", Strings.Chr(82).ToString(), false, false);
                                                                                            doc.Replace("<<" + drFlette.GetName(i).ToUpper() + "J>>", Strings.Chr(163).ToString(), false, false);
                                                                                        }
                                                                                        doc.Replace("<<" + drFlette.GetName(i).ToUpper() + ">>", drFlette.GetValue(i).ToString(), false, false);
                                                                                    }
                                                                                    else
                                                                                        doc.Replace("<<" + drFlette.GetName(i).ToUpper() + ">>", drFlette.GetValue(i).ToString(), false, false);
                                                                                }
                                                                                else
                                                                                    doc.Replace("<<" + drFlette.GetName(i).ToUpper() + ">>", "", false, false);
                                                                                VarTypeItem fv = new();
                                                                                fv.Navn = drFlette.GetName(i).ToString();
                                                                                fv.Verdi = drFlette.GetValue(i).ToString();
                                                                                arrFV.Add(fv);
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                        for (i = 0; i <= drFlette.FieldCount - 1; i++)
                                                                            doc.Replace("<<" + drFlette.GetName(i).ToString() + ">>", "", false, false);
                                                                }
                                                                drFlette.Close();
                                                                cmdFlette.Dispose();
                                                                if (cnnG63.State == ConnectionState.Open)
                                                                    cnnG63.Close();
                                                                break;
                                                            }

                                                        case 3: // FLETTER INN BLOKKEN
                                                 
                                                            {
                                                                Spire.Doc.Documents.TextSelection selection = doc.FindString("<<" + strKode + ">>", false, true);

                                                                if (selection != null)
                                                                {
                                                                    foreach (var f in arrFV)
                                                                        strSQL = strSQL.Replace("<RS." + f.Navn.ToUpper() + ">", f.Verdi);

                                                                    int rCount = 0;

                                                                    if (cnnG63.State == ConnectionState.Closed) 
                                                                        cnnG63.Open();

                                                                    SqlCommand cmdBB = cnnG63.CreateCommand();
                                                                    cmdBB.CommandType = CommandType.Text;
                                                                    cmdBB.CommandText = strSQL;
                                                                    SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);

                                                                    if (drBB.HasRows)
                                                                    {
                                                                        Spire.Doc.Fields.TextRange tr = selection.GetAsOneRange();
                                                                        var par = tr.OwnerParagraph;
                                                                        Spire.Doc.Table table;

                                                                        if (par.IsInCell)
                                                                        {
                                                                            table = null;
                                                                            foreach (Spire.Doc.Table t in s.Tables)
                                                                            {
                                                                                if (t.Rows.Count == 1 && t.Rows[0].Cells[0].Paragraphs[0].Text.ToUpper().Trim() == "<<" + strKode + ">>")
                                                                                {
                                                                                    table = t;
                                                                                    table.ResetCells(1, drBB.FieldCount);
                                                                                    break;
                                                                                }
                                                                                else if (t.Rows.Count >= 2 && t.Rows[1].Cells[0].Paragraphs[0].Text.ToUpper().Trim() == "<<" + strKode + ">>")
                                                                                {
                                                                                    table = t;
                                                                                    table.Rows.RemoveAt(1);
                                                                                    break;
                                                                                }
                                                                            }

                                                                            if (table != null)
                                                                            {
                                                                                try
                                                                                {
                                                                                    {
                                                                                        var drFlette = drBB;
                                                                                        while (drFlette.Read())
                                                                                        {
                                                                                            Spire.Doc.TableRow DataRow = table.AddRow();
                                                                                            //DataRow.RowFormat.Borders.Bottom.BorderType = Spire.Doc.Documents.BorderStyle.Cleared;
                                                                                            //DataRow.RowFormat.Borders.Top.BorderType = Spire.Doc.Documents.BorderStyle.Cleared;
                                                                                            //DataRow.RowFormat.Borders.Top.ClearFormatting();
                                                                                            //DataRow.RowFormat.Borders.Bottom.ClearFormatting();

                                                                                            for (i = 0; i <= drFlette.FieldCount - 1; i++)
                                                                                            {
                                                                                                Spire.Doc.Documents.Paragraph p2 = DataRow.Cells[i].AddParagraph();
                                                                                                if (styleTT.Length > 0)
                                                                                                    p2.ApplyStyle(styleTT);

                                                                                                if (!drFlette.IsDBNull(i))
                                                                                                {
                                                                                                    switch (drBB.GetDataTypeName(i).ToUpper())
                                                                                                    {
                                                                                                        case "INT":
                                                                                                        case "INTEGER":
                                                                                                            {
                                                                                                                p2.Text = drFlette.GetValue(i).ToString();
                                                                                                                p2.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                                                                                                                break;
                                                                                                            }

                                                                                                        case "FLOAT":
                                                                                                        case "DOUBLE":
                                                                                                        case "DECIMAL":
                                                                                                            {
                                                                                                                p2.Text = drFlette.GetValue(i).ToString();
                                                                                                                p2.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                                                                                                                break;
                                                                                                            }

                                                                                                        default:
                                                                                                            {
                                                                                                                string flette = drFlette.GetValue(i).ToString();
                                                                                                                int verdi;
                                                                                                                Single verdiS;
                                                                                                                float verdiF;

                                                                                                                if (int.TryParse(flette, out verdi))
                                                                                                                {
                                                                                                                    p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                                                                }
                                                                                                                if (Single.TryParse(flette, out verdiS))
                                                                                                                {
                                                                                                                    p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                                                                }
                                                                                                                if (float.TryParse(flette, out verdiF))
                                                                                                                {
                                                                                                                    p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                                                                }

                                                                                                                p2.Text = flette;
                                                                                                                break;
                                                                                                            }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                catch (Exception ex)
                                                                                {
                                                                                    Debug.Write(ex.Message);
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            table = s.AddTable(true);
                                                                            table.ResetCells(1, drBB.FieldCount);
                                                                            Spire.Doc.TableRow fRow = table.Rows[0];
    
                                                                            try
                                                                            {
                                                                                {
                                                                                    var drFlette = drBB;
                                                                                    while (drFlette.Read())
                                                                                    {
                                                                                        Spire.Doc.TableRow DataRow = table.AddRow();

                                                                                        for (i = 0; i <= drFlette.FieldCount - 1; i++)
                                                                                        {
                                                                                            Spire.Doc.Documents.Paragraph p2 = DataRow.Cells[i].AddParagraph();
                                                                                            if (styleTT.Length > 0)
                                                                                                p2.ApplyStyle(styleTT);

                                                                                            if (!drFlette.IsDBNull(i))
                                                                                            {
                                                                                                switch (drBB.GetDataTypeName(i).ToUpper())
                                                                                                {
                                                                                                    case "INT":
                                                                                                    case "INTEGER":
                                                                                                        {
                                                                                                            p2.Text = drFlette.GetValue(i).ToString();
                                                                                                            break;
                                                                                                        }

                                                                                                    case "FLOAT":
                                                                                                    case "DOUBLE":
                                                                                                    case "DECIMAL":
                                                                                                        {
                                                                                                            p2.Text = drFlette.GetValue(i).ToString();
                                                                                                            break;
                                                                                                        }

                                                                                                    default:
                                                                                                        {
                                                                                                            p2.Text = drFlette.GetValue(i).ToString();
                                                                                                            break;
                                                                                                        }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
                                                                            }

                                                                            if (selection != null)
                                                                            {
                                                                                Spire.Doc.Fields.TextRange range = selection.GetAsOneRange();
                                                                                Spire.Doc.Documents.Paragraph paragraph = range.OwnerParagraph;
                                                                                Spire.Doc.Body body = paragraph.OwnerTextBody;
                                                                                int index = body.ChildObjects.IndexOf(paragraph);

                                                                                body.ChildObjects.Remove(paragraph);
                                                                                body.ChildObjects.Insert(index, table);
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                        doc.Replace("<<" + strKode + ">>", "", false, true);

                                                                    drBB.Close();
                                                                    cmdBB.Dispose();
                                                                    if (cnnG63.State == ConnectionState.Open)
                                                                        cnnG63.Close();
                                                                }
                                                                else
                                                                    doc.Replace("<<" + strKode + ">>", "", false, true);
                                                                break;
                                                            }

                                                        case 6:
                                                            {
                                                                TextSelection selection = doc.FindString("<<" + strKode + ">>", false, true);
                                                                if (selection != null)
                                                                {
                                                                    foreach (var f in arrFV)
                                                                        strSQL = strSQL.Replace("<RS." + f.Navn.ToUpper() + ">", f.Verdi);

                                                                    using (SqlConnection cnn = new SqlConnection(conString))
                                                                    {
                                                                        cnn.Open();
                                                                        try
                                                                        {
                                                                            SqlCommand cmdBB = cnn.CreateCommand();

                                                                            cmdBB.CommandType = CommandType.Text;
                                                                            cmdBB.CommandText = strSQL;
                                                                            SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);

                                                                            if (drBB.HasRows)
                                                                            {
                                                                                Spire.Doc.Fields.TextRange tr = selection.GetAsOneRange();
                                                                                Spire.Doc.Documents.Paragraph par = tr.OwnerParagraph;

                                                                                Spire.Doc.Section? section = par.Owner.Owner as Spire.Doc.Section;
                                                                                int index = section.Body.ChildObjects.IndexOf(par);

                                                                                par.Text = "";

                                                                                try
                                                                                {
                                                                                    var drFlette = drBB;
                                                                                    while (drFlette.Read())
                                                                                    {

                                                                                        for (i = 0; i <= drFlette.FieldCount - 1; i++)
                                                                                        {
                                                                                            //Spire.Doc.Documents.Paragraph p2 = par. s.AddParagraph();

                                                                                            if (!drFlette.IsDBNull(i))
                                                                                            {
                                                                                                switch (drBB.GetDataTypeName(i).ToUpper())
                                                                                                {
                                                                                                    case "INT":
                                                                                                    case "INTEGER":
                                                                                                        {
                                                                                                            par.AppendText(drFlette.GetValue(i).ToString());

                                                                                                            break;
                                                                                                        }

                                                                                                    case "FLOAT":
                                                                                                    case "DOUBLE":
                                                                                                    case "DECIMAL":
                                                                                                        {
                                                                                                            //p2.Text = drFlette.GetValue(i).ToString();
                                                                                                            //p2.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                                                                                                            break;
                                                                                                        }

                                                                                                    default:
                                                                                                        {
                                                                                                            Spire.Doc.Documents.Paragraph parIns = new(doc);
                                                                                                            parIns.AppendText(drFlette.GetValue(i).ToString());
                                                                                                            parIns.ApplyStyle("List abc");
                                                                                                            doc.Sections[0].Paragraphs.Insert(index, parIns);
                                                                                                            index++;
                                                                                                            //par.AppendText(drFlette.GetValue(i).ToString() + System.Environment.NewLine);

                                                                                                            break;
                                                                                                        }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                catch (Exception ex)
                                                                                {
                                                                                }



                                                                            }
                                                                            else
                                                                            {
                                                                                doc.Replace("<<" + strKode + ">>", "", false, true);
                                                                            }

                                                                            drBB.Close();
                                                                            cmdBB.Dispose();
                                                                        }
                                                                        catch (Exception ex) { }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    doc.Replace("<<" + strKode + ">>", "", false, true);
                                                                }
                                                                break;
                                                            }

                                                        case 9:
                                                            {

                                                                TextSelection selection = doc.FindString("<<" + strKode + ">>", false, true);
                                                                if (selection != null)
                                                                {
                                                                    foreach (var f in arrFV)
                                                                        strSQL = strSQL.Replace("<RS." + f.Navn.ToUpper() + ">", f.Verdi);

                                                                    using (SqlConnection cnn = new SqlConnection(conString))
                                                                    {
                                                                        cnn.Open();
                                                                        try
                                                                        {
                                                                            SqlCommand cmdBB = cnn.CreateCommand();

                                                                            cmdBB.CommandType = CommandType.Text;
                                                                            cmdBB.CommandText = strSQL;
                                                                            SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);

                                                                            if (drBB.HasRows)
                                                                            {
                                                                                Spire.Doc.Fields.TextRange tr = selection.GetAsOneRange();
                                                                                var par = tr.OwnerParagraph;

                                                                                Spire.Doc.Fields.TextRange trH = selection.GetAsOneRange();
                                                                                Spire.Doc.Documents.Paragraph parH = tr.OwnerParagraph;

                                                                                Spire.Doc.Section? section = par.Owner.Owner as Spire.Doc.Section;
                                                                                int index = section.Body.ChildObjects.IndexOf(par);

                                                                                Spire.Doc.Table tableH = null;

                                                                                par.Text = "";

                                                                                string oldHeader = "";

                                                                                try
                                                                                {
                                                                                    {
                                                                                        var drFlette = drBB;
                                                                                        while (drFlette.Read())
                                                                                        {
                                                                                            if (oldHeader != drFlette.GetValue(0).ToString())
                                                                                            {
                                                                                                Spire.Doc.Documents.Paragraph parIns = new(doc);
                                                                                                parIns.AppendText(drFlette.GetValue(0).ToString());
                                                                                                if (styleH.Length>0)
                                                                                                    parIns.ApplyStyle(styleH);

                                                                                                doc.Sections[0].Paragraphs.Insert(index, parIns);

                                                                                                oldHeader = drFlette.GetValue(0).ToString();

                                                                                                tableH = new Spire.Doc.Table(doc, true);
                                                                                                PreferredWidth width = new PreferredWidth(WidthType.Percentage, 100);
                                                                                                tableH.PreferredWidth = width;
                                                                                                par.Owner.ChildObjects.Insert(index + 1, tableH);
                                                                                                tableH.ResetCells(1, drBB.FieldCount - 1);
                                                                                                Spire.Doc.TableRow fRow = tableH.Rows[0];
                                                                                                fRow.IsHeader = true;


                                                                                                for (i = 1; i <= drFlette.FieldCount - 1; i++)
                                                                                                {
                                                                                                    Spire.Doc.Documents.Paragraph p2 = fRow.Cells[i - 1].AddParagraph();
                                                                                                    if (styleTH.Length>0)
                                                                                                        p2.ApplyStyle(styleTH);

                                                                                                    p2.Text = drFlette.GetName(i);
                                                                                                    if (p2.Text == "NoHeader") { p2.Text = ""; }
                                                                                                    if (i == 1) { fRow.Cells[i - 1].SetCellWidth(500, Spire.Doc.CellWidthType.Point); }
                                                                                                    if (i == 2) { fRow.Cells[i - 1].SetCellWidth(150, Spire.Doc.CellWidthType.Point); }
                                                                                                    if (i == 3) { fRow.Cells[i - 1].SetCellWidth(50, Spire.Doc.CellWidthType.Point); }
                                                                                                }

                                                                                            }

                                                                                            Spire.Doc.TableRow DataRow = tableH.AddRow();

                                                                                            for (i = 1; i <= drFlette.FieldCount - 1; i++)
                                                                                            {
                                                                                                Spire.Doc.Documents.Paragraph p2 = DataRow.Cells[i - 1].AddParagraph();
                                                                                                if (styleTT.Length > 0)
                                                                                                    p2.ApplyStyle(styleTT);

                                                                                                if (!drFlette.IsDBNull(i))
                                                                                                {
                                                                                                    switch (drBB.GetDataTypeName(i).ToUpper())
                                                                                                    {
                                                                                                        case "INT":
                                                                                                        case "INTEGER":
                                                                                                            {
                                                                                                                p2.Text = drFlette.GetValue(i).ToString();
                                                                                                                break;
                                                                                                            }

                                                                                                        case "FLOAT":
                                                                                                        case "DOUBLE":
                                                                                                        case "DECIMAL":
                                                                                                            {
                                                                                                                p2.Text = drFlette.GetValue(i).ToString();
                                                                                                                p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                                                                break;
                                                                                                            }

                                                                                                        default:
                                                                                                            {
                                                                                                                string flette = drFlette.GetValue(i).ToString();
                                                                                                                int verdi;
                                                                                                                Single verdiS;
                                                                                                                float verdiF;

                                                                                                                if (int.TryParse(flette, out verdi))
                                                                                                                {
                                                                                                                    p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                                                                }
                                                                                                                if (Single.TryParse(flette, out verdiS))
                                                                                                                {
                                                                                                                    p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                                                                }
                                                                                                                if (float.TryParse(flette, out verdiF))
                                                                                                                {
                                                                                                                    p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                                                                }

                                                                                                                p2.Text = flette;
                                                                                                                break;
                                                                                                            }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                catch (Exception ex)
                                                                                {
                                                                                }

                                                                            }
                                                                            else
                                                                            {
                                                                                doc.Replace("<<" + strKode + ">>", "", false, true);
                                                                            }

                                                                            drBB.Close();
                                                                            cmdBB.Dispose();
                                                                        }
                                                                        catch (Exception ex) { }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    doc.Replace("<<" + strKode + ">>", "", false, true);
                                                                }
                                                                break;
                                                            }

                                                        case 10:
                                                            {
                                                                TextSelection selection = doc.FindString("<<" + strKode + ">>", false, true);
                                                                if (selection != null)
                                                                {

                                                                    foreach (var f in arrFV)
                                                                        strSQL = strSQL.Replace("<RS." + f.Navn.ToUpper() + ">", f.Verdi);

                                                                    using (SqlConnection cnn = new SqlConnection(conString))
                                                                    {
                                                                        cnn.Open();
                                                                        try
                                                                        {
                                                                            SqlCommand cmdBB = cnn.CreateCommand();

                                                                            cmdBB.CommandType = CommandType.Text;
                                                                            cmdBB.CommandText = strSQL;
                                                                            SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);

                                                                            if (drBB.HasRows)
                                                                            {
                                                                                Spire.Doc.Fields.TextRange tr = selection.GetAsOneRange();
                                                                                var par = tr.OwnerParagraph;

                                                                                Spire.Doc.Fields.TextRange trH = selection.GetAsOneRange();
                                                                                Spire.Doc.Documents.Paragraph parH = tr.OwnerParagraph;

                                                                                Spire.Doc.Section? section = par.Owner.Owner as Spire.Doc.Section;
                                                                                int index = section.Body.ChildObjects.IndexOf(par);

                                                                                par.Text = "";

                                                                                string base64string = "";

                                                                                try
                                                                                {
                                                                                    {
                                                                                        var drFlette = drBB;
                                                                                        while (drFlette.Read())
                                                                                        {
                                                                                            base64string = drFlette.GetString(0);
                                                                                            byte[] img = Convert.FromBase64String(base64string);
                                                                                            MemoryStream ms = new MemoryStream(img);
                                                                                            Bitmap p = new Bitmap(ms);

                                                                                            Spire.Doc.Documents.Paragraph parIns = new(doc);
                                                                                            par.AppendPicture(p);

                                                                                        }
                                                                                    }
                                                                                }
                                                                                catch (Exception ex)
                                                                                {
                                                                                }

                                                                            }
                                                                            else
                                                                            {
                                                                                doc.Replace("<<" + strKode + ">>", "", false, true);
                                                                            }

                                                                            drBB.Close();
                                                                            cmdBB.Dispose();
                                                                        }
                                                                        catch (Exception ex) { }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    doc.Replace("<<" + strKode + ">>", "", false, true);
                                                                }
                                                                break;
                                                            }
                                                    }
                                                }
                                            }
                                        }
                                        drRapSQL.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.Print("Catch 1: " + ex.Message);
                                    }

                                    // Fletter inn formler
                                    strSQL = "SELECT FormelNavn, FormelTekst, FormelType, Antall FROM REPORT_FORMEL WHERE RapId='" + item.RapId + "'";
                                    try
                                    {
                                        if (cnnG63.State == ConnectionState.Closed)
                                            cnnG63.Open();
                                        SqlCommand cmdFormel = cnnG63.CreateCommand();
                                        cmdFormel.CommandType = CommandType.Text;
                                        cmdFormel.CommandText = strSQL;

                                        SqlDataReader drFormel = cmdFormel.ExecuteReader(CommandBehavior.CloseConnection);

                                        {
                                            while (drFormel.Read())
                                            {
                                                if (!drFormel.IsDBNull(drFormel.GetOrdinal("FormelNavn")))
                                                    strKode = drFormel.GetValue(drFormel.GetOrdinal("FormelNavn")).ToString();
                                                else
                                                    strKode = "";
                                                if (!drFormel.IsDBNull(drFormel.GetOrdinal("FormelType")))
                                                    intType = (int)drFormel.GetValue(drFormel.GetOrdinal("FormelType"));
                                                else
                                                    intType = 0;
                                                if (!drFormel.IsDBNull(drFormel.GetOrdinal("FormelTekst")))
                                                    strSQL = drFormel.GetString(drFormel.GetOrdinal("FormelTekst"));
                                                else
                                                    strSQL = "";
                                                if (!drFormel.IsDBNull(drFormel.GetOrdinal("Antall")))
                                                    intFormelAntall = (int)drFormel.GetValue(drFormel.GetOrdinal("Antall"));
                                                else
                                                    intFormelAntall = 10;
                                                if (intFormelAntall == 0)
                                                    intFormelAntall = 10;
                                                foreach (var var in item.Verdier)
                                                {
                                                    if (var.Kode.Length > 0 && var.Verdi.Length > 0)
                                                        strSQL = System.Text.RegularExpressions.Regex.Replace(strSQL, "#" + var.Kode.ToUpper() + "#", var.Verdi, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                                    else if (var.Kode.Length > 0 && var.Verdi.Length == 0)
                                                        strSQL = System.Text.RegularExpressions.Regex.Replace(strSQL, "#" + var.Kode.ToUpper() + "#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                                }

                                                {
                                                    if (drHovedSQL.HasRows)
                                                    {
                                                        for (i = 0; i <= drHovedSQL.FieldCount - 1; i++)
                                                        {
                                                            if (!drHovedSQL.IsDBNull(i))
                                                                strSQL = strSQL.Replace("<RS." + drHovedSQL.GetName(i).ToString().ToUpper() + ">", drHovedSQL.GetValue(i).ToString());
                                                        }
                                                    }
                                                }

                                                switch (intType)
                                                {
                                                    case 2 // FLETTER INN HOVEDTEKSTEN
                                                   :
                                                        {
                                                            try
                                                            {
                                                                if (cnnG6F.State == ConnectionState.Closed)
                                                                    cnnG6F.Open();
                                                                SqlCommand cmdF = cnnG6F.CreateCommand();
                                                                cmdF.CommandType = CommandType.Text;
                                                                cmdF.CommandText = strSQL;

                                                                SqlDataReader drF = cmdF.ExecuteReader(CommandBehavior.CloseConnection);
                                                                {
                                                                    var drFlette = drF;
                                                                    if (intType == 2)
                                                                    {
                                                                        if (drFlette.Read())
                                                                        {
                                                                            for (i = 0; i <= drFlette.FieldCount - 1; i++)
                                                                            {
                                                                                if (!drFlette.IsDBNull(i))
                                                                                    doc.Replace("<<" + strKode + ">>", drFlette.GetValue(i).ToString(), false, false);
                                                                                else
                                                                                    doc.Replace("<<" + strKode + ">>", "", false, false);
                                                                            }
                                                                        }
                                                                        else
                                                                            doc.Replace("<<" + strKode + ">>", "", false, false);
                                                                    }
                                                                }
                                                                drF.Close();
                                                                cmdF.Dispose();
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                            }

                                                            break;
                                                        }

                                                    case 3 // FLETTER INN HOVEDTEKSTEN
                                             :
                                                        {
                                                            try
                                                            {
                                                                if (cnnG6F.State == ConnectionState.Closed)
                                                                    cnnG6F.Open();
                                                                SqlCommand cmdF = cnnG6F.CreateCommand();
                                                                cmdF.CommandType = CommandType.Text;
                                                                cmdF.CommandText = strSQL;
                                                                string strVerdier = "";
                                                                SqlDataReader drF = cmdF.ExecuteReader(CommandBehavior.CloseConnection);
                                                                {
                                                                    var drFlette = drF;
                                                                    while (drFlette.Read())
                                                                    {
                                                                        if (!drFlette.IsDBNull(0))
                                                                            strVerdier += drFlette.GetValue(0) + ", ";
                                                                    }
                                                                }
                                                                drF.Close();
                                                                cmdF.Dispose();

                                                                if (strVerdier.Length > 0)
                                                                {
                                                                    int p1;
                                                                    p1 = strVerdier.LastIndexOf(",");
                                                                    strVerdier = strVerdier.Substring(0, p1);

                                                                    p1 = strVerdier.LastIndexOf(",");
                                                                    if (p1 >= 0)
                                                                        strVerdier = strVerdier.Substring(0, p1) + " og" + strVerdier.Substring(p1 + 1);
                                                                }

                                                                if (strVerdier.Length > 0)
                                                                    doc.Replace("<<" + strKode + ">>", strVerdier, false, false);
                                                                else
                                                                    doc.Replace("<<" + strKode + ">>", "", false, false);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                            }

                                                            break;
                                                        }

                                                    case 5:
                                                        {
                                                            try
                                                            {
                                                                if (cnnG6F.State == ConnectionState.Closed)
                                                                    cnnG6F.Open();
                                                                SqlCommand cmdF = cnnG6F.CreateCommand();
                                                                cmdF.CommandType = CommandType.Text;
                                                                cmdF.CommandText = strSQL;

                                                                SqlDataReader drF = cmdF.ExecuteReader(CommandBehavior.CloseConnection);
                                                                {
                                                                    var drFlette = drF;
                                                                    if (drFlette.Read())
                                                                    {
                                                                        if (!drFlette.IsDBNull(0))
                                                                            intVerdi = (int)drFlette.GetValue(0);
                                                                        else
                                                                            intVerdi = 0;
                                                                        for (i = 0; i <= intFormelAntall; i++)
                                                                        {
                                                                            if (i == intVerdi)
                                                                                doc.Replace("<<" + strKode + i + ">>", Strings.Chr(82).ToString(), false, false);
                                                                            else
                                                                                doc.Replace("<<" + strKode + i + ">>", Strings.Chr(163).ToString(), false, false);
                                                                        }
                                                                    }
                                                                    else
                                                                        doc.Replace("<<" + strKode + i + ">>", Strings.Chr(163).ToString(), false, false);
                                                                }
                                                                drF.Close();
                                                                cmdF.Dispose();
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                            }

                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.Print("Catch 2: " + ex.Message);
                                    }
                                }
                            }
                        }
                        drHovedSQL.Close();
                        cmdHovedSQL.Dispose();
                    }
                    catch (SqlException ex)
                    {
                    
                    }

                StandardVerdier:
                
                    if (item.Verdier != null)
                    {
                        foreach (var var in item.Verdier)
                        {
                            if (var.Kode.Length > 0 && var.Verdi != null && var.Verdi.Length > 0)
                                doc.Replace("<<" + var.Kode + ">>", var.Verdi, false, false);
                            else
                                doc.Replace("<<" + var.Kode + ">>", "", false, false);
                        }
                    }



                    if (cnnG6.State == ConnectionState.Open)
                        cnnG6.Close();
                    cnnG6.Dispose();

                    if (cnnG62.State == ConnectionState.Open)
                        cnnG62.Close();
                    cnnG62.Dispose();

                    if (cnnG63.State == ConnectionState.Open)
                        cnnG63.Close();
                    cnnG63.Dispose();

                    MemoryStream saveStream = new MemoryStream();
                    //if (DocType.ToUpper() == "PDF")
                    //    Document.SaveToStream(saveStream, Spire.Doc.FileFormat.PDF);
                    //else
                    doc.SaveToStream(saveStream, Spire.Doc.FileFormat.Docx);
                    strBase64Dokument = Convert.ToBase64String(saveStream.ToArray());
                }

            }

            Retur.Base64String = strBase64Dokument;

            string output = JsonConvert.SerializeObject(Retur);

            return output;
        }

        [Route("CreateSpireDocPreview")]
        [HttpPost]
        public string CreateSpireDocPreview(ReportPreview item)
        {
            ReportPreviewItem Retur = new();

            string strBase64Dokument = "";

            string conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            byte[] MyDoc = Convert.FromBase64String(item.base64String);

            item.logonInfo.Parameters.field = item.RapId;
            List<SQLVerdierItem> arrSQLVerdier = GetSQLInformasjonInternal(item.logonInfo);

            MemoryStream stream = new MemoryStream(MyDoc);

            //Spire.License.LicenseProvider.SetLicenseKey("C:\\temp\\license.elic.xml");
            Spire.Doc.Document doc = new Spire.Doc.Document(stream);
            Spire.Doc.Section s = doc.Sections[0];

            TextSelection selImage = doc.FindString("<<ImageShip>>", false, true);

            if (selImage != null && item.logonInfo.Parameters.fieldValue != null)
            {
                Spire.Doc.Fields.TextRange trI = selImage.GetAsOneRange();
                var par = trI.OwnerParagraph;

                Spire.Doc.Section? section = par.Owner.Owner as Spire.Doc.Section;
                int index = section.Body.ChildObjects.IndexOf(par);

                par.Text = "";

                ShipController sc = new ShipController();

                string base64string = sc.GetShipPicture(conString, item.logonInfo.Parameters.fieldValue);
                byte[] img = Convert.FromBase64String(base64string);
                MemoryStream ms = new MemoryStream(img);
                Bitmap p = new Bitmap(ms);

                DocPicture pic = par.AppendPicture(p);
            }

            foreach (var v in arrSQLVerdier)
                {


                    string strKode = "";
                    int i = 0;
                    List<VarTypeItem> arrFV = new List<VarTypeItem>();

                    if (v.Type == "Boolean") {
                        if (v.Verdi == "true") {
                            doc.Replace("<<" + v.FeltNavn + "J>>", Strings.Chr(82).ToString(), false, false);
                            doc.Replace("<<" + v.FeltNavn + "J>>", Strings.Chr(82).ToString(), false, false);
                            doc.Replace("<<" + v.FeltNavn + "N>>", Strings.Chr(163).ToString(), false, false);
                            }
                        else {
                            doc.Replace("<<" + v.FeltNavn + "N>>", Strings.Chr(82).ToString(), false, false);
                            doc.Replace("<<" + v.FeltNavn + "J>>", Strings.Chr(163).ToString(), false, false);
                            }
                        }
                    else if (v.Type == "Blokk") {

                        TextSelection selection = doc.FindString("<<" + v.FeltNavn + ">>", false, true);
                        if (selection != null)
                        {

                            using (SqlConnection cnn = new SqlConnection(conString))
                            {
                                cnn.Open();
                                try
                                {
                                    SqlCommand cmdBB = cnn.CreateCommand();

                                    cmdBB.CommandType = CommandType.Text;
                                    cmdBB.CommandText = v.Verdi;
                                    SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);

                                    if (drBB.HasRows)
                                    {
                                        Spire.Doc.Fields.TextRange tr = selection.GetAsOneRange();
                                        var par = tr.OwnerParagraph;
                                        Spire.Doc.Table table;
                                        bool removeFirstRow = false;
                                        if (par.IsInCell)
                                        {
                                            table = null;
                                            foreach (Spire.Doc.Table t in s.Tables)
                                            {
                                                if (t.Rows.Count == 1 && t.Rows[0].Cells[0].Paragraphs[0].Text.ToUpper().Trim() == "<<" + v.FeltNavn.ToUpper() + ">>")
                                                {
                                                    table = t;
                                                    table.ResetCells(1, drBB.FieldCount);
                                                    break;
                                                }
                                                else if (t.Rows.Count >= 2 && t.Rows[1].Cells[0].Paragraphs[0].Text.ToUpper().Trim() == "<<" + v.FeltNavn.ToUpper() + ">>")
                                                {
                                                    table = t;
                                                    //table.Rows.RemoveAt(1);
                                                    removeFirstRow = true;
                                                    break;
                                                }
                                            }

                                            if (table != null)
                                            {
                                                try
                                                {
                                                    {
                                                        var drFlette = drBB;
                                                        while (drFlette.Read())
                                                        {
                                                            Spire.Doc.TableRow DataRow = table.AddRow();
                                                            //DataRow.RowFormat.Borders.Bottom.BorderType = Spire.Doc.Documents.BorderStyle.Cleared;
                                                            //DataRow.RowFormat.Borders.Top.BorderType = Spire.Doc.Documents.BorderStyle.Cleared;
                                                            //DataRow.RowFormat.Borders.Top.ClearFormatting();
                                                            //DataRow.RowFormat.Borders.Bottom.ClearFormatting();

                                                            for (i = 0; i <= drFlette.FieldCount - 1; i++)
                                                            {
                                                                Spire.Doc.Documents.Paragraph p2 = DataRow.Cells[i].AddParagraph();
       
                                                                if (!drFlette.IsDBNull(i))
                                                                {
                                                                    switch (drBB.GetDataTypeName(i).ToUpper())
                                                                    {
                                                                        case "INT":
                                                                        case "INTEGER":
                                                                            {
                                                                                p2.Text = drFlette.GetValue(i).ToString();
                                                                                p2.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                                                                                break;
                                                                            }

                                                                        case "FLOAT":
                                                                        case "DOUBLE":
                                                                        case "DECIMAL":
                                                                            {
                                                                                p2.Text = drFlette.GetValue(i).ToString();
                                                                                p2.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                                                                                break;
                                                                            }

                                                                        default:
                                                                            {
                                                                                p2.Text = drFlette.GetValue(i).ToString();
                                                                                break;
                                                                            }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                }
                                                
                                            if (removeFirstRow) table.Rows.RemoveAt(1);
                                        }
                                        }
                                        else
                                        {
                                            table = s.AddTable(true);
                                            table.ResetCells(1, drBB.FieldCount);
                                            Spire.Doc.TableRow fRow = table.Rows[0];

                                            try
                                            {
                                                {
                                                    var drFlette = drBB;
                                                    while (drFlette.Read())
                                                    {
                                                        Spire.Doc.TableRow DataRow = table.AddRow();

                                                        for (i = 0; i <= drFlette.FieldCount - 1; i++)
                                                        {
                                                            Spire.Doc.Documents.Paragraph p2 = DataRow.Cells[i].AddParagraph();


                                                            if (!drFlette.IsDBNull(i))
                                                            {
                                                                switch (drBB.GetDataTypeName(i).ToUpper())
                                                                {
                                                                    case "INT":
                                                                    case "INTEGER":
                                                                        {
                                                                            p2.Text = drFlette.GetValue(i).ToString();
                                                                            break;
                                                                        }

                                                                    case "FLOAT":
                                                                    case "DOUBLE":
                                                                    case "DECIMAL":
                                                                        {
                                                                            p2.Text = drFlette.GetValue(i).ToString();
                                                                            break;
                                                                        }

                                                                    default:
                                                                        {                                                                        
                                                                            p2.Text = drFlette.GetValue(i).ToString();
                                                                            if (int.TryParse(p2.Text, out i))
                                                                        {
                                                                            p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                        }
                                                                            break;
                                                                        }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                        }

                                        //if (selection != null)
                                        //{
                                        //    Spire.Doc.Fields.TextRange range = selection.GetAsOneRange();
                                        //    Spire.Doc.Documents.Paragraph paragraph = range.OwnerParagraph;
                                        //    Spire.Doc.Body body = paragraph.OwnerTextBody;
                                        //    int index = body.ChildObjects.IndexOf(paragraph);

                                        //    body.ChildObjects.Remove(paragraph);
                                        //    body.ChildObjects.Insert(index, table);
                                        //}
                                    }
                                    else
                                    {
                                        doc.Replace("<<" + strKode + ">>", "", false, true);
                                    }

                                    drBB.Close();
                                    cmdBB.Dispose();
                                }
                                catch (Exception ex) { }
                            }
                        }
                        else
                        {
                            doc.Replace("<<" + v.FeltNavn + ">>", "", false, true);
                        }
                        }
                    else if (v.Type == "BlokkListeA")
                    {

                        TextSelection selection = doc.FindString("<<" + v.FeltNavn + ">>", false, true);
                        if (selection != null)
                        {

                            using (SqlConnection cnn = new SqlConnection(conString))
                            {
                                cnn.Open();
                                try
                                {
                                    SqlCommand cmdBB = cnn.CreateCommand();

                                    cmdBB.CommandType = CommandType.Text;
                                    cmdBB.CommandText = v.Verdi;
                                    SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);

                                    if (drBB.HasRows)
                                    {
                                        Spire.Doc.Fields.TextRange tr = selection.GetAsOneRange();
                                        Spire.Doc.Documents.Paragraph par = tr.OwnerParagraph;

                                        Spire.Doc.Section? section = par.Owner.Owner as Spire.Doc.Section;
                                        int index = section.Body.ChildObjects.IndexOf(par);
                                    
                                        par.Text = "";

                                        try {
                                            var drFlette = drBB;
                                            while (drFlette.Read())
                                            {

                                                for (i = 0; i <= drFlette.FieldCount - 1; i++)
                                                {
                                                    //Spire.Doc.Documents.Paragraph p2 = par. s.AddParagraph();

                                                    if (!drFlette.IsDBNull(i))
                                                    {
                                                        switch (drBB.GetDataTypeName(i).ToUpper())
                                                        {
                                                            case "INT":
                                                            case "INTEGER":
                                                                {
                                                                    par.AppendText(drFlette.GetValue(i).ToString());
                                                                            
                                                                    break;
                                                                }

                                                            case "FLOAT":
                                                            case "DOUBLE":
                                                            case "DECIMAL":
                                                                {
                                                                    //p2.Text = drFlette.GetValue(i).ToString();
                                                                    //p2.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                                                                    break;
                                                                }

                                                            default:
                                                                {
                                                                    Spire.Doc.Documents.Paragraph parIns = new(doc);
                                                                    parIns.AppendText(drFlette.GetValue(i).ToString());
                                                                    parIns.ApplyStyle("List abc");
                                                                    doc.Sections[0].Paragraphs.Insert(index, parIns);
                                                                    index++;
                                                                    //par.AppendText(drFlette.GetValue(i).ToString() + System.Environment.NewLine);
                                                                
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                            }

                                    
                                
                                    }
                                    else
                                    {
                                        doc.Replace("<<" + strKode + ">>", "", false, true);
                                    }

                                    drBB.Close();
                                    cmdBB.Dispose();
                                }
                                catch (Exception ex) { }
                            }
                        }
                        else
                        {
                            doc.Replace("<<" + v.FeltNavn + ">>", "", false, true);
                        }
                    }
                    else if (v.Type == "BlokkHeader")
                    {

                        TextSelection selection = doc.FindString("<<" + v.FeltNavn + ">>", false, true);
                        if (selection != null)
                        {

                            using (SqlConnection cnn = new SqlConnection(conString))
                            {
                                cnn.Open();
                                try
                                {
                                    SqlCommand cmdBB = cnn.CreateCommand();

                                    cmdBB.CommandType = CommandType.Text;
                                    cmdBB.CommandText = v.Verdi;
                                    SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);

                                    if (drBB.HasRows)
                                    {
                                        Spire.Doc.Fields.TextRange tr = selection.GetAsOneRange();
                                        var par = tr.OwnerParagraph;
                                    
                                        Spire.Doc.Fields.TextRange trH = selection.GetAsOneRange();
                                        Spire.Doc.Documents.Paragraph parH = tr.OwnerParagraph;

                                        Spire.Doc.Section? section = par.Owner.Owner as Spire.Doc.Section;
                                        int index = section.Body.ChildObjects.IndexOf(par);

                                        Spire.Doc.Table tableH = null;

                                        par.Text = "";

                                        string oldHeader = "";

                                        try
                                        {
                                            {
                                                var drFlette = drBB;
                                                while (drFlette.Read())
                                                {
                                                    if (oldHeader != drFlette.GetValue(0).ToString())
                                                    {
                                                        Spire.Doc.Documents.Paragraph parIns = new(doc);
                                                        parIns.AppendText(drFlette.GetValue(0).ToString());
                                                        parIns.ApplyStyle("Heading 2");
                                                        doc.Sections[0].Paragraphs.Insert(index, parIns);

                                                        oldHeader = drFlette.GetValue(0).ToString();

                                                        tableH = new Spire.Doc.Table(doc, true);
                                                        PreferredWidth width = new PreferredWidth(WidthType.Percentage, 100);
                                                        tableH.PreferredWidth = width;
                                                        par.Owner.ChildObjects.Insert(index + 1, tableH);
                                                        tableH.ResetCells(1, drBB.FieldCount - 1);
                                                        Spire.Doc.TableRow fRow = tableH.Rows[0];
                                                        fRow.IsHeader = true;
                                                    

                                                        for (i = 1; i <= drFlette.FieldCount - 1; i++)
                                                        {
                                                            Spire.Doc.Documents.Paragraph p2 = fRow.Cells[i - 1].AddParagraph();
                                                            p2.Text = drFlette.GetName(i);
                                                            if (p2.Text == "NoHeader") { p2.Text = ""; }
                                                            if (i == 1) { fRow.Cells[i - 1].SetCellWidth(500, Spire.Doc.CellWidthType.Point); }
                                                            if (i == 2) { fRow.Cells[i - 1].SetCellWidth(150, Spire.Doc.CellWidthType.Point); }
                                                            if (i == 3) { fRow.Cells[i - 1].SetCellWidth(50, Spire.Doc.CellWidthType.Point); }
                                                        }

                                                    }

                                                    Spire.Doc.TableRow DataRow = tableH.AddRow();

                                                    for (i = 1; i <= drFlette.FieldCount - 1; i++)
                                                    {
                                                        Spire.Doc.Documents.Paragraph p2 = DataRow.Cells[i - 1].AddParagraph();


                                                        if (!drFlette.IsDBNull(i))
                                                        {
                                                            switch (drBB.GetDataTypeName(i).ToUpper())
                                                            {
                                                                case "INT":
                                                                case "INTEGER":
                                                                    {
                                                                        p2.Text = drFlette.GetValue(i).ToString();
                                                                        break;
                                                                    }

                                                                case "FLOAT":
                                                                case "DOUBLE":
                                                                case "DECIMAL":
                                                                    {
                                                                        p2.Text = drFlette.GetValue(i).ToString();
                                                                        p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                        break;
                                                                    }

                                                                default:
                                                                    {
                                                                        string flette = drFlette.GetValue(i).ToString();
                                                                        int verdi;
                                                                        Single verdiS;
                                                                        float verdiF;
                                                                        if (int.TryParse(flette, out verdi))
                                                                        {
                                                                            p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                        }
                                                                        if (Single.TryParse(flette, out verdiS))
                                                                        {
                                                                            p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                        }
                                                                        if (float.TryParse(flette, out verdiF))
                                                                        {
                                                                            p2.Format.HorizontalAlignment = HorizontalAlignment.Right;
                                                                        }
                                                                        p2.Text = flette;
                                                                    break;
                                                                    }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }

                                    }
                                    else
                                    {
                                        doc.Replace("<<" + strKode + ">>", "", false, true);
                                    }

                                    drBB.Close();
                                    cmdBB.Dispose();
                                }
                                catch (Exception ex) { }
                            }
                        }
                        else
                        {
                            doc.Replace("<<" + v.FeltNavn + ">>", "", false, true);
                        }
                    }
                    else if (v.Type == "BlokkImage")
                    {

                        TextSelection selection = doc.FindString("<<" + v.FeltNavn + ">>", false, true);
                        if (selection != null)
                        {

                            using (SqlConnection cnn = new SqlConnection(conString))
                            {
                                cnn.Open();
                                try
                                {
                                    SqlCommand cmdBB = cnn.CreateCommand();

                                    cmdBB.CommandType = CommandType.Text;
                                    cmdBB.CommandText = v.Verdi;
                                    SqlDataReader drBB = cmdBB.ExecuteReader(CommandBehavior.CloseConnection);

                                    if (drBB.HasRows)
                                    {
                                        Spire.Doc.Fields.TextRange tr = selection.GetAsOneRange();
                                        var par = tr.OwnerParagraph;

                                        Spire.Doc.Fields.TextRange trH = selection.GetAsOneRange();
                                        Spire.Doc.Documents.Paragraph parH = tr.OwnerParagraph;

                                        Spire.Doc.Section? section = par.Owner.Owner as Spire.Doc.Section;
                                        int index = section.Body.ChildObjects.IndexOf(par);

                                        par.Text = "";

                                        string base64string = "";

                                        try
                                        {
                                            {
                                                var drFlette = drBB;
                                                while (drFlette.Read())
                                                {
                                                    base64string = drFlette.GetString(0);
                                                    byte[] img = Convert.FromBase64String(base64string);
                                                    MemoryStream ms = new MemoryStream(img);
                                                    Bitmap p = new Bitmap(ms);

                                                    Spire.Doc.Documents.Paragraph parIns = new(doc);
                                                    par.AppendPicture(p);

                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }

                                    }
                                    else
                                    {
                                        doc.Replace("<<" + strKode + ">>", "", false, true);
                                    }

                                    drBB.Close();
                                    cmdBB.Dispose();
                                }
                                catch (Exception ex) { }
                            }
                        }
                        else
                        {
                            doc.Replace("<<" + v.FeltNavn + ">>", "", false, true);
                        }
                    }
                    else
                    {
                        doc.Replace("<<" + v.FeltNavn + ">>", v.Verdi, false, false);
                        }

                    }
            
            MemoryStream saveStream = new MemoryStream();
                    //if (DocType.ToUpper() == "PDF")
                    //    Document.SaveToStream(saveStream, Spire.Doc.FileFormat.PDF);
                    //else
                    doc.SaveToStream(saveStream, Spire.Doc.FileFormat.PDF);
                    strBase64Dokument = Convert.ToBase64String(saveStream.ToArray());

            Retur.Base64String = strBase64Dokument;

            string output = JsonConvert.SerializeObject(Retur);

            return output;
        }

        [Route("ClearImage")]
        [HttpPost]
        public string ClearImage(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            ReturnValueItem retur = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            string sql = "DELETE FROM tmpImage";
            retur.Success = ExecuteSQL(conString, sql);

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("SetImage")]
        [HttpPost]
        public string SetImage(ReportImageItem item)
        {
            string conString;
            string strBase64Dokument = "";

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            string sql = "";
            sql = "INSERT INTO tmpImage(UserGuid, Id, ProfilGuid, Profile, Tittel, [Image]) VALUES('" + item.logonInfo.UserId + "','ChartImage','" + item.ProfilGuid + "','" + item.Profile + "','" + item.Tittel + "','" + item.Image + "')";
            ExecuteSQL(conString, sql);

            return strBase64Dokument;
        }
        #endregion

        #region Funksjoner

        private string ImageToBase64String(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                image.Save(memStream, imageFormat);
                string result = Convert.ToBase64String(memStream.ToArray());
                memStream.Close();
                return result;
            }
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


        private int ReadValue(AccountLogOnInfoItem logonInfo, string sql, int standard)
        {
            int retur = standard;

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
                        if (!rdr.IsDBNull(0)) retur = (int)rdr.GetValue(0);
                    }
                }
                catch (SqlException ex)
                {
                    var st = new StackTrace(ex, true);
                }

            }

            return retur;
        }


        private bool ExecuteSQL(string conString, string sql)
        {
            using (SqlConnection cnnG6 = new SqlConnection(conString))
            {
                cnnG6.Open();

                if (cnnG6.State == ConnectionState.Open)
                    cnnG6.Close();

                cnnG6.Open();
                SqlTransaction transaction;
                transaction = cnnG6.BeginTransaction("SampleTransaction");

                SqlCommand cmdExecute = cnnG6.CreateCommand();
                cmdExecute.Transaction = transaction;
                cmdExecute.CommandType = CommandType.Text;
                cmdExecute.CommandTimeout = 600;

                try
                {
                    cmdExecute.CommandText = sql;
                    cmdExecute.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException exp)
                {
                    transaction.Rollback();
                    return false;
                }
                finally
                {
                    cmdExecute.Dispose();
                }

                if (cnnG6.State == ConnectionState.Open)
                    cnnG6.Close();

            }
            return true;
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

        private void CsqlUD(ref string SQLQ, string strField, string strType, DateTime dtValue, DateTime? dtOldValue)
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
            strWhere = SQLQ.Substring(p1 - 1);
            strNewSQL = SQLQ.Substring(0, p1 - 1);

            switch (strType)
            {
                case "D":
                    {
                        if (dtValue.Year > 1800)
                            sqlData = "," + strField + "='" + dtValue.ToString("yyyy-MM-dd") + "T00:00:00' ";
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

            strNewSQL = string.Concat(strNewSQL, sqlData, strWhere);
            SQLQ = strNewSQL;
        }

        #endregion

    }

}


class ReportConnectionStringManager
{
    private readonly string connectionString;

    public ReportConnectionStringManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Telerik.Reporting.ReportSource UpdateReportSource(Telerik.Reporting.ReportSource sourceReportSource)
    {
        if (sourceReportSource is Telerik.Reporting.UriReportSource)
        {
            var uriReportSource = (Telerik.Reporting.UriReportSource)sourceReportSource;
            // unpackage TRDP report
            // http://docs.telerik.com/reporting/report-packaging-trdp#unpackaging
            var reportInstance = UnpackageReport(uriReportSource);
            // or deserialize TRDX report(legacy format)
            // http://docs.telerik.com/reporting/programmatic-xml-serialization#deserialize-report-definition-from-xml-file
            // var reportInstance = DeserializeReport(uriReportSource);
            ValidateReportSource(uriReportSource.Uri);
            this.SetConnectionString(reportInstance);
            return CreateInstanceReportSource(reportInstance, uriReportSource);
        }

        if (sourceReportSource is Telerik.Reporting.XmlReportSource)
        {
            var xml = (Telerik.Reporting.XmlReportSource)sourceReportSource;
            ValidateReportSource(xml.Xml);
            var reportInstance = this.DeserializeReport(xml);
            this.SetConnectionString(reportInstance);
            return CreateInstanceReportSource(reportInstance, xml);
        }

        if (sourceReportSource is Telerik.Reporting.InstanceReportSource)
        {
            var instanceReportSource = (Telerik.Reporting.InstanceReportSource)sourceReportSource;
            this.SetConnectionString((Telerik.Reporting.ReportItemBase)instanceReportSource.ReportDocument);
            return instanceReportSource;
        }

        if (sourceReportSource is Telerik.Reporting.TypeReportSource)
        {
            var typeReportSource = (Telerik.Reporting.TypeReportSource)sourceReportSource;
            var typeName = typeReportSource.TypeName;
            ValidateReportSource(typeName);
            var reportType = Type.GetType(typeName);
            var reportInstance = (Telerik.Reporting.Report)Activator.CreateInstance(reportType);
            this.SetConnectionString((Telerik.Reporting.ReportItemBase)reportInstance);
            return CreateInstanceReportSource(reportInstance, typeReportSource);
        }

        throw new NotImplementedException("Handler for the used ReportSource type is not implemented.");
    }

    private Telerik.Reporting.ReportSource CreateInstanceReportSource(Telerik.Reporting.IReportDocument report, Telerik.Reporting.ReportSource originalReportSource)
    {
        var instanceReportSource = new Telerik.Reporting.InstanceReportSource()
        {
            ReportDocument = report
        };
        instanceReportSource.Parameters.AddRange(originalReportSource.Parameters);
        return instanceReportSource;
    }

    public void ValidateReportSource(string value)
    {
        if (value.Trim().StartsWith("="))
            throw new InvalidOperationException("Expressions for ReportSource are not supported when changing the connection string dynamically");
    }

    private Telerik.Reporting.Report UnpackageReport(Telerik.Reporting.UriReportSource uriReportSource)
    {
        var reportPackager = new Telerik.Reporting.ReportPackager();
        using (var sourceStream = System.IO.File.OpenRead(uriReportSource.Uri))
        {
            var report = (Telerik.Reporting.Report)reportPackager.UnpackageDocument(sourceStream);
            return report;
        }
    }

    public Telerik.Reporting.Report DeserializeReport(Telerik.Reporting.UriReportSource uriReportSource)
    {
        var settings = new System.Xml.XmlReaderSettings();
        settings.IgnoreWhitespace = true;
        using (var xmlReader = System.Xml.XmlReader.Create(uriReportSource.Uri, settings))
        {
            var xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
            var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);
            return report;
        }
    }

    public Telerik.Reporting.Report DeserializeReport(Telerik.Reporting.XmlReportSource xmlReportSource)
    {
        var settings = new System.Xml.XmlReaderSettings();
        settings.IgnoreWhitespace = true;
        var textReader = new System.IO.StringReader(xmlReportSource.Xml);
        using (var xmlReader = System.Xml.XmlReader.Create(textReader, settings))
        {
            var xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
            var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);
            return report;
        }
    }

    public void SetConnectionString(Telerik.Reporting.ReportItemBase reportItemBase)
    {
        if (reportItemBase.Items.Count < 1)
            return;

        if (reportItemBase is Telerik.Reporting.Report)
        {
            var report = (Telerik.Reporting.Report)reportItemBase;

            if (report.DataSource is Telerik.Reporting.SqlDataSource)
            {
                var sqlDataSource = (Telerik.Reporting.SqlDataSource)report.DataSource;
                sqlDataSource.ConnectionString = connectionString;
            }
            foreach (Telerik.Reporting.ReportParameter parameter in report.ReportParameters)
            {
                if (parameter.AvailableValues.DataSource is Telerik.Reporting.SqlDataSource)
                {
                    var sqlDataSource = (Telerik.Reporting.SqlDataSource)parameter.AvailableValues.DataSource;
                    sqlDataSource.ConnectionString = connectionString;
                }
            }
        }

        foreach (Telerik.Reporting.ReportItemBase item in reportItemBase.Items)
        {
            // recursively set the connection string to the items from the Items collection
            SetConnectionString(item);

            // set the drillthrough report connection strings
            var drillThroughAction = item.Action as Telerik.Reporting.NavigateToReportAction;
            if (drillThroughAction != null)
            {
                var updatedReportInstance = this.UpdateReportSource(drillThroughAction.ReportSource);
                drillThroughAction.ReportSource = updatedReportInstance;
            }

            if (item is Telerik.Reporting.SubReport)
            {
                var subReport = (Telerik.Reporting.SubReport)item;
                subReport.ReportSource = this.UpdateReportSource(subReport.ReportSource);
                continue;
            }

            // Covers all data items(Crosstab, Table, List, Graph, Map and Chart)
            if (item is Telerik.Reporting.DataItem)
            {
                var dataItem = (Telerik.Reporting.DataItem)item;
                if (dataItem.DataSource is Telerik.Reporting.SqlDataSource)
                {
                    var sqlDataSource = (Telerik.Reporting.SqlDataSource)dataItem.DataSource;
                    sqlDataSource.ConnectionString = connectionString;
                    continue;
                }
            }
        }
    }
}