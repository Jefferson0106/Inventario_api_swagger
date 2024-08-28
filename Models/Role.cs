using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class Role
    {
        public Role()
        {
            RolPermisos = new HashSet<RolPermiso>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string? NombreRol { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        [JsonIgnore]
        public virtual ICollection<RolPermiso> RolPermisos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
