using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.DOMINIO;
using Proyecto_Final.DAO;


namespace Proyecto_Final.NEGOCIO
{
    class ClsLogin
    {
        ClsListaAdministradores cls = new ClsListaAdministradores();
        public int acceso(Login log)
        {
            int estado = 0;
            for (int i=0; i< cls.user.Length; i++)
            {
                if (log.Usuario.Equals(cls.user[i]) && log.Password.Equals(cls.pass[i]))
                {
                    estado = 1;
                }
            }

            //if (log.Usuario.Equals("Kevin") && log.Password.Equals("123"))
            //{
            //    estado = 1;
            //}
            return estado;
            
        }
    }
}
