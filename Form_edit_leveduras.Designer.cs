
namespace BrewHome
{
    partial class Form_edit_leveduras
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
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_atenuacao = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_tipo = new System.Windows.Forms.ComboBox();
            this.txt_atenuacao = new System.Windows.Forms.TextBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.btn_sair = new System.Windows.Forms.Button();
            this.btn_edit_levedura = new System.Windows.Forms.Button();
            this.btn_del_lev = new System.Windows.Forms.Button();
            this.btn_add_lev = new System.Windows.Forms.Button();
            this.lv_levedura = new System.Windows.Forms.ListView();
            this.btn_submeter = new System.Windows.Forms.Button();
            this.comboBox_Flocula = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Floculação";
            // 
            // lbl_atenuacao
            // 
            this.lbl_atenuacao.AutoSize = true;
            this.lbl_atenuacao.Location = new System.Drawing.Point(409, 309);
            this.lbl_atenuacao.Name = "lbl_atenuacao";
            this.lbl_atenuacao.Size = new System.Drawing.Size(64, 15);
            this.lbl_atenuacao.TabIndex = 25;
            this.lbl_atenuacao.Text = "Atenuação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome";
            // 
            // comboBox_tipo
            // 
            this.comboBox_tipo.Enabled = false;
            this.comboBox_tipo.FormattingEnabled = true;
            this.comboBox_tipo.Location = new System.Drawing.Point(266, 327);
            this.comboBox_tipo.Name = "comboBox_tipo";
            this.comboBox_tipo.Size = new System.Drawing.Size(137, 23);
            this.comboBox_tipo.TabIndex = 22;
            // 
            // txt_atenuacao
            // 
            this.txt_atenuacao.Enabled = false;
            this.txt_atenuacao.Location = new System.Drawing.Point(409, 327);
            this.txt_atenuacao.Name = "txt_atenuacao";
            this.txt_atenuacao.Size = new System.Drawing.Size(137, 23);
            this.txt_atenuacao.TabIndex = 20;
            this.txt_atenuacao.TextChanged += new System.EventHandler(this.txt_atenuacao_TextChanged);
            // 
            // txt_nome
            // 
            this.txt_nome.Enabled = false;
            this.txt_nome.Location = new System.Drawing.Point(123, 327);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(137, 23);
            this.txt_nome.TabIndex = 19;
            // 
            // btn_sair
            // 
            this.btn_sair.Location = new System.Drawing.Point(7, 446);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(110, 31);
            this.btn_sair.TabIndex = 18;
            this.btn_sair.Text = "Sair";
            this.btn_sair.UseVisualStyleBackColor = true;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // btn_edit_levedura
            // 
            this.btn_edit_levedura.Enabled = false;
            this.btn_edit_levedura.Location = new System.Drawing.Point(7, 49);
            this.btn_edit_levedura.Name = "btn_edit_levedura";
            this.btn_edit_levedura.Size = new System.Drawing.Size(110, 31);
            this.btn_edit_levedura.TabIndex = 17;
            this.btn_edit_levedura.Text = "Editar Levedura";
            this.btn_edit_levedura.UseVisualStyleBackColor = true;
            this.btn_edit_levedura.Click += new System.EventHandler(this.btn_edit_levedura_Click);
            // 
            // btn_del_lev
            // 
            this.btn_del_lev.Location = new System.Drawing.Point(7, 86);
            this.btn_del_lev.Name = "btn_del_lev";
            this.btn_del_lev.Size = new System.Drawing.Size(110, 31);
            this.btn_del_lev.TabIndex = 16;
            this.btn_del_lev.Text = "Excluir levedura";
            this.btn_del_lev.UseVisualStyleBackColor = true;
            this.btn_del_lev.Click += new System.EventHandler(this.btn_del_lev_Click);
            // 
            // btn_add_lev
            // 
            this.btn_add_lev.Location = new System.Drawing.Point(7, 12);
            this.btn_add_lev.Name = "btn_add_lev";
            this.btn_add_lev.Size = new System.Drawing.Size(110, 31);
            this.btn_add_lev.TabIndex = 15;
            this.btn_add_lev.Text = "Add Levedura";
            this.btn_add_lev.UseVisualStyleBackColor = true;
            this.btn_add_lev.Click += new System.EventHandler(this.btn_add_lev_Click);
            // 
            // lv_levedura
            // 
            this.lv_levedura.HideSelection = false;
            this.lv_levedura.Location = new System.Drawing.Point(123, 12);
            this.lv_levedura.Name = "lv_levedura";
            this.lv_levedura.Size = new System.Drawing.Size(566, 292);
            this.lv_levedura.TabIndex = 14;
            this.lv_levedura.UseCompatibleStateImageBehavior = false;
            this.lv_levedura.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_levedura_MouseClick);
            // 
            // btn_submeter
            // 
            this.btn_submeter.Enabled = false;
            this.btn_submeter.Location = new System.Drawing.Point(7, 327);
            this.btn_submeter.Name = "btn_submeter";
            this.btn_submeter.Size = new System.Drawing.Size(110, 24);
            this.btn_submeter.TabIndex = 27;
            this.btn_submeter.Text = "Submeter";
            this.btn_submeter.UseVisualStyleBackColor = true;
            this.btn_submeter.Click += new System.EventHandler(this.btn_submeter_Click);
            // 
            // comboBox_Flocula
            // 
            this.comboBox_Flocula.Enabled = false;
            this.comboBox_Flocula.FormattingEnabled = true;
            this.comboBox_Flocula.Location = new System.Drawing.Point(552, 327);
            this.comboBox_Flocula.Name = "comboBox_Flocula";
            this.comboBox_Flocula.Size = new System.Drawing.Size(137, 23);
            this.comboBox_Flocula.TabIndex = 28;
            this.comboBox_Flocula.SelectedIndexChanged += new System.EventHandler(this.comboBox_Flocula_SelectedIndexChanged);
            // 
            // Form_edit_leveduras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 489);
            this.Controls.Add(this.comboBox_Flocula);
            this.Controls.Add(this.btn_submeter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_atenuacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_tipo);
            this.Controls.Add(this.txt_atenuacao);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_edit_levedura);
            this.Controls.Add(this.btn_del_lev);
            this.Controls.Add(this.btn_add_lev);
            this.Controls.Add(this.lv_levedura);
            this.Name = "Form_edit_leveduras";
            this.Text = "Form_edit_leveduras";
            this.Load += new System.EventHandler(this.Form_edit_leveduras_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_atenuacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_tipo;
        private System.Windows.Forms.TextBox txt_atenuacao;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Button btn_edit_levedura;
        private System.Windows.Forms.Button btn_del_lev;
        private System.Windows.Forms.Button btn_add_lev;
        private System.Windows.Forms.ListView lv_levedura;
        private System.Windows.Forms.Button btn_submeter;
        private System.Windows.Forms.ComboBox comboBox_Flocula;
    }
}