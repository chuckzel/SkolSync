using System;
using System.Collections.Generic;

namespace BakaDB;

public partial class Organiz
{
    public string Nazev { get; set; } = null!;

    public string NazevOfic { get; set; } = null!;

    public string Historie { get; set; } = null!;

    public string Ulice { get; set; } = null!;

    public string Psc { get; set; } = null!;

    public string Obec { get; set; } = null!;

    public string Frazev { get; set; } = null!;

    public string Ico { get; set; } = null!;

    public string Zrizovatel { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string Reditel { get; set; } = null!;

    public string Hospodar { get; set; } = null!;

    public string VlasVztah { get; set; } = null!;

    public decimal PocetObj { get; set; }

    public decimal Postaveno { get; set; }

    public decimal Rekonstruk { get; set; }

    public decimal TridyKmen { get; set; }

    public decimal OdborUceb { get; set; }

    public decimal Telocvicny { get; set; }

    public decimal Dilny { get; set; }

    public decimal Laboratore { get; set; }

    public decimal Hriste { get; set; }

    public string VzdelProg { get; set; } = null!;

    public string Obory { get; set; } = null!;

    public decimal PUcitelu { get; set; }

    public decimal PVychovat { get; set; }

    public decimal PMistrOv { get; set; }

    public decimal PHospod { get; set; }

    public decimal PZastupcu { get; set; }

    public decimal PSekret { get; set; }

    public decimal PSkolnik { get; set; }

    public decimal PUklizec { get; set; }

    public decimal PKuchar { get; set; }

    public decimal PReferent { get; set; }

    public decimal POstatni { get; set; }

    public string Poznamky { get; set; } = null!;

    public string KodOrg { get; set; } = null!;

    public DateTime? Modified { get; set; }

    public string? Modifiedby { get; set; }
}
