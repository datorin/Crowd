using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
	public class RecordsController : MonoBehaviour
	{
		public static RecordsController Instance;
        
		[SerializeField] public float ElapsedTime;
		[SerializeField] private bool _started;

		private IList<ITimeable> _timers;
        
		private void Awake()
		{
			Instance = this;
			_started = true;
			_timers = new List<ITimeable>();
		}
        
		private void FixedUpdate()
		{
			if (_started)
			{
				ElapsedTime += Time.fixedDeltaTime;
                
			}
            
			for (var i = 0; i < _timers.Count; i++)
			{
				var t = _timers[i];
				t.TimeElapsed(Time.fixedDeltaTime);
			}
		}

		public void InitializeTimer()
		{
			ElapsedTime = 0;
		}

		public void RestartTimer()
		{
			_started = true;
		}

		public void AddTimeListener(ITimeable timer)
		{
			_timers.Add(timer);
		}


		public void RemoveTimeLister(ITimeable timer)
		{
			_timers.Remove(timer);
		}
	}
}