using Proyecto_Final.DAO;
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
    public partial class FrmVenta : Form
    {
        Productos producto = new Productos();
        public String usuario;
        public FrmVenta(Productos prod, String usu)
        {
            InitializeComponent();
            this.producto = prod;
            this.usuario = usu;
        }
        public int ObtenerIdUsuario(List<Usuarios> lista)
        {
            int IdUsuario = 0;

            List<Usuarios> list = lista;
            foreach (var i in list)
            {
                IdUsuario = i.Id_Usuarios;
            }

            return IdUsuario;
        }
        public int ObtenerIdProducto(List<Productos> lista)
        {
            int IdProducto = 0;

            List<Productos> list = lista;
            foreach (var i in list)
            {
                IdProducto = i.Id_Producto;
            }

            return IdProducto;
        }
        void cargarControles() {
            ClsDUserList clsuser = new ClsDUserList();
            ClsDProducto clsprod = new ClsDProducto();
            txtNombre.Text = producto.Nombre_Producto;
            txtPrecio.Text = producto.Precio_Producto.ToString();

            List<Usuarios> lista = clsuser.ObtenerListaUsuarioPorNombre(usuario);
            int IdUsuario = ObtenerIdUsuario(lista);
            txtIdUsuario.Text = IdUsuario.ToString();

            List<Productos> listaProd = clsprod.ObtenerListaProductoPorNombre(producto);
            int IdProducto = ObtenerIdProducto(listaProd);
            txtIdProducto.Text = IdProducto.ToString();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            cargarControles();
            
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                ClsDVenta clsventa = new ClsDVenta();
                Venta venta = new Venta();
                venta.Id_UsuariosFK = Convert.ToInt32(txtIdUsuario.Text);
                venta.Id_ProductoFK = Convert.ToInt32(txtIdProducto.Text);
                venta.Cantidad = Convert.ToInt32(txtCantidad.Text);
                venta.totalVenta = Convert.ToDecimal(txtTotal.Text);
                venta.fechaVenta = Convert.ToDateTime(dtpFecha.Text);
                clsventa.saveVenta(venta);
            }
            catch (Exception ex) {
                MessageBox.Show("Por favor, Llene los campos vacios");
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal precio = Convert.ToDecimal(producto.Precio_Producto);
                Decimal cantidad;
                Decimal total;

                cantidad = Convert.ToDecimal(txtCantidad.Text);
                total = precio * cantidad;
                txtTotal.Text = total.ToString();
            }
            catch (Exception)
            {
                if (txtCantidad.Text.Equals(""))
                {
                    txtCantidad.Text = "0";
                    //Selecciona todo el texto que esta en el txtCantidad siempre que este vacio
                    txtCantidad.SelectAll();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //dtgVenta.Rows.Add(txtIdUsuario.Text, txtIdProducto.Text, txtCantidad.Text, txtTotal.Text, Convert.ToDateTime(dtpFecha.Text));
            if (txtCantidad.Text.Equals(""))
            {
                MessageBox.Show("Por favor llenar todos los campos");
            }
            else if (txtCantidad.Text.Equals("0"))
            {
                MessageBox.Show("Error, ingresar numero diferente a cero");
            }
            else
            {
                dtgVenta.Rows.Add(txtIdUsuario.Text, txtIdProducto.Text, txtCantidad.Text, txtTotal.Text, Convert.ToDateTime(dtpFecha.Text));
            }


            dtgVenta.Refresh();
            dtgVenta.ClearSelection();
            int ultimaFila = dtgVenta.Rows.Count - 1;
            dtgVenta.FirstDisplayedScrollingRowIndex = ultimaFila;
            dtgVenta.Rows[ultimaFila].Selected = true;
            txtCantidad.Clear();
            txtCantidad.Text = "1";
            txtCantidad.SelectAll();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmCatalogo frm = new FrmCatalogo(usuario);
            this.Hide();
            frm.ShowDialog();
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnAgregar.PerformClick();
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            Double suma = 0;
            for (int i = 0; i < dtgVenta.Rows.Count; i++)
            {
                //String precio = dtgProducto.CurrentRow.Cells[2].Value.ToString();
                String datosaoperartotal = dtgVenta.Rows[i].Cells[3].Value.ToString();

                Double datosConvertidos = Convert.ToDouble(datosaoperartotal);

                suma += datosConvertidos;

                txtTotalFinal.Text = suma.ToString();
            }
        }
    }
}
