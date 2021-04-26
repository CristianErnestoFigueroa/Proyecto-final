using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.MODEL;

namespace Proyecto_Final.DAO
{
    class ClsDUserList
    {
        public List<UserList> cargaDato()
        {
            List<UserList> lista;

            using (FarmaciaEntities1 db = new FarmaciaEntities1())
            {
                lista = db.UserList.ToList();
            }
            return lista;
        }

        public void Registrarse(UserList user)
        {
            using (FarmaciaEntities1 db = new FarmaciaEntities1())
            {
                try { 
                UserList userList = new UserList();

                userList.Nombre = user.Nombre;
                userList.Pass = user.Pass;
                db.UserList.Add(userList);
                db.SaveChanges();
                MessageBox.Show("Registrado Correctamente");

                }catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error" + ex);
                }
            }
        }
    }
}
