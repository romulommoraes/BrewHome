using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrewHome
{
    public partial class Form_intro : Form
    {
        public Form_intro()
        {
            InitializeComponent();
        }

        private void gerenciadorDeReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_receitas f2 = new Form_receitas();
            f2.ShowDialog(); // Shows Form2
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_sobre f3 = new Form_sobre();
            f3.ShowDialog();
        }

        private void fermentáveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_edit_ferm f4 = new Form_edit_ferm();
            f4.ShowDialog();
        }

        private void lúpulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_edit_lupulo f5 = new Form_edit_lupulo();
            f5.ShowDialog();
        }
    }
}
