using System;
using System.Collections.Generic;

namespace DL;

public partial class Factura
{
    public int FolioFactura { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdProveedor { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Proveedore? IdProveedorNavigation { get; set; }
}
