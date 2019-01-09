using Controllers;
using Persistence;
using UnityEngine;
using Utils;

public class StartManager : MonoBehaviour
{

    [SerializeField] public GameObject PersonPrefab;
    
    private void Start()
    {
        RecordsController.Instance.ExecuteAwake();
        
        foreach (var i in Functions.Range(0, 10))
        {
            Instantiate(PersonPrefab, new Vector3(i * 2, 2, 10), Quaternion.identity);
        }

        new StandardTimer(() =>
        {
            foreach (var controller in WorkplaceManager.Instance.GetAllControllers())
            {
                controller.ExecuteAwake();
            }
            
            foreach (var controller in ApartmentManager.Instance.GetAllControllers())
            {
                controller.ExecuteAwake();
            }

            foreach (var controller in SupermarketManager.Instance.GetAllControllers())
            {
                controller.ExecuteAwake();
            }
            
            foreach (var controller in HobbiesManager.Instance.GetAllCinemaControllers())
            {
                controller.ExecuteAwake();
            }
            
            foreach (var controller in HobbiesManager.Instance.GetAllParkControllers())
            {
                controller.ExecuteAwake();
            }
            
            foreach (var controller in HobbiesManager.Instance.GetAllShopControllers())
            {
                controller.ExecuteAwake();
            }
           
            foreach (var controller in PersonsManager.Instance.GetAllControllers())
            {
                controller.ExecuteAwake();
            }
            
        }, 1);
    }
}