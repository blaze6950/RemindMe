using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Reminder
{
    internal delegate void OkButtonAction();

    public partial class ReminderForm : Form
    {
        private AllEvents _allEvents;

        private OkButtonAction _okButtonAction;

        public ReminderForm()
        {
            InitializeComponent();
            var repeatEnums = new List<RepeatEnum>(3);
            repeatEnums.Add(RepeatEnum.Once);
            repeatEnums.Add(RepeatEnum.EveryMonth);
            repeatEnums.Add(RepeatEnum.EveryYear);
            repeatComboBox.DataSource = repeatEnums;
            LoadEvents();

            var contextMenu = new ContextMenu();
            var exitItem = new MenuItem();
            var addEventItem = new MenuItem();

            // Initialize contextMenu
            contextMenu.MenuItems.AddRange(
                new[] {exitItem, addEventItem});

            // Initialize exitItem
            exitItem.Index = 0;
            exitItem.Text = @"Выход";
            exitItem.Click += menuItem_Click;

            // Initialize addEventItem
            addEventItem.Index = 0;
            addEventItem.Text = @"Добавить событие";
            addEventItem.Click += addEventItem_Click;
            notifyIcon.ContextMenu = contextMenu;
        }


        // функции, обрабатывающие события взаимодействия с кнопками

        #region ButtonEvents

        private void addButton_Click(object sender, EventArgs e)
        {
            calendar.Enabled = false;
            eventsList.Enabled = false;
            addButton.Enabled = false;
            deleteButton.Enabled = false;
            changeButton.Enabled = false;
            eventGB.Enabled = true;
            ClearEventGb();
            _okButtonAction = AddAction;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            calendar.Enabled = false;
            eventsList.Enabled = false;
            addButton.Enabled = false;
            deleteButton.Enabled = false;
            changeButton.Enabled = false;
            eventGB.Enabled = true;
            _okButtonAction = ChangeAction;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            (eventsList.DataSource as BindingList<Event>)?.Remove(eventsList.SelectedItem as Event);
            StateButtons();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DateChanged(calendar.SelectionStart.Date);
            eventGB.Enabled = false;
            addButton.Enabled = true;
            calendar.Enabled = true;
            eventsList.Enabled = true;
            StateButtons();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ValidateFieldsForNewEvent();
            _okButtonAction.Invoke();
            cancelButton_Click(cancelButton, EventArgs.Empty);
        }

        #endregion


        // функции, обрабатывающие события взаимодейтсвия с другими элементами формы

        #region ControlsEvents

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateChanged(e.Start.Date);
        }

        private void eventsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameTB.Text = (eventsList.SelectedItem as Event)?.Name;
            timePicker.Value = ((Event) eventsList.SelectedItem).Time;
            remindCB.Checked = ((Event) eventsList.SelectedItem).IsRemind;
            repeatComboBox.SelectedItem = ((Event) eventsList.SelectedItem).Repeat;
        }

        private void ReminderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveEvents();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var eventItem = _allEvents.RemindForEvent();
            if (eventItem != null)
            {
                Show();
                Activate();
                //this.Hide();
                MessageBox.Show(string.Format("{0} {1}", eventItem.Name, eventItem.Time), @"Событие",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (eventItem.Repeat == RepeatEnum.EveryMonth)
                {
                    eventItem.Time = eventItem.Time.AddMonths(1);
                    var newEventsOfADay = new EventsOfADay();
                    newEventsOfADay.AddEvent(eventItem);
                    _allEvents.EventsEOAD.Add(newEventsOfADay);
                    DoBoldDates();
                }
                else if (eventItem.Repeat == RepeatEnum.EveryYear)
                {
                    eventItem.Time = eventItem.Time.AddYears(1);
                    var newEventsOfADay = new EventsOfADay();
                    newEventsOfADay.AddEvent(eventItem);
                    _allEvents.EventsEOAD.Add(newEventsOfADay);
                    DoBoldDates();
                }
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addEventItem_Click(object sender, EventArgs e)
        {
            notifyIcon_DoubleClick(notifyIcon, EventArgs.Empty);
            addButton_Click(addButton, EventArgs.Empty);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            //this.Activate();
            Focus();
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
        }

        private void ReminderForm_Deactivate(object sender, EventArgs e)
        {
            Hide();
            notifyIcon.ShowBalloonTip(2000);
        }

        #endregion


        // вспомогательные функции для для обработки событий

        #region ProcessingFunctions

        private void LoadEvents()
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream("events.bin", FileMode.Open, FileAccess.Read);

                var formatter = new BinaryFormatter();
                _allEvents = (AllEvents) formatter.Deserialize(stream);
            }
            catch (FileNotFoundException)
            {
                _allEvents = new AllEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} {1}", ex.Message, ex.GetType()), @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            DoBoldDates();
        }

        private void SaveEvents()
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream("events.bin", FileMode.Create, FileAccess.Write);

                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, _allEvents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        private void AddAction()
        {
            var newEvent = new Event();
            newEvent.Name = nameTB.Text;
            newEvent.Time = timePicker.Value;
            newEvent.IsRemind = remindCB.Checked;
            newEvent.Repeat = (RepeatEnum) repeatComboBox.SelectedItem;
            _allEvents.AddEvent(newEvent);
            calendar.AddBoldedDate(newEvent.Time.Date);
            calendar.UpdateBoldedDates();
        }

        private void ChangeAction()
        {
            AddAction();
            deleteButton_Click(deleteButton, EventArgs.Empty);
        }

        private void StateButtons()
        {
            if (((BindingList<Event>) eventsList.DataSource).Count == 0)
            {
                deleteButton.Enabled = false;
                changeButton.Enabled = false;
                calendar.RemoveBoldedDate(calendar.SelectionStart.Date);
            }
            else
            {
                deleteButton.Enabled = true;
                changeButton.Enabled = true;
            }
            calendar.UpdateBoldedDates();
        }

        private void ClearEventGb()
        {
            nameTB.Text = string.Empty;
            repeatComboBox.SelectedIndex = 0;
            var newDateTime = calendar.SelectionStart.Add(DateTime.Now.TimeOfDay);
            timePicker.Value = newDateTime;
        }

        private void DateChanged(DateTime selectedDateTime)
        {
            var eventsFromThatDate = _allEvents.FindEOAD(selectedDateTime);
            if (eventsFromThatDate != null)
            {
                eventsList.DataSource = eventsFromThatDate.Events;
            }
            else
            {
                eventsList.DataSource = new BindingList<Event>();
                nameTB.Text = string.Empty;
                repeatComboBox.SelectedIndex = 0;
                timePicker.Value = DateTime.Now;
            }
            StateButtons();
            Text = selectedDateTime.ToShortDateString();
        }

        private void ValidateFieldsForNewEvent()
        {
            if (nameTB.Text == string.Empty)
            {
                MessageBox.Show(@"Вы ввели неккоректное имя события!", @"Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (nameTB.Text.Length > 15)
            {
                MessageBox.Show(@"Имя события слишком длинное!", @"Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (timePicker.Value < DateTime.Now && remindCB.Checked)
            {
                MessageBox.Show(@"Указанное время уже произошло! Уведомление о событии не будет произведено!",
                    @"Предупреждение", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                remindCB.Checked = false;
            }
        }

        private void DoBoldDates()
        {
            foreach (var eventsEoadItem in _allEvents.EventsEOAD)
                calendar.AddBoldedDate(eventsEoadItem.GetDate());
        }

        #endregion
    }
}