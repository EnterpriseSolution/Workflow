using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Host
{
    public class SQLActivity : Activity
    {
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            SqlConnection  conn;
            if(!String.IsNullOrEmpty(ConnectionString))
                conn=new SqlConnection(ConnectionString);
            else 
                conn=new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(SQLText, conn);
            conn.Open();
            int idx = cmd.ExecuteNonQuery();
            conn.Close();
            return ActivityExecutionStatus.Closed;
        }

        [Category("Data"), EditorAttribute(typeof(SQLEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SQLText
        {
            get { return (string)GetValue(SQLTextProperty); }
            set { SetValue(SQLTextProperty, value); }
        }
        public static readonly DependencyProperty SQLTextProperty =
            DependencyProperty.Register("SQLText", typeof(string), typeof(SQLActivity));


        [DefaultValue(""), EditorAttribute(typeof(System.Web.UI.Design.ConnectionStringEditor), typeof(System.Drawing.Design.UITypeEditor)),
        Category("Data"), Description("The  connection string.")]
        public string ConnectionString
        {
            get { return (string)GetValue(ConnectionStringProperty); }
            set { SetValue(ConnectionStringProperty, value); }
        }
        public static readonly DependencyProperty ConnectionStringProperty =
        DependencyProperty.Register("ConnectionString", typeof(string), typeof(SQLActivity));

    }
}
