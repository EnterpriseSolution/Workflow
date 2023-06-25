using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QueryDesigner
{
    public partial class QueryPropertiesDialog : Form
    {
        //------------------------------------------------------------------------------
        #region ** fields

        QueryBuilder _builder;

        #endregion

        //------------------------------------------------------------------------------
        #region ** ctor

        public QueryPropertiesDialog()
        {
            InitializeComponent();
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** object model

        public QueryBuilder QueryBuilder
        {
            get { return _builder; }
            set 
            {
                if (_builder != value)
                {
                    _builder = value;
                    UpdateDialogValues();
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** event handlers

        void _btnOK_Click(object sender, EventArgs e)
        {
            UpdateBuilderValues();
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** implementation

        // copy QueryBuilder values to form 
        void UpdateDialogValues()
        {
            _numTopN.Value = _builder.Top;
            if (_builder.GroupBy)
            {
                _cmbGroupBy.SelectedIndex = (int)_builder.GroupByExtension;
            }
            else
            {
                _cmbGroupBy.Enabled = false;
            }
            _chkDistinct.Checked = _builder.Distinct;
        }

        // copy form values to QueryBuilder
        void UpdateBuilderValues()
        {
            _builder.Top = (int)_numTopN.Value;
            if (_builder.GroupBy)
            {
                _builder.GroupByExtension = (GroupByExtension)_cmbGroupBy.SelectedIndex;
            }
            _builder.Distinct = _chkDistinct.Checked;
        }

        #endregion
    }
}
