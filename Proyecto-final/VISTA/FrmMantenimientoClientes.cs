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
    public partial class FrmMantenimientoClientes : Form
    {
        public FrmMantenimientoClientes()
        {
            InitializeComponent();
            carga();
            clear();
        }


        void clear()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtPass.Clear();
        }


        void carga()
        {
            dtgListadoClientesMan.Rows.Clear();
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                var Lista = db.Usuarios.ToList();
             

                foreach (var interacion in Lista)
                {
                    dtgListadoClientesMan.Rows.Add(interacion.Id_Usuarios, interacion.Nombre, interacion.Pass);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                ClsDMantenimiento cliente = new ClsDMantenimiento();
                cliente.Eliminar(Convert.ToInt32(txtId.Text));
            }
            carga();
            clear();
        }

        private void dtgListadoClientesMan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String Id = dtgListadoClientesMan.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dtgListadoClientesMan.CurrentRow.Cells[1].Value.ToString();
            String Pass = dtgListadoClientesMan.CurrentRow.Cells[2].Value.ToString();

            txtId.Text = Id;
            txtNombre.Text = Nombre;
            txtPass.Text = Pass;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                ClsDMantenimiento producto = new ClsDMantenimiento();
                Usuarios tb_Producto = new Usuarios();
                tb_Producto.Id_Usuarios= Convert.ToInt32(txtId.Text);
                tb_Producto.Nombre = txtNombre.Text;
                tb_Producto.Pass = txtPass.Text;

                producto.actualizar(tb_Producto);
            }
            clear();
            carga();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                ClsDMantenimiento man = new ClsDMantenimiento();
                Usuarios userList = new Usuarios();
                userList.Nombre = txtNombre.Text;
                userList.Pass = txtPass.Text;
                man.Guardar(userList);
            }
            carga();
            clear();
        }

        private void FrmMantenimientoClientes_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh: mm: ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
