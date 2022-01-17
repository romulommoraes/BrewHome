using BrewHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrewHome.Classes.JSON
{
    public class ReceitaToJSon
    {
        public string Nome { get; set; }
        public string Estilo { get; set; }
        public double VolumeFinal { get; set; }
       
        public double TempoFervura { get; set; }
        public double OG { get; set; } //calcular com base nos fermentáveis e tempo de mosturação
        public double FG { get; set; } //calcular com base na atenuação da levedura
        public double SRM { get; set; } 
        public double EBC { get; set; } //EBC (SRM*2)
        public double IBU { get; set; } //calcular com base nos lupulos
        public double ABV { get; set; } //calcular com base na OG/FG, e volume
        public List<FermentavelToJson> Fermentaveis { get; set; }
        public List<LupuloToJson> Lupulos { get; set; }
        public string Levedura { get; set; }
        public double Calorias { get; set; }
        public double TempoMostura { get; set; }
        public List<double[]> RampasMostura { get; set; }
        public double[] Fermentacao { get; set; }
        public double[] Maturacao { get; set; }
        public string[] Dryhopping { get; set; }

        public string ComentariosMostura { get; set; }
        public string ComentariosFervura { get; set; }
        public string ComentariosFermMat { get; set; }

        public ReceitaToJSon()
        {
            Fermentaveis = new();
            Lupulos = new();
            RampasMostura = new();
            Fermentacao = new double[2];
            Maturacao = new double[2];
            Dryhopping = new string[3];
        }

        public string ExportRampas()
        {
            string ret = "";
            string tem;
            string min;

            foreach (var item in RampasMostura)
            {
                tem = item[0].ToString();
                min = item[1].ToString();
                ret += $" Temperatura: {tem}°C: {min} Min \n";
            }
            return ret;
        }

        public string ExportMaturacao()
        {
            string ret = "";
            string tem = Maturacao[0].ToString();
            string min = Maturacao[1].ToString();
            ret += $" Temperatura: {tem}°C: {min} Min \n";

            return ret;
        }

        public string ExportFermentacao()
        {
            string ret = "";
            string tem = Fermentacao[0].ToString();
            string min = Fermentacao[1].ToString();
            ret += $" Temperatura: {tem}°C: {min} Min \n";

            return ret;
        }

    }
}
