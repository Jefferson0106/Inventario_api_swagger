using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class Permiso
    {
        public Permiso()
        {
            RolPermisos = new HashSet<RolPermiso>();
        }

        public int IdPermiso { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        [JsonIgnore]
        public virtual ICollection<RolPermiso> RolPermisos { get; set; }
    }
}
