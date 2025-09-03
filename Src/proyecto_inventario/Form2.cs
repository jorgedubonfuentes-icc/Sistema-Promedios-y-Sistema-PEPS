using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_inventario
{
    public partial class frminicio : Form
    {
        public frminicio()
        {
            InitializeComponent();
        }

        //Boton para abrir el costo promedio
        private void button1_Click(object sender, EventArgs e)
        {
            frmcosto frmcosto = new frmcosto();
            frmcosto.Show();

        }

        //Boton para abrir el peps
        private void button2_Click(object sender, EventArgs e)
        {
            frmpeps frmpeps = new frmpeps();
            frmpeps.Show();
        }

        //Boton para salir
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
