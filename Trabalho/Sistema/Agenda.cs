using Trabalho.Pessoas;
using Trabalho.State;

namespace Trabalho.Sistema
{
    public class Agenda
    {
        public int Id { get; set; }
        public Horario? Horario { get; set; }
        public Medico? Medico { get; set; }
        public Cliente? Cliente { get; set; }
        public Secretaria? Secretaria { get; set; }


        public void CriarAgenda(int id, Horario horario, Medico medico, Cliente cliente, Secretaria secretaria)
        {
            Id = id;
            Horario = horario;
            Medico = medico;
            Cliente = cliente;
            Secretaria = secretaria;
        }
    }
}
