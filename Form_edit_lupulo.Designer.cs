﻿
namespace BrewHome
{
    partial class Form_edit_lupulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_edit_lupulo));
            this.Txt_AlfaAcido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_tipo = new System.Windows.Forms.ComboBox();
            this.txt_ex = new System.Windows.Forms.TextBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.btn_sair = new System.Windows.Forms.Button();
            this.btn_edit_lupulo = new System.Windows.Forms.Button();
            this.btn_del_lupulo = new System.Windows.Forms.Button();
            this.btn_add_lupulo = new System.Windows.Forms.Button();
            this.lv_lupulo = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Txt_AlfaAcido
            // 
            this.Txt_AlfaAcido.AutoSize = true;
            this.Txt_AlfaAcido.Location = new System.Drawing.Point(562, 307);
            this.Txt_AlfaAcido.Name = "Txt_AlfaAcido";
            this.Txt_AlfaAcido.Size = new System.Drawing.Size(64, 15);
            this.Txt_AlfaAcido.TabIndex = 25;
            this.Txt_AlfaAcido.Text = "Alfa_Acido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome";
            // 
            // comboBox_tipo
            // 
            this.comboBox_tipo.FormattingEnabled = true;
            this.comboBox_tipo.Location = new System.Drawing.Point(367, 327);
            this.comboBox_tipo.Name = "comboBox_tipo";
            this.comboBox_tipo.Size = new System.Drawing.Size(188, 23);
            this.comboBox_tipo.TabIndex = 22;
            this.comboBox_tipo.SelectedIndexChanged += new System.EventHandler(this.comboBox_tipo_SelectedIndexChanged);
            // 
            // txt_ex
            // 
            this.txt_ex.Location = new System.Drawing.Point(562, 327);
            this.txt_ex.Name = "txt_ex";
            this.txt_ex.Size = new System.Drawing.Size(188, 23);
            this.txt_ex.TabIndex = 20;
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(172, 327);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(188, 23);
            this.txt_nome.TabIndex = 19;
            // 
            // btn_sair
            // 
            this.btn_sair.Location = new System.Drawing.Point(12, 369);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(154, 31);
            this.btn_sair.TabIndex = 18;
            this.btn_sair.Text = "Sair";
            this.btn_sair.UseVisualStyleBackColor = true;
            // 
            // btn_edit_lupulo
            // 
            this.btn_edit_lupulo.Location = new System.Drawing.Point(12, 86);
            this.btn_edit_lupulo.Name = "btn_edit_lupulo";
            this.btn_edit_lupulo.Size = new System.Drawing.Size(154, 31);
            this.btn_edit_lupulo.TabIndex = 17;
            this.btn_edit_lupulo.Text = "Editar Lúpulo";
            this.btn_edit_lupulo.UseVisualStyleBackColor = true;
            // 
            // btn_del_lupulo
            // 
            this.btn_del_lupulo.Location = new System.Drawing.Point(12, 49);
            this.btn_del_lupulo.Name = "btn_del_lupulo";
            this.btn_del_lupulo.Size = new System.Drawing.Size(154, 31);
            this.btn_del_lupulo.TabIndex = 16;
            this.btn_del_lupulo.Text = "Excluir Lúpulo";
            this.btn_del_lupulo.UseVisualStyleBackColor = true;
            // 
            // btn_add_lupulo
            // 
            this.btn_add_lupulo.Location = new System.Drawing.Point(12, 12);
            this.btn_add_lupulo.Name = "btn_add_lupulo";
            this.btn_add_lupulo.Size = new System.Drawing.Size(154, 31);
            this.btn_add_lupulo.TabIndex = 15;
            this.btn_add_lupulo.Text = "Add Lúpulo";
            this.btn_add_lupulo.UseVisualStyleBackColor = true;
            // 
            // lv_lupulo
            // 
            this.lv_lupulo.HideSelection = false;
            this.lv_lupulo.Location = new System.Drawing.Point(172, 12);
            this.lv_lupulo.Name = "lv_lupulo";
            this.lv_lupulo.Size = new System.Drawing.Size(579, 292);
            this.lv_lupulo.TabIndex = 14;
            this.lv_lupulo.UseCompatibleStateImageBehavior = false;
            this.lv_lupulo.SelectedIndexChanged += new System.EventHandler(this.lv_lupulo_SelectedIndexChanged);
            // 
            // Form_edit_lupulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Controls.Add(this.Txt_AlfaAcido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_tipo);
            this.Controls.Add(this.txt_ex);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_edit_lupulo);
            this.Controls.Add(this.btn_del_lupulo);
            this.Controls.Add(this.btn_add_lupulo);
            this.Controls.Add(this.lv_lupulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_edit_lupulo";
            this.Text = "Form_edit_lupulo";
            this.Load += new System.EventHandler(this.Form_edit_lupulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Txt_AlfaAcido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_tipo;
        private System.Windows.Forms.TextBox txt_ex;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Button btn_edit_lupulo;
        private System.Windows.Forms.Button btn_del_lupulo;
        private System.Windows.Forms.Button btn_add_lupulo;
        private System.Windows.Forms.ListView lv_lupulo;
    }
}