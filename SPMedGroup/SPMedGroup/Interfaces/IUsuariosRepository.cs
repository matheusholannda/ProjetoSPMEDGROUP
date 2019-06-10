using SPMedGroup.Domains;
using System.Collections.Generic;

namespace SPMedGroup.Interfaces
{
    interface IUsuariosRepository
    {
        void Cadastrar(Usuarios usuario);
        void CadastrarProntuario(ProntuarioPaciente prontuario);
        Usuarios BuscarPorEmailSenha(string email, string senha);
        List<Medicos> ListarMedicos();
        //List<Usuarios> ListarPacientes();
        List<ProntuarioPaciente> ListarPacientes();
    }
}
