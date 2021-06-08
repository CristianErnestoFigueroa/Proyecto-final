using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.MODEL;

namespace Proyecto_Final.DAO
{
    class ClsDProveedores
    {
        public List<Proveedores> CargarProveedores(string filtro)
        {

            List<Proveedores> proveedores = new List<Proveedores>();
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                proveedores = (from listadoproductos in db.Proveedores
                            where listadoproductos.Nombre_Proveedores.Contains(filtro)
                            select listadoproductos).ToList();

            }

            return proveedores;
        }
        public List<Proveedores> CargarComboProveedores()
        {
            List<Proveedores> proveedores = new List<Proveedores>();
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                proveedores = db.Proveedores.ToList();
                

            }

            return proveedores;
        }

        public List<Proveedores> ultimoId()
        {
            List<Proveedores> proveedores = new List<Proveedores>();
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                proveedores = db.Proveedores.ToList();
            }

            return proveedores;
        }
    }
}
