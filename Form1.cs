using BrewHome.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BrewHome.Classes.JSON;
using BrewHome.Classes.Insumos;
using BrewHome.Classes.Services;

namespace BrewHome
{


    public partial class Form1 : Form
    {

        List<Fermentavel> fermentaveisLista = new();
        List<Fermentavel> fermentaveisSelecionados = new();
        List<Fermentavel> fermentaveisMosto = new();

        List<Lupulo> lupuloLista = new();
        List<Lupulo> lupuloSelecionados = new();
        List<Lupulo> lupuloMosto = new();

        List<Levedura> leveduraLista = new();
        List<Levedura> leveduraSelecionados = new();
        List<Levedura> leveduraMosto = new();

        List<Estilo> estilosLista = new();

        string FermentavelSelecionado = "";
        string LupuloSelecionado = "";
        float eficiencia;

        Receita receita = new();

        public Form1()
        {
            InitializeComponent();
           
        }

        private void btn_CalcOG_Click(object sender, EventArgs e) //salvar receita (mudar isso)
        {
            if (receita.Nome != null && receita.Nome != "")
            {
                DialogResult dialogResult = MessageBox.Show($"Deseja salvar a receita {receita.Nome}?", "Salvar Receita", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    receita.SetNome(txt_Nome.Text);
                    //SALVA RAMPAS
                    List<double[]> rampas = new();
                    double[] r1 = new double []{ double.Parse(txt_rampa_tempT1.Text), double.Parse(txt_rampa_min_T1.Text)  };
                    rampas.Add(r1);
                    if (txt_rampa_tempT2.Enabled) 
                    {
                        double[] r2 = new double[] { double.Parse(txt_rampa_tempT2.Text), double.Parse(txt_rampa_min_T2.Text) };
                        rampas.Add(r2);
                    }
                    if (txt_rampa_tempT3.Enabled)
                    {
                        double[] r3 = new double[] { double.Parse(txt_rampa_tempT3.Text), double.Parse(txt_rampa_min_T3.Text) };
                        rampas.Add(r3);
                    }
                    if (txt_rampa_tempT4.Enabled)
                    {
                        double[] r4 = new double[] { double.Parse(txt_rampa_tempT4.Text), double.Parse(txt_rampa_min_T4.Text) };
                        rampas.Add(r4);
                    }
                    if (receita.RampasMostura != null)
                    {
                        receita.RampasMostura.Clear();
                    }
                    receita.RampasMostura.AddRange(rampas);


                    //REVER ESSA GAMBIARRA DO DEMONIO
                    try
                    {
                        //SALVA MATURAÇÃO
                        receita.Maturacao[0] = double.Parse(txt_matura_temp.Text);
                        receita.Maturacao[1] = double.Parse(txt_tempo_maturacao.Text);

                        //SALVA FERMENTAÇÃO
                        receita.Fermentacao[0] = double.Parse(txt_temp_ferm.Text);
                        receita.Fermentacao[1] = double.Parse(Txt_TempoFermentacao.Text);
                    }
                    catch (Exception)
                    {
                    }

                    if (checkBox_dryhopping.Enabled)
                    {
                        receita.Dryhopping[0] = (comboBox_dryhopping.SelectedItem != null) ? comboBox_dryhopping.SelectedItem.ToString() : "";
                        receita.Dryhopping[1] = textBox_DH_peso.Text;
                        receita.Dryhopping[2] = textBox_DH_dias.Text;
                    }
                    else
                    {
                        receita.Dryhopping[0] = "";
                        receita.Dryhopping[1] = "";
                        receita.Dryhopping[2] = "";
                    }

                    receita.ComentariosMostura = richText_com_mostura.Text;
                    receita.ComentariosFervura = richText_com_ferv.Text;
                    receita.ComentariosFermMat = richText_coment_ferm.Text;

                    HandleJson.SaveJson(receita, double.Parse(txt_TempoMostura.Text), double.Parse(txt_FervuraMosto.Text));
                    HandleTxt.ExportTXT(receita, double.Parse(txt_TempoMostura.Text), double.Parse(txt_FervuraMosto.Text));
                    receita.Lupulos.Clear();
                    receita.Fermentaveis.Clear();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                MessageBox.Show("Adicione um nome para a receita antes de salvar");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Receita receita = new();
            receita.SetVolume(10);
            lv_fermentaveis.Columns.Add("Nome", 160);
            lv_fermentaveis.Columns.Add("Tipo", 60);
            lv_fermentaveis.Columns.Add("EBC", 60);
            lv_fermentaveis.Columns.Add("Extrato", 60);

            lv_fermentaveis.View = View.Details;
            lv_fermentaveis.GridLines = true; //mostra linha de grades
            lv_fermentaveis.FullRowSelect = true; //seleciona toda a linha qdo clica
            lv_fermentaveis.Sorting = SortOrder.Ascending; //ordena a lista pela primeira coluna

            lv_selecionados.Columns.Add("Nome", 100);
            lv_selecionados.Columns.Add("Tipo", 60);
            lv_selecionados.Columns.Add("SRM", 50);
            lv_selecionados.Columns.Add("Extrato", 50);
            lv_selecionados.Columns.Add("Peso", 50);
            lv_selecionados.Columns.Add("%", 50);


            lv_selecionados.View = View.Details;
            lv_selecionados.GridLines = true; //mostra linha de grades
            lv_selecionados.FullRowSelect = true; //seleciona toda a linha qdo clica
            lv_selecionados.Sorting = SortOrder.Ascending; //ordena a lista pela primeira coluna
            

            lv_lupulos.Columns.Add("Nome", lv_lupulos.Width/2);
            lv_lupulos.Columns.Add("Tipo", lv_lupulos.Width / 4);
            lv_lupulos.Columns.Add("AlfaAcido", (lv_lupulos.Width / 4)-5);

            lv_lupulos.View = View.Details;
            lv_lupulos.GridLines = true; //mostra linha de grades
            lv_lupulos.FullRowSelect = true; //seleciona toda a linha qdo clica
            lv_lupulos.Sorting = SortOrder.Ascending; //ordena a lista pela primeira coluna

            lv_lpselecionados.Columns.Add("Nome", 70);
            lv_lpselecionados.Columns.Add("Tipo", 65);
            lv_lpselecionados.Columns.Add("Tempo Fervura", 100);
            lv_lpselecionados.Columns.Add("Peso", 45);
            lv_lpselecionados.Columns.Add("AlfaAcido", 80);

            lv_lpselecionados.View = View.Details;
            lv_lpselecionados.GridLines = true; //mostra linha de grades
            lv_lpselecionados.FullRowSelect = true; //seleciona toda a linha qdo clica
            lv_lpselecionados.Sorting = SortOrder.Ascending; //ordena a lista pela primeira coluna


            lv_levedura.Columns.Add("Nome", 150);
            lv_levedura.Columns.Add("Tipo", 50);
            lv_levedura.Columns.Add("Atenuação", 70);
            lv_levedura.Columns.Add("Floculação", 70);

            lv_levedura.View = View.Details;
            lv_levedura.GridLines = true; //mostra linha de grades
            lv_levedura.FullRowSelect = true; //seleciona toda a linha qdo clica
            lv_levedura.Sorting = SortOrder.Ascending; //ordena a lista pela primeira coluna

            lv_levedura_sl.Columns.Add("Nome", 150);
            lv_levedura_sl.Columns.Add("Tipo", 50);
            lv_levedura_sl.Columns.Add("Atenuação", 70);
            lv_levedura_sl.Columns.Add("Floculação", 70);

            lv_levedura_sl.View = View.Details;
            lv_levedura_sl.GridLines = true; //mostra linha de grades
            lv_levedura_sl.FullRowSelect = true; //seleciona toda a linha qdo clica
            lv_levedura_sl.Sorting = SortOrder.Ascending; //ordena a lista pela primeira coluna


            string filepathRaiz = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            fermentaveisLista.AddRange(HandleTxt.loadFermentaveis(filepathRaiz));
            foreach (var item in fermentaveisLista)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.EBC.ToString(), item.Extrato.ToString() };
                lv_fermentaveis.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
            }

            lupuloLista.AddRange(HandleTxt.loadLupulo(filepathRaiz));
            foreach (var item in lupuloLista)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.AlfaAcido.ToString() };
                lv_lupulos.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
            }

