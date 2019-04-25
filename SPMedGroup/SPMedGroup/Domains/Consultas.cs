using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.Domains
{
    public partial class Consultas
    {
        [Required(ErrorMessage = "Informe o Id da consulta que será consultada")]
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

        public virtual Medicos IdMedicoNavigation { get; set; }
        public virtual ProntuarioPaciente IdProntuarioNavigation { get; set; }
        public virtual TipoSituacoes IdTipoSituacaoNavigation { get; set; }
    }
}
