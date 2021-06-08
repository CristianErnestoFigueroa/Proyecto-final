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
using Proyecto_Final.DOMINIO;
using Proyecto_Final.MODEL;

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


        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (txtPass.PasswordChar == '*')
                {
                    txtPass.PasswordChar = '\0';
                }
            } else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void btnRegistrarse_Click_1(object sender, EventArgs e)
        {
            FrmRegistrarse frm = new FrmRegistrarse();
            this.Hide();
            frm.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh: mm: ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            ClsAcceso acceso = new ClsAcceso();
            Usuarios usu = new Usuarios();
            usu.Nombre = txtUser.Text;
            usu.Pass = txtPass.Text;

            int valor = acceso.acceso(usu);

            if (valor == 1)
            {
                FrmMenu menu = new FrmMenu();
                menu.usuario = txtUser.Text;
                MessageBox.Show("Welcome");
                this.Hide();
                menu.ShowDialog();
                 
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
            
            txtUser.Clear();
            txtPass.Clear();
        }
    }
}
