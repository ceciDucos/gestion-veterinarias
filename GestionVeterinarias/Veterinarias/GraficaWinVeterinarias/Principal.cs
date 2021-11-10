using GraficaWinVeterinarias.Forms;
using LogicaVeterinarias.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraficaWinVeterinarias
{
    public partial class Principal : Form
    {
        public FachadaWin fachadaWin;
        public Principal()
        {
            InitializeComponent();
            fachadaWin = new FachadaWin();
        }

        private void veterinariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gestionVeterinariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionVeterinarios FrmGestionVeterinarios;
            FrmGestionVeterinarios = new GestionVeterinarios(fachadaWin);
            FrmGestionVeterinarios.Owner = this;  
            FrmGestionVeterinarios.Show();
        }

        private void gestionClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionClientes FrmGestionClientes;
            FrmGestionClientes = new GestionClientes();
            FrmGestionClientes.Owner = this;  
            FrmGestionClientes.Show();
        }

        private void cargarDatosInicialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                fachadaWin.CrearDB();
                fachadaWin.CrearTablas();
                fachadaWin.CargarDatos();
                MessageBox.Show("Creación y carga inicial de datos finalizada", "Gestion Veterinaria - Cargando datos iniciales", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Gestion Veterinaria - Cargando datos iniciales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
    }
}
