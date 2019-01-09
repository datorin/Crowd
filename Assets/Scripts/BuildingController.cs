using System.Collections.Generic;
using System.Linq;
using Persistence;
using UnityEngine;
using Utils;

public class BuildingController : MonoBehaviour
{
    private IDictionary<Vector3, bool> _availableWorkPositions;

    private void Awake()
    {
        _availableWorkPositions = new Dictionary<Vector3, bool>();

        for (var i = 0; i >= 0; i++)
        {
            var floor = gameObject.transform.Find("Floor_" + i);
            if (floor == null) break;
            var high = floor.transform.position.y + 1;
            foreach (var x in Functions.Range(2, 19, 1))
            {
                foreach (var z in Functions.Range(9, 19, 1))
                {
                    _availableWorkPositions.Add(new Vector3(x + transform.position.x, high, z + transform.position.y), true);
                }
            }
        }
        
        WorkplaceManager.Instance.AddWorkplace(gameObject);
    }

    public Vector3 GetRandomAvailableWorkPosition()
    {
        var place = _availableWorkPositions.Where(x => x.Value).Random().Key;
        _availableWorkPositions[place] = false;
        return place;
    }
}