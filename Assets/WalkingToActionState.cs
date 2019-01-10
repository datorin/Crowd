using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class WalkingToActionState : StateMachineBehaviour {

	private NavMeshAgent _agent;
	private GameObject _pedestrian;
	private Vector3 _destination;
	
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{	
		_pedestrian = animator.gameObject;
		_agent = _pedestrian.GetComponent<NavMeshAgent>();
		_agent.enabled = true;
		_destination = _pedestrian.GetComponent<PersonController>().Destination;//Target.transform.position;
		_agent.SetDestination(_destination); //GetDestination();
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		if (Math.Abs(_pedestrian.transform.position.x - _destination.x) < ValuesManager.Instance.Tolerance && 
		    Math.Abs(_pedestrian.transform.position.z - _destination.z) < ValuesManager.Instance.Tolerance)
		{
			animator.SetTrigger(ValuesManager.Instance.IsFinished);
		}
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
