
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CadSis457
{

using System;
    using System.Collections.Generic;
    
public partial class VentaDetalle
{

    public int id { get; set; }

    public decimal cantidad { get; set; }

    public decimal precioUnitario { get; set; }

    public decimal total { get; set; }

    public int idVenta { get; set; }

    public int idProveedor { get; set; }

    public string usuarioRegistro { get; set; }

    public System.DateTime fechaRegistro { get; set; }

    public short estado { get; set; }



    public virtual Proveedor Proveedor { get; set; }

    public virtual Venta Venta { get; set; }

}

}
