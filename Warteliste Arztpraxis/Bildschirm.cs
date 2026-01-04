//Simon Scheit -- 3CK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warteliste_Arztpraxis
{
    class Bildschirm
    {
        private List<Patien> patienten = new List<Patien>();

        public void PatientHinzufügen(int patientnummer, string vorname, string nachnahm, string sozialversicherungsnr, string behandlung)
        {
            Patien patientneu = new Patien(vorname, nachnahm, sozialversicherungsnr, behandlung);
            patientneu.NummerZuweisen(ErzeugeNeuePatientennummer());
            patienten.Add(patientneu);
        }

        public void SchmerzpatientHinzufügen(int patientnummer, string vorname, string nachnahm, string sozialversicherungsnr, string behandlung)
        {
            Patien patientneu = new Patien(vorname, nachnahm, sozialversicherungsnr, behandlung);
            patientneu.NummerZuweisen(ErzeugeNeuePatientennummer());
            patienten.Add(patientneu);
        }

        public void ZeigeWarteliste()
        {
            int position = 0;
            foreach (Patien patient in patienten)
            {
                position++;
                Console.WriteLine($"Position {position}: {patient.Nummer}\n");
            }
            if(patienten == null || patienten.Count == 0)
            {
                Console.WriteLine("Keine Patienten vorhanden\n");
            }
        }

        public int ErzeugeNeuePatientennummer()
        {
            Random rnd = new Random();
            
            int nummer = rnd.Next(10, 100);

            foreach (Patien patient in patienten)
            {
                if (patient.Nummer == nummer)
                {
                    nummer = rnd.Next(10, 100);
                }
            }

            return nummer;
        }

        public void NächsterPatientEntfernen(int patientnummer)
        {
            Patien patientZumEntfernen = null;
            foreach (Patien patient in patienten)
            {
                if (patient.Nummer == patientnummer)
                {
                    patientZumEntfernen = patient;
                    break;
                }
            }
            if (patientZumEntfernen != null)
            {
                patienten.Remove(patientZumEntfernen);
            }
        }
    }
}
