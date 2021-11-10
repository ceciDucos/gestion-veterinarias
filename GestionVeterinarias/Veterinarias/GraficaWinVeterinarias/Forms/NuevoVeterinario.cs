using LogicaVeterinarias.Controller;
using ModelosVeterinarias.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraficaWinVeterinarias.Forms
{
    public partial class NuevoVeterinario : Form
    {
        private FachadaWin facadaWin;

       
        public NuevoVeterinario(FachadaWin facadaWin)
        {
            InitializeComponent();
            this.facadaWin = facadaWin;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btbConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos()) {

                try
                {
                    VOVeterinario voveterianrio = CrearVO();
                    facadaWin.CrearVeterinario(voveterianrio);
                    MessageBox.Show("Veterinario ingresado con exito", "Gestion Veterinaria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BorrarDatos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestion Veterinaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        private void BorrarDatos() {
            TextBoxCedula.Text = String.Empty;
            textBoxNombre.Text = String.Empty;
            textBoxTelefono.Text = String.Empty;
            textBoxHorario.Text = String.Empty;

        }

        private VOVeterinario CrearVO()
        {
            VOVeterinario voveterinario = new VOVeterinario(Convert.ToInt64(TextBoxCedula.Text), textBoxNombre.Text,
                textBoxTelefono.Text, textBoxHorario.Text);
            return voveterinario;
        }

        private bool ValidarDatos() {
            bool exito = false;
            exito = ValidarCedula();
            exito = ValidarNombre();
            exito = ValidarTelefono();
            exito = ValidarHorario();
            return exito;

        }

        private bool ValidarCedula()
        {
            bool bStatus = true;
            if (TextBoxCedula.Text == "")
            {
                errorProvider1.SetError(TextBoxCedula, "Por favor ingrese la cedula");
                bStatus = false;
            }
            else
                errorProvider1.SetError(TextBoxCedula, "");
            return bStatus;
        }

        private bool ValidarNombre()
        {
            bool bStatus = true;
            if (textBoxNombre.Text == "")
            {
                errorProvider1.SetError(textBoxNombre, "Por favor ingrese el nombre");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBoxNombre, "");
            return bStatus;
        }

        private bool ValidarTelefono()
        {
            bool bStatus = true;
            if (textBoxTelefono.Text == "")
            {
                errorProvider1.SetError(textBoxTelefono, "Por favor ingrese el telefono");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBoxTelefono, "");
            return bStatus;
        }

        private bool ValidarHorario()
        {
            bool bStatus = true;
            if (textBoxHorario.Text == "")
            {
                errorProvider1.SetError(textBoxHorario, "Por favor ingrese el horario");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBoxHorario, "");
            return bStatus;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
