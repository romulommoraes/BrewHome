
namespace BrewHome
{
    partial class Form_intro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_intro));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciadorDeReceitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciadorDeInsumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermentáveisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lúpulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levedurasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciadorDeReceitasToolStripMenuItem,
            this.gerenciadorDeInsumosToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // gerenciadorDeReceitasToolStripMenuItem
            // 
            this.gerenciadorDeReceitasToolStripMenuItem.Name = "gerenciadorDeReceitasToolStripMenuItem";
            this.gerenciadorDeReceitasToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.gerenciadorDeReceitasToolStripMenuItem.Text = "Gerenciador de Receitas";
            this.gerenciadorDeReceitasToolStripMenuItem.Click += new System.EventHandler(this.gerenciadorDeReceitasToolStripMenuItem_Click);
            // 
            // gerenciadorDeInsumosToolStripMenuItem
            // 
            this.gerenciadorDeInsumosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fermentáveisToolStripMenuItem,
            this.lúpulosToolStripMenuItem,
            this.levedurasToolStripMenuItem});
            this.gerenciadorDeInsumosToolStripMenuItem.Name = "gerenciadorDeInsumosToolStripMenuItem";
            this.gerenciadorDeInsumosToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.gerenciadorDeInsumosToolStripMenuItem.Text = "Gerenciador de Insumos";
            // 
            // fermentáveisToolStripMenuItem
            // 
            this.fermentáveisToolStripMenuItem.Name = "fermentáveisToolStripMenuItem";
            this.fermentáveisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fermentáveisToolStripMenuItem.Text = "Fermentáveis";
            this.fermentáveisToolStripMenuItem.Click += new System.EventHandler(this.fermentáveisToolStripMenuItem_Click);
            // 
            // lúpulosToolStripMenuItem
            // 
            this.lúpulosToolStripMenuItem.Name = "lúpulosToolStripMenuItem";
            this.lúpulosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lúpulosToolStripMenuItem.Text = "Lúpulos";
            this.lúpulosToolStripMenuItem.Click += new System.EventHandler(this.lúpulosToolStripMenuItem_Click);
            // 
            // levedurasToolStripMenuItem
            // 
            this.levedurasToolStripMenuItem.Name = "levedurasToolStripMenuItem";
            this.levedurasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.levedurasToolStripMenuItem.Text = "Leveduras";
            this.levedurasToolStripMenuItem.Click += new System.EventHandler(this.levedurasToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BrewHome.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 372);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form_intro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_intro";
            this.Text = "BrewHome 1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciadorDeReceitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciadorDeInsumosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem fermentáveisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lúpulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levedurasToolStripMenuItem;
    }
}