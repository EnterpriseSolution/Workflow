
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using QueryDesigner;

namespace CNPOPSOFT.Controls.Demo
{
    public partial class MessageTemplate : Form
    {
        public MessageTemplate()
        {
            InitializeComponent();
        }
        public string MessageBody
        {
            get
            {
                return rtfMessage.Text;
            }
            set
            {
                rtfMessage.Text = value;                    
            }
        }
        public string Receiver
        {
            get
            {
                return txtTo.Text;
            }
            set
            {
                txtTo.Text = value;
            }
        }
        public string Subject
        {
            get
            {
                return txtSubject.Text;
            }
            set
            {
                txtSubject.Text = value;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ////在这里输入你的邮件服务器信息，就可以发送邮件了！
            //string host = "192.168.22.12";
            //int port = 25;
            //string userid = "51aspx";
            //string password = "51aspx";

            //MailMessage message = BuildMessage();

            //SmtpClient smtp = new SmtpClient(host, port);
            //smtp.Credentials = new NetworkCredential(userid, password);
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            //try
            //{
            //    smtp.Send(message);

            //    MessageBox.Show("发送成功！", "示例", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("发送失败！\r\n" + ex.Message, "示例", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        //private MailMessage BuildMessage()
        //{
        //    string from = "sample@sample.sample";
        //    string to = textBoxTo.Text;
        //    string subproject = textBoxSubject.Text;
        //    string[] images = rtfMessage.Images;
        //    string body = rtfMessage.Text;

        //    MailMessage message = new MailMessage();

        //    message.From = new MailAddress(from);
        //    message.To.Add(new MailAddress(to));
        //    message.Subject = subproject;

        //    //message.IsBodyHtml = true;

        //    if (images.Length != 0)
        //    {
        //        for (int i = 0, count = images.Length; i < count; ++i)
        //        {
        //            string image = images[i];

        //            if (image.Trim() == "")
        //            {
        //                continue;
        //            }

        //            if (!image.StartsWith("file"))
        //            {
        //                continue;
        //            }

        //            string path = Path.GetFullPath(image.Replace("%20", " ").Replace("file:///", ""));
        //            string cid = string.Format("image_{0:00}", i);

        //            Attachment attach = new Attachment(path);
        //            attach.Name = Path.GetFileNameWithoutExtension(path);
        //            attach.ContentId = cid;
        //            message.Attachments.Add(attach);

        //            body = body.Replace(path, string.Format("cid:{0}", cid));
        //        }
        //    }

        //    message.Body = body;

        //    return message;
        //}

        private void btnQueryBuilder_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Enterprise;Data Source=(local)";
            using (var dlg = new QueryDesignerDialog())
            {
                dlg.Font = this.Font;
                dlg.ConnectionString = ConnectionString;
                // dlg.SelectStatement = SelectStatement; // NOP (for now)
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string sql = dlg.SelectStatement;
                    rtfMessage.Text += sql;
                }
            }
        }
    }
}