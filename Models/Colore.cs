using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class Colore
    {
        public Colore()
        {
            Productos = new HashSet<Producto>();
            TipoProductos = new HashSet<TipoProducto>();
        }

        public int IdColor { get; set; }
        public string? Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }
        [JsonIgnore]
        public virtual ICollection<TipoProducto> TipoProductos { get; set; }
    }
}
