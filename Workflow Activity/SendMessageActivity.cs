using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.ComponentModel;
using System.Data.SqlClient;
using CNPOPSOFT.Controls.Demo;
using System.Workflow.ComponentModel.Design;
using System.Drawing;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.IO;

namespace Host
{
    [Designer(typeof(SendMessageActivityDesigner), typeof(IDesigner))]
    public class SendMessageActivity : Activity
    {
        public SendMessageActivity()
        {

        }
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            //将消息写到数据库中,不能依赖于ORM，这样会产生很多问题
            //IMessageManager manager = ClientProxyFactory.CreateProxyInstance<IMessageManager>();
            //manager.CreateMessage("MIS", Receiver, Subject, MessageBody);
            //Random rd = new Random();
            //StreamWriter writer = File.CreateText(rd.Next(100)+".txt");
            //writer.Write("将消息写到数据库中,不能依赖于ORM，这样会产生很多问题");
            //writer.Flush();
            //writer.Close();

            MessageDAL.CreateMessage(Receiver, Subject, MessageBody);           
            return base.Execute(executionContext);
        }

        public static DependencyProperty SubjectProperty =
            DependencyProperty.Register("Subject", typeof(string), typeof(SendMessageActivity));

        [Category("File")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Subject
        {
            get
            {
                return ((string)(base.GetValue(SendMessageActivity.SubjectProperty)));
            }
            set
            {
                base.SetValue(SendMessageActivity.SubjectProperty, value);
            }
        }              

        public static DependencyProperty MessageBodyProperty =
           DependencyProperty.Register("MessageBody", typeof(string), typeof(SendMessageActivity));
            
        [Category("File")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string MessageBody
        {
            get
            {
                return ((string)(base.GetValue(SendMessageActivity.MessageBodyProperty)));
            }
            set
            {
                base.SetValue(SendMessageActivity.MessageBodyProperty, value);
            }
        }

        public static DependencyProperty ReceiverProperty =
          DependencyProperty.Register("Receiver", typeof(string), typeof(SendMessageActivity));

        [Category("File")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Receiver
        {
            get
            {
                return ((string)(base.GetValue(SendMessageActivity.ReceiverProperty)));
            }
            set
            {
                base.SetValue(SendMessageActivity.ReceiverProperty, value);
            }
        }
    }

    [ActivityDesignerTheme(typeof(WriteFileActivityDesignerTheme))]
    public class SendMessageActivityDesigner : ActivityDesigner
    {
        private const int TEXT_WIDTH = 75;
        private const int PADDING = 4;

        protected override Rectangle ImageRectangle
        {
            get
            {
                Rectangle rect = new Rectangle();
                rect.X = this.Bounds.Left + PADDING;
                rect.Y = this.Bounds.Top + PADDING;
                //  rect.Size = Properties.Resources.Write.Size;
                rect.Size = new Size(16, 16);
                return rect;
            }
        }

        protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            SendMessageActivity activity = this.Activity as SendMessageActivity;            
            using (MessageTemplate dlg = new MessageTemplate())
            {
                dlg.Receiver = activity.Receiver != null ? activity.Receiver : "";
                dlg.Subject = activity.Subject != null ? activity.Subject : "";
                dlg.MessageBody = activity.MessageBody != null ? activity.MessageBody : "";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    activity.Receiver = dlg.Receiver;
                    activity.Subject = dlg.Subject;
                    activity.MessageBody = dlg.MessageBody;                             
                }
            }
        }
        protected override Rectangle TextRectangle
        {
            get
            {
                Rectangle imgRect = this.ImageRectangle;

                Rectangle rect = new Rectangle(
                    imgRect.Right + PADDING,
                    imgRect.Top,
                    TEXT_WIDTH,
                    imgRect.Height);
                return rect;
            }
        }

        protected override void Initialize(Activity activity)
        {
            base.Initialize(activity);

            //Bitmap image = Properties.Resources.Write;
            //image.MakeTransparent();
            //this.Image = image;
        }

        protected override Size OnLayoutSize(ActivityDesignerLayoutEventArgs e)
        {
            base.OnLayoutSize(e);

            //Size imgSize = Properties.Resources.Write.Size;
            //return new Size(imgSize.Width + TEXT_WIDTH + (PADDING * 3),
            //    imgSize.Height + (PADDING * 2));
            return new Size(32, 32);
        }
    }

    //public class JobActivity : Activity
    //{
    //    public JobActivity() { }
    //    protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
    //    {
    //        return base.Execute(executionContext);
    //    }
    //}
    public class MessageEntity
    {
        public MessageEntity() { }
        private int _message_id;
        private string _created_by;
        private DateTime _created_date;
        private string _revised_by;
        private DateTime _revised_date;
        private string _summary;
        private string _detail;
        private int _parent_id;
        private string _post_status;
        private int _req_id;
        private string _msg_to;
        private decimal _reqmsg_parent_id;
        private int _instance_no;
        private string _html_text;
        private bool _with_attachment;

