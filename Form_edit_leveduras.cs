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
    public partial class Form_edit_leveduras : Form
    {

        List<Levedura> leveduraLista = new();
        List<Levedura> leveduraSelecionados = new();
        string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        public Form_edit_leveduras()
        {
            InitializeComponent();
        }

        private void Form_edit_leveduras_Load(object sender, EventArgs e)
        {
            lv_levedura.Columns.Add("Nome", lv_levedura.Width/4);
            lv_levedura.Columns.Add("Tipo", lv_levedura.Width / 4);
            lv_levedura.Columns.Add("Atenuação", lv_levedura.Width / 4);
            lv_levedura.Columns.Add("Floculação", lv_levedura.Width / 4);

            lv_levedura.View = View.Details;
            lv_levedura.GridLines = true; //mostra linha de grades
            lv_levedura.FullRowSelect = true; //seleciona toda a linha qdo clica
            lv_levedura.Sorting = SortOrder.Ascending; //ordena a lista pela primeira coluna

            string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            leveduraLista.AddRange(HandleTxt.loadLevedura(filepathRaiz));
            foreach (var item in leveduraLista)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.Atenuacao.ToString(), item.Floculacao.ToString() };
                lv_levedura.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
            }

            comboBox_tipo.Items.Add(TiposLeveduras.Ale);
            comboBox_tipo.Items.Add(TiposLeveduras.Lager);
            comboBox_tipo.Items.Add(TiposLeveduras.Kveik);
            comboBox_tipo.Items.Add(TiposLeveduras.Saison);
        }

        private void btn_add_lev_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = true;
            txt_atenuacao.Enabled = true;
            comboBox_tipo.Enabled = true;
            txt_floculacao.Enabled = true;
            btn_submeter.Enabled = true;
        }

        private void btn_edit_levedura_Click(object sender, EventArgs e)
        {
            txt_nome.Text = lv_levedura.SelectedItems[0].Text;
            string selected = lv_levedura.SelectedItems[0].SubItems[1].Text;

            //LAMBDA OU LINQ
            List<TiposLeveduras> lista = new();
            foreach (var item in comboBox_tipo.Items)
            {
                lista.Add((TiposLeveduras)item);
            }
            comboBox_tipo.SelectedItem = lista.Find(c => c.ToString() == selected);
            
            // NORMAL
            
            //foreach (var item in comboBox_tipo.Items)
            //{
            //    if (selected == item.ToString())
            //    {
            //        comboBox_tipo.SelectedItem = item;
            //        break;
            //    }
            //}
            txt_atenuacao.Enabled = true;
            txt_floculacao.Enabled = true;
        }

        private void btn_del_lev_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_levedura.SelectedItems[0] != null)
                {
                    DialogResult dialogResult = MessageBox.Show($"Deseja excluir o item {lv_levedura.SelectedItems[0].SubItems[0].Text}?", "Excluir Item", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        leveduraSelecionados.AddRange(leveduraLista);
                        bool found = false;
                        foreach (var item in leveduraSelecionados)
                        {
                            if (item.Nome == lv_levedura.SelectedItems[0].SubItems[0].Text)
                            {
                                leveduraSelecionados.Remove(item);
                                found = true;
                                break;
                            }
                        }
                        if (found == true)
                        {
                            bool sucesso = HandleTxt.UpdateLeveduras(leveduraSelecionados, filepathRaiz);
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

        private void btn_submeter_Click(object sender, EventArgs e)
        {
            Levedura submit = new(txt_nome.Text, comboBox_tipo.SelectedItem.ToString(), double.Parse(txt_atenuacao.Text), txt_floculacao.Text);

            leveduraSelecionados.AddRange(leveduraLista);
            bool found = false;
            foreach (var item in leveduraSelecionados)
            {
                if (item.Nome == submit.Nome)
                {
                    item.Tipo = submit.Tipo;
                    item.Atenuacao = submit.Atenuacao;
                    item.Floculacao = submit.Floculacao;
                    found = true;
                    break;
                }
            }
            if (found == false) leveduraSelecionados.Add(submit);

            bool sucesso = HandleTxt.UpdateLeveduras(leveduraSelecionados, filepathRaiz);
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

        private void lv_levedura_MouseClick(object sender, MouseEventArgs e)
        {
            btn_edit_levedura.Enabled = true;
        }

        private void reload()
        {
            btn_edit_levedura.Enabled = false;
            txt_nome.Enabled = false;
            txt_atenuacao.Enabled = false;
            comboBox_tipo.Enabled = false;
            txt_floculacao.Enabled = false;
            btn_submeter.Enabled = false;

            lv_levedura.Items.Clear();
            leveduraLista.Clear();
            leveduraSelecionados.Clear();
            leveduraLista.AddRange(HandleTxt.loadLevedura(filepathRaiz));
            foreach (var item in leveduraLista)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.Atenuacao.ToString(), item.Floculacao.ToString() };
                lv_levedura.Items.Add(new ListViewItem(itemLinha));
            }
        }

        private void txt_atenuacao_TextChanged(object sender, EventArgs e)
        {
            if (!txt_atenuacao.Text.Contains(".") && !txt_atenuacao.Text.Contains("-"))
            {
                double teste = 0;
                bool parseSucessoAten = double.TryParse(txt_atenuacao.Text, out teste);
                bool parseSucessoFloc = double.TryParse(txt_floculacao.Text, out teste);

                txt_atenuacao.ForeColor = (txt_atenuacao.Text == "") ? Color.Red : Color.Black;
                txt_floculacao.ForeColor = (txt_floculacao.Text == "") ? Color.Red : Color.Black;
                txt_atenuacao.ForeColor = (!parseSucessoAten) ? Color.Red : Color.Black;
                txt_floculacao.ForeColor = (!parseSucessoFloc) ? Color.Red : Color.Black;
                btn_submeter.Enabled = (txt_atenuacao.ForeColor == Color.Red || txt_floculacao.ForeColor == Color.Red) ? false : true;
            }
            else
            {
                btn_submeter.Enabled = false;
                txt_atenuacao.ForeColor = Color.Red;
            }

        }

        private void txt_floculacao_TextChanged(object sender, EventArgs e)
        {
            if (!txt_floculacao.Text.Contains(".") && !txt_floculacao.Text.Contains("-"))
            {
                double teste = 0;
                bool parseSucessoAten = double.TryParse(txt_atenuacao.Text, out teste);
                bool parseSucessoFloc = double.TryParse(txt_floculacao.Text, out teste);

                txt_atenuacao.ForeColor = (txt_atenuacao.Text == "") ? Color.Red : Color.Black;
                txt_floculacao.ForeColor = (txt_floculacao.Text == "") ? Color.Red : Color.Black;
                txt_atenuacao.ForeColor = (!parseSucessoAten) ? Color.Red : Color.Black;
                txt_floculacao.ForeColor = (!parseSucessoFloc) ? Color.Red : Color.Black;
                btn_submeter.Enabled = (txt_atenuacao.ForeColor == Color.Red || txt_floculacao.ForeColor == Color.Red) ? false : true;
            }
            else
            {
                btn_submeter.Enabled = false;
                txt_floculacao.ForeColor = Color.Red;
            }
        }
    }
}
