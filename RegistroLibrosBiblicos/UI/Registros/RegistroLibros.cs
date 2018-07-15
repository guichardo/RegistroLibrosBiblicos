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

namespace RegistroLibroBiblicos.UI.Registros
{
    public partial class RegistroLibros : Form
    {
        public RegistroLibros()
        {
            InitializeComponent();
        }

        private Libros LlenarClase()
        {

            Libros libro = new Libros();

            libro.LibroId = Convert.ToInt32(IdnumericUpDown.Value);
            libro.Descripcion = DescripciontextBox.Text;
            libro.Siglas = SiglastextBox.Text;
            libro.Fecha = FechadateTimePicker.Value;
            libro.Tipo = TipotextBox.Text;

            return libro;
        }

        public bool Validar(int validar)
        {

            bool paso = false;

            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(IdnumericUpDown, "Introduzca un ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {

                MyerrorProvider.SetError(DescripciontextBox, "Introduzca el nombre del libro");
                paso = true;

            }
            if (validar == 2 && SiglastextBox.Text == string.Empty)
            {

                MyerrorProvider.SetError(SiglastextBox, "Introduzca las siglas del libro");

                
            }
            if (validar == 2 && TipotextBox.Text == string.Empty)
            {

                MyerrorProvider.SetError(TipotextBox, "Introduzca el tipo de libro");


            }
            return paso;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
           
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            MyerrorProvider.Clear();

            Libros libro = LlenarClase();
            bool paso = false;

            if (IdnumericUpDown.Value == 0)
                paso = BLL.LibrosBLL.Guardar(libro);
            else
                paso = BLL.LibrosBLL.Modificar(LlenarClase());

            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            SiglastextBox.Clear();
            FechadateTimePicker.Value = DateTime.Now; ;
            TipotextBox.Clear();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Libros libro = BLL.LibrosBLL.Buscar(id);

            if (libro != null)
            {

                DescripciontextBox.Text = libro.Descripcion;
                SiglastextBox.Text = libro.Siglas;
                FechadateTimePicker.Value = libro.Fecha;
                TipotextBox.Text = libro.Tipo;
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();
            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.LibrosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RegistroLibros_Load(object sender, EventArgs e)
        {

        }
    }
}
