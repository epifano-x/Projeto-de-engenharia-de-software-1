using Trabalho.Sistema;

namespace Trabalho.Pessoas
{
    internal class Administrador : IUsuario
    {
        public Guid UsuarioID { get; set ; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        internal Administrador(Guid id, string nome, string senha, List<IUsuario> usuarios)
        {
            UsuarioID = id;
            Nome = nome;
            Senha = senha;
            usuarios.Add(this);
        }

        void IUsuario.MostrarAgendamento()
        {
            Console.WriteLine("Administrador não visualiza agendamento");
        }

        void IUsuario.Agendar(Horario horario, Agenda agenda, IUsuario c)
        {
        }

        void IUsuario.RemoverAgendamento(int valor, Horario horario, Registro registrogeral)
        {
            Console.WriteLine("Administrador não remove agendamento");
        }

        bool IUsuario.VerificaAgendamento()
        {
            Console.WriteLine("Administrador não verifica os agendamentos");
            return false;
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
            int flag = 0, idade;
            string senha, rg, cpf, crm, telefone, nome;
            do {
                flag = 0;
                Console.WriteLine("Informe o nome do médico:");
                nome = Console.ReadLine();
                Console.WriteLine("Informe a senha do médico: ");
                senha = Console.ReadLine();
                Console.WriteLine("Informe a idade do médico: ");
                idade = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe o RG do médico: ");
                rg = Console.ReadLine();
                Console.WriteLine("Informe o CPF do médico: ");
                cpf = Console.ReadLine();
                Console.WriteLine("Informe o CRM do médico: ");
                crm = Console.ReadLine();
                Console.WriteLine("Informe o telefone do médico: ");
                telefone = Console.ReadLine();
                foreach (var a in usuarios)
                {
                    if (nome == a.Nome)
                    {
                        flag = 1;
                        Console.WriteLine("Esse nome de usuário já existe. Tente novamente.");
                    }
                }
            } while (flag != 0);
            Console.WriteLine("Médico cadastrado.");
            Medico medico = new Medico(new Guid(), nome, idade, senha, rg, cpf, crm, telefone, usuarios);
        }

        void IUsuario.CadastrarSecretaria(List<IUsuario> usuarios)
        {
            int flag = 0, idade;
            string nome, senha, rg, cpf, telefone;
            do {
                flag = 0;
                Console.WriteLine("Informe o nome da secretária:");
                nome = Console.ReadLine();
                Console.WriteLine("Informe a senha da secretária: ");
                senha = Console.ReadLine();
                Console.WriteLine("Informe a idade da secretária: ");
                idade = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe o RG da secretária: ");
                rg = Console.ReadLine(); 
                Console.WriteLine("Informe o CPF da secretária: ");
                cpf = Console.ReadLine();
                Console.WriteLine("Informe o telefone da secretária: ");
                telefone = Console.ReadLine();
                foreach (var a in usuarios)
                {
                    if (nome == a.Nome)
                    {
                        flag = 1;
                        Console.WriteLine("Esse nome de usuário já existe. Tente novamente.");
                    }
                }
            } while (flag != 0);
            Console.WriteLine("Secretária cadastrada.");
            Secretaria secretaria = new Secretaria(new Guid(), nome, idade, senha, rg, cpf, telefone, usuarios);
        }

        void IUsuario.CadastrarAdministrador(List<IUsuario> usuarios)
        {
            int flag = 0;
            string nome;
            string senha;
            do
            {
                flag = 0;
                Console.WriteLine("Informe o nome da conta do administrador: ");
                nome = Console.ReadLine();
                Console.WriteLine("Informe a senha do administrador: ");
                senha = Console.ReadLine();
                foreach (var a in usuarios)
                {
                    if (nome == a.Nome)
                    {
                        flag = 1;
                        Console.WriteLine("Esse nome de usuário já existe. Tente novamente.");
                    }
                }
            } while (flag != 0);
            Console.WriteLine("Administrador cadastrado.");
            Administrador admin = new Administrador(new Guid(), nome, senha, usuarios);
        }
        public override string ToString()
        {
            return "Administrador";
        }
    }
}
