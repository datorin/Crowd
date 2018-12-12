using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroStationController : MonoBehaviour
{

	[SerializeField] private GameObject _bottomTargetMin;
	[SerializeField] private GameObject _bottomTargetMax;
	
	[SerializeField] private GameObject _platform0TargetMin;
	[SerializeField] private GameObject _platform0TargetMax;
	
	[SerializeField] private GameObject _platform1TargetMin;
	[SerializeField] private GameObject _platform1TargetMax;

	private Vector3 _bottomPositionMin;
	private Vector3 _bottomPositionMax;
	
	private Vector3 _platform0PositionMin;
	private Vector3 _platform0PositionMax;
	
	private Vector3 _platform1PositionMin;
	private Vector3 _platform1PositionMax;

	private GameObject _metro;
	private IList<PersonController> _persons;

	private void Awake()
	{
		_bottomPositionMin = _bottomTargetMin.transform.position;
		_bottomPositionMax = _bottomTargetMax.transform.position;
		
		_platform0PositionMin = _platform0TargetMin.transform.position;
		_platform0PositionMax = _platform0TargetMax.transform.position;
		
		_platform1PositionMin = _platform1TargetMin.transform.position;
		_platform1PositionMax = _platform1TargetMax.transform.position;
		
		_persons = new List<PersonController>();
	}

	public Vector3 GetWaitTrainPosition()
	{
		var randomX = Random.Range(_bottomPositionMin.x, _bottomPositionMax.x);
		var randomZ = Random.Range(_bottomPositionMin.z, _bottomPositionMax.z);
		return new Vector3(randomX,_bottomPositionMin.y,randomZ);
	}
	
	private Vector3 GetTrainPosition()
	{
		var coin = Random.Range(0, 1);
		var randomX = 0f;
		var randomZ = 0f;
		if (coin == 0)
		{
			randomX = Random.Range(_platform0PositionMin.x, _platform0PositionMax.x);
			randomZ = Random.Range(_platform0PositionMin.z, _platform0PositionMax.z);	
		}
		else
		{
			randomX = Random.Range(_platform1PositionMin.x, _platform1PositionMax.x);
			randomZ = Random.Range(_platform1PositionMin.z, _platform1PositionMax.z);	
		}
		return new Vector3(randomX,_platform1PositionMax.y,randomZ);
	}

	public void AddPerson(PersonController person)
	{
		if(_persons.Contains(person)) return;
		_persons.Add(person);
	}

	public void NotifyMetroArrived()
	{
		foreach(var person in _persons)
		{
			person.NotifyMetroArrived(GetTrainPosition());
		}
		_persons.Clear();
	}
}
