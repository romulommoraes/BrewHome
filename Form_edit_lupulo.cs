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
    public partial class Form_edit_lupulo : Form
    {

        List<Lupulo> lupuloLista = new();
        List<Lupulo> lupulosSelecionados = new();
        public Form_edit_lupulo()
        {
            InitializeComponent();
        }

        private void comboBox_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lv_lupulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form_edit_lupulo_Load(object sender, EventArgs e)
        {
            lv_lupulo.Columns.Add("Nome", lv_lupulo.Width / 3);
            lv_lupulo.Columns.Add("Tipo", lv_lupulo.Width / 3);
            lv_lupulo.Columns.Add("AlfaAcido", lv_lupulo.Width / 3);

            lv_lupulo.View = View.Details;
            lv_lupulo.GridLines = true; //mostra linha de grades
            lv_lupulo.FullRowSelect = true; //seleciona toda a linha qdo clica
            lv_lupulo.Sorting = SortOrder.Ascending; //ordena a lista pela primeira coluna

            string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            lupuloLista.AddRange(HandleTxt.loadLupulo(filepathRaiz));
            foreach (var item in lupuloLista)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.AlfaAcido.ToString() };
                lv_lupulo.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
            }

            comboBox_tipo.Items.Add(TiposLupulos.Amargor);
            comboBox_tipo.Items.Add(TiposLupulos.Aroma);
            comboBox_tipo.Items.Add(TiposLupulos.Geral);
        }
    }
}
