using System;
using System.Collections.Generic;

namespace SPMedGroup.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public int? IdEspecialidade { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdClinica { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidades IdEspecialidadeNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultas> Consultas { get; set; }
    }
}
