using SPMedGroup.Domains;

namespace SPMedGroup.Interfaces
{
    interface IUsuariosRepository
    {
        void Cadastrar(Usuarios usuario);
        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
