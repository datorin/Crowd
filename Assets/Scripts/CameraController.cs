using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] float _speed; //regular speed
    [SerializeField] private float _hSpeed;
    [SerializeField] private float _vSpeed;
    private float totalRun= 1.0f;
    private float h = 0;
    private float v = 0;
    [SerializeField] private GameObject _fire;
    [SerializeField] private GameObject _gold;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update () {
        //Mouse  camera angle
        h += _hSpeed * Input.GetAxis("Mouse X");
        v -= _vSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(v,h,0);
       
        //Keyboard commands
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if(Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue) * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.Space) && Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(0, 1, 0) * _speed * Time.deltaTime, Space.World);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Camera.main == null) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit)) {
                var firePosition = hit.point;
                // Instantiate fire
                Instantiate(_fire, firePosition, Quaternion.identity);
            }
        }
        
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            if (Camera.main == null) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit)) {
                var goldPosition = hit.point;
                // Instantiate fire
                Instantiate(_gold, goldPosition, Quaternion.identity);
            }
        }
    }
}
