using CadSis457;
using ClnSis457;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpSis457
{
    public partial class FrmVentaDetalle : Form
    {
        bool esNuevo = true;
        public FrmVentaDetalle()
        {
            InitializeComponent();
        }
        //crar funcion listar
        private void listar()
        {
            var ventadetalle = VentaDetallecl.listarPa(txtBuscar.Text.Trim());
            dgvLista.DataSource = ventadetalle;
            //Oculta la columna id
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;

            //Poner mayusculas 
            dgvLista.Columns["cantidad"].HeaderText = "Cantidad";
            dgvLista.Columns["precioUnitario"].HeaderText = "Precio Unitario";
            dgvLista.Columns["total"].HeaderText = "Total";
            dgvLista.Columns["idventa"].HeaderText = "Venta";
            dgvLista.Columns["idProveedor"].HeaderText = "Proveedor";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha y Hora";
            //habilitar edicion y eliminar y desabilitar
            btnEditar.Enabled = ventadetalle.Count > 0;
            btnEliminar.Enabled = ventadetalle.Count > 0;
            //Si  hay registro que el primer elemento este selccionado
            if (ventadetalle.Count > 0) dgvLista.Rows[0].Cells["cantidad"].Selected = true;

        }
        //ocultar el formulario de nuevo
        private void VentaDetalle_Load(object sender, EventArgs e)
        {

            // borrar dgvLista.DefaultCellStyle.ForeColor = Color.Black;
            Size = new Size(887, 548);
            listar();

        }
        //muestra el formulario para crear nuevos
        private void btnNuevo_Click(object sender, EventArgs e)

        {
            //parpadea en nuevo
            esNuevo = true;
            numCantidad.Focus();
            Size = new Size(1235, 548);
        }

        //editar 
        private void btnEditar_Click(object sender, EventArgs e)
        {

            esNuevo = false;
            Size = new Size(1235, 548);
            int index = dgvLista.CurrentCell.RowIndex;
            int id =Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            var ventadetalle = VentaDetallecl.get(id);
            numCantidad.Value = ventadetalle.cantidad;
            numUnitario.Value = ventadetalle.precioUnitario;
            numTotal.Value = ventadetalle.total;
        }
        //Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(887, 548);
            limpiar();
        }
        //cerrar salir de todo
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        //buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }
        //buscar  presionando enter
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }
        //VALIDAR PARA ESCRIBIR
        private bool validar()
        {
            bool esValido = true;
            erpCantidad.SetError(numCantidad, "");
            erpUnitario.SetError(numUnitario, "");
            erpTotal.SetError(numTotal, "");


            //validacion para cantidad
            if (numCantidad.Value < 1)
            {
                esValido = false;
                erpCantidad.SetError(numCantidad, "El campo Cantidad tiene que ser mayor a cero");

            }
            //validacion para Precio U
            if (numUnitario.Value < 1)
            {
                esValido = false;
                erpUnitario.SetError(numCantidad, "El campo Cantidad tiene que ser mayor a cero");

            }
            //validacion para precio
            if (numTotal.Value < 1)
            {
                esValido = false;
                erpTotal.SetError(numTotal, "El campo Precio tiene que ser mayor a cero");

            }

            return esValido;
        }


        //guardar nuevos nuevos registros
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (validar())
            {
                var ventadetalle = new VentaDetalle();
                ventadetalle.cantidad = numCantidad.Value;
                ventadetalle.precioUnitario = numUnitario.Value;
                ventadetalle.total = numTotal.Value;
                ventadetalle.usuarioRegistro = "sis257";
                if (esNuevo)
                {
                    ventadetalle.fechaRegistro = DateTime.Now;
                    ventadetalle.estado = 1;
                    VentaDetallecl.insertar(ventadetalle);
                }
                else
                {
                    int index = dgvLista.CurrentCell.RowIndex;
                    ventadetalle.id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
                    VentaDetallecl.actualizar(ventadetalle);
                }
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Producto guardado correctamente", "sis257",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //llamas a la clase para que saque el total en guardar 
            CalcularSuma();
        }
        //limpiar 
        private void limpiar()
        {

            numCantidad.Value = 0;
            numUnitario.Value = 0;
            numTotal.Value = 0;
        }
        //Crear  2 clases para suma;
        //eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            string cantidad = dgvLista.Rows[index].Cells["codigo"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Esta seguro de que desea eliminar?", "sis257", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.OK)
            {
                VentaDetallecl.eliminar(id, "sis457");
                listar();
                MessageBox.Show("Venta eliminado correctamente", "sis257",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            //llamas a la clase para que saque el total en  
            CalcularSuma();
        }

        //volver a la lista actual despues de buscar
        private void btnSalirB_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Llamar la clase calcular suma
        private void btnSuma_Click(object sender, EventArgs e)
        {
            CalcularSuma();
        }
        private void CalcularSuma()
        {
            int total = 0;
            foreach (DataGridViewRow suma in dgvLista.Rows)
            {
                //suma total de dinero
                total += Convert.ToInt32(suma.Cells["saldo"].Value);
                txtNumero.Text = Convert.ToString(total);
                //suma total de registros
                txtSuma.Text = Convert.ToString((dgvLista.Rows.Count));
            }
        }
    }
    }
