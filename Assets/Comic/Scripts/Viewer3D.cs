using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer3D : MonoBehaviour
{
    public Transform target;

    public float rotationSpeed = 400f;

    public bool rotateHorizontallyOnly = false;

    Vector3 lastMousePos;
    Vector3 currentMousePos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lastMousePos = currentMousePos;
        currentMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        var diff = currentMousePos - lastMousePos;

        if (Input.GetMouseButtonDown(0))
        {
            diff = Vector3.zero;
        }
        diff = diff * rotationSpeed;

        if(Input.touchCount == 1)
        {
            if (Input.GetMouseButton(0))
            {
                if (rotateHorizontallyOnly)
                {
                    target.transform.Rotate(0f, -diff.x, 0f, Space.Self);
                }
                else
                {
                    target.transform.Rotate(diff.y, -diff.x, 0f, Space.World);
                }

            }
        }
        
    }
}
