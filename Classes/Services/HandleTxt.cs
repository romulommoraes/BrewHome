using BrewHome.Classes.Insumos;
using BrewHome.Classes.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrewHome.Classes.Services
{


    public static class HandleTxt
    {
        public static List<Fermentavel> loadFermentaveis(string filepathRaiz)
        {
            //string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string fileBD = @$"{filepathRaiz}\Dados\Fermentaveis.txt";
            String[] itens = File.ReadAllLines(fileBD);//separa todas as linhas do arquivo numa lista de strings
            List<Fermentavel> fermentaveisLoad = new();
            foreach (var item in itens)
            {
                string[] ferm = item.Split(";");
                Fermentavel fermentavel = new(ferm[0].ToString(), ferm[1].ToString(), double.Parse(ferm[2].ToString()), double.Parse(ferm[3].ToString()), 0);
                fermentaveisLoad.Add(fermentavel);
            }
            return fermentaveisLoad;
        }

        public static List<Lupulo> loadLupulo(string filepathRaiz)
        {
            string fileBD2 = @$"{filepathRaiz}\Dados\Lupulo.txt";
            String[] lupulos = File.ReadAllLines(fileBD2);
            List<Lupulo> lupulosLoad = new();
            foreach (var item in lupulos)
            {
                string[] lup = item.Split(";");
                Lupulo lupulo = new(lup[0].ToString(), lup[1].ToString(), double.Parse(lup[2].ToString()), 0, 0);

                lupulosLoad.Add(lupulo);
            }

            return lupulosLoad;
        }

        public static List<Levedura> loadLevedura(string filepathRaiz)
        {
            string fileBD3 = @$"{filepathRaiz}\Dados\Leveduras.txt";
            String[] leve = File.ReadAllLines(fileBD3);
            List<Levedura> levedurasLoad = new();

            foreach (var item in leve)
            {
                string[] lev = item.Split(";");
                Levedura levedura = new(lev[0].ToString(), lev[1].ToString(), double.Parse(lev[2].ToString()), lev[3].ToString());

                levedurasLoad.Add(levedura);
            }
            return levedurasLoad;
        }

        public static List<Estilo> loadEstilo(string filepathRaiz)
        {
            string fileBD4 = @$"{filepathRaiz}\Dados\Estilos.txt";
            String[] ItensEstilo = File.ReadAllLines(fileBD4);//separa todas as linhas do arquivo numa lista de strings
            List<Estilo> estilosLoad = new();

            foreach (var item in ItensEstilo)
            {
                string[] est = item.Split(";");
                string[] ograngeST = est[2].Split("-");
                double[] ogrange = new double[] { double.Parse(ograngeST[0]), double.Parse(ograngeST[1]) };
                string[] fgrangeST = est[3].Split("-");
                double[] fgrange = new double[] { double.Parse(fgrangeST[0]), double.Parse(fgrangeST[1]) };
                string[] ABVrangeST = est[4].Split("-");
                double[] ABVrange = new double[] { double.Parse(ABVrangeST[0]), double.Parse(ABVrangeST[1]) };
                string[] SRMrangeST = est[5].Split("-");
                double[] SRMrange = new double[] { double.Parse(SRMrangeST[0]), double.Parse(SRMrangeST[1]) };
                string[] IBUrangeST = est[6].Split("-");
                double[] IBUrange = new double[] { double.Parse(IBUrangeST[0]), double.Parse(IBUrangeST[1]) };

                Estilo estilo = new(est[0].ToString(), est[1].ToString(), ogrange, fgrange, ABVrange, SRMrange, IBUrange);

                estilosLoad.Add(estilo);
            }
            return estilosLoad;
        }


        public static void ExportTXT(Receita receita, double tempofervura, double tempomostura)
        {
            ReceitaToJSon receitaToJSon = new();
            receitaToJSon.Nome = receita.Nome;
            receitaToJSon.Estilo = receita.Estilo;
            receitaToJSon.VolumeFinal = receita.VolumeFinal;
            receitaToJSon.ABV = Math.Round(receita.ABV, 1);
            receitaToJSon.OG = Math.Round(receita.OG, 1);
            receitaToJSon.FG = Math.Round(receita.FG, 1);
            receitaToJSon.IBU = Math.Round(receita.IBU, 1);
            receitaToJSon.SRM = Math.Round(receita.COR, 1);
            receitaToJSon.Calorias = Math.Round(receita.Calorias, 1);
            receitaToJSon.EBC = Math.Round(receita.COR * 2, 1);
            receitaToJSon.TempoMostura = tempomostura;
            receitaToJSon.TempoFervura = tempofervura;

            receitaToJSon.Maturacao = receita.Maturacao;
            receitaToJSon.Fermentacao = receita.Fermentacao;

            receitaToJSon.Dryhopping = receita.Dryhopping;

            receitaToJSon.ComentariosMostura = receita.ComentariosMostura;
            receitaToJSon.ComentariosFervura = receita.ComentariosFervura;
            receitaToJSon.ComentariosFermMat = receita.ComentariosFermMat;

            receitaToJSon.Levedura = receita.Levedura.Nome;
            if (receitaToJSon.RampasMostura != null)
            {
                receitaToJSon.RampasMostura.Clear();
            }
            receitaToJSon.RampasMostura.AddRange(receita.RampasMostura);

            foreach (var fermentavel in receita.Fermentaveis)
            {
                FermentavelToJson fJson = new(fermentavel.Nome, fermentavel.PesoKG);
                receitaToJSon.Fermentaveis.Add(fJson);
            }
            foreach (var lupulo in receita.Lupulos)
            {
                LupuloToJson lJson = new(lupulo.Nome, lupulo.PesoG, lupulo.TempoFervura);
                receitaToJSon.Lupulos.Add(lJson);
            }

            string separador = "*******************************************************";
            string head = $"Receita: {receitaToJSon.Nome} \n Estilo: {receitaToJSon.Estilo}";
            string Estatisticas = $"Volume: {receitaToJSon.VolumeFinal}(L) " +
                $"\n OG: {receitaToJSon.OG}" +
                $"\n FG: {receitaToJSon.FG}" +
                $"\n ABV: {receitaToJSon.ABV}" +
                $"\n SRM: {receitaToJSon.SRM}" +
                $"\n EBC: {receitaToJSon.EBC}" +
                $"\n IBU: {receitaToJSon.IBU}";
            string fermentaveis = "Fermentáveis:";
            foreach (var item in receitaToJSon.Fermentaveis)
            {
                fermentaveis += $"\n {item.Nome}: {item.Peso}(KG)";
            }
            string lupulos = "Lúpulos:";
            foreach (var item in receitaToJSon.Lupulos)
            {
                lupulos += $"\n {item.Nome}: {item.Peso}(g)";
            }
            string rampas = receitaToJSon.ExportRampas();
            string dryhopping = (receitaToJSon.Dryhopping[0] != "") ? $"{receitaToJSon.Dryhopping[0]}, { receitaToJSon.Dryhopping[1]}g, { receitaToJSon.Dryhopping[2]}(Dias)" : "-";
            string levedura = $"Levedura:\n {receitaToJSon.Levedura}";
            string etapas = $"Mosturacao: {receitaToJSon.TempoMostura}(Min) " +
                $"\n Rampas:" +
                $"\n{rampas} " +
                $"\n Comentários: {receitaToJSon.ComentariosMostura} " +
                $"\n\n Fervura: {receitaToJSon.TempoFervura}(Min)" +
                $"\n Comentários: {receitaToJSon.ComentariosFervura} " +
                $"\n\n Tempo de Fermentação: {receitaToJSon.Fermentacao[1]}(Dias)" +
                $"\n Temperatura de Fermentação: {receitaToJSon.Fermentacao[0]}°C" +
                $"\n\n Tempo de Maturação: {receitaToJSon.Maturacao[1]}(Dias)" +
                $"\n Temperatura de Maturação:{receitaToJSon.Maturacao[0]}°C" +
                $"\n\n DryHopping: {dryhopping}" +
                $"\n\n Comentários: {receitaToJSon.ComentariosFermMat}";
                
            string header = "************* RECEITA GERADA POR BREWHOME *************";
            string footer = $"***************** {DateTime.Now} *****************";
            string export = "";

            export += $"\n {separador}";
            export += $"\n {header}";
            export += $"\n {separador}";
            export += $"\n \n";
            export += $"\n {head}";
            export += $"\n \n {Estatisticas}";
            export += $"\n \n {fermentaveis}";
            export += $"\n \n {lupulos}";
            export += $"\n \n {levedura}";
            export += $"\n \n {etapas}";
            export += $"\n \n";
            export += $"\n {separador}";
            export += $"\n {footer}";
            export += $"\n {separador}";



            string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string fileBD = @$"{filepathRaiz}\Receitas\{receitaToJSon.Nome}.txt";
            File.WriteAllText(fileBD, export);
            //MessageBox.Show("Receita salva com sucesso");
        }

        public static bool UpdateFermentaveis(List<Fermentavel> lista, string filepathRaiz)
        {
            try
            {
                List<string> outputTxt = new List<string>();
                foreach (var item in lista)
                {
                    outputTxt.Add(item.ToTxt());
                }

                string fileFerm = @$"{filepathRaiz}\Dados\Fermentaveis.txt";
                File.WriteAllLines(fileFerm, outputTxt);
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }

        public static bool UpdateLupulos(List<Lupulo> lista, string filepathRaiz)
        {
            try
            {
                List<string> outputTxt = new List<string>();
                foreach (var item in lista)
                {
                    outputTxt.Add(item.ToTxt());
                }

                string fileFerm = @$"{filepathRaiz}\Dados\Lupulo.txt";
                File.WriteAllLines(fileFerm, outputTxt);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdateLeveduras(List<Levedura> lista, string filepathRaiz)
        {
            try
            {
                List<string> outputTxt = new List<string>();
                foreach (var item in lista)
                {
                    outputTxt.Add(item.ToTxt());
                }

                string fileFerm = @$"{filepathRaiz}\Dados\Leveduras.txt";
                File.WriteAllLines(fileFerm, outputTxt);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
