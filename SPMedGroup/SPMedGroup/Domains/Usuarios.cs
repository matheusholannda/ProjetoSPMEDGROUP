using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int IdTipoUsuario { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }

        public TipoUsuarios IdTipoUsuarioNavigation { get; set; }
        public ProntuarioPaciente ProntuarioPaciente { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
    }
}
