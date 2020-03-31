using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasteryzacja
{
    public enum iris_kind
    {
        setosa = 0,
        versicolor = 1,
        virginica = 2
    }
    public class Iris
    {
        public Iris()
        {
            x1 = 0;
            x2 = 0;
            x3 = 0;
            x4 = 0;
            kind = (iris_kind)0;
        }
        public Iris(double x1, double x2, double x3, double x4)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }
        private double x1;
        public double X1 { get { return x1; } set { x1 = value; } }
        private double x2;
        public double X2 { get { return x2; } set { x2 = value; } }
        private double x3;
        public double X3 { get { return x3; } set { x3 = value; } }
        private double x4;
        public double X4 { get { return x4; } set { x4 = value; } }
        private iris_kind kind;
        public iris_kind Kind { get; set; }
    }
}
