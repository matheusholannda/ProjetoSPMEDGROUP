using System;
using System.Collections.Generic;

namespace SPMedGroup.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public TipoUsuarios IdTipoUsuarioNavigation { get; set; }
        public ProntuarioPaciente ProntuarioPaciente { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
    }
}
