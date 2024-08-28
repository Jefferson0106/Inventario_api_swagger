using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Almacenes = new HashSet<Almacene>();
        }

        public int IdUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? ApellidoCompleto { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? Cedula { get; set; }
        public string? Telefono { get; set; }
        public int? IdRol { get; set; }
        public DateTime? FechaCreacion { get; set; }

        [JsonIgnore]
        public virtual Role? IdRolNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Almacene> Almacenes { get; set; }
    }
}
