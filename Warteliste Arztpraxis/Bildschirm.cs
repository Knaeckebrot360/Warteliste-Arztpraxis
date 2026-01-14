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

        public void PatientHinzufügen(Patien patient)
        {
            Patien patientneu = patient;
            patientneu.NummerZuweisen(ErzeugeNeuePatientennummer());
            patienten.Add(patientneu);
        }

        public void SchmerzpatientHinzufügen(Patien patient)
        {
            Patien patientneu = patient;
            patientneu.NummerZuweisen(ErzeugeNeuePatientennummer());
            patienten.Add(patientneu);
        }

        public void ZeigeWarteliste()
        {
            int position = 0;
            foreach (Patien patient in patienten)
            {
                position++;
                Console.Write($"Position {position}: {patient.Nummer}\n");
            }
            if( patienten.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keine Patienten vorhanden\n");
                Console.ResetColor();
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

        public void ZeigePatientendetails(int patientnummer)
        {
            foreach (Patien patient in patienten)
            {
                if (patient.Nummer == patientnummer)
                {
                    Console.WriteLine($"Patientennummer: {patient.Nummer}");
                    Console.WriteLine($"Vorname: {patient.Vorname}");
                    Console.WriteLine($"Nachname: {patient.Nachname}");
                    Console.WriteLine($"Sozialversicherungsnummer: {patient.Sozialversicherungsnr}");
                    Console.WriteLine($"Behandlung: {patient.Behandlung}\n");
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Patient nicht gefunden\n");
            Console.ResetColor();
        }
    }
}
