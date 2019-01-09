using System.Collections.Generic;
using System.Linq;
using Persistence;
using UnityEngine;
using Utils;

public class ApartmentController : MonoBehaviour
{
    private IDictionary<Vector3, bool> _availablePositions;

    private void Awake()
    {
        _availablePositions = new Dictionary<Vector3, bool>();
        ApartmentManager.Instance.AddApartment(gameObject);
    }

    public void ExecuteAwake()
    {
        for (var i = 0; i >= 0; i++)
        {
            var floor = gameObject.transform.Find("Floor_" + i);
            if (floor == null) break;
            var high = floor.transform.position.y + 1;
            foreach (var x in Functions.Range(-18, -1, 1))
            {
                foreach (var z in Functions.Range(2, 22, 1))
                {
                    var pos = new Vector3(x + transform.position.x, high, z + transform.position.z);
                    if(_availablePositions.ContainsKey(pos)) continue;
                    _availablePositions.Add(pos, true);
                }
                
                foreach (var z in Functions.Range(-24, -8, 1))
                {
                    var pos = new Vector3(x + transform.position.x, high, z + transform.position.z);
                    if(_availablePositions.ContainsKey(pos)) continue;
                    _availablePositions.Add(pos, true);
                }
            }
        }
    }
    
    public Vector3 GetRandomAvailableWorkPosition()
    {
        var place = _availablePositions.Where(x => x.Value).Random().Key;
        _availablePositions[place] = false;
        return place;
    }
}