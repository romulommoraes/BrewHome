using BrewHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Classes.Insumos
{
    public class Lupulo :ILupulo
    {
        public Lupulo(string nome, string tipo, double alfaAcido, double peso, double tempoFervura)
        {
            Nome = nome;
            Tipo = tipo;
            AlfaAcido = alfaAcido;
            PesoG = peso;
            TempoFervura = tempoFervura;
        }

       public string Nome { get; set; }
       public string Tipo { get; set; }
       public double AlfaAcido { get; set; }
       public double PesoG { get; set; }
        public double Pontos { get; set; }

        public double TempoFervura { get; set; }


        public void CalcPontos( float utilizacao)
        {
            Pontos = (AlfaAcido /100) * (PesoG * 1000) * utilizacao;
        }
        public string ToTxt()
        {
            return $"{Nome};{Tipo};{AlfaAcido}";
        }

    }
}
