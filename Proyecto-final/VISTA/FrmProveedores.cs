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
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
            ultimocorrelativoProveedores();
            cargardatos();
            carga();
            
        }
        void carga()
        {
            dtgProveedores.Rows.Clear();
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                var Lista = db.Proveedores.ToList();


                foreach (var interacion in Lista)
                {
                    dtgProveedores.Rows.Add(interacion.Id_Proveedores, interacion.Nombre_Proveedores, interacion.Tipo_Proveedores);
                }
            }
        }

        void ultimocorrelativoProveedores()
        {
            var consultaProveedores = new ClsDProveedores();

            int lista = 0;

            foreach (var list in consultaProveedores.ultimoId())
            {
                lista = list.Id_Proveedores;
                lista++;
                txtId.Text = lista.ToString();
            }
        }

        

        void cargardatos()
        {
            ClsDProveedores clsProducto = new ClsDProveedores();

            dtgProveedores.Rows.Clear();

            foreach (var listardatos in clsProducto.CargarProveedores(txtBuscarProveedores.Text))
            {

                dtgProveedores.Rows.Add(listardatos.Id_Proveedores, listardatos.Nombre_Proveedores, listardatos.Tipo_Proveedores);
            }
        }

        private void txtBuscarProveedores_TextChanged(object sender, EventArgs e)
        {
            cargardatos();
        }


        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            ultimocorrelativoProveedores();

            ClsDProveedores proveedores = new ClsDProveedores();
            cbProveedores.DataSource = proveedores.CargarComboProveedores();
            cbProveedores.DisplayMember = "Tipo_Proveedores";
            cbProveedores.ValueMember = "Id_Proveedores";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtgProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String Id = dtgProveedores.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dtgProveedores.CurrentRow.Cells[1].Value.ToString();
            String Tipo = dtgProveedores.CurrentRow.Cells[2].Value.ToString();

            txtId.Text = Id;
            txtNombre.Text = Nombre;
            txtTipo.Text = Tipo;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                Proveedores proveedores = new Proveedores();
                proveedores.Nombre_Proveedores = txtNombreAgregar.Text;
                proveedores.Tipo_Proveedores = cbProveedores.Text;
                dtgProveedores.Rows.Add(txtId.Text, txtNombreAgregar.Text, cbProveedores.Text);
                db.Proveedores.Add(proveedores);
                db.SaveChanges();
            }
            txtNombreAgregar.Clear();
           
        }

        private void cbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProveedores.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void THorayFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh: mm: ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
