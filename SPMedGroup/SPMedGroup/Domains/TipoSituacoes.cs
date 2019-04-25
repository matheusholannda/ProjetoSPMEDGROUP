using System;
using System.Collections.Generic;

namespace SPMedGroup.Domains
{
    public partial class TipoSituacoes
    {
        public TipoSituacoes()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Situacao { get; set; }

        public virtual ICollection<Consultas> Consultas { get; set; }
    }
}
