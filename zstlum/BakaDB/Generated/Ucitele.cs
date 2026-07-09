using System;
using System.Collections.Generic;

namespace BakaDB;

public partial class Ucitele
{
    public string Titul { get; set; } = null!;

    public string Prijmeni { get; set; } = null!;

    public string Jmeno { get; set; } = null!;

    public string TitulZa { get; set; } = null!;

    public string Zkratka { get; set; } = null!;

    public string OsobCislo { get; set; } = null!;

    public string DatumNar { get; set; } = null!;

    public string RodneC { get; set; } = null!;

    public string Pohlavi { get; set; } = null!;

    public string Funkce { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PracZaraz { get; set; } = null!;

    public bool VychPorad { get; set; }

    public bool Nekvalif { get; set; }

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

    public string TelDomu { get; set; } = null!;

    public string TelMobil { get; set; } = null!;

    public string TelSkolni { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string Web { get; set; } = null!;

    public string StPrisl { get; set; } = null!;

    public string CisloOP { get; set; } = null!;

    public string CisloPasu { get; set; } = null!;

    public DateTime? DatNastup { get; set; }

    public string Poznamka { get; set; } = null!;

    public string Poznamka1 { get; set; } = null!;

    public string Poznamka2 { get; set; } = null!;

    public string Vzdelani { get; set; } = null!;

    public string Aprobace { get; set; } = null!;

    public string AprobZakl { get; set; } = null!;

    public string Specializ { get; set; } = null!;

    public string SpecZnal { get; set; } = null!;

    public string KodZp { get; set; } = null!;

    public DateTime? PrihlOd { get; set; }

    public bool UciLetos { get; set; }

    public decimal UvazkyHod { get; set; }

    public string UvazkySku { get; set; } = null!;

    public decimal PlatTrida { get; set; }

    public decimal PlatStup { get; set; }

    public decimal PlatZaraz { get; set; }

    public decimal PlatZakl { get; set; }

    public decimal PlatPripl { get; set; }

    public decimal PlatOsPr { get; set; }

    public decimal PlatTdn { get; set; }

    public decimal PlatOsCl { get; set; }

    public decimal PlatSpec { get; set; }

    public decimal PlatCelk { get; set; }

    public DateTime? PlatP1 { get; set; }

    public DateTime? PlatP2 { get; set; }

    public string PpDruh { get; set; } = null!;

    public DateTime? PpOd { get; set; }

    public DateTime? PpDo { get; set; }

    public decimal UvazkyPro { get; set; }

    public DateTime? MdOd { get; set; }

    public DateTime? MdDo { get; set; }

    public DateTime? DatDuchod { get; set; }

    public string Stav { get; set; } = null!;

    public string KodMist { get; set; } = null!;

    public decimal Priorita { get; set; }

    public string KodJed { get; set; } = null!;

    public string Manzel { get; set; } = null!;

    public decimal PocetDeti { get; set; }

    public decimal Praxe { get; set; }

    public string PrijRodne { get; set; } = null!;

    public string ZamestMan { get; set; } = null!;

    public string MistoNar { get; set; } = null!;

    public string OkresNar { get; set; } = null!;

    public string TbZuj { get; set; } = null!;

    public string DatSchran { get; set; } = null!;

    public DateTime? Modified { get; set; }

    public string? Modifiedby { get; set; }

    public string IsicTyp { get; set; } = null!;

    public string IsicKarta { get; set; } = null!;

    public string IsicCip { get; set; } = null!;

    public string IsicPlat { get; set; } = null!;

    public DateTime? IsicObjdt { get; set; }

    public DateTime? CovidPoz { get; set; }

    public DateTime? CovidOck { get; set; }

    public DateTime? CovidTest { get; set; }

    public DateTime? CovidOck1 { get; set; }

    public DateTime? CovidOck2 { get; set; }

    public string Heslo { get; set; } = null!;

    public bool DeletedRc { get; set; }

    public string InternKod { get; set; } = null!;

    public string PhotoIds { get; set; } = null!;
}
