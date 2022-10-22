using Trabalho.Sistema;

namespace Trabalho.State
{
    public interface IState
    {
        void DemonstrarEstado();
        void ReservarHorario();
        void DisponibilizarHorario();
        void IndisponibilizarHorario();
    }
}
