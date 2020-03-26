using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayes_Limanowka
{
    class Przypadki
    {
        public Przypadki(short rp, short temp, short rw, short d)
        {
            this.rp = (enums.RodzajePogody)rp;
            this.temp = temp;
            this.rw = (enums.RodzajeWiatru)rw;
            this.d = (enums.Decyzje)d;
        }

        public Przypadki(short rp, short temp, short rw)
        {
            this.rp = (enums.RodzajePogody)rp;
            this.temp = temp;
            this.rw = (enums.RodzajeWiatru)rw;
            
        }
        private short temp;
        public short Temp { get {return temp; } set {temp = value; } }
        private enums.RodzajeTemperatury rt;
        public enums.RodzajeTemperatury RT
        {
            get
            {
                if (temp < 16)
                    return enums.RodzajeTemperatury.chlodno;
                else if (temp > 20)
                    return enums.RodzajeTemperatury.goraco;
                else
                    return enums.RodzajeTemperatury.cieplo;
            }
        }
        private enums.RodzajeWiatru rw;
        public enums.RodzajeWiatru RW { get { return rw; } }
        private enums.RodzajePogody rp;
        public enums.RodzajePogody RP { get { return rp; } }
        public enums.Decyzje d;
        public enums.Decyzje D { get { return d; } set { d = value; } }
    }
}
