using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PersonController : MonoBehaviour
{
	private NavMeshAgent _agent;
	
	[SerializeField] private GameObject _target;
	private Vector3 _destination;

	[SerializeField] private GameObject _metroStation;

	private bool _wait = true;
	
	// Use this for initialization
	void Start ()
	{
		_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_destination = _target.transform.position;
		_agent.SetDestination(_destination);

		if (Math.Abs(transform.position.x - _destination.x) < 0.1f && 
		    Math.Abs(transform.position.z - _destination.z) < 0.1f)
		{
			if (_wait)
			{
				_target.transform.position = _metroStation.GetComponent<MetroStationController>().GetWaitTrainPosition();
				_wait = false;
			}
			else
			{
				_target.transform.position = _metroStation.GetComponent<MetroStationController>().GetTrainPosition();
			}
		}
	}
}
