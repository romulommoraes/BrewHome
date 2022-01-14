using BrewHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Classes.JSON
{
    public class ReceitaToJSon
    {
        public string Nome { get; set; }
        public string Estilo { get; set; }
        public double VolumeFinal { get; set; }
        public double TempoMostura { get; set; }
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

        public ReceitaToJSon()
        {
            Fermentaveis = new();
            Lupulos = new();
        }

    }
}
