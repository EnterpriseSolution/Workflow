using System;
using System.Collections.Generic;
using System.Workflow.ComponentModel;
using System.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Drawing;
using System.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.Activities;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using ActivityLibrary;
using System.Windows.Forms;
using CustomActivityLibrary;
using System.Collections.Specialized;

namespace Host
{
    [ToolboxBitmap(typeof(AvatarIfElseActivity), "Resources.Decision.png"), 
    Description("ConditionalActivityDescription"), 
    ActivityValidator(typeof(AvatarIfElseValidator)), Category("Standard"), 
    ToolboxItem(typeof(AvatarIfElseToolboxItem)), 
    Designer(typeof(AvatarIfElseDesigner), typeof(IDesigner))]
    public sealed class AvatarIfElseActivity : CompositeActivity, IActivityEventListener<ActivityExecutionStatusChangedEventArgs>
    {        
        public AvatarIfElseActivity()
        {
        }

        public AvatarIfElseActivity(string name)
            : base(name)
        {
        }

        public AvatarIfElseBranchActivity AddBranch(ICollection<Activity> activities)
        {
            if (activities == null)
            {
                throw new ArgumentNullException("activities");
            }
            return this.AddBranch(activities, null);
        }

        public AvatarIfElseBranchActivity AddBranch(ICollection<Activity> activities, ActivityCondition branchCondition)
        {
            if (activities == null)
            {
                throw new ArgumentNullException("activities");
            }
            if (!base.DesignMode)
            {
                throw new InvalidOperationException("Error_ConditionalBranchUpdateAtRuntime");
            }
            AvatarIfElseBranchActivity item = new AvatarIfElseBranchActivity();
            foreach (Activity activity2 in activities)
            {
                item.Activities.Add(activity2);
            }
            item.Condition = branchCondition;
            base.Activities.Add(item);
            return item;
        }

        protected override ActivityExecutionStatus Cancel(ActivityExecutionContext executionContext)
        {
            bool flag = true;
            for (int i = 0; i < base.EnabledActivities.Count; i++)
            {
                Activity activity = base.EnabledActivities[i];
                if (activity.ExecutionStatus == ActivityExecutionStatus.Executing)
                {
                    flag = false;
                    executionContext.CancelActivity(activity);
                    break;
                }
                if ((activity.ExecutionStatus == ActivityExecutionStatus.Canceling) || (activity.ExecutionStatus == ActivityExecutionStatus.Faulting))
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                return ActivityExecutionStatus.Canceling;
            }
            return ActivityExecutionStatus.Closed;
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }
            bool flag = true;
            for (int i = 0; i < base.EnabledActivities.Count; i++)
            {
                AvatarIfElseBranchActivity activity = base.EnabledActivities[i] as AvatarIfElseBranchActivity;
                if ((activity.Condition == null) || activity.Condition.Evaluate(activity, executionContext))
                {
                    flag = false;
                    activity.RegisterForStatusChange(Activity.ClosedEvent, this);
                    executionContext.ExecuteActivity(activity);
                    break;
                }
            }
            if (!flag)
            {
                return ActivityExecutionStatus.Executing;
            }
            return ActivityExecutionStatus.Closed;
        }

