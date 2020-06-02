namespace PDFTemplate
{
    partial class dlgGroup
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
            this.components = new System.ComponentModel.Container();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblField = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvFields = new System.Windows.Forms.ListView();
            this.chPos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdFields = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRemoveField = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miClear = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLowIndex = new System.Windows.Forms.Label();
            this.lblHighIndex = new System.Windows.Forms.Label();
            this.nudLowIndex = new System.Windows.Forms.NumericUpDown();
            this.nudHighIndex = new System.Windows.Forms.NumericUpDown();
            this.cbFieldId = new System.Windows.Forms.ComboBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.cmdFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLowIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHighIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(64, 363);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(145, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(9, 92);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(40, 13);
            this.lblField.TabIndex = 4;
            this.lblField.Text = "Field id";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(248, 87);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvFields
            // 
            this.lvFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPos,
            this.chField});
            this.lvFields.ContextMenuStrip = this.cmdFields;
            this.lvFields.FullRowSelect = true;
            this.lvFields.Location = new System.Drawing.Point(12, 115);
            this.lvFields.Name = "lvFields";
            this.lvFields.Size = new System.Drawing.Size(260, 242);
            this.lvFields.TabIndex = 6;
            this.lvFields.UseCompatibleStateImageBehavior = false;
            this.lvFields.View = System.Windows.Forms.View.Details;
            this.lvFields.VirtualMode = true;
            this.lvFields.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvFields_RetrieveVirtualItem);
            // 
            // chPos
            // 
            this.chPos.Text = "Pos.";
            // 
            // chField
            // 
            this.chField.Text = "Field id";
            this.chField.Width = 167;
            // 
            // cmdFields
            // 
            this.cmdFields.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRemoveField,
            this.toolStripMenuItem1,
            this.miClear});
            this.cmdFields.Name = "cmdFields";
            this.cmdFields.Size = new System.Drawing.Size(144, 54);
            this.cmdFields.Opening += new System.ComponentModel.CancelEventHandler(this.cmdFields_Opening);
            // 
            // miRemoveField
            // 
            this.miRemoveField.Name = "miRemoveField";
            this.miRemoveField.Size = new System.Drawing.Size(143, 22);
            this.miRemoveField.Text = "Remove field";
            this.miRemoveField.Click += new System.EventHandler(this.miRemoveField_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // miClear
            // 
            this.miClear.Name = "miClear";
            this.miClear.Size = new System.Drawing.Size(143, 22);
            this.miClear.Text = "Clear";
            this.miClear.Click += new System.EventHandler(this.miClear_Click);
            // 
            // lblLowIndex
            // 
            this.lblLowIndex.AutoSize = true;
            this.lblLowIndex.Location = new System.Drawing.Point(9, 37);
            this.lblLowIndex.Name = "lblLowIndex";
            this.lblLowIndex.Size = new System.Drawing.Size(55, 13);
            this.lblLowIndex.TabIndex = 8;
            this.lblLowIndex.Text = "Low index";
            // 
            // lblHighIndex
            // 
            this.lblHighIndex.AutoSize = true;
            this.lblHighIndex.Location = new System.Drawing.Point(9, 63);
            this.lblHighIndex.Name = "lblHighIndex";
            this.lblHighIndex.Size = new System.Drawing.Size(57, 13);
            this.lblHighIndex.TabIndex = 10;
            this.lblHighIndex.Text = "High index";
            // 
            // nudLowIndex
            // 
            this.nudLowIndex.Location = new System.Drawing.Point(79, 35);
            this.nudLowIndex.Name = "nudLowIndex";
            this.nudLowIndex.Size = new System.Drawing.Size(103, 20);
            this.nudLowIndex.TabIndex = 11;
            // 
            // nudHighIndex
            // 
            this.nudHighIndex.Location = new System.Drawing.Point(79, 61);
            this.nudHighIndex.Name = "nudHighIndex";
            this.nudHighIndex.Size = new System.Drawing.Size(103, 20);
            this.nudHighIndex.TabIndex = 12;
            // 
            // cbFieldId
            // 
            this.cbFieldId.FormattingEnabled = true;
            this.cbFieldId.Location = new System.Drawing.Point(79, 87);
            this.cbFieldId.Name = "cbFieldId";
            this.cbFieldId.Size = new System.Drawing.Size(163, 21);
            this.cbFieldId.TabIndex = 13;
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(9, 12);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(65, 13);
            this.lblGroupName.TabIndex = 17;
            this.lblGroupName.Text = "Group name";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(79, 9);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(103, 20);
            this.txtGroupName.TabIndex = 16;
            // 
            // dlgGroup
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 398);
            this.ControlBox = false;
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.cbFieldId);
            this.Controls.Add(this.nudHighIndex);
            this.Controls.Add(this.nudLowIndex);
            this.Controls.Add(this.lblHighIndex);
            this.Controls.Add(this.lblLowIndex);
            this.Controls.Add(this.lvFields);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgGroup";
            this.Text = "Define group";
            this.Load += new System.EventHandler(this.dlgGroup_Load);
            this.cmdFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLowIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHighIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvFields;
        private System.Windows.Forms.ColumnHeader chPos;
        private System.Windows.Forms.ColumnHeader chField;
        private System.Windows.Forms.ContextMenuStrip cmdFields;
        private System.Windows.Forms.ToolStripMenuItem miRemoveField;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miClear;
        private System.Windows.Forms.Label lblLowIndex;
        private System.Windows.Forms.Label lblHighIndex;
        private System.Windows.Forms.NumericUpDown nudLowIndex;
        private System.Windows.Forms.NumericUpDown nudHighIndex;
        private System.Windows.Forms.ComboBox cbFieldId;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGroupName;
    }
}