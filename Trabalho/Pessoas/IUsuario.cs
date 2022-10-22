using Trabalho.Sistema;

namespace Trabalho.Pessoas
{
    public interface IUsuario
    {
        public Guid UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        internal void MostrarAgendamento();
        internal void Agendar(Horario a, Agenda b, IUsuario c);
        public void RemoverAgendamento(int valor, Horario horario, Registro registrogeral);
        internal Boolean VerificaAgendamento();
        public void CadastrarCliente(List<Cliente> clientes);
        public void CadastrarMedico(List<IUsuario> usuarios);
        public void CadastrarSecretaria(List<IUsuario> usuarios);
        public void CadastrarAdministrador(List<IUsuario> usuarios);
    }
}