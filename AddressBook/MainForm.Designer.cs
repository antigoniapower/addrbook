namespace AddressBook
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btReload = new System.Windows.Forms.Button();
            this.lblExcel = new System.Windows.Forms.LinkLabel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.pnUserInfo = new System.Windows.Forms.Panel();
            this.lblBossString = new System.Windows.Forms.Label();
            this.lblGridUserName = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.gbOrganization = new System.Windows.Forms.GroupBox();
            this.btSetBoss = new System.Windows.Forms.Button();
            this.dtStartJob = new System.Windows.Forms.DateTimePicker();
            this.txtBoss = new System.Windows.Forms.TextBox();
            this.txtDep = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gbContacts = new System.Windows.Forms.GroupBox();
            this.linkMain = new System.Windows.Forms.LinkLabel();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.txtSIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCommon = new System.Windows.Forms.GroupBox();
            this.dtBDay = new System.Windows.Forms.DateTimePicker();
            this.chDontShowYear = new System.Windows.Forms.CheckBox();
            this.txtMidName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbPhoto = new System.Windows.Forms.GroupBox();
            this.btClearPhoto = new System.Windows.Forms.Button();
            this.btLoadPhoto = new System.Windows.Forms.Button();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.linkAbout = new System.Windows.Forms.LinkLabel();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.grAddress = new System.Windows.Forms.DataGridView();
            this.aDUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsAMAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.pnUserInfo.SuspendLayout();
            this.gbOrganization.SuspendLayout();
            this.gbContacts.SuspendLayout();
            this.gbCommon.SuspendLayout();
            this.gbPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDUserBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btReload);
            this.panel1.Controls.Add(this.lblExcel);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.filterBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 43);
            this.panel1.TabIndex = 5;
            // 
            // btReload
            // 
            this.btReload.Location = new System.Drawing.Point(293, 9);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(75, 23);
            this.btReload.TabIndex = 3;
            this.btReload.Text = "Обновить";
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblExcel
            // 
            this.lblExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExcel.AutoSize = true;
            this.lblExcel.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblExcel.Location = new System.Drawing.Point(736, 12);
            this.lblExcel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExcel.Name = "lblExcel";
            this.lblExcel.Size = new System.Drawing.Size(89, 13);
            this.lblExcel.TabIndex = 2;
            this.lblExcel.TabStop = true;
            this.lblExcel.Text = "Открыть в Excel";
            this.lblExcel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblExcel_LinkClicked);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSearch.Location = new System.Drawing.Point(23, 12);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(39, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Поиск";
            // 
            // filterBox
            // 
            this.filterBox.Location = new System.Drawing.Point(67, 11);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(206, 20);
            this.filterBox.TabIndex = 0;
            this.filterBox.TextChanged += new System.EventHandler(this.filterBox_TextChanged);
            // 
            // pnUserInfo
            // 
            this.pnUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnUserInfo.Controls.Add(this.lblBossString);
            this.pnUserInfo.Controls.Add(this.lblGridUserName);
            this.pnUserInfo.Controls.Add(this.lblCurrentUser);
            this.pnUserInfo.Controls.Add(this.btCancel);
            this.pnUserInfo.Controls.Add(this.btOK);
            this.pnUserInfo.Controls.Add(this.gbOrganization);
            this.pnUserInfo.Controls.Add(this.gbContacts);
            this.pnUserInfo.Controls.Add(this.gbCommon);
            this.pnUserInfo.Controls.Add(this.gbPhoto);
            this.pnUserInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnUserInfo.Enabled = false;
            this.pnUserInfo.Location = new System.Drawing.Point(0, 319);
            this.pnUserInfo.Name = "pnUserInfo";
            this.pnUserInfo.Size = new System.Drawing.Size(836, 414);
            this.pnUserInfo.TabIndex = 0;
            // 
            // lblBossString
            // 
            this.lblBossString.AutoSize = true;
            this.lblBossString.Location = new System.Drawing.Point(180, 394);
            this.lblBossString.Name = "lblBossString";
            this.lblBossString.Size = new System.Drawing.Size(41, 13);
            this.lblBossString.TabIndex = 20;
            this.lblBossString.Text = "label13";
            this.lblBossString.Visible = false;
            // 
            // lblGridUserName
            // 
            this.lblGridUserName.AutoSize = true;
            this.lblGridUserName.Location = new System.Drawing.Point(457, 2);
            this.lblGridUserName.Name = "lblGridUserName";
            this.lblGridUserName.Size = new System.Drawing.Size(137, 13);
            this.lblGridUserName.TabIndex = 7;
            this.lblGridUserName.Text = "Имя пользователя гриды";
            this.lblGridUserName.Visible = false;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(131, 2);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(154, 13);
            this.lblCurrentUser.TabIndex = 6;
            this.lblCurrentUser.Text = "Имя текущего пользователя";
            this.lblCurrentUser.Visible = false;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(588, 354);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(95, 37);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(453, 354);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(95, 37);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "Сохранить";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // gbOrganization
            // 
            this.gbOrganization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrganization.Controls.Add(this.btSetBoss);
            this.gbOrganization.Controls.Add(this.dtStartJob);
            this.gbOrganization.Controls.Add(this.txtBoss);
            this.gbOrganization.Controls.Add(this.txtDep);
            this.gbOrganization.Controls.Add(this.txtTitle);
            this.gbOrganization.Controls.Add(this.label9);
            this.gbOrganization.Controls.Add(this.label10);
            this.gbOrganization.Controls.Add(this.label11);
            this.gbOrganization.Controls.Add(this.label12);
            this.gbOrganization.Location = new System.Drawing.Point(368, 191);
            this.gbOrganization.Name = "gbOrganization";
            this.gbOrganization.Size = new System.Drawing.Size(402, 148);
            this.gbOrganization.TabIndex = 3;
            this.gbOrganization.TabStop = false;
            this.gbOrganization.Text = "Организация";
            // 
            // btSetBoss
            // 
            this.btSetBoss.Location = new System.Drawing.Point(312, 88);
            this.btSetBoss.Name = "btSetBoss";
            this.btSetBoss.Size = new System.Drawing.Size(75, 23);
            this.btSetBoss.TabIndex = 20;
            this.btSetBoss.Text = "Задать";
            this.btSetBoss.UseVisualStyleBackColor = true;
            this.btSetBoss.Click += new System.EventHandler(this.btSetBoss_Click);
            // 
            // dtStartJob
            // 
            this.dtStartJob.CustomFormat = " ";
            this.dtStartJob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartJob.Location = new System.Drawing.Point(118, 113);
            this.dtStartJob.Name = "dtStartJob";
            this.dtStartJob.Size = new System.Drawing.Size(183, 20);
            this.dtStartJob.TabIndex = 19;
            this.dtStartJob.ValueChanged += new System.EventHandler(this.dtPicker_ValueChanged);
            // 
            // txtBoss
            // 
            this.txtBoss.Location = new System.Drawing.Point(118, 88);
            this.txtBoss.Name = "txtBoss";
            this.txtBoss.ReadOnly = true;
            this.txtBoss.Size = new System.Drawing.Size(183, 20);
            this.txtBoss.TabIndex = 18;
            this.txtBoss.TextChanged += new System.EventHandler(this.txtXXX_TextChanged);
            // 
            // txtDep
            // 
            this.txtDep.Location = new System.Drawing.Point(118, 63);
            this.txtDep.Name = "txtDep";
            this.txtDep.Size = new System.Drawing.Size(236, 20);
            this.txtDep.TabIndex = 17;
            this.txtDep.TextChanged += new System.EventHandler(this.txtXXX_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(118, 39);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(236, 20);
            this.txtTitle.TabIndex = 16;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtXXX_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Принят";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Руководитель";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Отдел";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Должность";
            // 
            // gbContacts
            // 
            this.gbContacts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbContacts.Controls.Add(this.linkMain);
            this.gbContacts.Controls.Add(this.txtMobile);
            this.gbContacts.Controls.Add(this.txtLink);
            this.gbContacts.Controls.Add(this.txtSIP);
            this.gbContacts.Controls.Add(this.label4);
            this.gbContacts.Controls.Add(this.label3);
            this.gbContacts.Controls.Add(this.label2);
            this.gbContacts.Controls.Add(this.label1);
            this.gbContacts.Location = new System.Drawing.Point(66, 264);
            this.gbContacts.Name = "gbContacts";
            this.gbContacts.Size = new System.Drawing.Size(282, 127);
            this.gbContacts.TabIndex = 2;
            this.gbContacts.TabStop = false;
            this.gbContacts.Text = "Контакты";
            // 
            // linkMain
            // 
            this.linkMain.AutoSize = true;
            this.linkMain.Location = new System.Drawing.Point(83, 20);
            this.linkMain.Name = "linkMain";
            this.linkMain.Size = new System.Drawing.Size(0, 13);
            this.linkMain.TabIndex = 7;
            this.linkMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMain_LinkClicked);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(86, 92);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(161, 20);
            this.txtMobile.TabIndex = 6;
            this.txtMobile.TextChanged += new System.EventHandler(this.txtXXX_TextChanged);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(86, 67);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(161, 20);
            this.txtLink.TabIndex = 5;
            this.txtLink.TextChanged += new System.EventHandler(this.txtXXX_TextChanged);
            // 
            // txtSIP
            // 
            this.txtSIP.Location = new System.Drawing.Point(86, 41);
            this.txtSIP.Name = "txtSIP";
            this.txtSIP.Size = new System.Drawing.Size(161, 20);
            this.txtSIP.TabIndex = 4;
            this.txtSIP.TextChanged += new System.EventHandler(this.txtXXX_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Мобильный";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Link";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SIP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Почта";
            // 
            // gbCommon
            // 
            this.gbCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCommon.Controls.Add(this.dtBDay);
            this.gbCommon.Controls.Add(this.chDontShowYear);
            this.gbCommon.Controls.Add(this.txtMidName);
            this.gbCommon.Controls.Add(this.txtFirstName);
            this.gbCommon.Controls.Add(this.txtLastName);
            this.gbCommon.Controls.Add(this.label5);
            this.gbCommon.Controls.Add(this.label6);
            this.gbCommon.Controls.Add(this.label7);
            this.gbCommon.Controls.Add(this.label8);
            this.gbCommon.Location = new System.Drawing.Point(368, 18);
            this.gbCommon.Name = "gbCommon";
            this.gbCommon.Size = new System.Drawing.Size(402, 167);
            this.gbCommon.TabIndex = 1;
            this.gbCommon.TabStop = false;
            this.gbCommon.Text = "Общие";
            // 
            // dtBDay
            // 
            this.dtBDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtBDay.CustomFormat = " ";
            this.dtBDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBDay.Location = new System.Drawing.Point(120, 101);
            this.dtBDay.Name = "dtBDay";
            this.dtBDay.Size = new System.Drawing.Size(181, 20);
            this.dtBDay.TabIndex = 13;
            this.dtBDay.ValueChanged += new System.EventHandler(this.dtPicker_ValueChanged);
            // 
            // chDontShowYear
            // 
            this.chDontShowYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chDontShowYear.AutoSize = true;
            this.chDontShowYear.Location = new System.Drawing.Point(23, 136);
            this.chDontShowYear.Name = "chDontShowYear";
            this.chDontShowYear.Size = new System.Drawing.Size(176, 17);
            this.chDontShowYear.TabIndex = 12;
            this.chDontShowYear.Text = "Не отображать год рождения";
            this.chDontShowYear.UseVisualStyleBackColor = true;
            this.chDontShowYear.CheckedChanged += new System.EventHandler(this.chDontShowYear_CheckedChanged);
            // 
            // txtMidName
            // 
            this.txtMidName.Location = new System.Drawing.Point(120, 75);
            this.txtMidName.Name = "txtMidName";
            this.txtMidName.Size = new System.Drawing.Size(234, 20);
            this.txtMidName.TabIndex = 10;
            this.txtMidName.TextChanged += new System.EventHandler(this.txtXXX_TextChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(120, 50);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(234, 20);
            this.txtFirstName.TabIndex = 9;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtXXX_TextChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(120, 26);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(234, 20);
            this.txtLastName.TabIndex = 8;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtXXX_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Дата рождения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Отчество";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Имя";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Фамилия";
            // 
            // gbPhoto
            // 
            this.gbPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPhoto.Controls.Add(this.btClearPhoto);
            this.gbPhoto.Controls.Add(this.btLoadPhoto);
            this.gbPhoto.Controls.Add(this.pbPhoto);
            this.gbPhoto.Location = new System.Drawing.Point(66, 18);
            this.gbPhoto.Name = "gbPhoto";
            this.gbPhoto.Size = new System.Drawing.Size(282, 239);
            this.gbPhoto.TabIndex = 0;
            this.gbPhoto.TabStop = false;
            this.gbPhoto.Text = "Фото";
            // 
            // btClearPhoto
            // 
            this.btClearPhoto.Location = new System.Drawing.Point(144, 205);
            this.btClearPhoto.Name = "btClearPhoto";
            this.btClearPhoto.Size = new System.Drawing.Size(75, 23);
            this.btClearPhoto.TabIndex = 5;
            this.btClearPhoto.Text = "Очистить";
            this.btClearPhoto.UseVisualStyleBackColor = true;
            this.btClearPhoto.Click += new System.EventHandler(this.btClearPhoto_Click);
            // 
            // btLoadPhoto
            // 
            this.btLoadPhoto.Location = new System.Drawing.Point(57, 205);
            this.btLoadPhoto.Name = "btLoadPhoto";
            this.btLoadPhoto.Size = new System.Drawing.Size(75, 23);
            this.btLoadPhoto.TabIndex = 4;
            this.btLoadPhoto.Text = "Загрузить";
            this.btLoadPhoto.UseVisualStyleBackColor = true;
            this.btLoadPhoto.Click += new System.EventHandler(this.btLoadPhoto_Click);
            // 
            // pbPhoto
            // 
            this.pbPhoto.Location = new System.Drawing.Point(57, 29);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(162, 160);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 3;
            this.pbPhoto.TabStop = false;
            // 
            // linkAbout
            // 
            this.linkAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkAbout.AutoSize = true;
            this.linkAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkAbout.Location = new System.Drawing.Point(750, 711);
            this.linkAbout.Name = "linkAbout";
            this.linkAbout.Size = new System.Drawing.Size(75, 13);
            this.linkAbout.TabIndex = 6;
            this.linkAbout.TabStop = true;
            this.linkAbout.Text = "О программе";
            this.linkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.grAddress);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(0, 43);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(836, 276);
            this.pnGrid.TabIndex = 7;
            // 
            // grAddress
            // 
            this.grAddress.AllowUserToAddRows = false;
            this.grAddress.AllowUserToDeleteRows = false;
            this.grAddress.AllowUserToOrderColumns = true;
            this.grAddress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grAddress.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grAddress.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grAddress.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grAddress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.departmentDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.mailDataGridViewTextBoxColumn,
            this.clGUID,
            this.clsAMAccountName});
            this.grAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grAddress.Location = new System.Drawing.Point(0, 0);
            this.grAddress.MinimumSize = new System.Drawing.Size(0, 100);
            this.grAddress.Name = "grAddress";
            this.grAddress.ReadOnly = true;
            this.grAddress.RowHeadersVisible = false;
            this.grAddress.RowTemplate.ReadOnly = true;
            this.grAddress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grAddress.Size = new System.Drawing.Size(836, 276);
            this.grAddress.TabIndex = 2;
            this.grAddress.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grAddress_CellContentClick);
            this.grAddress.SelectionChanged += new System.EventHandler(this.grAddress_SelectionChanged);
            // 
            // aDUserBindingSource
            // 
            this.aDUserBindingSource.DataSource = typeof(AddressBook.CustomUser);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Должность";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Департамент";
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            this.departmentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.phoneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Телефон";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mailDataGridViewTextBoxColumn
            // 
            this.mailDataGridViewTextBoxColumn.DataPropertyName = "Mail";
            this.mailDataGridViewTextBoxColumn.HeaderText = "E-Mail";
            this.mailDataGridViewTextBoxColumn.Name = "mailDataGridViewTextBoxColumn";
            this.mailDataGridViewTextBoxColumn.ReadOnly = true;
            this.mailDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mailDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clGUID
            // 
            this.clGUID.HeaderText = "GUID";
            this.clGUID.Name = "clGUID";
            this.clGUID.ReadOnly = true;
            this.clGUID.Visible = false;
            // 
            // clsAMAccountName
            // 
            this.clsAMAccountName.HeaderText = "clsAMAccountName";
            this.clsAMAccountName.Name = "clsAMAccountName";
            this.clsAMAccountName.ReadOnly = true;
            this.clsAMAccountName.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 733);
            this.Controls.Add(this.pnGrid);
            this.Controls.Add(this.linkAbout);
            this.Controls.Add(this.pnUserInfo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Address Book";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnUserInfo.ResumeLayout(false);
            this.pnUserInfo.PerformLayout();
            this.gbOrganization.ResumeLayout(false);
            this.gbOrganization.PerformLayout();
            this.gbContacts.ResumeLayout(false);
            this.gbContacts.PerformLayout();
            this.gbCommon.ResumeLayout(false);
            this.gbCommon.PerformLayout();
            this.gbPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDUserBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.LinkLabel lblExcel;
        private System.Windows.Forms.BindingSource aDUserBindingSource;
        private System.Windows.Forms.Panel pnUserInfo;
        private System.Windows.Forms.GroupBox gbContacts;
        private System.Windows.Forms.GroupBox gbCommon;
        private System.Windows.Forms.GroupBox gbPhoto;
        private System.Windows.Forms.GroupBox gbOrganization;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Button btLoadPhoto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.TextBox txtSIP;
        private System.Windows.Forms.LinkLabel linkMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMidName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.CheckBox chDontShowYear;
        private System.Windows.Forms.TextBox txtBoss;
        private System.Windows.Forms.TextBox txtDep;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.LinkLabel linkAbout;
        private System.Windows.Forms.Panel pnGrid;
        private System.Windows.Forms.DataGridView grAddress;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.Button btClearPhoto;
        private System.Windows.Forms.DateTimePicker dtBDay;
        private System.Windows.Forms.DateTimePicker dtStartJob;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblGridUserName;
        private System.Windows.Forms.Label lblBossString;
        private System.Windows.Forms.Button btSetBoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn mailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clsAMAccountName;



    }
}

