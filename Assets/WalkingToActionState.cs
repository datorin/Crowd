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
		animator.SetBool( ValuesManager.Instance.IsFinished, false);
		
		_pedestrian = animator.gameObject;
		_agent = _pedestrian.GetComponent<NavMeshAgent>();
		_destination = _pedestrian.GetComponent<PersonController>().Target.transform.position;
		_agent.SetDestination(_destination); //GetDestination();
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		if (Math.Abs(_pedestrian.transform.position.x - _destination.x) < ValuesManager.Instance.Tolerance && 
		    Math.Abs(_pedestrian.transform.position.z - _destination.z) < ValuesManager.Instance.Tolerance)
		{
			animator.SetBool( ValuesManager.Instance.IsFinished, true);
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
