using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o CNPJ da clínica que será cadastrada")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Informe a razão social da clínica")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "Informe o endereço da clínica")]
        public string Endereco { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
