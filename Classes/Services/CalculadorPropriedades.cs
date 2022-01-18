using BrewHome.Classes.Insumos;
using BrewHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Classes.Services
{
    public class CalculadorPropriedades
    {
        public Receita Receita { get; set; }

        public CalculadorPropriedades(Receita receita)
        {
            Receita = receita;

        }

        public void CalcularPropriedades(double eficiencia)
        {
          
            double TotalPontosAcucar = 0;
            double TotalPontosCor = 0;

            foreach (Fermentavel ferm in Receita.Fermentaveis)
            {
                ferm.CalcTotAcucar();
                ferm.CalcPontosCor();
                TotalPontosAcucar += ferm.PontosAcucar;
                TotalPontosCor += ferm.PontosCor;
            }
            Receita.OG = Math.Round(1000 + (TotalPontosAcucar * eficiencia) / (Receita.VolumeFinal * 0.264172));
            double corLovibond = (TotalPontosCor + 0.76) / 1.3546; //converte SRM pra lovibond

            Receita.COR = Math.Round(TotalPontosCor / (Receita.VolumeFinal * 0.264172), 1);

            //se o srm for acima de 2 aplicar correção de morey
            if (Receita.COR > 2)
            {
                Receita.COR = Math.Round(corLovibond / (Receita.VolumeFinal * 0.264172), 1);
                Receita.COR = Math.Round(1.5 * Math.Pow(Receita.COR, 0.7), 1);
            }
        }

        public void CalcularIBU()
        {
            double TotalPontos = 0;

            foreach (ILupulo lup in Receita.Lupulos)
            {
                float utiliz;
                if (Receita.OG < 1040)
                {
                   utiliz = DICibu.DefIBU30(lup.TempoFervura);
                }
                else if (Receita.OG >= 1040 && Receita.OG < 1050)
                {
                    utiliz = DICibu.DefIBU40(lup.TempoFervura);
                }
                else if (Receita.OG >= 1050 && Receita.OG < 1060)
                {
                    utiliz = DICibu.DefIBU50(lup.TempoFervura);
                }
                else if (Receita.OG >= 1060 && Receita.OG < 1070)
                {
                    utiliz = DICibu.DefIBU60(lup.TempoFervura);
                }
                else if (Receita.OG >= 1070 && Receita.OG < 1080)
                {
                    utiliz = DICibu.DefIBU70(lup.TempoFervura);
                }
                else if (Receita.OG >= 1080 && Receita.OG < 1090)
                {
                    utiliz = DICibu.DefIBU80(lup.TempoFervura);
                }
                else 
                {
                    utiliz = DICibu.DefIBU90high(lup.TempoFervura);
                }
                lup.CalcPontos(utiliz);
                TotalPontos += lup.Pontos;
            }

            Receita.IBU = Math.Round((TotalPontos)/Receita.VolumeFinal, 1) ;

        }

        public void CalcularABV()
        {
            try
            {
                double atenuado = (Receita.OG - 1000) * (Receita.Levedura.Atenuacao / 100);
                Receita.FG = Math.Round(Receita.OG - (atenuado));
                Receita.ABV = Math.Round((131.25 * (Receita.OG - Receita.FG))/1000, 1);
            }
            catch (Exception)
            {
                Receita.FG = 0;
                Receita.ABV = 0;
            }
        }

        public void CalcularCalorias()
        {
            try
            {
                // plato
                double PlatoInicial = (-463.37) + (668.72 * (Receita.OG/1000)) - (205.35 * Math.Pow((Receita.OG / 1000), 2));
                double PlatoFinal = (-463.37) + (668.72 * (Receita.FG / 1000)) - (205.35 * Math.Pow((Receita.FG / 1000), 2));

                // re
                double RE = (0.1808 * PlatoInicial) + (0.8192 * PlatoFinal);

                //abw         

                double ABW = (0.79 * Receita.ABV) / (Receita.FG / 1000);
                double CalTotal12oz = ((6.9 * ABW) + 4.0 * (RE - 0.1)) * (Receita.FG / 1000) * 3.55;


                double doubleCal330ml = (CalTotal12oz * 11.2) / 12;
                Receita.Calorias = Math.Round(doubleCal330ml, 1);
            }
            catch (Exception)
            {
                Receita.Calorias = 0;
            }
        }


    }
}
