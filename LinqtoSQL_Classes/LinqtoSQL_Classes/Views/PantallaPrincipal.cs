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
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrear frmCrear = new FrmCrear();
            frmCrear.ShowDialog();
        }
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
