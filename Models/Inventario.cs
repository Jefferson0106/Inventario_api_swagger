using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class Inventario
    {
        public Inventario()
        {
            InventarioAlmacenProductos = new HashSet<InventarioAlmacenProducto>();
        }

        public int IdInventario { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public string? FechaEntrega { get; set; }
        public bool? Estado { get; set; }

        [JsonIgnore]
        public virtual ICollection<InventarioAlmacenProducto> InventarioAlmacenProductos { get; set; }
    }
}
