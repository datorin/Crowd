using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Persistence
{
    public class WorkplaceManager
    {
        public static readonly WorkplaceManager Instance = new WorkplaceManager();
        
        private readonly List<GameObject> _workplaces;

        private WorkplaceManager()
        {
            _workplaces = new List<GameObject>();
        }

        public void AddWorkplace(GameObject obj)
        {
            _workplaces.Add(obj);
        }

        private static BuildingController GetWorkplaceController(GameObject obj)
        {
            return obj.GetComponent<BuildingController>();
        }

        public Vector3 GetRandomWorkplace()
        {
            return GetWorkplaceController(_workplaces.Random()).GetRandomAvailableWorkPosition();
        }

        public void ClearManager()
        {
            _workplaces.Clear();
        }

        public IEnumerable<BuildingController> GetAllControllers()
        {
            return _workplaces.Select(GetWorkplaceController);
        }
    }
}