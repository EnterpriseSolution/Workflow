
namespace CNPOPSOFT.Controls.Demo
{
    partial class HtmlTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageTemplate));
            this.labelTo = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQueryBuilder = new System.Windows.Forms.Button();
            this.rtfMessage = new CNPOPSOFT.Controls.HtmlEditor();
            this.SuspendLayout();
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(12, 14);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(76, 17);
            this.labelTo.TabIndex = 4;
            this.labelTo.Text = "Receiver(&R):";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(12, 42);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(68, 17);
            this.labelSubject.TabIndex = 5;
            this.labelSubject.Text = "Subject(&S):";
            // 
            // textBoxTo
            // 
            this.textBoxTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTo.Location = new System.Drawing.Point(85, 11);
            this.textBoxTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(776, 23);
            this.textBoxTo.TabIndex = 0;
            this.textBoxTo.Text = "billgates@microsoft.com";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSubject.Location = new System.Drawing.Point(85, 42);
            this.textBoxSubject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(776, 23);
            this.textBoxSubject.TabIndex = 1;
            this.textBoxSubject.Text = "SharePoint is a great product";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(677, 446);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(782, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(8, 446);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnQueryBuilder
            // 
            this.btnQueryBuilder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQueryBuilder.Location = new System.Drawing.Point(99, 446);
            this.btnQueryBuilder.Name = "btnQueryBuilder";
            this.btnQueryBuilder.Size = new System.Drawing.Size(107, 23);
            this.btnQueryBuilder.TabIndex = 9;
            this.btnQueryBuilder.Text = "Query Builder";
            this.btnQueryBuilder.UseVisualStyleBackColor = true;
            this.btnQueryBuilder.Click += new System.EventHandler(this.btnQueryBuilder_Click);
            // 
            // rtfMessage
            // 
            this.rtfMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rtfMessage.Location = new System.Drawing.Point(8, 73);
            this.rtfMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtfMessage.Name = "rtfMessage";
            this.rtfMessage.Size = new System.Drawing.Size(853, 364);
            this.rtfMessage.TabIndex = 2;
            // 
            // MessageTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(873, 479);
            this.Controls.Add(this.btnQueryBuilder);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.rtfMessage);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MessageTemplate";
            this.Text = "Message Template";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HtmlEditor rtfMessage;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQueryBuilder;
    }
}