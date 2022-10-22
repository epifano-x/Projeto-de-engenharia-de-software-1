namespace Trabalho.Sistema
{
    public class Consulta
    {
        public Agenda Agenda { get; set; }
        public int? Valor { get; set; }
        public void ConfirmarConsulta(int valor, Agenda agenda, Registro registrogeral)
        {
            Agenda = agenda;
            Valor = valor;
            registrogeral.AdicionarNoRegistro(this);
            Console.WriteLine("Consulta Realizada");
        }
    }
}
