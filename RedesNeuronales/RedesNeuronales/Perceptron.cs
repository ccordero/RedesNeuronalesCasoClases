using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedesNeuronales.Perceptron
{
   public class Perceptron
    {
        public int C { get; set; }
        public int[] n { get; set; }
        public double[,] x { get; set; }
        public double[,] y { get; set; }
        public double[,] s { get; set; }
        public double[,] a { get; set; }
        public double[,] u { get; set; }
        public double[,,] w { get; set; }
        public int NumeroPatrones { get; set; }
        public double MaximoEntrada { get; set; }
        public double MinimoEntrada { get; set; }
        public double MaximoSalida { get; set; }
        public double MinimoSalida { get; set; }
        public double errorCuadratico { get; set; }
        public double ErrorEntrenamiento { get; set; }
        public double Alfa { get; set; }
        public Double[,] Delta { get; set; }

        Random rand = new Random();
        double sumaerror = 0.0;
        public Perceptron()
        {
            sumaerror = 0.0;
            errorCuadratico = 0.0;
        }
        public double Sigmoidal(double x) {
            return 1/(1+ Math.Exp(x));
        }
        public void CrearUmbrales()
        {
            u = new double[C + 1, n.Max() + 1];

            for (int c = 2; c <= C; c++)
            {
                for (int i = 1; i < n[C]; i++)
                {
                    u[c, i] = rand.NextDouble();
                }
            }


        }
        public void CrearPesos() {
            w = new double[C+1,n.Max()+1 ,n.Max() +1 ];
            for (int c = 1; c <= C-1; c++)
            {
                for (int i = 1; i <= n[c+1]; i++)
                {
                    for (int j = 1; j <=  n[c]; j++)
                    {
                        w[c,j,i] = rand.NextDouble();
                    }
                }
            }
        }
        public double Normalizacion(double valor, double _maximo , double _minimo) {
            return (1 / (_maximo - _minimo)) * (valor - _minimo);
        }
        public void NormalizarEntradas() {
            double[] Numeros = new double[NumeroPatrones];
            for (int i = 0; i < Numeros.Length; i++)
            {
                x[i, 0] = Normalizacion(x[i, 0], MaximoEntrada, MinimoEntrada);
            }
        }
        public void NormalizarSalidas()
        {
            double[] Numeros = new double[NumeroPatrones];
            for (int i = 0; i < Numeros.Length; i++)
            {
                s[i, 0] = Normalizacion(s[i, 0], MaximoSalida, MinimoSalida);
            }
        }
        public void EncuentraMaxMinEntradas() {

            double[] numeros = new double[NumeroPatrones];
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = x[i,0];
            }
            Array.Sort(numeros);
            MaximoSalida = numeros[numeros.Length - 1];
            MinimoSalida = numeros[0];
        }
        public void ActivacionEntrada(int patron)
        {
            for (int i = 0; i < n[i]; i++)
            {
                a[1, i] = x[patron, i - 1];
            }
        }
        public void PropagacionNeuronas()
        {
            double suma = 0.0;
            for (int c = 2; c <= C; c++)
            {
                for (int i = 0; i <= n[c]; i++)
                {
                    suma = 0.0;
                    for (int j = 0; j <= n[c-1]; j++)
                    {
                        suma += w[c - 1, j, i] * a[c-1,j];
                    }
                    a[c, i] = suma + u[c, i];
                    a[c, i] = Sigmoidal(a[c, i]);
                }
            }
        }
        public void ErrorCuadratico(int nPatron)
        {
            double temp = 0.0;
            for (int i = 0; i <= C; i++)
            {
                temp += Math.Pow(s[nPatron,0] - a[C,i],2);
                y[nPatron, 0] = a[C, i];
            }
            errorCuadratico = temp / 2;
            sumaerror = errorCuadratico + sumaerror;
        }
        public void Retropropagacion(int patron)
        {
            CalcularDeltra(patron);
            CalcularPesosYUmbrales();
        }
        private void CalcularDeltra(int patron)
        {
            double suma = 0.0;
            for (int i = 0; i <= C; i++)
            {
                Delta[C, i] = (s[patron, i - 1] - a[C, i]) * a[C, i] * (1 - a[C, i]);
            }
            for (int c = C-1; c > 1 ; c--)
            {
                for (int j = 0; j <= n[c]; j++)
                {
                    suma = 0.0;
                    for (int i = 0; i <= n[c+1]; i++)
                    {
                        suma += Delta[c+1,i]* w[c,j,i];
                    }
                    Delta[c, j] = a[c, j] * (1 - a[c, j]);
                }
            }
        }
        private void CalcularPesosYUmbrales()
        {
            for (int c = 0; c <= C-1; c++)
            {
                for (int i = 0; i <= n[c+1]; i++)
                {
                    for (int j = 0; j <= n[c]; j++)
                    {
                        w[c, j, i] = w[c, j, i] + Alfa * Delta[c + 1, i] * a[c, j];
                    }
                    u[c + 1, i] = u[c + 1, i] + Alfa * Delta[c + 1, i];
                }
            }
        }
        private void ErrordeAprendisaje()
        {
            ErrorEntrenamiento = sumaerror / NumeroPatrones;
            sumaerror = 0;
        }
    }
}