            leveduraLista.AddRange(HandleTxt.loadLevedura(filepathRaiz));
            foreach (var item in leveduraLista)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.Atenuacao.ToString(), item.Floculacao.ToString() };
                lv_levedura.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
            }

            estilosLista.AddRange(HandleTxt.loadEstilo(filepathRaiz));
            foreach (var item in estilosLista)
            {
                comboBox1.Items.Add(item.Nome);
            }

            //estilosLista.AddRange(HandleTxt.loadEstilo(filepathRaiz));
            foreach (var item in lupuloLista)
            {
                comboBox_dryhopping.Items.Add(item.Nome);
            }

            txt_rampa_min_T1.Text = txt_TempoMostura.Text;
        }

        private void btn_addFerm_Click(object sender, EventArgs e)
        {
            fermentaveisSelecionados.Clear();
            try
            {
                string selectedNome = lv_fermentaveis.SelectedItems[0].SubItems[0].Text;
                string selectedTipo = lv_fermentaveis.SelectedItems[0].SubItems[1].Text;
                string selectedSRM = lv_fermentaveis.SelectedItems[0].SubItems[2].Text;
                string selectedExtrato = lv_fermentaveis.SelectedItems[0].SubItems[3].Text;


                
                Fermentavel selected = new(selectedNome, selectedTipo, double.Parse(selectedSRM), double.Parse(selectedExtrato), double.Parse(txt_PesoKG.Text));


                if (fermentaveisMosto.Count > 0)
                {
                    bool contem = false;
                    foreach (var ferm in fermentaveisMosto)
                    {
                        if (ferm.Nome.Equals(selectedNome))
                        {
                            ferm.PesoKG += double.Parse(txt_PesoKG.Text);

                            contem = true;
                            break;
                        }
                    }
                    if (contem == false)
                    {
                        fermentaveisSelecionados.Add(selected);
                        fermentaveisMosto.AddRange(fermentaveisSelecionados);
                        calcPesoPercentmaltes();
                    }
                }
                else
                {
                    fermentaveisSelecionados.Add(selected);
                    fermentaveisMosto.AddRange(fermentaveisSelecionados);
                    calcPesoPercentmaltes();
                }
                lv_selecionados.Items.Clear();
                Loadlv_selecionados();
            }
            catch (Exception)
            {
                if (receita.Estilo == null || receita.Estilo == "")
                {
                    //MessageBox.Show("Nenhum estilo selecionado");
                }
                else
                {
                    MessageBox.Show("Nenhum fermentavel selecionado");
                }                        
            }           
        }


        private double calcTotalPesomaltes()
        {
            double totalPeso = 0;
            if (fermentaveisMosto.Count > 0)
            {
              
                foreach (var item in fermentaveisMosto)
                {
                    totalPeso += item.PesoKG;   
                    
                }
                return totalPeso;
            }
            return 0;
        }

        private void calcPesoPercentmaltes()
        {
                double selectedPorcent;
                foreach (var item in fermentaveisMosto)
                {
                    selectedPorcent = (item.PesoKG / calcTotalPesomaltes()) * 100;
                    item.pesoPorcent = Math.Round(selectedPorcent, 1);
                }
        }



        private void btn_rmvFermento_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < fermentaveisMosto.Count; i++)
            {
                try
                {
                    if (fermentaveisMosto[i].Nome.Equals(lv_selecionados.SelectedItems[0].SubItems[0].Text))
                    {

                        fermentaveisMosto.Remove(fermentaveisMosto[i]);
                        Loadlv_selecionados();
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("nenhum item selecionado");            
                }
            }
        }


        private void Loadlv_selecionados()
        {
            lv_selecionados.Items.Clear();
            receita.Fermentaveis.Clear();

            foreach (var item in fermentaveisMosto)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.EBC.ToString(), item.Extrato.ToString(), item.PesoKG.ToString(), item.pesoPorcent.ToString() };
                lv_selecionados.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
                
                receita.AddFermentaveis(item);
            }
            CalcProp();
        }

        private void Loadlv_lp_selecionados()
        {

            lv_lpselecionados.Items.Clear();
            receita.Lupulos.Clear();

            foreach (var item in lupuloMosto)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.TempoFervura.ToString(), item.PesoG.ToString(), item.AlfaAcido.ToString() };
                lv_lpselecionados.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
                receita.AddLupulo(item);
            }
            CalcProp();
        }

        private void Loadlv_lev_selecionados()
        {
            lv_levedura_sl.Items.Clear();
            //receita.Levedura.Clear();


            foreach (var item in leveduraMosto)
            {
                String[] itemLinha = new string[] { item.Nome, item.Tipo, item.Atenuacao.ToString(), item.Floculacao.ToString()};
                lv_levedura_sl.Items.Add(new ListViewItem(itemLinha));//o list view item requer um array como parametro, no caso tem que criar ele pra poder adicionar ao list view
                receita.Levedura = item;
            }
            CalcProp();
        }

        private void CalcProp()
        {
            if (receita.VolumeFinal == 0)
            {
                receita.VolumeFinal = 10;
            }
            else
            {
                txtVolume.Text = receita.VolumeFinal.ToString();
            }
            calcPesoPercentmaltes();

            eficiencia = float.Parse(txt_eficiencia.Text)/100;            

            CalculadorPropriedades calc = new(receita);
            calc.CalcularPropriedades(eficiencia);
            calc.CalcularIBU();


            lbl_og.Text = calc.Receita.OG.ToString();
            lbl_ibu.Text = calc.Receita.IBU.ToString();

            if (calc.Receita.Levedura != null)
            {
                calc.CalcularABV();
                lbl_abv.Text = calc.Receita.ABV.ToString();
                lbl_fg.Text = calc.Receita.FG.ToString();
            }
            
                lbl_srm.Text = receita.COR.ToString();
                lbl_ebc.Text = Math.Round(receita.COR * 2, 1).ToString();


            if (receita.Estilo != null)
            {
                string[] OGRange = lbl_ogrange.Text.Split("-");
                if (receita.OG < double.Parse(OGRange[0]) || receita.OG > double.Parse(OGRange[1]))
                {
                    lbl_ogrange.ForeColor = Color.Red;
                }
                else
                {
                    lbl_ogrange.ForeColor = Color.Green;
                }

                string[] FGRange = lbl_fgrange.Text.Split("-");
                if (receita.FG < double.Parse(FGRange[0]) || receita.FG > double.Parse(FGRange[1]))
                {
                    lbl_fgrange.ForeColor = Color.Red;
                }
                else
                {
                    lbl_fgrange.ForeColor = Color.Green;
                }

                string[] ABVRange = lbl_abvrange.Text.Split("-");
                if (receita.ABV < double.Parse(ABVRange[0]) || receita.ABV > double.Parse(ABVRange[1]))
                {
                    lbl_abvrange.ForeColor = Color.Red;
                }
                else
                {
                    lbl_abvrange.ForeColor = Color.Green;
                }

                string[] EBCRange = lbl_ebcrange.Text.Split("-");
                if (Math.Round(receita.COR * 2, 1) < double.Parse(EBCRange[0]) || Math.Round(receita.COR * 2, 1) > double.Parse(EBCRange[1]))
                {
                    lbl_ebcrange.ForeColor = Color.Red;
                    lbl_srmrange.ForeColor = Color.Red;
                }
                else
                {
                    lbl_ebcrange.ForeColor = Color.Green;
                    lbl_srmrange.ForeColor = Color.Green;
                }

                string[] IBURange = lbl_iburange.Text.Split("-");
                if (receita.IBU < double.Parse(IBURange[0]) || receita.IBU > double.Parse(IBURange[1]))
                {
                    lbl_iburange.ForeColor = Color.Red;
                }
                else
                {
                    lbl_iburange.ForeColor = Color.Green;
                }


                //calorias
                calc.CalcularCalorias();
                lbl_kcal.Text = receita.Calorias.ToString();
            }


            if (txt_rampa_min_T2.Enabled !=true)
            {
                txt_rampa_min_T1.Text = txt_TempoMostura.Text;
            }

            double tb = Math.Round(receita.COR*10);
            //adaptação dos valores pro trackbar
            if (tb > 400) {tb = 400;} //acima de 40 é tudo preto
            
            //inverte os valores
            tb = tb - 400;
            if (tb < 0)
            {
                tb *= -1;
            }
            trackBar1.Value = (int)tb;

         

        }




        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void add_lupulo_Click(object sender, EventArgs e)
        {
            lupuloSelecionados.Clear();
            try
            {
                string selectedNome = lv_lupulos.SelectedItems[0].SubItems[0].Text;
                string selectedTipo = lv_lupulos.SelectedItems[0].SubItems[1].Text;
                string selectedAlfa = lv_lupulos.SelectedItems[0].SubItems[2].Text;
                Lupulo selected = new(selectedNome, selectedTipo, double.Parse(selectedAlfa), double.Parse(txt_peso_g.Text), double.Parse(txt_tempo_fervura.Text));

                if (lupuloMosto.Count > 0)
                {
                    bool contem = false;
                    foreach (var lup in lupuloMosto)
                    {
                        if (lup.Nome.Equals(selectedNome))
                        {
                            lup.PesoG += double.Parse(txt_peso_g.Text);
                            contem = true;
                            break;
                        }
                    }
                    if (contem == false)
                    {
                        lupuloSelecionados.Add(selected);
                        lupuloMosto.AddRange(lupuloSelecionados);
                    }
                }
                else
                {
                    lupuloSelecionados.Add(selected);
                    lupuloMosto.AddRange(lupuloSelecionados);
                }
                lv_lpselecionados.Items.Clear();
                Loadlv_lp_selecionados();
            }
            catch (Exception)
            {
                if (receita.Estilo == null || receita.Estilo == "")
                {
                    //MessageBox.Show("Nenhum estilo selecionado");
                }
                else
                {
                    MessageBox.Show("Nenhum Lupulo selecionado");
                }                
            }
        }

        private void btn_removerLup_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lupuloMosto.Count; i++)
            {
                try
                {
                    if (lupuloMosto[i].Nome.Equals(lv_lpselecionados.SelectedItems[0].SubItems[0].Text))
                    {
                        lupuloMosto.Remove(lupuloMosto[i]);
                        Loadlv_lp_selecionados();
                        return;
                    }
                }
                catch (Exception)
                {                    
                    MessageBox.Show("nenhum item selecionado");
                }
            }
        }

        private void btn_add_lev_Click(object sender, EventArgs e)
        {
            leveduraSelecionados.Clear();
            leveduraMosto.Clear();
            
            string selectedNome = lv_levedura.SelectedItems[0].SubItems[0].Text;
            string selectedTipo = lv_levedura.SelectedItems[0].SubItems[1].Text;
            string selectedAtenuacao = lv_levedura.SelectedItems[0].SubItems[2].Text;
            string selectedFloculacao = lv_levedura.SelectedItems[0].SubItems[3].Text;

            Levedura selected = new(selectedNome, selectedTipo, double.Parse(selectedAtenuacao), selectedFloculacao);

            if (leveduraMosto.Count > 0)
            {
                bool contem = false;
                foreach (var lev in leveduraMosto)
                {
                    if (lev.Nome.Equals(selectedNome))
                    {
                        MessageBox.Show("Levedura já selecionada");
                        break;
                    }
                }
                if (contem == false)
                {
                    leveduraSelecionados.Add(selected);
                    leveduraMosto.AddRange(leveduraSelecionados);
                }
            }
            else
            {
                leveduraSelecionados.Add(selected);
                leveduraMosto.AddRange(leveduraSelecionados);
            }
            lv_levedura_sl.Items.Clear();
            Loadlv_lev_selecionados();
            CalcProp();
        }

        private void txtVolume_TextChanged(object sender, EventArgs e)
        {            
            try
            {
                if (checkBox_escala.Checked)
                {
                    double volumePrevio = receita.VolumeFinal;
                    double volumeNovo = double.Parse(txtVolume.Text);
                    double razaoEscala = volumeNovo / volumePrevio;

                    foreach (var item in fermentaveisMosto)
                    {
                        item.PesoKG = Math.Round(razaoEscala * item.PesoKG, 1);
                    }
                    foreach (var item in lupuloMosto)
                    {
                        item.PesoG = Math.Round(razaoEscala * item.PesoG, 1);
                    }

                    receita.SetVolume(volumeNovo);
                    Loadlv_selecionados();
                    Loadlv_lp_selecionados();
                    CalcProp();
                }
                else
                {
                    double volumeNovo = double.Parse(txtVolume.Text);
                    receita.SetVolume(volumeNovo);
                    CalcProp();
                }
            }
            catch (Exception)
            {
                if (txtVolume.Text != "")
                {
                    MessageBox.Show("Volume inválido");
                }                
            }
        }

        
        private void txt_PesoKG_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (receita.Fermentaveis.Count > 0)
                {                    
                    foreach (var item in receita.Fermentaveis)
                    {
                        if (item.Nome.Equals(FermentavelSelecionado) && FermentavelSelecionado != "")
                        {
                            item.PesoKG = (double.Parse(txt_PesoKG.Text));
                            CalcProp();
                            Loadlv_selecionados();
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (txt_PesoKG.Text != "")
                {
                    MessageBox.Show("Peso inválido");
                }

            }
        }
        private void txt_peso_g_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (receita.Lupulos.Count > 0)
                {
                    foreach (var item in receita.Lupulos)
                    {
                        if (item.Nome.Equals(LupuloSelecionado) && LupuloSelecionado != "")
                        {
                            item.PesoG = (double.Parse(txt_peso_g.Text));
                            CalcProp();
                            Loadlv_lp_selecionados();
                            break;
                        }

                    }
                }
            }
            catch (Exception)
            {
                if (txt_peso_g.Text != "")
                {
                    MessageBox.Show("Peso inválido");
                }
            }
        }

        private void txt_tempo_fervura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (receita.Lupulos.Count > 0)
                {
                    foreach (var item in receita.Lupulos)
                    {
                        if (item.Nome.Equals(LupuloSelecionado) && LupuloSelecionado != "")
                        {
                            item.TempoFervura = (double.Parse(txt_tempo_fervura.Text));
                            CalcProp();
                            Loadlv_lp_selecionados();
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (txt_tempo_fervura.Text != "")
                {
                    MessageBox.Show("Duração inválida");
                }
            }
        }

        private void lv_selecionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FermentavelSelecionado = lv_selecionados.SelectedItems[0].SubItems[0].Text;
            }
            catch (Exception)
            {
                

            }
        }
        private void lv_lpselecionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LupuloSelecionado = lv_lpselecionados.SelectedItems[0].SubItems[0].Text;
            }
            catch (Exception)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indice = comboBox1.SelectedItem.ToString();
            foreach (var item in estilosLista)
            {
                if (indice == item.Nome)
                {                  
                    lbl_ogrange.Text = $"{item.OGRange[0]}-{item.OGRange[1]}";                                      
                    lbl_fgrange.Text = $"{item.FGRange[0]}-{item.FGRange[1]}";                                                          
                    lbl_abvrange.Text = $"{item.ABVRange[0]}-{item.ABVRange[1]}";                                       
                    lbl_srmrange.Text = $"{item.SRMRange[0]}-{item.SRMRange[1]}";                    
                    lbl_ebcrange.Text = $"{item.SRMRange[0]*2}-{item.SRMRange[1] * 2}";                   
                    lbl_iburange.Text = $"{item.IBURange[0]}-{item.IBURange[1]}";
                    receita.Estilo = indice;                    
                }
            }
            CalcProp();
        }

        private void lv_fermentaveis_SelectedIndexChanged(object sender, EventArgs e)
        {
            FermentavelSelecionado = "";            
        }

        private void lv_lupulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            LupuloSelecionado = "";
        }

        private void btn_load_receita_Click(object sender, EventArgs e)
        {
            ReceitaToJSon receitaLoad = HandleJson.ReadJson();
            if (receitaLoad != null)
            {
                receita.Nome = receitaLoad.Nome;
                receita.Estilo = receitaLoad.Estilo;
                receita.VolumeFinal = receitaLoad.VolumeFinal;
                receita.TempoMostura = receitaLoad.TempoMostura;
                receita.TempoFervura = receitaLoad.TempoFervura;
                receita.Fermentacao = receitaLoad.Fermentacao;
                receita.Maturacao = receitaLoad.Maturacao;
                receita.Dryhopping = receitaLoad.Dryhopping;

                receita.ComentariosMostura = receitaLoad.ComentariosMostura;
                receita.ComentariosFervura = receitaLoad.ComentariosFervura;
                receita.ComentariosFermMat = receitaLoad.ComentariosFermMat;

                if (receita.RampasMostura != null)
                {
                    receita.RampasMostura.Clear();
                }
                receita.RampasMostura.AddRange(receitaLoad.RampasMostura);

                receita.Fermentaveis.Clear();
                fermentaveisMosto.Clear();
                leveduraMosto.Clear();
                receita.Lupulos.Clear();
                lupuloMosto.Clear();

                foreach (var item in receitaLoad.Fermentaveis)
                {
                    foreach (var insumo in fermentaveisLista)
                    {
                        if (item.Nome == insumo.Nome)
                        {
                            Fermentavel insumoMosto = new(insumo.Nome, insumo.Tipo, insumo.EBC, insumo.Extrato, item.Peso);
                            fermentaveisMosto.Add(insumoMosto);                            
                        }
                    }                    
                }
                calcPesoPercentmaltes();
                receita.Fermentaveis.AddRange(fermentaveisMosto);

                foreach (var item in receitaLoad.Lupulos)
                {
                    foreach (var insumo in lupuloLista)
                    {
                        if (item.Nome == insumo.Nome)
                        {
                            Lupulo lupMosto = new(insumo.Nome, insumo.Tipo, insumo.AlfaAcido, item.Peso, item.TempoFervura);
                            lupuloMosto.Add(lupMosto);
                        }
                    }
                }

                receita.Lupulos.AddRange(lupuloMosto);
                foreach (var levedura in leveduraLista)
                {
                    if (levedura.Nome == receitaLoad.Levedura)
                    {
                        leveduraMosto.Add(levedura);
                        receita.Levedura = levedura; 
                    }
                }

                foreach (var item in estilosLista)
                {
                    if (receita.Estilo == item.Nome)
                    {
                        lbl_ogrange.Text = $"{item.OGRange[0]}-{item.OGRange[1]}";
                        lbl_fgrange.Text = $"{item.FGRange[0]}-{item.FGRange[1]}";
                        lbl_abvrange.Text = $"{item.ABVRange[0]}-{item.ABVRange[1]}";
                        lbl_srmrange.Text = $"{item.SRMRange[0]}-{item.SRMRange[1]}";
                        lbl_ebcrange.Text = $"{item.SRMRange[0] * 2}-{item.SRMRange[1] * 2}";
                        lbl_iburange.Text = $"{item.IBURange[0]}-{item.IBURange[1]}";                        
                        txt_Nome.Text = receita.Nome;
                        comboBox1.SelectedItem = item.Nome;
                    }
                }


                if (receita.RampasMostura.Count > 0)
                {
                    txt_rampa_tempT1.Text = receita.RampasMostura[0][0].ToString();
                    txt_rampa_min_T1.Text = receita.RampasMostura[0][1].ToString();

                    if (receita.RampasMostura.Count >= 2)
                    {
                        checkBox_Rampa_T2.Checked = true;
                        txt_rampa_tempT2.Enabled = true;
                        txt_rampa_min_T2.Enabled = true;
                        txt_rampa_tempT2.Text = receita.RampasMostura[1][0].ToString();
                        txt_rampa_min_T2.Text = receita.RampasMostura[1][1].ToString();
                    }
                    if (receita.RampasMostura.Count >= 3)
                    {
                        checkBox_Rampa_T3.Checked = true;
                        txt_rampa_tempT3.Enabled = true;
                        txt_rampa_min_T3.Enabled = true;
                        txt_rampa_tempT3.Text = receita.RampasMostura[2][0].ToString();
                        txt_rampa_min_T3.Text = receita.RampasMostura[2][1].ToString();
                    }
                    if (receita.RampasMostura.Count >= 4)
                    {
                        checkBox_Rampa_T4.Checked = true;
                        txt_rampa_tempT4.Enabled = true;
                        txt_rampa_min_T4.Enabled = true;
                        txt_rampa_tempT4.Text = receita.RampasMostura[3][0].ToString();
                        txt_rampa_min_T4.Text = receita.RampasMostura[3][1].ToString();
                    }
                }

                txt_matura_temp.Text = (receita.Maturacao != null) ? receita.Maturacao[0].ToString() : "0" ;
                txt_tempo_maturacao.Text = (receita.Maturacao != null) ? receita.Maturacao[1].ToString() : "0";

                txt_temp_ferm.Text = (receita.Fermentacao != null) ? receita.Fermentacao[0].ToString() : "0";
                Txt_TempoFermentacao.Text = (receita.Fermentacao != null) ? receita.Fermentacao[1].ToString() : "0";

                checkBox_dryhopping.Checked = (receita.Dryhopping[0] != "" && receita.Dryhopping[0] != null) ? true : false;

                comboBox_dryhopping.SelectedItem = receita.Dryhopping[0];
                textBox_DH_peso.Text = (receita.Dryhopping[1] != "") ? receita.Dryhopping[1] : "";
                textBox_DH_dias.Text = (receita.Dryhopping[2] != "") ? receita.Dryhopping[2] : "";

                richText_com_mostura.Text = receita.ComentariosMostura;
                richText_com_ferv.Text = receita.ComentariosMostura;
                richText_coment_ferm.Text = receita.ComentariosFermMat;


                Loadlv_selecionados();
                Loadlv_lp_selecionados();
                Loadlv_lev_selecionados();
            }       
            
        }

        private void txt_eficiencia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                eficiencia = float.Parse(txt_eficiencia.Text);
                CalcProp();
            }
            catch (Exception)
            {
                MessageBox.Show("eficiencia deve ser um valor entre 0 e 100");
            }
        }

        private void txt_Nome_TextChanged(object sender, EventArgs e)
        {
            receita.Nome = txt_Nome.Text;
        }

        
        private void checkBox_Rampa_T2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Rampa_T2.Checked)
            {
                checkBox_Rampa_T3.Enabled = true;

                txt_rampa_min_T2.Enabled = true;
                txt_rampa_tempT2.Enabled = true;
            }
            else
            {
                checkBox_Rampa_T3.Enabled = false;
                checkBox_Rampa_T4.Enabled = false;

                txt_rampa_min_T2.Enabled = false;
                txt_rampa_min_T2.Text = "";
                txt_rampa_tempT2.Enabled = false;
                txt_rampa_tempT2.Text = "";
                txt_rampa_min_T3.Enabled = false;
                txt_rampa_min_T3.Text = "";
                txt_rampa_tempT3.Enabled = false;
                txt_rampa_tempT3.Text = "";
                txt_rampa_min_T4.Enabled = false;
                txt_rampa_min_T4.Text = "";
                txt_rampa_tempT4.Enabled = false;
                txt_rampa_tempT4.Text = "";
            }
        }

        private void checkBox_Rampa_T3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Rampa_T3.Checked)
            {
                checkBox_Rampa_T4.Enabled = true;
                txt_rampa_min_T3.Enabled = true;
                txt_rampa_tempT3.Enabled = true;
            }
            else
            {
                checkBox_Rampa_T4.Enabled = false;

                txt_rampa_min_T3.Enabled = false;
                txt_rampa_min_T3.Text = "";
                txt_rampa_tempT3.Enabled = false;
                txt_rampa_tempT3.Text = "";
                txt_rampa_min_T4.Enabled = false;
                txt_rampa_min_T4.Text = "";
                txt_rampa_tempT4.Enabled = false;
                txt_rampa_tempT4.Text = "";
            }
        }

        private void checkBox_Rampa_T4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Rampa_T4.Checked)
            {
                txt_rampa_min_T4.Enabled = true;
                txt_rampa_tempT4.Enabled = true;
            }
            else
            {
                txt_rampa_min_T4.Enabled = false;
                txt_rampa_min_T4.Text = "";
                txt_rampa_tempT4.Enabled = false;
                txt_rampa_tempT4.Text = "";
            }
        }
        private void txt_rampa_min_T1_TextChanged(object sender, EventArgs e)
        {
            double R1;          
            double R2;
            double R3;
            double R4;
            try { R1 = double.Parse(txt_rampa_min_T1.Text, 0); }
            catch (Exception) { R1 = 0; }
            try { R2 = txt_rampa_min_T2.Enabled ? double.Parse(txt_rampa_min_T2.Text) : 0; }
            catch (Exception) { R2 = 0; }
            try { R3 = txt_rampa_min_T3.Enabled ? double.Parse(txt_rampa_min_T3.Text) : 0; }
            catch (Exception) { R3 = 0; }
            try { R4 = txt_rampa_min_T4.Enabled ? double.Parse(txt_rampa_min_T4.Text) : 0; }
            catch (Exception) { R4 = 0; }


            if (R1 + R2 + R3 + R4 > double.Parse(txt_TempoMostura.Text))
            {
                txt_rampa_min_T1.ForeColor = Color.Red;
            }
            else if (R1 + R2 + R3 + R4 < double.Parse(txt_TempoMostura.Text))
            {
                txt_rampa_min_T1.ForeColor = Color.Red;
                txt_rampa_min_T2.ForeColor = Color.Red;
                txt_rampa_min_T3.ForeColor = Color.Red;
                txt_rampa_min_T4.ForeColor = Color.Red;
            }
            else
            {
                txt_rampa_min_T1.ForeColor = Color.Black;
                txt_rampa_min_T2.ForeColor = Color.Black;
                txt_rampa_min_T3.ForeColor = Color.Black;
                txt_rampa_min_T4.ForeColor = Color.Black;
            }
        }
        private void txt_rampa_min_T2_TextChanged(object sender, EventArgs e)
        {
            double R1;
            double R2;
            double R3;
            double R4;
            try { R1 = double.Parse(txt_rampa_min_T1.Text, 0); }
            catch (Exception) { R1 = 0; }
            try {R2 = txt_rampa_min_T2.Enabled ? double.Parse(txt_rampa_min_T2.Text) : 0;}
            catch (Exception){R2 = 0;}
            try {R3 = txt_rampa_min_T3.Enabled ? double.Parse(txt_rampa_min_T3.Text) : 0;}
            catch (Exception) { R3 = 0;}
            try {R4 = txt_rampa_min_T4.Enabled ? double.Parse(txt_rampa_min_T4.Text) : 0;}
            catch (Exception) {R4 = 0;}


            if (R1 + R2 + R3 + R4 != double.Parse(txt_TempoMostura.Text))
            {
                txt_rampa_min_T1.ForeColor = Color.Red;
                txt_rampa_min_T2.ForeColor = Color.Red;
                txt_rampa_min_T3.ForeColor = Color.Red;
                txt_rampa_min_T4.ForeColor = Color.Red;
            }
            else
            {
                txt_rampa_min_T1.ForeColor = Color.Black;
                txt_rampa_min_T2.ForeColor = Color.Black;
                txt_rampa_min_T3.ForeColor = Color.Black;
                txt_rampa_min_T4.ForeColor = Color.Black;
            }
        }

        private void txt_rampa_min_T3_TextChanged(object sender, EventArgs e)
        {
            double R1;
            double R2;
            double R3;
            double R4;
            try { R1 = double.Parse(txt_rampa_min_T1.Text, 0); }
            catch (Exception) { R1 = 0; }
            try { R2 = txt_rampa_min_T2.Enabled ? double.Parse(txt_rampa_min_T2.Text) : 0; }
            catch (Exception) { R2 = 0; }
            try { R3 = txt_rampa_min_T3.Enabled ? double.Parse(txt_rampa_min_T3.Text) : 0; }
            catch (Exception) { R3 = 0; }
            try { R4 = txt_rampa_min_T4.Enabled ? double.Parse(txt_rampa_min_T4.Text) : 0; }
            catch (Exception) { R4 = 0; }


            if (R1 + R2 + R3 + R4 != double.Parse(txt_TempoMostura.Text))
            {
                txt_rampa_min_T1.ForeColor = Color.Red;
                txt_rampa_min_T2.ForeColor = Color.Red;
                txt_rampa_min_T3.ForeColor = Color.Red;
                txt_rampa_min_T4.ForeColor = Color.Red;
            }
            else
            {
                txt_rampa_min_T1.ForeColor = Color.Black;
                txt_rampa_min_T2.ForeColor = Color.Black;
                txt_rampa_min_T3.ForeColor = Color.Black;
                txt_rampa_min_T4.ForeColor = Color.Black;
            }
        }

        private void txt_rampa_min_T4_TextChanged(object sender, EventArgs e)
        {
            double R1;
            double R2;
            double R3;
            double R4;
            try { R1 = double.Parse(txt_rampa_min_T1.Text, 0); }
            catch (Exception) { R1 = 0; }
            try { R2 = txt_rampa_min_T2.Enabled ? double.Parse(txt_rampa_min_T2.Text) : 0; }
            catch (Exception) { R2 = 0; }
            try { R3 = txt_rampa_min_T3.Enabled ? double.Parse(txt_rampa_min_T3.Text) : 0; }
            catch (Exception) { R3 = 0; }
            try { R4 = txt_rampa_min_T4.Enabled ? double.Parse(txt_rampa_min_T4.Text) : 0; }
            catch (Exception) { R4 = 0; }


            if (R1 + R2 + R3 + R4 != double.Parse(txt_TempoMostura.Text))
            {
                txt_rampa_min_T1.ForeColor = Color.Red;
                txt_rampa_min_T2.ForeColor = Color.Red;
                txt_rampa_min_T3.ForeColor = Color.Red;
                txt_rampa_min_T4.ForeColor = Color.Red;
            }
            else
            {
                txt_rampa_min_T1.ForeColor = Color.Black;
                txt_rampa_min_T2.ForeColor = Color.Black;
                txt_rampa_min_T3.ForeColor = Color.Black;
                txt_rampa_min_T4.ForeColor = Color.Black;
            }
        }

        private void txt_TempoMostura_TextChanged(object sender, EventArgs e)
        {
            if (txt_rampa_min_T2.Enabled != true)
            {
                txt_rampa_min_T1.Text = txt_TempoMostura.Text;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_dryhopping.Checked)
            {
                comboBox_dryhopping.Enabled = true;
                textBox_DH_dias.Enabled = true;
                textBox_DH_peso.Enabled = true;
            }
            else
            {
                comboBox_dryhopping.Enabled = false;
                textBox_DH_dias.Enabled = false;
                textBox_DH_dias.Text = "";
                textBox_DH_peso.Enabled = false;
                textBox_DH_peso.Text = "";
            }
        }
    }
}
