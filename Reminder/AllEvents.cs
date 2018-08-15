using System;
using System.Collections.Generic;

namespace Reminder
{
    [Serializable]
    internal class AllEvents
    {
        // конструкторы

        #region Constructors

        public AllEvents()
        {
            _eventsEOAD = new List<EventsOfADay>();
        }

        #endregion

        // поля и свойства к полям

        #region FieldsAndProperties

        private List<EventsOfADay> _eventsEOAD;

        public List<EventsOfADay> EventsEOAD
        {
            get => _eventsEOAD;
            set => _eventsEOAD = value;
        }

        #endregion

        // методы интерфейса, для взаимодействия с классом

        #region InterfaceMethods

        public EventsOfADay FindEOAD(DateTime dateTime)
        {
            foreach (var eventEOADItem in _eventsEOAD)
                if (DateTime.Compare(eventEOADItem.GetDate(), dateTime) == 0)
                    return eventEOADItem;
            return null;
        }

        public void AddEvent(Event newEvent)
        {
            var EOADItem = FindEOAD(newEvent.Time.Date);
            if (EOADItem != null)
            {
                EOADItem.AddEvent(newEvent);
            }
            else
            {
                var newEventsOfADay = new EventsOfADay();
                newEventsOfADay.AddEvent(newEvent);
                _eventsEOAD.Add(newEventsOfADay);
            }
        }

        public void AddEvent(string name, DateTime time, RepeatEnum repeat, bool remind)
        {
            var newEvent = new Event(name, time, repeat, remind);
            AddEvent(newEvent);
        }

        public Event RemindForEvent()
        {
            foreach (var eoadItem in _eventsEOAD)
            foreach (var eventItem in eoadItem.Events)
                if (eventItem.Time <= DateTime.Now.AddMinutes(15) && eventItem.Time >= DateTime.Now)
                    if (eventItem.IsRemind)
                    {
                        eventItem.IsRemind = false;
                        if (eventItem.Repeat != RepeatEnum.Once) eoadItem.Events.Remove(eventItem);
                        return eventItem;
                    }
            return null;
        }

        #endregion
    }
}