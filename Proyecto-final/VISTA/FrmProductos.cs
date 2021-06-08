using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.DAO;
using Proyecto_Final.MODEL;

namespace Proyecto_Final.VISTA
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
            cargardatos();
            ultimocorrelativoProductos();


        }

        void clear()
        {
            txtId.Clear();
            txtNombre.Clear();
            txt_Precio.Clear();
        }

        void ultimocorrelativoProductos()
        {
            var consultaProductos = new ClsDProducto();

            int lista = 0;

            foreach (var list in consultaProductos.ultimoIdProducto())
            {
                lista = list.Id_Producto;
                lista++;
                txtId.Text = lista.ToString();
            }
        }



        void cargardatos()
        {
            ClsDProducto clsProducto = new ClsDProducto();

            dtgProducto.Rows.Clear();

            foreach (var listardatos in clsProducto.CargarProducto(txtBuscarProducto.Text))
            {

                dtgProducto.Rows.Add(listardatos.Id_Producto, listardatos.Nombre_Producto, listardatos.Precio_Producto);
            }
        }

       
        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void txtBuscarProducto_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txtBuscarProducto_Leave(object sender, EventArgs e)
        {
            
        }

        private void THorayFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh: mm: ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void dtgProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String Id = dtgProducto.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dtgProducto.CurrentRow.Cells[1].Value.ToString();
            String Tipo = dtgProducto.CurrentRow.Cells[2].Value.ToString();

            txtId.Text = Id;
            txtNombre.Text = Nombre;
            txt_Precio.Text = Tipo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //using (FarmaciaEntities3 db = new FarmaciaEntities3())
            //{
            //    ClsDProducto producto = new ClsDProducto();
            //    Productos Producto = new Productos();
            //    Producto.Nombre_Producto = txtNombre.Text;
            //    Producto.Precio_Producto= txt_Precio.Text;
            //    producto.Guardar(Producto);
            //}
            //cargardatos();
            //clear();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            //using (FarmaciaEntities3 db = new FarmaciaEntities3())
            //{
            //    int actualizar = Convert.ToInt32(txtId.Text);
            //    Productos producto = db.Productos.Where(x => x.Id_Producto == actualizar).Select(x => x).FirstOrDefault();
            //    producto.Nombre_Producto = txtNombre.Text;
            //    producto.Precio_Producto = txt_Precio.Text;
            //    db.SaveChanges();
            //    MessageBox.Show("Actualizado");
            //}
            //cargardatos();
            //clear();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //{
            //    ClsDProducto producto = new ClsDProducto();
            //    producto.Eliminar(Convert.ToInt32(txtId.Text));
            //}
            //cargardatos();
            //clear();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
