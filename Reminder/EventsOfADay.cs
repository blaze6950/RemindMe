using System;
using System.ComponentModel;

namespace Reminder
{
    [Serializable]
    internal class EventsOfADay
    {
        // поля и свойства к полям

        #region FieldsAndProperties

        private BindingList<Event> _events;

        public BindingList<Event> Events
        {
            get => _events;
            set => _events = value;
        }

        #endregion

        // конструкторы

        #region Contructors

        public EventsOfADay()
        {
            Events = new BindingList<Event>();
        }

        public EventsOfADay(BindingList<Event> events)
        {
            Events = events;
        }

        #endregion

        // методы интерфейса, для взаимодействия с классом

        #region InterfaceMethods

        public DateTime GetDate()
        {
            if (Events != null && Events.Count > 0)
                return DateTime.Parse(Events[0].Time.Date.ToShortDateString());
            return DateTime.Now;
        }

        public void AddEvent(Event newEvent)
        {
            _events.Add(newEvent);
        }

        public void AddEvent(string name, DateTime time, RepeatEnum repeat, bool remind)
        {
            var newEvent = new Event(name, time, repeat, remind);
            _events.Add(newEvent);
        }

        #endregion
    }
}   