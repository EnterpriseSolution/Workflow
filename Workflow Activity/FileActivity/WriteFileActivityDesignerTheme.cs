using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Design;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Host
{
	public class WriteFileActivityDesignerTheme : ActivityDesignerTheme
	{
        public WriteFileActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
        }

        public override void Initialize()
        {
            this.ForeColor = Color.Black;
            this.BorderColor = Color.Black;
            this.BorderStyle = DashStyle.Solid;
            this.BackgroundStyle = LinearGradientMode.Vertical;
            this.BackColorStart = Color.White;
            this.BackColorEnd = Color.LightGray;

            base.Initialize();
        }
	}
}
