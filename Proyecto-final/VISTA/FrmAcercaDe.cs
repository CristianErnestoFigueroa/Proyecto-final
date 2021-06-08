using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final.VISTA
{
    public partial class FrmAcercaDe : Form
    {
        public FrmAcercaDe()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmAcercaDe_Load(object sender, EventArgs e)
        {

        }

        private void THorayFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh: mm: ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }
    }
}
