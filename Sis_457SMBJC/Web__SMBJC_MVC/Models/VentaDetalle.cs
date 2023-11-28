using System;
using System.Collections.Generic;

namespace Web__SMBJC_MVC.Models;

public partial class VentaDetalle
{
    public int Id { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Total { get; set; }

    public int IdVenta { get; set; }

    public int IdProveedor { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
