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
        public static int insertar(VentaDetalle ventadetalle)
        {
            using (var context = new LabSMBJCEntities())
            {
                context.VentaDetalle.Add(ventadetalle);
                context.SaveChanges();
                return ventadetalle.id;
            }
        }
        //actualizar
        public static int actualizar(VentaDetalle ventadetalle)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existe = context.VentaDetalle.Find(ventadetalle.id);

                existe.cantidad = ventadetalle.cantidad;
                existe.precioUnitario = ventadetalle.precioUnitario;
                existe.total = ventadetalle.total;
                existe.usuarioRegistro = ventadetalle.usuarioRegistro;
                existe.fechaRegistro = ventadetalle.fechaRegistro;
                return context.SaveChanges();
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
