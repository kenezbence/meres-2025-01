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

class Program
{
    static void Main(string[] args)
    {
        List<Sportolo> sportolok = new List<Sportolo>();

        // 1. Read the file and populate the list
        try
        {
            var lines = File.ReadAllLines("kalapacsvetes.txt");
            for (int i = 1; i < lines.Length; i++) // Skip header
            {
                var parts = lines[i].Split(';');
                int helyezes = int.Parse(parts[0]);
                double eredmeny = double.Parse(parts[1], CultureInfo.InvariantCulture);
                string nev = parts[2];
                string orszagKod = parts[3];
                string helyszin = parts[4];
                string datum = parts[5];
                sportolok.Add(new Sportolo(helyezes, eredmeny, nev, orszagKod, helyszin, datum));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba a fájl beolvasása során: " + ex.Message);
            return;
        }
