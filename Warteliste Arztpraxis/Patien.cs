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
            public string Vorname { get; }
            public string Nachname { get; }
            public string Sozialversicherungsnr { get; }
            public string Behandlung { get; }

            public Patien(string vorname, string nachname, string sozialversicherungsnr, string behandlung)
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
