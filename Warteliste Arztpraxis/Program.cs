//Simon Scheit -- 3CK

namespace Warteliste_Arztpraxis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bildschirm bildschirm = new Bildschirm();

            int eingabe=-1;

            do { 
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("Zahnarztpraxis Schmerzfrei - Wartelistenprogramm");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\nWarteliste:");
                Console.ResetColor();
                bildschirm.ZeigeWarteliste();

                Console.WriteLine("\n[1] Patient hinzufügen, [2] Warteliste anzeigen, [3] Zeige Patient, [4] Patient behandelt, [0] Exit");

                Console.Write("\nEingabe: ");
                string eingabeStr = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(eingabeStr, out eingabe) == false)     //Sicherstellungen, dass eine korrekte Zahl eingegeben wurde
                {
                    ZeigeFehler("Fehler: Falsche Eingabe");
                    Console.ReadKey();
                    eingabe = -1;
                    continue;
                }

                if (eingabe < 0 || eingabe > 4)
                {
                    ZeigeFehler("Fehler: Falsche Eingabe");
                    Console.ReadKey();
                    eingabe = -1;
                    continue;
                }


                switch (eingabe)
                {
                    case 1:
                       
                        Console.Write("Vorname: ");
                        string vorname = Console.ReadLine();

                        while (int.TryParse(vorname, out int ausvorname))           //Namen enthalten üblicherweise keine Zahlen, leer sind sie schon gar nicht
                        {
                            ZeigeFehler("Falsche Eingabe (enthält Zahlen)");
                            Console.Write("Vorname: ");
                            vorname = Console.ReadLine();
                        }




                        Console.Write("Nachname: ");                                //Selbe Prinzip
                        string nachname = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(nachname) || int.TryParse(nachname, out int ausnachname))
                        {
                            if (string.IsNullOrWhiteSpace(nachname))
                            {
                                ZeigeFehler("Falsche Eingabe (darf nicht leer sein)");
                            }
                            else
                            {
                                ZeigeFehler("Falsche Eingabe (enthält Zahlen)");
                            }
                            Console.Write("Nachname: ");
                            nachname = Console.ReadLine();
                        }


                        Console.Write("Sozialversicherungsnummer:");                //Umgekehrtes Prinzip
                        string svnr = Console.ReadLine();
                        while (int.TryParse(svnr, out int aussvnr)==false)
                        {
                            ZeigeFehler("Falsche Eingabe");
                            Console.Write("Sozialversicherungsnummer: ");
                            svnr = Console.ReadLine();
                        }


                        Console.Write("Behandlung:");                               //können vielleicht Zahlen enthalten?
                        string behandlung = Console.ReadLine();
                        while (int.TryParse(behandlung, out int behandeln))
                        {
                            ZeigeFehler("Darf nicht leer sein");
                            Console.Write("Behandlung: ");
                            behandlung = Console.ReadLine();
                        }

                        Patien neuerPatient = new Patien(vorname, nachname, svnr, behandlung);
                        bildschirm.PatientHinzufügen(neuerPatient);

                        Console.Write("starke Schmerzen? (j/n): ");                 //Man wird gefragt ob man arge Schmerzen hat und somit ein Schmerzpatient ist
                        string argeSchmerzen = Console.ReadLine();
                        while (argeSchmerzen != "j" && argeSchmerzen != "n")
                        {
                            ZeigeFehler("Falsche Eingabe (nur j/n)");
                            Console.Write("starke Schmerzen? (j/n): ");
                            argeSchmerzen = Console.ReadLine();
                        }

                        Console.ForegroundColor = ConsoleColor.Green;           
                        Console.WriteLine("Patient erfolgreich hinzugefügt!\n");    //Ich finde es schön
                        Console.ResetColor();
                        Console.ReadKey();
                        break;

                    case 2:

                        bildschirm.ZeigeWarteliste();                               //nochmal die Warteliste wer sie oben nicht finden kann ¯\(ツ)/¯ 
                        Console.ReadKey();

                        break;

                    case 3:
                        Console.Write("Nummer des patienten: ");
                        string patientennummerD = Console.ReadLine();
                        bildschirm.ZeigePatientendetails(int.Parse(patientennummerD));                     //Zeigt die Details eines Patienten an
                        break;

                    case 4:

                        break;

                    case 5: break;
                }
                   
                

            } while (eingabe !=0);

            static void ZeigeFehler(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }

        }
    }
}
