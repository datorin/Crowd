using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utils;

[RequireComponent(typeof(NavMeshAgent))]
public class PersonController : MonoBehaviour
{
	private NavMeshAgent _agent;
	
	[SerializeField] public GameObject Target;
	
	// Use this for initialization
	void Start ()
	{
		_agent = GetComponent<NavMeshAgent>();
	}

	public void NotifyMetroArrived(Vector3 trainPosition)
	{
		_agent.SetDestination(trainPosition);
	}
}