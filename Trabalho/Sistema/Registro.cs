namespace Trabalho.Sistema
{
    public class Registro
    {
        public List<Consulta>? Consulta = new List<Consulta>();

        public void AdicionarNoRegistro(Consulta consultanova)
        {
            Consulta.Add(consultanova);
            Console.WriteLine("Consulta adicionada no registro.");
            Console.WriteLine($"{consultanova.Agenda.Cliente.Nome}");
        }
    }
}
