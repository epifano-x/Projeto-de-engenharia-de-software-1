using Trabalho.Sistema;

namespace Trabalho.Pessoas
{
    public class Medico : IUsuario
    {
        public Guid UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int MedicoIdade { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        public string Telefone { get; set; }


        public List<Agenda> Agendamentos = new List<Agenda>();

        internal Medico(Guid id, string nome, int idade, string senha, string rg, string cpf, string crm, string telefone, List<IUsuario> usuarios)
        {
            UsuarioID = id;
            Nome = nome;
            MedicoIdade = idade;
            Senha = senha;
            RG = rg;
            CPF = cpf;
            CRM = crm;
            Telefone = telefone;
            usuarios.Add(this);

        }

        public void AdicionarAgendamento(Agenda novaAgenda)
        {
            Agendamentos.Add(novaAgenda);

        }
        public void MostrarAgendamento()
        {
            foreach (var c in Agendamentos)
            {
                Console.WriteLine($"Nome do cliente: {c.Cliente.Nome}, horário do agendamento: {c.Horario}");
            }
        }
        public override string ToString()
        {
            return "Medico";
        }

        void IUsuario.Agendar(Horario horario, Agenda agenda, IUsuario c)
        {
            Console.WriteLine("Medico não muda agendamento");
        }

        public void RemoverAgendamento(int valor, Horario horario, Registro registrogeral)
        {
            Consulta consulta = new Consulta();
            foreach(var a in Agendamentos.ToList())
            {
                if (horario == a.Horario)
                {
                    Console.WriteLine("Informe o diagnóstico do paciente:");
                    string diagnóstico = Console.ReadLine();
                    Console.WriteLine("Informe detalhes adicionais: ");
                    string detalhes = Console.ReadLine();
                    HistóricoMédico histórico = new HistóricoMédico(consulta, detalhes, diagnóstico);
                    a.Cliente.HistóricoDoPaciente.Add(histórico);
                    consulta.ConfirmarConsulta(valor, a, registrogeral);
                    Agendamentos.Remove(a);
                }
            }

            horario.IndisponibilizarHorario();
        }

        public bool VerificaAgendamento()
        {
            if (Agendamentos.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        void IUsuario.CadastrarCliente(List<Cliente> clientes)
        {
            throw new NotImplementedException();
        }

        void IUsuario.CadastrarMedico(List<IUsuario> usuarios)
        {
            throw new NotImplementedException();
        }

        void IUsuario.CadastrarSecretaria(List<IUsuario> usuarios)
        {
            throw new NotImplementedException();
        }

        void IUsuario.CadastrarAdministrador(List<IUsuario> usuarios)
        {
            throw new NotImplementedException();
        }
    }
}

