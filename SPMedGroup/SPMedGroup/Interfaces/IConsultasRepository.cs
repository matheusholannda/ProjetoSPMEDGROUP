using SPMedGroup.Domains;
using System.Collections.Generic;

namespace SPMedGroup.Interfaces
{
    interface IConsultasRepository
    {
        void Cadastrar(Consultas consulta);
        void Atualizar(Consultas consulta);
        List<Consultas> ListarConsultasMed(int id);
        List<Consultas> ListarConsultasPac(int id);
        List<Consultas> ListarConsultas();
        Consultas BuscarPorId(int id);
    }
}
