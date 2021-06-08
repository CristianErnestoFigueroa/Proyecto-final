using Proyecto_Final.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final.DAO
{
    class ClsDVenta
    {
        public void saveVenta(Venta ventaParam) {

            using (FarmaciaEntities3 db = new FarmaciaEntities3()) {

                Venta venta = new Venta();
                venta.Id_UsuariosFK = ventaParam.Id_UsuariosFK;
                venta.Id_ProductoFK = ventaParam.Id_ProductoFK;
                venta.Cantidad = ventaParam.Cantidad;
                venta.totalVenta = ventaParam.totalVenta;
                venta.fechaVenta = ventaParam.fechaVenta;
                db.Venta.Add(venta);
                db.SaveChanges();
                MessageBox.Show("Venta Insertada");
            }
        }
    }
}
