using DefaultNamespace;
using UnityEngine;
using Utils;

public class TakingMetroState : StateMachineBehaviour
{

	private GameObject _metro;
	private GameObject _pedestrian;
	private bool _isOnStation;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		_pedestrian = animator.gameObject;
		_metro = _pedestrian.GetComponent<PersonController>().CurrentMetro;
		_metro.GetComponent<MetroController>().AddPerson(this);
		
		if (_metro != null)
		{
			_pedestrian.transform.parent = _metro.transform;
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!_isOnStation) return;
		_pedestrian.transform.parent = null;
		new StandardEventListener(() =>
			{
				_metro.GetComponent<MetroController>().RemovePerson(this);
			}, 
			() => Vector3.Distance(_pedestrian.transform.position, _metro.transform.position) > 30);
		animator.SetTrigger(ValuesManager.Instance.IsFinished);
	}
	
	public void NotifyIsOnStation(GameObject first)
	{
		_isOnStation = true;
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