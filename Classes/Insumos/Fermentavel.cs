using BrewHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Classes.Insumos
{
    public class Fermentavel 
    {
        public Fermentavel(string nome, string tipo, double ebc, double extrato, double pesoKG)
        {
            Nome = nome;
            Tipo = tipo;
            EBC = ebc;
            Extrato = extrato;
            PesoKG = pesoKG;

        }

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public double EBC { get; set; }
        public double Extrato { get; set; }
        public double PontosAcucar { get; set; }
        public double PontosCor { get; set; }
        public double TotAcucar { get; set; }
        public double PesoKG { get; set; }
        public double pesoPorcent { get; set; }

        public void CalcTotAcucar()
        {
            TotAcucar = (Extrato / 100) * 46.31;
            PontosAcucar = TotAcucar * (PesoKG * 2.20462);
        }
        public void CalcPontosCor()
        {
            PontosCor = (EBC * 0.508) * (PesoKG * 2.20462); //converte ebc pra srm e kg pra galão e calcula os pontos de cor
        }



    }
}
