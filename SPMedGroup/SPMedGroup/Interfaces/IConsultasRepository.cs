using SPMedGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.Interfaces
{
    interface IConsultasRepository
    {
        void Cadastrar(Consultas consulta);
        void Atualizar(Consultas consulta);
    }
}
