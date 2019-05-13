using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SPMedGroup.Domains;
using SPMedGroup.Interfaces;

namespace SPMedGroup.Repositories
{
    public class ConsultaRepository : IConsultasRepository
    {
        public void Atualizar(Consultas consulta)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Consultas.Update(consulta);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Consultas consulta)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public List<Consultas> ListarConsultas()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                List<Consultas>listaConsultas = ctx.Consultas.Include(x => x.IdProntuarioNavigation.IdUsuarioNavigation).Include(x => x.IdTipoSituacaoNavigation).Include(x=> x.IdMedicoNavigation).ToList();

                foreach (var item in listaConsultas)
                {
                    item.IdMedicoNavigation.Consultas = null;
                    item.IdProntuarioNavigation.Consultas = null;
                    item.IdTipoSituacaoNavigation.Consultas = null;
                }

                return listaConsultas;
            }
        }

        public List<Consultas> ListarConsultasMed(int id)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                Medicos medico = ctx.Medicos.FirstOrDefault(x => x.IdUsuario == id);

                List<Consultas> listaConsultas = ctx.Consultas.Include(x => x.IdProntuarioNavigation.IdUsuarioNavigation).Include(x => x.IdTipoSituacaoNavigation).Include(x => x.IdMedicoNavigation).Where(x => x.IdMedicoNavigation.Id == medico.Id).ToList();

                foreach (var item in listaConsultas)
                {
                    item.IdMedicoNavigation.Consultas = null;
                    item.IdProntuarioNavigation.Consultas = null;
                    item.IdTipoSituacaoNavigation.Consultas = null;
                }

                return listaConsultas;
            }
        }

        public List<Consultas> ListarConsultasPac(int id)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ProntuarioPaciente prontuario = ctx.ProntuarioPaciente.FirstOrDefault(x => x.IdUsuario == id);

                List<Consultas> listaConsultas = ctx.Consultas.Include(x => x.IdProntuarioNavigation.IdUsuarioNavigation).Include(x => x.IdTipoSituacaoNavigation).Include(x => x.IdMedicoNavigation).Where(x => x.IdProntuarioNavigation.Id == prontuario.Id).ToList();

                foreach (var item in listaConsultas)
                {
                    item.IdMedicoNavigation.Consultas = null;
                    item.IdProntuarioNavigation.Consultas = null;
                    item.IdTipoSituacaoNavigation.Consultas = null;
                }

                return listaConsultas;
            }
        }

        public Consultas BuscarPorId(int id)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                Consultas consulta = ctx.Consultas.Include(x => x.IdProntuarioNavigation).Include(x => x.IdProntuarioNavigation.IdUsuarioNavigation).FirstOrDefault(x => x.Id == id);
            
                if (consulta == null)
                {
                    return null;
                }

                return consulta;
            }
        }

        public void AtualizarDesc(Consultas consulta)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Consultas.Update(consulta);
                ctx.SaveChanges();
            }
        }
    }
}
