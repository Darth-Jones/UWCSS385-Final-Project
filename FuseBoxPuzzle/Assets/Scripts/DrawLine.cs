using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    Vector3 startPos;
    Vector3 endPos;
    Camera camera;
    LineRenderer lineRenderer;

    private bool lineDrawn;

    Vector3 camOffset = new Vector3(0, 0, 10);

    [SerializeField] AnimationCurve ac;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lineRenderer == null)
            {
                lineRenderer = gameObject.AddComponent<LineRenderer>();
            }

            else
            {
                lineRenderer.enabled = true;
            }
            //lr.enabled = true;
            
            //lr.widthCurve = ac;
            //lr.numCapVertices = 10;
        }
        if (Input.GetMouseButton(0))
        {
            endPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            lineRenderer.SetPosition(1, endPos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //lr.enabled = false;
        }
    }
}
