using SPMedGroup.Domains;

namespace SPMedGroup.Interfaces
{
    interface IUsuariosRepository
    {
        void Cadastrar(Usuarios usuario);
        void CadastrarProntuario(ProntuarioPaciente prontuario);
        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
