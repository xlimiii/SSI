using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Bayes_Limanowka
{
    class Class1
    { 
        static void Main(string[] args)
        { 
        Przypadki[] p = new Przypadki[] {
         new Przypadki(2,23,1,0),
         new Przypadki(0,15,2,1),
         new Przypadki(1,17,0,0),
         new Przypadki(1,21,1,1),
         new Przypadki(2,20,2,0),
         new Przypadki(2,25,0,0),
         new Przypadki(0,22,0,0),
         new Przypadki(2,14,2,1),
         new Przypadki(1,19,2,1),
         new Przypadki(0,16,0,1) };

        Przypadki x = new Przypadki(0, 21, 0);
        Console.WriteLine("Wedlug naiwnego klasyfikatora Bayesa przy podanych warunkach decyzja jest "+ Bayes(p, x));

        Console.ReadKey();

        }
        static enums.Decyzje Bayes(Przypadki[] p, Przypadki x)
        {
            List<Przypadki> tak = new List<Przypadki> { };
            List<Przypadki> nie = new List<Przypadki> {  };
            for (int i = 0; i < p.Length; i++)
            {
                switch (p[i].D)
                {
                    case enums.Decyzje.pozytywna:
                        tak.Add(p[i]);
                        break;
                    case enums.Decyzje.negatywna:
                        nie.Add(p[i]);
                        break;
                }
            }
            double PTa1 = 0;
            double PTa2 = 0;
            double PTa3 = 0;
            double PNa1 = 0;
            double PNa2 = 0;
            double PNa3 = 0;
            foreach (Przypadki przypadek in tak)
            {
                if (przypadek.RW == x.RW)
                    PTa1++;
                if (przypadek.RT == x.RT)
                    PTa2++;
                if (przypadek.RP == x.RP)
                    PTa3++;
            }
            foreach (Przypadki przypadek in nie)
            {
                if (przypadek.RW == x.RW)
                    PNa1++;
                if (przypadek.RT == x.RT)
                    PNa2++;
                if (przypadek.RP == x.RP)
                    PNa3++;
            }
            PTa1 = PTa1 / tak.Count;
            PTa2 = PTa2 / tak.Count;
            PTa3 = PTa3 / tak.Count;
            PNa1 = PNa1 / nie.Count;
            PNa2 = PNa2 / nie.Count;
            PNa3 = PNa3 / nie.Count;
            double PTak = PTa1 * PTa2 * PTa3;
            double PNie = PNa1 * PNa2 * PNa3;
            if (PTak >= PNie)
            {
                x.D = (enums.Decyzje)0;
            }
            else
                x.D = (enums.Decyzje)1;
            return x.D;

      
        }


    }
}