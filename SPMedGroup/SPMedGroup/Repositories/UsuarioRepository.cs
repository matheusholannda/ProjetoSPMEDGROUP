using Microsoft.EntityFrameworkCore;
using SPMedGroup.Domains;
using SPMedGroup.Interfaces;
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
    }
}
