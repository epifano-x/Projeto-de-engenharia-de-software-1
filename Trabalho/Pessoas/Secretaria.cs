using Trabalho.Sistema;
using Trabalho.State;

namespace Trabalho.Pessoas
{
    public class Secretaria : IUsuario
    {
        public int SecretariaIdade { get; set; }
        public Guid UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }

        internal Secretaria(Guid id, string nome, int idade, string senha, string rg, string cpf, string telefone, List<IUsuario> usuarios)
        {
            UsuarioID = id;
            Nome = nome;
            SecretariaIdade = idade;
            Senha = senha;
            CPF = cpf;
            Telefone = telefone;
            RG = rg;
            usuarios.Add(this);

        }
        public void MostrarSenha()
        {
            Console.WriteLine($"A senha da secretária é: {Senha}");
        }
        public override string ToString()
        {
            return "Secretaria";
        }

        void IUsuario.MostrarAgendamento()
        {
            throw new Exception("Secretária não vê agendamento de médico");
        }
        public void Agendar(Horario horario, Agenda agenda, IUsuario loginatual)
        {
            if (loginatual is Secretaria)
            {
                if (horario.HorarioState is Disponivel)
                {
                    AdicionarAgendamento(agenda);
                }
                horario.ReservarHorario();
            }
        }
        internal void AdicionarAgendamento(Agenda agenda)
        {
            agenda.Medico.AdicionarAgendamento(agenda);
            Console.WriteLine("Agenda adicionada");
            Console.WriteLine($"Horário: {agenda.Horario}, Medico a atender: {agenda.Medico.Nome}, Secretária que registrou: {agenda.Secretaria.Nome}");
        }

        void IUsuario.RemoverAgendamento(int valor, Horario horario, Registro registrogeral)
        {
            horario.DisponibilizarHorario();
            foreach(var a in registrogeral.Consulta)
            {
                if (a.Agenda.Horario == horario)
                {
                    a.Agenda.Medico.Agendamentos.Remove(a.Agenda);
                }
            }
            Console.WriteLine("Agendamento removido.");
        }

        bool IUsuario.VerificaAgendamento()
        {
            throw new NotImplementedException();
        }

        void IUsuario.CadastrarCliente(List<Cliente> clientes)
        {
            Console.WriteLine("Informe o nome do cliente: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe a idade do cliente: ");
            int idade = int.Parse(Console.ReadLine());
            Cliente cliente = new Cliente(new Guid(), nome, idade, clientes);
        }

        void IUsuario.CadastrarMedico(List<IUsuario> usuarios)
        {
            Console.WriteLine("Secretária não cadastra médico");
        }

        void IUsuario.CadastrarSecretaria(List<IUsuario> usuarios)
        {
            Console.WriteLine("Secretária não cadastra secretára");
        }

        void IUsuario.CadastrarAdministrador(List<IUsuario> usuarios)
        {
            Console.WriteLine("Secretária não cadastra administrador");
        }
    }
}
