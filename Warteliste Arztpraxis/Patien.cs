//Simon Scheit -- 3CK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warteliste_Arztpraxis
{
    class Patien
    {
        
        
            public int Nummer { get; private set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public string Sozialversicherungsnr { get; set; }
            public string Behandlung { get; set; }

            public Patien(string vorname, string nachname, string sozialversicherungsnr, string behandlung)     //Konstruktor für die Klasse Patient
        {
                Vorname = vorname;
                Nachname = nachname;
                Sozialversicherungsnr = sozialversicherungsnr;
                Behandlung = behandlung;
            }

            public void NummerZuweisen(int nummer)
            {
                this.Nummer=nummer;
            }
        

    }
}
