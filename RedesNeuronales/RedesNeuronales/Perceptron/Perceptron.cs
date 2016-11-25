using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedesNeuronales.Perceptron
{
   public class Perceptron
    {
        public int c { get; set; }
        public int[] n { get; set; }
        public double[,] x { get; set; }
        public double[,] y { get; set; }
        public double[,] z { get; set; }
        public double[,] a { get; set; }
        public int NumeroPatrones { get; set; }
        public double MaximoEntrada { get; set; }
        public double MinimoEntrada { get; set; }
        public double MaximoSalida { get; set; }
        public double MinimoSalida { get; set; }
        public double ErrorCuadratico { get; set; }
        public double ErrorEntrenamiento { get; set; }
        public double Alfa { get; set; }
        public Double[,] Delta { get; set; }

        Random rand = new Random();
        double sumaerror = 0.0;
        public Perceptron()
        {
            sumaerror = 0.0;
            ErrorCuadratico = 0.0;
        }
        public double signoidal(double x) {
            return 1/(1+ Math.Exp(x));
        }
        public void CrearUmbrales()
        {
            u = new double[c + 1, n.Max() + 1];


        }
    }
}
