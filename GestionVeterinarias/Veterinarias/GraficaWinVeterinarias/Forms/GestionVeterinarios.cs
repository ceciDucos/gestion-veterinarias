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
                listView1.Items.Add(item.ToString()); 
                listView1.View = View.List;

            }

        }
       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NuevoVeterinario FrmNuevoVeterinario;
            FrmNuevoVeterinario = new NuevoVeterinario(this.fachadaWin);
            FrmNuevoVeterinario.Owner = this;  // <-- This is the important thing
            FrmNuevoVeterinario.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
