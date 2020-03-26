using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayes_Limanowka
{
    class enums
    {
        public enum RodzajeTemperatury
        {
            chlodno=0,
            cieplo=1,
            goraco=2
        }
        public enum RodzajeWiatru
        {
            slaby=0,
            umiarkowany=1,
            mocny=2
        }
        public enum RodzajePogody
        {
            deszczowo=0,
            pochmurnie=1,
            slonecznie=2
        }
        public enum Decyzje
        {
            pozytywna = 0,
            negatywna =1
        }
    }
}
