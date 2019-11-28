using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Camera touchBasedCamera;
    private GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoniteringTouch()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }
        if (Input.GetMouseButton(0))
        {
            if (selectedObject != null)
            {
                var ray = touchBasedCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray.origin, ray.direction, out hit)) {
                    MoveObject(hit.point);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            var ray = touchBasedCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit)) {
                //Debug.Log(hit.collider.gameObject.tag);
                //Debug.Log(hit.collider.gameObject.name);
                switch (hit.collider.gameObject.tag)
                {
                    case "Player":
                        SelectPlayer(hit.collider.gameObject);
                        SelectObject(hit.collider.gameObject);
                        break;
                    case "Ray":
                        SelectObject(hit.collider.gameObject);
                        break;
                    case "Field":
                        SelectObject(hit.collider.gameObject);
                        break;
                }
            }
        }
    }

    void SelectPlayer(GameObject obj)
    {
        CameraController.Instance.SetCameraPos(obj.transform.position);
    }

    void SelectObject(GameObject obj)
    {
        selectedObject = obj;
    }

    void MoveObject(Vector3 pos)
    {
        switch (selectedObject.tag)
        {
            case "Player":
                MovePlayer(pos);
                break;
            case "Ray":
                MoveRay(pos);
                break;
        }
    }

    void MovePlayer(Vector3 pos)
    {
        selectedObject.GetComponent<PlayerController>().SetPlayerPos(pos);
        CameraController.Instance.SetCameraPos(pos);
    }

    void MoveRay(Vector3 pos)
    {
        selectedObject.transform.parent.GetComponent<PlayerController>().SetPlayerAngle(pos);
        CameraController.Instance.SetCameraAngle(pos);
    }

    // Update is called once per frame
    void Update()
    {
        //var ray = touchBasedCamera.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        MoniteringTouch();
    }
}
