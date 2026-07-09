using System;
using System.Collections.Generic;

namespace BakaDB;

public partial class Tridy
{
    public string Zkratka { get; set; } = null!;

    public decimal Rocnik { get; set; }

    public decimal Rocnikg { get; set; }

    public decimal Rocniknast { get; set; }

    public string Nazev { get; set; } = null!;

    public string Fzkratka { get; set; } = null!;

    public decimal Nastup { get; set; }

    public decimal StudDelka { get; set; }

    public string KodStdl { get; set; } = null!;

    public string Tridnictvi { get; set; } = null!;

    public string Tridnizast { get; set; } = null!;

    public DateTime? Zastupod { get; set; }

    public DateTime? Zastupdo { get; set; }

    public string KodTrid { get; set; } = null!;

    public string KodMist { get; set; } = null!;

    public string KodJed { get; set; } = null!;

    public string Izo { get; set; } = null!;

    public string CastSkoly { get; set; } = null!;

    public decimal PocetZaku { get; set; }

    public string DruhStud { get; set; } = null!;

    public string FormaStud { get; set; } = null!;

    public string Specialni { get; set; } = null!;

    public string VzdelProg { get; set; } = null!;

    public string Predmety1 { get; set; } = null!;

    public string KodSpoj { get; set; } = null!;

    public bool IndivInt { get; set; }

    public decimal Priorita { get; set; }

    public string None { get; set; } = null!;

    public string Asistence { get; set; } = null!;

    public DateTime? Modified { get; set; }

    public string? Modifiedby { get; set; }

    public string? Kategorie { get; set; }

    public string? Jazyk { get; set; }
}
