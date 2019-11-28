using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewRay : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject cylinder;

    const float hight = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetColor(Color color)
    {
        this.color = color;
        this.color.a = 1;
        lineRenderer.material.color = this.color;
    }

    private void Draw()
    {
        Vector3 position = transform.position;
        position = new Vector3(position.x, position.y + hight, position.z);
        Ray ray = new Ray(position, transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            Debug.Log(hit.collider.gameObject.name);
            float distance = Vector3.Distance(hit.point, position);
            lineRenderer.SetPosition(0, hit.point);
            lineRenderer.SetPosition(1, position);

            cylinder.transform.localScale = new Vector3(cylinder.transform.localScale.x, distance / 2, cylinder.transform.localScale.z);
            Vector3 cylinderPos = position + (hit.point - position) / 2;
            cylinderPos = new Vector3(cylinderPos.x, hight, cylinderPos.z);
            cylinder.transform.position = cylinderPos;

            //Debug.DrawRay(ray.origin, ray.direction * distance, color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }
}
