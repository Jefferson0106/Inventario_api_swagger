using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class AlmacenProducto
    {
        public int IdAlmacenProducto { get; set; }
        public int? IdAlmacen { get; set; }
        public int? IdProducto { get; set; }
        public DateTime? FechaCreacion { get; set; }

        [JsonIgnore]
        public virtual Almacene? IdAlmacenNavigation { get; set; }
        [JsonIgnore]
        public virtual Producto? IdProductoNavigation { get; set; }
    }
}
