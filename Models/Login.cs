using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Javier_Inventario.Models
{
    public partial class Login
    {
        public int? IdUsuario { get; set; }

        [JsonIgnore]
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
