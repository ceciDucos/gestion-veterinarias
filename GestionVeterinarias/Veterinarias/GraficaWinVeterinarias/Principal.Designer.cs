
namespace GraficaWinVeterinarias
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veterinariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionVeterinariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.historicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.consultasToolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.veterinariosToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // gestionClientesToolStripMenuItem
            // 
            this.gestionClientesToolStripMenuItem.Name = "gestionClientesToolStripMenuItem";
            this.gestionClientesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestionClientesToolStripMenuItem.Text = "Gestion Clientes";
            this.gestionClientesToolStripMenuItem.Click += new System.EventHandler(this.gestionClientesToolStripMenuItem_Click);
            // 
            // veterinariosToolStripMenuItem
            // 
            this.veterinariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionVeterinariosToolStripMenuItem});
            this.veterinariosToolStripMenuItem.Name = "veterinariosToolStripMenuItem";
            this.veterinariosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.veterinariosToolStripMenuItem.Text = "Veterinarios";
            this.veterinariosToolStripMenuItem.Click += new System.EventHandler(this.veterinariosToolStripMenuItem_Click);
            // 
            // gestionVeterinariosToolStripMenuItem
            // 
            this.gestionVeterinariosToolStripMenuItem.Name = "gestionVeterinariosToolStripMenuItem";
            this.gestionVeterinariosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestionVeterinariosToolStripMenuItem.Text = "Gestion Veterinarios";
            this.gestionVeterinariosToolStripMenuItem.Click += new System.EventHandler(this.gestionVeterinariosToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem1
            // 
            this.consultasToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historicoToolStripMenuItem});
            this.consultasToolStripMenuItem1.Name = "consultasToolStripMenuItem1";
            this.consultasToolStripMenuItem1.Size = new System.Drawing.Size(86, 24);
            this.consultasToolStripMenuItem1.Text = "Consultas";
            // 
            // historicoToolStripMenuItem
            // 
            this.historicoToolStripMenuItem.Name = "historicoToolStripMenuItem";
            this.historicoToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.historicoToolStripMenuItem.Text = "Historico";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click_1);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Gestión veterinaria";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veterinariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionVeterinariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem historicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

