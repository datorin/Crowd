using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GoldScript : MonoBehaviour
{

	[SerializeField] private float _distance;
	[SerializeField] private float _time;
	private float _actualTime;

	// Use this for initialization
	void Start ()
	{
		_actualTime = _time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_actualTime -= Time.deltaTime;

		if (_actualTime <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		var aux = Vector3.Distance(transform.position, other.transform.position);
		if (other.GetComponent<ITriggerable>() != null)
		{
			other.GetComponent<ITriggerable>().Gold(transform.position,_distance-aux);
		}
	}
}
