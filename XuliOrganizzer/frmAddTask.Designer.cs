namespace XuliOrganizzer
{
    partial class frmAddTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddTask));
            this.lblTask = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblStartDateTime = new System.Windows.Forms.Label();
            this.dtStartDateTime = new System.Windows.Forms.DateTimePicker();
            this.dtNextDateTime = new System.Windows.Forms.DateTimePicker();
            this.lblNextDateTime = new System.Windows.Forms.Label();
            this.groupTimeType = new System.Windows.Forms.GroupBox();
            this.cmbYearDay = new System.Windows.Forms.ComboBox();
            this.cmbMonthDay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.rbTimeType5 = new System.Windows.Forms.RadioButton();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.rbTimeType4 = new System.Windows.Forms.RadioButton();
            this.rbTimeType3 = new System.Windows.Forms.RadioButton();
            this.cmbWeekDay = new System.Windows.Forms.ComboBox();
            this.rbTimeType2 = new System.Windows.Forms.RadioButton();
            this.rbTimeType1 = new System.Windows.Forms.RadioButton();
            this.rbTimeType0 = new System.Windows.Forms.RadioButton();
            this.groupActionType = new System.Windows.Forms.GroupBox();
            this.rbActionType2 = new System.Windows.Forms.RadioButton();
            this.rbActionType1 = new System.Windows.Forms.RadioButton();
            this.rbActionType0 = new System.Windows.Forms.RadioButton();
            this.groupSoundType = new System.Windows.Forms.GroupBox();
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.btnOpenSoundFile = new System.Windows.Forms.Button();
            this.rbSoundType2 = new System.Windows.Forms.RadioButton();
            this.rbSoundType1 = new System.Windows.Forms.RadioButton();
            this.rbSoundType0 = new System.Windows.Forms.RadioButton();
            this.lblProgramPath = new System.Windows.Forms.Label();
            this.txtProgramPath = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtProgramParams = new System.Windows.Forms.TextBox();
            this.lblProgramParams = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupRemindType = new System.Windows.Forms.GroupBox();
            this.rbRemindType1 = new System.Windows.Forms.RadioButton();
            this.rbRemindType0 = new System.Windows.Forms.RadioButton();
            this.txtRemind = new System.Windows.Forms.TextBox();
            this.lblFormMsg = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.chkProgramHide = new System.Windows.Forms.CheckBox();
            this.groupTimeType.SuspendLayout();
            this.groupActionType.SuspendLayout();
            this.groupSoundType.SuspendLayout();
            this.groupRemindType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(2, 9);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(46, 13);
            this.lblTask.TabIndex = 0;
            this.lblTask.Text = "Задача:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(54, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(385, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblStartDateTime
            // 
            this.lblStartDateTime.AutoSize = true;
            this.lblStartDateTime.Location = new System.Drawing.Point(2, 35);
            this.lblStartDateTime.Name = "lblStartDateTime";
            this.lblStartDateTime.Size = new System.Drawing.Size(80, 13);
            this.lblStartDateTime.TabIndex = 2;
            this.lblStartDateTime.Text = "Дата и время:";
            // 
            // dtStartDateTime
            // 
            this.dtStartDateTime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDateTime.Location = new System.Drawing.Point(81, 32);
            this.dtStartDateTime.Name = "dtStartDateTime";
            this.dtStartDateTime.ShowUpDown = true;
            this.dtStartDateTime.Size = new System.Drawing.Size(110, 20);
            this.dtStartDateTime.TabIndex = 3;
            this.dtStartDateTime.ValueChanged += new System.EventHandler(this.dtStartDateTime_ValueChanged);
            // 
            // dtNextDateTime
            // 
            this.dtNextDateTime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtNextDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNextDateTime.Location = new System.Drawing.Point(329, 32);
            this.dtNextDateTime.Name = "dtNextDateTime";
            this.dtNextDateTime.ShowUpDown = true;
            this.dtNextDateTime.Size = new System.Drawing.Size(110, 20);
            this.dtNextDateTime.TabIndex = 5;
            // 
            // lblNextDateTime
            // 
            this.lblNextDateTime.AutoSize = true;
            this.lblNextDateTime.Location = new System.Drawing.Point(195, 35);
            this.lblNextDateTime.Name = "lblNextDateTime";
            this.lblNextDateTime.Size = new System.Drawing.Size(134, 13);
            this.lblNextDateTime.TabIndex = 4;
            this.lblNextDateTime.Text = "Следующее выполнение:";
            // 
            // groupTimeType
            // 
            this.groupTimeType.Controls.Add(this.cmbYearDay);
            this.groupTimeType.Controls.Add(this.cmbMonthDay);
            this.groupTimeType.Controls.Add(this.label4);
            this.groupTimeType.Controls.Add(this.txtN);
            this.groupTimeType.Controls.Add(this.rbTimeType5);
            this.groupTimeType.Controls.Add(this.cmbMonth);
            this.groupTimeType.Controls.Add(this.rbTimeType4);
            this.groupTimeType.Controls.Add(this.rbTimeType3);
            this.groupTimeType.Controls.Add(this.cmbWeekDay);
            this.groupTimeType.Controls.Add(this.rbTimeType2);
            this.groupTimeType.Controls.Add(this.rbTimeType1);
            this.groupTimeType.Controls.Add(this.rbTimeType0);
            this.groupTimeType.Location = new System.Drawing.Point(5, 57);
            this.groupTimeType.Name = "groupTimeType";
            this.groupTimeType.Size = new System.Drawing.Size(245, 186);
            this.groupTimeType.TabIndex = 6;
            this.groupTimeType.TabStop = false;
            this.groupTimeType.Text = "Тип задачи";
            // 
            // cmbYearDay
            // 
            this.cmbYearDay.FormattingEnabled = true;
            this.cmbYearDay.Location = new System.Drawing.Point(100, 115);
            this.cmbYearDay.MaxLength = 2;
            this.cmbYearDay.Name = "cmbYearDay";
            this.cmbYearDay.Size = new System.Drawing.Size(45, 21);
            this.cmbYearDay.TabIndex = 7;
            this.cmbYearDay.SelectedIndexChanged += new System.EventHandler(this.cmbYearDay_SelectedIndexChanged);
            this.cmbYearDay.Leave += new System.EventHandler(this.cmbYearDay_Leave);
            this.cmbYearDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyDigits);
            // 
            // cmbMonthDay
            // 
            this.cmbMonthDay.FormattingEnabled = true;
            this.cmbMonthDay.Location = new System.Drawing.Point(101, 89);
            this.cmbMonthDay.MaxLength = 2;
            this.cmbMonthDay.Name = "cmbMonthDay";
            this.cmbMonthDay.Size = new System.Drawing.Size(45, 21);
            this.cmbMonthDay.TabIndex = 5;
            this.cmbMonthDay.SelectedIndexChanged += new System.EventHandler(this.cmbMonthDay_SelectedIndexChanged);
            this.cmbMonthDay.Leave += new System.EventHandler(this.cmbMonthDay_Leave);
            this.cmbMonthDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyDigits);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "дней";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(102, 142);
            this.txtN.MaxLength = 10;
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(69, 20);
            this.txtN.TabIndex = 10;
            this.txtN.Text = "0";
            this.txtN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyDigits);
            // 
            // rbTimeType5
            // 
            this.rbTimeType5.AutoSize = true;
            this.rbTimeType5.Location = new System.Drawing.Point(8, 144);
            this.rbTimeType5.Name = "rbTimeType5";
            this.rbTimeType5.Size = new System.Drawing.Size(66, 17);
            this.rbTimeType5.TabIndex = 9;
            this.rbTimeType5.Text = "Каждые";
            this.rbTimeType5.UseVisualStyleBackColor = true;
            this.rbTimeType5.CheckedChanged += new System.EventHandler(this.TimeType_Changed);
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.cmbMonth.Location = new System.Drawing.Point(149, 115);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(86, 21);
            this.cmbMonth.TabIndex = 8;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // rbTimeType4
            // 
            this.rbTimeType4.AutoSize = true;
            this.rbTimeType4.Location = new System.Drawing.Point(8, 119);
            this.rbTimeType4.Name = "rbTimeType4";
            this.rbTimeType4.Size = new System.Drawing.Size(75, 17);
            this.rbTimeType4.TabIndex = 6;
            this.rbTimeType4.Text = "Ежегодно";
            this.rbTimeType4.UseVisualStyleBackColor = true;
            this.rbTimeType4.CheckedChanged += new System.EventHandler(this.TimeType_Changed);
            // 
            // rbTimeType3
            // 
            this.rbTimeType3.AutoSize = true;
            this.rbTimeType3.Location = new System.Drawing.Point(8, 91);
            this.rbTimeType3.Name = "rbTimeType3";
            this.rbTimeType3.Size = new System.Drawing.Size(89, 17);
            this.rbTimeType3.TabIndex = 4;
            this.rbTimeType3.Text = "Ежемесячно";
            this.rbTimeType3.UseVisualStyleBackColor = true;
            this.rbTimeType3.CheckedChanged += new System.EventHandler(this.TimeType_Changed);
            // 
            // cmbWeekDay
            // 
            this.cmbWeekDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeekDay.FormattingEnabled = true;
            this.cmbWeekDay.Items.AddRange(new object[] {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота",
            "Воскресенье"});
            this.cmbWeekDay.Location = new System.Drawing.Point(102, 65);
            this.cmbWeekDay.Name = "cmbWeekDay";
            this.cmbWeekDay.Size = new System.Drawing.Size(96, 21);
            this.cmbWeekDay.TabIndex = 3;
            this.cmbWeekDay.SelectedIndexChanged += new System.EventHandler(this.cmbWeekDay_SelectedIndexChanged);
            // 
            // rbTimeType2
            // 
            this.rbTimeType2.AutoSize = true;
            this.rbTimeType2.Location = new System.Drawing.Point(8, 66);
            this.rbTimeType2.Name = "rbTimeType2";
            this.rbTimeType2.Size = new System.Drawing.Size(94, 17);
            this.rbTimeType2.TabIndex = 2;
            this.rbTimeType2.Text = "Еженедельно";
            this.rbTimeType2.UseVisualStyleBackColor = true;
            this.rbTimeType2.CheckedChanged += new System.EventHandler(this.TimeType_Changed);
            // 
            // rbTimeType1
            // 
            this.rbTimeType1.AutoSize = true;
            this.rbTimeType1.Location = new System.Drawing.Point(8, 43);
            this.rbTimeType1.Name = "rbTimeType1";
            this.rbTimeType1.Size = new System.Drawing.Size(82, 17);
            this.rbTimeType1.TabIndex = 1;
            this.rbTimeType1.Text = "Ежедневно";
            this.rbTimeType1.UseVisualStyleBackColor = true;
            this.rbTimeType1.CheckedChanged += new System.EventHandler(this.TimeType_Changed);
            // 
            // rbTimeType0
            // 
            this.rbTimeType0.AutoSize = true;
            this.rbTimeType0.Checked = true;
            this.rbTimeType0.Location = new System.Drawing.Point(8, 20);
            this.rbTimeType0.Name = "rbTimeType0";
            this.rbTimeType0.Size = new System.Drawing.Size(92, 17);
            this.rbTimeType0.TabIndex = 0;
            this.rbTimeType0.TabStop = true;
            this.rbTimeType0.Text = "Единоразово";
            this.rbTimeType0.UseVisualStyleBackColor = true;
            this.rbTimeType0.CheckedChanged += new System.EventHandler(this.TimeType_Changed);
            // 
            // groupActionType
            // 
            this.groupActionType.Controls.Add(this.rbActionType2);
            this.groupActionType.Controls.Add(this.rbActionType1);
            this.groupActionType.Controls.Add(this.rbActionType0);
            this.groupActionType.Location = new System.Drawing.Point(256, 58);
            this.groupActionType.Name = "groupActionType";
            this.groupActionType.Size = new System.Drawing.Size(187, 91);
            this.groupActionType.TabIndex = 7;
            this.groupActionType.TabStop = false;
            this.groupActionType.Text = "Выполнение";
            // 
            // rbActionType2
            // 
            this.rbActionType2.AutoSize = true;
            this.rbActionType2.Location = new System.Drawing.Point(8, 66);
            this.rbActionType2.Name = "rbActionType2";
            this.rbActionType2.Size = new System.Drawing.Size(153, 17);
            this.rbActionType2.TabIndex = 2;
            this.rbActionType2.TabStop = true;
            this.rbActionType2.Text = "Программа и сообщение";
            this.rbActionType2.UseVisualStyleBackColor = true;
            this.rbActionType2.CheckedChanged += new System.EventHandler(this.ActionType_Changed);
            // 
            // rbActionType1
            // 
            this.rbActionType1.AutoSize = true;
            this.rbActionType1.Location = new System.Drawing.Point(8, 43);
            this.rbActionType1.Name = "rbActionType1";
            this.rbActionType1.Size = new System.Drawing.Size(140, 17);
            this.rbActionType1.TabIndex = 1;
            this.rbActionType1.TabStop = true;
            this.rbActionType1.Text = "Выполнить программу";
            this.rbActionType1.UseVisualStyleBackColor = true;
            this.rbActionType1.CheckedChanged += new System.EventHandler(this.ActionType_Changed);
            // 
            // rbActionType0
            // 
            this.rbActionType0.AutoSize = true;
            this.rbActionType0.Checked = true;
            this.rbActionType0.Location = new System.Drawing.Point(8, 20);
            this.rbActionType0.Name = "rbActionType0";
            this.rbActionType0.Size = new System.Drawing.Size(129, 17);
            this.rbActionType0.TabIndex = 0;
            this.rbActionType0.TabStop = true;
            this.rbActionType0.Text = "Вывести сообщение";
            this.rbActionType0.UseVisualStyleBackColor = true;
            this.rbActionType0.CheckedChanged += new System.EventHandler(this.ActionType_Changed);
            // 
            // groupSoundType
            // 
            this.groupSoundType.Controls.Add(this.btnPlaySound);
            this.groupSoundType.Controls.Add(this.btnOpenSoundFile);
            this.groupSoundType.Controls.Add(this.rbSoundType2);
            this.groupSoundType.Controls.Add(this.rbSoundType1);
            this.groupSoundType.Controls.Add(this.rbSoundType0);
            this.groupSoundType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupSoundType.Location = new System.Drawing.Point(256, 155);
            this.groupSoundType.Name = "groupSoundType";
            this.groupSoundType.Size = new System.Drawing.Size(187, 88);
            this.groupSoundType.TabIndex = 8;
            this.groupSoundType.TabStop = false;
            this.groupSoundType.Text = "Звук при сообщении";
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaySound.Image = global::XuliOrganizzer.Properties.Resources.sound32x32;
            this.btnPlaySound.Location = new System.Drawing.Point(144, 28);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(36, 36);
            this.btnPlaySound.TabIndex = 4;
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // btnOpenSoundFile
            // 
            this.btnOpenSoundFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSoundFile.Image = global::XuliOrganizzer.Properties.Resources.opensoundfile;
            this.btnOpenSoundFile.Location = new System.Drawing.Point(101, 28);
            this.btnOpenSoundFile.Name = "btnOpenSoundFile";
            this.btnOpenSoundFile.Size = new System.Drawing.Size(36, 36);
            this.btnOpenSoundFile.TabIndex = 3;
            this.btnOpenSoundFile.UseVisualStyleBackColor = true;
            this.btnOpenSoundFile.Click += new System.EventHandler(this.btnOpenSoundFile_Click);
            // 
            // rbSoundType2
            // 
            this.rbSoundType2.AutoSize = true;
            this.rbSoundType2.Location = new System.Drawing.Point(8, 66);
            this.rbSoundType2.Name = "rbSoundType2";
            this.rbSoundType2.Size = new System.Drawing.Size(122, 17);
            this.rbSoundType2.TabIndex = 2;
            this.rbSoundType2.TabStop = true;
            this.rbSoundType2.Text = "Пользовательский";
            this.rbSoundType2.UseVisualStyleBackColor = true;
            this.rbSoundType2.CheckedChanged += new System.EventHandler(this.SoundType_Changed);
            // 
            // rbSoundType1
            // 
            this.rbSoundType1.AutoSize = true;
            this.rbSoundType1.Checked = true;
            this.rbSoundType1.Location = new System.Drawing.Point(8, 43);
            this.rbSoundType1.Name = "rbSoundType1";
            this.rbSoundType1.Size = new System.Drawing.Size(87, 17);
            this.rbSoundType1.TabIndex = 1;
            this.rbSoundType1.TabStop = true;
            this.rbSoundType1.Text = "Встроенный";
            this.rbSoundType1.UseVisualStyleBackColor = true;
            this.rbSoundType1.CheckedChanged += new System.EventHandler(this.SoundType_Changed);
            // 
            // rbSoundType0
            // 
            this.rbSoundType0.AutoSize = true;
            this.rbSoundType0.Location = new System.Drawing.Point(8, 20);
            this.rbSoundType0.Name = "rbSoundType0";
            this.rbSoundType0.Size = new System.Drawing.Size(80, 17);
            this.rbSoundType0.TabIndex = 0;
            this.rbSoundType0.TabStop = true;
            this.rbSoundType0.Text = "Отключить";
            this.rbSoundType0.UseVisualStyleBackColor = true;
            this.rbSoundType0.CheckedChanged += new System.EventHandler(this.SoundType_Changed);
            // 
            // lblProgramPath
            // 
            this.lblProgramPath.AutoSize = true;
            this.lblProgramPath.Location = new System.Drawing.Point(4, 254);
            this.lblProgramPath.Name = "lblProgramPath";
            this.lblProgramPath.Size = new System.Drawing.Size(103, 13);
            this.lblProgramPath.TabIndex = 9;
            this.lblProgramPath.Text = "Путь к программе:";
            // 
            // txtProgramPath
            // 
            this.txtProgramPath.Location = new System.Drawing.Point(107, 250);
            this.txtProgramPath.Name = "txtProgramPath";
            this.txtProgramPath.Size = new System.Drawing.Size(267, 20);
            this.txtProgramPath.TabIndex = 10;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(381, 250);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(62, 20);
            this.btnSelect.TabIndex = 11;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtProgramParams
            // 
            this.txtProgramParams.Location = new System.Drawing.Point(107, 276);
            this.txtProgramParams.Name = "txtProgramParams";
            this.txtProgramParams.Size = new System.Drawing.Size(267, 20);
            this.txtProgramParams.TabIndex = 13;
            // 
            // lblProgramParams
            // 
            this.lblProgramParams.AutoSize = true;
            this.lblProgramParams.Location = new System.Drawing.Point(4, 280);
            this.lblProgramParams.Name = "lblProgramParams";
            this.lblProgramParams.Size = new System.Drawing.Size(69, 13);
            this.lblProgramParams.TabIndex = 12;
            this.lblProgramParams.Text = "Параметры:";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(4, 301);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(68, 13);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.Text = "Сообщение:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(107, 302);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(332, 106);
            this.txtMessage.TabIndex = 15;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(4, 463);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(106, 17);
            this.chkActive.TabIndex = 16;
            this.chkActive.Text = "Задача активна";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4, 486);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(368, 486);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupRemindType
            // 
            this.groupRemindType.Controls.Add(this.rbRemindType1);
            this.groupRemindType.Controls.Add(this.rbRemindType0);
            this.groupRemindType.Controls.Add(this.txtRemind);
            this.groupRemindType.Location = new System.Drawing.Point(107, 415);
            this.groupRemindType.Name = "groupRemindType";
            this.groupRemindType.Size = new System.Drawing.Size(332, 48);
            this.groupRemindType.TabIndex = 19;
            this.groupRemindType.TabStop = false;
            this.groupRemindType.Text = "Напоминать через каждые";
            // 
            // rbRemindType1
            // 
            this.rbRemindType1.AutoSize = true;
            this.rbRemindType1.Location = new System.Drawing.Point(185, 22);
            this.rbRemindType1.Name = "rbRemindType1";
            this.rbRemindType1.Size = new System.Drawing.Size(54, 17);
            this.rbRemindType1.TabIndex = 13;
            this.rbRemindType1.TabStop = true;
            this.rbRemindType1.Text = "часов";
            this.rbRemindType1.UseVisualStyleBackColor = true;
            this.rbRemindType1.CheckedChanged += new System.EventHandler(this.RemindType_Changed);
            // 
            // rbRemindType0
            // 
            this.rbRemindType0.AutoSize = true;
            this.rbRemindType0.Checked = true;
            this.rbRemindType0.Location = new System.Drawing.Point(124, 22);
            this.rbRemindType0.Name = "rbRemindType0";
            this.rbRemindType0.Size = new System.Drawing.Size(55, 17);
            this.rbRemindType0.TabIndex = 12;
            this.rbRemindType0.TabStop = true;
            this.rbRemindType0.Text = "минут";
            this.rbRemindType0.UseVisualStyleBackColor = true;
            this.rbRemindType0.CheckedChanged += new System.EventHandler(this.RemindType_Changed);
            // 
            // txtRemind
            // 
            this.txtRemind.Location = new System.Drawing.Point(6, 19);
            this.txtRemind.MaxLength = 10;
            this.txtRemind.Name = "txtRemind";
            this.txtRemind.Size = new System.Drawing.Size(112, 20);
            this.txtRemind.TabIndex = 12;
            this.txtRemind.Text = "0";
            this.txtRemind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyDigits);
            // 
            // lblFormMsg
            // 
            this.lblFormMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFormMsg.Location = new System.Drawing.Point(116, 465);
            this.lblFormMsg.Name = "lblFormMsg";
            this.lblFormMsg.Size = new System.Drawing.Size(248, 18);
            this.lblFormMsg.TabIndex = 20;
            this.lblFormMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(4, 327);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(91, 39);
            this.btnLog.TabIndex = 21;
            this.btnLog.Text = "Протокол выполнения";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(5, 369);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(91, 39);
            this.btnClearLog.TabIndex = 22;
            this.btnClearLog.Text = "Очистить протокол";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // chkProgramHide
            // 
            this.chkProgramHide.AutoSize = true;
            this.chkProgramHide.Location = new System.Drawing.Point(381, 277);
            this.chkProgramHide.Name = "chkProgramHide";
            this.chkProgramHide.Size = new System.Drawing.Size(64, 17);
            this.chkProgramHide.TabIndex = 23;
            this.chkProgramHide.Text = "Скрыть";
            this.chkProgramHide.UseVisualStyleBackColor = true;
            // 
            // frmAddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 514);
            this.Controls.Add(this.chkProgramHide);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.lblFormMsg);
            this.Controls.Add(this.groupRemindType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtProgramParams);
            this.Controls.Add(this.lblProgramParams);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtProgramPath);
            this.Controls.Add(this.lblProgramPath);
            this.Controls.Add(this.groupSoundType);
            this.Controls.Add(this.groupActionType);
            this.Controls.Add(this.groupTimeType);
            this.Controls.Add(this.dtNextDateTime);
            this.Controls.Add(this.lblNextDateTime);
            this.Controls.Add(this.dtStartDateTime);
            this.Controls.Add(this.lblStartDateTime);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAddTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить/изменить задачу";
            this.Load += new System.EventHandler(this.frmAddTask_Load);
            this.groupTimeType.ResumeLayout(false);
            this.groupTimeType.PerformLayout();
            this.groupActionType.ResumeLayout(false);
            this.groupActionType.PerformLayout();
            this.groupSoundType.ResumeLayout(false);
            this.groupSoundType.PerformLayout();
            this.groupRemindType.ResumeLayout(false);
            this.groupRemindType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblStartDateTime;
        private System.Windows.Forms.DateTimePicker dtStartDateTime;
        private System.Windows.Forms.DateTimePicker dtNextDateTime;
        private System.Windows.Forms.Label lblNextDateTime;
        private System.Windows.Forms.GroupBox groupTimeType;
        private System.Windows.Forms.ComboBox cmbWeekDay;
        private System.Windows.Forms.RadioButton rbTimeType2;
        private System.Windows.Forms.RadioButton rbTimeType1;
        private System.Windows.Forms.RadioButton rbTimeType0;
        private System.Windows.Forms.RadioButton rbTimeType3;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.RadioButton rbTimeType4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.RadioButton rbTimeType5;
        private System.Windows.Forms.GroupBox groupActionType;
        private System.Windows.Forms.RadioButton rbActionType2;
        private System.Windows.Forms.RadioButton rbActionType1;
        private System.Windows.Forms.RadioButton rbActionType0;
        private System.Windows.Forms.GroupBox groupSoundType;
        private System.Windows.Forms.RadioButton rbSoundType2;
        private System.Windows.Forms.RadioButton rbSoundType1;
        private System.Windows.Forms.RadioButton rbSoundType0;
        private System.Windows.Forms.Button btnOpenSoundFile;
        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.Label lblProgramPath;
        private System.Windows.Forms.TextBox txtProgramPath;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtProgramParams;
        private System.Windows.Forms.Label lblProgramParams;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupRemindType;
        private System.Windows.Forms.RadioButton rbRemindType1;
        private System.Windows.Forms.RadioButton rbRemindType0;
        private System.Windows.Forms.TextBox txtRemind;
        private System.Windows.Forms.ComboBox cmbMonthDay;
        private System.Windows.Forms.ComboBox cmbYearDay;
        private System.Windows.Forms.Label lblFormMsg;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.CheckBox chkProgramHide;
    }
}