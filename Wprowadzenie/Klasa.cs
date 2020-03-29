using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wprowadzenie
{
    class Klasa
    { 
        static void Main(string[] args)
        {
            //nakładanie filtru na zdjęcie
            string nazwa = "kot";
        Grafika gr = new Grafika();
            Bitmap btm = gr.Macierz(@nazwa);
            gr.Filtr_Sharpen(btm, nazwa);
            //pobieranie danych, normalizacja, tasowanie
            string nazwatxt = "iris.txt";
            Dane dn = new Dane();
            double[][] tablica = dn.Pobierz(nazwatxt);
            Console.WriteLine("Przed normalizacją: ");
            for (int i = 0; i < tablica.Length; i++)
            {
                for (int j = 0; j < tablica[i].Length; j++)
                {
                    Console.Write(tablica[i][j] + ", ");
                }
                Console.Write("\n");
            }
            double[][] potasowana = dn.Tasuj(tablica);
            Console.WriteLine("Potasowana: ");
            for (int i = 0; i < potasowana.Length; i++)
            {
                for (int j = 0; j < potasowana[i].Length; j++)
                {
                    Console.Write(potasowana[i][j] + ", ");
                }
                Console.Write("\n");
            }
            double[][] znormalizowana = dn.Normalizuj(tablica);
            Console.WriteLine("Po normalizacji: ");

            for (int i = 0; i < znormalizowana.Length; i++)
            {
                for (int j = 0; j < znormalizowana[i].Length; j++)
                {
                    Console.Write(znormalizowana[i][j] + ", ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
