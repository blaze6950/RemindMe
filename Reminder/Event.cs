using System;
using System.Text;

namespace Reminder
{
    [Serializable]
    internal class Event
    {
        // переопределения

        #region Overrides

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(20);
            stringBuilder.AppendLine(Name);
            stringBuilder.Append(' ');
            stringBuilder.AppendLine(Time.ToShortDateString());
            stringBuilder.Append(' ');
            if (IsRemind) stringBuilder.Append('!');
            return stringBuilder.ToString();
        }

        #endregion

        // поля класса

        #region Fields

        private string _name;
        private DateTime _time;
        private RepeatEnum _repeat;
        private bool _isRemind;

        #endregion

        // коснтрукторы класса

        #region Constructors

        public Event()
        {
        }

        public Event(string name, DateTime time, RepeatEnum repeat, bool isRemind)
        {
            Name = name;
            Time = time;
            Repeat = repeat;
            IsRemind = isRemind;
        }

        #endregion

        // свойства класса

        #region Properties

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public DateTime Time
        {
            get => _time;
            set => _time = value;
        }

        public RepeatEnum Repeat
        {
            get => _repeat;
            set => _repeat = value;
        }

        public bool IsRemind
        {
            get => _isRemind;
            set => _isRemind = value;
        }

        #endregion
    }
}