using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Persistence
{
    public class PersonsManager
    {
        public static readonly PersonsManager Instance = new PersonsManager();

        private IList<GameObject> _persons;
        
        private PersonsManager()
        {
            _persons = new List<GameObject>();
        }

        public void AddPerson(GameObject person)
        {
            _persons.Add(person);
        }
        
        private static PersonController GetPersonController(GameObject obj)
        {
            return obj.GetComponent<PersonController>();
        }

        public IEnumerable<PersonController> GetAllControllers()
        {
            return _persons.Select(GetPersonController);
        }
    }
}