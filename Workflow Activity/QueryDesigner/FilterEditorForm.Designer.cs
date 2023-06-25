namespace QueryDesigner
{
    partial class FilterEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterEditorForm));
            this.label1 = new System.Windows.Forms.Label();
            this._btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._cmbOperator = new System.Windows.Forms.ComboBox();
            this._txtValue = new System.Windows.Forms.TextBox();
            this._value = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtFrom = new System.Windows.Forms.TextBox();
            this._txtTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(204, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 51);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tips:\r\n- Use 0 or 1 instead of True and False;\r\n- Enclose string and date values " +
                "in \'quotes\'.";
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOK.Location = new System.Drawing.Point(256, 177);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(88, 24);
            this._btnOK.TabIndex = 5;
            this._btnOK.Text = "OK";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._cmbOperator);
            this.groupBox1.Controls.Add(this._txtValue);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single value criteria";
            // 
            // _cmbOperator
            // 
            this._cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbOperator.Items.AddRange(new object[] {
            "=",
            ">",
            ">=",
            "<",
            "<=",
            "<>"});
            this._cmbOperator.Location = new System.Drawing.Point(16, 24);
            this._cmbOperator.Name = "_cmbOperator";
            this._cmbOperator.Size = new System.Drawing.Size(56, 21);
            this._cmbOperator.TabIndex = 0;
            this._cmbOperator.SelectedIndexChanged += new System.EventHandler(this._simpleChanged);
            // 
            // _txtValue
            // 
            this._txtValue.Location = new System.Drawing.Point(78, 24);
            this._txtValue.Name = "_txtValue";
            this._txtValue.Size = new System.Drawing.Size(80, 20);
            this._txtValue.TabIndex = 1;
            this._txtValue.TextChanged += new System.EventHandler(this._simpleChanged);
            // 
            // _value
            // 
            this._value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._value.Location = new System.Drawing.Point(9, 138);
            this._value.Name = "_value";
            this._value.Size = new System.Drawing.Size(429, 21);
            this._value.TabIndex = 0;
            this._value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this._txtFrom);
            this.groupBox2.Controls.Add(this._txtTo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 56);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interval criteria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Between";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtFrom
            // 
            this._txtFrom.Location = new System.Drawing.Point(68, 25);
            this._txtFrom.Name = "_txtFrom";
            this._txtFrom.Size = new System.Drawing.Size(80, 20);
            this._txtFrom.TabIndex = 1;
            this._txtFrom.TextChanged += new System.EventHandler(this._between_Changed);
            // 
            // _txtTo
            // 
            this._txtTo.Location = new System.Drawing.Point(185, 25);
            this._txtTo.Name = "_txtTo";
            this._txtTo.Size = new System.Drawing.Size(80, 20);
            this._txtTo.TabIndex = 3;
            this._txtTo.TextChanged += new System.EventHandler(this._between_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "and";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(350, 177);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(88, 24);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Cancel";
            // 
            // _btnClear
            // 
            this._btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnClear.Location = new System.Drawing.Point(12, 177);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(88, 24);
            this._btnClear.TabIndex = 4;
            this._btnClear.Text = "Clear";
            this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
            // 
            // FilterEditorForm
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 210);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._value);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterEditorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Filter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox _cmbOperator;
        private System.Windows.Forms.TextBox _txtValue;
        private System.Windows.Forms.Label _value;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtFrom;
        private System.Windows.Forms.TextBox _txtTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnClear;
    }
}