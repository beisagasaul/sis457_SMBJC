using System;
using System.Collections.Generic;

namespace Web__SMBJC_MVC.Models;

public partial class Ventum
{
    public int Id { get; set; }

    public string Transccion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int IdUsuario { get; set; }

    public int IdCliente { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public int? IdProducto { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
