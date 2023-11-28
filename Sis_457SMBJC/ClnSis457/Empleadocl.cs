using CadSis457;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnSis457
{
    public class Empleadocl
    {
        public static int insertar(Empleado empleado)
        {
            using (var context = new LabSMBJCEntities())
            {
                context.Empleado.Add(empleado);
                context.SaveChanges();
                return empleado.id;
            }
        }

        public static int actualizar(Empleado empleado)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existente = context.Empleado.Find(empleado.id);
                existente.cedulaIdentidad = empleado.cedulaIdentidad;
                existente.nombres = empleado.nombres;
                existente.primerApellido = empleado.primerApellido;
                existente.segudoApellido = empleado.segudoApellido;
                existente.direccion = empleado.direccion;
                existente.cargo = empleado.cargo;
                existente.celular = empleado.celular;
                existente.usuarioRegistro = empleado.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int idEmpleado, string usuarioRegistro)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existente = context.Empleado.Find(idEmpleado);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Empleado get(int idEmpleado)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.Empleado.Find(idEmpleado);
            }
        }

        public static List<Empleado> listar()
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.Empleado.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paEmpleadoListar_Result> listarPa(string parametro)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.paEmpleadoListar(parametro).ToList();
            }
        }
    }
}
