using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace QueryDesigner
{
    public partial class QueryDesignerDialog : Form
    {
        //------------------------------------------------------------------------------
        #region ** fields

        QueryBuilder _builder;

        #endregion

        //------------------------------------------------------------------------------
        #region ** ctor

        /// <summary>
        /// Initializes a new instance of a <see cref="QueryDesignerDialog"/>.
        /// </summary>
        public QueryDesignerDialog()
        {
            // designer initialization
            InitializeComponent();

            // create query builder
            _builder = new QueryBuilder(new OleDbSchema());
            _builder.QueryFields.ListChanged += QueryFields_ListChanged;

            // bind grid
            _grid.DataSource = _builder.QueryFields;
            FixGridColumns();

            // update UI
            UpdateGridColumns();
            UpdateTableTree();
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** object model

        /// <summary>
        /// Gets or sets the connection string that represents the underlying database.
        /// </summary>
        public string ConnectionString 
        {
            get { return _builder.ConnectionString; }
            set 
            {
                if (value != ConnectionString)
                {
                    _builder.ConnectionString = value;
                    UpdateTableTree();
                }
            }
        }
        /// <summary>
        /// Gets the SQL statement being built.
        /// </summary>
        public string SelectStatement 
        {
            get { return _builder.Sql; }
            set { }
        }
        /// <summary>
        /// Gets or sets whether the user can change the connection string.
        /// </summary>
        public bool CanChangeConnectionString
        {
            get { return _btnConnString.Visible; }
            set { _btnConnString.Visible = value; }
        }
        
        #endregion

        //------------------------------------------------------------------------------
        #region ** event handlers

        // update SQL statement when query field list changes
        void QueryFields_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateSqlDisplay();
        }

        // commit right away to update SQL
        void _grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // allow user to drag tables and columns from tree
        void _treeTables_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var node = e.Item as TreeNode;
            if (node != null)
            {
                if (node.Tag is DataTable || node.Tag is DataColumn)
                {
                    _treeTables.SelectedNode = node;
                    DoDragDrop(e.Item, DragDropEffects.Copy);
                }
            }
        }

        // allow user to reorder rows by dragging them with the mouse
        void _grid_MouseDown(object sender, MouseEventArgs e)
        {
            // check whether this is a row header
            var ht = _grid.HitTest(e.X, e.Y);
            if (ht.Type == DataGridViewHitTestType.RowHeader)
            {
                // get row index and underlying query field
                var row = _grid.Rows[ht.RowIndex];
                if (row != null)
                {
                    var field = row.DataBoundItem as QueryField;
                    if (field != null)
                    {
                        // select source row and start dragging
                        _grid.CurrentCell = row.Cells[0];
                        if (DoDragDrop(row, DragDropEffects.Move) != DragDropEffects.None)
                        {
                            // select the row in the new position (need timer hack)
                            _timer.Tag = field;
                            _timer.Start();
                        }
                    }
                }
            }
        }

        // ugly hack to select the row after it has been dragged
        void _timer_Tick(object sender, EventArgs e)
        {
            // done with timer
            _timer.Stop();

            // select field
            SelectField(_timer.Tag as QueryField);
        }

        // allow user to drop tables and columns onto grid
        // and to reorder rows by dragging them
        void _grid_DragEnter(object sender, DragEventArgs e)
        {
            // tables and columns
            var node = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            if (node != null)
            {
                if (node.Tag is DataColumn || node.Tag is DataTable)
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }

            // rows
            var row = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
            if (row != null)
            {
                if (_grid.Rows.Contains(row))
                {
                    e.Effect = DragDropEffects.Move;
                    return;
                }
            }
        }

        // provide feedback while dragging rows
        void _grid_DragOver(object sender, DragEventArgs e)
        {
            // rows
            var row = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
            if (row != null)
            {
                var pt = _grid.PointToClient(new Point(e.X, e.Y));
                var ht = _grid.HitTest(pt.X, pt.Y);
                switch (ht.Type)
                {
                    case DataGridViewHitTestType.Cell:
                    case DataGridViewHitTestType.RowHeader:
                    case DataGridViewHitTestType.None: // below all rows
                        e.Effect = DragDropEffects.Move;
                        break;
                    default:
                        e.Effect = DragDropEffects.None;
                        break;
                }
            }
        }

        // add tables and columns to grid
        void _grid_DragDrop(object sender, DragEventArgs e)
        {
            // tables and columns
            var node = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            if (node != null)
            {
                AddField(node.Tag);
                return;
            }

            // reorder fields
            var row = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
            if (row != null)
            {
                // get source and target indices
                var pt = _grid.PointToClient(new Point(e.X, e.Y));
                var ht = _grid.HitTest(pt.X, pt.Y);
                int src = row.Index;
                int dst = ht.RowIndex;

                // negative index means after the last row, so insert as last item
                if (dst < 0)
                {
                    dst = _grid.Rows.Count - 1;
                }

                // move item
                if (src != dst)
                {
                    var fields = _builder.QueryFields;
                    var field = fields[src];
                    fields.RemoveAt(src);
                    fields.Insert(dst, field);
                }

                // done
                return;
            }
        }

        // add columns to query when user double-clicks them
        void _treeTables_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == _treeTables.SelectedNode &&
                e.Node.Tag is DataColumn)
            {
                AddField(e.Node.Tag);
            }
        }

        // handle clicks on filter button by showing the filter editor
        void _grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_grid.Columns[e.ColumnIndex].Name == "Filter" && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                using (var dlg = new FilterEditorForm())
                {
                    var field = _grid.Rows[e.RowIndex].DataBoundItem as QueryField;
                    dlg.Font = Font;
                    dlg.QueryField = field;
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        field.Filter = dlg.Value;
                    }
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** toolstrip commands

        // pick connection string
        void _btnConnString_Click(object sender, EventArgs e)
        {
            ConnectionString = OleDbConnString.EditConnectionString(this, ConnectionString);
        }

        // edit query properties
        void _btnProperties_Click(object sender, EventArgs e)
        {
            using (var dlg = new QueryPropertiesDialog())
            {
                dlg.Font = this.Font;
                dlg.QueryBuilder = _builder;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    UpdateSqlDisplay();
                }
            }
        }

        // toggle GROUPBY
        void _btnGroupBy_Click(object sender, EventArgs e)
        {
            // toggle button
            _btnGroupBy.Checked = !_btnGroupBy.Checked;

            // update sql
            _builder.GroupBy = _btnGroupBy.Checked;
            UpdateSqlDisplay();

            // show/hide the GroupBy column on the grid
            UpdateGridColumns();
        }

        // check current SQL
        void _btnCheckSql_Click(object sender, EventArgs e)
        {
            try
            {
                var da = new OleDbDataAdapter(SelectStatement, ConnectionString);
                var dt = new DataTable();
                da.FillSchema(dt, SchemaType.Mapped);
                MessageBox.Show(this,
                    "The SQL syntax has been verified against the data source.",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception x)
            {
                var msg = string.Format("Failed to retrieve the data:{0}", x.Message);
                MessageBox.Show(this,
                    msg,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // show results for current SQL
        void _btnViewResults_Click(object sender, EventArgs e)
        {
            try
            {
                // get the data
                var da = new OleDbDataAdapter(SelectStatement, ConnectionString);
                var dt = new DataTable("Query");
                da.Fill(dt);

                // show the data
                using (var dlg = new DataPreviewDialog(dt, Font, Size))
                {
                    dlg.ShowDialog(this);
                }
            }
            catch (Exception x)
            {
                var msg = string.Format("Failed to retrieve data:{0}", x.Message);
                MessageBox.Show(this,
                    msg,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // clear the query
        void _btnClearQuery_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                "Are you sure you want to clear this query?",
                Application.ProductName, 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _builder.QueryFields.Clear();
            }
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** tree context-menu event handlers

        void _mnuTree_Opening(object sender, CancelEventArgs e)
        {
            // get node that was clicked
            Point pt = _treeTables.PointToClient(Control.MousePosition);
            TreeNode nd = _treeTables.GetNodeAt(pt);
            DataTable dt = nd == null ? null : nd.Tag as DataTable;

            // select node
            if (nd != null)
            {
                _treeTables.SelectedNode = nd;
            }

            // make sure this is a table node
            if (dt == null)
            {
                e.Cancel = true;
                return;
            }

            // populate related tables menu
            _mnuRelatedTables.DropDownItems.Clear();
            if (nd != null && nd.Tag is DataTable)
            {
                var list = new List<string>();
                foreach (DataRelation dr in _builder.Schema.Relations)
                {
                    if (dr.ParentTable == dt && !list.Contains(dr.ChildTable.TableName))
                    {
                        list.Add(dr.ChildTable.TableName);
                    }
                    else if (dr.ChildTable == dt && !list.Contains(dr.ParentTable.TableName))
                    {
                        list.Add(dr.ParentTable.TableName);
                    }
                }
                list.Sort();
                foreach (string tableName in list)
                {
                    if (FindNode(tableName) != null)
                    {
                        _mnuRelatedTables.DropDownItems.Add(tableName);
                    }
                }
            }
        }
        void _mnuHideThisTable_Click(object sender, EventArgs e)
        {
            var node = _treeTables.SelectedNode;
            if (node != null)
            {
                _treeTables.Nodes.Remove(node);
            }
        }
        void _mnuShowAllTables_Click(object sender, EventArgs e)
        {
            UpdateTableTree();
        }
        void _mnuRelatedTables_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var node = FindNode(e.ClickedItem.Text);
            if (node != null)
            {
                _treeTables.SelectedNode = node;
                node.Expand();
            }
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** implementation

        // for easy access
        OleDbSchema Schema
        {
            get { return _builder.Schema; }
        }

        // update table tree to reflect new connection string
        void UpdateTableTree()
        {
            // initialize table tree
            TreeNodeCollection nodes = _treeTables.Nodes;
            nodes.Clear();
            var ndTables = new TreeNode("Tables", 0, 0);
            var ndViews = new TreeNode("Views", 1, 1);

            // populate using current schema
            if (Schema != null)
            {
                // populate the tree
                _treeTables.BeginUpdate();
                foreach (DataTable dt in Schema.Tables)
                {
                    // create new node, save table in tag property
                    var node = new TreeNode(dt.TableName);
                    node.Tag = dt;

                    // add new node to appropriate parent
                    switch (OleDbSchema.GetTableType(dt))
                    {
                        case TableType.Table:
                            ndTables.Nodes.Add(node);
                            node.ImageIndex = node.SelectedImageIndex = 0;
                            AddDataColumns(node, dt);
                            break;
                        case TableType.View:
                            ndViews.Nodes.Add(node);
                            node.ImageIndex = node.SelectedImageIndex = 1;
                            AddDataColumns(node, dt);
                            break;
                    }
                }

                // add non-empty nodes to tree
                foreach (TreeNode nd in new TreeNode[] { ndTables, ndViews })
                {
                    if (nd.Nodes.Count > 0)
                    {
                        nd.Text = string.Format("{0} ({1})", nd.Text, nd.Nodes.Count);
                        nodes.Add(nd);
                    }
                }

                // expand tables node
                ndTables.Expand();

                // done
                _treeTables.EndUpdate();
            }
        }
        void AddDataColumns(TreeNode node, DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                var field = node.Nodes.Add(col.ColumnName);
                field.Tag = col;
                field.ImageIndex = 2;
                field.SelectedImageIndex = 2;
            }
        }

        // update state of the grid columns
        void UpdateGridColumns()
        {
            _grid.Columns["Column"].Frozen = true;
            _grid.Columns["GroupBy"].Visible = _builder.GroupBy;
        }

        // replace grid columns with ones with better editors
        void FixGridColumns()
        {
            for (int i = 0; i < _grid.Columns.Count; i++)
            {
                var col = _grid.Columns[i];
                if (col.ValueType.IsEnum)
                {
                    // create combo column for enum types
                    var cmb = new DataGridViewComboBoxColumn();
                    cmb.ValueType = col.ValueType;
                    cmb.Name = col.Name;
                    cmb.DataPropertyName = col.DataPropertyName;
                    cmb.HeaderText = col.HeaderText;
                    cmb.DisplayStyleForCurrentCellOnly = true;
                    cmb.DataSource = Enum.GetValues(col.ValueType);
                    cmb.Width = col.Width;

                    // replace original column with new combo column
                    _grid.Columns.RemoveAt(i);
                    _grid.Columns.Insert(i, cmb);
                }
                else if (col.Name == "Filter")
                {
                    var btn = new DataGridViewButtonColumn();
                    btn.ValueType = col.ValueType;
                    btn.Name = col.Name;
                    btn.DataPropertyName = col.DataPropertyName;
                    btn.HeaderText = col.HeaderText;
                    btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    btn.Width = col.Width;

                    // replace original column with new combo column
                    _grid.Columns.RemoveAt(i);
                    _grid.Columns.Insert(i, btn);
                }
            }
        }

        // add tables or columns to the sql statement
        void AddField(object element)
        {
            var dt = element as DataTable;
            if (dt != null)
            {
                AddTable(dt);
            }
            var dc = element as DataColumn;
            if (dc != null)
            {
                AddColumn(dc);
            }
        }
        void AddTable(DataTable dt)
        {
            var field = new QueryField(dt);
            _builder.QueryFields.Add(field);
            SelectField(field);
        }
        void AddColumn(DataColumn dc)
        {
            var field = new QueryField(dc);
            _builder.QueryFields.Add(field);
            SelectField(field);
        }

        // select a field on the grid
        void SelectField(QueryField field)
        {
            var cm = BindingContext[_grid.DataSource] as CurrencyManager;
            cm.Position = cm.List.IndexOf(field);
        }

        // find a node on the tree
        TreeNode FindNode(string text)
        {
            return FindNode(_treeTables.Nodes, text);
        }
        TreeNode FindNode(TreeNodeCollection nodes, string text)
        {
            foreach (TreeNode node in nodes)
            {
                // check this node
                var dt = node.Tag as DataTable;
                if (dt != null && dt.TableName == text)
                {
                    return node;
                }

                // and check child nodes
                var child = FindNode(node.Nodes, text);
                if (child != null)
                {
                    return child;
                }
            }

            // not found...
            return null;
        }

        // update SQL display
        void UpdateSqlDisplay()
        {
            _txtSql.Text = _builder.Sql;
            _lblStatus.Visible = _builder.MissingJoins;
        }

        #endregion
    }
}
