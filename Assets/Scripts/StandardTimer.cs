using System;
using Controllers;

namespace UnityEngine
{
	public class StandardTimer : ITimeable
	{
		private readonly Action _action;
		private readonly float _waitSeconds;

		private float _secondsElapsed;

		public StandardTimer(Action action, float waitSeconds)
		{
			_action = action;
			_waitSeconds = waitSeconds;
			RecordsController.Instance.AddTimeListener(this);
		}

		public void TimeElapsed(float seconds)
		{
			_secondsElapsed += seconds;
			if (!(_waitSeconds <= _secondsElapsed)) return;
			_action();
			RecordsController.Instance.RemoveTimeLister(this);
		}
	}
}