using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Host
{
    public partial class SQLEditorForm : Form
    {
        public SQLEditorForm()
        {
            InitializeComponent();
        }
        public string SQL
        {
            get { return rtfSQL.Text; }
        }

        private void SQLEditorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
