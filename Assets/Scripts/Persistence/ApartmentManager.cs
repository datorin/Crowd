using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Persistence
{
    public class ApartmentManager
    {
        public static readonly ApartmentManager Instance = new ApartmentManager();
        
        private readonly List<GameObject> _apartments;

        private ApartmentManager()
        {
            _apartments = new List<GameObject>();
        }

        public void AddApartment(GameObject obj)
        {
            _apartments.Add(obj);
        }

        private static ApartmentController GetApartmentController(GameObject obj)
        {
            return obj.GetComponent<ApartmentController>();
        }

        public Vector3 GetRandomApartment()
        {
            return GetApartmentController(_apartments.Random()).GetRandomAvailableWorkPosition();
        }

        public void ClearManager()
        {
            _apartments.Clear();
        }

        public IEnumerable<ApartmentController> GetAllControllers()
        {
            return _apartments.Select(GetApartmentController);
        }
    }
}