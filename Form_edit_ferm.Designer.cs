
namespace BrewHome
{
    partial class Form_edit_ferm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_edit_ferm));
            this.lv_fermentaveis = new System.Windows.Forms.ListView();
            this.btn_add_ferm = new System.Windows.Forms.Button();
            this.btn_del_ferm = new System.Windows.Forms.Button();
            this.btn_edit_fermentavel = new System.Windows.Forms.Button();
            this.btn_sair = new System.Windows.Forms.Button();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.txt_EBC = new System.Windows.Forms.TextBox();
            this.txt_extrato = new System.Windows.Forms.TextBox();
            this.comboBox_tipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lv_fermentaveis
            // 
            this.lv_fermentaveis.HideSelection = false;
            this.lv_fermentaveis.Location = new System.Drawing.Point(172, 12);
            this.lv_fermentaveis.Name = "lv_fermentaveis";
            this.lv_fermentaveis.Size = new System.Drawing.Size(566, 292);
            this.lv_fermentaveis.TabIndex = 1;
            this.lv_fermentaveis.UseCompatibleStateImageBehavior = false;
            // 
            // btn_add_ferm
            // 
            this.btn_add_ferm.Location = new System.Drawing.Point(12, 12);
            this.btn_add_ferm.Name = "btn_add_ferm";
            this.btn_add_ferm.Size = new System.Drawing.Size(154, 31);
            this.btn_add_ferm.TabIndex = 2;
            this.btn_add_ferm.Text = "Add Fermentável";
            this.btn_add_ferm.UseVisualStyleBackColor = true;
            this.btn_add_ferm.Click += new System.EventHandler(this.btn_add_ferm_Click);
            // 
            // btn_del_ferm
            // 
            this.btn_del_ferm.Location = new System.Drawing.Point(12, 49);
            this.btn_del_ferm.Name = "btn_del_ferm";
            this.btn_del_ferm.Size = new System.Drawing.Size(154, 31);
            this.btn_del_ferm.TabIndex = 3;
            this.btn_del_ferm.Text = "Del Fermentável";
            this.btn_del_ferm.UseVisualStyleBackColor = true;
            // 
            // btn_edit_fermentavel
            // 
            this.btn_edit_fermentavel.Location = new System.Drawing.Point(12, 86);
            this.btn_edit_fermentavel.Name = "btn_edit_fermentavel";
            this.btn_edit_fermentavel.Size = new System.Drawing.Size(154, 31);
            this.btn_edit_fermentavel.TabIndex = 4;
            this.btn_edit_fermentavel.Text = "Editar Fermentavel";
            this.btn_edit_fermentavel.UseVisualStyleBackColor = true;
            // 
            // btn_sair
            // 
            this.btn_sair.Location = new System.Drawing.Point(12, 369);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(154, 31);
            this.btn_sair.TabIndex = 5;
            this.btn_sair.Text = "Sair";
            this.btn_sair.UseVisualStyleBackColor = true;
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(172, 327);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(137, 23);
            this.txt_nome.TabIndex = 6;
            // 
            // txt_EBC
            // 
            this.txt_EBC.Location = new System.Drawing.Point(458, 327);
            this.txt_EBC.Name = "txt_EBC";
            this.txt_EBC.Size = new System.Drawing.Size(137, 23);
            this.txt_EBC.TabIndex = 7;
            // 
            // txt_extrato
            // 
            this.txt_extrato.Location = new System.Drawing.Point(601, 327);
            this.txt_extrato.Name = "txt_extrato";
            this.txt_extrato.Size = new System.Drawing.Size(137, 23);
            this.txt_extrato.TabIndex = 8;
            // 
            // comboBox_tipo
            // 
            this.comboBox_tipo.FormattingEnabled = true;
            this.comboBox_tipo.Location = new System.Drawing.Point(315, 327);
            this.comboBox_tipo.Name = "comboBox_tipo";
            this.comboBox_tipo.Size = new System.Drawing.Size(137, 23);
            this.comboBox_tipo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "EBC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(601, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Extrato";
            // 
            // Form_edit_ferm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 412);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_tipo);
            this.Controls.Add(this.txt_extrato);
            this.Controls.Add(this.txt_EBC);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_edit_fermentavel);
            this.Controls.Add(this.btn_del_ferm);
            this.Controls.Add(this.btn_add_ferm);
            this.Controls.Add(this.lv_fermentaveis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_edit_ferm";
            this.Text = "Fermentáveis";
            this.Load += new System.EventHandler(this.Form_edit_ferm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lv_fermentaveis;
        private System.Windows.Forms.Button btn_add_ferm;
        private System.Windows.Forms.Button btn_del_ferm;
        private System.Windows.Forms.Button btn_edit_fermentavel;
        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.TextBox txt_EBC;
        private System.Windows.Forms.TextBox txt_extrato;
        private System.Windows.Forms.ComboBox comboBox_tipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}