﻿using System;
using System.Collections.Generic;

namespace Web__SMBJC_MVC.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public long Nit { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public string CedulaIdentidad { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
