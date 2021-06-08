using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.MODEL;

namespace Proyecto_Final.DAO
{
    class ClsAcceso
    {
        public int acceso(/*string usuario, string password*/ Usuarios usu)
        {
            int variableacceso = 0;
            using (FarmaciaEntities3 bd = new FarmaciaEntities3())
            {
                //SELECT Id_Usuarios FROM Usuarios WHERE Nombre = @Nombre
                var consulta = from user in bd.Usuarios
                               where user.Nombre == usu.Nombre && user.Pass == usu.Pass
                               select user;

                if (consulta.Count() > 0)
                {
                    variableacceso = 1;
                }
            }
            return variableacceso;
        }
    }
}
