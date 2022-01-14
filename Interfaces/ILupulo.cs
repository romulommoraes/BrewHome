using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Interfaces
{
    public interface ILupulo
    {

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public double AlfaAcido { get; set; }
        public double PesoG { get; set; }
        public double Pontos { get; set; }

        public double TempoFervura { get; set; }

        public void CalcPontos(float utilizacao);

    }
}
