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
using System.Collections.Generic;

namespace GraficaWinVeterinarias.Forms
{
    public partial class GestionVeterinarios : Form
    {
        public FachadaWin fachadaWin;
        public GestionVeterinarios(FachadaWin FachadaWin)
        {
            InitializeComponent();
            this.fachadaWin = FachadaWin;
            CargarLista();

        }


        private void CargarLista() {
            List<VOVeterinario> lista = new List<VOVeterinario>();
            lista = fachadaWin.ObtenerVeterinarios();

            foreach (var item in lista)
            {
                ListViewItem listado = new ListViewItem(item.Cedula.ToString());
                listado.SubItems.Add(item.Nombre);
                listado.SubItems.Add(item.Telefono);
                listado.SubItems.Add(item.Horario);
                listView1.Items.Add(listado);
            }
            //listView1.View = View.List;

        }


      

        private void button1_Click_1(object sender, EventArgs e)
        {
            NuevoVeterinario FrmNuevoVeterinario;
            FrmNuevoVeterinario = new NuevoVeterinario(this.fachadaWin);
            FrmNuevoVeterinario.Owner = this;  // <-- This is the important thing
            FrmNuevoVeterinario.ShowDialog();
            listView1.Items.Clear();
            CargarLista();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lista in listView1.SelectedItems) {
                long cedula = long.Parse(lista.Text);
                try
                {
                    this.fachadaWin.EliminarVeterinario(cedula);
                    lista.Remove();
                    MessageBox.Show("Veterinario eliminado con exito", "Gestion Veterinaria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestion Veterinaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lista in listView1.SelectedItems)
            {
                long cedula = long.Parse(lista.Text);
                EditarVeterinario FrmEditarVeterinario;
                FrmEditarVeterinario = new EditarVeterinario(this.fachadaWin, cedula);
                FrmEditarVeterinario.Owner = this;  // <-- This is the important thing
                FrmEditarVeterinario.ShowDialog();
                listView1.Items.Clear();
                CargarLista();
            }
            

           
        }
    }
}
