namespace Reminder
{
    partial class ReminderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReminderForm));
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.eventGB = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.remindCB = new System.Windows.Forms.CheckBox();
            this.repeatComboBox = new System.Windows.Forms.ComboBox();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.timeLabel = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.eventsLabel = new System.Windows.Forms.Label();
            this.eventsList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.eventGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(18, 18);
            this.calendar.MaxSelectionCount = 10;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 1;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // eventGB
            // 
            this.eventGB.Controls.Add(this.cancelButton);
            this.eventGB.Controls.Add(this.saveButton);
            this.eventGB.Controls.Add(this.remindCB);
            this.eventGB.Controls.Add(this.repeatComboBox);
            this.eventGB.Controls.Add(this.repeatLabel);
            this.eventGB.Controls.Add(this.timePicker);
            this.eventGB.Controls.Add(this.timeLabel);
            this.eventGB.Controls.Add(this.nameTB);
            this.eventGB.Controls.Add(this.nameLabel);
            this.eventGB.Enabled = false;
            this.eventGB.Location = new System.Drawing.Point(209, 18);
            this.eventGB.Name = "eventGB";
            this.eventGB.Size = new System.Drawing.Size(307, 162);
            this.eventGB.TabIndex = 2;
            this.eventGB.TabStop = false;
            this.eventGB.Text = "Событие";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(221, 133);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(125, 133);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // remindCB
            // 
            this.remindCB.AutoSize = true;
            this.remindCB.Location = new System.Drawing.Point(13, 137);
            this.remindCB.Name = "remindCB";
            this.remindCB.Size = new System.Drawing.Size(89, 17);
            this.remindCB.TabIndex = 6;
            this.remindCB.Text = "Напоминать";
            this.remindCB.UseVisualStyleBackColor = true;
            // 
            // repeatComboBox
            // 
            this.repeatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatComboBox.FormattingEnabled = true;
            this.repeatComboBox.Location = new System.Drawing.Point(82, 97);
            this.repeatComboBox.Name = "repeatComboBox";
            this.repeatComboBox.Size = new System.Drawing.Size(214, 21);
            this.repeatComboBox.TabIndex = 5;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(10, 100);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(61, 13);
            this.repeatLabel.TabIndex = 4;
            this.repeatLabel.Text = "Повторять";
            // 
            // timePicker
            // 
            this.timePicker.AllowDrop = true;
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(82, 56);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(214, 20);
            this.timePicker.TabIndex = 3;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(10, 60);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(40, 13);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "Время";
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(82, 19);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(214, 20);
            this.nameTB.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(10, 22);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(57, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название";
            // 
            // eventsLabel
            // 
            this.eventsLabel.AutoSize = true;
            this.eventsLabel.Location = new System.Drawing.Point(15, 189);
            this.eventsLabel.Name = "eventsLabel";
            this.eventsLabel.Size = new System.Drawing.Size(51, 13);
            this.eventsLabel.TabIndex = 3;
            this.eventsLabel.Text = "События";
            // 
            // eventsList
            // 
            this.eventsList.FormattingEnabled = true;
            this.eventsList.Location = new System.Drawing.Point(18, 205);
            this.eventsList.Name = "eventsList";
            this.eventsList.Size = new System.Drawing.Size(164, 56);
            this.eventsList.TabIndex = 4;
            this.eventsList.SelectedIndexChanged += new System.EventHandler(this.eventsList_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(209, 219);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Enabled = false;
            this.changeButton.Location = new System.Drawing.Point(290, 219);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 6;
            this.changeButton.Text = "Изменить";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(371, 219);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Я теперь в трее, чтобы не мешать! Чтобы открыть меня, дважды нажми на иконке!";
            this.notifyIcon.BalloonTipTitle = "Опа";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Календарь";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // ReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 278);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.eventsList);
            this.Controls.Add(this.eventsLabel);
            this.Controls.Add(this.eventGB);
            this.Controls.Add(this.calendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReminderForm";
            this.Text = "Календарь";
            this.Deactivate += new System.EventHandler(this.ReminderForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReminderForm_FormClosing);
            this.eventGB.ResumeLayout(false);
            this.eventGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.GroupBox eventGB;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox repeatComboBox;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox remindCB;
        private System.Windows.Forms.Label eventsLabel;
        private System.Windows.Forms.ListBox eventsList;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

