using RegistroLibroBiblicos.BLL;
using RegistroLibroBiblicos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroLibrosBiblicos.UI.Consultas
{
    public partial class cLibros : Form
    {
        public cLibros()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
      
            System.Linq.Expressions.Expression<Func<Libros, bool>> filtro = x => true;

            int id;
            switch (filtrarcomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.LibroId == id && 
                        (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 1:// Descripcion
                    filtro = x => x.Descripcion.Contains(CriteriotextBox.Text) &&
                        (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 2:// Siglas
                    filtro = x => x.Siglas.Contains(CriteriotextBox.Text) &&
                        (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 3:// Tipo
                    filtro = x => x.Tipo.Contains(CriteriotextBox.Text) &&
                        (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
            }


            ConsultadataGridView.DataSource = LibrosBLL.GetList(filtro);
        }
    }
}
