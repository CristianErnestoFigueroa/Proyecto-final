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
    public partial class FrmRegistrarse : Form
    {
        public FrmRegistrarse()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            
                FrmLogin frm = new FrmLogin();
                Usuarios user = new Usuarios();
                ClsDUserList cls = new ClsDUserList();

                user.Nombre = txtNombre.Text;
                user.Pass = txtPass.Text;
                cls.Registrarse(user);
                this.Close();
            frm.Show();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (txtPass.PasswordChar == '*')
                {
                    txtPass.PasswordChar = '\0';
                }
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRegistrarse_Load(object sender, EventArgs e)
        {

        }
    }
}
