namespace ActivityLibrary
{
	partial class EntityFilter
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.cmbFields = new System.Windows.Forms.ComboBox();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.cmbValue = new System.Windows.Forms.TextBox();
            this.chkRemove = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.52665F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.47335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cmbType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbTables, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbFields, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbOperator, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbValue, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkRemove, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(619, 26);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cmbType
            // 
            this.cmbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Entity",
            "SQL"});
            this.cmbType.Location = new System.Drawing.Point(3, 3);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(81, 20);
            this.cmbType.TabIndex = 0;
            // 
            // cmbTables
            // 
            this.cmbTables.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTables.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Items.AddRange(new object[] {
            "SLORDH",
            "PRJOBH",
            "PRSBOM"});
            this.cmbTables.Location = new System.Drawing.Point(90, 3);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(212, 20);
            this.cmbTables.TabIndex = 1;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // cmbFields
            // 
            this.cmbFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFields.FormattingEnabled = true;
            this.cmbFields.Location = new System.Drawing.Point(308, 3);
            this.cmbFields.Name = "cmbFields";
            this.cmbFields.Size = new System.Drawing.Size(120, 20);
            this.cmbFields.TabIndex = 2;
            // 
            // cmbOperator
            // 
            this.cmbOperator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOperator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "<",
            ">",
            "!=",
            "="});
            this.cmbOperator.Location = new System.Drawing.Point(434, 3);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(104, 20);
            this.cmbOperator.TabIndex = 3;
            this.cmbOperator.SelectedIndexChanged += new System.EventHandler(this.cmbOperator_SelectedIndexChanged);
            // 
            // cmbValue
            // 
            this.cmbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbValue.Location = new System.Drawing.Point(544, 3);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.Size = new System.Drawing.Size(50, 21);
            this.cmbValue.TabIndex = 4;
            this.cmbValue.Leave += new System.EventHandler(this.cmbValue_Leave);
            // 
            // chkRemove
            // 
            this.chkRemove.AutoSize = true;
            this.chkRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRemove.Location = new System.Drawing.Point(600, 3);
            this.chkRemove.Name = "chkRemove";
            this.chkRemove.Size = new System.Drawing.Size(16, 20);
            this.chkRemove.TabIndex = 5;
            this.chkRemove.UseVisualStyleBackColor = true;
            // 
            // EntityFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EntityFilter";
            this.Size = new System.Drawing.Size(625, 32);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbType;
        public System.Windows.Forms.ComboBox cmbTables;
        public System.Windows.Forms.ComboBox cmbFields;
        public System.Windows.Forms.ComboBox cmbOperator;
        public System.Windows.Forms.TextBox cmbValue;
        public System.Windows.Forms.CheckBox chkRemove;
	}
}
