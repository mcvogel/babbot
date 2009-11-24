﻿namespace BabBot.Forms
{
    partial class TalentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TalentsForm));
            this.cbTalentTemplates = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLevelList = new System.Windows.Forms.ListBox();
            this.labelAssignment = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelLevel = new System.Windows.Forms.Label();
            this.numLevel = new System.Windows.Forms.NumericUpDown();
            this.labelTab = new System.Windows.Forms.Label();
            this.labelTalent = new System.Windows.Forms.Label();
            this.numTalent = new System.Windows.Forms.NumericUpDown();
            this.numTab = new System.Windows.Forms.NumericUpDown();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.labelURL = new System.Windows.Forms.Label();
            this.tbTalentURL = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.labelClass = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.labelDescr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTalent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTab)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTalentTemplates
            // 
            this.cbTalentTemplates.FormattingEnabled = true;
            this.cbTalentTemplates.Location = new System.Drawing.Point(105, 6);
            this.cbTalentTemplates.Name = "cbTalentTemplates";
            this.cbTalentTemplates.Size = new System.Drawing.Size(164, 21);
            this.cbTalentTemplates.TabIndex = 0;
            this.cbTalentTemplates.SelectedIndexChanged += new System.EventHandler(this.cbTalentTemplates_SelectedIndexChanged);
            this.cbTalentTemplates.DropDown += new System.EventHandler(this.cbTalentTemplates_DropDown);
            this.cbTalentTemplates.TextChanged += new System.EventHandler(this.cbTalentTemplates_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Talent Template:";
            // 
            // lbLevelList
            // 
            this.lbLevelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLevelList.FormattingEnabled = true;
            this.lbLevelList.Location = new System.Drawing.Point(12, 166);
            this.lbLevelList.Name = "lbLevelList";
            this.lbLevelList.ScrollAlwaysVisible = true;
            this.lbLevelList.Size = new System.Drawing.Size(153, 212);
            this.lbLevelList.TabIndex = 3;
            this.lbLevelList.SelectedIndexChanged += new System.EventHandler(this.lbLevelList_SelectedIndexChanged);
            // 
            // labelAssignment
            // 
            this.labelAssignment.AutoSize = true;
            this.labelAssignment.Location = new System.Drawing.Point(9, 147);
            this.labelAssignment.Name = "labelAssignment";
            this.labelAssignment.Size = new System.Drawing.Size(146, 13);
            this.labelAssignment.TabIndex = 4;
            this.labelAssignment.Text = "Talents Assignment per Level";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(204, 401);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(116, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // labelLevel
            // 
            this.labelLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(192, 168);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(36, 13);
            this.labelLevel.TabIndex = 7;
            this.labelLevel.Text = "Level:";
            // 
            // numLevel
            // 
            this.numLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLevel.Location = new System.Drawing.Point(239, 166);
            this.numLevel.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numLevel.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(42, 20);
            this.numLevel.TabIndex = 8;
            this.numLevel.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLevel.ValueChanged += new System.EventHandler(this.numLevel_ValueChanged);
            // 
            // labelTab
            // 
            this.labelTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTab.AutoSize = true;
            this.labelTab.Location = new System.Drawing.Point(192, 194);
            this.labelTab.Name = "labelTab";
            this.labelTab.Size = new System.Drawing.Size(29, 13);
            this.labelTab.TabIndex = 9;
            this.labelTab.Text = "Tab:";
            // 
            // labelTalent
            // 
            this.labelTalent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTalent.AutoSize = true;
            this.labelTalent.Location = new System.Drawing.Point(192, 220);
            this.labelTalent.Name = "labelTalent";
            this.labelTalent.Size = new System.Drawing.Size(40, 13);
            this.labelTalent.TabIndex = 10;
            this.labelTalent.Text = "Talent:";
            // 
            // numTalent
            // 
            this.numTalent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTalent.Location = new System.Drawing.Point(239, 218);
            this.numTalent.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numTalent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTalent.Name = "numTalent";
            this.numTalent.Size = new System.Drawing.Size(42, 20);
            this.numTalent.TabIndex = 11;
            this.numTalent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numTab
            // 
            this.numTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTab.Location = new System.Drawing.Point(239, 192);
            this.numTab.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numTab.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTab.Name = "numTab";
            this.numTab.Size = new System.Drawing.Size(42, 20);
            this.numTab.TabIndex = 12;
            this.numTab.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(206, 244);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 13;
            this.btnApply.Tag = "";
            this.btnApply.Text = "Add";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(218, 77);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(63, 23);
            this.btnImport.TabIndex = 14;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(9, 34);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(98, 13);
            this.labelURL.TabIndex = 15;
            this.labelURL.Text = "WoW Armory URL:";
            // 
            // tbTalentURL
            // 
            this.tbTalentURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTalentURL.Location = new System.Drawing.Point(12, 51);
            this.tbTalentURL.Name = "tbTalentURL";
            this.tbTalentURL.Size = new System.Drawing.Size(269, 20);
            this.tbTalentURL.TabIndex = 16;
            this.tbTalentURL.Text = "http://www.wowarmory.com/talent-calc.xml?cid=6&tal=200000000000000000000000000000" +
                "0000000000000000000000000000000000000000000000000000000000";
            this.tbTalentURL.TextChanged += new System.EventHandler(this.tbTalentURL_TextChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(204, 302);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(50, 91);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(108, 21);
            this.cbClass.TabIndex = 18;
            this.cbClass.TextChanged += new System.EventHandler(this.cbClass_TextChanged);
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(9, 94);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(35, 13);
            this.labelClass.TabIndex = 19;
            this.labelClass.Text = "Class:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(50, 118);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(229, 20);
            this.tbDescription.TabIndex = 20;
            this.tbDescription.TextChanged += new System.EventHandler(this.tbDescription_TextChanged);
            // 
            // labelDescr
            // 
            this.labelDescr.AutoSize = true;
            this.labelDescr.Location = new System.Drawing.Point(9, 121);
            this.labelDescr.Name = "labelDescr";
            this.labelDescr.Size = new System.Drawing.Size(38, 13);
            this.labelDescr.TabIndex = 21;
            this.labelDescr.Text = "Descr:";
            // 
            // TalentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 436);
            this.Controls.Add(this.labelDescr);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.tbTalentURL);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.numTab);
            this.Controls.Add(this.numTalent);
            this.Controls.Add(this.labelTalent);
            this.Controls.Add(this.labelTab);
            this.Controls.Add(this.numLevel);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labelAssignment);
            this.Controls.Add(this.lbLevelList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTalentTemplates);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 470);
            this.Name = "TalentsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Talents";
            this.Load += new System.EventHandler(this.TalentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTalent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTalentTemplates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbLevelList;
        private System.Windows.Forms.Label labelAssignment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.NumericUpDown numLevel;
        private System.Windows.Forms.Label labelTab;
        private System.Windows.Forms.Label labelTalent;
        private System.Windows.Forms.NumericUpDown numTalent;
        private System.Windows.Forms.NumericUpDown numTab;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.TextBox tbTalentURL;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label labelDescr;
    }
}