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
        //To change
        if (position.Equals(new Vector3(0,0,0)))
        {
            return _stations.Last();
        }
        return _stations.First();
    }
    
    
}