using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.MODEL;

namespace Proyecto_Final.DAO
{
    class ClsDMantenimiento
    {
        public void Guardar(Usuarios cliente)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                Usuarios user = new Usuarios();

                user.Nombre = cliente.Nombre;
                user.Pass = cliente.Pass;
                db.Usuarios.Add(cliente);
                db.SaveChanges();
                MessageBox.Show("Guardado");
            }
        }

        public void Eliminar(int iD)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                int Eliminar = Convert.ToInt32(iD);
                Usuarios user = db.Usuarios.Where(x => x.Id_Usuarios == Eliminar).Select(x => x).FirstOrDefault();
                db.Usuarios.Remove(user);
                db.SaveChanges();
                MessageBox.Show("ELIMINADO");
            }
        }

        public void actualizar(Usuarios cliente)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                int update = Convert.ToInt32(cliente.Id_Usuarios);
                Usuarios produc = db.Usuarios.Where(x => x.Id_Usuarios == update).Select(x => x).FirstOrDefault();
                produc.Id_Usuarios = cliente.Id_Usuarios;
                produc.Nombre = cliente.Nombre;
                produc.Pass = cliente.Pass;
                db.SaveChanges();
                MessageBox.Show("ACTUALIZADO");
            }
        }
    }
}
