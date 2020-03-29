using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wprowadzenie
{
    class Dane
    {
        public double[][] Pobierz(string path)
        {
            string[] lines = File.ReadAllLines(path);
            double[][] tablica = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                tablica[i] = new double[tmp.Length + 2];
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    tablica[i][j] = Convert.ToDouble(tmp[j].Replace('.', ','));
                }
                if (tmp[tmp.Length - 1] == "Iris-setosa")
                {
                    tablica[i][tmp.Length - 1] = 1;
                    tablica[i][tmp.Length] = 0;
                    tablica[i][tmp.Length + 1] = 0;
                }
                else if (tmp[tmp.Length - 1] == "Iris-versicolor")
                {
                    tablica[i][tmp.Length - 1] = 0;
                    tablica[i][tmp.Length] = 1;
                    tablica[i][tmp.Length + 1] = 0;
                }
                else if (tmp[tmp.Length - 1] == "Iris-virginica")
                {
                    tablica[i][tmp.Length - 1] = 0;
                    tablica[i][tmp.Length] = 0;
                    tablica[i][tmp.Length + 1] = 1;
                }
            }
            return tablica;
        }
        public double ZnajdzMax(double[][] lista, int k)
        {
            double max = lista[0][k];
            for (int i = 0; i < lista.Length; i++)
            {
                if (max < lista[i][k])
                {
                    max = lista[i][k];
                }
            }
            return max;
        }

        public double ZnajdzMin(double[][] lista, int k)
        {
            double min = lista[0][k];
            for (int i = 0; i < lista.Length; i++)
            {
                if (min > lista[i][k])
                {
                    min = lista[i][k];
                }
            }
            return min;
        }

        public double[][] Normalizuj(double[][] tablica)
        {
            double nmax = 1;
            double nmin = 0;
            double min;
            double max;
            for (int i = 0; i < 4; i++)
            {
                  min =ZnajdzMin(tablica, i);
                  max = ZnajdzMax(tablica, i);
                for (int j = 0; j < tablica.Length; j++)
                {
                    tablica[j][i] = ((tablica[j][i] - min) * (nmax - nmin)) / (max - min) + nmin;
                }               
            }
            return tablica;
        }
        public double[][] NormalizujMean(double[][] tablica)
        {
            double srednia = 0.0;
            int ile = 0;
            double min;
            double max;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < tablica.Length; j++)
                {
                    srednia += tablica[j][i];
                    ile++;
                }
            }
            srednia = srednia / ile;

            for (int i = 0; i < 4; i++)
            {
                max = ZnajdzMax(tablica, i);
                min = ZnajdzMin(tablica, i);
                for (int j = 0; j < tablica.Length; j++)
                {
                    tablica[j][i] = (tablica[j][i] - srednia) / (max - min);
                }
            }
            return tablica;
        }
        public double[][] NormalizujStandaryzacja(double[][] tablica)
        {
            double srednia = 0.0;
            int ile = 0;
            double odchylenie = 0.0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < tablica.Length; j++)
                {
                    srednia += tablica[j][i];
                    ile++;
                }
            }
            srednia = srednia / ile;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < tablica.Length; j++)
                {
                    odchylenie += ((tablica[j][i] - srednia) * (tablica[j][i] - srednia));

                }
            }
            odchylenie = odchylenie / ile;
            odchylenie = Math.Sqrt(odchylenie);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < tablica.Length; j++)
                {
                    tablica[j][i] = (tablica[j][i] - srednia) / odchylenie;
                }
            }
            return tablica;
        }

            public double[][] Tasuj(double[][] tablica)
        {
            Random random = new Random();
            for (int i = tablica.Length - 1; i > 0; i--)
            {
                int zmienIndex = random.Next(i + 1);
                double[] temp = tablica[i];
                tablica[i] = tablica[zmienIndex];
                tablica[zmienIndex] = temp;
            }
            return tablica;
        }
    }
}
