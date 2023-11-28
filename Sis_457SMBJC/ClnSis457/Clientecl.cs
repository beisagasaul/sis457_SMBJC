﻿using CadSis457;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnSis457
{
    public  class Clientecl
    {
        public static int insertar(Cliente cliente)
        {
            using (var context = new LabSMBJCEntities())
            {
                int idCliente = context.Cliente
                .Where(c => c.cedulaIdentidad == cliente.cedulaIdentidad)
                .Select(c => c.id)
                .FirstOrDefault();

                if (idCliente == 0)
                {
                    context.Cliente.Add(cliente);
                    context.SaveChanges();
                    return cliente.id;
                }
                else
                {
                    return idCliente;
                }
            }
        }

        public static int actualizar(Cliente cliente)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existente = context.Cliente.Find(cliente.id);
                existente.razonSocial = cliente.razonSocial;
                existente.cedulaIdentidad = cliente.cedulaIdentidad;
                existente.celular = cliente.celular;
                existente.usuarioRegistro = cliente.usuarioRegistro;
                return context.SaveChanges();

            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabSMBJCEntities())
            {
                var existente = context.Cliente.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();

            }
        }

        public static Cliente get(int id)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.Cliente.Find(id);

            }
        }

        public static List<Cliente> listar()
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.Cliente.Where(x => x.estado != -1).ToList();

            }
        }

        public static List<paClienteListar_Result> listarPa(string parametro)
        {
            using (var context = new LabSMBJCEntities())
            {
                return context.paClienteListar(parametro).ToList();

            }
        }
    }
}
