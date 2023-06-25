using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using CRD.Common.Enums;

namespace CustomActivityLibrary
{
    public partial class CustomActivityWithCustomActivityCondition: SequenceActivity
	{
		public CustomActivityWithCustomActivityCondition()
		{
			InitializeComponent();
		}

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            ActivityExecutionStatus status = ActivityExecutionStatus.Closed;
            if (MyCustomCondition.Evaluate(executionContext.Activity, executionContext))
                status = base.Execute(executionContext);
            return status;
        }

        public static DependencyProperty MyCustomConditionProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MyCustomCondition", typeof(ActivityCondition), typeof(CustomActivityWithCustomActivityCondition));

        [Description("Description here")]
        [Category("Activity")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(CustomActivityConditionTypeConverter))]
        public ActivityCondition MyCustomCondition
        {
            get
            {
                return ((ActivityCondition)(base.GetValue(CustomActivityWithCustomActivityCondition.MyCustomConditionProperty)));
            }
            set
            {
                base.SetValue(CustomActivityWithCustomActivityCondition.MyCustomConditionProperty, value);
            }
        }
	}
}
