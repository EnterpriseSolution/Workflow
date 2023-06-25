using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QueryDesigner
{
    public partial class DataPreviewDialog : Form
    {
        //------------------------------------------------------------------------------
        #region ** ctors

        public DataPreviewDialog()
        {
            InitializeComponent();
        }
        public DataPreviewDialog(DataTable dt, Font font, Size size)
            : this()
        {
            Font = font;
            Size = size;
            _grid.DataSource = dt;
            Text = string.Format(Text, dt.TableName, dt.Rows.Count);
        }

        #endregion

        //------------------------------------------------------------------------------
        #region ** implementation

        // close preview form when user presses escape
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        #endregion
    }
}
