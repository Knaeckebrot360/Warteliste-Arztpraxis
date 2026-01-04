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

                Console.WriteLine("[1] Patient hinzufügen, [2] Warteliste anzeigen, [3] Zeige Patient, [4] Patient behandelt, [0] Exit");

                Console.WriteLine("\nEingabe: ");
                string eingabeStr = Console.ReadLine();

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

                        while (int.TryParse(vorname, out int ausvorname))           //Namen enthalten üblicherweise keine Zahlen, ist man das Kind von Elon Musk hat man pech gehabt
                        {
                            ZeigeFehler("Falsche Eingabe (enthält Zahlen)");
                            Console.Write("Vorname: ");
                            vorname = Console.ReadLine();
                        }



                        Console.Write("Nachname:");                                 //Selbe Prinzip
                        string nachname = Console.ReadLine();
                        while (int.TryParse(nachname, out int ausnachname))
                        {
                            ZeigeFehler("Falsche Eingabe (enthält Zahlen)");
                            Console.Write("Nachname: ");
                            nachname = Console.ReadLine();
                        }
                        

                        Console.Write("Sozialversicherungsnummer:");                //Umgekehrtes Prinzip
                        string svnr = Console.ReadLine();
                        while (int.TryParse(svnr, out int aussvnr)==false)
                        {
                            ZeigeFehler("Falsche Eingabe (enthält Buchstaben)");
                            Console.Write("Sozialversicherungsnummer: ");
                            svnr = Console.ReadLine();
                        }


                        Console.Write("Behandlung:");                               //können vielleicht Zahlen enthalten?
                        string behandlung = Console.ReadLine();

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
                        Console.WriteLine("Patient erfolgreich hinzugefügt!\n");    //Ich finds schön
                        Console.ResetColor();
                        Console.ReadKey();
                        break;

                    case 2:

                        bildschirm.ZeigeWarteliste();                               //nochmal die Warteliste wer sie oben nicht finden kann ¯\(ツ)/¯ 
                        Console.ReadKey();

                        break;

                    case 3:

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
