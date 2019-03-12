using SPMedGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.Interfaces
{
    interface IClinicasRepository
    {
        void Cadastrar(Clinica clinica);
        List<Clinica> Listar();
    }
}
