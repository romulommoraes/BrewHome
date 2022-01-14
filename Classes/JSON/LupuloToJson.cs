using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Classes.JSON
{
    public class LupuloToJson
    {
        public LupuloToJson(string nome, double peso, double tempoFervura)
        {
            Nome = nome;
            Peso = peso;
            TempoFervura = tempoFervura;
        }

        public string Nome { get; set; }
        public double Peso { get; set; }
        public double TempoFervura { get; set; }
    }
}
