using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.Sistema
{
    public class HistóricoMédico
    {
        public Consulta Consulta { get; set; }
        public string Detalhes { get; set; } 
        public string Diagnóstico { get; set; }

        public HistóricoMédico(Consulta consulta, string detalhes, string diagnóstico)
        {
            Consulta = consulta;
            Detalhes = detalhes;
            Diagnóstico = diagnóstico;
        }
    }
}
