using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Text.RegularExpressions;

namespace AddressBook
{
    
    // Нормальная 
    enum  ProgramMode
    {
        ManagerMode,//текущ пользователь входит в группу менеджеров
        UserMode,   //текущ пользователь может редактировать себя
        ReadMode    //только для чтения
    }

    public partial class MainForm : Form
    {

    #region Соответствия перечислений реквизитов пользователя и других полей
              
        Dictionary<Control, ADpar> FormControlsAndUserFields = new Dictionary<Control, ADpar>();

        void InitializeCtrlUserNames()
        {
            FormControlsAndUserFields.Add(pbPhoto, ADpar.photo);
            FormControlsAndUserFields.Add(txtFirstName, ADpar.firstName);
            FormControlsAndUserFields.Add(txtLastName, ADpar.lastName);
            FormControlsAndUserFields.Add(txtMidName, ADpar.midName);
            FormControlsAndUserFields.Add(dtBDay, ADpar.birthday);
            FormControlsAndUserFields.Add(chDontShowYear, ADpar.dontShowBirthYear);
            //CtrlUserNames.Add(ADpar.mail, txt
            FormControlsAndUserFields.Add(txtSIP, ADpar.phone);
            FormControlsAndUserFields.Add(txtLink, ADpar.link);
            FormControlsAndUserFields.Add(txtMobile, ADpar.mobile);
            FormControlsAndUserFields.Add(txtTitle, ADpar.title);
            FormControlsAndUserFields.Add(txtDep, ADpar.department);
            FormControlsAndUserFields.Add(txtBoss, ADpar.bossAD);
            FormControlsAndUserFields.Add(dtStartJob, ADpar.startJob);
        }

   #endregion

    #region Форма

        ProgramMode CurMode = ProgramMode.ReadMode;
        LdapType CurLDAP = LdapType.ReadOnly;

        public MainForm()
            {

                CurLDAP = DE.ObtainRODC();
                //MessageBox.Show(CurLDAP.ToString());
                if (CurLDAP == LdapType.Writable)
                {
                    CurrentUser.FindIfManager();
                    if (CurrentUser.isManager)
                        CurMode = ProgramMode.ManagerMode;
                    else
                        CurMode = ProgramMode.UserMode;
                }

                InitializeComponent();
                InitializeCtrlUserNames();
                InitializeInterface();
                
            }

        private void InitializeInterface()
        {
            this.Text = this.Text + " v." + this.ProductVersion;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            linkAbout.Visible = Properties.Settings.Default.showCopyRight;
            btReload.Visible = Properties.Settings.Default.showReload;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ReLoadUsers();
        }
        //перегрузка пользователей
        private void ReLoadUsers()
        {
            users = DE.GetUsers();
            //grAddress.DataSource = users;
            FillGrAddresses();
            SelectTopRow();
            DisEnAbleAllControls(CurMode == ProgramMode.ManagerMode);
            //AddTestRows();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            showMidName();
        }
        //показывать отчество
        private void showMidName()
        {
            bool showMidName = Properties.Settings.Default.ShowMidName;
            label6.Visible = showMidName;
            txtMidName.Visible = showMidName;
            label7.Text = showMidName ? "Имя" : "Имя и отчество";

            if (!showMidName)
            {
                int HeightSdvig = dtBDay.Location.Y - txtMidName.Location.Y;
                gbCommon.Height -= HeightSdvig;
                gbOrganization.Location = new Point(gbOrganization.Location.X, gbOrganization.Location.Y - 2 * HeightSdvig / 3);
            }
        }

        //пользователи
        CustomUserList users = new CustomUserList();
       
        CustomUser fCurGridUser = new CustomUser();
       
        string GroupName = Properties.Settings.Default.GroupName;

       
        //хранение изменений
        CustomUser ChangesHolder = new CustomUser();

        bool fChanged = false;
        
        private string NewPhotoPath = "";
        
        private void setChanged()
            { fChanged = true; }
        
        private void dropChanges()
            {
                fChanged = false;
                ChangesHolder.Copy(fCurGridUser);
            }
        //пользователи не найдены
        private void ShowUsersNotFoundMessage()
        {
            this.Text = this.Text +  "Пользователи не найдены";
        }
       
    #endregion

    #region Грида grAddress

