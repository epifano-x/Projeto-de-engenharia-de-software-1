using Trabalho.State;

namespace Trabalho.Sistema
{
    public class Horario : IState
    {
        public DateTime DateTime { get; set; }
        public IState HorarioState { get; set; }

        public Horario(DateTime datetime)
        {
            HorarioState = new Disponivel();
            DateTime = datetime;
        }
        public void DemonstrarEstado()
        {
            HorarioState.DemonstrarEstado();
        }
        public override string ToString()
        {
            return $"{DateTime}";
        }

        public void ReservarHorario()
        {
            HorarioState.ReservarHorario();
            if (HorarioState is Disponivel)
                HorarioState = new Reservado();
        }
        public void DisponibilizarHorario()
        {
            HorarioState.DisponibilizarHorario();
            if (HorarioState is Reservado)
                HorarioState = new Disponivel();
        }

        public void IndisponibilizarHorario()
        {
            HorarioState.IndisponibilizarHorario();
            HorarioState = new Indisponível();
        }
    }
}
