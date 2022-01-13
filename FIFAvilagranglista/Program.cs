using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFAvilagranglista
{

    class Fifa
    {
        public Fifa(string sor)
        {
            string[] sorelemek = sor.Split(';');
            this.Csapat = sorelemek[0];
            this.Helyezes = Convert.ToInt32(sorelemek[1]);
            this.Valtozas = Convert.ToInt32(sorelemek[2]);
            this.Pontszam = Convert.ToInt32(sorelemek[3]);
        }
        //Csapat;Helyezes;Valtozas;Pontszam
        //Anglia;4;0;1662
        public string Csapat { get; set; }
        public int Helyezes { get; set; }
        public int Valtozas { get; set; }
        public int Pontszam { get; set; }

    }
    class Program
    {
        public static List<Fifa> adatok = new List<Fifa>();
        static void Main(string[] args)
        {            StreamReader olvas = new StreamReader("fifa.txt", Encoding.UTF8);
            string fejlec = olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                adatok.Add(new Fifa(olvas.ReadLine()));
            }
            int i, j;
            int adatokszama = adatok.Count;
            //3
            Console.WriteLine("3. feladat: A világranglistán {0} csapat szerepel", adatokszama);
            //4
            double atlagpont = 0;
            for (i = 0; i < adatokszama; i++) atlagpont += adatok[i].Pontszam;
            Console.WriteLine("4. feladat: A csapatok átlagos pontszáma: {0} pont", Math.Round(atlagpont / adatokszama, 2));
            //5
            int max = adatok[0].Valtozas;
            int maxi = 0;
            for (i = 0; i < adatokszama; i++)
                if (adatok[i].Valtozas > max)
                {
                    max = adatok[i].Valtozas;
                    maxi = i;
                }
            Console.WriteLine("5. feladat: A legtöbbet javító csapat:");
            Console.WriteLine("\tHelyezés: {0}", adatok[maxi].Helyezes);
            Console.WriteLine("\tCsapat: {0}", adatok[maxi].Csapat);
            Console.WriteLine("\tPontszám: {0}", adatok[maxi].Pontszam);
            //6
            bool van = false;
            i = 0;
            do
            {
                if (adatok[i].Csapat == "Magyarország") van = true;
                i++;
            }
            while (i < adatokszama && !van);
            if (van) Console.WriteLine("6. feladat: A csapatok között van Magyarország");
            else Console.WriteLine("6. feladat: A csapatok között nincs Magyarország");
            

            Console.ReadKey();

        }
    }
}
