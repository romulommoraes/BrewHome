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

        public string Tipo { get; set; }
        public double VolumeFinal { get; set; }

        public List<Fermentavel> Fermentaveis { get; set; }
        public List<Lupulo> Lupulos { get; set; }

        public Levedura Levedura { get; set; }

        public double OG { get; set; } //calcular com base nos fermentáveis e tempo de mosturação
        public double FG { get; set; } //calcular com base na atenuação da levedura
        public double COR { get; set; } //srm  ------ EBC (SRM*2)
        public double IBU { get; set; } //calcular com base nos lupulos
        public double ABV { get; set; } //calcular com base na OG/FG, e volume
        public double Calorias { get; set; }
        public double TempoMostura { get; set; }
        public List<double[]> RampasMostura { get; set; }
        public double[] Fermentacao { get; set; }
        public double[] Maturacao { get; set; }
        public double TempoFervura { get; set; }
        public string[] Dryhopping { get; set; }
        public string ComentariosMostura { get; set; }
        public string ComentariosFervura { get; set; }
        public string ComentariosFermMat { get; set; }


        public Receita()
        {
            Fermentaveis = new();
            Lupulos = new();
            RampasMostura = new();
            Fermentacao = new double[2];
            Maturacao = new double[2];
            Dryhopping = new string[3];
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
