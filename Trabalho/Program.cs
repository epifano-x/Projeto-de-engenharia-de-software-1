using System;
using Trabalho.Pessoas;
using Trabalho.Sistema;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IUsuario> usuarios = new List<IUsuario>();
            List<Cliente> clientes = new List<Cliente>();

            Administrador administrador = new Administrador(new Guid(), "Admin", "Admin", usuarios);
            Secretaria carla = new Secretaria(new Guid(), "Carla", 24, "1234", "123456", "345432", "40028922", usuarios);
            Secretaria caroline = new Secretaria(new Guid(), "Caroline", 18, "2345", "123", "454324", "99776213", usuarios);
            Medico Evandro = new Medico(new Guid(), "Evandro", 32, "1234", "2342", "43432", "32131", "554433992", usuarios);
            Cliente vinicius = new Cliente(new Guid(), "Vinicius", 22, clientes);
            Cliente Marcos = new Cliente(new Guid(), "Marcos", 23, clientes);
            Registro registrogeral = new Registro();
            List<Horario> horarioList = new List<Horario>();

            for (int cont = 0; cont < 24; cont++)
            {
                Horario horario = new Horario(DateTime.Parse($"19/06/2022 {cont}:00:00"));
                horarioList.Add(horario);
            }

            Agenda agenda = new Agenda();
            agenda.CriarAgenda(1, new Horario(DateTime.Parse("24/06/2022 12:30:20")), Evandro, vinicius, carla);

            Consulta consulta = new Consulta();
            consulta.ConfirmarConsulta(250, agenda, registrogeral);

            Agenda agenda2 = new Agenda();
            agenda2.CriarAgenda(2, new Horario(DateTime.Parse("24/06/2022 13:30:20")), Evandro, Marcos, caroline);

            Consulta consulta2 = new Consulta();
            consulta2.ConfirmarConsulta(200, agenda2, registrogeral);

            IUsuario? loginAtual = null;
            string? usuario = null;
            string? senha = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Digite uma tecla para iniciar...");
                Console.ReadKey();

                do
                {
                    Console.WriteLine("Digite o seu usuário: ");
                    usuario = Console.ReadLine();
                    Console.WriteLine("Digite a sua senha: ");
                    senha = Console.ReadLine();
                    foreach (var us in usuarios)
                    {
                        if (us.Nome == usuario && us.Senha == senha)
                        {
                            loginAtual = us;
                        }
                    }
                    if (loginAtual == null)
                    {
                        Console.WriteLine("Usuário e/ou senha inválidos, digite novamente");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Logado como {loginAtual}");
                    }
                } while (loginAtual == null);

                if (loginAtual is Medico)
                {
                    string letra;
                    int valor;
                    Horario horario;
                    do
                    {
                        Console.WriteLine("Deseja ver suas consultas marcadas? S/N");
                        letra = Console.ReadLine();
                    } while (letra != "S" && letra != "N");
                    if (letra == "S")
                        loginAtual.MostrarAgendamento();
                    else
                    {
                        Console.WriteLine("Deseja confirmar uma consulta? (S/N)");
                        letra = Console.ReadLine();
                        if (letra == "S")
                        {
                            if (loginAtual.VerificaAgendamento() == true)
                            {

                                Console.WriteLine("Informe o horário da consulta que será confirmada: ");
                                loginAtual.MostrarAgendamento();
                                horario = new Horario(DateTime.Parse(Console.ReadLine()));


                                Console.WriteLine("Informe o valor da consulta a ser cobrado: ");
                                valor = int.Parse(Console.ReadLine());

                                foreach (var d in horarioList)
                                {
                                    if (horario.DateTime == d.DateTime)
                                    {
                                        loginAtual.RemoverAgendamento(valor, d, registrogeral);
                                    }
                                }
                            }
                            else
                                Console.WriteLine("Nenhum agendamento feito para confirmação");
                        } else if (letra == "N")
                        {
                            Console.WriteLine("Deseja ver histórico médico de algum paciente? ");
                            letra = Console.ReadLine();
                            if (letra == "S")
                            {
                                Console.WriteLine("Escolha um paciente pra visualizar histórico: ");
                                foreach(var a in clientes)
                                {
                                    Console.WriteLine(a.Nome);
                                }
                                string nome = Console.ReadLine();
                                foreach (var d in clientes)
                                {
                                    if (nome == d.Nome)
                                    {
                                        foreach(var c in d.HistóricoDoPaciente)
                                        {
                                            Console.WriteLine(".....");
                                            Console.WriteLine($"Dia da consulta: {c.Consulta.Agenda.Horario.ToString()}");
                                            Console.WriteLine($"Custou: {c.Consulta.Valor}");
                                            Console.WriteLine($"Diagnóstico: {c.Diagnóstico}");
                                            Console.WriteLine($"Detalhes: {c.Detalhes}");
                                        }
                                    }
                                }

                            }
                        }
                    }

                }
                else if (loginAtual is Secretaria)
                {
                    string letra;
                    string nome;
                    string medico;
                    Horario horario;
                    do
                    {
                        Console.WriteLine("Deseja agendar nova consulta? S/N");
                        letra = Console.ReadLine();
                    } while (letra != "S" && letra != "N");
                    if (letra == "S")
                    {
                        Console.WriteLine("Selecione um cliente: ");
                        foreach (var a in clientes)
                        {

                            Console.WriteLine(a.Nome);
                        }
                        nome = Console.ReadLine();
                        Console.WriteLine("Selecione um médico: ");
                        foreach (var b in usuarios)
                        {
                            if (b is Medico)
                            {
                                Console.WriteLine(b.Nome);
                            }
                        }
                        medico = Console.ReadLine();
                        Console.WriteLine("Selecione um horário disponível pra marcar a consulta (DD/MM/AA HH:MM:SS)");
                        foreach (var c in horarioList)
                        {
                            Console.WriteLine(c.ToString());
                            c.DemonstrarEstado();
                        }
                        horario = new Horario(DateTime.Parse(Console.ReadLine()));

                        foreach (var a in clientes)
                        {
                            if (nome == a.Nome)
                            {
                                foreach (var b in usuarios)
                                {
                                    if (medico == b.Nome)
                                    {
                                        foreach (var d in horarioList)
                                        {
                                            if (horario.DateTime == d.DateTime)
                                            {
                                                agenda = new Agenda();
                                                agenda.CriarAgenda(1, d, (Medico)b, (Cliente)a, (Secretaria)loginAtual);
                                                loginAtual.Agendar(d, agenda, loginAtual);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else if (letra == "N")
                    {
                        Console.WriteLine("Deseja cadastrar novo cliente? (S/N)");
                        letra = Console.ReadLine();
                        if (letra == "S")
                        {
                            loginAtual.CadastrarCliente(clientes);
                        } else if (letra == "N")
                        {
                            Console.WriteLine("Deseja cancelar uma consulta? (S/N)");
                            letra = Console.ReadLine();
                            if (letra == "S")
                            {
                                Console.WriteLine("Digite o horário da consulta a ser cancelada :");
                                foreach(var a in usuarios)
                                {
                                    if (a is Medico)
                                    {
                                        a.MostrarAgendamento();
                                    }
                                }
                               horario = new Horario(DateTime.Parse(Console.ReadLine()));
                                foreach (var d in horarioList)
                                {
                                    if (horario.DateTime == d.DateTime)
                                    {
                                        loginAtual.RemoverAgendamento(0, d, registrogeral);
                                    }
                                }
                            } else if (letra == "N")
                            {
                                Console.WriteLine("Deseja mostrar o registro?(S/N)");
                                letra = Console.ReadLine();
                                if (letra == "S")
                                {
                                    foreach(var a in registrogeral.Consulta)
                                    {
                                        Console.WriteLine($"Dia realizada: {a.Agenda.Horario.ToString()}");
                                        Console.WriteLine($"Paciente atendido: {a.Agenda.Cliente.Nome}");
                                        Console.WriteLine($"Médico que atendeu: {a.Agenda.Medico.Nome}");
                                        Console.WriteLine($"Valor da consulta: {a.Valor}");
                                        Console.WriteLine("");
                                    }
                                }
                            }
                        }
                    }
                } else if (loginAtual is Administrador)
                {
                    string letra;
                    int verificação;
                    Console.WriteLine("Gostaria de adicionar um novo cadastro? (S/N)");
                    letra = Console.ReadLine();
                    if (letra == "S")
                    {
                        do
                        {

                            Console.WriteLine("Digite 1 pra cadastrar novo Administrador");
                            Console.WriteLine("Digite 2 pra cadastrar novo Médico");
                            Console.WriteLine("Digite 3 pra cadastrar nova Secretária");
                            Console.WriteLine("Digite 4 pra cadastrar novo Cliente");
                            Console.WriteLine("Digite 5 pra cancelar");
                            verificação = int.Parse(Console.ReadLine());
                            Console.Clear();
                            if (verificação < 1 || verificação > 5)
                            {
                                Console.WriteLine("Opção inválida, tente novamente.");
                            }
                        } while (verificação < 1 || verificação > 5);

                        if (verificação == 1)
                        {
                            loginAtual.CadastrarAdministrador(usuarios);
                        }else if (verificação == 2)
                        {
                            loginAtual.CadastrarMedico(usuarios);
                        }
                        else if (verificação == 3)
                        {
                            loginAtual.CadastrarSecretaria(usuarios);
                        }
                        else if (verificação == 4)
                        {
                            loginAtual.CadastrarCliente(clientes);
                        }
                    }
                }
                Console.ReadKey();
                loginAtual = null;
            } while (true);
        }
    }
}