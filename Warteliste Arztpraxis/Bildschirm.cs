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
        private List<Patient> patienten = new List<Patient>();

        public void PatientHinzufügen(Patient patient)
        {
            Patient patientneu = patient;
            patientneu.NummerZuweisen(ErzeugeNeuePatientennummer());
            patienten.Add(patientneu);
        }

        public void SchmerzpatientHinzufügen(Patient patient)
        {
            Patient patientneu = patient;
            patientneu.NummerZuweisen(ErzeugeNeuePatientennummer());
            patienten.Add(patientneu);
        }

        public void ZeigeWarteliste()
        {
            int position = 0;
            foreach (Patient patient in patienten)
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

            foreach (Patient patient in patienten)
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
            if (patienten != null)
            {
                patienten.RemoveAt(0);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient aus Warteliste entfernt\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keine Patienten vorhanden\n");
                Console.ResetColor();
            }
            
        }

        public void ZeigePatientendetails(int patientnummer)
        {
            foreach (Patient patient in patienten)
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

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Patient nicht gefunden\n");
                Console.ResetColor();

            }
            

        }
    }
}
