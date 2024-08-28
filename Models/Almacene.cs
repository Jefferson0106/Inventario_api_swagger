using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class Almacene
    {
        public Almacene()
        {
            AlmacenProductos = new HashSet<AlmacenProducto>();
            InventarioAlmacenProductos = new HashSet<InventarioAlmacenProducto>();
        }

        public int IdAlmacen { get; set; }
        public string? NombreAlmacen { get; set; }
        public string? Ubicacion { get; set; }
        public string? Descripcion { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? FechaCreacion { get; set; }


        [JsonIgnore]
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<AlmacenProducto> AlmacenProductos { get; set; }
        [JsonIgnore]
        public virtual ICollection<InventarioAlmacenProducto> InventarioAlmacenProductos { get; set; }
    }
}
