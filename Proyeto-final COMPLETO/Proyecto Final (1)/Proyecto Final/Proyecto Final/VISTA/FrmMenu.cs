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
    public partial class FrmMenu : Form
    {
        public String usuario = "";
        public FrmMenu()
        {
            InitializeComponent();
        }

        public string usuarioEstado;
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            label1.Text = usuarioEstado;
        }

        private void listadoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario user = new FrmUsuario();
            user.MdiParent = this;
            user.Show();
        }

        private void clickParaMasInformacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaDe acercaDe = new FrmAcercaDe();
            acercaDe.MdiParent = this;
            acercaDe.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMantenimientoClientes clientes = new FrmMantenimientoClientes();
            clientes.MdiParent = this;
            clientes.Show();
        }

        private void mANTENIMIENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductos productos = new FrmProductos();
            productos.MdiParent = this;

            productos.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductos producto = new FrmProductos
            {
                MdiParent = this
            };
            producto.txtId.Enabled = false;
            producto.txtId.Clear();
            producto.txtNombre.Enabled = false;
            producto.txt_Precio.Enabled = false;
            producto.btnGuardar.Enabled = false;
            producto.BtnActualizar.Enabled = false;
            producto.BtnEliminar.Enabled = false;

            producto.Show();
        }

        private void THoraFecha_Tick(object sender, EventArgs e)
        {
          
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedores proveedores = new FrmProveedores();
            proveedores.MdiParent = this;
            proveedores.Show();
        }

        private void vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatalogo catalogo = new FrmCatalogo(usuario);
            catalogo.MdiParent = this;
            catalogo.Show();
        }
    }
}
