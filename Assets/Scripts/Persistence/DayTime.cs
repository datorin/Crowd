using System;
using System.Collections.Generic;

namespace Persistence
{
    public class DayTime
    {
        public static readonly DayTime Instance = new DayTime();
        
        public int Hour;
        public int Minute;

        private readonly List<ITimeListener> _listeners;
        
        private DayTime()
        {
            Hour = 7;
            Minute = 56;
            _listeners = new List<ITimeListener>();
        }

        public void ExecuteAwake()
        {
            new RegularTimer(AddOneMinute, 1);
        }
        
        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}", Hour, Minute);
        }

        private void AddOneMinute()
        {
            Minute++;
            if (Minute == 60)
            {
                Minute = 0;
                Hour++;
                foreach (var l in _listeners)
                {
                    l.HourPassed();
                }
            }

            if (Hour == 24)
            {
                Hour = 0;
            }

            foreach (var l in _listeners)
            {
                l.TimePassed();
            }
        }

        public void AddTimeListener(ITimeListener listener)
        {
            _listeners.Add(listener);
        }
    }
}