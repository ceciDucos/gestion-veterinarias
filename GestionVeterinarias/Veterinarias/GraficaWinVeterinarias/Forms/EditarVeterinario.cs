﻿using LogicaVeterinarias.Controller;
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
    public partial class EditarVeterinario : Form
    {
        private FachadaWin facadaWin;
        long cedula;
        public EditarVeterinario(FachadaWin facadaWin, long cedula)
        {
            
            InitializeComponent();
            this.facadaWin = facadaWin;
            this.cedula = cedula;
            PreCargarForm(cedula);

        }

        private void PreCargarForm(long cedula) {
            VOVeterinario veterinario = facadaWin.ObtenerVeterinario(cedula);
            lblCedulaValor.Text = veterinario.Cedula.ToString();
            textBoxNombre.Text = veterinario.Nombre;
            textBoxTelefono.Text = veterinario.Telefono;
            textBoxHorario.Text = veterinario.Horario;

            textBoxNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                VOVeterinario voveterianrio = CrearVO();
                facadaWin.EditarVeterinario(voveterianrio);
                MessageBox.Show("Veterinario editado con exito", "Gestion Veterinaria", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestion Veterinaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private VOVeterinario CrearVO()
        {
            VOVeterinario voveterinario = new VOVeterinario(Convert.ToInt64(this.cedula), textBoxNombre.Text,
                textBoxTelefono.Text, textBoxHorario.Text);
            return voveterinario;
        }

        private bool ValidarDatos()
        {
            bool exito = false;
            exito = ValidarNombre();
            exito = ValidarTelefono();
            exito = ValidarHorario();
            return exito;

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

        private void EditarVeterinario_Load(object sender, EventArgs e)
        {

        }
    }
}
