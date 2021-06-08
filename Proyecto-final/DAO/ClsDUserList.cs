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
        
        public List<Usuarios> ObtenerListaUsuarioPorNombre(String usuario)
        {
            List<Usuarios> list = new List<Usuarios>();

            using (FarmaciaEntities3 bd = new FarmaciaEntities3())
            {
                list = (from user in bd.Usuarios
                        where user.Nombre == usuario
                        select user).ToList();
                //if (consulta.Count > 0) {
                //    list = consulta;
                //}
            }
            return list;
        }

        public List<Usuarios> cargaDato()
        {
            List<Usuarios> lista;

            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                lista = db.Usuarios.ToList();
            }
            return lista;
        }

        public void Registrarse(Usuarios user)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                try {
                    Usuarios userList = new Usuarios();

                    userList.Nombre = user.Nombre;
                    userList.Pass = user.Pass;
                    db.Usuarios.Add(userList);
                    db.SaveChanges();
                    MessageBox.Show("Registrado Correctamente");

                }catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
        }
    }
}
