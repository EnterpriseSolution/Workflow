namespace QueryDesigner
{
    partial class QueryPropertiesDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this._numTopN = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this._cmbGroupBy = new System.Windows.Forms.ComboBox();
            this._chkDistinct = new System.Windows.Forms.CheckBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._numTopN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Top N:";
            // 
            // _numTopN
            // 
            this._numTopN.Location = new System.Drawing.Point(81, 40);
            this._numTopN.Margin = new System.Windows.Forms.Padding(2);
            this._numTopN.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this._numTopN.Name = "_numTopN";
            this._numTopN.Size = new System.Drawing.Size(117, 20);
            this._numTopN.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Group By:";
            // 
            // _cmbGroupBy
            // 
            this._cmbGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbGroupBy.FormattingEnabled = true;
            this._cmbGroupBy.Items.AddRange(new object[] {
            "None",
            "Cube",
            "Rollup",
            "All"});
            this._cmbGroupBy.Location = new System.Drawing.Point(81, 67);
            this._cmbGroupBy.Margin = new System.Windows.Forms.Padding(2);
            this._cmbGroupBy.Name = "_cmbGroupBy";
            this._cmbGroupBy.Size = new System.Drawing.Size(118, 21);
            this._cmbGroupBy.TabIndex = 4;
            // 
            // _chkDistinct
            // 
            this._chkDistinct.AutoSize = true;
            this._chkDistinct.Location = new System.Drawing.Point(11, 11);
            this._chkDistinct.Margin = new System.Windows.Forms.Padding(2);
            this._chkDistinct.Name = "_chkDistinct";
            this._chkDistinct.Size = new System.Drawing.Size(96, 17);
            this._chkDistinct.TabIndex = 0;
            this._chkDistinct.Text = "&Distinct Values";
            this._chkDistinct.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(195, 117);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(70, 22);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(120, 117);
            this._btnOK.Margin = new System.Windows.Forms.Padding(2);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(70, 22);
            this._btnOK.TabIndex = 5;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // QueryPropertiesDialog
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(274, 149);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._chkDistinct);
            this.Controls.Add(this._cmbGroupBy);
            this.Controls.Add(this._numTopN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryPropertiesDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query Properties";
            ((System.ComponentModel.ISupportInitialize)(this._numTopN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _numTopN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cmbGroupBy;
        private System.Windows.Forms.CheckBox _chkDistinct;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
    }
}