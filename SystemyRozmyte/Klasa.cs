using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemyRozmyte
{
    class Klasa
    {
        static void Main(string[] args)
        {
            List<Miasta> miasta = new List<Miasta>();
            miasta.Add(new Miasta(0.3, 0.6, "Warszawa"));
            miasta.Add(new Miasta(0.1, 1, "Kraków"));
            miasta.Add(new Miasta(0.9, 0.9, "Gdańsk"));
            miasta.Add(new Miasta(0.7, 0.8, "Wrocław"));
            miasta.Add(new Miasta(0.1, 0.3, "Katowice"));
            miasta.Add(new Miasta(0.6, 0.7, "Poznań"));
            miasta.Add(new Miasta(0.1, 0.3, "Gliwice"));

            foreach (Miasta miasto in miasta)
            {
                miasto.ZanieczyszczenieFuzzy.Add(SystemyRozmyte.A22(0, 0, 0.1, 0.25, miasto.Zanieczyszczenie));
                miasto.ZanieczyszczenieFuzzy.Add(SystemyRozmyte.A21(0.2, 0.35, 0.55, miasto.Zanieczyszczenie));
                miasto.ZanieczyszczenieFuzzy.Add(SystemyRozmyte.A22(0.5, 0.7, 1, 1, miasto.Zanieczyszczenie));
                miasto.NaslonecznienieFuzzy.Add(SystemyRozmyte.A22(0, 0, 0.1, 0.25, miasto.Naslonecznienie));
                miasto.NaslonecznienieFuzzy.Add(SystemyRozmyte.A21(0.2, 0.35, 0.6, miasto.Naslonecznienie));
                miasto.NaslonecznienieFuzzy.Add(SystemyRozmyte.A22(0.55, 0.8, 1, 1, miasto.Naslonecznienie));
                miasto.Wnioskowanie();
                miasto.Wyostrzanie();
                Console.WriteLine("Miasto: " + miasto.Nazwa + "\nZanieczyszczenie na poziomie: " +
                    miasto.Zanieczyszczenie + "\nNasłoczenie na poziomie: " +
                    miasto.Naslonecznienie + "\nPoziom życia: " + miasto.WynikLingwistycznie(miasto.Result));
                Console.WriteLine("***************************************************************************************");
            }
            Console.ReadKey();
        }
    }
}
