using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class TipoProducto
    {
        public TipoProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdTipoProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? IdColor { get; set; }
        public int? IdSubColor { get; set; }
        public DateTime? FechaCreacion { get; set; }

        [JsonIgnore]
        public virtual Colore? IdColorNavigation { get; set; }
        [JsonIgnore]
        public virtual SubColor? IdSubColorNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
