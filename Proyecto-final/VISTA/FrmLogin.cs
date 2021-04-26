using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.DOMINIO;
using Proyecto_Final.NEGOCIO;

namespace Proyecto_Final.VISTA
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Usuario = txtUser.Text;
            log.Password = txtPass.Text;

            ClsLogin ClsL = new ClsLogin();
            FrmMenu menu = new FrmMenu();

            int VariabledeEvaluacion = ClsL.acceso(log);

            if (VariabledeEvaluacion == 1)
            {
                MessageBox.Show("Bienvenido " + txtUser.Text);
                FrmMenu frm = new FrmMenu();
                frm.usuarioEstado = txtUser.Text;
                frm.Show();

                frm.Hide();

            } else
            {
                MessageBox.Show("Datos Incorrectos");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
