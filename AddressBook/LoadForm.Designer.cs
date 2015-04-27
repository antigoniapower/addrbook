namespace AddressBook
{
    partial class LoadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadForm));
            this.lblAuthorInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAuthorInfo
            // 
            this.lblAuthorInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAuthorInfo.Location = new System.Drawing.Point(-2, 9);
            this.lblAuthorInfo.Name = "lblAuthorInfo";
            this.lblAuthorInfo.Size = new System.Drawing.Size(187, 119);
            this.lblAuthorInfo.TabIndex = 1;
            this.lblAuthorInfo.Text = "Загрузка пользователей, пожалуйста, подождите...";
            this.lblAuthorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 137);
            this.Controls.Add(this.lblAuthorInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Address Book";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAuthorInfo;





    }
}

