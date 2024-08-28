using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class Producto
    {
        public Producto()
        {
            AlmacenProductos = new HashSet<AlmacenProducto>();
            InventarioAlmacenProductos = new HashSet<InventarioAlmacenProducto>();
        }

        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? CodigoProducto { get; set; }
        public int? Stoks { get; set; }
        public string? Descripcion { get; set; }
        public string? UbicacionProducto { get; set; }
        public bool? Estatus { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdTipoProducto { get; set; }
        public int? IdColor { get; set; }
        public int? IdSubColor { get; set; }
        public DateTime? FechaCreacion { get; set; }

        [JsonIgnore]
        public virtual Categoria? IdCategoriaNavigation { get; set; }
        [JsonIgnore]
        public virtual Colore? IdColorNavigation { get; set; }
        [JsonIgnore]
        public virtual SubColor? IdSubColorNavigation { get; set; }
        [JsonIgnore]
        public virtual TipoProducto? IdTipoProductoNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<AlmacenProducto> AlmacenProductos { get; set; }

        [JsonIgnore]
        public virtual ICollection<InventarioAlmacenProducto> InventarioAlmacenProductos { get; set; }
    }
}
