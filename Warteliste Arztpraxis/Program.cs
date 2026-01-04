//Simon Scheit -- 3CK

namespace Warteliste_Arztpraxis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bildschirm bildschirm = new Bildschirm();
            Console.WriteLine("Zahnarztpraxis Schmerzfrei - Wartelistenprogramm");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\nWarteliste:");
            Console.ResetColor();
            bildschirm.ZeigeWarteliste();

            Console.WriteLine("[1] Patient hinzufügen, [2] Warteliste anzeigen, [3] Zeige Patient, [4] Patient behandelt, [0] Exit");

            if(Console.ReadLine() == "1")
            {
                Console.WriteLine("Vorname:");          
                string vorname = Console.ReadLine();

                Console.WriteLine("Nachname:");
                string nachname = Console.ReadLine();

                Console.WriteLine("Sozialversicherungsnummer:");
                string svnr = Console.ReadLine();

                Console.WriteLine("Behandlung:");
                string behandlung = Console.ReadLine();

                Patien neuerPatient = new Patien(vorname, nachname, svnr, behandlung);
                bildschirm.PatientHinzufügen(neuerPatient);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient erfolgreich hinzugefügt!\n");
                Console.ResetColor();
            }

        }
    }
}
