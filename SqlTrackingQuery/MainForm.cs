using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Runtime.Tracking;

namespace SqlTrackingQuerySample
{
   public partial class MainForm : Form
   {
      private string _connString;

      public MainForm()
      {
          _connString = System.Configuration.ConfigurationManager.AppSettings["Workflow"];
         InitializeComponent();
      }

      private void RefreshButton_Click(object sender, EventArgs e)
      {
         if ( !String.IsNullOrEmpty(_connString) )
         {
            RefreshData();
         }
      }

        #region Private Methods
        //
        // Private Methods
        //

        private void RefreshData()
        {
            System.Workflow.Runtime.Tracking.SqlTrackingQuery query = new System.Workflow.Runtime.Tracking.SqlTrackingQuery(_connString);
            var from = new DateTime(2010, 1, 1);
            var until= new DateTime(2021, 12, 31);
            SqlTrackingQueryOptions options = new SqlTrackingQueryOptions()
            {
                StatusMinDateTime = from,
                StatusMaxDateTime = until
            };
            //options.WorkflowStatus = WorkflowStatus.Completed;

            // var list= query.GetWorkflows(options);
            List<SqlTrackingWorkflowInstance> list = new List<SqlTrackingWorkflowInstance>();

            options.WorkflowStatus = WorkflowStatus.Created;
            list.AddRange(query.GetWorkflows(options));

            options.WorkflowStatus = WorkflowStatus.Completed;
            list.AddRange(query.GetWorkflows(options));

            options.WorkflowStatus = WorkflowStatus.Running;
            list.AddRange(query.GetWorkflows(options));

            options.WorkflowStatus = WorkflowStatus.Suspended;
            list.AddRange(query.GetWorkflows(options));

            options.WorkflowStatus = WorkflowStatus.Terminated;
            list.AddRange(query.GetWorkflows(options));

            this.Text = this.Text + $"({list.Count})";

            //foreach (var instance in list)
            //{
            //    Microsoft.Workflow.Monitor.Data.WorkflowInstance instance2 = new Microsoft.Workflow.Monitor.Data.WorkflowInstance(instance);
            //}

            trackingBindingSource.DataSource = list;
            //this.activityEventBindingSource.DataMember = "ActivityEvents";
            //this.activityEventBindingSource.DataSource = this.trackingBindingSource;
          
        }

        #endregion // Private Methods

        private void connectDbButton_Click(object sender, EventArgs e)
      {
         using ( SelectDbForm dlg = new SelectDbForm() )
         {
            DialogResult res = dlg.ShowDialog(this);
            if ( res == DialogResult.OK )
            {
               _connString = dlg.ConnectionString;
               RefreshData();
            }
         }
      }

      private void wfEventsGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
      {
         for ( int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++ )
         {
            DataGridViewRow row = wfEventsGrid.Rows[i];
            WorkflowTrackingRecord record =  (WorkflowTrackingRecord)row.DataBoundItem;

            string argsText = "";

            switch ( record.TrackingWorkflowEvent )
            {
            case TrackingWorkflowEvent.Suspended:
               argsText = ((TrackingWorkflowSuspendedEventArgs)record.EventArgs).Error;
               break;
            case TrackingWorkflowEvent.Exception:
               argsText = ((TrackingWorkflowExceptionEventArgs)record.EventArgs).Exception.Message;
               break;
            case TrackingWorkflowEvent.Changed:
               argsText = string.Format("Number of Changes: {0}", ((TrackingWorkflowChangedEventArgs)record.EventArgs).Changes.Count);
               break;
            case TrackingWorkflowEvent.Terminated:
               argsText = ((TrackingWorkflowTerminatedEventArgs)record.EventArgs).Exception.Message;
               break;
            default:
               // no need to do anything;
               break;
            }
            row.Cells[ArgsColumn.Name].Value = argsText;
         }
      }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            WorkflowEnquiryForm form = new WorkflowEnquiryForm();
            form.Show(this);
        }
    }
}