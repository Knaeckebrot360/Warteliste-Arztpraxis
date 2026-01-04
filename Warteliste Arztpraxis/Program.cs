//Simon Scheit -- 3CK

namespace Warteliste_Arztpraxis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bildschirm bildschirm = new Bildschirm();
            Console.WriteLine("Zahnarztpraxis Schmerzfrei - Wartelistenprogramm");

            Console.WriteLine("\n\nWarteliste:\n");
            bildschirm.ZeigeWarteliste();


        }
    }
}
