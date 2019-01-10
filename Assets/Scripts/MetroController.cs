using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class MetroController : MonoBehaviour
{
  public static MetroController Instance;

  [SerializeField] private List<GameObject> _metroStations;
  [SerializeField] private List<TakingMetroState> _persons;
  
  private Vector3 _targetPosition;

  [SerializeField] private float _speed;
  [SerializeField] private float _timeWait;
  private float _timeWaitActual;

  private bool _isOnStation = true;

  private bool _canGo;

  private RegularTimer _timer;

  // Use this for initialization
  private void Start()
  {
    _timeWaitActual = _timeWait;

    _canGo = true;
    
    GetTarget();
    Instance = this;
  }
  
  // Update is called once per frame
  void Update ()
  {/*
    if (_isOnStation)
    {
      _timeWaitActual -= Time.deltaTime;  
    }

    if (_timeWaitActual <= 0)
    {
      Move();
      _isOnStation = false;
    }*/

    if (_canGo)
    {
      Move();
      _isOnStation = false;
    }
    
    if (Math.Abs(transform.position.x - _targetPosition.x) < _speed * 0.02f && _isOnStation == false)
    {
      _canGo = false;
      _isOnStation = true;
      _timeWaitActual = _timeWait;
      ChangeStation();
    }
  }

  private void GetTarget()
  {
    _targetPosition = _metroStations.First().GetComponent<MetroStationController>().GetMetroDestination();
  }

  private void Move()
  {
    transform.Translate((_targetPosition - transform.position).normalized * _speed * Time.deltaTime);
  }

  private void ChangeStation()
  {
    NotifyIsOnStation();
    var aux = _metroStations.First();
    _metroStations.Remove(aux);
    _metroStations.Add(aux);
    GetTarget();
  }
  
  public bool IsOnStation()
  {
    return _isOnStation;
  }

  public void AddPerson(TakingMetroState person)
  {
    _persons.Add(person);
  }

  public void RemovePerson(TakingMetroState person)
  {
    _persons.Remove(person);
  }

  private void NotifyIsOnStation()
  {
    _metroStations.First().GetComponent<MetroStationController>().NotifyMetroArrived(gameObject);
    _persons = _persons.Where(x => x != null).ToList();
    
    _timer = new RegularTimer(() =>
    {
      foreach (var person in _persons)
      {
      person.NotifyIsOnStation(_metroStations.First());
    }
    }, 1);
  }

  public void Go()
  {
    new StandardEventListener(() => { _canGo = true;
      _timer.Kill(); 
    }, () => !_persons.Any());
  }
}