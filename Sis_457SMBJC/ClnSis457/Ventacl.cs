using CadSis457;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnSis457
{
    public class Ventacl
    {
        public static int insertar(Venta venta)
        {
            using (var context = new LabSMBJCEntities())
            {
                context.Venta.Add(venta);
                context.SaveChanges();
                return venta.id;
            }
        }

        public static int actualizar(Venta venta)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existente = context.Venta.Find(venta.id);
                existente.transccion = venta.transccion;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existente = context.Venta.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Venta get(int id)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.Venta.Find(id);
            }
        }

        public static List<Venta> listar()
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.Venta.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paVentaListar_Result> listarPa(string parametro)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.paVentaListar(parametro).ToList();
            }
        }
    }
}
