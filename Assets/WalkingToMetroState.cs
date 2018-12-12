using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using Utils;

public class WalkingToMetroState : StateMachineBehaviour {
	
	private NavMeshAgent _agent;
	private GameObject _pedestrian;
	private Vector3 _destination;
	private Animator _animator;

	private MetroStationController _metroStationController;
	private bool _isWaiting;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_animator = animator;
		_pedestrian = animator.gameObject;
		_agent = _pedestrian.GetComponent<NavMeshAgent>();
		_metroStationController = MetroManager.Instance.GetClosestStation(_pedestrian.transform.position)
			.GetComponent<MetroStationController>();
		_destination = _metroStationController.GetWaitTrainPosition();
		_agent.SetDestination(_destination); 
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		if (Math.Abs(_pedestrian.transform.position.x - _destination.x) < ValuesManager.Instance.Tolerance && 
		    Math.Abs(_pedestrian.transform.position.z - _destination.z) < ValuesManager.Instance.Tolerance && 
		    !_isWaiting)
		{
			_isWaiting = true;
			_metroStationController.AddPerson(this);
		}
	}
	
	public void NotifyMetroArrived(Vector3 trainPosition, GameObject metro)
	{
		_agent.SetDestination(trainPosition);
		new StandardEventListener(() =>
			{
				_metroStationController.RemovePerson(this);
				_agent.enabled = false;
				_animator.SetTrigger(ValuesManager.Instance.IsFinished);
			}, 
			() => Math.Abs(_pedestrian.transform.position.x - trainPosition.x) < ValuesManager.Instance.Tolerance &&
			      Math.Abs(_pedestrian.transform.position.z - trainPosition.z) < ValuesManager.Instance.Tolerance);
		_pedestrian.GetComponent<PersonController>().CurrentMetro = metro;
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
