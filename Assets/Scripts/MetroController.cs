using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroController : MonoBehaviour
{

	[SerializeField] private GameObject _target0;
	[SerializeField] private GameObject _target1;

	private Vector3 _target0Position;
	private Vector3 _target1Position;
	private Vector3 _targetPosition;

	[SerializeField] private float _speed;
	[SerializeField] private float _timeWait;
	private float _timeWaitActual;

	private bool _isOnStation = true;
	// Use this for initialization
	void Start ()
	{
		_timeWaitActual = _timeWait;
		
		_target0Position = _target0.transform.position;
		_target1Position = _target1.transform.position;
		_targetPosition = _target1Position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_isOnStation)
		{
			_timeWaitActual -= Time.deltaTime;	
		}

		if (_timeWaitActual <= 0)
		{
			Move();
			_isOnStation = false;
		}

		if (Math.Abs(transform.position.x - _targetPosition.x) < _speed * 0.02f && _isOnStation == false)
		{
			_isOnStation = true;
			_timeWaitActual = _timeWait;
			ChangeTarget();
		}
	}

	private void Move()
	{
		transform.Translate((_targetPosition - transform.position).normalized * _speed * Time.deltaTime);
	}

	private void ChangeTarget()
	{
		if (_targetPosition == _target0Position)
		{
			_targetPosition = _target1Position;
		}
		else
		{
			_targetPosition = _target0Position;
		}
	}

	public bool IsOnStation()
	{
		return _isOnStation;
	}
}
