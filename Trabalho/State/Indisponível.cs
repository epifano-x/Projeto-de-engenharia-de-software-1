using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.State
{
    internal class Indisponível : IState
    {
        public void DemonstrarEstado()
        {
            Console.WriteLine("Horário indisponível");
        }

        public void DisponibilizarHorario()
        {
            Console.WriteLine("Horário indisponível não pode mais ser disponibilizado");
        }

        public void ReservarHorario()
        {
            Console.WriteLine("Horário indisponível não pode mais ser reservado");
        }

        public void IndisponibilizarHorario()
        {
            Console.WriteLine("Horário já indisponível");
        }
    }
}
