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
    }
}
