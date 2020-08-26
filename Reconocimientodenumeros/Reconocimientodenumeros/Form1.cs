using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Libredneuronal.RedNeuronal;
using Libredneuronal.RedNeuronal.Backpropagation;

namespace Reconocimientodenumeros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private RedBackpropagation network;
        double ddd = 0;
        double[] salida = new double[10];
        double[] rec = new double[45];
        double[,] numarec = new double[9, 5];

        double[] cero = new double[45] 
             {1, 1, 1, 1, 1,
              1, 0, 0, 0, 1,
              1, 0, 0, 0, 1,
              1, 0, 0, 0, 1,
              1, 0, 0, 0, 1,
              1, 0, 0, 0, 1,
              1, 0, 0, 0, 1,
              1, 0, 0, 0, 1,
              1, 1, 1, 1, 1};
        double[] cero2 = new double[45] 
             {0, 1, 1, 1, 0,
              0, 1, 0, 1, 0,
              0, 1, 0, 1, 0,
              0, 1, 0, 1, 0,
              0, 1, 0, 1, 0,
              0, 1, 0, 1, 0,
              0, 1, 0, 1, 0,
              0, 1, 0, 1, 0,
              0, 1, 1, 1, 0};
      
        double[] uno = new double[45] 
            {0, 0, 0, 1, 1,
             0, 0, 1, 0, 1,
             0, 1, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1};

        double[] uno2 = new double[45] 
            {0, 0, 1, 0, 0,
             0, 1, 1, 0, 0,
             1, 0, 1, 0, 0,
             0, 0, 1, 0, 0,
             0, 0, 1, 0, 0,
             0, 0, 1, 0, 0,
             0, 0, 1, 0, 0,
             0, 0, 1, 0, 0,
             1, 1, 1, 1, 1};

        double[] uno3 = new double[45] 
            {1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0};

        double[] dos = new double[45] 
            {0, 1, 1, 1, 0,
             1, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 1, 0,
             0, 0, 1, 0, 0,
             0, 1, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 1, 1, 1, 1};
        double[] dos2 = new double[45] 
            {1, 1, 1, 1, 0,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 1, 1, 1, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 1, 1, 1, 1};

        double[] tres = new double[45] 
            {1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 1, 0,
             0, 0, 1, 0, 0,
             0, 1, 1, 1, 0,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 1, 1, 0};
        double[] tres2 = new double[45] 
            {1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             1, 1, 1, 1, 0,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             1, 1, 1, 1, 1};
        double[] tres3 = new double[45] 
            {0, 1, 1, 1, 0,
             1, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 1, 1, 1, 0,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 1, 1, 0};

        double[] cuatro = new double[45] 
            {1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1};
        double[] cuatro2 = new double[45] 
            {1, 0, 0, 1, 0,
             1, 0, 0, 1, 0,
             1, 0, 0, 1, 0,
             1, 0, 0, 1, 0,
             1, 0, 0, 1, 0,
             1, 1, 1, 1, 1,
             0, 0, 0, 1, 0,
             0, 0, 0, 1, 0,
             0, 0, 0, 1, 0};
        double[] cuatro3 = new double[45] 
            {0, 0, 0, 0, 1,
             0, 0, 0, 1, 1,
             0, 0, 1, 0, 1,
             0, 1, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1};
        double[] cuatro4 = new double[45] 
            {1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1};
        double[] cuatro5 = new double[45] 
            {0, 0, 0, 1, 0,
             0, 0, 1, 1, 0,
             0, 1, 0, 1, 0,
             1, 0, 0, 1, 0,
             1, 1, 1, 1, 1,
             0, 0, 0, 1, 0,
             0, 0, 0, 1, 0,
             0, 0, 0, 1, 0,
             0, 0, 0, 1, 0};
        double[] cuatro6 = new double[45] 
            {0, 0, 0, 0, 1,
             0, 0, 0, 1, 1,
             0, 0, 1, 0, 1,
             0, 1, 0, 0, 1,
             1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1};

        double[] cinco = new double[45] 
            {1, 1, 1, 1, 1,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 1, 1, 1, 0,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 1, 1, 0};
        double[] cinco2 = new double[45] 
            {1, 1, 1, 1, 1,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             1, 1, 1, 1, 1};
        double[] cinco3 = new double[45] 
            {0, 1, 1, 1, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             0, 1, 1, 1, 0,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 1, 1, 1, 0};

        double[] seis = new double[45] 
            {0, 1, 1, 1, 0,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 1, 1, 0,
             1, 1, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 1, 1, 0};
        double[] seis2 = new double[45] 
            {1, 1, 1, 1, 1,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 1, 1, 1, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 1, 1, 1, 1};
        double[] seis3 = new double[45] 
            {0, 0, 0, 0, 1,
             0, 0, 0, 1, 0,
             0, 0, 1, 0, 0,
             0, 1, 0, 0, 0,
             1, 1, 1, 1, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 0, 1, 0,
             0, 0, 1, 0, 0};

        double[] siete = new double[45] 
            {1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 1, 0,
             0, 0, 1, 0, 0,
             0, 1, 0, 0, 0,
             1, 0, 0, 0, 0};
        double[] siete2 = new double[45] 
            {1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 1, 0,
             1, 1, 1, 1, 1,
             0, 1, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0,
             1, 0, 0, 0, 0};
        double[] siete3 = new double[45] 
            {1, 1, 1, 1, 1,
             0, 0, 0, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 1, 0,
             1, 1, 1, 1, 1,
             0, 0, 1, 0, 0,
             0, 0, 1, 0, 0,
             0, 0, 1, 0, 0};

        double[] ocho = new double[45] 
            {1, 1, 1, 1, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 1, 1, 1, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 1, 1, 1, 1};
        double[] ocho2 = new double[45] 
            {0, 1, 1, 1, 0,
             0, 1, 0, 1, 0,
             0, 1, 0, 1, 0,
             0, 1, 0, 1, 0,
             0, 1, 1, 1, 0,
             0, 1, 0, 1, 0,
             0, 1, 0, 1, 0,
             0, 1, 0, 1, 0,
             0, 1, 1, 1, 0};
        double[] ocho3 = new double[45] 
            {0, 1, 1, 1, 0,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 1, 1, 0,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 1, 1, 0};

        double[] nueve = new double[45] 
            {0, 1, 1, 1, 0,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 1, 1, 0};
        double[] nueve2 = new double[45] 
            {1, 1, 1, 1, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 1, 1, 1, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1,
             0, 0, 0, 0, 1};
        double[] nueve3 = new double[45] 
            {0, 1, 1, 1, 0,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             1, 0, 0, 0, 1,
             0, 1, 1, 1, 1,
             0, 0, 0, 1, 0,
             0, 0, 1, 0, 0,
             0, 1, 0, 0, 0,
             1, 0, 0, 0, 0};

        private void button1_Click(object sender, EventArgs e)
        {
            //FILA 1
            if (checkBox5.Checked)
            {
                numarec[0, 0] = 1;
            }
            if (checkBox4.Checked)
            {
                numarec[0, 1] = 1;
            }
            if (checkBox3.Checked)
            {
                numarec[0, 2] = 1;
            }
            if (checkBox2.Checked)
            {
                numarec[0, 3] = 1;
            }
            if (checkBox1.Checked)
            {
                numarec[0, 4] = 1;
            }
            //FILA 2
            if (checkBox10.Checked)
            {
                numarec[1, 0] = 1;
            }
            if (checkBox9.Checked)
            {
                numarec[1, 1] = 1;
            }
            if (checkBox8.Checked)
            {
                numarec[1, 2] = 1;
            }
            if (checkBox7.Checked)
            {
                numarec[1, 3] = 1;
            }
            if (checkBox6.Checked)
            {
                numarec[1, 4] = 1;
            }
            //FILA 3
            if (checkBox15.Checked)
            {
                numarec[2, 0] = 1;
            }
            if (checkBox14.Checked)
            {
                numarec[2, 1] = 1;
            }
            if (checkBox13.Checked)
            {
                numarec[2, 2] = 1;
            }
            if (checkBox12.Checked)
            {
                numarec[2, 3] = 1;
            }
            if (checkBox11.Checked)
            {
                numarec[2, 4] = 1;
            }
            //FILA 4
            if (checkBox20.Checked)
            {
                numarec[3, 0] = 1;
            }
            if (checkBox19.Checked)
            {
                numarec[3, 1] = 1;
            }
            if (checkBox18.Checked)
            {
                numarec[3, 2] = 1;
            }
            if (checkBox17.Checked)
            {
                numarec[3, 3] = 1;
            }
            if (checkBox16.Checked)
            {
                numarec[3, 4] = 1;
            }
            //FILA 5
            if (checkBox25.Checked)
            {
                numarec[4, 0] = 1;
            }
            if (checkBox24.Checked)
            {
                numarec[4, 1] = 1;
            }
            if (checkBox23.Checked)
            {
                numarec[4, 2] = 1;
            }
            if (checkBox22.Checked)
            {
                numarec[4, 3] = 1;
            }
            if (checkBox21.Checked)
            {
                numarec[4, 4] = 1;
            }
            //FILA 6
            if (checkBox30.Checked)
            {
                numarec[5, 0] = 1;
            }
            if (checkBox29.Checked)
            {
                numarec[5, 1] = 1;
            }
            if (checkBox28.Checked)
            {
                numarec[5, 2] = 1;
            }
            if (checkBox27.Checked)
            {
                numarec[5, 3] = 1;
            }
            if (checkBox26.Checked)
            {
                numarec[5, 4] = 1;
            }
            //FILA 7
            if (checkBox35.Checked)
            {
                numarec[6, 0] = 1;
            }
            if (checkBox34.Checked)
            {
                numarec[6, 1] = 1;
            }
            if (checkBox33.Checked)
            {
                numarec[6, 2] = 1;
            }
            if (checkBox32.Checked)
            {
                numarec[6, 3] = 1;
            }
            if (checkBox31.Checked)
            {
                numarec[6, 4] = 1;
            }
            //FILA 8
            if (checkBox40.Checked)
            {
                numarec[7, 0] = 1;
            }
            if (checkBox39.Checked)
            {
                numarec[7, 1] = 1;
            }
            if (checkBox38.Checked)
            {
                numarec[7, 2] = 1;
            }
            if (checkBox37.Checked)
            {
                numarec[7, 3] = 1;
            }
            if (checkBox36.Checked)
            {
                numarec[7, 4] = 1;
            }
            //FILA 9
            if (checkBox45.Checked)
            {
                numarec[8, 0] = 1;
            }
            if (checkBox44.Checked)
            {
                numarec[8, 1] = 1;
            }
            if (checkBox43.Checked)
            {
                numarec[8, 2] = 1;
            }
            if (checkBox42.Checked)
            {
                numarec[8, 3] = 1;
            }
            if (checkBox41.Checked)
            {
                numarec[8, 4] = 1;
            }
            int c = 0;
            for (int y = 0; y <= 8; y++)
            {
                for (int x = 0; x <= 4; x++)
                {
                    rec[c] = System.Convert.ToDouble(numarec[y, x]);
                    c++;
                }
            }
            label3.Text = "Lista la introducción";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SigmoidLayer capaentrada = new SigmoidLayer(45);
            SigmoidLayer capaoculta = new SigmoidLayer(9);
            SigmoidLayer capasalida = new SigmoidLayer(10);
            new ConexionBackpropagation(capaentrada, capaoculta);
            new ConexionBackpropagation(capaoculta, capasalida);
            network = new RedBackpropagation(capaentrada, capasalida);
            network.SetLearningRate(0.05);

            Ajusteentrenamiento grupoent = new Ajusteentrenamiento(45, 10);
           
            grupoent.Add(new Entrenamiento(cero, new double[10] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(cero2, new double[10] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));

            grupoent.Add(new Entrenamiento(uno, new double[10] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(uno2, new double[10] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(uno3, new double[10] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 }));

            grupoent.Add(new Entrenamiento(dos, new double[10] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(dos2, new double[10] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 }));

            grupoent.Add(new Entrenamiento(tres, new double[10] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(tres2, new double[10] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(tres3, new double[10] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 }));

            grupoent.Add(new Entrenamiento(cuatro, new double[10] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(cuatro2, new double[10] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(cuatro3, new double[10] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(cuatro4, new double[10] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(cuatro5, new double[10] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(cuatro6, new double[10] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }));

            grupoent.Add(new Entrenamiento(cinco, new double[10] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(cinco2, new double[10] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(cinco3, new double[10] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 }));

            grupoent.Add(new Entrenamiento(seis, new double[10] { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(seis2, new double[10] { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 }));
            grupoent.Add(new Entrenamiento(seis3, new double[10] { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 }));

            grupoent.Add(new Entrenamiento(siete, new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 }));
            grupoent.Add(new Entrenamiento(siete2, new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 }));
            grupoent.Add(new Entrenamiento(siete3, new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 }));

            grupoent.Add(new Entrenamiento(ocho, new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 }));
            grupoent.Add(new Entrenamiento(ocho2, new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 }));
            grupoent.Add(new Entrenamiento(ocho3, new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 }));

            grupoent.Add(new Entrenamiento(nueve, new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
            grupoent.Add(new Entrenamiento(nueve2, new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
            grupoent.Add(new Entrenamiento(nueve3, new double[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
            network.Learn(grupoent, 5000);
            network.StopLearning();
            label3.Text = "Listo el entrenamiento";
             }

        private void button3_Click_1(object sender, EventArgs e)
              {
                  double ls = 0.5, li = 0.15, lsp = 0.04, lip=0.02 ;
                  salida = new double[10] {0,0,0,0,0,0,0,0,0,0};
                  salida = network.Run(rec);
                  label4.Text = (1-network.MeanSquaredError).ToString("0.000000");
                  if (salida[0] >= ls && salida[1] <= li && salida[2] <= li && salida[3] <= li && salida[4] <= li && salida[5] <= li && salida[6] <= li && salida[7] <= li && salida[8] <= li && salida[9] <= li)
                  {
                      label3.Text = "El número es cero";
                      ddd = 0;
                  }
                  else if (salida[0] >= ls && salida[1] >= ls && salida[2] <= li && salida[3] <= li && salida[4] <= li && salida[5] <= li && salida[6] <= li && salida[7] <= li && salida[8] <= li && salida[9] <= li)
                  {
                      label3.Text = "El número es uno";
                      ddd = 1;
                  }
                  else if (salida[0] >= ls && salida[1] >= ls && salida[2] >= ls && salida[3] <=li && salida[4] <= li && salida[5] <= li && salida[6] <= li && salida[7] <= li && salida[8] <= li && salida[9] <= li)
                  {
                      label3.Text = "El número es dos";
                      ddd = 2;
                  }
                  else if (salida[0] >= ls && salida[1] >= ls && salida[2] >= ls && salida[3] >= ls && salida[4] <= li && salida[5] <= li && salida[6] <= li && salida[7] <= li && salida[8] <= li && salida[9] <= li)
                  {
                      label3.Text = "El número es tres";
                      ddd = 3;
                  }
                  else if (salida[0] >= ls && salida[1] >= ls && salida[2] >= ls && salida[3] >= ls && salida[4] >= ls && salida[5] <= li && salida[6] <= li && salida[7] <= li && salida[8] <= li && salida[9] <= li)
                  {
                      label3.Text = "El número es cuatro";
                      ddd = 4;
                  }
                  else if (salida[0] >= ls && salida[1] >= ls && salida[2] >= ls && salida[3] >= ls && salida[4] >= ls && salida[5] >= ls && salida[6] <= li && salida[7] <= li && salida[8] <= li && salida[9] <= li)
                  {
                      label3.Text = "El número es cinco"; 
                      ddd = 5;
                  }
                  else if (salida[0] >= ls && salida[1] >= ls && salida[2] >= ls && salida[3] >= ls && salida[4] >= ls && salida[5] >= ls && salida[6] >= ls && salida[7] <= li && salida[8] <= li && salida[9] <= li)
                  {
                      label3.Text = "El número es seis";
                      ddd = 6;
                  }
                  else if (salida[0] >= ls && salida[1] >= ls && salida[2] >= ls && salida[3] >= ls && salida[4] >= ls && salida[5] >= ls && salida[6] >= ls && salida[7] >= ls && salida[8] <= li && salida[9] <= li)
                  {
                      label3.Text = "El número es siete";
                      ddd = 7;
                  }
                  else if (salida[0] >= ls && salida[1] >= ls && salida[2] >= ls && salida[3] >= ls && salida[4] >= ls && salida[5] >= ls && salida[6] >= ls && salida[7] >= ls && salida[8] >= ls && salida[9] <= li)
                  {
                      label3.Text = "El número es ocho";
                      ddd = 8;
                  }
                  else if (salida[0] >= ls && salida[1] >= ls && salida[2] >= ls && salida[3] >= ls && salida[4] >= ls && salida[5] >= ls && salida[6] >= ls && salida[7] >= ls && salida[8] >= ls && salida[9] >= ls)
                  {
                      label3.Text = "El número es nueve";
                      ddd = 9;
                  }
                  else
                  {
                      if (salida[0] >= lsp && salida[1] <= lip && salida[2] <= lip && salida[3] <= lip && salida[4] <= lip && salida[5] <= lip && salida[6] <= lip && salida[7] <= lip && salida[8] <= lip && salida[9] <= lip)
                      {
                          label3.Text = "El numero no se reconoce pero parece un cero";
                          ddd = 0;
                      }
                      else if (salida[0] >= lsp && salida[1] >= lsp && salida[2] <= lip && salida[3] <= lip && salida[4] <= lip && salida[5] <= lip && salida[6] <= lip && salida[7] <= lip && salida[8] <= lip && salida[9] <= lip)
                      {
                          label3.Text = "El numero no se reconoce pero parece un uno";
                          ddd = 1;
                      }
                      else if (salida[0] >= lsp && salida[1] >= lsp && salida[2] >= lsp && salida[3] <= lip && salida[4] <= lip && salida[5] <= lip && salida[6] <= lip && salida[7] <= lip && salida[8] <= lip && salida[9] <= lip)
                      {
                          label3.Text = "El numero no se reconoce pero parece un dos";
                          ddd = 2;
                      }
                      else if (salida[0] >= lsp && salida[1] >= lsp && salida[2] >= lsp && salida[3] >= lsp && salida[4] <= lip && salida[5] <= lip && salida[6] <= lip && salida[7] <= lip && salida[8] <= lip && salida[9] <= lip)
                      {
                          label3.Text = "El numero no se reconoce pero parece un tres";
                          ddd = 3;
                      }
                      else if (salida[0] >= lsp && salida[1] >= lsp && salida[2] >= lsp && salida[3] >= lsp && salida[4] >= lsp && salida[5] <= lip && salida[6] <= lip && salida[7] <= lip && salida[8] <= lip && salida[9] <= lip)
                      {
                          label3.Text = "El numero no se reconoce pero parece un cuatro";
                          ddd = 4;
                      }
                      else if (salida[0] >= lsp && salida[1] >= lsp && salida[2] >= lsp && salida[3] >= lsp && salida[4] >= lsp && salida[5] >= lsp && salida[6] <= lip && salida[7] <= lip && salida[8] <= lip && salida[9] <= lip)
                      {
                          label3.Text = "El numero no se reconoce pero parece un cinco";
                          ddd = 5;
                      }
                      else if (salida[0] >= lsp && salida[1] >= lsp && salida[2] >= lsp && salida[3] >= lsp && salida[4] >= lsp && salida[5] >= lsp && salida[6] >= lsp && salida[7] <= lip && salida[8] <= lip && salida[9] <= lip)
                      {
                          label3.Text = "El numero no se reconoce pero parece un seis";
                          ddd = 6;
                      }
                      else if (salida[0] >= lsp && salida[1] >= lsp && salida[2] >= lsp && salida[3] >= lsp && salida[4] >= lsp && salida[5] >= lsp && salida[6] >= lsp && salida[7] >= lsp && salida[8] <= lip && salida[9] <= lip)
                      {
                          label3.Text = "El numero no se reconoce pero parece un siete";
                          ddd = 7;
                      }
                      else if (salida[0] >= lsp && salida[1] >= lsp && salida[2] >= lsp && salida[3] >= lsp && salida[4] >= lsp && salida[5] >= lsp && salida[6] >= lsp && salida[7] >= lsp && salida[8] >= lsp && salida[9] <= lip)
                      {
                          label3.Text = "El numero no se reconoce pero parece un ocho";
                          ddd = 8;
                      }
                      else if (salida[0] >= lsp && salida[1] >= lsp && salida[2] >= lsp && salida[3] >= lsp && salida[4] >= lsp && salida[5] >= lsp && salida[6] >= lsp && salida[7] >= lsp && salida[8] >= lsp && salida[9] >= lsp)
                      {
                          label3.Text = "El numero no se reconoce pero parece un nueve";
                          ddd = 9;
                      }
                      else
                      {
                          label3.Text = "El numero no se reconoce";
                      }
                  }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            label4.Text = cero[50].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            salida = new double[10]{0,0,0,0,0,0,0,0,0,0};
            rec = new double[45]
            {0,0,0,0,0,
             0,0,0,0,0,
             0,0,0,0,0,
             0,0,0,0,0,
             0,0,0,0,0,
             0,0,0,0,0,
             0,0,0,0,0,
             0,0,0,0,0,
             0,0,0,0,0};
            numarec = new double[9, 5]
            {{0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0}};
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
