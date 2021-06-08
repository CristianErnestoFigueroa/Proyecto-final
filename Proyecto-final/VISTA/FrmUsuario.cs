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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
            carga();
            //cargaRe();
        }

        void carga()
        {
            dtgListaUsuario.Rows.Clear();
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                var Lista = db.Usuarios.ToList();

                foreach(var interacion in Lista)
                {
                    dtgListaUsuario.Rows.Add(interacion.Id_Usuarios, interacion.Nombre, interacion.Pass);
                }
            }
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

        }

        //private void FrmUsuario_Load(object sender, EventArgs e)
        //{
        //    ClsListaAdministradores cls = new ClsListaAdministradores();
        //    foreach (var interacion in cls.user)
        //    {
        //        dtgListaUsuario.Rows.Add(interacion.ToString());
        //    }
        //    carga();
        //}
    }
}
