using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class InventarioAlmacenProducto
    {
        public int IdInventarioAlmacenProducto { get; set; }
        public int? IdAlmacen { get; set; }
        public int? IdProducto { get; set; }
        public int? IdInventario { get; set; }

        [JsonIgnore]
        public virtual Almacene? IdAlmacenNavigation { get; set; }
        [JsonIgnore]
        public virtual Inventario? IdInventarioNavigation { get; set; }
        [JsonIgnore]
        public virtual Producto? IdProductoNavigation { get; set; }
    }
}
