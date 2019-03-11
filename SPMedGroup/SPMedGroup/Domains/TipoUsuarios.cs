using System;
using System.Collections.Generic;

namespace SPMedGroup.Domains
{
    public partial class TipoUsuarios
    {
        public TipoUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string TipoUsuario { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
