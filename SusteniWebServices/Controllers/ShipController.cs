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
using Spire.Doc.Documents.Rendering;
using Microsoft.VisualStudio.Services.WebApi;


public class ShipItem
{
    public string? ShipGuid { get; set; } = "";
    public string CustomerGuid { get; set; } = "";
    public string IMO { get; set; } = "";
    public string Name { get; set; } = "";
    public string? ShipTypeGuid { get; set; } = "";
    public int GrossTonnage { get; set; } = 0;
    public int Length { get; set; } = 0;
    public int Width { get; set; } = 0;
    public int YearOfBuilt { get; set; } = 0;
    public int OperationDays { get; set; } = 0;
    public Single KgDieselkWh { get; set; } = 0;
    public Single EfficientMotorSwitchboard { get; set; } = 0;
    public Single DensityMGO { get; set; } = 0;
    public int NumberOfDays { get; set; } = 0;
    public int FuelConsPrYear { get; set; } = 0;
    public string Picture { get; set; } = "";
    public string PicturePrint { get; set; } = "";
    public string byte64Picture { get; set; } = "";
    public int UnitOfMeasurement { get; set; } = 0;
    public string ProfilGuid { get; set; } = "";
    public string ProfilName { get; set; } = "";
    public string? InfoText { get; set; } = "";
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class NewShipItem
{
    public string? ShipGuid { get; set; } = "";
    public string? CustomerGuid { get; set; } = "";
    public string? IMO { get; set; } = "";
    public string Name { get; set; } = "";
    public string ShipTypeGuid { get; set; } = "";
    public int GrossTonnage { get; set; } = 0;
    public int Length { get; set; } = 0;
    public int Width { get; set; } = 0;
    public int YearOfBuilt { get; set; } = 0;
    public int OperationDays { get; set; } = 0;
    public Single DensityMGO { get; set; } = 0;
    public int NumberOfDays { get; set; } = 0;
    public int FuelConsPrYear { get; set; } = 0;
    public int UnitOfMeasurement { get; set; } = 0;
    public string? ProfilGuid { get; set; } = "";
    public string? ProfilName { get; set; } = "";
    public string? InfoText { get; set; } = "";
    public string? OperationModes { get; set; } = "";
    public string? Generators { get; set; } = "";
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class ShipTypeItem
{
    public string ShipTypeGuid { get; set; } = "";
    public string Name { get; set; } = "";
}

public class ShipTypeOperationModesItem
{
    public string? OperationModeGuid { get; set; } = "";
    public string ShipTypeGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public int Order { get; set; } = 0;
    public int HoursPrYear { get; set; } = 0;
    public int NumberGenerators { get; set; } = 0;
    public bool Standard { get; set; } = false;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ShipTypeGeneratorsItem
{
    public string? GeneratorGuid { get; set; }
    public string ShipTypeGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public string? FuelTypeGuid { get; set; } = "";
    public string? TypeGuid { get; set; } = "";
    public int kW { get; set; } = 0;
    public Double KgDieselkWh { get; set; } = 0;
    public Double EfficientMotorSwitchboard { get; set; } = 0;
    public Double MaintenanceCost { get; set; } = 0;
    public bool PowerProduction { get; set; } = false;
    public int Order { get; set; } = 0;
    public bool Standard { get; set; } = false;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class PowerProductionTypeItem
{
    public string TypeGuid { get; set; } = "";
    public string Name { get; set; } = "";
}

public class ShipFuelTypeItem
{
    public string FuelTypeGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public Single CarbonContent { get; set; } = 0;
    public Single Cf { get; set; } = 0;
}

public class ShipOperationModeItem
{
    public string OperationModeGuid { get; set; } = "";
    public string? OperationModeProfileGuid { get; set; }
    public string ShipGuid { get; set; } = "";
    public string? ProfilGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public int Order { get; set; } = 0;
    public int HoursPrYear { get; set; } = 0;
    public int NumberGenerator { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ShipEquipmentTypeItem
{
    public int Type { get; set; } = 0;
    public string Name { get; set; } = "";
}

public class ShipEquipmentItem
{
    public string? EquipmentGuid { get; set; } = "";
    public string ShipGuid { get; set; } = "";
    public string ProfilGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public string Model { get; set; } = "";
    public string? Description { get; set; } = "";
    public int EquipmentType { get; set; } = 0;
    public Single MaxEffect { get; set; } = 0;
    public int Order { get; set; } = 0;
    public Single Cost { get; set; } = 0;
    public int FinancielSupport { get; set; } = 0;
    public bool Active { get; set; } = false;
    public int Year { get; set; } = 0;
    public Single MaintenanceCode { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ShipEquipmentModesItem
{
    public string? EquipmentModesGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public string EquipmentGuid { get; set; } = "";
    public string OperationModeGuid { get; set; } = "";
    public string? ProfilGuid { get; set; } = "";
    public int HoursBefore { get; set; } = 0;
    public decimal PercentLoad { get; set; } = 0;
    public int HoursAfter { get; set; } = 0;
    public decimal PercentSaving { get; set; } = 0;
    public int HoursPrYear { get; set; } = 0;
    public decimal MaxEffect { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();

    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ShipGeneratorModesSummaryItem
{
    public string Name { get; set; } = "";
    public int HoursPrYear { get; set; } = 0;
    public double MaintenanceCost { get; set; } = 0;
    public double EffectBefore { get; set; } = 0;
    public double EffectAfter { get; set; } = 0;
    public double FuelBefore { get; set; } = 0;
    public double FuelAfter { get; set; } = 0;
    public double CO2Before { get; set; } = 0;
    public double CO2After { get; set; } = 0;
    public double NOxBefore { get; set; } = 0;
    public double NOxAfter { get; set; } = 0;
    public double SOxBefore { get; set; } = 0;
    public double SOxAfter { get; set; } = 0;
}

public class ShipGeneratorItem
{
    public string? GeneratorGuid { get; set; } = "";
    public string ShipGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public int Order { get; set; } = 0;
    public string TypeGuid { get; set; } = "";
    public string FuelTypeGuid { get; set; } = "";
    public int kW { get; set; } = 0;
    public Double KgDieselkWh { get; set; } = 0;
    public Double EfficientMotorSwitchboard { get; set; } = 0;
    public Double MaintenanceCost { get; set; } = 0;
    public Double FuelPrice { get; set; } = 0;
    public bool PowerProduction { get; set; } = true;
    public bool ExcludeAutoTune { get; set; } = false;
    public int EffectBefore { get; set;} = 0;
    public int EffectAfter { get; set; } = 0;
    public Double Faktor { get; set; } = 0;
    public Double FuelBefore { get; set; } = 0;
    public Double FuelAfter { get; set; } = 0;
    public Double CO2Before { get; set; } = 0;
    public Double CO2After { get; set; } = 0;
    public Double NOxBefore { get; set; } = 0;
    public Double NOxAfter { get; set; } = 0;
    public Double SOxBefore { get; set; } = 0;
    public Double SOxAfter { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ShipGeneratorModesItem
{
    public string? GeneratorModesGuid { get; set; } = "";
    public string? Name { get; set; } = "";
    public string GeneratorGuid { get; set; } = "";
    public string OperationModeGuid { get; set; } = "";
    public string? ProfilGuid { get; set; } = "";
    public int HoursBefore { get; set; } = 0;
    public decimal PercentLoad { get; set; } = 0;
    public int HoursAfter { get; set; } = 0;
    public decimal PercentSaving { get; set; } = 0;
    public int HoursPrYear { get; set; } = 0;
    public int kW { get; set; } = 0;
    public bool PowerProduction { get; set; } = true;
    public double EffectBefore { get; set; } = 0;
    public double EffectAfter { get; set; } = 0;
    public double KgDieselKwhB { get; set; } = 0;
    public double KgDieselKwhA { get; set; } = 0;
    public double FuelBefore { get; set; } = 0;
    public double FuelAfter { get; set; } = 0;
    public bool Active { get; set; } = false;
    public bool ActiveBefore { get; set; } = false;
    public int MaintenanceCost { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();

    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ShipGeneratorModesShortItem
{
    public string GeneratorModesGuid { get; set; } = "";
    public string GeneratorGuid { get; set; } = "";
    public string OperationModeGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public int kW { get; set; } = 0;
    public string? ProfilGuid { get; set; } = "";
    public decimal PercentLoad { get; set; } = 0;
    public decimal PercentSaving { get; set; } = 0;
    public int HoursBefore { get; set; } = 0;
    public int HoursAfter { get; set; } = 0;
    public bool Active { get; set; } = false;
    public bool ActiveBefore { get; set; } = false;
    public bool ExcludeAutoTune { get; set; } = false;    
}

public class ShipGeneratorModesListItem
{
    public string? GeneratorModesGuid { get; set; } = "";
    public string? GeneratorGuid { get; set; } = "";
    public string? OperationModeGuid { get; set; } = "";
    public int UpdateMode { get; set; } = 0;
    public string? ProfilGuid { get; set; } = "";
    public decimal PercentLoad { get; set; } = 0;
    public decimal PercentSaving { get; set; } = 0;
    public int HoursBefore { get; set; } = 0;
    public int HoursAfter { get; set; } = 0;
    public bool Active { get; set; } = false;
    public bool ActiveBefore { get; set; } = false;
    public ErrorItem Error { get; set; } = new ErrorItem();

    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class AutoTuneParameteritem
{
    public string OperationModeGuid { get; set; } = "";
    public string ProfilGuid { get; set; } = "";
    public int MinNumberGenerator { get; set; } = 0;
    public int NecesseryPP { get; set; } = 0;
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ShipOperationPowerItem
{
    public string Name { get; set; } = "";
    public string Order { get; set; } = "";
    public int HoursPrYear { get; set; } = 0;
    public int PowerPre { get; set; } = 0;
    public int PowerPast { get; set; } = 0;

    public ErrorItem Error { get; set; } = new ErrorItem();

    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ShipOperationSavingPowerItem
{
    public string EquipmentTypeName { get; set; } = "";
    public int OperationMode1 { get; set; } = 0;
    public int OperationMode2 { get; set; } = 0;
    public int OperationMode3 { get; set; } = 0;
    public int OperationMode4 { get; set; } = 0;
    public int OperationMode5 { get; set; } = 0;
    public int OperationMode6 { get; set; } = 0;
    public int OperationMode7 { get; set; } = 0;
    public int OperationMode8 { get; set; } = 0;
    public int OperationMode9 { get; set; } = 0;
    public int OperationMode0 { get; set; } = 0;

    public ErrorItem Error { get; set; } = new ErrorItem();

    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class ShipOperationSavingItem
{
    public string Name { get; set; } = "";
    public int OldValue { get; set; } = 0;
    public int NewValue { get; set; } = 0;

}

public class ShipGeneratorHeatUnitItem
{
    public string? HeatUnitGuid { get; set; } = "";
    public string ShipGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public int kW { get; set; } = 0;
    public Single HourPrday { get; set; } = 0;
    public Single Factor { get; set; } = 0;
    public int NumberOfDays { get; set; } = 0;
    public Single KgDieselkWh { get; set; } = 0;
    public Single EfficientMotorSwitchboard { get; set; } = 0;
    public Single DensityMGO { get; set; } = 0;
    public int FuelConsPrYear { get; set; } = 0;

    public ErrorItem Error { get; set; } = new ErrorItem();

    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class InvestmentPlanItem
{
    public string ShipGuid { get; set; } = "";
    public string EquipmentGuid { get; set; } = "";
    public string ProfilGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public string ProfilName { get; set; } = "";
    public double Effect { get; set; } = 0;
    public double Savings { get; set; } = 0;
    public double Total { get; set; } = 0;  
    public int InvYear { get; set; } = 0;
    public double Cost { get; set; } = 0;
    public int FinancielSupport { get; set; } = 0;
    public double KgDieselkWh { get; set; } = 0;
    public double GenPowerPrLiter { get; set; } = 0;
    public double PriceKwh { get; set; } = 0;
    public double SavingsYear { get; set; } = 0;
    public double MaintenaceCost { get; set; } = 0;
    public double FuelSaving {  get; set; } = 0;
    public double EffectCostYear { get; set; } = 0;
    public double SavingsCostYear { get; set; } = 0;
    public double OilPrice { get; set; } = 0;
    public double CO2Savings { get; set; } = 0;
    public double NOxSavings { get; set; } = 0;
    public double SOxSavings { get; set; } = 0;
    public double kWhSavings { get; set; } = 0;
    public double FuelCons {  get; set; } = 0;

}

public class InvestmentPlanYearItem
{
    public string ShipGuid { get; set; } = "";
    public string EquipmentGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public Single Year2023 { get; set; } = 0;
    public Single Year2024 { get; set; } = 0;
    public Single Year2025 { get; set; } = 0;
    public Single Year2026 { get; set; } = 0;

    public Single Year2027 { get; set; } = 0;
    public Single Year2028 { get; set; } = 0;
    public Single Year2029 { get; set; } = 0;
    public Single Year2030 { get; set; } = 0;
}

public class ShipFuleSavingsInfoItem
{
    public String ShipGuid { get; set; } = "";
    public Single Effect { get; set; } = 0;
    public Single Savings { get; set; } = 0;
}

public class ProfileItem
{
    public string? ProfilGuid { get; set; } = "";
    public string LinkGuid { get; set; } = "";
    public string Name { get; set; } = "";
    public string CreatedBy { get; set; } = "";
    public DateTime CreatDate { get; set; } = DateTime.Now;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class UserShipProfileItem
{
    public String UserGuid { get; set; } = "";
    public String ShipGuid { get; set; } = "";
    public String? ProfilGuid { get; set; } = "";
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
}

public class GeneratorFuelComsuptionItem
{
    public string? FuelConsGuid { get; set; } = "";
    public string LinkGuid { get; set; } = "";
    public int Effect { get; set; } = 0;
    public double KgDieselkWh { get; set; } = 0;
    public ErrorItem Error { get; set; } = new ErrorItem();
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

public class GeneratorFuelComsuptionChartItem
{
    public string Effect { get; set; } = "";
    public double KgDieselkWh { get; set; } = 0;

}

public class OperationModeProfileItem
{
    public string? OperationModeProfileGuid { get; set; } = "";
    public string OperationModeGuid { get; set; } = "";
    public string ProfilGuid { get; set; } = "";
    public int NumberGenerator { get; set; } = 0;
    public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

}

namespace SusteniWebServices.Controllers
{

    [Route("/[controller]")]
    [ApiController]

    public class ShipController : ControllerBase
    {

        #region Ship information

        [Route("CreateShip")]
        [HttpPost]
        public string CreateShip(NewShipItem item)
        {
            FunctionsController fc = new FunctionsController();
            string conString;
            string sql = "";
            bool newShip = false;

            ReturnValueItem retur = new();

            if (item.ShipGuid == null)
            {
                newShip = true;
                string shipGuid = Guid.NewGuid().ToString();
                item.ShipGuid = shipGuid;

                sql = "INSERT INTO Ship() VALUES()";
                CsqlI(ref sql, "ShipGuid", item.ShipGuid);
                CsqlI(ref sql, "CustomerGuid", item.logonInfo.CustomerGuid);
                CsqlI(ref sql, "IMO", item.IMO);
                CsqlI(ref sql, "Name", item.Name);
                CsqlI(ref sql, "ShipTypeGuid", item.ShipTypeGuid);
                CsqlI(ref sql, "GrossTonnage", item.GrossTonnage);
                CsqlI(ref sql, "Length", item.Length);
                CsqlI(ref sql, "Width", item.Width);
                CsqlI(ref sql, "YearOfBuilt", item.YearOfBuilt);
                CsqlI(ref sql, "OperationDays", item.OperationDays);
                CsqlI(ref sql, "DensityMGO", item.DensityMGO);
                CsqlI(ref sql, "NumberOfDays", item.NumberOfDays);
                CsqlI(ref sql, "FuelConsPrYear", item.FuelConsPrYear);
                CsqlI(ref sql, "UnitOfMeasurement", item.UnitOfMeasurement);
                CsqlI(ref sql, "InfoText", item.InfoText);

                string userShipGuid = Guid.NewGuid().ToString();
                sql += ";INSERT INTO Users_Ship(UserShipGuid, UserId, ShipGuid, CustomerGuid) VALUES('" + userShipGuid + "','" + item.logonInfo.UserId + "','" + item.ShipGuid + "','" + item.logonInfo.CustomerGuid + "')";

            }
            else
            {
                ShipItem itemOld = new();
                itemOld = GetShipInternal(item.logonInfo, item.ShipGuid);

                sql = "UPDATE Ship SET WHERE ShipGuid='" + item.ShipGuid + "'";
                CsqlU(ref sql, "IMO", item.IMO, itemOld.IMO);
                CsqlU(ref sql, "Name", item.Name, itemOld.Name);
                CsqlU(ref sql, "ShipTypeGuid", item.ShipTypeGuid, itemOld.ShipTypeGuid);
                CsqlU(ref sql, "GrossTonnage", item.GrossTonnage, itemOld.GrossTonnage);
                CsqlU(ref sql, "Length", item.Length, itemOld.Length);
                CsqlU(ref sql, "Width", item.Width, itemOld.Width);
                CsqlU(ref sql, "YearOfBuilt", item.YearOfBuilt, itemOld.YearOfBuilt);
                CsqlU(ref sql, "OperationDays", item.OperationDays, itemOld.OperationDays);
                CsqlU(ref sql, "DensityMGO", item.DensityMGO, itemOld.DensityMGO);
                CsqlU(ref sql, "NumberOfDays", item.NumberOfDays, itemOld.NumberOfDays);
                CsqlU(ref sql, "FuelConsPrYear", item.FuelConsPrYear, itemOld.FuelConsPrYear);
                CsqlU(ref sql, "UnitOfMeasurement", item.UnitOfMeasurement, itemOld.UnitOfMeasurement);
                CsqlU(ref sql, "InfoText", item.InfoText, itemOld.InfoText);
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
                    retur.Success = false;
                    ErrorItem e = new();
                    e.ErrorCode = 10;
                    e.Message = ex.Message;
                    retur.Error.Add(e);
                    transaction.Rollback();
                }

            }

            ProfileItem itmP = new();
            itmP.Name = "Basic Setup";
            itmP.LinkGuid = item.ShipGuid;
            ReturnValueItem returP = new();
            string returSP = SetProfile(itmP);
            if (returSP != null)
            {
                returP = JsonConvert.DeserializeObject<ReturnValueItem>(returSP);
                item.logonInfo.ShipGuid = item.ShipGuid;
                item.logonInfo.Parameters.fieldValue = returP.NewGuid;
                SetActivProfil(item.logonInfo);
            }

            if (item.OperationModes != null && item.OperationModes.Length>0)
            {
                string[] om = item.OperationModes.Split(';');
                foreach(string o in om)
                {
                    AccountLogOnInfoItem ali = new AccountLogOnInfoItem();
                    ali = item.logonInfo;
                    ShipTypeOperationModesItem itmOM = fc.GetShipTypeOperationModesInternal(ali, o);
                    ShipOperationModeItem itmOMI = new();
                    itmOMI.Name = itmOM.Name;
                    itmOMI.HoursPrYear = itmOM.HoursPrYear;
                    itmOMI.Order = itmOM.Order;
                    itmOMI.ShipGuid = item.ShipGuid;
                    itmOMI.NumberGenerator = itmOM.NumberGenerators;
                    SetShipOperationMode(itmOMI);
                }
            }

            if (item.Generators != null && item.Generators.Length > 0)
            {
                string[] gen = item.Generators.Split(';');
                foreach (string g in gen)
                {
                    AccountLogOnInfoItem ali = new AccountLogOnInfoItem();
                    ali = item.logonInfo;
                    ShipTypeGeneratorsItem itmG = fc.GetShipTypeGeneratorsInternal(ali, g);
                    ShipGeneratorItem itmGI = new();
                    itmGI.Name = itmG.Name;
                    itmGI.ShipGuid = item.ShipGuid;
                    itmGI.FuelTypeGuid = itmG.FuelTypeGuid;
                    itmGI.TypeGuid = itmG.TypeGuid;
                    itmGI.kW = itmG.kW;
                    itmGI.KgDieselkWh = itmG.KgDieselkWh;
                    itmGI.EfficientMotorSwitchboard = itmG.EfficientMotorSwitchboard;
                    itmGI.MaintenanceCost = itmG.MaintenanceCost;
                    itmGI.PowerProduction = itmG.PowerProduction;
                    itmGI.Order = itmG.Order;
                    SetShipGenerator(itmGI);
                }
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("GetShip")]
        [HttpPost]
        public string GetShip(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT ShipGuid, CustomerGuid, IMO, Name, ShipTypeGuid, GrossTonnage, Length, Width, YearOfBuilt, OperationDays, DensityMGO, NumberOfDays, FuelConsPrYear, UnitOfMeasurement, InfoText, Pictures.byte64Picture " +
                "FROM Ship LEFT OUTER JOIN Pictures ON Ship.ShipGuid=Pictures.LinkGuid ";
            if (logonInfo.Parameters.filter != "")
            {
                sql += "WHERE " + logonInfo.Parameters.filter;
            }

            ShipItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CustomerGuid"))) { item.CustomerGuid = rdr.GetString(rdr.GetOrdinal("CustomerGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("IMO"))) { item.IMO = rdr.GetString(rdr.GetOrdinal("IMO")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GrossTonnage"))) { item.GrossTonnage = rdr.GetInt32(rdr.GetOrdinal("GrossTonnage")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Length"))) { item.Length = rdr.GetInt32(rdr.GetOrdinal("Length")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Width"))) { item.Width = rdr.GetInt32(rdr.GetOrdinal("Width")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("YearOfBuilt"))) { item.YearOfBuilt = rdr.GetInt32(rdr.GetOrdinal("YearOfBuilt")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationDays"))) { item.OperationDays = rdr.GetInt32(rdr.GetOrdinal("OperationDays")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("DensityMGO"))) { item.DensityMGO = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("DensityMGO"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumberOfDays"))) { item.NumberOfDays = rdr.GetInt32(rdr.GetOrdinal("NumberOfDays")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelConsPrYear"))) { item.FuelConsPrYear = rdr.GetInt32(rdr.GetOrdinal("FuelConsPrYear")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UnitOfMeasurement"))) { item.UnitOfMeasurement = rdr.GetInt16(rdr.GetOrdinal("UnitOfMeasurement")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("byte64Picture"))) { item.byte64Picture = rdr.GetString(rdr.GetOrdinal("byte64Picture")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("InfoText"))) { item.InfoText = rdr.GetString(rdr.GetOrdinal("InfoText")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }


        [Route("SetShip")]
        [HttpPost]
        public string SetShip(ShipItem item)
        {

            string conString;
            string sql = "";
            bool newShip = false;

            ReturnValueItem retur = new();

            if (item.ShipGuid == null)
            {
                newShip = true;
                string shipGuid = Guid.NewGuid().ToString();
                item.ShipGuid = shipGuid;

                sql = "INSERT INTO Ship() VALUES()";
                CsqlI(ref sql, "ShipGuid", item.ShipGuid);
                CsqlI(ref sql, "CustomerGuid", item.CustomerGuid);
                CsqlI(ref sql, "IMO", item.IMO);
                CsqlI(ref sql, "Name", item.Name);
                CsqlI(ref sql, "ShipTypeGuid", item.ShipTypeGuid);
                CsqlI(ref sql, "GrossTonnage", item.GrossTonnage);
                CsqlI(ref sql, "Length", item.Length);
                CsqlI(ref sql, "Width", item.Width);
                CsqlI(ref sql, "YearOfBuilt", item.YearOfBuilt);
                CsqlI(ref sql, "OperationDays", item.OperationDays);
                CsqlI(ref sql, "DensityMGO", item.DensityMGO);
                CsqlI(ref sql, "NumberOfDays", item.NumberOfDays);
                CsqlI(ref sql, "FuelConsPrYear", item.FuelConsPrYear);
                CsqlI(ref sql, "UnitOfMeasurement", item.UnitOfMeasurement);
                CsqlI(ref sql, "InfoText", item.InfoText);
            }
            else
                {
                ShipItem itemOld = new();
                itemOld = GetShipInternal(item.logonInfo, item.ShipGuid);

                sql = "UPDATE Ship SET WHERE ShipGuid='" + item.ShipGuid + "'";
                CsqlU(ref sql, "IMO", item.IMO, itemOld.IMO);
                CsqlU(ref sql, "Name", item.Name, itemOld.Name);
                CsqlU(ref sql, "ShipTypeGuid", item.ShipTypeGuid, itemOld.ShipTypeGuid);
                CsqlU(ref sql, "GrossTonnage", item.GrossTonnage, itemOld.GrossTonnage);
                CsqlU(ref sql, "Length", item.Length, itemOld.Length);
                CsqlU(ref sql, "Width", item.Width, itemOld.Width);
                CsqlU(ref sql, "YearOfBuilt", item.YearOfBuilt, itemOld.YearOfBuilt);
                CsqlU(ref sql, "OperationDays", item.OperationDays, itemOld.OperationDays);
                CsqlU(ref sql, "DensityMGO", item.DensityMGO, itemOld.DensityMGO);
                CsqlU(ref sql, "NumberOfDays", item.NumberOfDays, itemOld.NumberOfDays);
                CsqlU(ref sql, "FuelConsPrYear", item.FuelConsPrYear, itemOld.FuelConsPrYear);
                CsqlU(ref sql, "UnitOfMeasurement", item.UnitOfMeasurement, itemOld.UnitOfMeasurement);
                CsqlU(ref sql, "InfoText", item.InfoText, itemOld.InfoText);
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
                    retur.Success = false;
                    ErrorItem e = new();
                    e.ErrorCode = 10;
                    e.Message = ex.Message;
                    retur.Error.Add(e);
                    transaction.Rollback();
                }

            }

            if (newShip)
            {
                ProfileItem itmP = new();
                itmP.Name = "Basic Setup";
                itmP.LinkGuid = item.ShipGuid;
                ReturnValueItem returP = new();
                string returSP = SetProfile(itmP);
                if (returSP != null)
                {
                    returP = JsonConvert.DeserializeObject<ReturnValueItem>(returSP);
                    item.logonInfo.ShipGuid = item.ShipGuid;
                    item.logonInfo.Parameters.fieldValue = returP.NewGuid;
                    SetActivProfil(item.logonInfo);
                }

            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

            private ShipItem GetShipInternal(AccountLogOnInfoItem logonInfo, string ShipGuid)
            {

                string conString;
                string sql = "SELECT ShipGuid, CustomerGuid, IMO, Name, ShipTypeGuid, GrossTonnage, Length, Width, YearOfBuilt, OperationDays, DensityMGO, NumberOfDays, FuelConsPrYear, UnitOfMeasurement, InfoText, Pictures.byte64Picture " +
                    "FROM Ship LEFT OUTER JOIN Pictures ON Ship.ShipGuid=Pictures.LinkGuid ";
                sql += "WHERE ShipGuid='" + ShipGuid + "'";

                ShipItem item = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        if (rdr.Read())
                        {
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("GrossTonnage"))) { item.GrossTonnage = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("GrossTonnage"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Length"))) { item.Length = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Length"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Width"))) { item.Width = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Width"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("YearOfBuilt"))) { item.YearOfBuilt = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("YearOfBuilt"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("OperationDays"))) { item.OperationDays = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("OperationDays"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("DensityMGO"))) { item.DensityMGO = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("DensityMGO"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("byte64Picture"))) { item.byte64Picture = rdr.GetString(rdr.GetOrdinal("byte64Picture")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("NumberOfDays"))) { item.NumberOfDays = rdr.GetInt32(rdr.GetOrdinal("NumberOfDays")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("FuelConsPrYear"))) { item.FuelConsPrYear = rdr.GetInt32(rdr.GetOrdinal("FuelConsPrYear")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("UnitOfMeasurement"))) { item.UnitOfMeasurement = rdr.GetInt16(rdr.GetOrdinal("UnitOfMeasurement")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("InfoText"))) { item.InfoText = rdr.GetString(rdr.GetOrdinal("InfoText")); }
                        }
                    }
                }

                return item;
            }


            [Route("GetShipsList")]
            [HttpPost]
            public string GetShipsList(AccountLogOnInfoItem logonInfo)
            {
                string conString;
                string sql = "SELECT ShipGuid, Name, ShipTypeGuid FROM Ship ";
                if (logonInfo.Parameters.filter != "")
                {
                    sql += "WHERE " + logonInfo.Parameters.filter;
                }

                List<ShipItem> items = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            ShipItem item = new();
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                            items.Add(item);
                        }
                    }
                }

                string output = JsonConvert.SerializeObject(items);

                return output;
            }


            [Route("GetShipsListWithPicture")]
            [HttpPost]
            public string GetShipsListWithPicture(AccountLogOnInfoItem logonInfo)
            {
                string conString;
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image/ship.jpeg");

                string sql = "SELECT Ship.ShipGuid, Ship.Name, ShipTypeGuid, Pictures.byte64Picture, US.ProfilGuid, P.Name ProfileName FROM Ship INNER JOIN Users_ship US ON Ship.ShipGuid=US.ShipGuid LEFT OUTER JOIN Profile P ON US.ProfilGuid=P.ProfilGuid LEFT OUTER JOIN Pictures ON Ship.ShipGuid=Pictures.LinkGuid";
                if (logonInfo.Parameters.filter != "")
                {
                    sql += "WHERE " + logonInfo.Parameters.filter;
                }
                else
            {
                sql += " WHERE US.UserId='" + logonInfo.UserId + "'";
            }
                List<ShipItem> items = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";


                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            ShipItem item = new();
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ProfileName"))) { item.ProfilName = rdr.GetString(rdr.GetOrdinal("ProfileName")); }
                            if (logonInfo.Parameters.yesno == false)
                            {
                                if (!rdr.IsDBNull(rdr.GetOrdinal("byte64Picture"))) { item.byte64Picture = rdr.GetString(rdr.GetOrdinal("byte64Picture")); }
                                if (item.byte64Picture.Length == 0)
                                {
                                    try
                                    {
                                        FileStream fStream = new FileStream(filePath, FileMode.Open);
                                        MemoryStream stream = new MemoryStream();
                                        fStream.CopyTo(stream);

                                        item.byte64Picture = Convert.ToBase64String(stream.ToArray());

                                        fStream.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        item.Error.Message = ex.Message;
                                    }

                                }
                            }


                            items.Add(item);
                        }
                    }
                }



                string output = JsonConvert.SerializeObject(items);

                return output;
            }

            [Route("GetShipPicture")]
            [HttpPost]
            public string GetShipPicture(string conString, string shipGuid)
            {
                string sql = "SELECT byte64Picture FROM Pictures WHERE LinkGuid='" + shipGuid + "'";

                string base64String = "";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        if (rdr.Read())
                        {
                            if (!rdr.IsDBNull(rdr.GetOrdinal("byte64Picture"))) { base64String = rdr.GetString(rdr.GetOrdinal("byte64Picture")); }
                        }
                    }
                }

                return base64String;
            }


            [Route("SetPicture")]
            [HttpPost]
            public string SetPicture(FilerItem item)
            {

                string conString;
                string sql = "";
                ReturnValueItem retur = new();

                string pictureGuid = Guid.NewGuid().ToString();

                if (item.byte64string.Substring(0, 4) == "data")
                {
                    item.byte64string = item.byte64string.Substring(item.byte64string.IndexOf("base64") + 7);
                }

                sql = "INSERT INTO Pictures() VALUES()";
                CsqlI(ref sql, "PictureGuid", pictureGuid);
                CsqlI(ref sql, "LinkGuid", item.LinkGuid);
                CsqlI(ref sql, "byte64Picture", item.byte64string);

                sql = "DELETE FROM Pictures WHERE LinkGuid='" + item.LinkGuid + "';" + sql;

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


            [Route("RemoveShip")]
            [HttpPost]
            public string RemoveShip(AccountLogOnInfoItem logonInfo)
            {

                string conString;
                string sql = "";
                ReturnValueItem retur = new();

                sql = "DELETE FROM Ship WHERE ShipGuid='" + logonInfo.ShipGuid + "'";
                sql += ";DELETE FROM Equipment WHERE ShipGuid='" + logonInfo.ShipGuid + "'";
                sql += ";DELETE FROM GeneratorHeatUnit WHERE ShipGuid='" + logonInfo.ShipGuid + "'";
                sql += ";DELETE FROM Generators WHERE ShipGuid='" + logonInfo.ShipGuid + "'";
                sql += ";DELETE FROM OperationModes WHERE ShipGuid='" + logonInfo.ShipGuid + "'";
                sql += ";DELETE FROM USERS_SHIP WHERE ShipGuid='" + logonInfo.ShipGuid + "'";
                sql += ";DELETE FROM UserShipProfil WHERE ShipGuid='" + logonInfo.ShipGuid + "'";

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


        [Route("SetActiveShip")]
        [HttpPost]
        public string SetActiveShip(AccountLogOnInfoItem item)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            retur.Description = ReadValue(item, "SELECT Case WHEN UnitOfMeasurement = 1 THEN 'ton' ELSE 'm³' END Measure FROM Ship WHERE ShipGuid='" + item.ShipGuid + "'","");

            sql = "UPDATE Users SET ActivShipGuid='" + item.ShipGuid + "' WHERE UserId='" + item.UserId + "'";

            conString = @"server=" + item.Server + ";User Id=" + item.UserId + ";password=" + item.Password + ";database=" + item.Database + ";TrustServerCertificate=True";

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
                    retur.Success = false;
                    ErrorItem e = new();
                    e.ErrorCode = 10;
                    e.Message = ex.Message;
                    retur.Error.Add(e);
                    transaction.Rollback();
                }

            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        #endregion

        #region Types

        [Route("GetShipTypeList")]
        [HttpPost]
        public string GetShipTypeList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ShipTypeGuid, Name FROM ShipType";

            List<ShipTypeItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipTypeItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipTypeGuid"))) { item.ShipTypeGuid = rdr.GetString(rdr.GetOrdinal("ShipTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetPowerProductionTypeList")]
        [HttpPost]
        public string GetPowerProductionTypeList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT TypeGuid, Name FROM PowerProductionType";

            List<PowerProductionTypeItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        PowerProductionTypeItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetShipFuelTypeList")]
        [HttpPost]
        public string GetShipFuelTypeList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT FuelTypeGuid, Name, CarbonContent, Cf FROM FuelType";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipFuelTypeItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipFuelTypeItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CarbonContent"))) { item.CarbonContent = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("CarbonContent"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Cf"))) { item.Cf = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Cf"))); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        #endregion

        #region Operation mode


        [Route("SetShipOperationMode")]
        [HttpPost]
        public string SetShipOperationMode(ShipOperationModeItem item)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            if (item.OperationModeGuid == "")
            {
                string OperationModeGuid = Guid.NewGuid().ToString();
                int order = item.Order;
                if (order == 0)
                {
                    order = GetNextValue(item.logonInfo, "OperationModes", "[Order]", "ShipGuid='" + item.ShipGuid + "'");
                }

                sql = "INSERT INTO OperationModes() VALUES()";
                CsqlI(ref sql, "Operationmodeguid", OperationModeGuid);
                CsqlI(ref sql, "ShipGuid", item.ShipGuid);
                CsqlI(ref sql, "ProfilGuid", item.ProfilGuid);
                CsqlI(ref sql, "Name", item.Name);
                CsqlI(ref sql, "[Order]", order);
                CsqlI(ref sql, "[HoursPrYear]", item.HoursPrYear);
                CsqlI(ref sql, "[NumberGenerator]", item.NumberGenerator);
            }
            else
            {
                ShipOperationModeItem itemOld = new();
                AccountLogOnInfoItem logonInfo = new();
                logonInfo.Parameters.filter = "OperationModeGuid='" + item.OperationModeGuid + "'";
                itemOld = GetShipOperationModeInternal(logonInfo);

                sql = "UPDATE OperationModes SET WHERE OperationModeGuid='" + item.OperationModeGuid + "'";
                CsqlU(ref sql, "Name", item.Name, itemOld.Name);
                CsqlU(ref sql, "[Order]", item.Order, itemOld.Order);
                CsqlU(ref sql, "[HoursPrYear]", item.HoursPrYear, itemOld.HoursPrYear);
                CsqlU(ref sql, "[NumberGenerator]", item.NumberGenerator, itemOld.NumberGenerator);
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
                retur.Status = 20;
                retur.Description = ex.Message;
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("GetShipOperationMode")]
        [HttpPost]
        public string GetShipOperationMode(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT OperationModeGuid, ShipGuid, Name, [Order], HoursPrYear, NumberGenerator FROM OperationModes WHERE " + logonInfo.Parameters.filter;

            ShipOperationModeItem item = new();

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
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HoursPrYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumberGenerator"))) { item.NumberGenerator = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("NumberGenerator"))); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }


        [Route("RemoveShipOperationMode")]
        [HttpPost]
        public string RemoveShipOperationMode(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "DELETE FROM OperationModes WHERE " + logonInfo.Parameters.filter;
            sql += ";DELETE FROM GeneratorModes WHERE " + logonInfo.Parameters.filter;
            sql += ";DELETE FROM EquipmentModes WHERE " + logonInfo.Parameters.filter;

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


        [Route("GetShipOperationModeList")]
        [HttpPost]
        public string GetShipOperationModeList(AccountLogOnInfoItem logonInfo)
        {

            string conString;

            string sql = "SELECT OM.OperationModeGuid, Name, [Order], HoursPrYear, OM.NumberGenerator, OMP.OperationModeProfileGuid, OMP.NumberGenerator NG, OMP.ProfilGuid " +
                "FROM OperationModes OM LEFT OUTER JOIN OperationModeProfile OMP ON OM.OperationModeGuid=OMP.OperationModeGuid AND OMP.ProfilGuid='" + logonInfo.Parameters.fieldValue + "'";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipOperationModeItem> items = new();

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
                ShipOperationModeItem item = new();
                if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeProfileGuid"))) { item.OperationModeProfileGuid = rdr.GetString(rdr.GetOrdinal("OperationModeProfileGuid")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HoursPrYear"))); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("NumberGenerator"))) { item.NumberGenerator = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("NumberGenerator"))); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("NG"))) { item.NumberGenerator = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("NG"))); }
                items.Add(item);
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        #endregion

        #region Equipments

            [Route("SetShipEquipment")]
            [HttpPost]
            public string SetShipEquipment(ShipEquipmentItem item)
            {

                string conString;
                string sql = "";
                ReturnValueItem retur = new();

                if (item.EquipmentGuid == null)
                {
                    string EquipmentGuid = Guid.NewGuid().ToString();
                    sql = "INSERT INTO Equipment() VALUES()";
                    CsqlI(ref sql, "Equipmentguid", EquipmentGuid);
                    CsqlI(ref sql, "ShipGuid", item.ShipGuid);
                    CsqlI(ref sql, "ProfilGuid", item.ProfilGuid);
                    CsqlI(ref sql, "Name", item.Name);
                    CsqlI(ref sql, "Model", item.Model);
                    CsqlI(ref sql, "Description", item.Description);
                    CsqlI(ref sql, "EquipmentType", item.EquipmentType);
                    CsqlI(ref sql, "Maxeffect", item.MaxEffect);
                    CsqlI(ref sql, "[Order]", item.Order);
                    CsqlI(ref sql, "Cost", item.Cost);
                    CsqlI(ref sql, "FinancielSupport", item.FinancielSupport);
                    CsqlI(ref sql, "Active", item.Active);
                    CsqlI(ref sql, "Year", item.Year);
                    CsqlI(ref sql, "MaintenanceCode", item.MaintenanceCode);
                }
                else
                {
                    ShipEquipmentItem itemOld = new();
                    itemOld = GetShipEquipmentInternal(item.logonInfo, item.EquipmentGuid);
                    sql = "UPDATE Equipment SET WHERE EquipmentGuid='" + item.EquipmentGuid + "'";
                    CsqlU(ref sql, "ProfilGuid", item.ProfilGuid, itemOld.ProfilGuid);
                    CsqlU(ref sql, "Name", item.Name, itemOld.Name);
                    CsqlU(ref sql, "Model", item.Model, itemOld.Model);
                    CsqlU(ref sql, "Description", item.Description, itemOld.Description);
                    CsqlU(ref sql, "EquipmentType", item.EquipmentType, itemOld.EquipmentType);
                    CsqlU(ref sql, "Maxeffect", item.MaxEffect, itemOld.MaxEffect);
                    CsqlU(ref sql, "[Order]", item.Order, itemOld.Order);
                    CsqlU(ref sql, "Cost", item.Cost, itemOld.Cost);
                    CsqlU(ref sql, "FinancielSupport", item.FinancielSupport, itemOld.FinancielSupport);
                    CsqlU(ref sql, "Active", item.Active, itemOld.Active);
                    CsqlU(ref sql, "Year", item.Year, itemOld.Year);
                    CsqlU(ref sql, "MaintenanceCode", item.MaintenanceCode, itemOld.MaintenanceCode);
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
                    e.Message = ex.Message;
                    e.ErrorCode = 10;
                    retur.Success = false;
                    retur.Error.Add(e);
                    transaction.Rollback();
                }

                string output = JsonConvert.SerializeObject(retur);

                return output;
            }

            private ShipEquipmentItem GetShipEquipmentInternal(AccountLogOnInfoItem logonInfo, string EquipmentGuid)
            {

                string conString;
                string sql = "SELECT EquipmentGuid, ShipGuid, Name, Model, Description, EquipmentType, MaxEffect, [Order], Cost, FinancielSupport, Active, Year, MaintenanceCode FROM Equipment ";
                sql += " WHERE EquipmentGuid='" + EquipmentGuid + "'"; 

                ShipEquipmentItem item = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        if (rdr.Read())
                        {
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentGuid"))) { item.EquipmentGuid = rdr.GetString(rdr.GetOrdinal("EquipmentGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Model"))) { item.Model = rdr.GetString(rdr.GetOrdinal("Model")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Description"))) { item.Description = rdr.GetString(rdr.GetOrdinal("Description")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentType"))) { item.EquipmentType = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("EquipmentType"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("MaxEffect"))) { item.MaxEffect = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("MaxEffect"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Cost"))) { item.Cost = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Cost"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Financielsupport"))) { item.FinancielSupport = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("FinancielSupport"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Year"))) { item.Year = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Year"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCode"))) { item.MaintenanceCode = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("MaintenanceCode"))); }
                        }
                    }
                }

                return item;
            }


            [Route("GetShipEquipment")]
            [HttpPost]
            public string GetShipEquipment(AccountLogOnInfoItem logonInfo)
            {

                string conString;
                string sql = "SELECT EquipmentGuid, ShipGuid, ProfilGuid, Name, Model, Description, EquipmentType, MaxEffect, [Order], Cost, FinancielSupport, Active, Year, MaintenanceCode FROM Equipment ";
                if (logonInfo.Parameters.filter != null) { sql += " WHERE " + logonInfo.Parameters.filter; }

                ShipEquipmentItem item = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        if (rdr.Read())
                        {
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentGuid"))) { item.EquipmentGuid = rdr.GetString(rdr.GetOrdinal("EquipmentGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Model"))) { item.Model = rdr.GetString(rdr.GetOrdinal("Model")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Description"))) { item.Description = rdr.GetString(rdr.GetOrdinal("Description")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentType"))) { item.EquipmentType = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("EquipmentType"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("MaxEffect"))) { item.MaxEffect = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("MaxEffect"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Cost"))) { item.Cost = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Cost"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Financielsupport"))) { item.FinancielSupport = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("FinancielSupport"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Year"))) { item.Year = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Year"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCode"))) { item.MaintenanceCode = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("MaintenanceCode"))); }
                        
                        }
                    }
                }

                string output = JsonConvert.SerializeObject(item);

                return output;
            }

            [Route("RemoveShipEquipment")]
            [HttpPost]
            public string RemoveShipEquipment(AccountLogOnInfoItem logonInfo)
            {

                string conString;
                string sql = "DELETE FROM Equipment WHERE " + logonInfo.Parameters.filter;

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


            [Route("GetShipEquipmentList")]
            [HttpPost]
            public string GetShipEquipmentList(AccountLogOnInfoItem logonInfo)
            {

                string conString;

                string sql = "SELECT EquipmentGuid, ProfilGuid, Name, Model, Description, EquipmentType, MaxEffect, [Order], Cost, FinancielSupport, Active, Year, MaintenanceCode FROM Equipment";
                if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
                if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

                List<ShipEquipmentItem> items = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            ShipEquipmentItem item = new();
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentGuid"))) { item.EquipmentGuid = rdr.GetString(rdr.GetOrdinal("EquipmentGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Model"))) { item.Model = rdr.GetString(rdr.GetOrdinal("Model")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Description"))) { item.Description = rdr.GetString(rdr.GetOrdinal("Description")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentType"))) { item.EquipmentType = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("EquipmentType"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("MaxEffect"))) { item.MaxEffect = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("MaxEffect"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Cost"))) { item.Cost = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Cost"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Financielsupport"))) { item.FinancielSupport = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("FinancielSupport"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Year"))) { item.Year = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Year"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCode"))) { item.MaintenanceCode = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("MaintenanceCode"))); }
                        
                            items.Add(item);
                        }
                    }
                }

                string output = JsonConvert.SerializeObject(items);

                return output;
            }



            #endregion

        #region Fuel savings

            [Route("GetShipEquipmentTypeList")]
            [HttpPost]
            public string GetShipEquipmentTypeList(AccountLogOnInfoItem logonInfo)
            {

                string conString;

                string sql = "SELECT Type, Name FROM EquipmentTypes";
                if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
                if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

                List<ShipEquipmentTypeItem> items = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            ShipEquipmentTypeItem item = new();
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Type"))) { item.Type = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Type"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                            items.Add(item);
                        }
                    }
                }

                string output = JsonConvert.SerializeObject(items);

                return output;
            }


            [Route("GetShipEquipmentModesList")]
            [HttpPost]
            public string GetShipEquipmentModesList(AccountLogOnInfoItem logonInfo)
            {

                string conString;

                string sql = "SELECT EM.EquipmentModesGuid, E.EquipmentGuid, OM.OperationModeGuid, OM.Name, OM.HoursPrYear, EM.HoursBefore, EM.PercentLoad, EM.HoursAfter, EM.PercentSaving, E.MaxEffect " +
                    "FROM OperationModes OM INNER JOIN Equipment E ON OM.ShipGuid=E.ShipGuid LEFT OUTER JOIN EquipmentModes EM ON OM.OperationModeGUID=EM.OperationModeGuid AND E.EquipmentGuid=EM.EquipmentGuid ";
                if (logonInfo.Parameters.field != "") { sql += logonInfo.Parameters.field; }
                if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
                if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

                List<ShipEquipmentModesItem> items = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            ShipEquipmentModesItem item = new();
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentModesGuid"))) { item.EquipmentModesGuid = rdr.GetString(rdr.GetOrdinal("EquipmentModesGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentGuid"))) { item.EquipmentGuid = rdr.GetString(rdr.GetOrdinal("EquipmentGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = rdr.GetInt32(rdr.GetOrdinal("HoursPrYear")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("HoursBefore"))) { item.HoursBefore = rdr.GetInt16(rdr.GetOrdinal("HoursBefore")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("PercentLoad"))) { item.PercentLoad = rdr.GetDecimal(rdr.GetOrdinal("PercentLoad")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("HoursAfter"))) { item.HoursAfter = rdr.GetInt16(rdr.GetOrdinal("HoursAfter")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("PercentSaving"))) { item.PercentSaving = rdr.GetDecimal(rdr.GetOrdinal("PercentSaving")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("MaxEffect"))) { item.MaxEffect = rdr.GetDecimal(rdr.GetOrdinal("MaxEffect")); }
                            items.Add(item);
                        }
                    }
                }

                string output = JsonConvert.SerializeObject(items);

                return output;
            }



            [Route("GetShipEquipmentModes")]
            [HttpPost]
            public ShipEquipmentModesItem GetShipEquipmentModes(AccountLogOnInfoItem logonInfo)
            {

                string conString;
                string sql = "SELECT EquipmentModesGuid, EquipmentGuid, OperationModeGuid, HoursBefore, PercentLoad, HoursAfter, PercentSaving FROM EquipmentModes ";
                if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
                if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

                ShipEquipmentModesItem item = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        if (rdr.Read())
                        {
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentModesGuid"))) { item.EquipmentModesGuid = rdr.GetString(rdr.GetOrdinal("EquipmentModesGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentGuid"))) { item.EquipmentGuid = rdr.GetString(rdr.GetOrdinal("EquipmentGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("HoursBefore"))) { item.HoursBefore = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HoursBefore"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("PercentLoad"))) { item.PercentLoad = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("PercentLoad"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("HoursAfter"))) { item.HoursAfter = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HoursAfter"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("PercentSaving"))) { item.PercentSaving = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("PercentSaving"))); }
                        }
                    }
                }

                return item;
            }


            [Route("SetShipEquipmentModes")]
            [HttpPost]
            public string SetShipEquipmentModes(ShipEquipmentModesItem item)
            {

                string conString;
                string sql = "";
                ReturnValueItem retur = new();

                if (item.EquipmentModesGuid == null)
                {
                    string EquipmentModesGuid = Guid.NewGuid().ToString();

                    sql = "INSERT INTO EquipmentModes() Values()";
                    CsqlI(ref sql, "EquipmentModesGuid", EquipmentModesGuid);
                    CsqlI(ref sql, "EquipmentGuid", item.EquipmentGuid);
                    CsqlI(ref sql, "OperationModeGuid", item.OperationModeGuid);
                    CsqlI(ref sql, "ProfilGuid", item.ProfilGuid);
                    CsqlI(ref sql, "HoursBefore", item.HoursBefore);
                    CsqlI(ref sql, "PercentLoad", item.PercentLoad);
                    CsqlI(ref sql, "HoursAfter", item.HoursAfter);
                    CsqlI(ref sql, "PercentSaving", item.PercentSaving);

                }
                else
                {
                    ShipEquipmentModesItem itemOld = new();
                    AccountLogOnInfoItem logonInfo = new();
                    logonInfo = item.logonInfo;
                    logonInfo.Parameters.filter = "EquipmentModesGuid='" + item.EquipmentModesGuid + "'";
                    itemOld = GetShipEquipmentModes(logonInfo);
                    sql = "UPDATE EquipmentModes SET WHERE EquipmentModesGuid='" + item.EquipmentModesGuid + "'";
                    CsqlU(ref sql, "HoursBefore", item.HoursBefore, itemOld.HoursBefore);
                    CsqlU(ref sql, "PercentLoad", item.PercentLoad, itemOld.PercentLoad);
                    CsqlU(ref sql, "HoursAfter", item.HoursAfter, itemOld.HoursAfter);
                    CsqlU(ref sql, "PercentSaving", item.PercentSaving, itemOld.PercentSaving);
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

                string output = JsonConvert.SerializeObject(retur);

                return output;
            }


            [Route("GetShipFuelSavingsInfo")]
            [HttpPost]
            public string GetShipFuelSavingsInfo(AccountLogOnInfoItem logonInfo)
            {
                string conString;

                string sql = "SELECT ShipGuid, Effect, Savings FROM ShipFuelSavings";
                if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
                if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

                ShipFuleSavingsInfoItem item = new();

                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        if (rdr.Read())
                        {
                            if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Effect"))) { item.Effect = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Effect"))); }
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Savings"))) { item.Savings = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Savings"))); }
                        }
                    }
                }

                string output = JsonConvert.SerializeObject(item);

                return output;
            }



        [Route("GetShipOperationFuelSavingsInfo")]
        [HttpPost]
        public string GetShipOperationFuelSavingsInfo(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ShipGuid, Effect, Savings FROM ShipOperationFuelSavings WHERE ShipGuid='" + logonInfo.Parameters.fieldValue + "'";
            if (logonInfo.Parameters.filter != "") { sql += logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            ShipFuleSavingsInfoItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Effect"))) { item.Effect += Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Effect"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Savings"))) { item.Savings += Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Savings"))); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        #endregion

        #region Generators

        [Route("GetShipGeneratorList")]
        [HttpPost]
        public string GetShipGeneratorList(AccountLogOnInfoItem logonInfo)
        {

            string conString;

            string sql = "SELECT G.GeneratorGuid, G.ShipGuid, G.PowerProduction, GEI.ProfilGuid, G.Name, G.[Order], G.kW, G.KgDieselkWh, GEI.EffectBefore, GEI.EffectAfter, GEI.Faktor, ";
            sql += "MaintenanceCost=(SELECT Sum(GEN.MaintenanceCost * (EM.HoursBefore - EM.HoursAfter)) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid AND GEN.GeneratorGuid = EM.GeneratorGuid " +
                    " AND " + logonInfo.Parameters.fieldValue + "  " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid), ";
            sql += "FuelBefore=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentLoad / 100 * FuelB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid), ";
            sql += "FuelAfter=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * FuelA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid), ";
            sql += "CO2Before=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf, ";
            sql += "CO2After=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf, ";
            sql += "NOxBefore=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentSaving / 100 * FaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.NOx, ";
            sql += "NOxAfter=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.NOx, ";
            sql += "SOxBefore=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentSaving / 100 * FaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.SOx,";
            sql += "SOxAfter=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.SOx ";
            sql += "FROM Generators AS G INNER JOIN FuelType F ON G.FuelTypeGuid=F.FuelTypeGuid LEFT OUTER JOIN GeneratorEffectInfo AS GEI ON G.GeneratorGuid = GEI.GeneratorGuid ";
            if (logonInfo.Parameters.field != "") { sql += logonInfo.Parameters.field; }
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipGeneratorItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ShipGeneratorItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("kW"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = rdr.GetDouble(rdr.GetOrdinal("KgDieselkWh")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = Convert.ToInt32(rdr.GetDouble(rdr.GetOrdinal("MaintenanceCost"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectBefore"))) { item.EffectBefore = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("EffectBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectAfter"))) { item.EffectAfter = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("EffectAfter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Faktor"))) { item.Faktor = rdr.GetDouble(rdr.GetOrdinal("Faktor")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelBefore"))) { item.FuelBefore = rdr.GetDouble(rdr.GetOrdinal("FuelBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelAfter"))) { item.FuelAfter = rdr.GetDouble(rdr.GetOrdinal("FuelAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2Before"))) { item.CO2Before = rdr.GetDouble(rdr.GetOrdinal("CO2Before")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2After"))) { item.CO2After = rdr.GetDouble(rdr.GetOrdinal("CO2After")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxBefore"))) { item.NOxBefore = rdr.GetDouble(rdr.GetOrdinal("NOxBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxAfter"))) { item.NOxAfter = rdr.GetDouble(rdr.GetOrdinal("NOxAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxBefore"))) { item.SOxBefore = rdr.GetDouble(rdr.GetOrdinal("SOxBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxAfter"))) { item.SOxAfter = rdr.GetDouble(rdr.GetOrdinal("SOxAfter")); }
                        if (!item.PowerProduction)
                        {
                            item.EffectBefore = 0;
                            item.EffectAfter = 0;
                        }
                        items.Add(item);
                    }
                }

            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetShipGeneratorModesSummaryListe")]
        [HttpPost]
        public string GetShipGeneratorModesSummaryListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT OM.Name, HoursPrYear, " +
                "MaintenanceCost = (SELECT Sum(G.MaintenanceCost * (GM.HoursBefore - GM.HoursAfter))  FROM Generators G INNER JOIN GeneratorModes GM ON G.GeneratorGuid=GM.GeneratorGuid WHERE MaintenanceCost>0 AND ProfilGuid = '" + logonInfo.Parameters.fieldValue + "' AND OperationModeGuid=OM.OperationModeGuid)," +
                "EffectBefore = (SELECT Sum(CAST(GM.HoursBefore AS float) * G.kW * G.EfficientMotorSwitchboard * GM.PercentLoad / 100) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid WHERE OperationModeGuid=OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "')," +
                "EffectAfter = (SELECT Sum(CAST(GM.HoursAfter AS float) * G.kW * G.EfficientMotorSwitchboard * GM.PercentSaving / 100) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid WHERE GM.Active=1 AND OperationModeGuid=OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "')," +
                "FuelBefore = (SELECT SUM(CAST(GM.HoursBefore AS float) * kW * PercentLoad / 100 * FuelB / 1000) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "FuelAfter = (SELECT SUM(CAST(GM.HoursAfter AS float) * kW * PercentSaving / 100 * FuelA / 1000) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND Active=1 AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "CO2Before = (SELECT SUM(CAST(GM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000 * Cf) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "CO2After = (SELECT SUM(CAST(GM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000 * Cf) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND Active=1 AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "NOxBefore = (SELECT SUM(CAST(GM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000 * NOx) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "NOxAfter = (SELECT SUM(CAST(GM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000 * NOx) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND Active=1 AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "SOxBefore = (SELECT SUM(CAST(GM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000 * SOx) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "SOxAfter = (SELECT SUM(CAST(GM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000 * SOx) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND Active=1 AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "') " +
                "FROM OperationModes OM "; 

            if (logonInfo.Parameters.filter == "" && logonInfo.ShipGuid != "")
            {
                sql += "WHERE OM.ShipGuid = '" + logonInfo.ShipGuid + "'";
            }
            else
            {
                sql += "WHERE OM.OperationModeGuid = '" + logonInfo.Parameters.filter + "'";
            }

            ShipGeneratorModesSummaryItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = (int)rdr.GetInt32(rdr.GetOrdinal("HoursPrYear")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost += rdr.GetDouble(rdr.GetOrdinal("MaintenanceCost")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectBefore"))) { item.EffectBefore += rdr.GetDouble(rdr.GetOrdinal("EffectBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectAfter"))) { item.EffectAfter += rdr.GetDouble(rdr.GetOrdinal("EffectAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelBefore"))) { item.FuelBefore += rdr.GetDouble(rdr.GetOrdinal("FuelBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelAfter"))) { item.FuelAfter += rdr.GetDouble(rdr.GetOrdinal("FuelAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2Before"))) { item.CO2Before += rdr.GetDouble(rdr.GetOrdinal("CO2Before")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2After"))) { item.CO2After += rdr.GetDouble(rdr.GetOrdinal("CO2After")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxBefore"))) { item.NOxBefore += rdr.GetDouble(rdr.GetOrdinal("NOxBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxAfter"))) { item.NOxAfter += rdr.GetDouble(rdr.GetOrdinal("NOxAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxBefore"))) { item.SOxBefore += rdr.GetDouble(rdr.GetOrdinal("SOxBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxAfter"))) { item.SOxAfter += rdr.GetDouble(rdr.GetOrdinal("SOxAfter")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        private ShipGeneratorModesSummaryItem GetShipGeneratorModesSummaryListeInternal(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT OM.Name, HoursPrYear, " +
                "MaintenanceCost = (SELECT Sum(G.MaintenanceCost * (GM.HoursBefore - GM.HoursAfter))  FROM Generators G INNER JOIN GeneratorModes GM ON G.GeneratorGuid=GM.GeneratorGuid WHERE MaintenanceCost>0 AND ProfilGuid = '" + logonInfo.Parameters.fieldValue + "' AND OperationModeGuid=OM.OperationModeGuid)," +
                "EffectBefore = (SELECT Sum(CAST(GM.HoursBefore AS float) * G.kW * G.EfficientMotorSwitchboard * GM.PercentLoad / 100) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid WHERE OperationModeGuid=OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "')," +
                "EffectAfter = (SELECT Sum(CAST(GM.HoursAfter AS float) * G.kW * G.EfficientMotorSwitchboard * GM.PercentSaving / 100) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid WHERE GM.Active=1 AND OperationModeGuid=OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "')," +
                "FuelBefore = (SELECT SUM(CAST(GM.HoursBefore AS float) * kW * PercentLoad / 100 * FuelB / 1000) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "FuelAfter = (SELECT SUM(CAST(GM.HoursAfter AS float) * kW * PercentSaving / 100 * FuelA / 1000) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND Active=1 AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "CO2Before = (SELECT SUM(CAST(GM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000 * Cf) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "CO2After = (SELECT SUM(CAST(GM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000 * Cf) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND Active=1 AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "NOxBefore = (SELECT SUM(CAST(GM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000 * NOx) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "NOxAfter = (SELECT SUM(CAST(GM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000 * NOx) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND Active=1 AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "SOxBefore = (SELECT SUM(CAST(GM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000 * SOx) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "'), " +
                "SOxAfter = (SELECT SUM(CAST(GM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000 * SOx) FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid INNER JOIN GeneratorKgDieselFaktor GKF ON GM.GeneratorModesGuid = GKF.GeneratorModesGuid WHERE OperationModeGuid = OM.OperationModeGuid AND Active=1 AND ProfilGuid='" + logonInfo.Parameters.fieldValue + "') " +
                "FROM OperationModes OM ";

            if (logonInfo.Parameters.filter == "" && logonInfo.ShipGuid != "")
            {
                sql += "WHERE OM.ShipGuid = '" + logonInfo.ShipGuid + "'";
            }
            else
            {
                sql += "WHERE OM.OperationModeGuid = '" + logonInfo.Parameters.filter + "'";
            }


            ShipGeneratorModesSummaryItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = (int)rdr.GetInt32(rdr.GetOrdinal("HoursPrYear")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost += rdr.GetDouble(rdr.GetOrdinal("MaintenanceCost")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectBefore"))) { item.EffectBefore += rdr.GetDouble(rdr.GetOrdinal("EffectBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectAfter"))) { item.EffectAfter += rdr.GetDouble(rdr.GetOrdinal("EffectAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelBefore"))) { item.FuelBefore += rdr.GetDouble(rdr.GetOrdinal("FuelBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelAfter"))) { item.FuelAfter += rdr.GetDouble(rdr.GetOrdinal("FuelAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2Before"))) { item.CO2Before += rdr.GetDouble(rdr.GetOrdinal("CO2Before")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2After"))) { item.CO2After += rdr.GetDouble(rdr.GetOrdinal("CO2After")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxBefore"))) { item.NOxBefore += rdr.GetDouble(rdr.GetOrdinal("NOxBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxAfter"))) { item.NOxAfter += rdr.GetDouble(rdr.GetOrdinal("NOxAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxBefore"))) { item.SOxBefore += rdr.GetDouble(rdr.GetOrdinal("SOxBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxAfter"))) { item.SOxAfter += rdr.GetDouble(rdr.GetOrdinal("SOxAfter")); }
                    }
                }
            }

            return item;
        }


        private List<ShipGeneratorItem> CreateShipGeneratorList(AccountLogOnInfoItem logonInfo)
        {

            string conString;

            string sql = "SELECT G.GeneratorGuid, G.ShipGuid, G.PowerProduction, GEI.ProfilGuid, G.Name, G.[Order], G.kW, G.KgDieselkWh, GEI.EffectBefore, GEI.EffectAfter, GEI.Faktor, ";
            sql += "MaintenanceCost=(SELECT Sum(GEN.MaintenanceCost * (EM.HoursBefore - EM.HoursAfter)) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid AND GEN.GeneratorGuid = EM.GeneratorGuid " +
                    " AND " + logonInfo.Parameters.fieldValue + "  " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid), ";
            sql += "FuelBefore=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid), ";
            sql += "FuelAfter=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid), ";
            sql += "CO2Before=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf * F.DensityMGO, ";
            sql += "CO2After=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf * F.DensityMGO, ";
            sql += "NOxBefore=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentSaving / 100 * NoXFaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf * F.DensityMGO, ";
            sql += "NOxAfter=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * NoXFaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf * F.DensityMGO, ";
            sql += "SOxBefore=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentSaving / 100 * SoXFaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf * F.DensityMGO ,";
            sql += "SOxAfter=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * SoXFaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf * F.DensityMGO ";
            sql += "FROM Generators AS G INNER JOIN FuelType F ON G.FuelTypeGuid=F.FuelTypeGuid LEFT OUTER JOIN GeneratorEffectInfo AS GEI ON G.GeneratorGuid = GEI.GeneratorGuid ";
            if (logonInfo.Parameters.field != "") { sql += logonInfo.Parameters.field; }
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipGeneratorItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ShipGeneratorItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("kW"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("MaintenanceCost"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectBefore"))) { item.EffectBefore = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("EffectBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectAfter"))) { item.EffectAfter = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("EffectAfter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Faktor"))) { item.Faktor = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Faktor"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelBefore"))) { item.FuelBefore = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("FuelBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelAfter"))) { item.FuelAfter = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("FuelAfter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2Before"))) { item.CO2Before = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("CO2Before"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2After"))) { item.CO2After = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("CO2After"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxBefore"))) { item.NOxBefore = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("NOxBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxAfter"))) { item.NOxAfter = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("NOxAfter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxBefore"))) { item.SOxBefore = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("SOxBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxAfter"))) { item.SOxAfter = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("SOxAfter"))); }
                        if (!item.PowerProduction)
                        {
                            item.EffectBefore = 0;
                            item.EffectAfter = 0;
                        }
                        items.Add(item);
                    }
                }

            }

            return items;
        }


        [Route("SetShipGenerator")]
        [HttpPost]
        public string SetShipGenerator(ShipGeneratorItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            ReturnValueItem retur = new();

            if (item.GeneratorGuid == null || item.GeneratorGuid == "")
            {
                string GeneratorGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO Generators() Values()";
                CsqlI(ref sql, "GeneratorGuid", GeneratorGuid);
                CsqlI(ref sql, "ShipGuid", item.ShipGuid);
                CsqlI(ref sql, "Name", item.Name);
                CsqlI(ref sql, "[Order]", item.Order);
                CsqlI(ref sql, "FuelTypeGuid", item.FuelTypeGuid);
                CsqlI(ref sql, "TypeGuid", item.TypeGuid);
                CsqlI(ref sql, "kW", item.kW);
                CsqlI(ref sql, "KgDieselkWh", item.KgDieselkWh);
                CsqlI(ref sql, "FuelPrice", item.FuelPrice);
                CsqlI(ref sql, "EfficientMotorSwitchboard", item.EfficientMotorSwitchboard);
                CsqlI(ref sql, "MaintenanceCost", item.MaintenanceCost);
                CsqlI(ref sql, "PowerProduction", item.PowerProduction);
                CsqlI(ref sql, "ExcludeAutoTune", item.ExcludeAutoTune);                
            }
            else
            {
                ShipGeneratorItem itemOld = new();
                itemOld = GetShipGeneratorInternal(logonInfo, item.GeneratorGuid);
                sql = "UPDATE Generators SET WHERE GeneratorGuid='" + item.GeneratorGuid + "'";
                CsqlU(ref sql, "Name", item.Name, itemOld.Name);
                CsqlU(ref sql, "[Order]", item.Order, itemOld.Order);
                CsqlU(ref sql, "FuelTypeGuid", item.FuelTypeGuid, itemOld.FuelTypeGuid);
                CsqlU(ref sql, "TypeGuid", item.TypeGuid, itemOld.TypeGuid);
                CsqlU(ref sql, "kW", item.kW, itemOld.kW);
                CsqlU(ref sql, "KgDieselkWh", item.KgDieselkWh, itemOld.KgDieselkWh);
                CsqlU(ref sql, "FuelPrice", item.FuelPrice, itemOld.FuelPrice);
                CsqlU(ref sql, "EfficientMotorSwitchboard", item.EfficientMotorSwitchboard, itemOld.EfficientMotorSwitchboard);
                CsqlU(ref sql, "MaintenanceCost", item.MaintenanceCost, itemOld.MaintenanceCost);
                CsqlU(ref sql, "PowerProduction", item.PowerProduction, itemOld.PowerProduction);
                CsqlU(ref sql, "ExcludeAutoTune", item.ExcludeAutoTune, itemOld.ExcludeAutoTune);
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
                retur.Success = false;
                e.Message = ex.Message;
                e.ErrorCode = 20;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("GetShipGenerator")]
        [HttpPost]
        public string GetShipGenerator(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT GeneratorGuid, ShipGuid, Name, [Order], FuelTypeGuid, TypeGuid, kW, KgDieselkWh, FuelPrice, EfficientMotorSwitchboard, MaintenanceCost, PowerProduction, ExcludeAutoTune FROM Generators ";
            if (logonInfo.Parameters.filter != null) { sql += " WHERE " + logonInfo.Parameters.filter; }

            ShipGeneratorItem item = new();

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
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("kW"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelPrice"))) { item.FuelPrice = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("FuelPrice"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EfficientMotorSwitchboard"))) { item.EfficientMotorSwitchboard = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("EfficientMotorSwitchboard"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("MaintenanceCost"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ExcludeAutoTune"))) { item.ExcludeAutoTune = rdr.GetBoolean(rdr.GetOrdinal("ExcludeAutoTune")); }
                        
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }



        [Route("RemoveShipGenerator")]
        [HttpPost]
        public string RemoveShipGenerator(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "DELETE FROM Generators WHERE " + logonInfo.Parameters.filter;
            sql += "DELETE FROM GeneratorModes WHERE " + logonInfo.Parameters.filter;

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


        private ShipGeneratorItem GetShipGeneratorInternal(AccountLogOnInfoItem logonInfo, string generatorGuid)
        {

            string conString;
            string sql = "SELECT GeneratorGuid, ShipGuid, Name, FuelTypeGuid, TypeGuid, kW, KgDieselkWh, EfficientMotorSwitchboard, MaintenanceCost, PowerProduction, ExcludeAutoTune FROM Generators WHERE GeneratorGuid='" + generatorGuid + "'";

            ShipGeneratorItem item = new();

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
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("kW"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelTypeGuid"))) { item.FuelTypeGuid = rdr.GetString(rdr.GetOrdinal("FuelTypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("TypeGuid"))) { item.TypeGuid = rdr.GetString(rdr.GetOrdinal("TypeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EfficientMotorSwitchboard"))) { item.EfficientMotorSwitchboard = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("EfficientMotorSwitchboard"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("MaintenanceCost"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ExcludeAutoTune"))) { item.ExcludeAutoTune = rdr.GetBoolean(rdr.GetOrdinal("ExcludeAutoTune")); }
                    }
                }
            }

            return item;
        }

        
        [Route("GetShipGeneratorModesList")]
        [HttpPost]
        public string GetShipGeneratorModesList(AccountLogOnInfoItem logonInfo)
        {

            string conString;

            string sql = "SELECT EM.GeneratorModesGuid, EM.ProfilGuid, G.KgDieselkWh, G.GeneratorGuid, G.PowerProduction, G.MaintenanceCost * (EM.HoursBefore - EM.HoursAfter) AS MaintenanceCost, OM.OperationModeGuid, " +
                "OM.Name, OM.HoursPrYear, EM.HoursBefore, EM.PercentLoad, EM.HoursAfter, CAST(EM.HoursBefore AS float) * kW * PercentLoad / 100 EffectBefore, CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 EffectAfter, " +
                "EM.PercentSaving, G.kW, GKF.KgDieselKwhB,GKF.KgDieselKwhA, CAST(EM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000 AS FuelBefore, CAST(EM.HoursAfter AS float) *kW * PercentSaving / 100 * FaktorA / 1000 AS FuelAfter, OM.[Order] " +
                "FROM OperationModes AS OM INNER JOIN Generators AS G ON OM.ShipGuid = G.ShipGuid LEFT OUTER JOIN " +
                "GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid AND G.GeneratorGuid = EM.GeneratorGuid ";
            sql += logonInfo.Parameters.field;
            sql += " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid ";
    
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipGeneratorModesItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ShipGeneratorModesItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModesGuid"))) { item.GeneratorModesGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModesGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HoursPrYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursBefore"))) { item.HoursBefore = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HoursBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentLoad"))) { item.PercentLoad = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("PercentLoad"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursAfter"))) { item.HoursAfter = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HoursAfter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentSaving"))) { item.PercentSaving = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("PercentSaving"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("kW"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("MaintenanceCost"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectBefore"))) { item.EffectBefore = Convert.ToDouble(rdr.GetValue(rdr.GetOrdinal("EffectBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectAfter"))) { item.EffectAfter = Convert.ToDouble(rdr.GetValue(rdr.GetOrdinal("EffectAfter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselKwhB"))) { item.KgDieselKwhB = Convert.ToDouble(rdr.GetValue(rdr.GetOrdinal("KgDieselKwhB"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselKwhA"))) { item.KgDieselKwhA = Convert.ToDouble(rdr.GetValue(rdr.GetOrdinal("KgDieselKwhA"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelBefore"))) { item.FuelBefore = Convert.ToDouble(rdr.GetValue(rdr.GetOrdinal("FuelBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelAfter"))) { item.FuelAfter = Convert.ToDouble(rdr.GetValue(rdr.GetOrdinal("FuelAfter"))); }
                        if (!item.PowerProduction)
                        {
                            item.EffectBefore = 0;
                            item.EffectAfter = 0;
                        }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("GetShipGeneratorModesShortListe")]
        [HttpPost]
        public string GetShipGeneratorModesShortListe(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GeneratorModesGuid, G.GeneratorGuid, OperationModeGuid, ProfilGuid, PercentLoad, PercentSaving, HoursBefore, HoursAfter, Active, ActiveBefore, G.Name, G.kW, ExcludeAutoTune "; 
            sql += "FROM Generators G LEFT OUTER JOIN GeneratorModes GM ON GM.GeneratorGuid = G.GeneratorGuid ";
            if (logonInfo.Parameters.fieldValue != "")
            {
                sql += logonInfo.Parameters.fieldValue + " ";
            }
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipGeneratorModesShortItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipGeneratorModesShortItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModesGuid"))) { item.GeneratorModesGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModesGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = rdr.GetInt32(rdr.GetOrdinal("kW")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentLoad"))) { item.PercentLoad = rdr.GetDecimal(rdr.GetOrdinal("PercentLoad")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentSaving"))) { item.PercentSaving = rdr.GetDecimal(rdr.GetOrdinal("PercentSaving")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursBefore"))) { item.HoursBefore = rdr.GetInt16(rdr.GetOrdinal("HoursBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursAfter"))) { item.HoursAfter = rdr.GetInt16(rdr.GetOrdinal("HoursAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ActiveBefore"))) { item.ActiveBefore = rdr.GetBoolean(rdr.GetOrdinal("ActiveBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ExcludeAutoTune"))) { item.ExcludeAutoTune = rdr.GetBoolean(rdr.GetOrdinal("ExcludeAutoTune")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        private List<ShipGeneratorModesShortItem> GetShipGeneratorModesShortListeInternal(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GeneratorModesGuid, GM.GeneratorGuid, OperationModeGuid, ProfilGuid, PercentLoad, PercentSaving, HoursBefore, HoursAfter, Active, ActiveBefore, ExcludeAutoTune ";
            sql += "FROM GeneratorModes  GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            sql += " ORDER BY G.[Order]";

            List<ShipGeneratorModesShortItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipGeneratorModesShortItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModesGuid"))) { item.GeneratorModesGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModesGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentLoad"))) { item.PercentLoad = rdr.GetDecimal(rdr.GetOrdinal("PercentLoad")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentSaving"))) { item.PercentSaving = rdr.GetDecimal(rdr.GetOrdinal("PercentSaving")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursBefore"))) { item.HoursBefore = rdr.GetInt16(rdr.GetOrdinal("HoursBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursAfter"))) { item.HoursAfter = rdr.GetInt16(rdr.GetOrdinal("HoursAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ActiveBefore"))) { item.ActiveBefore = rdr.GetBoolean(rdr.GetOrdinal("ActiveBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ExcludeAutoTune"))) { item.ExcludeAutoTune = rdr.GetBoolean(rdr.GetOrdinal("ExcludeAutoTune")); }
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        private List<ShipGeneratorModesShortItem> GetShipGeneratorModesListeInternal(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT GeneratorModesGuid, G.GeneratorGuid, OperationModeGuid, ProfilGuid, PercentLoad, PercentSaving, HoursBefore, HoursAfter, Active, ActiveBefore, ExcludeAutoTune ";
            sql += "FROM Generators G LEFT OUTER JOIN GeneratorModes GM ON G.GeneratorGuid=GM.GeneratorGuid AND " + logonInfo.Parameters.filter;
            if (logonInfo.ShipGuid != "") { sql += " WHERE ShipGuid='" + logonInfo.ShipGuid + "'"; }
            sql += " ORDER BY G.[Order]";

            List<ShipGeneratorModesShortItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipGeneratorModesShortItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModesGuid"))) { item.GeneratorModesGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModesGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentLoad"))) { item.PercentLoad = rdr.GetDecimal(rdr.GetOrdinal("PercentLoad")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentSaving"))) { item.PercentSaving = rdr.GetDecimal(rdr.GetOrdinal("PercentSaving")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursBefore"))) { item.HoursBefore = rdr.GetInt16(rdr.GetOrdinal("HoursBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursAfter"))) { item.HoursAfter = rdr.GetInt16(rdr.GetOrdinal("HoursAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ActiveBefore"))) { item.ActiveBefore = rdr.GetBoolean(rdr.GetOrdinal("ActiveBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ExcludeAutoTune"))) { item.ExcludeAutoTune = rdr.GetBoolean(rdr.GetOrdinal("ExcludeAutoTune")); }
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        private ShipGeneratorModesItem GetShipGeneratorModesInternal(AccountLogOnInfoItem logonInfo, string GeneratorModesGuid)
        {

            string conString;
            string sql = "SELECT GeneratorModesGuid, GeneratorGuid, OperationModeGuid, HoursBefore, PercentLoad, HoursAfter, PercentSaving, Active, ActiveBefore FROM GeneratorModes WHERE GeneratorModesGuid='" + GeneratorModesGuid + "'";

            ShipGeneratorModesItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModesGuid"))) { item.GeneratorModesGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModesGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursBefore"))) { item.HoursBefore = rdr.GetInt16(rdr.GetOrdinal("HoursBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentLoad"))) { item.PercentLoad = rdr.GetDecimal(rdr.GetOrdinal("PercentLoad")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursAfter"))) { item.HoursAfter = rdr.GetInt16(rdr.GetOrdinal("HoursAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentSaving"))) { item.PercentSaving = rdr.GetDecimal(rdr.GetOrdinal("PercentSaving")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ActiveBefore"))) { item.ActiveBefore = rdr.GetBoolean(rdr.GetOrdinal("ActiveBefore")); }
                    }
                }
            }

            return item;
        }


        [Route("GetShipGeneratorModes")]
        [HttpPost]
        public ShipGeneratorModesItem GetShipGeneratorModes(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT GeneratorModesGuid, GeneratorGuid, OperationModeGuid, HoursBefore, PercentLoad, HoursAfter, PercentSaving, Active, ActiveBefore FROM GeneratorModes ";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            ShipGeneratorModesItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModesGuid"))) { item.GeneratorModesGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModesGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursBefore"))) { item.HoursBefore = rdr.GetInt16(rdr.GetOrdinal("HoursBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentLoad"))) { item.PercentLoad = rdr.GetDecimal(rdr.GetOrdinal("PercentLoad")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursAfter"))) { item.HoursAfter = rdr.GetInt16(rdr.GetOrdinal("HoursAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentSaving"))) { item.PercentSaving = rdr.GetDecimal(rdr.GetOrdinal("PercentSaving")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Active"))) { item.Active = rdr.GetBoolean(rdr.GetOrdinal("Active")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ActiveBefore"))) { item.ActiveBefore = rdr.GetBoolean(rdr.GetOrdinal("ActiveBefore")); }
                    }
                }
            }

            return item;
        }


        [Route("GetShipGeneratorLoad")]
        [HttpPost]
        public ShipGeneratorModesItem GetShipGeneratorLoad(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT TOP 1 GeneratorModesGuid, GM.GeneratorGuid, OperationModeGuid, HoursBefore, PercentLoad, HoursAfter, PercentSaving " +
                "FROM GeneratorModes GM INNER JOIN Generators G ON GM.GeneratorGuid=G.GeneratorGuid WHERE PercentSaving > 0 AND PowerProduction = 1 ";
            if (logonInfo.Parameters.filter != "") { sql += " AND " + logonInfo.Parameters.filter; }
            sql += " ORDER BY ExcludeAutoTune DESC, PercentSaving DESC";

            ShipGeneratorModesItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorModesGuid"))) { item.GeneratorModesGuid = rdr.GetString(rdr.GetOrdinal("GeneratorModesGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursBefore"))) { item.HoursBefore = rdr.GetInt16(rdr.GetOrdinal("HoursBefore")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentLoad"))) { item.PercentLoad = rdr.GetDecimal(rdr.GetOrdinal("PercentLoad")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursAfter"))) { item.HoursAfter = rdr.GetInt16(rdr.GetOrdinal("HoursAfter")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PercentSaving"))) { item.PercentSaving = rdr.GetDecimal(rdr.GetOrdinal("PercentSaving")); }
                    }
                }
            }

            return item;
        }


        [Route("SetShipGeneratorModes")]
        [HttpPost]
        public string SetShipGeneratorModes(ShipGeneratorModesItem item)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            if (item.GeneratorModesGuid == null || item.GeneratorModesGuid == "")
            {
                string GeneratorModesGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO GeneratorModes() Values()";
                CsqlI(ref sql, "GeneratorModesGuid", GeneratorModesGuid);
                CsqlI(ref sql, "GeneratorGuid", item.GeneratorGuid);
                CsqlI(ref sql, "OperationModeGuid", item.OperationModeGuid);
                CsqlI(ref sql, "ProfilGuid", item.ProfilGuid);
                CsqlI(ref sql, "HoursBefore", item.HoursBefore);
                CsqlI(ref sql, "PercentLoad", item.PercentLoad);
                CsqlI(ref sql, "HoursAfter", item.HoursAfter);
                CsqlI(ref sql, "PercentSaving", item.PercentSaving);
                CsqlI(ref sql, "Active", item.Active);
                CsqlI(ref sql, "ActiveBefore", item.ActiveBefore);

            }
            else
            {
                ShipGeneratorModesItem itemOld = new();
                AccountLogOnInfoItem logonInfo = new();
                logonInfo = item.logonInfo;
                logonInfo.Parameters.filter = "GeneratorModesGuid='" + item.GeneratorModesGuid + "'";
                itemOld = GetShipGeneratorModes(logonInfo);
                sql = "UPDATE GeneratorModes SET WHERE GeneratorModesGuid='" + item.GeneratorModesGuid + "'";
                CsqlU(ref sql, "HoursBefore", item.HoursBefore, itemOld.HoursBefore);
                CsqlU(ref sql, "PercentLoad", item.PercentLoad, itemOld.PercentLoad);
                CsqlU(ref sql, "HoursAfter", item.HoursAfter, itemOld.HoursAfter);
                CsqlU(ref sql, "PercentSaving", item.PercentSaving, itemOld.PercentSaving);
                CsqlU(ref sql, "Active", item.Active, itemOld.Active);
                CsqlU(ref sql, "ActiveBefore", item.ActiveBefore, itemOld.ActiveBefore);
            }

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlTransaction transaction = cnn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sql, cnn);
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


            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("SetShipGeneratorModesList")]
        [HttpPost]
        public string SetShipGeneratorModesList(ShipGeneratorModesListItem item)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            if (item.UpdateMode == 0)
            {
                sql = "UPDATE GeneratorModes SET ActiveBefore=" + Convert.ToInt16(item.Active) + " WHERE GeneratorModesGuid='" + item.GeneratorModesGuid + "'";
            }
            if (item.UpdateMode == 1) { 
                sql = "UPDATE GeneratorModes SET Active=" + Convert.ToInt16(item.Active) + ", HoursAfter=" + item.HoursAfter + " WHERE GeneratorModesGuid='" + item.GeneratorModesGuid + "'";
                }
            else if (item.UpdateMode == 2)
                {
                sql = "UPDATE GeneratorModes SET PercentLoad=" + item.PercentLoad.ToString().Replace(",", ".") + " WHERE OperationModeGuid='" + item.OperationModeGuid + "'";
                }
            else if (item.UpdateMode == 3)
                {
                sql = "UPDATE GeneratorModes SET PercentSaving=" + item.PercentLoad.ToString().Replace(",",".") + " WHERE OperationModeGuid='" + item.OperationModeGuid + "' AND GeneratorGuid IN (SELECT GeneratorGuid FROM Generators WHERE ExcludeAutoTune=0)";
                }

            if (item.ProfilGuid != null && item.ProfilGuid.Length>0)
                {
                sql += " AND ProfilGuid='" + item.ProfilGuid + "'";
                }
            else
                {
                sql += " AND ProfilGuid IS NULL";
                }

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlTransaction transaction = cnn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sql, cnn);
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


            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }



        [Route("RemoveShipGeneratorMode")]
        [HttpPost]
        public string RemoveShipGeneratorMode(ShipGeneratorModesListItem item)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "DELETE FROM GeneratorModes WHERE GeneratorModesGuid='" + item.GeneratorModesGuid + "'";

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlTransaction transaction = cnn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sql, cnn);
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


            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("AutoTune")]
        [HttpPost]
        public string AutoTune(AutoTuneParameteritem item)
        {

            string conString;
            string sql = "";
            bool canAutotune = true;
            //int numberGenerator = 0;
            ReturnValueItem retur = new();

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

            //if(item.MinNumberGenerator > 0)
            //{
            //    numberGenerator = ReadValue(item.logonInfo, "SELECT COUNT(*) FROM GeneratorModes WHERE OperationModeGUid='" + item.OperationModeGuid + "' AND Active=1", 0);
            //    if (numberGenerator < item.MinNumberGenerator)
            //    {
            //        ErrorItem e = new();
            //        e.ErrorCode = -9;
            //        e.Message = "To few active generator for this operation mode";
            //        retur.Error.Add(e);
            //        canAutotune = false;
            //    }
            //}



            if (canAutotune)
            {

                item.logonInfo.Parameters.filter = "OperationModeGuid='" + item.OperationModeGuid + "' ";
                if (item.ProfilGuid != null)
                {
                    item.logonInfo.Parameters.filter += " AND ProfilGuid='" + item.ProfilGuid + "'";
                }
                else
                {
                    item.logonInfo.Parameters.filter += " AND ProfilGuid IS NULL";
                }
                
                item.logonInfo.Parameters.order = "G.[Order]";

                List<ShipGeneratorModesShortItem> itemOM = GetShipGeneratorModesListeInternal(item.logonInfo);
                int iCount = 0;
                int hoursBefore = 0;
                int hoursAfter = 0;
                string generatorGuid = "";

                foreach (ShipGeneratorModesShortItem s in itemOM)
                {
                    ShipGeneratorModesListItem itemSGML = new();
                    if (s.ExcludeAutoTune == false)
                    {
                        if (s.HoursAfter > hoursAfter) { hoursAfter = s.HoursAfter; }
                        if (s.HoursBefore > hoursBefore) { hoursBefore = s.HoursBefore; }
                    }
                }

                foreach (ShipGeneratorModesShortItem s in itemOM)
                {
                    ShipGeneratorModesListItem itemSGML = new();
                    if (s.ExcludeAutoTune == false) { 
                        if (s.Active == false && s.ActiveBefore == false && s.GeneratorModesGuid != "")
                        {
                            itemSGML.GeneratorModesGuid = s.GeneratorModesGuid;
                            RemoveShipGeneratorMode(itemSGML);                        
                        }
                        else if (s.GeneratorModesGuid != "")
                        {                        
                            itemSGML.UpdateMode = 1;
                            itemSGML.GeneratorModesGuid = s.GeneratorModesGuid;
                            itemSGML.ProfilGuid = s.ProfilGuid;
                            itemSGML.Active = false;
                            if (s.HoursAfter == 0 ) 
                            { itemSGML.HoursAfter = hoursAfter; }
                            else {
                                itemSGML.HoursAfter = s.HoursAfter;
                                    }
                            generatorGuid = s.GeneratorGuid;
                            SetShipGeneratorModesList(itemSGML);
                            iCount++;
                        }
                    }
                    else if (s.Active == true && s.HoursAfter > 0)
                    {
                        iCount++;
                    }
                }

                if (iCount < item.MinNumberGenerator)
                {
                    foreach (ShipGeneratorModesShortItem s in itemOM)
                    {
                        ShipGeneratorModesItem itemSGML = new();

                        if (s.GeneratorModesGuid == "" && iCount < item.MinNumberGenerator && s.ExcludeAutoTune == false)
                        {
                            itemSGML.GeneratorGuid = s.GeneratorGuid;
                            itemSGML.ProfilGuid = item.ProfilGuid;
                            itemSGML.OperationModeGuid = item.OperationModeGuid;
                            itemSGML.HoursBefore = hoursBefore;
                            itemSGML.HoursAfter = hoursAfter;
                            itemSGML.PercentLoad = 0;
                            itemSGML.PercentSaving = 0;
                            itemSGML.Active = true;
                            itemSGML.ActiveBefore = false;
                            SetShipGeneratorModes(itemSGML);
                            iCount++;
                        }
                    }
                }

                itemOM = GetShipGeneratorModesShortListeInternal(item.logonInfo);

                iCount = 0;
                foreach (ShipGeneratorModesShortItem s in itemOM)
                {
                    ReturnValueItem rv = new();
                    
                    if (s.ExcludeAutoTune == false)
                    {
                        ShipGeneratorModesListItem itemSGML = new();
                        itemSGML.UpdateMode = 1;
                        itemSGML.GeneratorModesGuid = s.GeneratorModesGuid;
                        itemSGML.ProfilGuid = s.ProfilGuid;
                        itemSGML.Active = true;
                        if (s.HoursAfter == 0)
                        { itemSGML.HoursAfter = hoursAfter; }
                        else
                        { itemSGML.HoursAfter = s.HoursAfter; }
                        SetShipGeneratorModesList(itemSGML);
                        iCount++;
                    }
                    else if (s.Active == true && s.HoursAfter > 0)
                    {
                        iCount++;
                    }


                    if (iCount >= item.MinNumberGenerator) { 
                        rv = AutoTuneLoad(item.logonInfo, s.OperationModeGuid, s.ProfilGuid, 85, 10, item.NecesseryPP);

                        if  (rv.Success)
                        {
                            retur = rv;
                            break;
                        }
                    }
                }

                item.logonInfo.Parameters.filter = "OperationModeGuid='" + item.OperationModeGuid + "'  AND ExcludeAutoTune=0 ";
                if (item.ProfilGuid != null)
                {
                    item.logonInfo.Parameters.filter += " AND ProfilGuid='" + item.ProfilGuid + "'";
                }
                else
                {
                    item.logonInfo.Parameters.filter += " AND ProfilGuid IS NULL";
                }

                item.logonInfo.Parameters.order = "G.[Order]";

                itemOM = GetShipGeneratorModesListeInternal(item.logonInfo);

                foreach (ShipGeneratorModesShortItem s in itemOM)
                {
                    if (!s.Active && !s.ExcludeAutoTune)
                    {
                        ShipGeneratorModesItem itemSGML = new();
                        itemSGML = GetShipGeneratorModesInternal(item.logonInfo, s.GeneratorModesGuid);
                        itemSGML.HoursAfter = 0;
                        itemSGML.PercentSaving = 0;
                        itemSGML.Active = false;
                        SetShipGeneratorModes(itemSGML);
                    }
                }


            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        private ReturnValueItem AutoTuneLoad(AccountLogOnInfoItem item, string operationModeGuid, string? profilGuid, int maxLoad, int minLoad, int NecesseryPP)
        {
            ReturnValueItem retur = new();
            decimal loadValue = maxLoad;

            string conString = @"server=" + item.Server + ";User Id=" + item.UserId + ";password=" + item.Password + ";database=" + item.Database + ";TrustServerCertificate=True";

            item.Parameters.filter = "OperationModeGuid = '" + operationModeGuid + "' AND ExcludeAutoTune=0 ";
            if (profilGuid != null && profilGuid.Length>0)
            {
                item.Parameters.filter += " AND profilGuid = '" + profilGuid + "'";
            }
            else
            {
                item.Parameters.filter += " AND profilGuid IS NULL";
            }
            item.Parameters.order = "G.[Order]";

            ShipGeneratorModesItem itemSGM = GetShipGeneratorLoad(item);
            if (itemSGM.PercentSaving < maxLoad)
            {
                ShipGeneratorModesListItem itemNL = new();
                itemNL.UpdateMode = 3;
                itemNL.OperationModeGuid = operationModeGuid;
                itemNL.ProfilGuid = profilGuid;
                itemNL.PercentLoad = maxLoad;
                itemNL.logonInfo = item;
                SetShipGeneratorModesList(itemNL);
            }
                        
            item.Parameters.filter = operationModeGuid;
            item.Parameters.fieldValue = profilGuid;
            ShipGeneratorModesSummaryItem itemPP = new ShipGeneratorModesSummaryItem();
            itemPP = GetShipGeneratorModesSummaryListeInternal(item);

            item.Parameters.filter = "OperationModeGuid = '" + operationModeGuid + "' AND ExcludeAutoTune=0 ";
            if (profilGuid != null && profilGuid.Length > 0)
            {
                item.Parameters.filter += " AND profilGuid = '" + profilGuid + "'";
            }
            else
            {
                item.Parameters.filter += " AND profilGuid IS NULL";
            }
            item.Parameters.order = "G.[Order]";
            itemSGM = GetShipGeneratorLoad(item);
            if (itemPP.EffectAfter > NecesseryPP)
            {
                while (itemPP.EffectAfter > NecesseryPP && loadValue > minLoad)
                {
                    item.Parameters.filter = "OperationModeGuid = '" + operationModeGuid + "' AND ExcludeAutoTune=0 ";
                    if (profilGuid != null)
                    {
                        item.Parameters.filter += " AND profilGuid = '" + profilGuid + "'";
                    }
                    else
                    {
                        item.Parameters.filter += " AND profilGuid IS NULL";
                    }
                    itemSGM = GetShipGeneratorLoad(item);
                    ShipGeneratorModesListItem itemNL = new();
                    itemNL.UpdateMode = 3;
                    itemNL.OperationModeGuid = operationModeGuid;
                    itemNL.ProfilGuid = profilGuid;
                    itemNL.PercentLoad = loadValue;
                    itemNL.logonInfo = item;
                    SetShipGeneratorModesList(itemNL);

                    item.Parameters.filter = operationModeGuid;
                    item.Parameters.fieldValue = profilGuid;
                    itemPP = GetShipGeneratorModesSummaryListeInternal(item);

                    loadValue -= 1;
                }
            }

            while (itemPP.EffectAfter < NecesseryPP && loadValue < maxLoad)
            {
                item.Parameters.filter = "OperationModeGuid = '" + operationModeGuid + "' AND ExcludeAutoTune=0 ";
                if (profilGuid != null)
                {
                    item.Parameters.filter += " AND profilGuid = '" + profilGuid + "'";
                }
                else
                {
                    item.Parameters.filter += " AND profilGuid IS NULL";
                }
                item.Parameters.order = "G.[Order]";
                itemSGM = GetShipGeneratorLoad(item);
                ShipGeneratorModesListItem itemNL = new();
                itemNL.UpdateMode = 3;
                itemNL.OperationModeGuid = operationModeGuid;
                itemNL.ProfilGuid = profilGuid;
                itemNL.PercentLoad = loadValue;
                itemNL.logonInfo = item;
                SetShipGeneratorModesList(itemNL);

                item.Parameters.filter = operationModeGuid;
                item.Parameters.fieldValue = profilGuid;
                itemPP = GetShipGeneratorModesSummaryListeInternal(item);

                loadValue = Decimal.Add(loadValue, .1m); ;
            }

            if (itemPP.EffectAfter >= NecesseryPP)
            {
                retur.Description = "Power production set to " + itemPP.EffectAfter.ToString() + " - Necessery: " + NecesseryPP.ToString();
                retur.Success = true;
            }
            else { retur.Success = false; }

            return retur;
        }

        [Route("AutoAdjustment")]
        [HttpPost]
        public string AutoAdjustment(AutoTuneParameteritem item)
        {

            string conString;
            //int numberGenerator = 0;
            ReturnValueItem retur = new();

            conString = @"server=" + item.logonInfo.Server + ";User Id=" + item.logonInfo.UserId + ";password=" + item.logonInfo.Password + ";database=" + item.logonInfo.Database + ";TrustServerCertificate=True";

              
            decimal loadValue = 85;

            item.logonInfo.Parameters.filter = "OperationModeGuid = '" + item.OperationModeGuid + "' AND ExcludeAutoTune=0 ";
            if (item.ProfilGuid != null && item.ProfilGuid.Length > 0)
            {
                item.logonInfo.Parameters.filter += " AND profilGuid = '" + item.ProfilGuid + "'";
            }
            else
            {
                item.logonInfo.Parameters.filter += " AND profilGuid IS NULL";
            }
            item.logonInfo.Parameters.order = "G.[Order]";

            ShipGeneratorModesItem itemSGM = GetShipGeneratorLoad(item.logonInfo);
            if (itemSGM.PercentSaving < 85)
            {
                ShipGeneratorModesListItem itemNL = new();
                itemNL.UpdateMode = 3;
                itemNL.OperationModeGuid = item.OperationModeGuid;
                itemNL.ProfilGuid = item.ProfilGuid;
                itemNL.PercentLoad = 85;
                itemNL.logonInfo = item.logonInfo;
                SetShipGeneratorModesList(itemNL);
            }

            item.logonInfo.Parameters.filter = item.OperationModeGuid;
            item.logonInfo.Parameters.fieldValue = item.ProfilGuid;
            ShipGeneratorModesSummaryItem itemPP = new ShipGeneratorModesSummaryItem();
            itemPP = GetShipGeneratorModesSummaryListeInternal(item.logonInfo   );

            item.logonInfo.Parameters.filter = "OperationModeGuid = '" + item.OperationModeGuid + "' AND ExcludeAutoTune=0 ";
            if (item.ProfilGuid != null && item.ProfilGuid.Length > 0)
            {
                item.logonInfo.Parameters.filter += " AND profilGuid = '" + item.ProfilGuid + "'";
            }
            else
            {
                item.logonInfo.Parameters.filter += " AND profilGuid IS NULL";
            }
            item.logonInfo.Parameters.order = "G.[Order]";
            itemSGM = GetShipGeneratorLoad(item.logonInfo);
            if (itemPP.EffectAfter > item.NecesseryPP)
            {
                while (itemPP.EffectAfter > item.NecesseryPP && loadValue > 10)
                {
                    item.logonInfo.Parameters.filter = "OperationModeGuid = '" + item.OperationModeGuid + "' AND ExcludeAutoTune=0 ";
                    if (item.ProfilGuid != null)
                    {
                        item.logonInfo.Parameters.filter += " AND profilGuid = '" + item.ProfilGuid + "'";
                    }
                    else
                    {
                        item.logonInfo.Parameters.filter += " AND profilGuid IS NULL";
                    }
                    itemSGM = GetShipGeneratorLoad(item.logonInfo);
                    ShipGeneratorModesListItem itemNL = new();
                    itemNL.UpdateMode = 3;
                    itemNL.OperationModeGuid = item.OperationModeGuid;
                    itemNL.ProfilGuid = item.ProfilGuid;
                    itemNL.PercentLoad = loadValue;
                    itemNL.logonInfo = item.logonInfo;
                    SetShipGeneratorModesList(itemNL);

                    item.logonInfo.Parameters.filter = item.OperationModeGuid;
                    item.logonInfo.Parameters.fieldValue = item.ProfilGuid;
                    itemPP = GetShipGeneratorModesSummaryListeInternal(item.logonInfo);

                    loadValue -= 1;
                }
            }

            while (itemPP.EffectAfter < item.NecesseryPP && loadValue < 85)
            {
                item.logonInfo.Parameters.filter = "OperationModeGuid = '" + item.OperationModeGuid + "' AND ExcludeAutoTune=0 ";
                if (item.ProfilGuid != null)
                {
                    item.logonInfo.Parameters.filter += " AND profilGuid = '" + item.ProfilGuid + "'";
                }
                else
                {
                    item.logonInfo.Parameters.filter += " AND profilGuid IS NULL";
                }
                item.logonInfo.Parameters.order = "G.[Order]";
                itemSGM = GetShipGeneratorLoad(item.logonInfo);
                ShipGeneratorModesListItem itemNL = new();
                itemNL.UpdateMode = 3;
                itemNL.OperationModeGuid = item.OperationModeGuid;
                itemNL.ProfilGuid = item.ProfilGuid;
                itemNL.PercentLoad = loadValue;
                itemNL.logonInfo = item.logonInfo;
                SetShipGeneratorModesList(itemNL);

                item.logonInfo.Parameters.filter = item.OperationModeGuid;
                item.logonInfo.Parameters.fieldValue = item.ProfilGuid;
                itemPP = GetShipGeneratorModesSummaryListeInternal(item.logonInfo);

                loadValue = Decimal.Add(loadValue, .1m); ;
            }

            if (itemPP.EffectAfter >= item.NecesseryPP)
            {
                retur.Description = "Power production set to " + itemPP.EffectAfter.ToString() + " - Necessery: " + item.NecesseryPP.ToString();
                retur.Success = true;
            }
            else { retur.Success = false; }


            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("SetShipGeneratorHeatUnit")]
        [HttpPost]
        public string SetShipGeneratorHeatUnit(ShipGeneratorHeatUnitItem item)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            if (item.HeatUnitGuid == null)
            {
                string HeatUnitGuid = Guid.NewGuid().ToString();
                item.HeatUnitGuid = HeatUnitGuid;

                sql = "INSERT INTO GeneratorHeatUnit() VALUES()";
                CsqlI(ref sql, "HeatUnitGuid", item.HeatUnitGuid);
                CsqlI(ref sql, "ShipGuid", item.ShipGuid);
                CsqlI(ref sql, "Name", item.Name);
                CsqlI(ref sql, "kW", item.kW);
                CsqlI(ref sql, "HourPrday", item.HourPrday);
                CsqlI(ref sql, "Factor", item.Factor);
                CsqlI(ref sql, "KgDieselkWh", item.KgDieselkWh);
                CsqlI(ref sql, "EfficientMotorSwitchboard", item.EfficientMotorSwitchboard);
            }
            else
            {
                ShipGeneratorHeatUnitItem itemOld = new();
                itemOld = GetShipGeneratorHeatUnitInternal(item.logonInfo, item.HeatUnitGuid);

                sql = "UPDATE GeneratorHeatUnit SET WHERE HeatUnitGuid='" + item.HeatUnitGuid + "'";

                CsqlU(ref sql, "HeatUnitGuid", item.HeatUnitGuid, itemOld.HeatUnitGuid);
                CsqlU(ref sql, "ShipGuid", item.ShipGuid, itemOld.ShipGuid);
                CsqlU(ref sql, "Name", item.Name, itemOld.Name);
                CsqlU(ref sql, "kW", item.kW, itemOld.kW);
                CsqlU(ref sql, "HourPrday", item.HourPrday, itemOld.HourPrday);
                CsqlU(ref sql, "Factor", item.Factor, itemOld.Factor);
                CsqlU(ref sql, "KgDieselkWh", item.KgDieselkWh, itemOld.KgDieselkWh);
                CsqlU(ref sql, "EfficientMotorSwitchboard", item.EfficientMotorSwitchboard, itemOld.EfficientMotorSwitchboard);
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
                    retur.Status = 20;
                    retur.Description = ex.Message;
                    transaction.Rollback();
                }
            }
            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("GetShipGeneratorHeatUnit")]
        [HttpPost]
        public string GetShipGeneratorHeatUnit(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT HeatUnitGuid, ShipGuid, Name, kW, HourPrday, Factor, KgDieselkWh, EfficientMotorSwitchboard FROM GeneratorHeatUnit ";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }

            ShipGeneratorHeatUnitItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";


            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HeatUnitGuid"))) { item.HeatUnitGuid = rdr.GetString(rdr.GetOrdinal("HeatUnitGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("kW"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HourPrday"))) { item.HourPrday = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HourPrday"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Factor"))) { item.Factor = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Factor"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EfficientMotorSwitchboard"))) { item.EfficientMotorSwitchboard = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("EfficientMotorSwitchboard"))); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }


        private ShipGeneratorHeatUnitItem GetShipGeneratorHeatUnitInternal(AccountLogOnInfoItem logonInfo, string HeatUnitGuid)
        {
            string conString;
            string sql = "SELECT HeatUnitGuid, ShipGuid, Name, kW, HourPrday, Factor, KgDieselkWh, EfficientMotorSwitchboard FROM GeneratorHeatUnit WHERE HeatUnitGuid = '" + HeatUnitGuid + "'";

            ShipGeneratorHeatUnitItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HeatUnitGuid"))) { item.HeatUnitGuid = rdr.GetString(rdr.GetOrdinal("HeatUnitGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("kW"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HourPrday"))) { item.HourPrday = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HourPrday"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Factor"))) { item.Factor = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Factor"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EfficientMotorSwitchboard"))) { item.EfficientMotorSwitchboard = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("EfficientMotorSwitchboard"))); }
                    }
                }
            }
            return item;
        }


        [Route("GetShipGeneratorHeatUnitList")]
        [HttpPost]
        public string GetShipGeneratorHeatUnitList(AccountLogOnInfoItem logonInfo)
        {

            string conString;

            string sql = "SELECT HeatUnitGuid, GeneratorHeatUnit.ShipGuid, GeneratorHeatUnit.Name, kW, HourPrday, Factor, Ship.NumberOfDays, KgDieselkWh , Ship.DensityMGO, " +
                "EfficientMotorSwitchboard, Ship.FuelConsPrYear  " +
                "FROM GeneratorHeatUnit INNER JOIN Ship ON GeneratorHeatUnit.ShipGuid = Ship.ShipGuid";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE Ship." + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipGeneratorHeatUnitItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipGeneratorHeatUnitItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HeatUnitGuid"))) { item.HeatUnitGuid = rdr.GetString(rdr.GetOrdinal("HeatUnitGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("kW"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HourPrday"))) { item.HourPrday = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HourPrday"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Factor"))) { item.Factor = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Factor"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EfficientMotorSwitchboard"))) { item.EfficientMotorSwitchboard = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("EfficientMotorSwitchboard"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("DensityMGO"))) { item.DensityMGO = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("DensityMGO"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumberOfDays"))) { item.NumberOfDays = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("NumberOfDays"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelConsPrYear"))) { item.FuelConsPrYear = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("FuelConsPrYear"))); }

                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetGeneratorFuelComsuptionList")]
        [HttpPost]
        public string GetGeneratorFuelComsuptionList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT FuelConsGuid, LinkGuid, Effect, KgDieselkWh FROM FuelConsumptions";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<GeneratorFuelComsuptionItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        GeneratorFuelComsuptionItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelConsGuid"))) { item.FuelConsGuid = rdr.GetString(rdr.GetOrdinal("FuelConsGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LinkGuid"))) { item.LinkGuid = rdr.GetString(rdr.GetOrdinal("LinkGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Effect"))) { item.Effect = (int)rdr.GetValue(rdr.GetOrdinal("Effect")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = rdr.GetDouble(rdr.GetOrdinal("KgDieselkWh")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetGeneratorFuelComsuptionChart")]
        [HttpPost]
        public string GetGeneratorFuelComsuptionChart(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT Effect, KgDieselkWh FROM FuelConsumptions";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<GeneratorFuelComsuptionChartItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        GeneratorFuelComsuptionChartItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Effect"))) { item.Effect = rdr.GetValue(rdr.GetOrdinal("Effect")).ToString(); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = Convert.ToDouble(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetGeneratorFuelComsuption")]
        [HttpPost]
        public string GetGeneratorFuelComsuption(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT FuelConsGuid, LinkGuid, Effect, KgDieselkWh FROM FuelConsumptions";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            GeneratorFuelComsuptionItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelConsGuid"))) { item.FuelConsGuid = rdr.GetString(rdr.GetOrdinal("FuelConsGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LinkGuid"))) { item.LinkGuid = rdr.GetString(rdr.GetOrdinal("LinkGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Effect"))) { item.Effect = (int)rdr.GetValue(rdr.GetOrdinal("Effect")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = rdr.GetDouble(rdr.GetOrdinal("KgDieselkWh")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetGeneratorFuelComsuption")]
        [HttpPost]
        public string SetGeneratorFuelComsuption(GeneratorFuelComsuptionItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            ReturnValueItem retur = new();
            logonInfo = item.logonInfo;

            if (item.FuelConsGuid == null)
            {
                string FuelConsGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO FuelConsumptions() Values()";

                CsqlI(ref sql, "FuelConsGuid", FuelConsGuid);
                CsqlI(ref sql, "LinkGuid", item.LinkGuid);
                CsqlI(ref sql, "Effect", item.Effect);
                CsqlI(ref sql, "KgDieselkWh", item.KgDieselkWh);

            }
            else
            {
                GeneratorFuelComsuptionItem itemOld = new();
                itemOld = GetGeneratorFuelComsuptionInternal(logonInfo, item.FuelConsGuid);
                sql = "UPDATE FuelConsumptions SET WHERE FuelConsGuid ='" + item.FuelConsGuid  + "'"; 
                CsqlU(ref sql, "Effect", item.Effect, itemOld.Effect);
                CsqlU(ref sql, "KgDieselkWh", item.KgDieselkWh, itemOld.KgDieselkWh);
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
                retur.Success = false;
                e.Message = ex.Message;
                e.ErrorCode = 20;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        private GeneratorFuelComsuptionItem GetGeneratorFuelComsuptionInternal(AccountLogOnInfoItem logonInfo, string FuelConsGuid)
        {
            string conString;

            string sql = "SELECT FuelConsGuid, LinkGuid, Effect, KgDieselkWh FROM FuelConsumptions WHERE FuelConsGuid = '" + FuelConsGuid + "'";

            GeneratorFuelComsuptionItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelConsGuid"))) { item.FuelConsGuid = rdr.GetString(rdr.GetOrdinal("FuelConsGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LinkGuid"))) { item.LinkGuid = rdr.GetString(rdr.GetOrdinal("LinkGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Effect"))) { item.Effect = (int)rdr.GetValue(rdr.GetOrdinal("Effect")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = rdr.GetDouble(rdr.GetOrdinal("KgDieselkWh")); }
                    }
                }
            }

            return item;
        }


        [Route("RemoveGeneratorFuelComsuption")]
        [HttpPost]
        public string RemoveGeneratorFuelComsuption(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();


            sql = "DELETE FROM FuelConsumptions WHERE FuelConsGuid ='" + logonInfo.Parameters.field + "'";

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
                ErrorItem e = new();
                retur.Success = false;
                e.Message = ex.Message;
                e.ErrorCode = 20;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("CopyFromProfile")]
        [HttpPost]
        public string CopyFromProfile(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "DELETE FROM GeneratorModes WHERE " +
                              "OperationModeGuid IN (SELECT OperationModeGuid FROM OperationModes WHERE ShipGuid='" + logonInfo.ShipGuid + "')";
            sql += " AND ProfilGuid = '" + logonInfo.Parameters.field + "'";
            sql += ";INSERT INTO GeneratorModes(GeneratorModesGuid, GeneratorGuid, OperationModeGuid, ProfilGuid, PercentLoad, PercentSaving, HoursBefore, HoursAfter) ";
            sql += "SELECT LOWER(Newid()) GeneratorModesGuid, GeneratorGuid, OperationModeGuid, '" + logonInfo.Parameters.field + "' ProfilGuid, PercentLoad, PercentSaving, HoursBefore, HoursAfter FROM GeneratorModes WHERE " +
                "OperationModeGuid IN (SELECT OperationModeGuid FROM OperationModes WHERE ShipGuid='" + logonInfo.ShipGuid + "')";
            sql += " AND " + logonInfo.Parameters.filter;


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
                ErrorItem e = new();
                retur.Success = false;
                e.Message = ex.Message;
                e.ErrorCode = 20;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("SetActivProfil")]
        [HttpPost]
        public string SetActivProfil(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "UPDATE USERS_SHIP SET ProfilGuid='" + logonInfo.Parameters.fieldValue + "' WHERE UserId='" + logonInfo.UserId + "' AND ShipGuid='" + logonInfo.ShipGuid + "'";

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
                ErrorItem e = new();
                retur.Success = false;
                e.Message = ex.Message;
                e.ErrorCode = 20;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            if (logonInfo.ShipGuid != null) { 
                UserShipProfileItem itmUS = new();
                itmUS.ShipGuid = logonInfo.ShipGuid;
                itmUS.ProfilGuid = logonInfo.Parameters.fieldValue;
                itmUS.logonInfo = logonInfo;

                SetActiveProfile(itmUS);
            }


            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        #endregion

        #region Operation mode & profile

        [Route("GetOperationModeProfile")]
        [HttpPost]
        public string GetOperationModeProfile(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT OperationModeProfileGuid, OperationModeGuid, ProfilGuid, NumberGenerator FROM OperationModeProfile";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            OperationModeProfileItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeProfileGuid"))) { item.OperationModeProfileGuid = rdr.GetString(rdr.GetOrdinal("OperationModeProfileGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumberGenerator"))) { item.NumberGenerator = rdr.GetInt16(rdr.GetOrdinal("NumberGenerator")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }

        [Route("SetOperationModeProfile")]
        [HttpPost]
        public string SetOperationModeProfile(OperationModeProfileItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            ReturnValueItem retur = new();

            logonInfo = item.logonInfo;

            if (item.OperationModeProfileGuid == null || item.OperationModeProfileGuid.Length == 0)
            {
                item.OperationModeProfileGuid = Guid.NewGuid().ToString();

                retur.NewId = item.OperationModeProfileGuid;

                sql = "INSERT INTO OperationModeProfile() Values()";

                CsqlI(ref sql, "OperationModeProfileGuid", item.OperationModeProfileGuid);
                CsqlI(ref sql, "OperationModeGuid", item.OperationModeGuid);
                CsqlI(ref sql, "ProfilGuid", item.ProfilGuid);
                CsqlI(ref sql, "NumberGenerator", item.NumberGenerator);
            }
            else
            {
                OperationModeProfileItem itemOld = new();
                itemOld = GetOperationModeProfileInternal(logonInfo, item.OperationModeProfileGuid);
                sql = "UPDATE OperationModeProfile SET WHERE OperationModeProfileGuid ='" + item.OperationModeProfileGuid+ "'";
                CsqlU(ref sql, "NumberGenerator", item.NumberGenerator, itemOld.NumberGenerator);
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

        private OperationModeProfileItem GetOperationModeProfileInternal(AccountLogOnInfoItem logonInfo, string OperationModeProfileGuid)
        {
            string conString;

            string sql = "SELECT OperationModeProfileGuid, OperationModeGuid, ProfilGuid, NumberGenerator FROM OperationModeProfile WHERE OperationModeProfileGuid = '" + OperationModeProfileGuid + "'";

            OperationModeProfileItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeProfileGuid"))) { item.OperationModeProfileGuid = rdr.GetString(rdr.GetOrdinal("OperationModeProfileGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OperationModeGuid"))) { item.OperationModeGuid = rdr.GetString(rdr.GetOrdinal("OperationModeGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumberGenerator"))) { item.NumberGenerator = rdr.GetInt16(rdr.GetOrdinal("NumberGenerator")); }
                    }
                }
            }

            return item;
        }

        #endregion

        #region Statistikk

        [Route("GetShipOperationPowerList")]
        [HttpPost]
        public string GetShipOperationPowerList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT OM.Name, OM.[Order], OM.HoursPrYear, PowerPre = Sum(CAST(EM.HoursBefore AS float) * G.kW * EM.PercentLoad / 100), PowerPast = Sum(CAST(EM.HoursAfter AS float) * G.kW * EM.PercentSaving / 100) " +
                "FROM OperationModes OM INNER JOIN Generators G ON OM.ShipGuid=G.ShipGuid INNER JOIN GeneratorModes EM ON OM.OperationModeGUID=EM.OperationModeGuid AND G.GeneratorGuid=EM.GeneratorGuid  ";
            if (logonInfo.Parameters.filter != null) { sql += " WHERE G.PowerProduction=1 AND " + logonInfo.Parameters.filter; }
            sql += " GROUP BY OM.Name, OM.[Order], OM.HoursPrYear ";

            if (logonInfo.Parameters.order != null) { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipOperationPowerItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipOperationPowerItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HoursPrYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerPre"))) { item.PowerPre = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("PowerPre"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerPast"))) { item.PowerPast = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("PowerPast"))); }
                        items.Add(item);
                    }
                }

            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetSavingPrModeList")]
        [HttpPost]
        public string GetSavingPrModeList(AccountLogOnInfoItem logonInfo)
        {
            string conString;
            string modes = "";
            List<ShipOperationSavingPowerItem> items = new();

            modes = ReadValue(logonInfo, "SELECT distinct STUFF((SELECT ', [' + Name + ']' FROM OperationModes WHERE " + logonInfo.Parameters.filter + " ORDER BY [Order] FOR XML PATH('')),1,1,'')", "");

            if (!string.IsNullOrEmpty(modes))
            {           
                string sql = "SELECT * FROM ( SELECT OM.Name OpMode, OM.HoursPrYear * EM.PercentLoad * E.MaxEffect / 100 * EM.PercentSaving / 100 Power, ET.Name EqName " +
                        "FROM OperationModes OM INNER JOIN Equipment E ON OM.ShipGuid = E.ShipGuid INNER JOIN EquipmentModes EM ON OM.OperationModeGUID = EM.OperationModeGuid AND E.EquipmentGuid = EM.EquipmentGuid INNER JOIN EquipmentTypes ET ON E.EquipmentType = ET.Type " +
                        "WHERE OM." + logonInfo.Parameters.filter;
                if (logonInfo.Parameters.field != null)
                {
                    sql += logonInfo.Parameters.field;
                }

                sql += ") AS src ";
                sql += "PIVOT( SUM(Power) FOR OpMode IN(" + modes + ")) AS pvt  ";


                conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            ShipOperationSavingPowerItem item = new();
                            if (!rdr.IsDBNull(rdr.GetOrdinal("EqName"))) { item.EquipmentTypeName = rdr.GetString(rdr.GetOrdinal("EqName")); }

                            for (int i = 1; i < rdr.FieldCount; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        if (!rdr.IsDBNull(i)) { item.OperationMode1 = Convert.ToInt32(rdr.GetValue(i)); }
                                        break;

                                    case 2:
                                        if (!rdr.IsDBNull(i)) { item.OperationMode2 = Convert.ToInt32(rdr.GetValue(i)); }
                                        break;

                                    case 3:
                                        if (!rdr.IsDBNull(i)) { item.OperationMode3 = Convert.ToInt32(rdr.GetValue(i)); }
                                        break;

                                    case 4:
                                        if (!rdr.IsDBNull(i)) { item.OperationMode4 = Convert.ToInt32(rdr.GetValue(i)); }
                                        break;

                                    case 5:
                                        if (!rdr.IsDBNull(i)) { item.OperationMode5 = Convert.ToInt32(rdr.GetValue(i)); }
                                        break;

                                    case 6:
                                        if (!rdr.IsDBNull(i)) { item.OperationMode6 = Convert.ToInt32(rdr.GetValue(i)); }
                                        break;

                                    case 7:
                                        if (!rdr.IsDBNull(i)) { item.OperationMode7 = Convert.ToInt32(rdr.GetValue(i)); }
                                        break;

                                    case 8:
                                        if (!rdr.IsDBNull(i)) { item.OperationMode8 = Convert.ToInt32(rdr.GetValue(i)); }
                                        break;

                                    case 9:
                                        if (!rdr.IsDBNull(i)) { item.OperationMode9 = Convert.ToInt32(rdr.GetValue(i)); }
                                        break;

                                }

                            }

                            items.Add(item);
                        }
                    }

                }
            }
            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetShipEquipmentSavingsList")]
        [HttpPost]
        public string GetShipEquipmentSavingsList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ET.Name, SUM(OM.HoursPrYear * EM.PercentLoad * E.MaxEffect / 100) OldConsume, SUM((OM.HoursPrYear * EM.PercentLoad * E.MaxEffect / 100) -((OM.HoursPrYear * EM.PercentLoad * E.MaxEffect / 100) * EM.PercentSaving /100)) NewConsume " +
                "FROM OperationModes OM INNER JOIN Equipment E ON OM.ShipGuid = E.ShipGuid INNER JOIN EquipmentModes EM ON OM.OperationModeGUID = EM.OperationModeGuid AND E.EquipmentGuid = EM.EquipmentGuid INNER JOIN EquipmentTypes ET ON E.EquipmentType = ET.Type   ";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE OM." + logonInfo.Parameters.filter; }
            sql += " GROUP BY ET.Name ";

            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipOperationSavingItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipOperationSavingItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OldConsume"))) { item.OldValue = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("OldConsume"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NewConsume"))) { item.NewValue = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("NewConsume"))); }
                        items.Add(item);
                    }
                }

            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        [Route("GetShipOperationSavingsList")]
        [HttpPost]
        public string GetShipOperationSavingsList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT OM.Name, SUM(OM.HoursPrYear * EM.PercentLoad * E.MaxEffect / 100) OldConsume, SUM((OM.HoursPrYear * EM.PercentLoad * E.MaxEffect / 100) -((OM.HoursPrYear * EM.PercentLoad * E.MaxEffect / 100) * EM.PercentSaving /100)) NewConsume " +
                "FROM OperationModes OM INNER JOIN Equipment E ON OM.ShipGuid = E.ShipGuid INNER JOIN EquipmentModes EM ON OM.OperationModeGUID = EM.OperationModeGuid AND E.EquipmentGuid = EM.EquipmentGuid INNER JOIN EquipmentTypes ET ON E.EquipmentType = ET.Type   ";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE OM." + logonInfo.Parameters.filter; }
            sql += " GROUP BY OM.Name ";

            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipOperationSavingItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ShipOperationSavingItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OldConsume"))) { item.OldValue = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("OldConsume"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NewConsume"))) { item.NewValue = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("NewConsume"))); }
                        items.Add(item);
                    }
                }

            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        #endregion

        #region Plan

        [Route("GetInvestmentPlanList")]
        [HttpPost]
        public string GetInvestmentPlanList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ShipGuid, ProfilGuid, EquipmentGuid, Name, Effect, Savings, InvYear, Cost, FinancielSupport, KgDieselkWh, GenPowerPrLiter, PriceKwh, OilPrice, SavingsYear, EffectCostYear, SavingsCostYear, " +
                "Total = (SELECT Sum(Effect - Savings) FROM EquipmentSavingInfo ESI WHERE shipGuid=EquipmentSavingInfo.shipGuid AND ProfilGuid=EquipmentSavingInfo.ProfilGuid )" +
                "FROM EquipmentSavingInfo";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<InvestmentPlanItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        InvestmentPlanItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentGuid"))) { item.EquipmentGuid = rdr.GetString(rdr.GetOrdinal("EquipmentGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Effect"))) { item.Effect = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Effect"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Savings"))) { item.Savings = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Savings"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Total"))) { item.Total = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Total"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("InvYear"))) { item.InvYear = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("InvYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Cost"))) { item.Cost = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Cost"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FinancielSupport"))) { item.FinancielSupport = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("FinancielSupport"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GenPowerPrLiter"))) { item.GenPowerPrLiter = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("GenPowerPrLiter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PriceKwh"))) { item.PriceKwh = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("PriceKwh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SavingsYear"))) { item.SavingsYear = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("SavingsYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectCostYear"))) { item.EffectCostYear = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("EffectCostYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SavingsCostYear"))) { item.SavingsCostYear = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("SavingsCostYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OilPrice"))) { item.OilPrice = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("OilPrice"))); }

                        item.FuelSaving = 0;
                        item.MaintenaceCost = 0;

                        if (!rdr.IsDBNull(rdr.GetOrdinal("profilGuid"))) 
                        {
                            logonInfo.Parameters.field = " AND GEI.ProfilGuid='" + rdr.GetString(rdr.GetOrdinal("ProfilGuid")) + "' ";
                            logonInfo.Parameters.fieldValue = " EM.ProfilGuid='" + rdr.GetString(rdr.GetOrdinal("ProfilGuid")) + "' ";
                        }
                        else
                        {
                            logonInfo.Parameters.field = " AND GEI.ProfilGuid IS NULL ";
                            logonInfo.Parameters.fieldValue = " EM.ProfilGuid IS NULL ";
                        }

                        List<ShipGeneratorItem> fsItems = new List<ShipGeneratorItem>();
                        fsItems = GetShipFuelSaveInfo(logonInfo);

                        foreach (ShipGeneratorItem fsItem in fsItems)
                        {
                            item.FuelSaving += fsItem.FuelBefore - fsItem.FuelAfter;
                            item.MaintenaceCost += fsItem.MaintenanceCost;
                        }

                        item.SavingsYear = item.FuelSaving * 1000 * item.OilPrice * ((item.Effect - item.Savings) * 100 / item.Total) / 100;

                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("CreateInvestmentPlanList")]
        [HttpPost]
        public string CreateInvestmentPlanList(AccountLogOnInfoItem logonInfo)
        {
            string conString;
            string sql = "";
            string lastProfile = "";
            string Unit = "m3";

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            if (ReadValue(logonInfo, "SELECT UnitOfMeasurement FROM _Ship WHERE ShipGuid='b71d55d0-2c41-46a5-9a9a-48bdb7eb3782'", 0) == 1)
            {
                Unit = "ton";
            }


            sql = "DELETE FROM tmpTable WHERE UserGuid='" + logonInfo.UserId + "'";
            ExecuteSQL(conString, sql);

            sql = "SELECT ShipGuid, P.ProfilGuid, P.Name ProfilName, Sum(Effect) Effect, Sum(Savings) Savings, Sum(Cost) Cost, Sum(FinancielSupport) FinancielSupport, MIN(OilPrice) OilPrice, Sum(SavingsYear) SavingsYear, Sum(EffectCostYear) EffectCostYear, Sum(SavingsCostYear) SavingsCostYear, " +
                          "Total = (SELECT Sum(Effect - Savings) FROM EquipmentSavingInfo ESI WHERE shipGuid = GEI.shipGuid AND ProfilGuid = P.ProfilGuid ), " +
                          "FuelCons = (SELECT FuelConsPrYear FROM Ship WHERE shipGuid = GEI.shipGuid) " +
                          "FROM EquipmentSavingInfo GEI INNER JOIN Profile P ON GEI.ProfilGuid = P.ProfilGuid ";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            sql += " GROUP BY ShipGuid, P.ProfilGuid, P.Name";
            ReturnValueItem retur = new();

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        InvestmentPlanItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilName"))) { item.ProfilName = rdr.GetString(rdr.GetOrdinal("ProfilName")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Effect"))) { item.Effect = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Effect"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Savings"))) { item.Savings = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Savings"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Total"))) { item.Total = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Total"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Cost"))) { item.Cost = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("Cost"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FinancielSupport"))) { item.FinancielSupport = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("FinancielSupport"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SavingsYear"))) { item.SavingsYear = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("SavingsYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectCostYear"))) { item.EffectCostYear = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("EffectCostYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SavingsCostYear"))) { item.SavingsCostYear = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("SavingsCostYear"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("OilPrice"))) { item.OilPrice = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("OilPrice"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelCons"))) { item.FuelCons = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("FuelCons"))); }

                        item.FuelSaving = 0;
                        item.MaintenaceCost = 0;
                        item.CO2Savings = 0;
                        item.NOxSavings = 0;
                        item.SOxSavings = 0;
                        item.kWhSavings = 0;

                        if (!rdr.IsDBNull(rdr.GetOrdinal("profilGuid")))
                        {
                            logonInfo.Parameters.field = " AND GEI.ProfilGuid='" + rdr.GetString(rdr.GetOrdinal("ProfilGuid")) + "' ";
                            logonInfo.Parameters.fieldValue = " EM.ProfilGuid='" + rdr.GetString(rdr.GetOrdinal("ProfilGuid")) + "' ";
                        }
                        else
                        {
                            logonInfo.Parameters.field = " AND GEI.ProfilGuid IS NULL ";
                            logonInfo.Parameters.fieldValue = " EM.ProfilGuid IS NULL ";
                        }

                        List<ShipGeneratorItem> fsItems = new List<ShipGeneratorItem>();
                        fsItems = GetShipFuelSaveInfo(logonInfo);

                        foreach (ShipGeneratorItem fsItem in fsItems)
                        {
                            item.FuelSaving += fsItem.FuelBefore - fsItem.FuelAfter;
                            item.MaintenaceCost += fsItem.MaintenanceCost;
                            item.CO2Savings += fsItem.CO2Before - fsItem.CO2After;
                            item.NOxSavings += fsItem.NOxBefore - fsItem.NOxAfter;
                            item.SOxSavings += fsItem.SOxBefore - fsItem.SOxAfter;
                            item.kWhSavings += fsItem.EffectBefore - fsItem.EffectAfter;
                        }

                        item.SavingsYear = item.FuelSaving * 1000 * item.OilPrice * ((item.Effect - item.Savings) * 100 / item.Total) / 100;

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Value, Ext) VALUES('" + logonInfo.UserId + "',1,'ListOfMesures','" + item.ProfilGuid + "','" + item.ProfilName + "','" + item.Name + "','" + item.SavingsYear.ToString().Replace(",",".") + "','" + logonInfo.Currency + "')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',2,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Calculated savings in kWh each year','" + item.kWhSavings.ToString("N0") + "','kWh')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',3,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Calculated fuel volume saved each year','" + item.FuelSaving.ToString("N0") + "','" + Unit + "')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',4,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Calculated CO2 reduction each year on el.production','" + item.CO2Savings.ToString("N0") + "','ton')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',5,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Calculated NOx reduction each year','" + item.NOxSavings.ToString("N2") + "','ton')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',6,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Estimated SOx reduction each year','" + item.SOxSavings.ToString("N2") + "','kg')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',7,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Estimated soot (PM) reduction each year','" + (item.FuelSaving/10).ToString("N0") + "','kg')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',8,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Reduction of CO2','" + (item.FuelSaving * 100 / item.FuelCons).ToString("N0") + "','%')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',9,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Calculated saved fuel cost','" + item.SavingsYear.ToString("N0") + "','" + logonInfo.Currency + "')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',10,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Saved maintenance cost','" + item.MaintenaceCost.ToString("N0") + "','" + logonInfo.Currency + "')";
                        ExecuteSQL(conString, sql);

                        sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',11,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Estimated investment cost','" + item.Cost.ToString("N0") + "','" + logonInfo.Currency + "')";
                        ExecuteSQL(conString, sql);

                        if (item.SavingsYear > 0 || item.MaintenaceCost > 0)
                        {
                            sql = "INSERT INTO tmpTable(UserGuid, [Order], Id, ProfilGuid, Profile, Name, Price, Ext) VALUES('" + logonInfo.UserId + "',12,'MesuresTable','" + item.ProfilGuid + "','" + item.ProfilName + "','Payback time','" + (Convert.ToInt16((item.Cost / (item.SavingsYear + item.MaintenaceCost)) * 12)) + "','months')";
                            ExecuteSQL(conString, sql);
                        }

                    }
                }
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }

        [Route("GetInvestmentPlanYear")]
        [HttpPost]
        public string GetInvestmentPlanYear(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT * FROM ( SELECT ShipGuid, EquipmentGuid, Name, InvYear, " + logonInfo.Parameters.field + " FROM EquipmentSavingInfo ";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            sql += ") AS src ";
            sql += "PIVOT( SUM(" + logonInfo.Parameters.field + ") FOR InvYear IN([2023], [2024], [2025], [2026], [2027], [2028], [2029], [2030])) AS pvt ";

            List<InvestmentPlanYearItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        InvestmentPlanYearItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EquipmentGuid"))) { item.EquipmentGuid = rdr.GetString(rdr.GetOrdinal("EquipmentGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("2023"))) { item.Year2023 = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("2023"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("2024"))) { item.Year2024 = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("2024"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("2025"))) { item.Year2025 = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("2025"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("2026"))) { item.Year2026 = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("2026"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("2027"))) { item.Year2027 = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("2027"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("2028"))) { item.Year2028 = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("2028"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("2029"))) { item.Year2029 = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("2029"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("2030"))) { item.Year2030 = (float)Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("2030"))); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }


        private List<ShipGeneratorItem> GetShipFuelSaveInfo(AccountLogOnInfoItem logonInfo)
        {

            string conString;

            string sql = "SELECT G.GeneratorGuid, G.ShipGuid, G.PowerProduction, GEI.ProfilGuid, G.Name, G.kW, G.KgDieselkWh, GEI.EffectBefore, GEI.EffectAfter, GEI.Faktor, ";
            sql += "MaintenanceCost=(SELECT Sum(GEN.MaintenanceCost * (EM.HoursBefore - EM.HoursAfter))" +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid AND GEN.GeneratorGuid = EM.GeneratorGuid " +
                    " AND " + logonInfo.Parameters.fieldValue + "  " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid), ";
            sql += "FuelBefore=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentLoad / 100 * FuelB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid), ";
            sql += "FuelAfter=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * FuelA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid), ";
            sql += "CO2Before=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentLoad / 100 * FaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf, ";
            sql += "CO2After=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * FaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf, ";
            sql += "NOxBefore=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentSaving / 100 * NoXFaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf, ";
            sql += "NOxAfter=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * NoXFaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf, ";
            sql += "SOxBefore=(SELECT SUM(CAST(EM.HoursBefore AS float) * kW * PercentSaving / 100 * SoXFaktorB / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf, ";
            sql += "SOxAfter=(SELECT SUM(CAST(EM.HoursAfter AS float) * kW * PercentSaving / 100 * SoXFaktorA / 1000) " +
                    "FROM OperationModes AS OM INNER JOIN Generators AS GEN ON OM.ShipGuid = GEN.ShipGuid LEFT OUTER JOIN GeneratorModes AS EM ON OM.OperationModeGuid = EM.OperationModeGuid " +
                    "AND G.GeneratorGuid = EM.GeneratorGuid  AND " + logonInfo.Parameters.fieldValue + " LEFT OUTER JOIN GeneratorKgDieselFaktor GKF ON EM.GeneratorModesGuid = GKF.GeneratorModesGuid " +
                    "WHERE GEN.GeneratorGuid=G.GeneratorGuid) * F.Cf ";
            sql += "FROM Generators AS G INNER JOIN FuelType F ON G.FuelTypeGuid=F.FuelTypeGuid LEFT OUTER JOIN GeneratorEffectInfo AS GEI ON G.GeneratorGuid = GEI.GeneratorGuid ";
            if (logonInfo.Parameters.field != "") { sql += logonInfo.Parameters.field; }
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ShipGeneratorItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ShipGeneratorItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("GeneratorGuid"))) { item.GeneratorGuid = rdr.GetString(rdr.GetOrdinal("GeneratorGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("PowerProduction"))) { item.PowerProduction = rdr.GetBoolean(rdr.GetOrdinal("PowerProduction")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("kW"))) { item.kW = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("kW"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("KgDieselkWh"))) { item.KgDieselkWh = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("KgDieselkWh"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("MaintenanceCost"))) { item.MaintenanceCost = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("MaintenanceCost"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectBefore"))) { item.EffectBefore = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("EffectBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("EffectAfter"))) { item.EffectAfter = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("EffectAfter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Faktor"))) { item.Faktor = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("Faktor"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelBefore"))) { item.FuelBefore = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("FuelBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("FuelAfter"))) { item.FuelAfter = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("FuelAfter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2Before"))) { item.CO2Before = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("CO2Before"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CO2After"))) { item.CO2After = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("CO2After"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxBefore"))) { item.NOxBefore = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("NOxBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("NOxAfter"))) { item.NOxAfter = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("NOxAfter"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxBefore"))) { item.SOxBefore = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("SOxBefore"))); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SOxAfter"))) { item.SOxAfter = Convert.ToSingle(rdr.GetValue(rdr.GetOrdinal("SOxAfter"))); }
                        if (!item.PowerProduction)
                        {
                            item.EffectBefore = 0;
                            item.EffectAfter = 0;
                        }
                        items.Add(item);
                    }
                }

            }

            return items;
        }


        #endregion

        #region Hjelpefunksjoner

        private ShipOperationModeItem GetShipOperationModeInternal(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "SELECT ShipGuid, Name, [Order], HoursPrYear, NumberGenerator FROM OperationModes WHERE " + logonInfo.Parameters.filter;

            ShipOperationModeItem item = new();

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
                if (!rdr.IsDBNull(rdr.GetOrdinal("ShipGuid"))) { item.ShipGuid = rdr.GetString(rdr.GetOrdinal("ShipGuid")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Order"))) { item.Order = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("Order"))); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("NumberGenerator"))) { item.NumberGenerator = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("NumberGenerator"))); }
                if (!rdr.IsDBNull(rdr.GetOrdinal("HoursPrYear"))) { item.HoursPrYear = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("HoursPrYear"))); }
            }

            return item;
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
                        if (!rdr.IsDBNull(0)) retur = Convert.ToInt16(rdr.GetValue(0));
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

        private void CsqlI(ref string SQLQ, string strField, double fltValue)
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

        private void CsqlI(ref string SQLQ, string strField, decimal fltValue)
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

        private void CsqlU(ref string SQLQ, string strField, double fltValue, double fltOldValue)
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

        private void CsqlU(ref string SQLQ, string strField, decimal fltValue, decimal fltOldValue)
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

        #region Profile

        [Route("SetProfile")]
        [HttpPost]
        public string SetProfile(ProfileItem item)
        {
            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            logonInfo = item.logonInfo;

            ReturnValueItem returnValue = new ReturnValueItem();

            if (item.ProfilGuid == null || item.ProfilGuid == "")
            {
                string ProfilGuid = Guid.NewGuid().ToString();

                sql = "INSERT INTO Profile() Values()";

                CsqlI(ref sql, "ProfilGuid", ProfilGuid);
                CsqlI(ref sql, "LinkGuid", item.LinkGuid);                
                CsqlI(ref sql, "Name", item.Name);
                CsqlI(ref sql, "CreatedBy", item.CreatedBy);
                CsqlI(ref sql, "CreatDate", "T", item.CreatDate);

            }
            else
            {
                ProfileItem itemOld = new();
                itemOld = GetProfileInternal(logonInfo, item.ProfilGuid);
                sql = "UPDATE Profile SET WHERE ProfilGuid='" + item.ProfilGuid + "'"; 
                CsqlU(ref sql, "ProfilGuid", item.ProfilGuid, itemOld.ProfilGuid);
                CsqlU(ref sql, "Name", item.Name, itemOld.Name);
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
                e.Message = ex.Message;
                e.ErrorCode = 20;
                returnValue.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(returnValue);

            return output;
        }

        [Route("GetProfile")]
        [HttpPost]
        public string GetProfile(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ProfilGuid, LinkGuid, Name, CreatedBy, CreatDate FROM Profile";
            sql += " WHERE " + logonInfo.Parameters.filter;

            ProfileItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("LinkGuid"))) { item.LinkGuid = rdr.GetString(rdr.GetOrdinal("LinkGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CreatedBy"))) { item.CreatedBy = rdr.GetString(rdr.GetOrdinal("CreatedBy")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CreatDate"))) { item.CreatDate = rdr.GetDateTime(rdr.GetOrdinal("CreatDate")); }
                    }
                }
            }

            string output = JsonConvert.SerializeObject(item);

            return output;
        }


        private ProfileItem GetProfileInternal(AccountLogOnInfoItem logonInfo, string ProfilGuid)
        {
            string conString;

            string sql = "SELECT ProfilGuid, Name, CreatedBy, CreatDate FROM Profile WHERE ProfilGuid = '" + ProfilGuid + "'";

            ProfileItem item = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CreatedBy"))) { item.CreatedBy = rdr.GetString(rdr.GetOrdinal("CreatedBy")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CreatDate"))) { item.CreatDate = rdr.GetDateTime(rdr.GetOrdinal("CreatDate")); }
                    }
                }
            }

            return item;
        }

        [Route("GetProfileList")]
        [HttpPost]
        public string GetProfileList(AccountLogOnInfoItem logonInfo)
        {
            string conString;

            string sql = "SELECT ProfilGuid, Name, CreatedBy, CreatDate FROM Profile";
            if (logonInfo.Parameters.filter != "") { sql += " WHERE " + logonInfo.Parameters.filter; }
            if (logonInfo.Parameters.order != "") { sql += " ORDER BY " + logonInfo.Parameters.order; }

            List<ProfileItem> items = new();

            conString = @"server=" + logonInfo.Server + ";User Id=" + logonInfo.UserId + ";password=" + logonInfo.Password + ";database=" + logonInfo.Database + ";TrustServerCertificate=True";

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sql, cnn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        ProfileItem item = new();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ProfilGuid"))) { item.ProfilGuid = rdr.GetString(rdr.GetOrdinal("ProfilGuid")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Name"))) { item.Name = rdr.GetString(rdr.GetOrdinal("Name")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CreatedBy"))) { item.CreatedBy = rdr.GetString(rdr.GetOrdinal("CreatedBy")); }
                        if (!rdr.IsDBNull(rdr.GetOrdinal("CreatDate"))) { item.CreatDate = rdr.GetDateTime(rdr.GetOrdinal("CreatDate")); }
                        items.Add(item);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(items);

            return output;
        }

        [Route("SetActiveProfile")]
        [HttpPost]
        public string SetActiveProfile(UserShipProfileItem item)
        {

            string conString;
            string sql = "";
            AccountLogOnInfoItem logonInfo = new();
            ReturnValueItem retur = new();
            logonInfo = item.logonInfo;


            sql = "INSERT INTO UserShipProfil() Values()";


            CsqlI(ref sql, "UserGuid", logonInfo.UserId);
            CsqlI(ref sql, "ShipGuid", item.ShipGuid);
            if (item.ProfilGuid != null) { CsqlI(ref sql, "ProfilGuid", item.ProfilGuid); }

            sql = "DELETE FROM UserShipProfil WHERE UserGuid='" + logonInfo.UserId + "' AND ShipGuid='" + item.ShipGuid + "';" + sql;

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
                retur.Success = false;
                ErrorItem e = new();
                e.Message = ex.Message;
                e.ErrorCode = 10;
                retur.Error.Add(e);
                transaction.Rollback();
            }

            string output = JsonConvert.SerializeObject(retur);

            return output;
        }


        [Route("RemoveProfile")]
        [HttpPost]
        public string RemoveProfile(AccountLogOnInfoItem logonInfo)
        {

            string conString;
            string sql = "";
            ReturnValueItem retur = new();

            sql = "DELETE FROM Equipment WHERE ProfilGuid='" + logonInfo.Parameters.field + "'";
            sql += ";DELETE FROM EquipmentModes WHERE ProfilGuid='" + logonInfo.Parameters.field + "'";
            sql += ";DELETE FROM GeneratorModes WHERE ProfilGuid='" + logonInfo.Parameters.field + "'";
            sql += ";DELETE FROM OperationModes WHERE ProfilGuid='" + logonInfo.Parameters.field + "'";
            sql += ";DELETE FROM Profile WHERE ProfilGuid='" + logonInfo.Parameters.field + "'";
            sql += ";DELETE FROM UserShipProfil WHERE ProfilGuid='" + logonInfo.Parameters.field + "'";

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

        #endregion

    }

}
