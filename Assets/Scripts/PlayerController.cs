using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject capsule;
    [SerializeField] private Color color;
    [SerializeField] private ViewRay viewRay;

    const float hight = 0f;
    public void SetPlayerPos (Vector3 pos)
    {
        transform.position = new Vector3(pos.x, hight, pos.z);
    }

    void Start()
    {
        SetColor();
    }

    void SetColor()
    {
        capsule.gameObject.GetComponent<MeshRenderer>().material.color = color;
        viewRay.SetColor(color);
    }

    public void SetPlayerAngle(Vector3 targetPos)
    {
        Vector3 target = new Vector3(targetPos.x, 0, targetPos.z);
        transform.LookAt(target);
    }

}
