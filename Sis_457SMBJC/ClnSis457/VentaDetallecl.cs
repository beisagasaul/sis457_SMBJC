using CadSis457;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnSis457
{
    public class VentaDetallecl
    {
        //insertar
        public static int insertar(VentaDetalle ventaDetalle)
        {
            using (var context = new LabSMBJCEntities())
            {
                context.VentaDetalle.Add(ventaDetalle);
                context.SaveChanges();
                return ventaDetalle.id;
            }
        }
        //actualizar
        public static int actualizar(VentaDetalle ventaDetalle)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existe = context.VentaDetalle.Find(ventaDetalle.id);

                var existente = context.VentaDetalle.Find(ventaDetalle.id);
                existente.cantidad = ventaDetalle.cantidad;
                existente.precioUnitario = ventaDetalle.precioUnitario;
                existente.total = ventaDetalle.total;
                existente.usuarioRegistro = ventaDetalle.usuarioRegistro;
                return context.SaveChanges()
            }
        }
        //eliminar
        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existente = context.VentaDetalle.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }
        //obtención de datos
        public static VentaDetalle get(int id)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.VentaDetalle.Find(id);
            }
        }

        //obtener una lista de objetos VentaDetalle desde la base de datos. 
        public static List<VentaDetalle> listar()
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.VentaDetalle.Where(x => x.estado != -1).ToList();
            }
        }
        //se encarga de obtener y procesar datos de la base de datos.
        public static List<paDventaListar_Result> listarPa(string parametro)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.paDventaListar(parametro).ToList();
            }
        }
    }
}
