using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

namespace Persistence
{
    public class HobbiesManager
    {
        public static readonly HobbiesManager Instance = new HobbiesManager();
        
        private readonly List<GameObject> _cinemas;
        private readonly List<GameObject> _parks;
        private readonly List<GameObject> _shops;

        private HobbiesManager()
        {
            _cinemas = new List<GameObject>();
            _parks = new List<GameObject>();
            _shops = new List<GameObject>();
        }

        public void AddCinema(GameObject obj)
        {
            _cinemas.Add(obj);
        }

        private static CinemaController GetCinemaController(GameObject obj)
        {
            return obj.GetComponent<CinemaController>();
        }

        public Vector3 GetRandomCinemaPlace()
        {
            return GetCinemaController(_cinemas.Random()).GetRandomAvailableWorkPosition();
        }

        public IEnumerable<CinemaController> GetAllCinemaControllers()
        {
            return _cinemas.Select(GetCinemaController);
        }

        public void AddPark(GameObject park)
        {
            _parks.Add(park);
        }
        
        private static ParkController GetParkController(GameObject obj)
        {
            return obj.GetComponent<ParkController>();
        }

        public Vector3 GetRandomParkPlace()
        {
            return GetParkController(_parks.Random()).GetRandomAvailableWorkPosition();
        }

        public IEnumerable<ParkController> GetAllParkControllers()
        {
            return _parks.Select(GetParkController);
        }
        
        public void AddShop(GameObject shop)
        {
            _shops.Add(shop);
        }
        
        private static ShopController GetShopController(GameObject obj)
        {
            return obj.GetComponent<ShopController>();
        }

        public Vector3 GetRandomShopPlace()
        {
            return GetShopController(_shops.Random()).GetRandomAvailableWorkPosition();
        }

        public IEnumerable<ShopController> GetAllShopControllers()
        {
            return _shops.Select(GetShopController);
        }
        
        public void ClearManager()
        {
            _cinemas.Clear();
        }
    }
}