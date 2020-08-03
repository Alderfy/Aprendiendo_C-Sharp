using LinqtoSQL_Classes.Model.DbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqtoSQL_Classes.Views
{
    public partial class FrmCrear : Form
    {
        iUsuarioRepo usuarioRepo = new UsuarioRepo();
        public FrmCrear()
        {
            InitializeComponent();
        }

        private void FrmCrear_Load(object sender, EventArgs e)
        {
            Load_grid();
        }

        private void Load_grid()
        {
            dgvUsuarios.DataSource = usuarioRepo.getAll();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;

            if(String.IsNullOrWhiteSpace(nombre) || String.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Se requiere completar todos los campos");
            }
            else
            {
                usuarioRepo.Create(new Usuario { Nombre = nombre, Apellido = apellido });

                MessageBox.Show("Empleado creado");
                Load_grid();
            }
        }
    }
}
