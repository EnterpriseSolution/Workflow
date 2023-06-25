#region Using Directives
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

#endregion

namespace Host
{
    [ToolboxItem(typeof(MyActivityToolboxItem))]
    [ToolboxBitmap(typeof(WriteFileActivity), "Resources.write.ico")]
    [Designer(typeof(WriteFileActivityDesigner), typeof(IDesigner))]
    [ActivityValidator(typeof(WriteFileActivityValidator))]
    public class WriteFileActivity : Activity
    {
        public static DependencyProperty FileTextProperty = 
            DependencyProperty.Register("FileText", typeof(string), typeof(WriteFileActivity));

        [Description("The text to write to the file")]
        [Category("File")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string FileText
        {
            get
            {
                return ((string)(base.GetValue(WriteFileActivity.FileTextProperty)));
            }
            set
            {
                base.SetValue(WriteFileActivity.FileTextProperty, value);
            }
        }

        public static DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(WriteFileActivity));

        [Description("The file to write to")]
        [Category("File")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string FileName
        {
            get
            {
                return ((string)(base.GetValue(WriteFileActivity.FileNameProperty)));
            }
            set
            {
                base.SetValue(WriteFileActivity.FileNameProperty, value);
            }
        }

		public WriteFileActivity()
		{
		}

        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            StreamWriter writer = File.CreateText(this.FileName);
            writer.Write(this.FileText);
            writer.Flush();
            writer.Close();

            return ActivityExecutionStatus.Closed;
        }
	}
}
