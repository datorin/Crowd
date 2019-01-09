using System.Collections.Generic;
using System.Linq;
using Persistence;
using UnityEngine;
using Utils;

public class ParkController : MonoBehaviour
{
    private IDictionary<Vector3, bool> _availablePositions;

    private void Awake()
    {
        _availablePositions = new Dictionary<Vector3, bool>();
        HobbiesManager.Instance.AddPark(gameObject);
    }

    public void ExecuteAwake()
    {
        var high = transform.position.y + 1;
        foreach (var x in Functions.Range(2, 285, 1))
        {
            foreach (var z in Functions.Range(-98, -2, 1))
            {
                var pos = new Vector3(x + transform.position.x, high, z + transform.position.z);
                if (_availablePositions.ContainsKey(pos)) continue;
                _availablePositions.Add(pos, true);
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