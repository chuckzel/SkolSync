using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BakaDB;

public partial class BakalariContext : DbContext
{
    public BakalariContext(DbContextOptions<BakalariContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Organiz> Organiz { get; set; }

    public virtual DbSet<Tridy> Tridy { get; set; }

    public virtual DbSet<Ucitele> Ucitele { get; set; }

    public virtual DbSet<Zaci> Zaci { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organiz>(entity =>
        {
            entity.HasKey(e => e.KodOrg).HasName("PK__organiz__4C3325EE1CC8523C");

            entity.ToTable("organiz", "dbo", tb => tb.HasTrigger("ORGANIZTrigger"));

            entity.Property(e => e.KodOrg)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_ORG");
            entity.Property(e => e.Dilny)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("DILNY");
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("E_MAIL");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("FAX");
            entity.Property(e => e.Frazev)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("FRAZEV");
            entity.Property(e => e.Historie)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("HISTORIE");
            entity.Property(e => e.Hospodar)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("HOSPODAR");
            entity.Property(e => e.Hriste)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("HRISTE");
            entity.Property(e => e.Ico)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ICO");
            entity.Property(e => e.Laboratore)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("LABORATORE");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasDefaultValue("", "DF__organiz__MODIFIE__3E68E952")
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Nazev)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("NAZEV");
            entity.Property(e => e.NazevOfic)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("NAZEV_OFIC");
            entity.Property(e => e.Obec)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBEC");
            entity.Property(e => e.Obory)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("OBORY");
            entity.Property(e => e.OdborUceb)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("ODBOR_UCEB");
            entity.Property(e => e.PHospod)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_HOSPOD");
            entity.Property(e => e.PKuchar)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_KUCHAR");
            entity.Property(e => e.PMistrOv)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_MISTR_OV");
            entity.Property(e => e.POstatni)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_OSTATNI");
            entity.Property(e => e.PReferent)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_REFERENT");
            entity.Property(e => e.PSekret)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_SEKRET");
            entity.Property(e => e.PSkolnik)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_SKOLNIK");
            entity.Property(e => e.PUcitelu)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("P_UCITELU");
            entity.Property(e => e.PUklizec)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_UKLIZEC");
            entity.Property(e => e.PVychovat)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_VYCHOVAT");
            entity.Property(e => e.PZastupcu)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("P_ZASTUPCU");
            entity.Property(e => e.PocetObj)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("POCET_OBJ");
            entity.Property(e => e.Postaveno)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("POSTAVENO");
            entity.Property(e => e.Poznamky)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("POZNAMKY");
            entity.Property(e => e.Psc)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PSC");
            entity.Property(e => e.Reditel)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("REDITEL");
            entity.Property(e => e.Rekonstruk)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("REKONSTRUK");
            entity.Property(e => e.Telefon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TELEFON");
            entity.Property(e => e.Telocvicny)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("TELOCVICNY");
            entity.Property(e => e.TridyKmen)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("TRIDY_KMEN");
            entity.Property(e => e.Ulice)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ULICE");
            entity.Property(e => e.VlasVztah)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("VLAS_VZTAH");
            entity.Property(e => e.VzdelProg)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("VZDEL_PROG");
            entity.Property(e => e.Zrizovatel)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ZRIZOVATEL");
        });

        modelBuilder.Entity<Tridy>(entity =>
        {
            entity.HasKey(e => e.KodTrid).HasName("PK__tridy__A6A6DC32C6110577");

            entity.ToTable("tridy", "dbo", tb => tb.HasTrigger("TRIDYTrigger"));

            entity.Property(e => e.KodTrid)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_TRID");
            entity.Property(e => e.Asistence)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ASISTENCE");
            entity.Property(e => e.CastSkoly)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CAST_SKOLY");
            entity.Property(e => e.DruhStud)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("DRUH_STUD");
            entity.Property(e => e.FormaStud)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("FORMA_STUD");
            entity.Property(e => e.Fzkratka)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("FZKRATKA");
            entity.Property(e => e.IndivInt).HasColumnName("INDIV_INT");
            entity.Property(e => e.Izo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("IZO");
            entity.Property(e => e.Jazyk)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("JAZYK");
            entity.Property(e => e.Kategorie)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KATEGORIE");
            entity.Property(e => e.KodJed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_JED");
            entity.Property(e => e.KodMist)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_MIST");
            entity.Property(e => e.KodSpoj)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_SPOJ");
            entity.Property(e => e.KodStdl)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_STDL");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasDefaultValue("", "DF__tridy__MODIFIEDB__7D053A49")
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Nastup)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("NASTUP");
            entity.Property(e => e.Nazev)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("NAZEV");
            entity.Property(e => e.None)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("NONE");
            entity.Property(e => e.PocetZaku)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("POCET_ZAKU");
            entity.Property(e => e.Predmety1)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("PREDMETY1");
            entity.Property(e => e.Priorita)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("PRIORITA");
            entity.Property(e => e.Rocnik)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("ROCNIK");
            entity.Property(e => e.Rocnikg)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("ROCNIKG");
            entity.Property(e => e.Rocniknast)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("ROCNIKNAST");
            entity.Property(e => e.Specialni)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("SPECIALNI");
            entity.Property(e => e.StudDelka)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("STUD_DELKA");
            entity.Property(e => e.Tridnictvi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TRIDNICTVI");
            entity.Property(e => e.Tridnizast)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TRIDNIZAST");
            entity.Property(e => e.VzdelProg)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("VZDEL_PROG");
            entity.Property(e => e.Zastupdo)
                .HasColumnType("datetime")
                .HasColumnName("ZASTUPDO");
            entity.Property(e => e.Zastupod)
                .HasColumnType("datetime")
                .HasColumnName("ZASTUPOD");
            entity.Property(e => e.Zkratka)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ZKRATKA");
        });

        modelBuilder.Entity<Ucitele>(entity =>
        {
            entity.HasKey(e => e.InternKod).HasName("PK__ucitele__1DA887CB4FB812E0");

            entity.ToTable("ucitele", "dbo", tb => tb.HasTrigger("UCITELETrigger"));

            entity.Property(e => e.InternKod)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("INTERN_KOD");
            entity.Property(e => e.AprobZakl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("APROB_ZAKL");
            entity.Property(e => e.Aprobace)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("APROBACE");
            entity.Property(e => e.CisloOP)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CISLO_O_P");
            entity.Property(e => e.CisloPasu)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CISLO_PASU");
            entity.Property(e => e.CovidOck)
                .HasColumnType("datetime")
                .HasColumnName("COVID_OCK");
            entity.Property(e => e.CovidOck1)
                .HasColumnType("datetime")
                .HasColumnName("COVID_OCK1");
            entity.Property(e => e.CovidOck2)
                .HasColumnType("datetime")
                .HasColumnName("COVID_OCK2");
            entity.Property(e => e.CovidPoz)
                .HasColumnType("datetime")
                .HasColumnName("COVID_POZ");
            entity.Property(e => e.CovidTest)
                .HasColumnType("datetime")
                .HasColumnName("COVID_TEST");
            entity.Property(e => e.DatDuchod)
                .HasColumnType("datetime")
                .HasColumnName("DAT_DUCHOD");
            entity.Property(e => e.DatNastup)
                .HasColumnType("datetime")
                .HasColumnName("DAT_NASTUP");
            entity.Property(e => e.DatSchran)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("DAT_SCHRAN");
            entity.Property(e => e.DatumNar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("DATUM_NAR");
            entity.Property(e => e.DeletedRc).HasColumnName("DELETED_RC");
            entity.Property(e => e.EMail)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("E_MAIL");
            entity.Property(e => e.Funkce)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("FUNKCE");
            entity.Property(e => e.Heslo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("HESLO");
            entity.Property(e => e.IsicCip)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ISIC_CIP");
            entity.Property(e => e.IsicKarta)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ISIC_KARTA");
            entity.Property(e => e.IsicObjdt)
                .HasColumnType("datetime")
                .HasColumnName("ISIC_OBJDT");
            entity.Property(e => e.IsicPlat)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ISIC_PLAT");
            entity.Property(e => e.IsicTyp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ISIC_TYP");
            entity.Property(e => e.Jmeno)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("JMENO");
            entity.Property(e => e.KaCobce)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_COBCE");
            entity.Property(e => e.KaCp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_CP");
            entity.Property(e => e.KaCpchar).HasColumnName("KA_CPCHAR");
            entity.Property(e => e.KaObec)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_OBEC");
            entity.Property(e => e.KaPsc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_PSC");
            entity.Property(e => e.KaStat)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_STAT");
            entity.Property(e => e.KaUlice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_ULICE");
            entity.Property(e => e.KaValid).HasColumnName("KA_VALID");
            entity.Property(e => e.KodJed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_JED");
            entity.Property(e => e.KodMist)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_MIST");
            entity.Property(e => e.KodZp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_ZP");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("LOGIN");
            entity.Property(e => e.Manzel)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("MANZEL");
            entity.Property(e => e.MdDo)
                .HasColumnType("datetime")
                .HasColumnName("MD_DO");
            entity.Property(e => e.MdOd)
                .HasColumnType("datetime")
                .HasColumnName("MD_OD");
            entity.Property(e => e.MistoNar)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("MISTO_NAR");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasDefaultValue("", "DF__ucitele__MODIFIE__118DB7E8")
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Nekvalif).HasColumnName("NEKVALIF");
            entity.Property(e => e.OkresNar)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OKRES_NAR");
            entity.Property(e => e.OsobCislo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OSOB_CISLO");
            entity.Property(e => e.PhotoIds)
                .HasMaxLength(1000)
                .HasDefaultValue("", "DF_ucitele_photo_ids")
                .HasColumnName("photo_ids");
            entity.Property(e => e.PlatCelk)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("PLAT_CELK");
            entity.Property(e => e.PlatOsCl)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("PLAT_OS_CL");
            entity.Property(e => e.PlatOsPr)
                .HasColumnType("numeric(4, 1)")
                .HasColumnName("PLAT_OS_PR");
            entity.Property(e => e.PlatP1)
                .HasColumnType("datetime")
                .HasColumnName("PLAT_P_1");
            entity.Property(e => e.PlatP2)
                .HasColumnType("datetime")
                .HasColumnName("PLAT_P_2");
            entity.Property(e => e.PlatPripl)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("PLAT_PRIPL");
            entity.Property(e => e.PlatSpec)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("PLAT_SPEC");
            entity.Property(e => e.PlatStup)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("PLAT_STUP");
            entity.Property(e => e.PlatTdn)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("PLAT_TDN");
            entity.Property(e => e.PlatTrida)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("PLAT_TRIDA");
            entity.Property(e => e.PlatZakl)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("PLAT_ZAKL");
            entity.Property(e => e.PlatZaraz)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("PLAT_ZARAZ");
            entity.Property(e => e.PocetDeti)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("POCET_DETI");
            entity.Property(e => e.Pohlavi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("POHLAVI");
            entity.Property(e => e.Poznamka)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("POZNAMKA");
            entity.Property(e => e.Poznamka1)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("POZNAMKA1");
            entity.Property(e => e.Poznamka2)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("POZNAMKA2");
            entity.Property(e => e.PpDo)
                .HasColumnType("datetime")
                .HasColumnName("PP_DO");
            entity.Property(e => e.PpDruh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PP_DRUH");
            entity.Property(e => e.PpOd)
                .HasColumnType("datetime")
                .HasColumnName("PP_OD");
            entity.Property(e => e.PracZaraz)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PRAC_ZARAZ");
            entity.Property(e => e.Praxe)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("PRAXE");
            entity.Property(e => e.PrihlOd)
                .HasColumnType("datetime")
                .HasColumnName("PRIHL_OD");
            entity.Property(e => e.PrijRodne)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PRIJ_RODNE");
            entity.Property(e => e.Prijmeni)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PRIJMENI");
            entity.Property(e => e.Priorita)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("PRIORITA");
            entity.Property(e => e.RodneC)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("RODNE_C");
            entity.Property(e => e.SpecZnal)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("SPEC_ZNAL");
            entity.Property(e => e.Specializ)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("SPECIALIZ");
            entity.Property(e => e.StPrisl)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ST_PRISL");
            entity.Property(e => e.Stav)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("STAV");
            entity.Property(e => e.TbCobce)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_COBCE");
            entity.Property(e => e.TbCp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_CP");
            entity.Property(e => e.TbCpchar).HasColumnName("TB_CPCHAR");
            entity.Property(e => e.TbJine).HasColumnName("TB_JINE");
            entity.Property(e => e.TbObec)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_OBEC");
            entity.Property(e => e.TbOkres)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_OKRES");
            entity.Property(e => e.TbPsc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_PSC");
            entity.Property(e => e.TbStat)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_STAT");
            entity.Property(e => e.TbUlice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_ULICE");
            entity.Property(e => e.TbValid).HasColumnName("TB_VALID");
            entity.Property(e => e.TbZuj)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_ZUJ");
            entity.Property(e => e.TelDomu)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TEL_DOMU");
            entity.Property(e => e.TelMobil)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TEL_MOBIL");
            entity.Property(e => e.TelSkolni)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TEL_SKOLNI");
            entity.Property(e => e.Titul)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TITUL");
            entity.Property(e => e.TitulZa)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TITUL_ZA");
            entity.Property(e => e.UciLetos).HasColumnName("UCI_LETOS");
            entity.Property(e => e.UvazkyHod)
                .HasColumnType("numeric(4, 1)")
                .HasColumnName("UVAZKY_HOD");
            entity.Property(e => e.UvazkyPro)
                .HasColumnType("numeric(6, 2)")
                .HasColumnName("UVAZKY_PRO");
            entity.Property(e => e.UvazkySku)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("UVAZKY_SKU");
            entity.Property(e => e.VychPorad).HasColumnName("VYCH_PORAD");
            entity.Property(e => e.Vzdelani)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("VZDELANI");
            entity.Property(e => e.Web)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("WEB");
            entity.Property(e => e.ZamestMan)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ZAMEST_MAN");
            entity.Property(e => e.Zkratka)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ZKRATKA");
        });

        modelBuilder.Entity<Zaci>(entity =>
        {
            entity.HasKey(e => e.InternKod).HasName("PK__zaci__1DA887CB96EA363B");

            entity.ToTable("zaci", "dbo", tb => tb.HasTrigger("ZACITrigger"));

            entity.HasIndex(e => e.Trida, "TRIDA");

            entity.HasIndex(e => e.DeletedRc, "zaci_DELETED_RC");

            entity.Property(e => e.InternKod)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("INTERN_KOD");
            entity.Property(e => e.AbsolvLet)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("ABSOLV_LET");
            entity.Property(e => e.CTrVyk)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("C_TR_VYK");
            entity.Property(e => e.Choroby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CHOROBY");
            entity.Property(e => e.CisloDipl)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CISLO_DIPL");
            entity.Property(e => e.CisloOP)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CISLO_O_P");
            entity.Property(e => e.CisloPasu)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CISLO_PASU");
            entity.Property(e => e.CisloProt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CISLO_PROT");
            entity.Property(e => e.CisloVysv)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CISLO_VYSV");
            entity.Property(e => e.CisloZkvz)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("CISLO_ZKVZ");
            entity.Property(e => e.CovidOck)
                .HasColumnType("datetime")
                .HasColumnName("COVID_OCK");
            entity.Property(e => e.CovidOck1)
                .HasColumnType("datetime")
                .HasColumnName("COVID_OCK1");
            entity.Property(e => e.CovidOck2)
                .HasColumnType("datetime")
                .HasColumnName("COVID_OCK2");
            entity.Property(e => e.CovidPoz)
                .HasColumnType("datetime")
                .HasColumnName("COVID_POZ");
            entity.Property(e => e.CovidTest)
                .HasColumnType("datetime")
                .HasColumnName("COVID_TEST");
            entity.Property(e => e.DatSchran)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("DAT_SCHRAN");
            entity.Property(e => e.DatumNar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("DATUM_NAR");
            entity.Property(e => e.DeletedRc).HasColumnName("DELETED_RC");
            entity.Property(e => e.DruhStud)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("DRUH_STUD");
            entity.Property(e => e.EMail)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("E_MAIL");
            entity.Property(e => e.EvCislo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("EV_CISLO");
            entity.Property(e => e.EvidDo)
                .HasColumnType("datetime")
                .HasColumnName("EVID_DO");
            entity.Property(e => e.EvidOd)
                .HasColumnType("datetime")
                .HasColumnName("EVID_OD");
            entity.Property(e => e.IsicCip)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ISIC_CIP");
            entity.Property(e => e.IsicKarta)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ISIC_KARTA");
            entity.Property(e => e.IsicObjdt)
                .HasColumnType("datetime")
                .HasColumnName("ISIC_OBJDT");
            entity.Property(e => e.IsicPlat)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ISIC_PLAT");
            entity.Property(e => e.IsicTyp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ISIC_TYP");
            entity.Property(e => e.IzoSs1)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("IZO_SS1");
            entity.Property(e => e.IzoSs2)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("IZO_SS2");
            entity.Property(e => e.IzoSs3)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("IZO_SS3");
            entity.Property(e => e.IzoSs4)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("IZO_SS4");
            entity.Property(e => e.IzoSs5)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("IZO_SS5");
            entity.Property(e => e.JazykZs)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("JAZYK_ZS");
            entity.Property(e => e.JazykZs1)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("JAZYK_ZS1");
            entity.Property(e => e.JazykZs2)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("JAZYK_ZS2");
            entity.Property(e => e.Jmeno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("JMENO");
            entity.Property(e => e.KaCobce)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_COBCE");
            entity.Property(e => e.KaCp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_CP");
            entity.Property(e => e.KaCpchar).HasColumnName("KA_CPCHAR");
            entity.Property(e => e.KaObec)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_OBEC");
            entity.Property(e => e.KaPsc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_PSC");
            entity.Property(e => e.KaStat)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_STAT");
            entity.Property(e => e.KaUlice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KA_ULICE");
            entity.Property(e => e.KaValid).HasColumnName("KA_VALID");
            entity.Property(e => e.KodZp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("KOD_ZP");
            entity.Property(e => e.LoginOut)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("login_out");
            entity.Property(e => e.MatSkola)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("MAT_SKOLA");
            entity.Property(e => e.MistoNar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("MISTO_NAR");
            entity.Property(e => e.Mistr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("mistr");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.OborSs1)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SS1");
            entity.Property(e => e.OborSs2)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SS2");
            entity.Property(e => e.OborSs3)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SS3");
            entity.Property(e => e.OborSs4)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SS4");
            entity.Property(e => e.OborSs5)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SS5");
            entity.Property(e => e.OborSsd1)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SSD1");
            entity.Property(e => e.OborSsd2)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SSD2");
            entity.Property(e => e.OborSsd3)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SSD3");
            entity.Property(e => e.OborSsd4)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SSD4");
            entity.Property(e => e.OborSsd5)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OBOR_SSD5");
            entity.Property(e => e.Odesel)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ODESEL");
            entity.Property(e => e.OdeselIzo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ODESEL_IZO");
            entity.Property(e => e.OdeselPoz)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("ODESEL_POZ");
            entity.Property(e => e.Odeselobo2)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ODESELOBO2");
            entity.Property(e => e.Odeselobor)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ODESELOBOR");
            entity.Property(e => e.Odklad)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ODKLAD");
            entity.Property(e => e.OkresNar)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("OKRES_NAR");
            entity.Property(e => e.PhotoIds)
                .HasMaxLength(1000)
                .HasDefaultValue("", "DF_zaci_photo_ids")
                .HasColumnName("photo_ids");
            entity.Property(e => e.Pohlavi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("POHLAVI");
            entity.Property(e => e.PoznSpec)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("POZN_SPEC");
            entity.Property(e => e.Poznamka)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("POZNAMKA");
            entity.Property(e => e.Poznamka1)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("POZNAMKA1");
            entity.Property(e => e.Poznamka2)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("POZNAMKA2");
            entity.Property(e => e.PrihlOd)
                .HasColumnType("datetime")
                .HasColumnName("PRIHL_OD");
            entity.Property(e => e.Prijmeni)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PRIJMENI");
            entity.Property(e => e.Prisel)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PRISEL");
            entity.Property(e => e.Problemy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PROBLEMY");
            entity.Property(e => e.PuvIzo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PUV_IZO");
            entity.Property(e => e.PuvPozn)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("PUV_POZN");
            entity.Property(e => e.PuvPusob)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PUV_PUSOB");
            entity.Property(e => e.PuvVzdel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("PUV_VZDEL");
            entity.Property(e => e.Rmat)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("rmat");
            entity.Property(e => e.Rodina)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("RODINA");
            entity.Property(e => e.RodneC)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("RODNE_C");
            entity.Property(e => e.Sd)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("SD");
            entity.Property(e => e.Sov)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("sov");
            entity.Property(e => e.StPrisl)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ST_PRISL");
            entity.Property(e => e.StPrislK)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ST_PRISL_K");
            entity.Property(e => e.StudDelka)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("STUD_DELKA");
            entity.Property(e => e.TbCobce)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_COBCE");
            entity.Property(e => e.TbCp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_CP");
            entity.Property(e => e.TbCpchar).HasColumnName("TB_CPCHAR");
            entity.Property(e => e.TbJine).HasColumnName("TB_JINE");
            entity.Property(e => e.TbObec)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_OBEC");
            entity.Property(e => e.TbObvod)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_OBVOD");
            entity.Property(e => e.TbOkres)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_OKRES");
            entity.Property(e => e.TbPsc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_PSC");
            entity.Property(e => e.TbStat)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_STAT");
            entity.Property(e => e.TbUlice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_ULICE");
            entity.Property(e => e.TbValid).HasColumnName("TB_VALID");
            entity.Property(e => e.TbZuj)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TB_ZUJ");
            entity.Property(e => e.TelMobil)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TEL_MOBIL");
            entity.Property(e => e.Telefon)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TELEFON");
            entity.Property(e => e.Titul)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("titul");
            entity.Property(e => e.TitulZa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("titul_za");
            entity.Property(e => e.Trida)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("TRIDA");
            entity.Property(e => e.VisaNum)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("visa_num");
            entity.Property(e => e.Zamereni)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ZAMERENI");
            entity.Property(e => e.Zdrsku)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ZDRSKU");
            entity.Property(e => e.Zps).HasColumnName("ZPS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
