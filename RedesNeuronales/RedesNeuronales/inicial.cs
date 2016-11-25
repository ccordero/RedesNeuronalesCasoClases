using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace RedesNeuronales
{
    public partial class inicial : Form
    {
        int[] arquitectura;
        double[,] PatronesdeEntrada;
        double[,] PatronesSalida;
        int NumeroDeCapas = 0, NeuronasDeEntrada = 0, NeuronasDeSalida = 0, NPatrones = 4;
        Int32 iteraciones = 0;
        int[] n;
        double Alfa = 0.75, ErrorMinimo = 0.0001 , IteracionesMaximas = 10000.0;

        public inicial()
        {

            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void inicial_Load(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private int obtenercolor() {
            return 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Tipo = (int)comboBox1.SelectedValue;
            int Formal = (int)comboBox5.SelectedValue;
            int Talla = (int)comboBox4.SelectedValue;
            int Color = obtenercolor(); 
            int Diseno = (int)comboBox2.SelectedValue;
            int MPago = (int)comboBox6.SelectedValue;
            int Marca = (int)comboBox7.SelectedValue;
            int ZTalla = (int)comboBox20.SelectedValue;
            int ZTipo = (int)comboBox17.SelectedValue;
            int ZDiseno = (int)comboBox19.SelectedValue;
            PatronesdeEntrada = new double [NPatrones + 1 , arquitectura[1]];
            PatronesSalida = new double [NPatrones + 1 , arquitectura[1]];

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("inteligencia artificial","inteligencia Artificial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
