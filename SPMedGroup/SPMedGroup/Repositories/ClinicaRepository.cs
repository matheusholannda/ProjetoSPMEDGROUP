using SPMedGroup.Domains;
using SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.Repositories
{
    public class ClinicaRepository : IClinicasRepository
    {
        public void Cadastrar(Clinica clinica)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
        }

        public List<Clinica> Listar()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Clinica.ToList();
            }
        }
    }
}
