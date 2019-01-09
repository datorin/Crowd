using System.Collections.Generic;
using UnityEngine;

namespace Persistence
{
    public class WorkplaceManager
    {
        public static readonly WorkplaceManager Instance = new WorkplaceManager();
        
        private readonly List<GameObject> workplaces;

        private WorkplaceManager()
        {
            workplaces = new List<GameObject>();
        }

        public void AddWorkplace(GameObject obj)
        {
            workplaces.Add(obj);
        }

        private static BuildingController GetWorkplaceController(GameObject obj)
        {
            return obj.GetComponent<BuildingController>();
        }

        public Vector3 GetRandomWorkplace()
        {
            return GetWorkplaceController(workplaces.Random()).GetRandomAvailableWorkPosition();
        }

        public void ClearManager()
        {
            workplaces.Clear();
        }
    }
}