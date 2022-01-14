using BrewHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrewHome.Classes.Insumos;

namespace BrewHome.Classes
{
    public class Receita
    {
        public string Nome { get;  set; }

        public string Estilo { get; set; } 
        public double VolumeFinal { get; set; }

        public List<Fermentavel> Fermentaveis { get; set; }
        public List<Lupulo> Lupulos { get; set; }

        public Levedura Levedura { get; set; }
        public double TempoMostura{ get; set; }
        public double TempoFervura { get; set; }
        public double OG { get; set; } //calcular com base nos fermentáveis e tempo de mosturação
        public double FG { get; set; } //calcular com base na atenuação da levedura
        public double COR { get; set; } //EBC (SRM*2)
        public double IBU { get; set; } //calcular com base nos lupulos
        public double ABV { get; set; } //calcular com base na OG/FG, e volume


        public Receita()
        {
            Fermentaveis = new();
            Lupulos = new();
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetVolume(double volume)
        {
            VolumeFinal = volume;
        }

        public void AddFermentaveis(Fermentavel ferm)
        {
            try
            {
                Fermentaveis.Add(ferm);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro");
            }
           
        }
        public void AddLupulo(Lupulo lup)
        {

            try
            {
                Lupulos.Add(lup);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro");
            }
        }
        public void SetLevedura(Levedura lev)
        {
            try
            {
                Levedura = lev;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro");
            }
        }

    }


}
