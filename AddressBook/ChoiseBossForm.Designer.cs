namespace AddressBook
{
    partial class ChoiseBossForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoiseBossForm));
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btCheckNames = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.pnResults = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(26, 39);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(211, 20);
            this.tbInput.TabIndex = 0;
            // 
            // btCheckNames
            // 
            this.btCheckNames.Location = new System.Drawing.Point(253, 37);
            this.btCheckNames.Name = "btCheckNames";
            this.btCheckNames.Size = new System.Drawing.Size(75, 23);
            this.btCheckNames.TabIndex = 1;
            this.btCheckNames.Text = "Найти";
            this.btCheckNames.UseVisualStyleBackColor = true;
            this.btCheckNames.Click += new System.EventHandler(this.btCheckNames_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(26, 75);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(106, 13);
            this.lblResults.TabIndex = 3;
            this.lblResults.Text = "Результаты поиска";
            // 
            // pnResults
            // 
            this.pnResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnResults.AutoScroll = true;
            this.pnResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnResults.Controls.Add(this.linkLabel1);
            this.pnResults.Location = new System.Drawing.Point(26, 105);
            this.pnResults.Name = "pnResults";
            this.pnResults.Size = new System.Drawing.Size(302, 154);
            this.pnResults.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(4, 4);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ChoiseBossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 282);
            this.Controls.Add(this.pnResults);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btCheckNames);
            this.Controls.Add(this.tbInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChoiseBossForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Найти пользователя";
            this.Shown += new System.EventHandler(this.ChoiseBossForm_Shown);
            this.pnResults.ResumeLayout(false);
            this.pnResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btCheckNames;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Panel pnResults;
        private System.Windows.Forms.LinkLabel linkLabel1;





    }
}

