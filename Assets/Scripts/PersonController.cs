using Persistence;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PersonController : MonoBehaviour
{
	private NavMeshAgent _agent;
	
	[SerializeField] public GameObject Target;
	public GameObject CurrentMetro;

	[SerializeField] public Vector3 HomePosition;
	[SerializeField] public Vector3 WorkPosition;
	
	// Use this for initialization
	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		PersonsManager.Instance.AddPerson(gameObject);
	}

	public void ExecuteAwake()
	{
		WorkPosition = WorkplaceManager.Instance.GetRandomWorkplace();
		_agent.SetDestination(WorkPosition);
	}

	public void NotifyMetroArrived(Vector3 trainPosition)
	{
		_agent.SetDestination(trainPosition);
	}
}