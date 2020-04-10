using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemyRozmyte
{
    public class Miasta
    {
        public Miasta(double zanieczyszczenie, double naslonecznienie, string nazwa)
        {
            this.naslonecznienie = naslonecznienie;
            this.zanieczyszczenie = zanieczyszczenie;
            this.nazwa = nazwa;
        }
        private string nazwa;
        public string Nazwa { get { return nazwa; } set { nazwa = value; } }
        private double naslonecznienie;
        public double Naslonecznienie { get { return naslonecznienie; } set { naslonecznienie = value; } }
        private double zanieczyszczenie;
        public double Zanieczyszczenie { get { return zanieczyszczenie; } set { zanieczyszczenie = value; } }
        private List<double> results = new List<double>();
        public List<double> Results { get { return results; } set { results = value; } }
        private List<double> zanieczyszczenieFuzzy = new List<double>();
        public List<double> ZanieczyszczenieFuzzy { get { return zanieczyszczenieFuzzy; } set { zanieczyszczenieFuzzy = value; } }
        private List<double> naslonecznienieFuzzy = new List<double>();
        public List<double> NaslonecznienieFuzzy { get { return naslonecznienieFuzzy; } set { naslonecznienieFuzzy = value; } }
        private List<double> resultOfRules = new List<double>();
        public List<double> ResultOfRules { get { return resultOfRules; } set { resultOfRules = value; } }
        private double result;
        public double Result { get { return result; } set { result = value; } }


        public void Wnioskowanie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    results.Add(SystemyRozmyte.min(zanieczyszczenieFuzzy[i], naslonecznienieFuzzy[j]));
                }
            }
        }

        public void Wyostrzanie()
        {
            resultOfRules.Add(0.6);
            resultOfRules.Add(0.8);
            resultOfRules.Add(1);
            resultOfRules.Add(0.4);
            resultOfRules.Add(0.5);
            resultOfRules.Add(0.7);
            resultOfRules.Add(0.1);
            resultOfRules.Add(0.2);
            resultOfRules.Add(0.3);
            double decision = 0;
            double tmp = 0;
            for (int i = 0; i < resultOfRules.Count; i++)
            {
                decision += results[i] * resultOfRules[i];
            }
            for (int i = 0; i < results.Count; i++)
            {
                tmp += results[i];
            }
            this.result = decision / tmp;
        }

        public string WynikLingwistycznie(double result)
        {
            if (result < 0.3)
                return "słaba jakość życia";
            else if (result >= 0.3 && result <= 0.5)
                return "przeciętna jakość życia";
            else if (result > 0.5 && result < 0.7)
                return "dobra jakość życia";
            else if (result >= 0.7 && result < 0.9)
                return "bardzo dobra jakość życia";
            else
                return "idealna";
        }

    } 
}
