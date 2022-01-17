using BrewHome.Classes.Insumos;
using BrewHome.Classes.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrewHome
{
    public partial class Form_edit_ferm : Form
    {

        List<Fermentavel> fermentaveisLista = new();
        List<Fermentavel> fermentaveisSelecionados = new();
        public Form_edit_ferm()
        {
            InitializeComponent();
        }


            private void btn_add_ferm_Click(object sender, EventArgs e)
        {



        }

        private void Form_edit_ferm_Load(object sender, EventArgs e)
        {
                lv_fermentaveis.Columns.Add("Nome", lv_fermentaveis.Width/4);
                lv_fermentaveis.Columns.Add("Tipo", lv_fermentaveis.Width / 4);
                lv_fermentaveis.Columns.Add("EBC", lv_fermentaveis.Width / 4);
                lv_fermentaveis.Columns.Add("Extrato", lv_fermentaveis.Width / 4);

                lv_fermentaveis.View = View.Details;
                lv_fermentaveis.GridLines = true; //mostra linha de grades
                lv_fermentaveis.FullRowSelect = true; //seleciona toda a linha qdo clica
                lv_fermentaveis.Sorting = SortOrder.Ascending; //ordena a lista pela primeira coluna

            string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            fermentaveisLista.AddRange(HandleTxt.loadFermentaveis(filepathRaiz));
            foreach (var item in fermentaveisLista)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.EBC.ToString(), item.Extrato.ToString() };
                lv_fermentaveis.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
            }


            comboBox_tipo.Items.Add(TiposFermentaveis.Base);
            comboBox_tipo.Items.Add(TiposFermentaveis.Especial);
            comboBox_tipo.Items.Add(TiposFermentaveis.Adjunto);
        }
    }
}
