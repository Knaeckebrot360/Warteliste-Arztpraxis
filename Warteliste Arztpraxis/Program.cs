//Simon Scheit -- 3CK

namespace Warteliste_Arztpraxis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bildschirm bildschirm = new Bildschirm();

            int eingabe = -1;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("Zahnarztpraxis Schmerzfrei - Wartelistenprogramm");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\nWarteliste:");

                bildschirm.ZeigeWarteliste();
                Console.ResetColor();
                Console.WriteLine("\n[1] Patient hinzufügen, [2] Warteliste anzeigen, [3] Zeige Patient, [4] Patient behandelt, [0] Exit");

                Console.Write("\nEingabe: ");
                string eingabeStr = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(eingabeStr, out eingabe) == false)     //Sicherstellungen, dass eine korrekte Zahl eingegeben wurde
                {
                    ZeigeFehler("Falsche Eingabe");
                    Console.ReadKey();
                    eingabe = -1;
                    continue;
                }

                if (eingabe < 0 || eingabe > 4)
                {
                    ZeigeFehler("Falsche Eingabe");
                    Console.ReadKey();
                    eingabe = -1;
                    continue;
                }


                switch (eingabe)
                {
                    case 1:

                        Console.Write("Vorname: ");
                        string vorname = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(vorname) || vorname.Any(char.IsDigit))              //Namen enthalten üblicherweise keine Zahlen, leer sind sie schon gar nicht
                        {                                                                                   
                            if (string.IsNullOrWhiteSpace(vorname))                                         //Fehler genauer definieren, damit der Benutzer weiß was er falsch gemacht hat
                            {
                                ZeigeFehler("Falsche Eingabe (darf nicht leer sein)");
                            }
                            else
                            {
                                ZeigeFehler("Falsche Eingabe (enthält Zahlen)");
                            }
                            Console.Write("Vorname: ");
                            vorname = Console.ReadLine();
                        }




                        Console.Write("Nachname: ");                                                        //Selbe Prinzip, IsNullOrWhiteSpace und und Any(char.IsDigit) um Zahlen auszuschließen
                        string nachname = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(nachname) || nachname.Any(char.IsDigit))           //Es wird gefragt bis das Programm eine korrekte Eingabe erhält
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


                        Console.Write("Sozialversicherungsnummer:");                                        //Umgekehrtes Prinzip
                        string svnr = Console.ReadLine();
                        while (int.TryParse(svnr, out int aussvnr) == false)
                        {
                            if (string.IsNullOrWhiteSpace(svnr))
                            {
                                ZeigeFehler("Falsche Eingabe (darf nicht leer sein)");
                            }
                            else
                            {
                                ZeigeFehler("Falsche Eingabe (enthält Buchstaben oder Sonderzeichen)");
                            }

                            Console.Write("Sozialversicherungsnummer: ");
                            svnr = Console.ReadLine();
                        }


                        Console.Write("Behandlung:");                                                        //könnte womöglich Zahlen enthalten?
                        string behandlung = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(behandlung))
                        {
                            ZeigeFehler("Falsche Eingabe (darf nicht leer sein)");
                            Console.Write("Behandlung: ");
                            behandlung = Console.ReadLine();
                        }

                        Patient neuerPatient = new Patient(vorname, nachname, svnr, behandlung);
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

                        bildschirm.ZeigeWarteliste();                               
                        Console.ReadKey();

                        break;

                    case 3:                                                        //Zeigt die Details eines Patienten an
                        Console.Write("Nummer des patienten: ");
                        string patientennummerD = Console.ReadLine();

                        while (int.TryParse(patientennummerD, out int auspatient) == false)     //Sicherstellung, dass eine korrekte Zahl eingegeben wurde
                        {
                            if (string.IsNullOrWhiteSpace(patientennummerD))
                            {
                                ZeigeFehler("Falsche Eingabe (darf nicht leer sein)");

                            }
                            else
                            {
                                ZeigeFehler("Falsche Eingabe (enthält Buchstaben oder Sonderzeichen)");
                            }

                            Console.Write("Nummer des patienten: ");
                            patientennummerD = Console.ReadLine();

                        }

                        bildschirm.ZeigePatientendetails(int.Parse(patientennummerD));
                        Console.ReadKey();
                        break;


                    case 4:

                        break;

                    case 5:
                        Console.WriteLine("Auf Wiedersehen.");
                        break;
                }



            } while (eingabe != 0);
        }

            static void ZeigeFehler(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }

        }
    }

