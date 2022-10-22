using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.State
{
    public class Reservado : IState
    {
        public void DemonstrarEstado()
        {
            Console.WriteLine("Horário reservado");
        }

        public void DisponibilizarHorario()
        {
            Console.WriteLine("Horário mudado pra Disponível");
        }
        public void ReservarHorario()
        {
            Console.WriteLine("Horário já reservado, tente outro");
        }
        public void IndisponibilizarHorario()
        {
            Console.WriteLine("Horário mudado pra indisponível");
        }
    }
}
