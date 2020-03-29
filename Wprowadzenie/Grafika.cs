using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wprowadzenie
{
    class Grafika
    {
        public Bitmap Macierz(string nazwa)
        {
            string path = nazwa + ".jpg";
            Bitmap btm = new Bitmap(path);
            return btm;
        }
        public void Filtr_Sharpen(Bitmap btm, string nazwa)
        {
            Bitmap btmF = new Bitmap(btm.Width, btm.Height);

            double[][] kernel = new double[3][];
            kernel[0] = new double[] { 0, -1, 0 };
            kernel[1] = new double[] { -1, 5, -1 };
            kernel[2] = new double[] { 0, -1, 0 };

            for (int i = 0; i < btm.Width - kernel.Length; i++)
            {
                for (int j = 0; j < btm.Height - kernel[0].Length; j++)
                {
                    double convR = 0, convG = 0, convB = 0;
                    for (int k = kernel.Length - 1; k > -1; k--)
                    {
                        for (int l = kernel[0].Length - 1; l > -1; l--)
                        {
                            Color pxl = btm.GetPixel(i + kernel.Length - 1 - k, j + kernel[0].Length - 1 - l);
                            convR += kernel[k][l] * pxl.R;
                            convG += kernel[k][l] * pxl.G;
                            convB += kernel[k][l] * pxl.B;
                        }
                    }
                    convR = convR < 0 ? 0 : convR;
                    convG = convG < 0 ? 0 : convG;
                    convB = convB < 0 ? 0 : convB;
                    btmF.SetPixel(i, j, Color.FromArgb((int)(convR > 255 ? 255 : convR), (int)(convG > 255 ? 255 : convG), (int)(convB > 255 ? 255 : convB)));
                }
            }
            string nowanazwa = nazwa + "_filtr_sharpen.jpg";
            btmF.Save(nowanazwa);

        }

        public void Filtr_EdgeDetection(Bitmap btm, string nazwa)
        {
            Bitmap btmF = new Bitmap(btm.Width, btm.Height);

            double[][] kernel = new double[3][];
            kernel[0] = new double[] { -1, -1, -1 };
            kernel[1] = new double[] { -1, 8, -1 };
            kernel[2] = new double[] { -1, -1, -1 };

            for (int i = 0; i < btm.Width - kernel.Length; i++)
            {
                for (int j = 0; j < btm.Height - kernel[0].Length; j++)
                {
                    double convR = 0, convG = 0, convB = 0;
                    for (int k = kernel.Length - 1; k > -1; k--)
                    {
                        for (int l = kernel[0].Length - 1; l > -1; l--)
                        {
                            Color pxl = btm.GetPixel(i + kernel.Length - 1 - k, j + kernel[0].Length - 1 - l);
                            convR += kernel[k][l] * pxl.R;
                            convG += kernel[k][l] * pxl.G;
                            convB += kernel[k][l] * pxl.B;
                        }
                    }
                    convR = convR < 0 ? 0 : convR;
                    convG = convG < 0 ? 0 : convG;
                    convB = convB < 0 ? 0 : convB;
                    btmF.SetPixel(i, j, Color.FromArgb((int)(convR > 255 ? 255 : convR), (int)(convG > 255 ? 255 : convG), (int)(convB > 255 ? 255 : convB)));
                }
            }
            string nowanazwa = nazwa + "_filtr_edgedetection.jpg";
            btmF.Save(nowanazwa);

        }
        public void Filtr_BoxBlur(Bitmap btm, string nazwa)
        {
            Bitmap btmF = new Bitmap(btm.Width, btm.Height);

            double[][] kernel = new double[3][];
            kernel[0] = new double[] { 1, 1, 1 };
            kernel[1] = new double[] { 1, 1, 1 };
            kernel[2] = new double[] { 1, 1, 1 };

            for (int i = 0; i < btm.Width - kernel.Length; i++)
            {
                for (int j = 0; j < btm.Height - kernel[0].Length; j++)
                {
                    double convR = 0, convG = 0, convB = 0;
                    for (int k = kernel.Length - 1; k > -1; k--)
                    {
                        for (int l = kernel[0].Length - 1; l > -1; l--)
                        {
                            Color pxl = btm.GetPixel(i + kernel.Length - 1 - k, j + kernel[0].Length - 1 - l);
                            convR += kernel[k][l] /9* pxl.R;
                            convG += kernel[k][l] /9 * pxl.G;
                            convB += kernel[k][l] /9* pxl.B;
                        }
                    }
                    convR = convR < 0 ? 0 : convR;
                    convG = convG < 0 ? 0 : convG;
                    convB = convB < 0 ? 0 : convB;
                    btmF.SetPixel(i, j, Color.FromArgb((int)(convR > 255 ? 255 : convR), (int)(convG > 255 ? 255 : convG), (int)(convB > 255 ? 255 : convB)));
                }
            }
            string nowanazwa = nazwa + "_filtr_boxblur.jpg";
            btmF.Save(nowanazwa);

        }
        public void Filtr_Uwypuklajacy_Wschod(Bitmap btm, string nazwa)
        {
            Bitmap btmF = new Bitmap(btm.Width, btm.Height);

            double[][] kernel = new double[3][];
            kernel[0] = new double[] { -1, 0, 1 };
            kernel[1] = new double[] { -1, 1, 1 };
            kernel[2] = new double[] { -1, 0, 1 };

            for (int i = 0; i < btm.Width - kernel.Length; i++)
            {
                for (int j = 0; j < btm.Height - kernel[0].Length; j++)
                {
                    double convR = 0, convG = 0, convB = 0;
                    for (int k = kernel.Length - 1; k > -1; k--)
                    {
                        for (int l = kernel[0].Length - 1; l > -1; l--)
                        {
                            Color pxl = btm.GetPixel(i + kernel.Length - 1 - k, j + kernel[0].Length - 1 - l);
                            convR += kernel[k][l]  * pxl.R;
                            convG += kernel[k][l]  * pxl.G;
                            convB += kernel[k][l]  * pxl.B;
                        }
                    }
                    convR = convR < 0 ? 0 : convR;
                    convG = convG < 0 ? 0 : convG;
                    convB = convB < 0 ? 0 : convB;
                    btmF.SetPixel(i, j, Color.FromArgb((int)(convR > 255 ? 255 : convR), (int)(convG > 255 ? 255 : convG), (int)(convB > 255 ? 255 : convB)));
                }
            }
            string nowanazwa = nazwa + "_filtr_uwypuklajacy_wschod.jpg";
            btmF.Save(nowanazwa);

        }
        public void Filtr_Gauss(Bitmap btm, string nazwa)
        {
            Bitmap btmF = new Bitmap(btm.Width, btm.Height);

            double[][] kernel = new double[3][];
            kernel[0] = new double[] { 1, 2, 1 };
            kernel[1] = new double[] { 2, 4, 2 };
            kernel[2] = new double[] { 1, 2, 1 };

            for (int i = 0; i < btm.Width - kernel.Length; i++)
            {
                for (int j = 0; j < btm.Height - kernel[0].Length; j++)
                {
                    double convR = 0, convG = 0, convB = 0;
                    for (int k = kernel.Length - 1; k > -1; k--)
                    {
                        for (int l = kernel[0].Length - 1; l > -1; l--)
                        {
                            Color pxl = btm.GetPixel(i + kernel.Length - 1 - k, j + kernel[0].Length - 1 - l);
                            convR += kernel[k][l] * pxl.R;
                            convG += kernel[k][l] * pxl.G;
                            convB += kernel[k][l] * pxl.B;
                        }
                    }
                    convR = convR < 0 ? 0 : convR;
                    convG = convG < 0 ? 0 : convG;
                    convB = convB < 0 ? 0 : convB;
                    btmF.SetPixel(i, j, Color.FromArgb((int)(convR > 255 ? 255 : convR), (int)(convG > 255 ? 255 : convG), (int)(convB > 255 ? 255 : convB)));
                }
            }
            string nowanazwa = nazwa + "_filtr_gauss.jpg";
            btmF.Save(nowanazwa);

        }
    }
}

