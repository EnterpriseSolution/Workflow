namespace ActivityLibrary
{
    partial class EntityFilterForm
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
            this.btnInsert = new System.Windows.Forms.LinkLabel();
            this.btbRemove = new System.Windows.Forms.LinkLabel();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.txtFormular = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnValidation = new System.Windows.Forms.Button();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.AutoSize = true;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(19, 7);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(37, 15);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.TabStop = true;
            this.btnInsert.Text = "Insert";
            this.btnInsert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnInsert_LinkClicked);
            // 
            // btbRemove
            // 
            this.btbRemove.AutoSize = true;
            this.btbRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbRemove.Location = new System.Drawing.Point(81, 7);
            this.btbRemove.Name = "btbRemove";
            this.btbRemove.Size = new System.Drawing.Size(53, 15);
            this.btbRemove.TabIndex = 1;
            this.btbRemove.TabStop = true;
            this.btbRemove.Text = "Remove";
            this.btbRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btbRemove_LinkClicked);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.flowPanel);
            this.panel.Location = new System.Drawing.Point(14, 36);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(712, 305);
            this.panel.TabIndex = 2;
            // 
            // txtFormular
            // 
            this.txtFormular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormular.Location = new System.Drawing.Point(12, 351);
            this.txtFormular.Name = "txtFormular";
            this.txtFormular.Size = new System.Drawing.Size(710, 67);
            this.txtFormular.TabIndex = 3;
            this.txtFormular.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(556, 425);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(647, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnValidation
            // 
            this.btnValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidation.Location = new System.Drawing.Point(12, 427);
            this.btnValidation.Name = "btnValidation";
            this.btnValidation.Size = new System.Drawing.Size(75, 23);
            this.btnValidation.TabIndex = 6;
            this.btnValidation.Text = "Validation";
            this.btnValidation.UseVisualStyleBackColor = true;
            this.btnValidation.Click += new System.EventHandler(this.btnValidation_Click);
            // 
            // flowPanel
            // 
            this.flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanel.Location = new System.Drawing.Point(3, 3);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(705, 0);
            this.flowPanel.TabIndex = 0;
            // 
            // EntityFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 459);
            this.Controls.Add(this.btnValidation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtFormular);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btbRemove);
            this.Controls.Add(this.btnInsert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EntityFilterForm";
            this.Text = "Selection Criterial";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnInsert;
        private System.Windows.Forms.LinkLabel btbRemove;
        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.RichTextBox txtFormular;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnValidation;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
    }
}