namespace PDFTemplate
{
    partial class frmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvMessages = new System.Windows.Forms.ListView();
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmMessages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miClear = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMessages = new System.Windows.Forms.Label();
            this.txtElement = new System.Windows.Forms.TextBox();
            this.lblElement = new System.Windows.Forms.Label();
            this.btnAddElement = new System.Windows.Forms.Button();
            this.dlgTemplate = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.btnSearchForm = new System.Windows.Forms.Button();
            this.lblFormPath = new System.Windows.Forms.Label();
            this.txtFormPath = new System.Windows.Forms.TextBox();
            this.dlgSearchForm = new System.Windows.Forms.OpenFileDialog();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.btnSearchTemplate = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
            this.btnProperties = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.btnFill = new System.Windows.Forms.Button();
            this.cbAutoFill = new System.Windows.Forms.CheckBox();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.btnGroup = new System.Windows.Forms.Button();
            this.lblFieldSet = new System.Windows.Forms.Label();
            this.txtSetValues = new System.Windows.Forms.TextBox();
            this.btnFieldsSetFill = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbPager = new System.Windows.Forms.CheckBox();
            this.cbGroupIdx = new System.Windows.Forms.ComboBox();
            this.cmMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvMessages
            // 
            this.lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTime,
            this.chMessage});
            this.lvMessages.ContextMenuStrip = this.cmMessages;
            this.lvMessages.Location = new System.Drawing.Point(12, 27);
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(666, 408);
            this.lvMessages.TabIndex = 0;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.Details;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            // 
            // chMessage
            // 
            this.chMessage.Text = "Message";
            // 
            // cmMessages
            // 
            this.cmMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClear});
            this.cmMessages.Name = "cmMessages";
            this.cmMessages.Size = new System.Drawing.Size(102, 26);
            this.cmMessages.Opening += new System.ComponentModel.CancelEventHandler(this.cmMessages_Opening);
            // 
            // miClear
            // 
            this.miClear.Name = "miClear";
            this.miClear.Size = new System.Drawing.Size(101, 22);
            this.miClear.Text = "Clear";
            this.miClear.Click += new System.EventHandler(this.miClear_Click);
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.Location = new System.Drawing.Point(13, 8);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(58, 13);
            this.lblMessages.TabIndex = 1;
            this.lblMessages.Text = "Messages:";
            // 
            // txtElement
            // 
            this.txtElement.Location = new System.Drawing.Point(69, 441);
            this.txtElement.Name = "txtElement";
            this.txtElement.Size = new System.Drawing.Size(473, 20);
            this.txtElement.TabIndex = 2;
            // 
            // lblElement
            // 
            this.lblElement.AutoSize = true;
            this.lblElement.Location = new System.Drawing.Point(9, 445);
            this.lblElement.Name = "lblElement";
            this.lblElement.Size = new System.Drawing.Size(45, 13);
            this.lblElement.TabIndex = 3;
            this.lblElement.Text = "Element";
            // 
            // btnAddElement
            // 
            this.btnAddElement.Location = new System.Drawing.Point(654, 440);
            this.btnAddElement.Name = "btnAddElement";
            this.btnAddElement.Size = new System.Drawing.Size(24, 21);
            this.btnAddElement.TabIndex = 4;
            this.btnAddElement.Text = "+";
            this.btnAddElement.UseVisualStyleBackColor = true;
            this.btnAddElement.Click += new System.EventHandler(this.btnAddElement_Click);
            // 
            // dlgTemplate
            // 
            this.dlgTemplate.DefaultExt = "*.xml";
            this.dlgTemplate.Filter = "Acrobat PDF form|*.pdf|Template XML file|*.xml|Any file|*.*";
            this.dlgTemplate.FilterIndex = 2;
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.Font = new System.Drawing.Font("Webdings", 8.25F);
            this.btnSaveTemplate.Location = new System.Drawing.Point(654, 492);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(24, 21);
            this.btnSaveTemplate.TabIndex = 5;
            this.btnSaveTemplate.Text = "Í";
            this.btnSaveTemplate.UseVisualStyleBackColor = true;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // btnSearchForm
            // 
            this.btnSearchForm.Location = new System.Drawing.Point(654, 466);
            this.btnSearchForm.Name = "btnSearchForm";
            this.btnSearchForm.Size = new System.Drawing.Size(24, 21);
            this.btnSearchForm.TabIndex = 8;
            this.btnSearchForm.Text = "...";
            this.btnSearchForm.UseVisualStyleBackColor = true;
            this.btnSearchForm.Click += new System.EventHandler(this.btnSearchForm_Click);
            // 
            // lblFormPath
            // 
            this.lblFormPath.AutoSize = true;
            this.lblFormPath.Location = new System.Drawing.Point(9, 471);
            this.lblFormPath.Name = "lblFormPath";
            this.lblFormPath.Size = new System.Drawing.Size(30, 13);
            this.lblFormPath.TabIndex = 7;
            this.lblFormPath.Text = "Form";
            // 
            // txtFormPath
            // 
            this.txtFormPath.Location = new System.Drawing.Point(69, 467);
            this.txtFormPath.Name = "txtFormPath";
            this.txtFormPath.Size = new System.Drawing.Size(579, 20);
            this.txtFormPath.TabIndex = 6;
            // 
            // dlgSearchForm
            // 
            this.dlgSearchForm.Filter = "Acrobat PDF form|*.pdf|Template XML file|*.xml|Any file|*.*";
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(9, 497);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(51, 13);
            this.lblTemplate.TabIndex = 9;
            this.lblTemplate.Text = "Template";
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Location = new System.Drawing.Point(69, 493);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.Size = new System.Drawing.Size(519, 20);
            this.txtTemplatePath.TabIndex = 10;
            // 
            // btnSearchTemplate
            // 
            this.btnSearchTemplate.Location = new System.Drawing.Point(624, 492);
            this.btnSearchTemplate.Name = "btnSearchTemplate";
            this.btnSearchTemplate.Size = new System.Drawing.Size(24, 21);
            this.btnSearchTemplate.TabIndex = 11;
            this.btnSearchTemplate.Text = "...";
            this.btnSearchTemplate.UseVisualStyleBackColor = true;
            this.btnSearchTemplate.Click += new System.EventHandler(this.btnSearchTemplate_Click);
            // 
            // btnDump
            // 
            this.btnDump.Location = new System.Drawing.Point(624, 519);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(54, 21);
            this.btnDump.TabIndex = 12;
            this.btnDump.Text = "Dump";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // btnProperties
            // 
            this.btnProperties.Font = new System.Drawing.Font("Webdings", 8.25F);
            this.btnProperties.Location = new System.Drawing.Point(594, 492);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(24, 21);
            this.btnProperties.TabIndex = 13;
            this.btnProperties.Text = "";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(69, 519);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(456, 20);
            this.txtDestination.TabIndex = 14;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(9, 523);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(60, 13);
            this.lblDestination.TabIndex = 15;
            this.lblDestination.Text = "Destination";
            // 
            // btnFill
            // 
            this.btnFill.Font = new System.Drawing.Font("Webdings", 8.25F);
            this.btnFill.Location = new System.Drawing.Point(594, 519);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(24, 21);
            this.btnFill.TabIndex = 16;
            this.btnFill.Text = "Í";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // cbAutoFill
            // 
            this.cbAutoFill.AutoSize = true;
            this.cbAutoFill.Location = new System.Drawing.Point(531, 522);
            this.cbAutoFill.Name = "cbAutoFill";
            this.cbAutoFill.Size = new System.Drawing.Size(57, 17);
            this.cbAutoFill.TabIndex = 17;
            this.cbAutoFill.Text = "Autofill";
            this.cbAutoFill.UseVisualStyleBackColor = true;
            // 
            // ddlType
            // 
            this.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Location = new System.Drawing.Point(548, 441);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(100, 21);
            this.ddlType.TabIndex = 18;
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(624, 545);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(54, 21);
            this.btnGroup.TabIndex = 19;
            this.btnGroup.Text = "+ Group";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // lblFieldSet
            // 
            this.lblFieldSet.AutoSize = true;
            this.lblFieldSet.Location = new System.Drawing.Point(9, 549);
            this.lblFieldSet.Name = "lblFieldSet";
            this.lblFieldSet.Size = new System.Drawing.Size(101, 13);
            this.lblFieldSet.TabIndex = 21;
            this.lblFieldSet.Text = "Group id / set value";
            // 
            // txtSetValues
            // 
            this.txtSetValues.Location = new System.Drawing.Point(191, 545);
            this.txtSetValues.Name = "txtSetValues";
            this.txtSetValues.Size = new System.Drawing.Size(271, 20);
            this.txtSetValues.TabIndex = 20;
            // 
            // btnFieldsSetFill
            // 
            this.btnFieldsSetFill.Location = new System.Drawing.Point(531, 545);
            this.btnFieldsSetFill.Name = "btnFieldsSetFill";
            this.btnFieldsSetFill.Size = new System.Drawing.Size(24, 21);
            this.btnFieldsSetFill.TabIndex = 22;
            this.btnFieldsSetFill.Text = "=";
            this.btnFieldsSetFill.UseVisualStyleBackColor = true;
            this.btnFieldsSetFill.Click += new System.EventHandler(this.btnFieldsSetFill_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(561, 545);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 21);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbPager
            // 
            this.cbPager.AutoSize = true;
            this.cbPager.Location = new System.Drawing.Point(468, 548);
            this.cbPager.Name = "cbPager";
            this.cbPager.Size = new System.Drawing.Size(54, 17);
            this.cbPager.TabIndex = 26;
            this.cbPager.Text = "Pager";
            this.cbPager.UseVisualStyleBackColor = true;
            // 
            // cbGroupIdx
            // 
            this.cbGroupIdx.FormattingEnabled = true;
            this.cbGroupIdx.Location = new System.Drawing.Point(113, 544);
            this.cbGroupIdx.Name = "cbGroupIdx";
            this.cbGroupIdx.Size = new System.Drawing.Size(72, 21);
            this.cbGroupIdx.TabIndex = 27;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 604);
            this.Controls.Add(this.cbGroupIdx);
            this.Controls.Add(this.cbPager);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFieldsSetFill);
            this.Controls.Add(this.lblFieldSet);
            this.Controls.Add(this.txtSetValues);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.ddlType);
            this.Controls.Add(this.cbAutoFill);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.btnProperties);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.btnSearchTemplate);
            this.Controls.Add(this.txtTemplatePath);
            this.Controls.Add(this.lblTemplate);
            this.Controls.Add(this.btnSearchForm);
            this.Controls.Add(this.lblFormPath);
            this.Controls.Add(this.txtFormPath);
            this.Controls.Add(this.btnSaveTemplate);
            this.Controls.Add(this.btnAddElement);
            this.Controls.Add(this.lblElement);
            this.Controls.Add(this.txtElement);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.lvMessages);
            this.Name = "frmMain";
            this.Text = "Template";
            this.Load += new System.EventHandler(this.Main_Load);
            this.cmMessages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMessages;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.TextBox txtElement;
        private System.Windows.Forms.Label lblElement;
        private System.Windows.Forms.Button btnAddElement;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chMessage;
        private System.Windows.Forms.SaveFileDialog dlgTemplate;
        private System.Windows.Forms.Button btnSaveTemplate;
        private System.Windows.Forms.ContextMenuStrip cmMessages;
        private System.Windows.Forms.ToolStripMenuItem miClear;
        private System.Windows.Forms.Button btnSearchForm;
        private System.Windows.Forms.Label lblFormPath;
        private System.Windows.Forms.TextBox txtFormPath;
        private System.Windows.Forms.OpenFileDialog dlgSearchForm;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.Button btnSearchTemplate;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.CheckBox cbAutoFill;
        private System.Windows.Forms.ComboBox ddlType;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Label lblFieldSet;
        private System.Windows.Forms.TextBox txtSetValues;
        private System.Windows.Forms.Button btnFieldsSetFill;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbPager;
        private System.Windows.Forms.ComboBox cbGroupIdx;
    }
}

