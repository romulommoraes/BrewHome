using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Classes
{
    public class Estilo
    {
        public Estilo(string nome, string tipo, double[] oGRange, double[] fGRange, double[] aBVRange, double[] sRMRange, double[] iBURange)
        {
            Nome = nome;
            Tipo = tipo;
            OGRange = oGRange;
            FGRange = fGRange;
            ABVRange = aBVRange;
            SRMRange = sRMRange;
            IBURange = iBURange;
        }

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public double[] OGRange { get; set; }
        public double[] FGRange { get; set; }
        public double[] ABVRange { get; set; }
        public double[] SRMRange { get; set; }
        public double[] IBURange { get; set; }
    }
}
