using RegistroLibroBiblicos.UI.Registros;
using RegistroLibrosBiblicos.UI.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroLibrosBiblicos
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LibrostoolStripButton_Click(object sender, EventArgs e)
        {
            RegistroLibros registro = new RegistroLibros();
            registro.MdiParent = this;
            registro.Show();
        }

        private void LibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroLibros registro = new RegistroLibros();
            registro.MdiParent = this;
            registro.Show();
        }

        private void LibrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cLibros consulta = new cLibros();
            consulta.MdiParent = this;
            consulta.Show();
        }
    }
}
