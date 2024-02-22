using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Datos : Form
    {
        public Datos()
        {
            InitializeComponent();
        }

        private void Datos_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //CALCULAR CRÉDITOS
            //Método para calcular el valor de la matrícula

            const double valorCredito = 123000;
            double valorTotal = 0;

            // Obtener la cantidad de créditos seleccionados del ComboBox
            int cantidadCreditos = Convert.ToInt32(cmbCreditos.SelectedItem);

            //Ciclo for para multiplicar el valor del crédito ya asignado en la variable valorCredito y se da con la conversión del combbox de la lista de créditos
            for (int i = 1; i <= cantidadCreditos; i++)
            {
                valorTotal += valorCredito;
            }

            //Descuentos de porcentajes estratos, se da mediante un switch - case agrupando los estratos
            //CalcularDescuento(int estrato, bool tieneCertificado)
            // Obtener la cantidad de créditos seleccionados del ComboBox haciendo la conversión
            int estrato = Convert.ToInt32(cmbEstrato.SelectedItem);
            double descuentoEstrato = 0;
            switch (estrato)
            {
                case 1:
                case 2:
                    descuentoEstrato = 0.15;
                    break;
                case 3:
                case 4:
                    descuentoEstrato = 0.10;
                    break;
                case 5:
                case 6:
                    descuentoEstrato = 0.05;
                    break;
            }

            //Resultado Valor del descuento donde la variable descuentoEstrato es el resultado según el case anterior y valorTotal representa el valor total de los créditos
            double DctoEstrato = valorTotal * descuentoEstrato;

            //Descuento de votaciones
            double DctoVotaciones = 0;
            string NoVota = "";

            if (optSi.Checked)
            {
                DctoVotaciones = valorTotal * 0.10;
            }
            else
            {
                NoVota = (",No tiene derecho a descuento de votaciones");
            }

            //Proceso Valor Total a Pagar
            double TotalMatricula = valorTotal - DctoEstrato - DctoVotaciones;

            //Método de recolección de datos y visualización
            string cadena;
            cadena = "Nombre: " + txtNombre.Text + "\nIdentificación: " + txtIdentificacion.Text + "\nEdad: " + txtEdad.Text;
            cadena = cadena + "\nEstrato: " + cmbEstrato.Text;
            cadena = cadena + "\nCréditos matriculados: " + cmbCreditos.Text;

            cadena = cadena + "\nGénero: ";

            //Validación Genero
            if (optMasculino.Checked == true)
            {
                cadena = cadena + "Masculino";
            }
            else
            {
                if (optFemenino.Checked == true)
                {
                    cadena = cadena + "Femenino";
                }
                else
                {
                    cadena = cadena + "No especifica";
                }
            }

            //Validación votaciones Si/No
            if (optSi.Checked == true)
            {
                cadena = cadena + "\nVotó en las elecciones";
            }
            else
            {
                cadena = cadena + "\nNo votó en las elecciones";
            }

            cadena = cadena + "\nValor total a pagar: " + valorTotal;
            cadena = cadena + $"\nValor Descuento del Estrato: {DctoEstrato} "; //Interpolación de cadenas
            cadena = cadena + $"\nValor Descuento de Votaciones: {DctoVotaciones} {NoVota}";


            //Validación de datos para no enviar datos incompletos
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtIdentificacion.Text) || string.IsNullOrEmpty(txtEdad.Text) || string.IsNullOrEmpty(cmbCreditos.Text) || string.IsNullOrEmpty(cmbEstrato.Text) || string.IsNullOrEmpty(optMasculino.Text) || string.IsNullOrEmpty(optFemenino.Text) || string.IsNullOrEmpty(optNA.Text) || string.IsNullOrEmpty(optSi.Text) || string.IsNullOrEmpty(optNo.Text))
            { 
                MessageBox.Show("Por favor complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        



        //Mostrar en pantalla todos los datos recopilados

        MessageBox.Show(cadena);
            MessageBox.Show($"El valor total de la matricula es: $ {TotalMatricula}");

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}



