using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MetroManager : MonoBehaviour
{
    public static MetroManager Instance;
        
    [SerializeField] private List<GameObject> _stations;
    [SerializeField] private List<GameObject> _metros;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetClosestStation(Vector3 position)
    {
        var auxDistance = 1000f;
        GameObject aux = null;
        foreach (var station in _stations)
        {
            if (Vector3.Distance(position, station.gameObject.transform.position) < auxDistance)
            {
                aux = station;
            }
        }
        return aux;
    }
}