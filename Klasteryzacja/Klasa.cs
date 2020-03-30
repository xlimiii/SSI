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
        
        static double[][] Pobierz(string path)
        {
            string[] lines = File.ReadAllLines(path);
            double[][] tablica = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                tablica[i] = new double[tmp.Length];
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    tablica[i][j] = Convert.ToDouble(tmp[j].Replace('.', ','));
                }
                if (tmp[tmp.Length - 1] == "Iris-setosa")
                {
                    tablica[i][tmp.Length - 1] =0;
                }
                else if (tmp[tmp.Length - 1] == "Iris-versicolor")
                {
                    tablica[i][tmp.Length - 1] = 1;
                    
                }
                else if (tmp[tmp.Length - 1] == "Iris-virginica")
                {
                    tablica[i][tmp.Length - 1] = 2;
                }
            }
            return tablica;
        }
        static double[] PoliczMetrykeEuklidesowa(double[][] tablica, double[] X)
        {
            double[] d = new double[tablica.Length];
            for(int i=0; i < tablica.Length; i++)
            {
                d[i] = Math.Sqrt((tablica[i][0] + X[0])* (tablica[i][0] + X[0]) + (tablica[i][1] + X[1])* (tablica[i][1] + X[1]) + (tablica[i][2] + X[2])* (tablica[i][2] + X[2]) + (tablica[i][3] + X[3])* (tablica[i][3] + X[3]));
            }
            return d;
        }
        static Dictionary<int, double> ZnajdzNajblizszychSasiadow(double[] d, double[][] tablica, int k)
        {
            Dictionary<int, double> nearestneighbours = new Dictionary<int, double>();
            for(int i = 0; i < k; i++)
            {
                nearestneighbours.Add(i, d[i]);
            }
            for (int j = k; j < d.Length; j++)
            {
                double min = nearestneighbours.Min(kvp => kvp.Value);
                if (d[j] > min)
                {
                    var item = nearestneighbours.First(kvp => kvp.Value == min);
                    nearestneighbours.Remove(item.Key);
                    nearestneighbours.Add(j, d[j]);
                }
            }
            return nearestneighbours;
        }
        static string Glosowanie(Dictionary<int, double> nearestneighbours, double[][] tablica)
        {
            int setosa = 0;
            int versicolor = 0;
            int virginica = 0;
            foreach (KeyValuePair<int, double> item in nearestneighbours)
            {
                if (tablica[item.Key][4] == 0)
                {
                    setosa++;
                }
                else if (tablica[item.Key][4] == 1)
                {
                    versicolor++;
                }
                else if (tablica[item.Key][4] == 2)
                {
                    virginica++;
                }
            }
            int max = setosa;
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
            double[][] tablica = Pobierz(nazwatxt);
            Console.WriteLine("Przed normalizacją: ");
            for (int i = 0; i < tablica.Length; i++)
            {
                for (int j = 0; j < tablica[i].Length; j++)
                {
                    Console.Write(tablica[i][j] + ", ");
                }
                Console.Write("\n");
            }
            double[] X = { 7, 2, 1.5, 1.8 };
            int k = 7;
            double[] d =PoliczMetrykeEuklidesowa(tablica, X);
            Dictionary<int, double> nearestneigbours = ZnajdzNajblizszychSasiadow(d, tablica, k);
            string wynik = Glosowanie(nearestneigbours, tablica);
            Console.WriteLine("WYNIK TO: " + wynik);
                            Console.ReadLine();

        }
    }
}
