using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Classes.Insumos
{
    public class Levedura
    {
        public Levedura(string nome, string tipo, double atenuacao, string floculacao)
        {
            Nome = nome;
            Tipo = tipo;
            Atenuacao = atenuacao;
            Floculacao = floculacao;
        }

        public string Nome { get; set; }
        public string Tipo { get; set; } //fazer enum  {lager, ale, kveik}
        public double Atenuacao { get; set; } 
        public string Floculacao { get; set; } //fazer enum  {baixa, media, alta}
    }
}
