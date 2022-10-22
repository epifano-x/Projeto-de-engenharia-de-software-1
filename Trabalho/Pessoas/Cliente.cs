using Trabalho.Sistema;

namespace Trabalho.Pessoas
{
    public class Cliente
    {
        public int Idade { get; set; }
        public Guid UsuarioID { get; set; }
        public string Nome { get; set; }
        public List<HistóricoMédico> HistóricoDoPaciente = new List<HistóricoMédico>();

        public Cliente (Guid clienteID, string nome, int idade, List<Cliente> clientes)
        {
            UsuarioID = clienteID;
            Nome = nome;
            Idade = idade;
            clientes.Add(this);
        }

        public override string ToString()
        {
            return "Cliente";
        }
    }
}