        void IActivityEventListener<ActivityExecutionStatusChangedEventArgs>.OnEvent(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("sender");
            }
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }
            ActivityExecutionContext context = sender as ActivityExecutionContext;
            if (context == null)
            {
                throw new ArgumentException("Error_SenderMustBeActivityExecutionContext", "sender");
            }
            context.CloseActivity();
        }
    }

    [Category("Standard"), Designer(typeof(AvatarIfElseBranchDesigner),
        typeof(IDesigner)), ToolboxItem(false), 
    ActivityValidator(typeof(AvatarIfElseBranchValidator)), 
    ToolboxBitmap(typeof(AvatarIfElseBranchActivity), "Resources.DecisionBranch.bmp")]
    public sealed class AvatarIfElseBranchActivity : SequenceActivity
    {      

        // Methods
        public AvatarIfElseBranchActivity()
        {
        }

        public AvatarIfElseBranchActivity(string name)
            : base(name)
        {
        }

        public static DependencyProperty ConditionProperty =
            DependencyProperty.Register("Condition", typeof(ActivityCondition), typeof(AvatarIfElseBranchActivity));    
     
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(CustomActivityConditionTypeConverter))]
        public ActivityCondition Condition
        {
            get
            {
                return (base.GetValue(ConditionProperty) as ActivityCondition);
            }
            set
            {
                base.SetValue(ConditionProperty, value);
            }
        }


        public static DependencyProperty ConditionItemsProperty =
            DependencyProperty.Register("ConditionItems", typeof(AvatarIfElseConditionCollection),
            typeof(AvatarIfElseBranchActivity));        
        public AvatarIfElseConditionCollection ConditionItems
        {
            get
            {
                return (base.GetValue(ConditionItemsProperty) as AvatarIfElseConditionCollection);
            }
            set
            {
                base.SetValue(ConditionItemsProperty, value);
            }
        }

        //用这种方式，不能实现序列化，无法保存
        //public DependencyObject ConditionItems;         
     
        //public AvatarIfElseConditionCollection ConditionItems;


        //public static DependencyProperty StringItemsProperty =
        // DependencyProperty.Register("StringItems", typeof(StringCollection), typeof(AvatarIfElseBranchActivity));
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public StringCollection StringItems
        //{
        //    get
        //    {
        //        return (base.GetValue(StringItemsProperty) as StringCollection);
        //    }
        //    set
        //    {
        //        base.SetValue(StringItemsProperty, value);
        //    }
        //}
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public StringCollection StringItems;

        public static DependencyProperty ObjectItemProperty =
        DependencyProperty.Register("ObjectItem", typeof(ObjectItem),
        typeof(AvatarIfElseBranchActivity));
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObjectItem ObjectItem
        {
            get
            {
                return (base.GetValue(ObjectItemProperty) as ObjectItem);
            }
            set
            {
                base.SetValue(ObjectItemProperty, value);
            }
        }
    }

    public class ObjectItem
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public ObjectItem(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

    }

    [ActivityDesignerTheme(typeof(AvatarConditionedDesignerTheme))]
    internal sealed class AvatarIfElseBranchDesigner : SequentialActivityDesigner
    {        
        public override bool CanBeParentedTo(CompositeActivityDesigner parentActivityDesigner)
        {
            if (parentActivityDesigner == null)
            {
                throw new ArgumentNullException("parentActivity");
            }
            return ((parentActivityDesigner.Activity is AvatarIfElseActivity) && base.CanBeParentedTo(parentActivityDesigner));
        }

        protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            AvatarIfElseBranchActivity activity = this.Activity as AvatarIfElseBranchActivity;
            using (EntityFilterForm dlg = new EntityFilterForm())
            {
                //初始化用值这个窗体
                //dlg.WorkflowName = activity.Name;
                dlg.Conditions = activity.ConditionItems;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //List<AvatarIfElseCondition> conts = new List<AvatarIfElseCondition>();
                    //foreach (KeyValuePair<int, AvatarIfElseCondition> kvp in dlg.Conditions)
                    //{
                    //    conts.Add(kvp.Value);
                    //}
                    ObjectItem obj = new ObjectItem("job", 190);
                    activity.ConditionItems = dlg.Conditions;
                    activity.ObjectItem = obj;
                }
            }
        }
    }

    internal sealed class AvatarIfElseBranchValidator : CompositeActivityValidator
    {
        // Methods
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);
            AvatarIfElseBranchActivity activity = obj as AvatarIfElseBranchActivity;
            if (activity == null)
            {
                throw new ArgumentException("Error_UnexpectedArgumentType"); //, new object[] { typeof(AvatarIfElseBranchActivity).FullName }), "obj");
            }
            AvatarIfElseActivity parent = activity.Parent as AvatarIfElseActivity;
            if (parent == null)
            {
                errors.Add(new ValidationError("Error_ConditionalBranchParentNotConditional", 0x50e));//(SR.GetString("Error_ConditionalBranchParentNotConditional"), 0x50e));
            }
            //if (((((parent == null) || (parent.EnabledActivities.Count <= 1)) || (parent.EnabledActivities[parent.EnabledActivities.Count - 1] != activity))))
            //    //|| (activity.Condition != null)) && (activity.Condition == null))
            //{
            //    errors.Add(ValidationError.GetNotSetValidationError("Condition"));
            //}
            return errors;
        }
    }


    [ActivityDesignerTheme(typeof(IfElseDesignerTheme))]
    internal sealed class AvatarIfElseDesigner : ParallelActivityDesigner
    {       
        public override bool CanInsertActivities(HitTestInfo insertLocation, ReadOnlyCollection<Activity> activitiesToInsert)
        {
            foreach (Activity activity in activitiesToInsert)
            {
                if (!(activity is AvatarIfElseBranchActivity))
                {
                    return false;
                }
            }
            return base.CanInsertActivities(insertLocation, activitiesToInsert);
        }

        public override bool CanMoveActivities(HitTestInfo moveLocation, ReadOnlyCollection<Activity> activitiesToMove)
        {
            if ((((this.ContainedDesigners.Count - activitiesToMove.Count) < 1) && (moveLocation != null)) && (moveLocation.AssociatedDesigner != this))
            {
                return false;
            }
            return true;
        }

        public override bool CanRemoveActivities(ReadOnlyCollection<Activity> activitiesToRemove)
        {
            if ((this.ContainedDesigners.Count - activitiesToRemove.Count) < 1)
            {
                return false;
            }
            return true;
        }

        private GraphicsPath GetDiamondPath(Rectangle rectangle)
        {
            Point[] points = new Point[] { new Point(rectangle.Left + (rectangle.Width / 2), rectangle.Top), new Point(rectangle.Right - 1, rectangle.Top + (rectangle.Height / 2)), new Point(rectangle.Left + (rectangle.Width / 2), rectangle.Bottom - 1), new Point(rectangle.Left, rectangle.Top + (rectangle.Height / 2)), new Point(rectangle.Left + (rectangle.Width / 2), rectangle.Top) };
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            path.CloseFigure();
            return path;
        }

        protected override CompositeActivity OnCreateNewBranch()
        {
            return new AvatarIfElseBranchActivity();
        }

        protected override void OnPaint(ActivityDesignerPaintEventArgs e)
        {
            base.OnPaint(e);
            if ((this.Expanded && (this.ContainedDesigners.Count != 0)) && (this == base.ActiveView.AssociatedDesigner))
            {
                CompositeDesignerTheme designerTheme = e.DesignerTheme as CompositeDesignerTheme;
                if (designerTheme != null)
                {
                    Rectangle bounds = base.Bounds;
                    Rectangle imageRectangle = this.ImageRectangle;
                    Rectangle empty = Rectangle.Empty;
                    empty.Width = (designerTheme.ConnectorSize.Height - (2 * e.AmbientTheme.Margin.Height)) + 2;
                    empty.Height = empty.Width;
                    empty.X = (bounds.Left + (bounds.Width / 2)) - (empty.Width / 2);
                    empty.Y = ((bounds.Top + this.TitleHeight) + ((((designerTheme.ConnectorSize.Height * 3) / 2) - empty.Height) / 2)) + 1;
                    using (GraphicsPath path = this.GetDiamondPath(empty))
                    {
                        e.Graphics.FillPath(designerTheme.ForegroundBrush, path);
                        e.Graphics.DrawPath(designerTheme.ForegroundPen, path);
                    }
                    empty.Y = ((bounds.Bottom - ((designerTheme.ConnectorSize.Height * 3) / 2)) + ((((designerTheme.ConnectorSize.Height * 3) / 2) - empty.Height) / 2)) + 1;
                    using (GraphicsPath path2 = this.GetDiamondPath(empty))
                    {
                        e.Graphics.FillPath(designerTheme.ForegroundBrush, path2);
                        e.Graphics.DrawPath(designerTheme.ForegroundPen, path2);
                    }
                }
            }
        }

        protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            AvatarIfElseActivity activity = this.Activity as AvatarIfElseActivity;
            using (NameForm dlg = new NameForm()) 
            {
                dlg.WorkflowName = activity.Name;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    activity.Name = dlg.WorkflowName;                  
                }
            }
        }
    }


    public sealed class IfElseDesignerTheme : CompositeDesignerTheme
    {
        // Methods
        public IfElseDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.ShowDropShadow = false;
            this.ConnectorStartCap = LineAnchor.None;
            this.ConnectorEndCap = LineAnchor.None;
            this.ForeColor = Color.FromArgb(0xff, 0, 100, 0);
            this.BorderColor = Color.FromArgb(0xff, 0xe0, 0xe0, 0xe0);
            this.BorderStyle = DashStyle.Dash;
            this.BackColorStart = Color.FromArgb(0, 0, 0, 0);
            this.BackColorEnd = Color.FromArgb(0, 0, 0, 0);
        }
    }


    [Serializable]
    internal sealed class AvatarIfElseToolboxItem : ActivityToolboxItem
    {
        // Methods
        public AvatarIfElseToolboxItem(Type type)
            : base(type)
        {
        }

        private AvatarIfElseToolboxItem(SerializationInfo info, StreamingContext context)
        {
            this.Deserialize(info, context);
        }

        protected override IComponent[] CreateComponentsCore(IDesignerHost designerHost)
        {
            CompositeActivity activity = new AvatarIfElseActivity
            {
                Activities = { new AvatarIfElseBranchActivity(), new AvatarIfElseBranchActivity() }
            };
            return new IComponent[] { activity };
        }
    }


    public sealed class AvatarIfElseValidator : CompositeActivityValidator
    {
        // Methods
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);
            AvatarIfElseActivity activity = obj as AvatarIfElseActivity;
            if (activity == null)
            {
                throw new ArgumentException("Error_UnexpectedArgumentType");//, new object[] { typeof(AvatarIfElseActivity).FullName }), "obj");
            }
            if (activity.EnabledActivities.Count < 1)
            {
                errors.Add(new ValidationError("Error_ConditionalLessThanOneChildren", 0x50c));
            }
            foreach (Activity activity2 in activity.EnabledActivities)
            {
                if (!(activity2 is AvatarIfElseBranchActivity))
                {
                    errors.Add(new ValidationError("Error_ConditionalDeclNotAllConditionalBranchDecl", 0x50d));
                    return errors;
                }
            }
            return errors;
        }

        public override ValidationError ValidateActivityChange(Activity activity, ActivityChangeAction action)
        {
            if (activity == null)
            {
                throw new ArgumentNullException("activity");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            if ((activity.ExecutionStatus != ActivityExecutionStatus.Initialized) && (activity.ExecutionStatus != ActivityExecutionStatus.Closed))
            {
                return new ValidationError("Error_DynamicActivity", 260);//new object[] { activity.QualifiedName, Enum.GetName(typeof(ActivityExecutionStatus), activity.ExecutionStatus) }), 260);
            }
            return null;
        }

    }

    internal sealed class AvatarConditionedDesignerTheme : CompositeDesignerTheme
    {

        public AvatarConditionedDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.ShowDropShadow = false;
            this.ConnectorStartCap = LineAnchor.None;
            this.ConnectorEndCap = LineAnchor.ArrowAnchor;
            this.ForeColor = Color.FromArgb(0xff, 0, 100, 0);
            this.BorderColor = Color.FromArgb(0xff, 0xe0, 0xe0, 0xe0);
            this.BorderStyle = DashStyle.Dash;
            this.BackColorStart = Color.FromArgb(0, 0, 0, 0);
            this.BackColorEnd = Color.FromArgb(0, 0, 0, 0);
        }
    }

}
