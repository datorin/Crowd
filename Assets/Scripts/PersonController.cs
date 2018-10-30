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
	}
}
