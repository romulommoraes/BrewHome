using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Windows.Forms;
using BrewHome.Classes.JSON;

namespace BrewHome.Classes.Services
{
    public static class HandleJson
    {

        public static void SaveJson(Receita receita, double tempofervura, double tempomostura)
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
            receitaToJSon.EBC = Math.Round(receita.COR*2, 1);
            receitaToJSon.TempoMostura = tempomostura; 
            receitaToJSon.TempoFervura = tempofervura;
            receitaToJSon.Levedura = receita.Levedura.Nome;

            foreach (var fermentavel in receita.Fermentaveis)
            {
               // MessageBox.Show(receita.Fermentaveis.Count.ToString());
                FermentavelToJson fJson = new(fermentavel.Nome, fermentavel.PesoKG);
                receitaToJSon.Fermentaveis.Add(fJson);
            }
            foreach (var lupulo in receita.Lupulos)
            {
                LupuloToJson lJson = new(lupulo.Nome, lupulo.PesoG, lupulo.TempoFervura);
                receitaToJSon.Lupulos.Add(lJson);
            }

            List<ReceitaToJSon> _receita = new ();
            _receita.Add(receitaToJSon);

            string json = JsonSerializer.Serialize(_receita);
            string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string fileBD = @$"{filepathRaiz}\Receitas\{receitaToJSon.Nome}.json";
            File.WriteAllText(fileBD, json);
            MessageBox.Show("Receita salva com sucesso");
        }

        public static ReceitaToJSon ReadJson()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";//só permite caregar json

            if (openFileDialog.ShowDialog() == DialogResult.OK) //se o usuario selecionou um arquivo e clickou em OK
            {
                String filepath = openFileDialog.FileName;

                string jsonString = File.ReadAllText(filepath);

                var receitaModels = JsonSerializer.Deserialize<List<ReceitaToJSon>>(jsonString);        

                ReceitaToJSon receita = receitaModels.First();
                return receita;
            }
            else
            {
                MessageBox.Show("Erro ao carregar arquivo");
                return null;
            }

                
        }

    }
}
