using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Nombre estudiante: Steven Alejandro Marín Salazar
//Grupo: 33
//Centro: CEAD Medellín/Zona Occidente
//Escuela: Escuela de Ciencias Básicas Tecnologías e Ingeniería
//Programa: Ingeniería de sistemas
//Curso: Estructura de Datos
//Código fuente: Autoría propia


namespace SimuladorMatricula
{
    public partial class Logueo : Form
    {
        public Logueo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                MessageBox.Show("Digite la contraseña");
            }
            else
            {
                if (txtClave.Text == "123")
                {
                    //Activar el inicio de sesión, siguiente formulario
                    MessageBox.Show("Contraseña Correcta");
                    Datos MiDatos = new Datos();
                    MiDatos.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña inválida");
                    txtClave.Clear(); 
                }
            }
            txtClave.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
