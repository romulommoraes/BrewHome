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
        string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        public Form_edit_ferm()
        {
            InitializeComponent();
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



        private void btn_add_ferm_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = true;
            txt_EBC.Enabled = true;
            comboBox_tipo.Enabled = true;
            txt_extrato.Enabled = true;
            btn_submeter.Enabled = true;
        }
        private void btn_del_ferm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_fermentaveis.SelectedItems[0] != null)
                {
                    DialogResult dialogResult = MessageBox.Show($"Deseja excluir o item {lv_fermentaveis.SelectedItems[0].SubItems[0].Text}?", "Excluir Item", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        fermentaveisSelecionados.AddRange(fermentaveisLista);
                        bool found = false;
                        foreach (var item in fermentaveisSelecionados)
                        {
                            if (item.Nome == lv_fermentaveis.SelectedItems[0].SubItems[0].Text)
                            {
                                fermentaveisSelecionados.Remove(item);
                                found = true;
                                break;
                            }
                        }
                        if (found == true)
                        {
                            bool sucesso = HandleTxt.UpdateFermentaveis(fermentaveisSelecionados, filepathRaiz);
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

        private void btn_edit_fermentavel_Click(object sender, EventArgs e)
        {

            txt_nome.Text = lv_fermentaveis.SelectedItems[0].Text;
                      
            btn_submeter.Enabled = true;
            txt_nome.Text = lv_fermentaveis.SelectedItems[0].Text;
            string selected = lv_fermentaveis.SelectedItems[0].SubItems[1].Text;

            //LAMBDA/LINQ
            List<TiposFermentaveis> lista = new();
            foreach (var item in comboBox_tipo.Items)
            {
                lista.Add((TiposFermentaveis)item);
            }
            comboBox_tipo.SelectedItem = lista.Find(c => c.ToString() == selected);

            txt_EBC.Enabled = true;
            //comboBox_tipo.Enabled = true;
            txt_extrato.Enabled = true;
        }

        private void btn_submeter_Click(object sender, EventArgs e)
        {
            Fermentavel submit = new(txt_nome.Text, comboBox_tipo.SelectedItem.ToString(), double.Parse(txt_EBC.Text), double.Parse(txt_extrato.Text), 0);

            fermentaveisSelecionados.AddRange(fermentaveisLista);
            bool found = false;
            foreach (var item in fermentaveisSelecionados)
            {
                if (item.Nome == submit.Nome)
                {
                    item.Tipo = submit.Tipo;
                    item.EBC = submit.EBC;
                    item.Extrato = submit.Extrato;
                    found = true;
                    break;
                }
            }
            if (found == false) fermentaveisSelecionados.Add(submit);

            bool sucesso = HandleTxt.UpdateFermentaveis(fermentaveisSelecionados, filepathRaiz);
            if (sucesso)
            {
                MessageBox.Show("Submissão realizada com sucesso");
                reload();

            }
        }


        private void reload()
        {
            btn_edit_fermentavel.Enabled = false;
            txt_nome.Enabled = false;
            txt_EBC.Enabled = false;
            comboBox_tipo.Enabled = false;
            txt_extrato.Enabled = false;
            btn_submeter.Enabled = false;

            lv_fermentaveis.Items.Clear();
            fermentaveisLista.Clear();
            fermentaveisSelecionados.Clear();
            fermentaveisLista.AddRange(HandleTxt.loadFermentaveis(filepathRaiz));
            foreach (var item in fermentaveisLista)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.EBC.ToString(), item.Extrato.ToString() };
                lv_fermentaveis.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
            }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lv_fermentaveis_MouseClick(object sender, MouseEventArgs e)
        {
            btn_edit_fermentavel.Enabled = true;
        }

        private void txt_EBC_TextChanged(object sender, EventArgs e)
        {
            if (!txt_EBC.Text.Contains(".") && !txt_EBC.Text.Contains("-"))
            {
                double teste = 0;
                bool parseSucessoEBC = double.TryParse(txt_EBC.Text, out teste);
                bool parseSucessoExtrato = double.TryParse(txt_extrato.Text, out teste);

                txt_EBC.ForeColor = (txt_EBC.Text == "") ? Color.Red : Color.Black;
                txt_extrato.ForeColor = (txt_extrato.Text == "") ? Color.Red : Color.Black;
                txt_EBC.ForeColor = (!parseSucessoEBC) ? Color.Red : Color.Black;
                txt_extrato.ForeColor = (!parseSucessoExtrato) ? Color.Red : Color.Black;
                btn_submeter.Enabled = (txt_EBC.ForeColor == Color.Red || txt_extrato.ForeColor == Color.Red) ? false : true;
            }
            else
            {
                btn_submeter.Enabled = false;
                txt_EBC.ForeColor = Color.Red;
            }
        }

        private void txt_extrato_TextChanged(object sender, EventArgs e)
        {
            if (!txt_extrato.Text.Contains(".") && !txt_extrato.Text.Contains("-"))
            {
                double teste = 0;
                bool parseSucessoEBC = double.TryParse(txt_EBC.Text, out teste);
                bool parseSucessoExtrato = double.TryParse(txt_extrato.Text, out teste);

                txt_EBC.ForeColor = (txt_EBC.Text == "") ? Color.Red : Color.Black;
                txt_extrato.ForeColor = (txt_extrato.Text == "") ? Color.Red : Color.Black;
                txt_EBC.ForeColor = (!parseSucessoEBC) ? Color.Red : Color.Black;
                txt_extrato.ForeColor = (!parseSucessoExtrato) ? Color.Red : Color.Black;
                btn_submeter.Enabled = (txt_EBC.ForeColor == Color.Red || txt_extrato.ForeColor == Color.Red) ? false : true;
            }
            else
            {
                btn_submeter.Enabled = false;
                txt_extrato.ForeColor = Color.Red;
            }
        }
    }
}
