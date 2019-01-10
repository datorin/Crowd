using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class MetroStationController : MonoBehaviour
{

	[SerializeField] private GameObject _bottomTargetMin;
	[SerializeField] private GameObject _bottomTargetMax;
	
	[SerializeField] private GameObject _platform0TargetMin;
	[SerializeField] private GameObject _platform0TargetMax;
	
	[SerializeField] private GameObject _platform1TargetMin;
	[SerializeField] private GameObject _platform1TargetMax;

	[SerializeField] private GameObject _metroDestination;

	private Vector3 _bottomPositionMin;
	private Vector3 _bottomPositionMax;
	
	private Vector3 _platform0PositionMin;
	private Vector3 _platform0PositionMax;
	
	private Vector3 _platform1PositionMin;
	private Vector3 _platform1PositionMax;

	private GameObject _metro;
	private IList<WalkingToMetroState> _persons;

	private void Awake()
	{
		_bottomPositionMin = _bottomTargetMin.transform.position;
		_bottomPositionMax = _bottomTargetMax.transform.position;
		
		_platform0PositionMin = _platform0TargetMin.transform.position;
		_platform0PositionMax = _platform0TargetMax.transform.position;
		
		_platform1PositionMin = _platform1TargetMin.transform.position;
		_platform1PositionMax = _platform1TargetMax.transform.position;
		
		_persons = new List<WalkingToMetroState>();
	}

	public Vector3 GetWaitTrainPosition()
	{
		var randomX = Random.Range(_bottomPositionMin.x, _bottomPositionMax.x);
		var randomZ = Random.Range(_bottomPositionMin.z, _bottomPositionMax.z);
		return new Vector3(randomX,_bottomPositionMin.y,randomZ);
	}
	
	private Vector3 GetTrainPosition()
	{
		var coin = Functions.Random(0, 1);
		var randomX = 0f;
		var randomZ = 0f;
		if (coin == 0)
		{
			randomX = Functions.RandomFloat(_platform0PositionMin.x, _platform0PositionMax.x);
			randomZ = Functions.RandomFloat(_platform0PositionMin.z, _platform0PositionMax.z);	
		}
		else
		{
			randomX = Functions.RandomFloat(_platform1PositionMin.x, _platform1PositionMax.x);
			randomZ = Functions.RandomFloat(_platform1PositionMin.z, _platform1PositionMax.z);	
		}
		return new Vector3(randomX,_platform1PositionMax.y,randomZ);
	}

	public void AddPerson(WalkingToMetroState person)
	{
		if(_persons.Contains(person)) return;
		_persons.Add(person);
	}

	public void RemovePerson(WalkingToMetroState person)
	{
		_persons.Remove(person);
		if (!_persons.Any())
		{
			_metro.GetComponent<MetroController>().Go();
		}
	}
	
	public void NotifyMetroArrived(GameObject metro)
	{
		_metro = metro;
		foreach(var person in _persons)
		{
			person.NotifyMetroArrived(GetTrainPosition(),_metro);
		}

		if (!_persons.Any())
		{
			_metro.GetComponent<MetroController>().Go();
		}
	}

	public Vector3 GetMetroDestination()
	{
		return _metroDestination.transform.position;
	}
}
