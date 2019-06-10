using Microsoft.EntityFrameworkCore;
using SPMedGroup.Domains;
using SPMedGroup.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SPMedGroup.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        public void Cadastrar(Usuarios usuario)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                Usuarios usuario = ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == email && x.Senha == senha);

                if (usuario != null)
                {
                    return usuario;
                }

                return null;
            }
        }

        public void CadastrarProntuario(ProntuarioPaciente prontuario)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.ProntuarioPaciente.Add(prontuario);
                ctx.SaveChanges();
            }
        }

        public List<Medicos> ListarMedicos()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Medicos.ToList();
            }
        }

        //public List<Usuarios> ListarPacientes()
        //{
        //    using (SPMedGroupContext ctx = new SPMedGroupContext())
        //    { 
        //        return ctx.Usuarios.Where(x => x.IdTipoUsuarioNavigation.TipoUsuario == "Paciente").ToList();
        //    }
        //}

        public List<ProntuarioPaciente> ListarPacientes()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.ProntuarioPaciente.Include(x=>x.IdUsuarioNavigation).ToList();
            }
        }
    }
}
