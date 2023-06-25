//using Microsoft.Workflow.Workflows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Tracking;
using Yokogawa.PATH.Common.Data;

namespace SqlTrackingQuerySample
{
    public partial class WorkflowEnquiryForm : Form
    {
        DataTable _tables;
        DataTable _flows;

        public WorkflowEnquiryForm()
        {
            InitializeComponent();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            gridMaster.DataSource = masterBindingSource;
            gridDetail.DataSource = detailBindingSource;

            var _connString = "Data Source=DESKTOP-2PVSNOU\\SQL08R2; Initial Catalog=Workflow; Integrated Security=SSPI";

            var _connStringEnterprise = "Data Source=DESKTOP-2PVSNOU\\SQL08R2; Initial Catalog=Enterprise; Integrated Security=SSPI";

            System.Workflow.Runtime.Tracking.SqlTrackingQuery query = new System.Workflow.Runtime.Tracking.SqlTrackingQuery(_connString);
            var from = new DateTime(2010, 1, 1);
            var until = new DateTime(2021, 12, 31);
            SqlTrackingQueryOptions options = new SqlTrackingQueryOptions()
            {
                StatusMinDateTime = from,
                StatusMaxDateTime = until
            };
            //options.WorkflowStatus = WorkflowStatus.Completed;

            List<SqlTrackingWorkflowInstance> list=new List<SqlTrackingWorkflowInstance>();
            //var list = query.GetWorkflows(options);

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

            string querytest = "Select *  from gbwrkf";
            var ds=SqlHelper.ExecuteDataset(_connStringEnterprise, CommandType.Text, querytest);
            var tableWrokflow = ds.Tables[0];
            var tableList = ds.Tables[0].AsEnumerable().Select(en => en.Field<string>("TableName")).Distinct().ToList();
           
            List<string> workflowTypes = new List<string>
            {
                //typeof(DocumentApprovalWorkflow).FullName,
                //typeof(ScheduledWorkflow).FullName,
                //typeof(TransactionClosedWorkflow).FullName,
                //typeof(TransactionCreatedWorkflow).FullName,
                //typeof(TransactionDeletedWorkflow).FullName,
                //typeof(TransactionPostedWorkflow).FullName,
                //typeof(TransactionPostingControlWorkflow).FullName,
                //typeof(TransactionUpdatedWorkflow).FullName
            };

            _tables = new DataTable("Table");
            _tables.Columns.Add("Table", typeof(string));
            _tables.Columns.Add("Entity", typeof(string));
            foreach (string name in workflowTypes)
            {
                _tables.Columns.Add(name, typeof(int));
            }
            _tables.PrimaryKey = new DataColumn[] { _tables.Columns["Table"] };
            foreach(string str in tableList)
            {
                var newRow = _tables.NewRow();
                newRow["Table"] = str;                
                _tables.Rows.Add(newRow);
            }


            var  _workflow = new DataTable("Workflow");
            _workflow.Columns.Add("WorkflowIndex", typeof(int));
            _workflow.Columns["WorkflowIndex"].AutoIncrement = true;

            _workflow.Columns.Add("WorkflowName", typeof(string));
            _workflow.Columns.Add("WorkflowType", typeof(string));
            _workflow.Columns.Add("Table", typeof(string));
            _workflow.Columns.Add("EventDateTime", typeof(DateTime));
            _workflow.Columns.Add("ExecutionStatus", typeof(string));

            _workflow.PrimaryKey = new DataColumn[] { _workflow.Columns["WorkflowIndex"] };

            foreach (var workflowInstance in list)
            {               
                foreach(var wfEvent in workflowInstance.ActivityEvents)
                {
                    string name = wfEvent.ActivityType.ToString();
                    if(workflowTypes.Contains(name))
                    {                       
                        //var row = _workflow.Rows.Find(wfEvent.QualifiedName);
                        //if(row==null)
                        //{
                            var newRow = _workflow.NewRow();
                            newRow["WorkflowName"] = wfEvent.QualifiedName;
                            newRow["WorkflowType"] = name;
                            newRow["EventDateTime"] = wfEvent.EventDateTime;
                          newRow["ExecutionStatus"] = workflowInstance.Status;

                        var rows = tableWrokflow.Select($"WorkflowName='{wfEvent.QualifiedName}'");
                            if (rows != null && rows.Length > 0)
                                newRow["Table"] = rows[0]["TableName"];

                            _workflow.Rows.Add(newRow);

                            string tableName = newRow["Table"].ToString();
                            var tblRow = _tables.Rows.Find(tableName);
                            if (tblRow != null)
                            {
                                int sum = tblRow[name] == DBNull.Value ? 0 : Convert.ToInt32(tblRow[name]);
                                tblRow[name] = sum + 1;
                            }
                        //}
                        break;                     
                    }
                }
            }

            DataSet data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            data.Tables.Add(_tables);
            data.Tables.Add(_workflow);

            DataRelation relation = new DataRelation("CustomersOrders",               data.Tables["Table"].Columns["Table"],
               data.Tables["Workflow"].Columns["Table"]);
            data.Relations.Add(relation);
            
           
            masterBindingSource.DataSource = data;
            masterBindingSource.DataMember = "Table";            
           
            detailBindingSource.DataSource = masterBindingSource;
            detailBindingSource.DataMember = "CustomersOrders";
                   

            //foreach(var type in workflowTypes)
            //{                
            //    gridMaster.Columns[type].HeaderText = type.Replace("Microsoft.Workflow.Workflows.","").Replace("Workflow", "");
            //}            
        }
    }
}
