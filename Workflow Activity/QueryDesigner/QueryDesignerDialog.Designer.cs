namespace QueryDesigner
{
    partial class QueryDesignerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryDesignerDialog));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._btnConnString = new System.Windows.Forms.ToolStripButton();
            this._btnGroupBy = new System.Windows.Forms.ToolStripButton();
            this._btnProperties = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btnCheckSql = new System.Windows.Forms.ToolStripButton();
            this._btnViewResults = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._btnClearQuery = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._treeTables = new System.Windows.Forms.TreeView();
            this._mnuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._mnuHideThisTable = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuShowAllTables = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._mnuRelatedTables = new System.Windows.Forms.ToolStripMenuItem();
            this._imgList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._grid = new System.Windows.Forms.DataGridView();
            this._txtSql = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._lblStatus = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._toolStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this._mnuTree.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnConnString,
            this._btnGroupBy,
            this._btnProperties,
            this.toolStripSeparator1,
            this._btnCheckSql,
            this._btnViewResults,
            this.toolStripSeparator2,
            this._btnClearQuery});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(580, 25);
            this._toolStrip.TabIndex = 0;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _btnConnString
            // 
            this._btnConnString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnConnString.Image = ((System.Drawing.Image)(resources.GetObject("_btnConnString.Image")));
            this._btnConnString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnConnString.Name = "_btnConnString";
            this._btnConnString.Size = new System.Drawing.Size(23, 22);
            this._btnConnString.Text = "Select connection string";
            this._btnConnString.Visible = false;
            this._btnConnString.Click += new System.EventHandler(this._btnConnString_Click);
            // 
            // _btnGroupBy
            // 
            this._btnGroupBy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnGroupBy.Image = ((System.Drawing.Image)(resources.GetObject("_btnGroupBy.Image")));
            this._btnGroupBy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGroupBy.Name = "_btnGroupBy";
            this._btnGroupBy.Size = new System.Drawing.Size(23, 22);
            this._btnGroupBy.Text = "Group results";
            this._btnGroupBy.Click += new System.EventHandler(this._btnGroupBy_Click);
            // 
            // _btnProperties
            // 
            this._btnProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnProperties.Image = ((System.Drawing.Image)(resources.GetObject("_btnProperties.Image")));
            this._btnProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnProperties.Name = "_btnProperties";
            this._btnProperties.Size = new System.Drawing.Size(23, 22);
            this._btnProperties.Text = "Query properties";
            this._btnProperties.Click += new System.EventHandler(this._btnProperties_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _btnCheckSql
            // 
            this._btnCheckSql.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnCheckSql.Image = ((System.Drawing.Image)(resources.GetObject("_btnCheckSql.Image")));
            this._btnCheckSql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCheckSql.Name = "_btnCheckSql";
            this._btnCheckSql.Size = new System.Drawing.Size(23, 22);
            this._btnCheckSql.Text = "Check SQL syntax";
            this._btnCheckSql.Click += new System.EventHandler(this._btnCheckSql_Click);
            // 
            // _btnViewResults
            // 
            this._btnViewResults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnViewResults.Image = ((System.Drawing.Image)(resources.GetObject("_btnViewResults.Image")));
            this._btnViewResults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnViewResults.Name = "_btnViewResults";
            this._btnViewResults.Size = new System.Drawing.Size(23, 22);
            this._btnViewResults.Text = "View query results";
            this._btnViewResults.Click += new System.EventHandler(this._btnViewResults_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _btnClearQuery
            // 
            this._btnClearQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnClearQuery.Image = ((System.Drawing.Image)(resources.GetObject("_btnClearQuery.Image")));
            this._btnClearQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnClearQuery.Name = "_btnClearQuery";
            this._btnClearQuery.Size = new System.Drawing.Size(23, 22);
            this._btnClearQuery.Text = "Clear query";
            this._btnClearQuery.Click += new System.EventHandler(this._btnClearQuery_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._treeTables);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(580, 272);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // _treeTables
            // 
            this._treeTables.ContextMenuStrip = this._mnuTree;
            this._treeTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeTables.ImageIndex = 0;
            this._treeTables.ImageList = this._imgList;
            this._treeTables.Location = new System.Drawing.Point(0, 0);
            this._treeTables.Margin = new System.Windows.Forms.Padding(2);
            this._treeTables.Name = "_treeTables";
            this._treeTables.SelectedImageIndex = 0;
            this._treeTables.Size = new System.Drawing.Size(233, 272);
            this._treeTables.TabIndex = 0;
            this._treeTables.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this._treeTables_ItemDrag);
            this._treeTables.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeTables_NodeMouseDoubleClick);
            // 
            // _mnuTree
            // 
            this._mnuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuHideThisTable,
            this._mnuShowAllTables,
            this.toolStripMenuItem1,
            this._mnuRelatedTables});
            this._mnuTree.Name = "_mnuTree";
            this._mnuTree.Size = new System.Drawing.Size(153, 76);
            this._mnuTree.Opening += new System.ComponentModel.CancelEventHandler(this._mnuTree_Opening);
            // 
            // _mnuHideThisTable
            // 
            this._mnuHideThisTable.Name = "_mnuHideThisTable";
            this._mnuHideThisTable.Size = new System.Drawing.Size(152, 22);
            this._mnuHideThisTable.Text = "Hide this table";
            this._mnuHideThisTable.Click += new System.EventHandler(this._mnuHideThisTable_Click);
            // 
            // _mnuShowAllTables
            // 
            this._mnuShowAllTables.Name = "_mnuShowAllTables";
            this._mnuShowAllTables.Size = new System.Drawing.Size(152, 22);
            this._mnuShowAllTables.Text = "Show all tables";
            this._mnuShowAllTables.Click += new System.EventHandler(this._mnuShowAllTables_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // _mnuRelatedTables
            // 
            this._mnuRelatedTables.Name = "_mnuRelatedTables";
            this._mnuRelatedTables.Size = new System.Drawing.Size(152, 22);
            this._mnuRelatedTables.Text = "Related tables";
            this._mnuRelatedTables.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._mnuRelatedTables_DropDownItemClicked);
            // 
            // _imgList
            // 
            this._imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imgList.ImageStream")));
            this._imgList.TransparentColor = System.Drawing.Color.Red;
            this._imgList.Images.SetKeyName(0, "Table.png");
            this._imgList.Images.SetKeyName(1, "View.png");
            this._imgList.Images.SetKeyName(2, "Field.png");
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._grid);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._txtSql);
            this.splitContainer2.Size = new System.Drawing.Size(344, 272);
            this.splitContainer2.SplitterDistance = 147;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // _grid
            // 
            this._grid.AllowDrop = true;
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Margin = new System.Windows.Forms.Padding(2);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.RowTemplate.Height = 24;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(344, 147);
            this._grid.TabIndex = 0;
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellClick);
            this._grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellEndEdit);
            this._grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellEndEdit);
            this._grid.DragDrop += new System.Windows.Forms.DragEventHandler(this._grid_DragDrop);
            this._grid.DragEnter += new System.Windows.Forms.DragEventHandler(this._grid_DragEnter);
            this._grid.DragOver += new System.Windows.Forms.DragEventHandler(this._grid_DragOver);
            this._grid.MouseDown += new System.Windows.Forms.MouseEventHandler(this._grid_MouseDown);
            // 
            // _txtSql
            // 
            this._txtSql.BackColor = System.Drawing.SystemColors.Window;
            this._txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtSql.Location = new System.Drawing.Point(0, 0);
            this._txtSql.Margin = new System.Windows.Forms.Padding(2);
            this._txtSql.Multiline = true;
            this._txtSql.Name = "_txtSql";
            this._txtSql.ReadOnly = true;
            this._txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtSql.Size = new System.Drawing.Size(344, 122);
            this._txtSql.TabIndex = 0;
            this._txtSql.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._lblStatus);
            this.panel1.Controls.Add(this._btnCancel);
            this.panel1.Controls.Add(this._btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 297);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 33);
            this.panel1.TabIndex = 3;
            // 
            // _lblStatus
            // 
            this._lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lblStatus.Location = new System.Drawing.Point(10, 6);
            this._lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(410, 22);
            this._lblStatus.TabIndex = 8;
            this._lblStatus.Text = "Warning: not all tables in the query are related.";
            this._lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblStatus.Visible = false;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(501, 6);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(70, 22);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(425, 6);
            this._btnOK.Margin = new System.Windows.Forms.Padding(2);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(70, 22);
            this._btnOK.TabIndex = 6;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _timer
            // 
            this._timer.Interval = 10;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // QueryDesignerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(580, 330);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QueryDesignerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query Designer";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this._mnuTree.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView _treeTables;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _txtSql;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.ToolStripButton _btnProperties;
        private System.Windows.Forms.ToolStripButton _btnGroupBy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _btnCheckSql;
        private System.Windows.Forms.ToolStripButton _btnViewResults;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _btnClearQuery;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.ImageList _imgList;
        private System.Windows.Forms.ToolStripButton _btnConnString;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.ContextMenuStrip _mnuTree;
        private System.Windows.Forms.ToolStripMenuItem _mnuHideThisTable;
        private System.Windows.Forms.ToolStripMenuItem _mnuShowAllTables;
        private System.Windows.Forms.ToolStripMenuItem _mnuRelatedTables;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}