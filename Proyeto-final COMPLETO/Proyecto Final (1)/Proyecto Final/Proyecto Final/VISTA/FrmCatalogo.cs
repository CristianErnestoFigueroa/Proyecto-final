using Proyecto_Final.MODEL;
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
    public partial class FrmCatalogo : Form
    {
        public String usuario;
        public FrmCatalogo(String usu)
        {
            InitializeComponent();
            this.usuario = usu;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmCatalogo_Load(object sender, EventArgs e)
        {

        }

        private void pbxMascarilla_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Nombre_Producto = lblMascarilla.Text;
            producto.Precio_Producto = Convert.ToDecimal(lblPrecioMascarilla.Text);

            FrmVenta frm = new FrmVenta(producto, usuario);
            this.Hide();
            frm.ShowDialog();
        }

        private void pbxAcetaminofen_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Nombre_Producto = lblAcetaminofen.Text;
            producto.Precio_Producto = Convert.ToDecimal(lblPrecioAcetaminofen.Text);

            FrmVenta frm = new FrmVenta(producto, usuario);
            this.Hide();
            frm.ShowDialog();
        }

        private void pbxAlcoholGel_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Nombre_Producto = lblAlcoholgel.Text;
            producto.Precio_Producto = Convert.ToDecimal(lblPrecioAlcohol.Text);

            FrmVenta frm = new FrmVenta(producto, usuario);
            this.Hide();
            frm.ShowDialog();
        }

        private void pbxGuantes_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Nombre_Producto = lblGuantesQuirurgicos.Text;
            producto.Precio_Producto = Convert.ToDecimal(lblPrecioGuantes.Text);

            FrmVenta frm = new FrmVenta(producto, usuario);
            this.Hide();
            frm.ShowDialog();
        }

        private void pbxJarabeParaTos_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Nombre_Producto = lblJarabeTos.Text;
            producto.Precio_Producto = Convert.ToDecimal(lblPrecioJarabe.Text);

            FrmVenta frm = new FrmVenta(producto, usuario);
            this.Hide();
            frm.ShowDialog();
        }

        private void pbxEnjuague_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Nombre_Producto = lblEnjuagueBucal.Text;
            producto.Precio_Producto = Convert.ToDecimal(lblPrecioEnjuague.Text);

            FrmVenta frm = new FrmVenta(producto, usuario);
            this.Hide();
            frm.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