        public int MESSAGE_ID
        {
            set { _message_id = value; }
            get { return _message_id; }
        }
        public string CREATED_BY
        {
            set { _created_by = value; }
            get { return _created_by; }
        }
        public DateTime CREATED_DATE
        {
            set { _created_date = value; }
            get { return _created_date; }
        }
        public string REVISED_BY
        {
            set { _revised_by = value; }
            get { return _revised_by; }
        }
        public DateTime REVISED_DATE
        {
            set { _revised_date = value; }
            get { return _revised_date; }
        }
        public string SUMMARY
        {
            set { _summary = value; }
            get { return _summary; }
        }
        public string DETAIL
        {
            set { _detail = value; }
            get { return _detail; }
        }
        public int PARENT_ID
        {
            set { _parent_id = value; }
            get { return _parent_id; }
        }
        public string POST_STATUS
        {
            set { _post_status = value; }
            get { return _post_status; }
        }
        public int REQ_ID
        {
            set { _req_id = value; }
            get { return _req_id; }
        }
        public string MSG_TO
        {
            set { _msg_to = value; }
            get { return _msg_to; }
        }
        public decimal REQMSG_PARENT_ID
        {
            set { _reqmsg_parent_id = value; }
            get { return _reqmsg_parent_id; }
        }
        public int INSTANCE_NO
        {
            set { _instance_no = value; }
            get { return _instance_no; }
        }
        public string HTML_TEXT
        {
            set { _html_text = value; }
            get { return _html_text; }
        }
        public bool WITH_ATTACHMENT
        {
            set { _with_attachment = value; }
            get { return _with_attachment; }
        }

    }

    public class UserMessageEntity
    {
        public UserMessageEntity() { }
        private decimal _recnum;
        private int _message_id;
        private string _user_id;
        private string _flow_type;
        private string _send_by;
        private string _send_to;
        private DateTime _received_date;
        private DateTime _sent_date;
        private string _unread;
        private string _importance;
        private string _status;
        private decimal _source_recnum;
        private int _last_action;
        private DateTime _last_action_date;
        private bool _deleted;
        private int _approval_action;

        public decimal RECNUM
        {
            set { _recnum = value; }
            get { return _recnum; }
        }
        public int MESSAGE_ID
        {
            set { _message_id = value; }
            get { return _message_id; }
        }
        public string USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        public string FLOW_TYPE
        {
            set { _flow_type = value; }
            get { return _flow_type; }
        }
        public string SEND_BY
        {
            set { _send_by = value; }
            get { return _send_by; }
        }
        public string SEND_TO
        {
            set { _send_to = value; }
            get { return _send_to; }
        }
        public DateTime RECEIVED_DATE
        {
            set { _received_date = value; }
            get { return _received_date; }
        }
        public DateTime SENT_DATE
        {
            set { _sent_date = value; }
            get { return _sent_date; }
        }
        public string UNREAD
        {
            set { _unread = value; }
            get { return _unread; }
        }
        public string IMPORTANCE
        {
            set { _importance = value; }
            get { return _importance; }
        }
        public string STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        public decimal SOURCE_RECNUM
        {
            set { _source_recnum = value; }
            get { return _source_recnum; }
        }
        public int LAST_ACTION
        {
            set { _last_action = value; }
            get { return _last_action; }
        }
        public DateTime LAST_ACTION_DATE
        {
            set { _last_action_date = value; }
            get { return _last_action_date; }
        }
        public bool DELETED
        {
            set { _deleted = value; }
            get { return _deleted; }
        }
        public int APPROVAL_ACTION
        {
            set { _approval_action = value; }
            get { return _approval_action; }
        }

    }

