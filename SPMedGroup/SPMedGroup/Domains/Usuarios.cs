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
        [Required(ErrorMessage = "Informe seu nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o tipo de usuário")]
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "A senha deve ter 4 e 150 caracteres")]
        public string Senha { get; set; }

        public virtual TipoUsuarios IdTipoUsuarioNavigation { get; set; }
        public virtual ProntuarioPaciente ProntuarioPaciente { get; set; }
        public virtual ICollection<Medicos> Medicos { get; set; }
    }
}
