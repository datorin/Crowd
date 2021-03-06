﻿using System;
using System.Collections.Generic;
using DefaultNamespace;
using Persistence;
using UnityEngine;
using UnityEngine.AI;
using Utils;

[RequireComponent(typeof(NavMeshAgent))]
public class PersonController : MonoBehaviour, ITriggerable
{
	private NavMeshAgent _agent;
	
	[SerializeField] public GameObject Target;
	public GameObject CurrentMetro;
	public Vector3 Destination;
	public bool IsFire;
	public bool IsGold;
	public Vector3 EventPosition;
	public Vector3 ExitPosition;

	[SerializeField] public Vector3 HomePosition;
	[SerializeField] public Vector3 WorkPosition;
	[SerializeField] public Vector3 SupermarketPosition;

	private IDictionary<int, Vector3> _routine;
	
	// Use this for initialization
	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		PersonsManager.Instance.AddPerson(gameObject);
		_routine = new Dictionary<int, Vector3>();
	}

	public void ExecuteAwake()
	{
		CurrentMetro = MetroController.Instance.gameObject;
		WorkPosition = WorkplaceManager.Instance.GetRandomWorkplace();
		HomePosition = transform.position;
		SupermarketPosition = SupermarketManager.Instance.GetRandomSupermarket();
		
		var workingHours = Functions.Random(2, 8);

		foreach (var hour in Functions.Range(0, 6))
		{
			_routine.Add(hour, HomePosition);
		}
		
		foreach (var hour in Functions.Range(7, 7 + workingHours - 1))
		{
			_routine.Add(hour, WorkPosition);
		}
		
		foreach (var hour in Functions.Range(7 + workingHours, 7 + workingHours + 1))
		{
			_routine.Add(hour, SupermarketPosition);
		}
		
		foreach (var hour in Functions.Range(7 + workingHours + 2, 20))
		{
			Vector3 pos;
			switch (Hobbies.Cinema.Random())
			{
				case Hobbies.Cinema:
					pos = HobbiesManager.Instance.GetRandomCinemaPlace();
					break;
				case Hobbies.Shop:
					pos = HobbiesManager.Instance.GetRandomShopPlace();
					break;
				case Hobbies.Park:
					pos = HobbiesManager.Instance.GetRandomParkPlace();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			_routine.Add(hour, pos);
		}
		
		foreach (var hour in Functions.Range(21, 23))
		{
			_routine.Add(hour, HomePosition);
		}
	}

	public void NotifyMetroArrived(Vector3 trainPosition)
	{
		_agent.SetDestination(trainPosition);
	}

	public void SetNewDestination()
	{
		var hour = DayTime.Instance.Hour;
		Destination = _routine[hour];
		
		GetComponent<Animator>().SetTrigger("isFinished");		
		// TO BE CHANCHED
 		//_agent.SetDestination(destination);
	}

	public void Fire(Vector3 origin)
	{
		EventPosition = origin;
		IsFire = true;
		GetComponent<Animator>().SetBool("isFire",true);
		
	}

	public void Gold(Vector3 origin)
	{
		if (!IsFire)
		{
			EventPosition = origin;
			IsGold = true;
			GetComponent<Animator>().SetBool("isGold",true);
		}
	}
}