export const usuarioAutorizado = () => localStorage.getItem('user-spmedgroup') !== null;
export function sair () {
    localStorage.removeItem("user-spmedgroup");
};