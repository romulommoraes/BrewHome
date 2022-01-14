using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Classes.JSON
{
    public class FermentavelToJson
    {
        public FermentavelToJson(string nome, double peso)
        {
            Nome = nome;
            Peso = peso;
        }
        public string Nome { get; set; }
        public double Peso { get; set; }
    }
}
