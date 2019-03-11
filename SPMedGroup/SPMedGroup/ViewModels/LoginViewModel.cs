using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "A senha deve ter de 4 e 150 caracteres")]
        public string Senha { get; set; }
    }
}
