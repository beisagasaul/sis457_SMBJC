﻿using CadSis457;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnSis457
{
    public class VentaDetalleCln
    {
        public static int insertar(VentaDetalle ventaDetalle)
        {
            using (var context = new LabSMBJCEntities())
            {
                context.VentaDetalle.Add(ventaDetalle);
                context.SaveChanges();
                return ventaDetalle.id;
            }
        }

        public static int actualizar(VentaDetalle ventaDetalle)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existente = context.VentaDetalle.Find(ventaDetalle.id);
                existente.cantidad = ventaDetalle.cantidad;
                existente.precioUnitario = ventaDetalle.precioUnitario;
                existente.total = ventaDetalle.total;
                existente.usuarioRegistro = ventaDetalle.usuarioRegistro;
                return context.SaveChanges();
            }
        }

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

        public static VentaDetalle get(int id)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.VentaDetalle.Find(id);

            }
        }

        public static List<VentaDetalle> listar()
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.VentaDetalle.Where(x => x.estado != -1).ToList();

            }
        }

        public static List<paVentaDetalleListar_Result> listarPa(string parametro)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.paVentaDetalleListar(parametro).ToList();

            }
        }
    }
}
