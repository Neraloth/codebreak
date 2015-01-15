﻿namespace Codebreak.Tool.Database
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chargerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabNpcTemplate = new System.Windows.Forms.TabPage();
            this.numericUpDownSearchNpcTemplateId = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxSearchNpcTemplateName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchNpcTemplate = new System.Windows.Forms.Button();
            this.listViewNpcTemplate = new System.Windows.Forms.ListView();
            this.columnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSell = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExchange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripNpcTemplate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editerToolStripMenuItemNpcTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabNpcTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchNpcTemplateId)).BeginInit();
            this.contextMenuStripNpcTemplate.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargerToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chargerToolStripMenuItem
            // 
            this.chargerToolStripMenuItem.Name = "chargerToolStripMenuItem";
            this.chargerToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.chargerToolStripMenuItem.Text = "Charger";
            this.chargerToolStripMenuItem.Click += new System.EventHandler(this.chargerToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabNpcTemplate);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 462);
            this.tabControl1.TabIndex = 1;
            // 
            // TabNpcTemplate
            // 
            this.TabNpcTemplate.Controls.Add(this.numericUpDownSearchNpcTemplateId);
            this.TabNpcTemplate.Controls.Add(this.label2);
            this.TabNpcTemplate.Controls.Add(this.txtBoxSearchNpcTemplateName);
            this.TabNpcTemplate.Controls.Add(this.label1);
            this.TabNpcTemplate.Controls.Add(this.btnSearchNpcTemplate);
            this.TabNpcTemplate.Controls.Add(this.listViewNpcTemplate);
            this.TabNpcTemplate.Location = new System.Drawing.Point(4, 22);
            this.TabNpcTemplate.Name = "TabNpcTemplate";
            this.TabNpcTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.TabNpcTemplate.Size = new System.Drawing.Size(852, 436);
            this.TabNpcTemplate.TabIndex = 0;
            this.TabNpcTemplate.Text = "NpcTemplate";
            this.TabNpcTemplate.UseVisualStyleBackColor = true;
            // 
            // numericUpDownSearchNpcTemplateId
            // 
            this.numericUpDownSearchNpcTemplateId.Location = new System.Drawing.Point(162, 8);
            this.numericUpDownSearchNpcTemplateId.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSearchNpcTemplateId.Name = "numericUpDownSearchNpcTemplateId";
            this.numericUpDownSearchNpcTemplateId.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownSearchNpcTemplateId.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nom :";
            // 
            // txtBoxSearchNpcTemplateName
            // 
            this.txtBoxSearchNpcTemplateName.Location = new System.Drawing.Point(284, 8);
            this.txtBoxSearchNpcTemplateName.Name = "txtBoxSearchNpcTemplateName";
            this.txtBoxSearchNpcTemplateName.Size = new System.Drawing.Size(146, 20);
            this.txtBoxSearchNpcTemplateName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id :";
            // 
            // btnSearchNpcTemplate
            // 
            this.btnSearchNpcTemplate.Location = new System.Drawing.Point(6, 5);
            this.btnSearchNpcTemplate.Name = "btnSearchNpcTemplate";
            this.btnSearchNpcTemplate.Size = new System.Drawing.Size(122, 23);
            this.btnSearchNpcTemplate.TabIndex = 2;
            this.btnSearchNpcTemplate.Text = "Rechercher";
            this.btnSearchNpcTemplate.UseVisualStyleBackColor = true;
            this.btnSearchNpcTemplate.Click += new System.EventHandler(this.btnSearchNpcTemplate_Click);
            // 
            // listViewNpcTemplate
            // 
            this.listViewNpcTemplate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnName,
            this.columnSell,
            this.columnExchange});
            this.listViewNpcTemplate.ContextMenuStrip = this.contextMenuStripNpcTemplate;
            this.listViewNpcTemplate.FullRowSelect = true;
            this.listViewNpcTemplate.GridLines = true;
            this.listViewNpcTemplate.Location = new System.Drawing.Point(3, 32);
            this.listViewNpcTemplate.MultiSelect = false;
            this.listViewNpcTemplate.Name = "listViewNpcTemplate";
            this.listViewNpcTemplate.Size = new System.Drawing.Size(843, 411);
            this.listViewNpcTemplate.TabIndex = 0;
            this.listViewNpcTemplate.UseCompatibleStateImageBehavior = false;
            this.listViewNpcTemplate.View = System.Windows.Forms.View.Details;
            // 
            // columnId
            // 
            this.columnId.Text = "Id";
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 214;
            // 
            // columnSell
            // 
            this.columnSell.Text = "Sell";
            this.columnSell.Width = 332;
            // 
            // columnExchange
            // 
            this.columnExchange.Text = "Exchange";
            this.columnExchange.Width = 206;
            // 
            // contextMenuStripNpcTemplate
            // 
            this.contextMenuStripNpcTemplate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editerToolStripMenuItemNpcTemplate});
            this.contextMenuStripNpcTemplate.Name = "contextMenuStripNpcTemplate";
            this.contextMenuStripNpcTemplate.Size = new System.Drawing.Size(105, 26);
            // 
            // editerToolStripMenuItemNpcTemplate
            // 
            this.editerToolStripMenuItemNpcTemplate.Name = "editerToolStripMenuItemNpcTemplate";
            this.editerToolStripMenuItemNpcTemplate.Size = new System.Drawing.Size(104, 22);
            this.editerToolStripMenuItemNpcTemplate.Text = "Editer";
            this.editerToolStripMenuItemNpcTemplate.Click += new System.EventHandler(this.editerToolStripMenuItemNpcTemplate_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(852, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelState,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 492);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelState
            // 
            this.toolStripStatusLabelState.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabelState.Name = "toolStripStatusLabelState";
            this.toolStripStatusLabelState.Size = new System.Drawing.Size(125, 17);
            this.toolStripStatusLabelState.Text = "Attente chargement ...";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(700, 16);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 514);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oklm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabNpcTemplate.ResumeLayout(false);
            this.TabNpcTemplate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchNpcTemplateId)).EndInit();
            this.contextMenuStripNpcTemplate.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chargerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabNpcTemplate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listViewNpcTemplate;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnSell;
        private System.Windows.Forms.ColumnHeader columnExchange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxSearchNpcTemplateName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchNpcTemplate;
        private System.Windows.Forms.NumericUpDown numericUpDownSearchNpcTemplateId;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNpcTemplate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelState;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem editerToolStripMenuItemNpcTemplate;
    }
}
