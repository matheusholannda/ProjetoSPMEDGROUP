using System;
using System.Collections.Generic;

namespace SPMedGroup.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public int IdProntuario { get; set; }
        public int IdMedico { get; set; }
        public DateTime? DataConsulta { get; set; }
        public string Descricao { get; set; }
        public int IdTipoSituacao { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public ProntuarioPaciente IdProntuarioNavigation { get; set; }
        public TipoSituacoes IdTipoSituacaoNavigation { get; set; }
    }
}
