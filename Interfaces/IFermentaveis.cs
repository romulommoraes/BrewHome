using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Interfaces
{
    public interface IFermentavel
    {
        string Nome { get; set; }
        string Tipo { get; set; }
        double EBC { get; set; }
        double Extrato { get; set; }
        double TotAcucar { get; set; }
        double PesoKG { get; set; }
        double PontosAcucar { get; set; }
        double PontosCor { get; set; }

        public void CalcPontosCor();
        public void CalcTotAcucar()
        {
            TotAcucar = (Extrato/100) * 46.31;
            PontosAcucar = TotAcucar * (PesoKG * 2.20462);
        }
    }
}
