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
        string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        public Form_edit_lupulo()
        {
            InitializeComponent();
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

        private void btn_add_lupulo_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = true;
            txt_alfa_acido.Enabled = true;
            comboBox_tipo.Enabled = true;
            btn_submeter.Enabled = true;

        }


        private void btn_del_lupulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_lupulo.SelectedItems[0] != null)
                {
                    DialogResult dialogResult = MessageBox.Show($"Deseja excluir o item {lv_lupulo.SelectedItems[0].SubItems[0].Text}?", "Excluir Item", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lupulosSelecionados.AddRange(lupuloLista);
                        bool found = false;
                        foreach (var item in lupulosSelecionados)
                        {
                            if (item.Nome == lv_lupulo.SelectedItems[0].SubItems[0].Text)
                            {
                                lupulosSelecionados.Remove(item);
                                found = true;
                                break;
                            }
                        }
                        if (found == true)
                        {
                            bool sucesso = HandleTxt.UpdateLupulos(lupulosSelecionados, filepathRaiz);
                            if (sucesso)
                            {
                                MessageBox.Show("Exclusão realizada com sucesso");
                                reload();
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nenhum Item Selecionado");
            }
        }

        private void btn_edit_lupulo_Click(object sender, EventArgs e)
        {
            txt_nome.Text = lv_lupulo.SelectedItems[0].Text;
            string selected = lv_lupulo.SelectedItems[0].SubItems[1].Text;

            //LAMBDA/LINQ
            List<TiposLupulos> lista = new();
            foreach (var item in comboBox_tipo.Items)
            {
                lista.Add((TiposLupulos)item);
            }
            comboBox_tipo.SelectedItem = lista.Find(c => c.ToString() == selected);

            txt_alfa_acido.Enabled = true;
        }

        private void btn_submeter_Click(object sender, EventArgs e)
        {
            Lupulo submit = new(txt_nome.Text, comboBox_tipo.SelectedItem.ToString(), double.Parse(txt_alfa_acido.Text), 0, 0);

            lupulosSelecionados.AddRange(lupuloLista);
            bool found = false;
            foreach (var item in lupulosSelecionados)
            {
                if (item.Nome == submit.Nome)
                {
                    item.Tipo = submit.Tipo;
                    item.AlfaAcido = submit.AlfaAcido;
                    found = true;
                    break;
                }
            }
            if (found == false) lupulosSelecionados.Add(submit);

            bool sucesso = HandleTxt.UpdateLupulos(lupulosSelecionados, filepathRaiz);
            if (sucesso)
            {
                MessageBox.Show("Submissão realizada com sucesso");
                reload();

            }
        }


        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void reload()
        {
            txt_nome.Enabled = false;
            txt_alfa_acido.Enabled = false;
            comboBox_tipo.Enabled = false;
            btn_submeter.Enabled = false;
            btn_edit_lupulo.Enabled = false;

            lv_lupulo.Items.Clear();
            lupuloLista.Clear();
            lupulosSelecionados.Clear();
            lupuloLista.AddRange(HandleTxt.loadLupulo(filepathRaiz));
            foreach (var item in lupuloLista)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.AlfaAcido.ToString() };
                lv_lupulo.Items.Add(new ListViewItem(itemLinha));
            }
        }

        private void comboBox_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lv_lupulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lv_lupulo_MouseClick(object sender, MouseEventArgs e)
        {
            btn_edit_lupulo.Enabled = true;
        }

        private void txt_alfa_acido_TextChanged(object sender, EventArgs e)
        {
            if (!txt_alfa_acido.Text.Contains(".") && !txt_alfa_acido.Text.Contains("-"))
            {
                double teste = 0;
                bool parseSucessoalfa_acido = double.TryParse(txt_alfa_acido.Text, out teste);

                txt_alfa_acido.ForeColor = (txt_alfa_acido.Text == "") ? Color.Red : Color.Black;
                txt_alfa_acido.ForeColor = (!parseSucessoalfa_acido) ? Color.Red : Color.Black;
                btn_submeter.Enabled = (txt_alfa_acido.ForeColor == Color.Red) ? false : true;
            }
            else
            {
                btn_submeter.Enabled = false;
                txt_alfa_acido.ForeColor = Color.Red;
            }
        }
    }
}
