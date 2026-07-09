using System;
using System.Collections.Generic;

namespace BakaDB;

public partial class Zaci
{
    public string Trida { get; set; } = null!;

    public decimal CTrVyk { get; set; }

    public string Prijmeni { get; set; } = null!;

    public string Jmeno { get; set; } = null!;

    public DateTime? EvidOd { get; set; }

    public DateTime? EvidDo { get; set; }

    public string Odesel { get; set; } = null!;

    public string OdeselIzo { get; set; } = null!;

    public string KaCobce { get; set; } = null!;

    public string KaCp { get; set; } = null!;

    public bool KaCpchar { get; set; }

    public string KaObec { get; set; } = null!;

    public string KaPsc { get; set; } = null!;

    public string KaStat { get; set; } = null!;

    public string KaUlice { get; set; } = null!;

    public bool KaValid { get; set; }

    public string TbCobce { get; set; } = null!;

    public string TbCp { get; set; } = null!;

    public bool TbCpchar { get; set; }

    public bool TbJine { get; set; }

    public string TbObec { get; set; } = null!;

    public string TbPsc { get; set; } = null!;

    public string TbStat { get; set; } = null!;

    public string TbUlice { get; set; } = null!;

    public bool TbValid { get; set; }

    public string TbOkres { get; set; } = null!;

    public string TbZuj { get; set; } = null!;

    public string DatumNar { get; set; } = null!;

    public string RodneC { get; set; } = null!;

    public string CisloPasu { get; set; } = null!;

    public string CisloOP { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string TelMobil { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string Pohlavi { get; set; } = null!;

    public string MistoNar { get; set; } = null!;

    public string OkresNar { get; set; } = null!;

    public string StPrisl { get; set; } = null!;

    public string Zamereni { get; set; } = null!;

    public string Poznamka { get; set; } = null!;

    public string Poznamka1 { get; set; } = null!;

    public string Poznamka2 { get; set; } = null!;

    public string KodZp { get; set; } = null!;

    public DateTime? PrihlOd { get; set; }

    public decimal StudDelka { get; set; }

    public decimal AbsolvLet { get; set; }

    public string Choroby { get; set; } = null!;

    public string Zdrsku { get; set; } = null!;

    public string Problemy { get; set; } = null!;

    public string Rodina { get; set; } = null!;

    public bool Zps { get; set; }

    public string IzoSs1 { get; set; } = null!;

    public string OborSs1 { get; set; } = null!;

    public string PuvIzo { get; set; } = null!;

    public string PuvPusob { get; set; } = null!;

    public string PuvPozn { get; set; } = null!;

    public string JazykZs { get; set; } = null!;

    public string Odklad { get; set; } = null!;

    public string MatSkola { get; set; } = null!;

    public string CisloVysv { get; set; } = null!;

    public string Prisel { get; set; } = null!;

    public string StPrislK { get; set; } = null!;

    public string PoznSpec { get; set; } = null!;

    public string CisloZkvz { get; set; } = null!;

    public string OdeselPoz { get; set; } = null!;

    public decimal Sd { get; set; }

    public string EvCislo { get; set; } = null!;

    public string IzoSs2 { get; set; } = null!;

    public string IzoSs3 { get; set; } = null!;

    public string OborSs2 { get; set; } = null!;

    public string OborSs3 { get; set; } = null!;

    public string Odeselobor { get; set; } = null!;

    public string DatSchran { get; set; } = null!;

    public DateTime? Modified { get; set; }

    public string? Modifiedby { get; set; }

    public string IsicTyp { get; set; } = null!;

    public string IsicKarta { get; set; } = null!;

    public string IsicCip { get; set; } = null!;

    public string IsicPlat { get; set; } = null!;

    public DateTime? IsicObjdt { get; set; }

    public DateTime? CovidPoz { get; set; }

    public DateTime? CovidTest { get; set; }

    public DateTime? CovidOck { get; set; }

    public DateTime? CovidOck1 { get; set; }

    public DateTime? CovidOck2 { get; set; }

    public string OborSsd1 { get; set; } = null!;

    public string OborSsd2 { get; set; } = null!;

    public string OborSsd3 { get; set; } = null!;

    public string Odeselobo2 { get; set; } = null!;

    public string DruhStud { get; set; } = null!;

    public string TbObvod { get; set; } = null!;

    public string IzoSs4 { get; set; } = null!;

    public string IzoSs5 { get; set; } = null!;

    public string OborSs4 { get; set; } = null!;

    public string OborSs5 { get; set; } = null!;

    public string OborSsd4 { get; set; } = null!;

    public string OborSsd5 { get; set; } = null!;

    public bool DeletedRc { get; set; }

    public string InternKod { get; set; } = null!;

    public string? LoginOut { get; set; }

    public string? VisaNum { get; set; }

    public bool IsCommuter { get; set; }

    public string? Sov { get; set; }

    public string? Mistr { get; set; }

    public string? CisloProt { get; set; }

    public string? CisloDipl { get; set; }

    public string? PuvVzdel { get; set; }

    public string? Titul { get; set; }

    public string? TitulZa { get; set; }

    public string? Rmat { get; set; }

    public string? JazykZs2 { get; set; }

    public string? JazykZs1 { get; set; }

    public string PhotoIds { get; set; } = null!;
}
