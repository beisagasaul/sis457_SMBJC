using CadSis457;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnSis457
{
    public class Usuariocl
    {
        public static Usuario validar(string usuario, string clave)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.Usuario
                    .Where(x => x.usuario1 == usuario && x.clave == clave)
                    .FirstOrDefault();
            }
        }
    }
}