    public class MessageDAL
    {
        public static void CreateMessage(string Receiver, string Subject, string MessageBody)
        {           
            MessageEntity message = new MessageEntity();
            message.PARENT_ID = -1;
            message.CREATED_BY = "MIS";
            message.CREATED_DATE = DateTime.Now;
            message.REVISED_BY = "MIS";
            message.REVISED_DATE = DateTime.Now;
            message.SUMMARY = Subject;
            message.DETAIL = MessageBody;
            //message.REQ_ID = messageID;
            AddMessage(message);

            //UserMessageEntity userMessage = new UserMessageEntity();
            //userMessage.SEND_TO = Receiver;
            //userMessage.SEND_BY = "MIS";
            //userMessage.SENT_DATE = DateTime.Now;
            //userMessage.RECEIVED_DATE = DateTime.Now;
            //userMessage.LAST_ACTION_DATE = DateTime.Now;
            //userMessage.USER_ID = "MIS";
            //int messageID = AddUserMessage(userMessage);
        }
        public static int AddUserMessage(UserMessageEntity Entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO USRMSG(");
            strSql.Append("MESSAGE_ID,USER_ID,FLOW_TYPE,SEND_BY,SEND_TO,RECEIVED_DATE,SENT_DATE,UNREAD,IMPORTANCE,STATUS,SOURCE_RECNUM,LAST_ACTION,LAST_ACTION_DATE,DELETED,APPROVAL_ACTION)");

            strSql.Append(" VALUES (");
            strSql.Append("@MESSAGE_ID,@USER_ID,@FLOW_TYPE,@SEND_BY,@SEND_TO,@RECEIVED_DATE,@SENT_DATE,@UNREAD,@IMPORTANCE,@STATUS,@SOURCE_RECNUM,@LAST_ACTION,@LAST_ACTION_DATE,@DELETED,@APPROVAL_ACTION)");
            strSql.Append(" SELECT @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "MESSAGE_ID", DbType.Int32, Entity.MESSAGE_ID);
            db.AddInParameter(dbCommand, "USER_ID", DbType.String, Entity.USER_ID);
            db.AddInParameter(dbCommand, "FLOW_TYPE", DbType.String, Entity.FLOW_TYPE);
            db.AddInParameter(dbCommand, "SEND_BY", DbType.String, Entity.SEND_BY);
            db.AddInParameter(dbCommand, "SEND_TO", DbType.String, Entity.SEND_TO);
            db.AddInParameter(dbCommand, "RECEIVED_DATE", DbType.DateTime, Entity.RECEIVED_DATE);
            db.AddInParameter(dbCommand, "SENT_DATE", DbType.DateTime, Entity.SENT_DATE);
            db.AddInParameter(dbCommand, "UNREAD", DbType.String, Entity.UNREAD);
            db.AddInParameter(dbCommand, "IMPORTANCE", DbType.String, Entity.IMPORTANCE);
            db.AddInParameter(dbCommand, "STATUS", DbType.String, Entity.STATUS);
            db.AddInParameter(dbCommand, "SOURCE_RECNUM", DbType.Decimal, Entity.SOURCE_RECNUM);
            db.AddInParameter(dbCommand, "LAST_ACTION", DbType.Int32, Entity.LAST_ACTION);
            db.AddInParameter(dbCommand, "LAST_ACTION_DATE", DbType.DateTime, Entity.LAST_ACTION_DATE);
            db.AddInParameter(dbCommand, "DELETED", DbType.Boolean, Entity.DELETED);
            db.AddInParameter(dbCommand, "APPROVAL_ACTION", DbType.Int32, Entity.APPROVAL_ACTION);
            int idx = (int)db.ExecuteScalar(dbCommand);
            return idx;
        }
        public static bool AddMessage(MessageEntity Entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO MESSAGE(");
            strSql.Append("CREATED_BY,CREATED_DATE,REVISED_BY,REVISED_DATE,SUMMARY,DETAIL,PARENT_ID,POST_STATUS,REQ_ID,MSG_TO,REQMSG_PARENT_ID,INSTANCE_NO,HTML_TEXT,WITH_ATTACHMENT)");

            strSql.Append(" VALUES (");
            strSql.Append("@CREATED_BY,@CREATED_DATE,@REVISED_BY,@REVISED_DATE,@SUMMARY,@DETAIL,@PARENT_ID,@POST_STATUS,@REQ_ID,@MSG_TO,@REQMSG_PARENT_ID,@INSTANCE_NO,@HTML_TEXT,@WITH_ATTACHMENT)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CREATED_BY", DbType.String, Entity.CREATED_BY);
            db.AddInParameter(dbCommand, "CREATED_DATE", DbType.DateTime, Entity.CREATED_DATE);
            db.AddInParameter(dbCommand, "REVISED_BY", DbType.String, Entity.REVISED_BY);
            db.AddInParameter(dbCommand, "REVISED_DATE", DbType.DateTime, Entity.REVISED_DATE);
            db.AddInParameter(dbCommand, "SUMMARY", DbType.String, Entity.SUMMARY);
            db.AddInParameter(dbCommand, "DETAIL", DbType.String, Entity.DETAIL);
            db.AddInParameter(dbCommand, "PARENT_ID", DbType.Int32, Entity.PARENT_ID);
            db.AddInParameter(dbCommand, "POST_STATUS", DbType.String, Entity.POST_STATUS);
            db.AddInParameter(dbCommand, "REQ_ID", DbType.Int32, Entity.REQ_ID);
            db.AddInParameter(dbCommand, "MSG_TO", DbType.String, Entity.MSG_TO);
            db.AddInParameter(dbCommand, "REQMSG_PARENT_ID", DbType.Decimal, Entity.REQMSG_PARENT_ID);
            db.AddInParameter(dbCommand, "INSTANCE_NO", DbType.Int32, Entity.INSTANCE_NO);
            db.AddInParameter(dbCommand, "HTML_TEXT", DbType.String, Entity.HTML_TEXT);
            db.AddInParameter(dbCommand, "WITH_ATTACHMENT", DbType.Boolean, Entity.WITH_ATTACHMENT);
            int idx = db.ExecuteNonQuery(dbCommand);
            return idx > 0 ? true : false;
        }
    }
}
