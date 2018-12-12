using System;
using Controllers;

namespace Utils
{
    public class StandardEventListener : ITimeable
    {
        private readonly Action _action;
        private Func<bool> _condition;

        public StandardEventListener(Action action, Func<bool> condition)
        {
            _action = action;
            _condition = condition;
            RecordsController.Instance.AddTimeListener(this);
        }

        public void TimeElapsed(float seconds)
        {
            if (!_condition()) return;
            _action();
            RecordsController.Instance.RemoveTimeLister(this);
        }
    }
}