        //Заполнение гриды
        private void FillGrAddresses()
        {
            grAddress.Rows.Clear();
            foreach (CustomUser user in users)
            {
                grAddress.Rows.Add();
                DataGridViewRow row = grAddress.Rows[grAddress.Rows.Count - 1];
                row.Cells[clGUID.Name].Value = user.GUID;
                row.Cells[nameDataGridViewTextBoxColumn.Name].Value = user[ADpar.cn];
                row.Cells[titleDataGridViewTextBoxColumn.Name].Value = user.Title;
                row.Cells[departmentDataGridViewTextBoxColumn.Name].Value = user.Department;
                row.Cells[mailDataGridViewTextBoxColumn.Name].Value = user.Mail;
                row.Cells[phoneDataGridViewTextBoxColumn.Name].Value = user.Phone;
                row.Cells[clsAMAccountName.Name].Value = user.SAMAccountName;
            }
            grAddress.Sort(nameDataGridViewTextBoxColumn, ListSortDirection.Ascending);
            //фокус на гриду
            if (grAddress.CanFocus)
            {
                grAddress.Focus();
            }
            
              
        }
        //Выделение первого пользователя
        private void SelectTopRow()
        {
            grAddress.ClearSelection();
            if (grAddress.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grAddress.Rows)
                {
                    if (row.Visible)
                    {
                        grAddress.FirstDisplayedScrollingRowIndex = row.Index;
                        row.Selected = true;
                        break;
                    }
                }             
            }
        }
        //Определение CurUser
        private void grAddress_SelectionChanged(object sender, EventArgs e)
        {
            if (grAddress.SelectedRows.Count > 0)
            {
                Guid? CurGuid = (Guid?)grAddress.SelectedRows[0].Cells[clGUID.Index].Value;
                fCurGridUser = users.GetUserByGuid(CurGuid);
                ChangesHolder.Copy(fCurGridUser);
                dropChanges();
                FillUserInfo();
            }
        }
        //Тестовые пользователи
        private void AddTestRows()
        {
            grAddress.Rows.Add();
            grAddress.Rows[0].Cells[nameDataGridViewTextBoxColumn.Name].Value = "Галигузов Максим Леонидович";
            grAddress.Rows[0].Cells[departmentDataGridViewTextBoxColumn.Name].Value = "ЦОД";
            grAddress.Rows[0].Cells[mailDataGridViewTextBoxColumn.Name].Value = "sadstatue128@yandex.ru";
            grAddress.Rows[0].Cells[phoneDataGridViewTextBoxColumn.Name].Value = "368-338";
            grAddress.Rows[0].Cells[titleDataGridViewTextBoxColumn.Name].Value = "Сисадмин";

            grAddress.Rows.Add();
            grAddress.Rows[1].Cells[nameDataGridViewTextBoxColumn.Name].Value = "Алехин Александр Андреевич";
            grAddress.Rows[1].Cells[departmentDataGridViewTextBoxColumn.Name].Value = "ЦОД";
            grAddress.Rows[1].Cells[mailDataGridViewTextBoxColumn.Name].Value = "alehinala@gmail.com";
            grAddress.Rows[1].Cells[phoneDataGridViewTextBoxColumn.Name].Value = "123";
            grAddress.Rows[1].Cells[titleDataGridViewTextBoxColumn.Name].Value = "Младший сисадмин";

        }

        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grAddress.Rows.Count; i++)
            {
                grAddress.Rows[i].Visible = false;
                for (int c = 0; c < grAddress.Columns.Count; c++)
                {
                    if (!grAddress.Columns[c].Visible)
                        continue;
                    var Value = grAddress[c, i].Value;
                    if (Value != null)
                    {
                        if (grAddress[c, i].Value.ToString().Contains(filterBox.Text, StringComparison.OrdinalIgnoreCase))
                        {
                            grAddress.Rows[i].Visible = true;
                            break;
                        }
                    }
                }
            }
            grAddress.Refresh();
            SelectTopRow();
        }
        
    #endregion

    #region Кнопки формы

        //выгрузка в Эксель
        private void lblExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Excel.Application ExcelApp = new Excel.Application();
            //устанавливаем параметры языка для работы в англ версии
            System.Globalization.CultureInfo oldCI = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Excel.Workbook exWorkBook = ExcelApp.Workbooks.Add();
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
            Excel.Worksheet exWorkSheet = (Excel.Worksheet)exWorkBook.Worksheets[1];
            //заголовки 
            foreach (DataGridViewColumn column in grAddress.Columns)
            {
                if (column.Visible)
                { 
                    int RowIndex = 1;
                    int ColIndex = column.Index + 1;
                    string header = column.HeaderText;
                    exWorkSheet.Cells[RowIndex, ColIndex] = header;
                }
            }
            //украшательства заголовков
            Excel.Range headerRange = exWorkSheet.get_Range("A1", "E1");
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.Font.Bold = true;
            //контент
            foreach (DataGridViewRow row in grAddress.Rows)
            {
                int RowIndex = row.Index + 2;
                foreach (DataGridViewColumn column in grAddress.Columns)
                {
                    if (column.Visible)
                    {
                        int ColIndex = column.Index + 1;
                        exWorkSheet.Cells[RowIndex, ColIndex] =
                            row.Cells[column.Index].Value;
                    }
                }
            }
            headerRange.EntireColumn.AutoFit();

            //ставим язык такой же, как был
            Thread.CurrentThread.CurrentCulture = oldCI;
        }
        //клик по почте в гриде
        private void grAddress_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == mailDataGridViewTextBoxColumn.Index)
            {
                if ((e.ColumnIndex > -1) && (e.RowIndex > -1))
                { 
                    string mail = string.Empty;
                    if (grAddress.Rows[e.RowIndex].Cells[mailDataGridViewTextBoxColumn.Name].Value != null)
                        mail = grAddress.Rows[e.RowIndex].Cells[mailDataGridViewTextBoxColumn.Name].Value.ToString();
                    MailTo.Send(mail);
                }
            }
        }
        //клик по почте на форме пользователя
        private void linkMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string mail = (sender as LinkLabel).Text;
            MailTo.Send(mail);
        }        
        //клик о программу
        private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutInfo();
        }
        //F1
        private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            AboutInfo();
        }
        //О программе
        private static void AboutInfo()
        {
            AboutForm HelpForm = new AboutForm();
            HelpForm.ShowDialog();
        }
        //перегрузка
        private void button1_Click(object sender, EventArgs e)
        {
            ReLoadUsers();
        }
        
    #endregion
                    
    #region Заполнение инфо пользователя
        
        //инфо пользователя
        public void FillUserInfo()
        {
            enableUserControls();            
            
            //фото
            pbPhoto.Image = fCurGridUser.Photo; ;
            //основная информация
            txtFirstName.Text = fCurGridUser.FirstName;
            txtMidName.Text = fCurGridUser.MidName;
            txtLastName.Text = fCurGridUser.LastName;

            SetStartPickerFormat(fCurGridUser.Birthday, dtBDay);          
            chDontShowYear.Checked = fCurGridUser.DontShowBirthYear;
            //контакты
            linkMain.Text = fCurGridUser.Mail;
            txtSIP.Text = fCurGridUser.Phone;
            txtLink.Text = fCurGridUser.Link;
            txtMobile.Text = fCurGridUser.Mobile;
            //организация
            txtTitle.Text = fCurGridUser.Title;
            txtDep.Text = fCurGridUser.Department;
            txtBoss.Text = fCurGridUser.Boss;
            SetStartPickerFormat(fCurGridUser.StartJob, dtStartJob);

            if (Properties.Settings.Default.showReload)
            { 
            lblCurrentUser.Visible = true;
            lblCurrentUser.Text = CurrentUser.SAMAccountName;

            lblGridUserName.Visible = true;
            lblGridUserName.Text = fCurGridUser.SAMAccountName;
            }
        }
        //задать начальный формат даты
        private void SetStartPickerFormat(DateTime date, DateTimePicker picker)
        {
            if (date.Equals(CustomUser.DEFAULT_DATE))
            {
                picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                picker.CustomFormat = " ";
            }//показываем дату рождения без года только остальным пользователям
            else if ((picker == dtBDay) && fCurGridUser.DontShowBirthYear && (CurMode != ProgramMode.ManagerMode) && !isCurAndGridUsersEquals())
            {
                picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                picker.CustomFormat = "d MMMM";                
            }
            else
            {
                if (picker.Format == System.Windows.Forms.DateTimePickerFormat.Custom)
                    picker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            }
            picker.Value = date;
        }
        //доступ пользователя
        private void enableUserControls()
        {
            if (fCurGridUser.GUID == null)
            {
                //блокируем всю панель
                pnUserInfo.Enabled = false;
                return;
            }
            //разблокируем панель
            pnUserInfo.Enabled = true;            
            if (CurMode == ProgramMode.ManagerMode) 
                return;
            
            DisEnAbleUserControls(isCurAndGridUsersEquals());           
        }
        //если пользователи гриды и текущий совпадают
        bool isCurAndGridUsersEquals()
        {
            return CurrentUser.SAMAccountName.Equals(fCurGridUser.SAMAccountName, StringComparison.OrdinalIgnoreCase);
        }
        //Открыть менеджеру все контролы
        private void DisEnAbleAllControls(bool yes)
        {
            //основная информация            
            txtFirstName.ReadOnly = !yes;
            txtMidName.ReadOnly = !yes;
            txtLastName.ReadOnly = !yes;
            dtBDay.Enabled = yes;
            chDontShowYear.Enabled = yes;
            //контакты
            //linkMain.Text = fCurUser.Mail;
            txtSIP.ReadOnly = !yes;
            txtLink.ReadOnly = !yes;
            txtMobile.ReadOnly = !yes;
            //организация
            txtTitle.ReadOnly = !yes;
            txtDep.ReadOnly = !yes;
            //txtBoss.ReadOnly = !yes;
            dtStartJob.Enabled = yes;
            //кнопки
            btLoadPhoto.Enabled = yes;
            btClearPhoto.Enabled = yes;
            btOK.Enabled = yes;
            btCancel.Enabled = yes;
            btSetBoss.Enabled = yes;
        }
        //Запретить пользователю редактировать запись
        private void DisEnAbleUserControls (bool yes)
        {
            /*btLoadPhoto.Enabled = yes;
            btClearPhoto.Enabled = yes; */          
            chDontShowYear.Enabled = yes;
            txtMobile.ReadOnly = !yes;
            btOK.Enabled = yes;
            btCancel.Enabled = yes;
        }
        
    #endregion

    #region Изменение инфо пользователя
        //изменение даты
        private void dtPicker_ValueChanged(object sender, EventArgs e)
        {            
            var picker = sender as DateTimePicker;
            
            //!!!!костыль типа ModifiedAfterEnter
            if (!picker.Focused)
                return;

            //делаем формат обычным
            if (picker.Format == DateTimePickerFormat.Custom)
                picker.Format = DateTimePickerFormat.Long;

            ADpar attr = FormControlsAndUserFields[picker];
            ChangesHolder[attr] = picker.Value;
            setChanged();
        }
        //изменение текстовых атрибутов
        private void txtXXX_TextChanged(object sender, EventArgs e)
        {
            if (!((sender as TextBox).Modified))
                return;

            if (fCurGridUser.GUID == null)
                return;
            //находим соотв контролу пользовательский атрибут
            ADpar attr = FormControlsAndUserFields[(Control)sender];
            //босса изменяем только по кнопке 
            if (attr == ADpar.bossAD)
                return;
            
            //инициализируем атрибут новым значением
            ChangesHolder[attr] = (sender as TextBox).Text;
            //если изменяются части имени - изменим и все имя
            if ((attr == ADpar.firstName) || (attr == ADpar.midName) || (attr == ADpar.lastName))
            {
                ChangesHolder.DislpayName = ChangesHolder.FirstName + " " +
                    (Properties.Settings.Default.ShowMidName ? (ChangesHolder.MidName + " ") : string.Empty) +
                    ChangesHolder.LastName;

                ChangesHolder.Cn = ChangesHolder.LastName + " " +
                    (Properties.Settings.Default.ShowMidName ? (ChangesHolder.MidName + " ") : string.Empty) +
                    ChangesHolder.FirstName;
            }
            setChanged();
        }
        //изменение отображение года
        private void chDontShowYear_CheckedChanged(object sender, EventArgs e)
        {
            if (fCurGridUser.GUID == null)
                return;

            ChangesHolder.DontShowBirthYear = (sender as CheckBox).Checked;
            setChanged();
        }
        //кнопка "загрузка фото"
        private void btLoadPhoto_Click(object sender, EventArgs e)
        {
            if (fCurGridUser.GUID == null)
                return;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Выберите фотографию";
            openFileDialog1.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp" ;
            // выход, если была нажата кнопка Отмена и прочие (кроме ОК)
            if (openFileDialog1.ShowDialog() != DialogResult.OK) 
                return;
            pbPhoto.Image = new Bitmap(openFileDialog1.FileName);
            //сохраняем путь до файла в переменную, чтобы конвертировать это дело в байты
            NewPhotoPath = openFileDialog1.FileName;
            ChangesHolder.Photo = pbPhoto.Image as Bitmap;            
            setChanged();
        }
        //кнопка "очистить фото"
        private void btClearPhoto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить фотографию?",
                "Редактирование пользователя", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question) !=
                System.Windows.Forms.DialogResult.OK)
                return;
            ChangesHolder.Photo = null;
            pbPhoto.Image = CustomUser.DEFAULT_PHOTO;
            setChanged();
        }
        //кнопка "отмена"
        private void btCancel_Click(object sender, EventArgs e)
        {
            dropChanges();
            FillUserInfo();
        }
        //кнопка "сохранить"
        private void btOK_Click(object sender, EventArgs e)
        {
            if ((fCurGridUser.GUID == null) || !fChanged)
                return;
            try { 
                string Msg = "Иземенения в Active Directory внесены успешно.\n" +
                    "Изменены следующие атрибуты пользователя " + fCurGridUser.DislpayName + ":\n";

                //Если нету никаких изменений, выходим
                List<ADpar> Differences;
                if (!fCurGridUser.HaveDifferences(ChangesHolder, out Differences))
                    return;

                bool WriteResult = false;
                foreach (ADpar attr in Differences)
                {                        
                    LdapField ADfield = Global.LdapFields[attr];

                    if (attr == ADpar.cn)
                        continue;
                    
                    WriteResult = WriteChangesToAD(attr);
                    
                    if (WriteResult)
                        Msg += "\n" + ADfield.Description;
                        else
                        return;
                }
                if (Differences.Contains(ADpar.cn))
                {
                    WriteResult = DE.ChangeCn(ChangesHolder);
                    
                    if (WriteResult)
                        Msg += "\n" + Global.LdapFields[ADpar.cn].Description;
                    else
                        return;
                }
                
                //копируем пользователя обратно в текущего
                fCurGridUser.Copy(ChangesHolder);
                MessageBox.Show(Msg,
                    "Успешное сохранение",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            finally 
            { 
                dropChanges();
                DE.RefreshUser(fCurGridUser);
                string SAM = fCurGridUser.SAMAccountName;
                FillGrAddresses();
                RestoreSelectedRow(SAM);            
            }
        }

        private void RestoreSelectedRow(string SAM)
        {
            foreach (DataGridViewRow row in grAddress.Rows)
            {
                if (row.Cells[clsAMAccountName.Index].Value.ToString().Equals(SAM))
                {
                    grAddress.ClearSelection();
                    row.Selected = true;
                    break;
                }
            }
        }

        private bool WriteChangesToAD(ADpar attr)
        {
            LdapField ADfield = Global.LdapFields[attr];
            bool WriteResult = false;

            //фотка
            if (ADfield.FieldType == typeof(Bitmap))
            {
                if (ChangesHolder.Photo == null)//очищение фото
                {
                    WriteResult = fCurGridUser.ClearPhotoFromAD();
                    ChangesHolder.Photo = CustomUser.DEFAULT_PHOTO;
                }
                else //загрузка фото
                {
                    byte[] imageByteArray = File.ReadAllBytes(NewPhotoPath);
                    WriteResult = fCurGridUser.WritePhotoToAD(imageByteArray);
                }

            }//строковые атрибуты
            else if (ADfield.FieldType == typeof(string))
            {
                //попытка записи в AD по имени свойства и значению атрибута
                WriteResult = fCurGridUser.WriteStrToAD(ADfield.LdapName, ChangesHolder[attr].ToString());
            }
            //атрибуты даты
            else if (ADfield.FieldType == typeof(DateTime))
            {
                string DateTimeToAD = Convert.ToDateTime(ChangesHolder[attr]).ToString("dd.MM.yyyy");
                WriteResult = fCurGridUser.WriteStrToAD(ADfield.LdapName, DateTimeToAD);
            }//изменение отображения года
            else if (ADfield.FieldType == typeof(bool))
            {
                WriteResult = fCurGridUser.WriteShowYearToAD(ChangesHolder.DontShowBirthYear);
            }

            return WriteResult;
        }
        //кнопка "установить босса"
        private void btSetBoss_Click(object sender, EventArgs e)
        {
            ChoiseBossForm bossForm = new ChoiseBossForm();
            if (bossForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ChangesHolder.Boss = CurrentBoss.boss.DistName;
                txtBoss.Text = CurrentBoss.boss.DislpayName;
                setChanged();
            }
        }
    #endregion          
      

    }

}

