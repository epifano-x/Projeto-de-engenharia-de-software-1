namespace Trabalho.State
{
    public class Disponivel : IState
    {
        public void DemonstrarEstado()
        {
            Console.WriteLine("Horário disponível");
        }

        public void DisponibilizarHorario()
        {
            Console.WriteLine("Horário já está disponível");
        }

        public void ReservarHorario()
        {
            Console.WriteLine("Horário mudado pra reservado");
        }
        public void IndisponibilizarHorario()
        {
            Console.WriteLine("Horário mudado pra indisponível");
        }
    }
}
