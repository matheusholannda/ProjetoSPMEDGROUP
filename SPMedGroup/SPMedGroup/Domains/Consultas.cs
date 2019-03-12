using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o prontuário do paciente que será atendido")]
        public int IdProntuario { get; set; }
        [Required(ErrorMessage = "Informe o médico que fará a consulta")]
        public int IdMedico { get; set; }
        [Required(ErrorMessage = "Informe o dia que a consulta será realizada")]
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe o estado da consulta(começa apenas agendada)")]
        public int IdTipoSituacao { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public ProntuarioPaciente IdProntuarioNavigation { get; set; }
        public TipoSituacoes IdTipoSituacaoNavigation { get; set; }
    }
}
