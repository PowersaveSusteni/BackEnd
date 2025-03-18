using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Web;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;
using Microsoft.VisualStudio.Services.GroupLicensingRule;
using OtpNet;
using static SQLite.SQLite3;


public class HelpDeskItem
{
    public string? HelpDeskGuid { get; set; }
    public int TiketId { get; set; } = 0;
    public int Program { get; set; } = 0;
    public string? Modul { get; set; }
    public string? Skjermbilde { get; set; }
    public DateTime? OpprettetDato { get; set; }
    public string? OpprettetAv { get; set; }
    public string? OpprettetDatoTekst { get; set; }
    public int Prioritet { get; set; } = 0;
    public string Tittel { get; set; } = "";
    public string? Beskrivelse { get; set; }
    public string? Losning { get; set; }
    public string? BrukerId { get; set; }
    public string? BrukerNavn { get; set; }
    public string? Fellesraad { get; set; }
    public string? Kunde { get; set; }
    public DateTime? StartDato { get; set; }
    public DateTime? Ferdig { get; set; }
    public DateTime? Aksept { get; set; }
    public string? FerdigDatoTekst { get; set; }
    public int Status { get; set; } = 0;
    public string? StatusTekst { get; set; }
    public string? Farge { get; set; }
    public bool bold { get; set; } = false;
    public int TypeId { get; set; } = 1;
    public string? TypeNavn { get; set; }
    public string? Program_GUID { get; set; }
    public string? Saksbehandler { get; set; }
    public string? ePostAdresse { get; set; }
    public string? KommentarKunde { get; set; }
    public int Stjerner { get; set; } = 0;
    public int Fremdrift { get; set; } = 0;
    public string? ikon { get; set; }
    public bool inklBilde { get; set; }
    public string? ikonLogg { get; set; }
    public string? byte64String { get; set; }
    public string? LinkGuid { get; set; }
    public string? Tabell { get; set; }
    public string? PubBeskrivelse { get; set; }
    public bool Publiser { get; set; }
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class HelpDeskUtvidetListeItem
{
    public string? HelpDeskGuid { get; set; }
    public int TiketId { get; set; } = 0;
    public string ProgramNavn { get; set; } = "";
    public string Modul { get; set; } = "";
    public string Skjermbilde { get; set; } = "";
    public int Prioritet { get; set; } = 0;
    public string Tittel { get; set; } = "";
    public string BrukerId { get; set; } = "";
    public string Fellesraad { get; set; } = "";
    public DateTime? StartDato { get; set; }
    public DateTime? Ferdig { get; set; }
    public DateTime? Aksept { get; set; }
    public int Status { get; set; } = 0;
    public int TypeId { get; set; } = 0;
    public string ePostAdresse { get; set; } = "";
    public string KommentarKunde { get; set; } = "";
    public int Stjerner { get; set; } = 0;
    public int Fremdrift { get; set; } = 0;
    public string LinkGuid { get; set; } = "";
    public string Tabell { get; set; } = "";
    public string Saksbehandler { get; set; } = "";
    public string Kunde { get; set; } = "";
    public string Bruker { get; set; } = "";
    public string StatusNavn { get; set; } = "";
    public string TypeNavn { get; set; } = "";
}

public class HelpDeskBildeItem
{
    public string? HelpDeskBildeGuid { get; set; }
    public string HelpDeskGuid { get; set; } = "";
    public string Bilde { get; set; } = "";
    public string? Kommentar { get; set; } = "";
    public int? TypeBilde { get; set; } = 0;
    public ErrorItem? Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class HelpDeskLoggItem
{
    public string? HelpDeskLoggGuid { get; set; }
    public string HelpDeskGuid { get; set; } = "";
    public DateTime Tidspunkt { get; set; }
    public string Kommentar { get; set; } = "";
    public string BrukerId { get; set; } = "";
    public int Type { get; set; } = 0;
    public bool Publiser { get; set; } = false;
    public bool BrukerLest { get; set; } = false;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class HelpDeskProgramItem
{
    public int Id { get; set; }
    public string ProgramNavn { get; set; } = "";
    public int Sortering { get; set; } = 0;
}

public class HelpDeskStatusItem
{
    public int Id { get; set; }
    public string StatusNavn { get; set; } = "";
    public int Sortering { get; set; }
}

public class HelpDeskTypeItem
{
    public int Id { get; set; }
    public string TypeNavn { get; set; } = "";
    public int Sortering { get; set; }
}

public class HelpdeskStatistikkItem
{
    public string Tittel { get; set; } = "";
    public string SubTittel { get; set; } = "";
    public int Antall { get; set; }

}


namespace SusteniWebServices.Controllers
{


    [Route("/[controller]")]
    [ApiController]


    public class HelpdeskController : ControllerBase
    {


        #region Helpdesk

        [Route("GetHelpDeskListe")]
        [HttpPost]
        public string GetHelpDeskListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT HelpDeskGuid, TiketId, Program, Modul, Skjermbilde, OpprettetDato, OpprettetAv, Prioritet, Tittel, Beskrivelse, Losning, BrukerId, Fellesraad, StartDato, Ferdig, Aksept, Status, TypeId, Program_GUID, Saksbehandler, ePostAdresse, KommentarKunde, Stjerner, Fremdrift, LinkGuid, Tabell, EndretDato, EndretAv, Publiser, PubBeskrivelse FROM HelpDesk";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<HelpDeskItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        HelpDeskItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskGuid"))) { item.HelpDeskGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TiketId"))) { item.TiketId = rdr.GetInt32(rdr.GetOrdinal("TiketId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Program"))) { item.Program = rdr.GetInt16(rdr.GetOrdinal("Program")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Modul"))) { item.Modul = rdr.GetString(rdr.GetOrdinal("Modul")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Skjermbilde"))) { item.Skjermbilde = rdr.GetString(rdr.GetOrdinal("Skjermbilde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDato"))) { item.OpprettetDato = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Prioritet"))) { item.Prioritet = (int)rdr.GetInt16(rdr.GetOrdinal("Prioritet")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tittel"))) { item.Tittel = rdr.GetString(rdr.GetOrdinal("Tittel")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Beskrivelse"))) { item.Beskrivelse = rdr.GetString(rdr.GetOrdinal("Beskrivelse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Losning"))) { item.Losning = rdr.GetString(rdr.GetOrdinal("Losning")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BrukerId"))) { item.BrukerId = rdr.GetString(rdr.GetOrdinal("BrukerId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Fellesraad"))) { item.Fellesraad = rdr.GetString(rdr.GetOrdinal("Fellesraad")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("StartDato"))) { item.StartDato = rdr.GetDateTime(rdr.GetOrdinal("StartDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Ferdig"))) { item.Ferdig = rdr.GetDateTime(rdr.GetOrdinal("Ferdig")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Aksept"))) { item.Aksept = rdr.GetDateTime(rdr.GetOrdinal("Aksept")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Status"))) { item.Status = (int)rdr.GetInt16(rdr.GetOrdinal("Status")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeId"))) { item.TypeId = (int)rdr.GetInt32(rdr.GetOrdinal("TypeId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Program_GUID"))) { item.Program_GUID = rdr.GetString(rdr.GetOrdinal("Program_GUID")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Saksbehandler"))) { item.Saksbehandler = rdr.GetString(rdr.GetOrdinal("Saksbehandler")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ePostAdresse"))) { item.ePostAdresse = rdr.GetString(rdr.GetOrdinal("ePostAdresse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KommentarKunde"))) { item.KommentarKunde = rdr.GetString(rdr.GetOrdinal("KommentarKunde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Stjerner"))) { item.Stjerner = (int)rdr.GetInt16(rdr.GetOrdinal("Stjerner")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Fremdrift"))) { item.Fremdrift = (int)rdr.GetInt16(rdr.GetOrdinal("Fremdrift")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LinkGuid"))) { item.LinkGuid = rdr.GetString(rdr.GetOrdinal("LinkGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tabell"))) { item.Tabell = rdr.GetString(rdr.GetOrdinal("Tabell")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Publiser"))) { item.Publiser = rdr.GetBoolean(rdr.GetOrdinal("Publiser")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PubBeskrivelse"))) { item.PubBeskrivelse = rdr.GetString(rdr.GetOrdinal("PubBeskrivelse")); }
                        if (item.Ferdig != null)
                        {
                            item.Farge = "Green";
                        }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetHelpDesk")]
        [HttpPost]
        public string GetHelpDesk(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT HelpDeskGuid, TiketId, Program, Modul, Skjermbilde, OpprettetDato, OpprettetAv, Prioritet, Tittel, Beskrivelse, Losning, BrukerId, Fellesraad, StartDato, Ferdig, Aksept, Status, TypeId, Program_GUID, Saksbehandler, ePostAdresse, KommentarKunde, Stjerner, Fremdrift, LinkGuid, Tabell, EndretDato, EndretAv, Publiser, PubBeskrivelse FROM HelpDesk";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            HelpDeskItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskGuid"))) { item.HelpDeskGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TiketId"))) { item.TiketId = rdr.GetInt32(rdr.GetOrdinal("TiketId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Program"))) { item.Program = rdr.GetInt16(rdr.GetOrdinal("Program")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Modul"))) { item.Modul = rdr.GetString(rdr.GetOrdinal("Modul")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Skjermbilde"))) { item.Skjermbilde = rdr.GetString(rdr.GetOrdinal("Skjermbilde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDato"))) { item.OpprettetDato = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Prioritet"))) { item.Prioritet = (int)rdr.GetInt16(rdr.GetOrdinal("Prioritet")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tittel"))) { item.Tittel = rdr.GetString(rdr.GetOrdinal("Tittel")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Beskrivelse"))) { item.Beskrivelse = rdr.GetString(rdr.GetOrdinal("Beskrivelse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Losning"))) { item.Losning = rdr.GetString(rdr.GetOrdinal("Losning")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BrukerId"))) { item.BrukerId = rdr.GetString(rdr.GetOrdinal("BrukerId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Fellesraad"))) { item.Fellesraad = rdr.GetString(rdr.GetOrdinal("Fellesraad")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("StartDato"))) { item.StartDato = rdr.GetDateTime(rdr.GetOrdinal("StartDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Ferdig"))) { item.Ferdig = rdr.GetDateTime(rdr.GetOrdinal("Ferdig")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Aksept"))) { item.Aksept = rdr.GetDateTime(rdr.GetOrdinal("Aksept")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Status"))) { item.Status = (int)rdr.GetInt16(rdr.GetOrdinal("Status")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeId"))) { item.TypeId = (int)rdr.GetInt32(rdr.GetOrdinal("TypeId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Program_GUID"))) { item.Program_GUID = rdr.GetString(rdr.GetOrdinal("Program_GUID")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Saksbehandler"))) { item.Saksbehandler = rdr.GetString(rdr.GetOrdinal("Saksbehandler")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ePostAdresse"))) { item.ePostAdresse = rdr.GetString(rdr.GetOrdinal("ePostAdresse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KommentarKunde"))) { item.KommentarKunde = rdr.GetString(rdr.GetOrdinal("KommentarKunde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Stjerner"))) { item.Stjerner = (int)rdr.GetInt16(rdr.GetOrdinal("Stjerner")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Fremdrift"))) { item.Fremdrift = (int)rdr.GetInt16(rdr.GetOrdinal("Fremdrift")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LinkGuid"))) { item.LinkGuid = rdr.GetString(rdr.GetOrdinal("LinkGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tabell"))) { item.Tabell = rdr.GetString(rdr.GetOrdinal("Tabell")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Publiser"))) { item.Publiser = rdr.GetBoolean(rdr.GetOrdinal("Publiser")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PubBeskrivelse"))) { item.PubBeskrivelse = rdr.GetString(rdr.GetOrdinal("PubBeskrivelse")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetHelpDesk")]
        [HttpPost]
        public string SetHelpDesk(HelpDeskItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            ReturnValueItem retur = new();

            logonInfo = item.logonInfo;

            if (item.HelpDeskGuid == null)
            {
                item.HelpDeskGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO HelpDesk() Values()";

                CsqlIS(ref sql, "HelpDeskGuid", item.HelpDeskGuid);
                CsqlII(ref sql, "Program", 1);
                CsqlIS(ref sql, "Modul", item.Modul);
                CsqlIS(ref sql, "Skjermbilde", item.Skjermbilde);
                CsqlID(ref sql, "OpprettetDato", "T", DateTime.Now);
                CsqlIS(ref sql, "OpprettetAv", logonInfo.UserId);
                CsqlII(ref sql, "Prioritet", item.Prioritet);
                CsqlIS(ref sql, "Tittel", item.Tittel);
                CsqlIS(ref sql, "Beskrivelse", item.Beskrivelse);
                CsqlIS(ref sql, "Losning", item.Losning);
                CsqlIS(ref sql, "BrukerId", item.BrukerId);
                CsqlIS(ref sql, "Fellesraad", item.Fellesraad);
                CsqlID(ref sql, "StartDato", "D", item.StartDato);
                CsqlID(ref sql, "Ferdig", "D", item.Ferdig);
                CsqlID(ref sql, "Aksept", "D", item.Aksept);
                CsqlII(ref sql, "Status", item.Status);
                CsqlII(ref sql, "TypeId", item.TypeId);
                CsqlIS(ref sql, "Program_GUID", item.Program_GUID);
                CsqlIS(ref sql, "Saksbehandler", item.Saksbehandler);
                CsqlIS(ref sql, "ePostAdresse", item.ePostAdresse);
                CsqlIS(ref sql, "KommentarKunde", item.KommentarKunde);
                CsqlII(ref sql, "Stjerner", item.Stjerner);
                CsqlII(ref sql, "Fremdrift", item.Fremdrift);
                CsqlIS(ref sql, "LinkGuid", item.LinkGuid);
                CsqlIS(ref sql, "Tabell", item.Tabell);
                CsqlIB(ref sql, "Publiser", item.Publiser);
                CsqlIS(ref sql, "PubBeskrivelse", item.PubBeskrivelse);

            }
            else
            {
                HelpDeskItem itemOld = new();
                itemOld = GetHelpDeskInternal(logonInfo, item.HelpDeskGuid);
                sql = "UPDATE HelpDesk SET WHERE HelpDeskGuid='" + item.HelpDeskGuid + "'";
                CsqlUS(ref sql, "Modul", item.Modul, itemOld.Modul);
                CsqlUS(ref sql, "Skjermbilde", item.Skjermbilde, itemOld.Skjermbilde);
                CsqlUI(ref sql, "Prioritet", item.Prioritet, itemOld.Prioritet);
                CsqlUS(ref sql, "Tittel", item.Tittel, itemOld.Tittel);
                CsqlUS(ref sql, "Beskrivelse", item.Beskrivelse, itemOld.Beskrivelse);
                CsqlUS(ref sql, "Losning", item.Losning, itemOld.Losning);
                CsqlUS(ref sql, "BrukerId", item.BrukerId, itemOld.BrukerId);
                CsqlUD(ref sql, "StartDato", "D", item.StartDato, itemOld.StartDato);
                CsqlUD(ref sql, "Ferdig", "D", item.Ferdig, itemOld.Ferdig);
                CsqlUD(ref sql, "Aksept", "D", item.Aksept, itemOld.Aksept);
                CsqlUI(ref sql, "Status", item.Status, itemOld.Status);
                CsqlUI(ref sql, "TypeId", item.TypeId, itemOld.TypeId);
                CsqlUS(ref sql, "Saksbehandler", item.Saksbehandler, itemOld.Saksbehandler);
                CsqlUS(ref sql, "ePostAdresse", item.ePostAdresse, itemOld.ePostAdresse);
                CsqlUS(ref sql, "KommentarKunde", item.KommentarKunde, itemOld.KommentarKunde);
                CsqlUI(ref sql, "Stjerner", item.Stjerner, itemOld.Stjerner);
                CsqlUI(ref sql, "Fremdrift", item.Fremdrift, itemOld.Fremdrift);
                CsqlUS(ref sql, "LinkGuid", item.LinkGuid, itemOld.LinkGuid);
                CsqlUS(ref sql, "Tabell", item.Tabell, itemOld.Tabell);
                CsqlUB(ref sql, "Publiser", item.Publiser, itemOld.Publiser);
                CsqlUS(ref sql, "PubBeskrivelse", item.PubBeskrivelse, itemOld.PubBeskrivelse);
            }


            if (sql.IndexOf("SET WHERE") == -1)
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
                    e.Message = ex.Message;
                    e.ErrorCode = 20;
                    retur.Error.Add(e);
                    retur.Success = false;
                    transaction.Rollback();
                }

                if(retur.Success && item.byte64String != null && item.byte64String.Length>0)
                {
                    HelpDeskBildeItem itemB = new();

                    itemB.HelpDeskGuid = item.HelpDeskGuid;
                    itemB.Bilde = item.byte64String;
                    SetHelpDeskBilde(itemB);
                }
                
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("RemoveHelpDesk")]
        [HttpPost]
        public string RemoveHelpDesk(HelpDeskItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            ReturnValueItem retur = new();

            sql = "DELETE FROM  HelpDesk WHERE HelpDeskGuid='" + item.HelpDeskGuid + "'";


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

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        private HelpDeskItem GetHelpDeskInternal(AccountLogOnInfoItem logonInfo, string HelpDeskGuid)
        {
            string conString;

            string sql = "SELECT HelpDeskGuid, TiketId, Program, Modul, Skjermbilde, OpprettetDato, OpprettetAv, Prioritet, Tittel, Beskrivelse, Losning, BrukerId, Fellesraad, StartDato, Ferdig, Aksept, Status, TypeId, Program_GUID, Saksbehandler, ePostAdresse, KommentarKunde, Stjerner, Fremdrift, LinkGuid, Tabell, EndretDato, EndretAv, Publiser, PubBeskrivelse FROM HelpDesk WHERE HelpDeskGuid = '" + HelpDeskGuid + "'";

            HelpDeskItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskGuid"))) { item.HelpDeskGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TiketId"))) { item.TiketId = rdr.GetInt32(rdr.GetOrdinal("TiketId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Program"))) { item.Program = rdr.GetInt16(rdr.GetOrdinal("Program")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Modul"))) { item.Modul = rdr.GetString(rdr.GetOrdinal("Modul")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Skjermbilde"))) { item.Skjermbilde = rdr.GetString(rdr.GetOrdinal("Skjermbilde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetDato"))) { item.OpprettetDato = rdr.GetDateTime(rdr.GetOrdinal("OpprettetDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OpprettetAv"))) { item.OpprettetAv = rdr.GetString(rdr.GetOrdinal("OpprettetAv")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Prioritet"))) { item.Prioritet = rdr.GetInt16(rdr.GetOrdinal("Prioritet")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tittel"))) { item.Tittel = rdr.GetString(rdr.GetOrdinal("Tittel")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Beskrivelse"))) { item.Beskrivelse = rdr.GetString(rdr.GetOrdinal("Beskrivelse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Losning"))) { item.Losning = rdr.GetString(rdr.GetOrdinal("Losning")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BrukerId"))) { item.BrukerId = rdr.GetString(rdr.GetOrdinal("BrukerId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Fellesraad"))) { item.Fellesraad = rdr.GetString(rdr.GetOrdinal("Fellesraad")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("StartDato"))) { item.StartDato = rdr.GetDateTime(rdr.GetOrdinal("StartDato")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Ferdig"))) { item.Ferdig = rdr.GetDateTime(rdr.GetOrdinal("Ferdig")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Aksept"))) { item.Aksept = rdr.GetDateTime(rdr.GetOrdinal("Aksept")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Status"))) { item.Status = rdr.GetInt16(rdr.GetOrdinal("Status")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeId"))) { item.TypeId = rdr.GetInt32(rdr.GetOrdinal("TypeId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Program_GUID"))) { item.Program_GUID = rdr.GetString(rdr.GetOrdinal("Program_GUID")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Saksbehandler"))) { item.Saksbehandler = rdr.GetString(rdr.GetOrdinal("Saksbehandler")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ePostAdresse"))) { item.ePostAdresse = rdr.GetString(rdr.GetOrdinal("ePostAdresse")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KommentarKunde"))) { item.KommentarKunde = rdr.GetString(rdr.GetOrdinal("KommentarKunde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Stjerner"))) { item.Stjerner = rdr.GetInt16(rdr.GetOrdinal("Stjerner")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Fremdrift"))) { item.Fremdrift = rdr.GetInt16(rdr.GetOrdinal("Fremdrift")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LinkGuid"))) { item.LinkGuid = rdr.GetString(rdr.GetOrdinal("LinkGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tabell"))) { item.Tabell = rdr.GetString(rdr.GetOrdinal("Tabell")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Publiser"))) { item.Publiser = rdr.GetBoolean(rdr.GetOrdinal("Publiser")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PubBeskrivelse"))) { item.PubBeskrivelse = rdr.GetString(rdr.GetOrdinal("PubBeskrivelse")); }
                    }
                }
            }

            return item;
        }


        #endregion


        #region Bilder

        [Route("GetHelpDeskBildeListe")]
        [HttpPost]
        public string GetHelpDeskBildeListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT HelpDeskBildeGuid, HelpDeskGuid, Bilde, Kommentar,  TypeBilde FROM HelpDeskBilder";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<HelpDeskBildeItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        HelpDeskBildeItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskBildeGuid"))) { item.HelpDeskBildeGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskBildeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskGuid"))) { item.HelpDeskGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Bilde"))) { item.Bilde = rdr.GetString(rdr.GetOrdinal("Bilde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kommentar"))) { item.Kommentar = rdr.GetString(rdr.GetOrdinal("Kommentar")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeBilde"))) { item.TypeBilde = (int)rdr.GetInt16(rdr.GetOrdinal("TypeBilde")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("SetHelpDeskBilde")]
        [HttpPost]
        public string SetHelpDeskBilde(HelpDeskBildeItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            ReturnValueItem result = new ReturnValueItem();

            if (item.HelpDeskBildeGuid == null)
            {
                string HelpDeskBildeGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO HelpDeskBilder() Values()";
                CsqlIS(ref sql, "HelpDeskBildeGuid", HelpDeskBildeGuid);
                CsqlIS(ref sql, "HelpDeskGuid", item.HelpDeskGuid);
                CsqlIS(ref sql, "Bilde", item.Bilde);
                CsqlIS(ref sql, "Kommentar", item.Kommentar);
                CsqlII(ref sql, "TypeBilde", item.TypeBilde);

            }
            else
            {
                HelpDeskBildeItem itemOld = new();
                itemOld = GetHelpDeskBildeInternal(logonInfo, item.HelpDeskBildeGuid);
                sql = "UPDATE HelpDeskBilder SET WHERE HelpDeskBildeGuid ='" + item.HelpDeskBildeGuid + "'"; 
                CsqlUS(ref sql, "Bilde", item.Bilde, itemOld.Bilde);
                CsqlUS(ref sql, "Kommentar", item.Kommentar, itemOld.Kommentar);
                CsqlUI(ref sql, "TypeBilde", item.TypeBilde, itemOld.TypeBilde);
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
                result.Success = false;
                e.ErrorCode = 20;
                e.Message = ex.Message;
                result.Error.Add(e);

                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(result);

            return output;
        }

        //private void UpdateHelpdeskBildeWS(string imageString, string HelpDeskBildeGuid)
        //{
            //if (imageString.Length > 0)
            //{
            //    try
            //    {
            //        if (imageString.IndexOf("base64,") > 0)
            //            imageString = imageString.Substring(imageString.IndexOf("base64,") + 7);

            //        MemoryStream fs = Base64StringToMemoryStream(imageString);
            //        byte[] bytes = fs.ToArray();

            //        string strSQL;

            //        strSQL = @"SELECT HelpDeskBildeGuid, Bilde
            //                  FROM HelpDeskBilder
            //                  WHERE  HelpDeskBildeGuid = '" + HelpDeskBildeGuid + "'";

            //        SqlConnection con = new SqlConnection(sConStringWS);
            //        SqlDataAdapter da = new SqlDataAdapter(strSQL, sConStringWS);
            //        SqlCommandBuilder MyCB = new SqlCommandBuilder(da);
            //        DataSet ds = new DataSet();
            //        da.UpdateCommand = MyCB.GetUpdateCommand;
            //        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //        da.UpdateCommand.CommandTimeout = 600;
            //        da.SelectCommand.CommandTimeout = 600;
            //        con.Open();
            //        da.Fill(ds, "HelpDeskBilder");

            //        if (ds.Tables("HelpDeskBilder").Rows.Count > 0)
            //        {
            //            DataRow myRow;
            //            myRow = ds.Tables("HelpDeskBilder").Rows(0);
            //            myRow("Bilde") = bytes;
            //            da.Update(ds, "HelpDeskBilder");
            //        }

            //        MyCB = null/* TODO Change to default(_) if this is not a reference type */;
            //        ds = null/* TODO Change to default(_) if this is not a reference type */;
            //        da = null/* TODO Change to default(_) if this is not a reference type */;

            //        con.Close();
            //        con = null/* TODO Change to default(_) if this is not a reference type */;
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}
        //}

        public static MemoryStream Base64StringToMemoryStream(string base64String)
        {
            byte[] newBytes = Convert.FromBase64String(base64String);
            MemoryStream memStream = new MemoryStream(newBytes);

            return memStream;
        }

        [Route("GetHelpDeskBilde")]
        [HttpPost]
        public string GetHelpDeskBilde(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT HelpDeskBildeGuid, HelpDeskGuid, Bilde, Kommentar, Program_GUID, TypeBilde, OpprettetDato, OpprettetAv FROM HelpDeskBilder";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            HelpDeskBildeItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskBildeGuid"))) { item.HelpDeskBildeGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskBildeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskGuid"))) { item.HelpDeskGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Bilde"))) { item.Bilde = rdr.GetString(rdr.GetOrdinal("Bilde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kommentar"))) { item.Kommentar = rdr.GetString(rdr.GetOrdinal("Kommentar")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeBilde"))) { item.TypeBilde = (int)rdr.GetInt16(rdr.GetOrdinal("TypeBilde")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        private HelpDeskBildeItem GetHelpDeskBildeInternal(AccountLogOnInfoItem logonInfo, string HelpDeskBildeGuid)
        {
            string conString;

            string sql = "SELECT HelpDeskBildeGuid, HelpDeskGuid, Bilde, Kommentar,  TypeBilde FROM HelpDeskBilder WHERE HelpDeskBildeGuid = '" + HelpDeskBildeGuid  + "'";

            HelpDeskBildeItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskBildeGuid"))) { item.HelpDeskBildeGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskBildeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskGuid"))) { item.HelpDeskGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Bilde"))) { item.Bilde = rdr.GetString(rdr.GetOrdinal("Bilde")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kommentar"))) { item.Kommentar = rdr.GetString(rdr.GetOrdinal("Kommentar")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeBilde"))) { item.TypeBilde = rdr.GetInt16(rdr.GetOrdinal("TypeBilde")); }
                    }
                }
            }

            return item;
        }


        #endregion

        #region Logg

        [Route("GetHelpDeskLoggListe")]
        [HttpPost]
        public string GetHelpDeskLoggListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT HelpDeskLoggGuid, HelpDeskGuid, Tidspunkt, Kommentar, BrukerId, Program_GUID, Publiser, Type, BrukerLest FROM HelpDeskLogg";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<HelpDeskLoggItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        HelpDeskLoggItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskLoggGuid"))) { item.HelpDeskLoggGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskLoggGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskGuid"))) { item.HelpDeskGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tidspunkt"))) { item.Tidspunkt = rdr.GetDateTime(rdr.GetOrdinal("Tidspunkt")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kommentar"))) { item.Kommentar = rdr.GetString(rdr.GetOrdinal("Kommentar")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BrukerId"))) { item.BrukerId = rdr.GetString(rdr.GetOrdinal("BrukerId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Publiser"))) { item.Publiser = rdr.GetBoolean(rdr.GetOrdinal("Publiser")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = rdr.GetInt16(rdr.GetOrdinal("Type")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BrukerLest"))) { item.BrukerLest = rdr.GetBoolean(rdr.GetOrdinal("BrukerLest")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetHelpDeskLogg")]
        [HttpPost]
        public string GetHelpDeskLogg(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT HelpDeskLoggGuid, HelpDeskGuid, Tidspunkt, Kommentar, BrukerId, Program_GUID, Publiser, Type, BrukerLest FROM HelpDeskLogg";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            HelpDeskLoggItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskLoggGuid"))) { item.HelpDeskLoggGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskLoggGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskGuid"))) { item.HelpDeskGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tidspunkt"))) { item.Tidspunkt = rdr.GetDateTime(rdr.GetOrdinal("Tidspunkt")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kommentar"))) { item.Kommentar = rdr.GetString(rdr.GetOrdinal("Kommentar")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BrukerId"))) { item.BrukerId = rdr.GetString(rdr.GetOrdinal("BrukerId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Publiser"))) { item.Publiser = rdr.GetBoolean(rdr.GetOrdinal("Publiser")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = (int)rdr.GetInt32(rdr.GetOrdinal("Type")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BrukerLest"))) { item.BrukerLest = rdr.GetBoolean(rdr.GetOrdinal("BrukerLest")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetHelpDeskLogg")]
        [HttpPost]
        public string SetHelpDeskLogg(HelpDeskLoggItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            if (item.HelpDeskLoggGuid == null)
            {
                string HelpDeskLoggGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO HelpDeskLogg() Values()";


                CsqlIS(ref sql, "HelpDeskLoggGuid", item.HelpDeskLoggGuid);
                CsqlIS(ref sql, "HelpDeskGuid", item.HelpDeskGuid);
                CsqlID(ref sql, "Tidspunkt", "T", item.Tidspunkt);
                CsqlIS(ref sql, "Kommentar", item.Kommentar);
                CsqlIS(ref sql, "BrukerId", item.BrukerId);
                CsqlIB(ref sql, "Publiser", item.Publiser);
                CsqlII(ref sql, "Type", item.Type);
                CsqlIB(ref sql, "BrukerLest", item.BrukerLest);

            }
            else
            {
                HelpDeskLoggItem itemOld = new();
                itemOld = GetHelpDeskLoggInternal(logonInfo, item.HelpDeskLoggGuid);
                sql = "UPDATE HelpDeskLogg SET WHERE HelpDeskLoggGuid='" + item.HelpDeskLoggGuid + "'"; CsqlUS(ref sql, "HelpDeskLoggGuid", item.HelpDeskLoggGuid, itemOld.HelpDeskLoggGuid);
                CsqlUS(ref sql, "HelpDeskGuid", item.HelpDeskGuid, itemOld.HelpDeskGuid);
                CsqlUD(ref sql, "Tidspunkt", "T", item.Tidspunkt, itemOld.Tidspunkt);
                CsqlUS(ref sql, "Kommentar", item.Kommentar, itemOld.Kommentar);
                CsqlUS(ref sql, "BrukerId", item.BrukerId, itemOld.BrukerId);
                CsqlUB(ref sql, "Publiser", item.Publiser, itemOld.Publiser);
                CsqlUI(ref sql, "Type", item.Type, itemOld.Type);
                CsqlUB(ref sql, "BrukerLest", item.BrukerLest, itemOld.BrukerLest);
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

        private HelpDeskLoggItem GetHelpDeskLoggInternal(AccountLogOnInfoItem logonInfo, string HelpDeskLoggGuid)
        {
            string conString;

            string sql = "SELECT HelpDeskLoggGuid, HelpDeskGuid, Tidspunkt, Kommentar, BrukerId, Program_GUID, Publiser, Type, BrukerLest FROM HelpDeskLogg WHERE HelpDeskLoggGuid = '" + HelpDeskLoggGuid + "'";

            HelpDeskLoggItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskLoggGuid"))) { item.HelpDeskLoggGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskLoggGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HelpDeskGuid"))) { item.HelpDeskGuid = rdr.GetString(rdr.GetOrdinal("HelpDeskGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Tidspunkt"))) { item.Tidspunkt = rdr.GetDateTime(rdr.GetOrdinal("Tidspunkt")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Kommentar"))) { item.Kommentar = rdr.GetString(rdr.GetOrdinal("Kommentar")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BrukerId"))) { item.BrukerId = rdr.GetString(rdr.GetOrdinal("BrukerId")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Publiser"))) { item.Publiser = rdr.GetBoolean(rdr.GetOrdinal("Publiser")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = rdr.GetInt32(rdr.GetOrdinal("Type")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("BrukerLest"))) { item.BrukerLest = rdr.GetBoolean(rdr.GetOrdinal("BrukerLest")); }
                    }
                }
            }

            return item;
        }

        #endregion

        #region Typer

        [Route("GetHelpDeskProgramListe")]
        [HttpPost]
        public string GetHelpDeskProgramListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT Id, ProgramNavn, Sortering FROM HelpDeskProgram";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<HelpDeskProgramItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        HelpDeskProgramItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Id"))) { item.Id = rdr.GetInt16(rdr.GetOrdinal("Id")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProgramNavn"))) { item.ProgramNavn = rdr.GetString(rdr.GetOrdinal("ProgramNavn")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Sortering"))) { item.Sortering = rdr.GetInt16(rdr.GetOrdinal("Sortering")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetHelpDeskStatusListe")]
        [HttpPost]
        public string GetHelpDeskStatusListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT Id, StatusNavn, Sortering FROM HelpDeskStatus";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<HelpDeskStatusItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        HelpDeskStatusItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Id"))) { item.Id = (int)rdr.GetInt32(rdr.GetOrdinal("Id")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("StatusNavn"))) { item.StatusNavn = rdr.GetString(rdr.GetOrdinal("StatusNavn")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Sortering"))) { item.Sortering = (int)rdr.GetInt32(rdr.GetOrdinal("Sortering")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetHelpDeskTypeListe")]
        [HttpPost]
        public string GetHelpDeskTypeListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT Id, TypeNavn, Sortering FROM HelpDeskType";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<HelpDeskTypeItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        HelpDeskTypeItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Id"))) { item.Id = (int)rdr.GetInt32(rdr.GetOrdinal("Id")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeNavn"))) { item.TypeNavn = rdr.GetString(rdr.GetOrdinal("TypeNavn")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Sortering"))) { item.Sortering = (int)rdr.GetInt32(rdr.GetOrdinal("Sortering")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        #endregion

        #region Generelle funksjoner

        private string ExecuteSQL(string conString, string sql)
        {

            ReturnValueItem retur = new();

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


        private string ReadValue(AccountLogOnInfoItem logonInfo, string sql, string standard)
        {
            string retur = standard;

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
                        if (!rdr.IsDBNull(0)) retur = rdr.GetInt16(0);
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

        private void CsqlII(ref string SQLQ, string strField, int? Value)
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
            P3 = Strings.InStr(SQLQ.ToLower(), "values") + 7;
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

        private void CsqlID(ref string SQLQ, string strField, string strType, DateTime? dtnValue)
        {
            int p1;
            int p2;
            int P3;
            string sqlData = "";
            int l;

            if (Information.IsDBNull(dtnValue) || !Information.IsDate(dtnValue) || dtnValue == null)
                return;

            DateTime dtValue = dtnValue.Value;

            if (dtValue.Year <= 1753)
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

        private void CsqlUI(ref string SQLQ, string strField, int? intValue, int? intOldValue)
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

        private void CsqlUD(ref string SQLQ, string strField, string strType, DateTime? dtnValue, DateTime? dtOldValue)
        {
            int p1;
            int p2;
            int p3;

            string sqlData = "";
            int l;
            string strWhere;
            string strNewSQL = "";

            if (dtnValue == dtOldValue || dtnValue == null)
                return;

            DateTime dtValue = dtnValue.Value;

            p1 = Strings.InStrRev(SQLQ, "WHERE");
            p2 = Strings.InStr(SQLQ, "SET");

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

            if (p1 - p2 == 4)
                SQLQ = sqlData.Substring(1);
            else
                SQLQ = sqlData;

            strNewSQL = string.Concat(strNewSQL, SQLQ, strWhere);
            SQLQ = strNewSQL;
        }

        #endregion


    }

}
