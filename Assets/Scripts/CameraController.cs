using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static CameraController ins;
    public static CameraController Instance
    {
        get
        {
            if (ins == null)
            {
                ins = FindObjectOfType<CameraController>();
            }
            return ins;
        }
    }

    [SerializeField] private GameObject camera;
    const float hight = 0.8f;

    public void SetCameraPos(Vector3 pos)
    {
        pos = new Vector3(pos.x, hight, pos.z);
        camera.transform.position = pos;
    }

    public void SetCameraAngle(Vector3 targetPos)
    {
        Vector3 target = new Vector3(targetPos.x, hight, targetPos.z);
        gameObject.transform.LookAt(target);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
