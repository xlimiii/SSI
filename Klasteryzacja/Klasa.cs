using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasteryzacja
{
    class Klasa
    {
        
        static Iris[] Pobierz(string path)
        {
            string[] lines = File.ReadAllLines(path);
            double[][] tablica = new double[lines.Length][];
            Iris[] tabIrysow = new Iris[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                tabIrysow[i] = new Iris();
                string[] tmp = lines[i].Split(',');
                tablica[i] = new double[tmp.Length];
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    tablica[i][j] = Convert.ToDouble(tmp[j].Replace('.', ','));
                }
                tabIrysow[i].X1 = tablica[i][0];
                tabIrysow[i].X2 = tablica[i][1];
                tabIrysow[i].X3 = tablica[i][2];
                tabIrysow[i].X4 = tablica[i][3];

                if (tmp[tmp.Length - 1] == "Iris-setosa")
                {
                    tabIrysow[i].Kind = (iris_kind)0;
                }
                else if (tmp[tmp.Length - 1] == "Iris-versicolor")
                {
                    tabIrysow[i].Kind = (iris_kind)1;

                }
                else if (tmp[tmp.Length - 1] == "Iris-virginica")
                {
                    tabIrysow[i].Kind = (iris_kind)2;
                }



            }
            return tabIrysow;
        }
        static double[] PoliczMetrykeEuklidesowa(Iris[] tablica, Iris X)
        {
            double[] d = new double[tablica.Length];
            for(int i=0; i < tablica.Length; i++)
            {
                d[i] = Math.Sqrt((tablica[i].X1 - X.X1)* (tablica[i].X1 - X.X1) + (tablica[i].X2 - X.X2)* (tablica[i].X2 - X.X2) + (tablica[i].X3 - X.X3)* (tablica[i].X3 - X.X3) + (tablica[i].X4 - X.X4)* (tablica[i].X4 - X.X4));
            }
            
            return d;

        }
        static Dictionary<int, double> ZnajdzNajblizszychSasiadow(double[] d,  int k)
        {
            Dictionary<int, double> nearestneighbours = new Dictionary<int, double>();
            for(int i = 0; i < k; i++)
            {
                nearestneighbours.Add(i, d[i]);
            }
            for (int j = k; j < d.Length; j++)
            {
                double max = nearestneighbours.Max(kvp => kvp.Value);
                if (d[j] < max)
                {
                    var item = nearestneighbours.First(kvp => kvp.Value == max);
                    nearestneighbours.Remove(item.Key);
                    nearestneighbours.Add(j, d[j]);
                }
            }
                return nearestneighbours;
        }
        static string Glosowanie(Dictionary<int, double> nearestneighbours, Iris[] tabIrysow)
        {
            int setosa = 0;
            int versicolor = 0;
            int virginica = 0;
            foreach (KeyValuePair<int, double> item in nearestneighbours)
            {
                if (tabIrysow[item.Key].Kind == (iris_kind)0)
                {
                    setosa++;
                }
                else if (tabIrysow[item.Key].Kind == (iris_kind)1)
                {
                    versicolor++;
                }
                else if (tabIrysow[item.Key].Kind == (iris_kind)2)
                {
                    virginica++;
                }
            }
            Console.WriteLine("Glosow na setose: " + setosa);
            Console.WriteLine("Glosow na versicolor: " + versicolor);
            Console.WriteLine("Glosow na virginice: " + virginica);
            if (versicolor > setosa && versicolor > virginica)
                return "versicolor";
            else if (setosa > versicolor && setosa > virginica)
                return "setosa";
            else if (virginica > setosa && virginica > versicolor)
                return "virginica";
            else
                return "nie okreslono";
                


        }
        static void Main(string[] args)
        {
            string nazwatxt = "iris.txt";
            Iris[] tablica = Pobierz(nazwatxt);
            Iris DoKlasyfikacji1 = new Iris(6.7, 3.0, 5.2, 2.3);
            Iris DoKlasyfikacji2 = new Iris(5.1, 3.8, 1.5, 0.3);
            Iris DoKlasyfikacji3 = new Iris(7.4, 3.2, 5.2, 2.2);
            int k = 33;
            double[] d1 =PoliczMetrykeEuklidesowa(tablica, DoKlasyfikacji1);
            Dictionary<int, double> nearestneigbours = ZnajdzNajblizszychSasiadow(d1, k);
            tablica = Pobierz(nazwatxt);
            string wynik = Glosowanie(nearestneigbours, tablica);
            Console.WriteLine("WYNIK TO: " + wynik);
            tablica = Pobierz(nazwatxt);
            double[] d2 = PoliczMetrykeEuklidesowa(tablica, DoKlasyfikacji2);
            Dictionary<int, double> nearestneigbours2 = ZnajdzNajblizszychSasiadow(d2, k);
            tablica = Pobierz(nazwatxt);
            string wynik2 = Glosowanie(nearestneigbours2, tablica);
            Console.WriteLine("WYNIK TO: " + wynik2);
            double[] d3 = PoliczMetrykeEuklidesowa(tablica, DoKlasyfikacji3);
            Dictionary<int, double> nearestneigbours3 = ZnajdzNajblizszychSasiadow(d3, k);
            string wynik3 = Glosowanie(nearestneigbours3, tablica);
            Console.WriteLine("WYNIK TO: " + wynik3);
            Console.ReadLine();
        }
    }
}
