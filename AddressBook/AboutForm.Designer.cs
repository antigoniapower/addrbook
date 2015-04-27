namespace AddressBook
{
    partial class AboutForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.btOK = new System.Windows.Forms.Button();
            this.lblAuthorInfo = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOK.Location = new System.Drawing.Point(44, 78);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(92, 45);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // lblAuthorInfo
            // 
            this.lblAuthorInfo.AutoSize = true;
            this.lblAuthorInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAuthorInfo.Location = new System.Drawing.Point(22, 21);
            this.lblAuthorInfo.Name = "lblAuthorInfo";
            this.lblAuthorInfo.Size = new System.Drawing.Size(127, 15);
            this.lblAuthorInfo.TabIndex = 1;
            this.lblAuthorInfo.Text = "Алехина Ольга, 2015";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLink.Location = new System.Drawing.Point(22, 45);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(146, 15);
            this.lblLink.TabIndex = 2;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "sadstatue128@yandex.ru";
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 137);
            this.ControlBox = false;
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lblAuthorInfo);
            this.Controls.Add(this.btOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Address Book";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Label lblAuthorInfo;
        private System.Windows.Forms.LinkLabel lblLink;




    }
}

