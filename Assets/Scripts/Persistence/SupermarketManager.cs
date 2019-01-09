using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Persistence
{
    public class SupermarketManager
    {
        public static readonly SupermarketManager Instance = new SupermarketManager();
        
        private readonly List<GameObject> _supermarkets;

        private SupermarketManager()
        {
            _supermarkets = new List<GameObject>();
        }

        public void AddSupermarket(GameObject obj)
        {
            _supermarkets.Add(obj);
        }

        private static SupermarketController GetSupermarketController(GameObject obj)
        {
            return obj.GetComponent<SupermarketController>();
        }

        public Vector3 GetRandomSupermarket()
        {
            return GetSupermarketController(_supermarkets.Random()).GetRandomAvailablePosition();
        }

        public void ClearManager()
        {
            _supermarkets.Clear();
        }

        public IEnumerable<SupermarketController> GetAllControllers()
        {
            return _supermarkets.Select(GetSupermarketController);
        }
    }
}