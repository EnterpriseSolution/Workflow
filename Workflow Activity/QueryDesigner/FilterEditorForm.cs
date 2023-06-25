using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace QueryDesigner
{
    public partial class FilterEditorForm : Form
    {
        //------------------------------------------------------------------------------
        #region ** fields

        QueryField _field;
        static Regex _rx1 = new Regex(@"^([^<>=]*)\s*(<|>|=|<>|<=|>=)\s*([^<>=]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        static Regex _rx2 = new Regex(@"^([^<>=]*)\s*BETWEEN\s+(.+)\s+AND\s+(.+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion

        //------------------------------------------------------------------------------
        #region ** ctor

        public FilterEditorForm()
        {
            InitializeComponent();
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** object model

        public QueryField QueryField
        {
            get { return _field; }
            set
            {
                // save query field
                _field = value;

                // initialize value
                string crit = _field.Filter;
                _value.Text = crit;

                // initialize fields
                if (crit.Length > 0)
                {
                    Match m = _rx1.Match(crit);
                    if (m.Success)
                    {
                        _cmbOperator.Text = m.Groups[2].Value;
                        _txtValue.Text = m.Groups[3].Value;
                    }
                    m = _rx2.Match(crit);
                    if (m.Success)
                    {
                        _txtFrom.Text = m.Groups[2].Value;
                        _txtTo.Text = m.Groups[3].Value;
                    }
                }
            }
        }
        public string Value
        {
            get { return _value.Text; }
            set { _value.Text = value; }
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** event handlers

        void _simpleChanged(object sender, System.EventArgs e)
        {
            UpdateSimple();
        }
        void _between_Changed(object sender, System.EventArgs e)
        {
            UpdateBetween();
        }
        void _btnClear_Click(object sender, System.EventArgs e)
        {
            _cmbOperator.SelectedIndex = -1;
            _txtValue.Text = string.Empty;
            _txtFrom.Text = string.Empty;
            _txtTo.Text = string.Empty;
            _value.Text = string.Empty;
        }
        protected override void OnActivated(EventArgs e)
        {
            if (_txtValue.Text.Length > 0)
            {
                _txtValue.Focus();
                _txtValue.SelectAll();
            }
            else if (_txtFrom.Text.Length > 0)
            {
                _txtFrom.Focus();
                _txtFrom.SelectAll();
            }
            base.OnActivated(e);
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** implementation

        void UpdateSimple()
        {
            if (_cmbOperator.SelectedIndex > -1 && _txtValue.Text.Length > 0)
            {
                var parm = GetParameter(_txtValue.Text);
                _value.Text = string.Format("{0} {1}", _cmbOperator.Text, parm);
            }
        }
        void UpdateBetween()
        {
            if (_txtFrom.Text.Length > 0 && _txtTo.Text.Length > 0)
            {
                var parmFrom = GetParameter(_txtFrom.Text);
                var parmTo = GetParameter(_txtTo.Text);
                _value.Text = string.Format("BETWEEN {0} AND {1}", parmFrom, parmTo);
            }
        }
        string GetParameter(string p)
        {
            // if not already in quotes
            if (p.Length < 2 || p[0] != '\'' || p[p.Length - 1] != '\'')
            {
                // and if this is not a number
                double d;
                if (!double.TryParse(p, NumberStyles.Any, CultureInfo.InvariantCulture, out d))
                {
                    // then enclose in quotes
                    p = string.Format("'{0}'", p);
                }
            }

            // done
            return p;
        }

        #endregion

    }
}
