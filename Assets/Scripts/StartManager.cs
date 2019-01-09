using Controllers;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    private void Start()
    {
        RecordsController.Instance.ExecuteAwake();

        new StandardTimer(() => { }, 1);
    }
}