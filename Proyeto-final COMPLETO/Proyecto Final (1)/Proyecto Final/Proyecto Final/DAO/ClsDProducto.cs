using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.MODEL;
using Proyecto_Final.VISTA;

namespace Proyecto_Final.DAO
{
    class ClsDProducto
    {
        public List<Productos> ObtenerListaProductoPorNombre(Productos prod)
        {
            List<Productos> list = new List<Productos>();

            using (FarmaciaEntities3 bd = new FarmaciaEntities3())
            {
                list = (from prods in bd.Productos
                        where prods.Nombre_Producto == prod.Nombre_Producto
                        select prods).ToList();
                //if (consulta.Count > 0) {
                //    list = consulta;
                //}
            }

            return list;
        }

        public List<Productos> cargaDato()
        {
            List<Productos> lista;

            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                lista = db.Productos.ToList();
            }
            return lista;
        }

        public int ObtenerIdProducto(Productos prod)
        {
            int IdProd = 0;
            using (FarmaciaEntities3 bd = new FarmaciaEntities3())
            {
                //SELECT Id_Usuarios FROM Usuarios WHERE Nombre = @Nombre
                var consulta = from producto in bd.Productos
                               where producto.Nombre_Producto == prod.Nombre_Producto
                               select producto.Id_Producto;

                if (consulta.Count() > 0)
                {
                    IdProd = Convert.ToInt32(consulta);
                }
            }
            return IdProd;
        }

        public List<Productos> CargarProducto(string filtro)
        {

            List<Productos> producto = new List<Productos>();
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                producto = (from listadoproductos in db.Productos
                            where listadoproductos.Nombre_Producto.Contains(filtro)
                               select listadoproductos).ToList();

            }

            return producto;
        }

        public List<Productos> ultimoIdProducto()
        {
            List<Productos> productos = new List<Productos>();
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                productos = db.Productos.ToList();
            }

            return productos;
        }

          public void Guardar(Productos produc)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                Productos producto = new Productos();

                producto.Nombre_Producto = produc.Nombre_Producto;
                producto.Precio_Producto = produc.Precio_Producto;
                db.Productos.Add(produc);
                db.SaveChanges();
                MessageBox.Show("Guardado");
            }
        }  

        public void Eliminar(int iD)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3())
            {
                int Eliminar = Convert.ToInt32(iD);
                Productos producto = db.Productos.Where(x => x.Id_Producto == Eliminar).Select(x => x).FirstOrDefault();
                db.Productos.Remove(producto);
                db.SaveChanges();
                MessageBox.Show("ELIMINADO");
            }
        }

        public void actualizar(Productos producto)
        {
            using (FarmaciaEntities3 db = new FarmaciaEntities3()) { 
            int update = Convert.ToInt32(producto.Id_Producto);
            Productos produc = db.Productos.Where(x => x.Id_Producto == update).Select(x => x).FirstOrDefault();
            produc.Nombre_Producto = producto.Nombre_Producto;
            produc.Precio_Producto = producto.Precio_Producto;
            db.SaveChanges();
            MessageBox.Show("ACTUALIZADO");
            }
        }
    }
}
