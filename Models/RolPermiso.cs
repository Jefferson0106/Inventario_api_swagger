using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class RolPermiso
    {
        public int IdRolPermiso { get; set; }
        public int? IdRol { get; set; }
        public int? IdPermiso { get; set; }
        [JsonIgnore]
        public virtual Permiso? IdPermisoNavigation { get; set; }
        [JsonIgnore]
        public virtual Role? IdRolNavigation { get; set; }
    }
}
