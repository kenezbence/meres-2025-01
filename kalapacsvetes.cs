using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Sportolo
{
    public int Helyezes { get; set; }
    public double Eredmeny { get; set; }
    public string Nev { get; set; }
    public string OrszagKod { get; set; }
    public string Helyszin { get; set; }
    public string Datum { get; set; }

    public int GetYear()
    {
        return int.Parse(Datum.Split('.')[0]);
    }

    public Sportolo(int helyezes, double eredmeny, string nev, string orszagKod, string helyszin, string datum)
    {
        Helyezes = helyezes;
        Eredmeny = eredmeny;
        Nev = nev;
        OrszagKod = orszagKod;
        Helyszin = helyszin;
        Datum = datum;
    }

    public override string ToString()
    {
        return $"{Helyezes};{Eredmeny:F2};{Nev};{OrszagKod};{Helyszin};{Datum}";
    }
}
