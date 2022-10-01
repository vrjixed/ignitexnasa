using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateARObject : MonoBehaviour
{
    float rotationSpeed = 700f;

    Vector3 lastMousePos;
    Vector3 currentMousePos;

    float lastFingersDistance;
    float currentFingersDistance;

    float zoomSpeed = 0.001f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lastMousePos = currentMousePos;
        currentMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        var diff = currentMousePos - lastMousePos;

        if(Input.touchCount == 2)
        {
            lastFingersDistance = currentFingersDistance;
            currentFingersDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            var diffDist = currentFingersDistance - lastFingersDistance;

            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {
                diff = Vector3.zero;
                diffDist = 0f;
            } 

            diff = diff * rotationSpeed;

            if (Input.GetMouseButton(0))
            {
                transform.Rotate(0f, -diff.x, 0f, Space.Self);

                float size = transform.localScale.x;
                size += diffDist * zoomSpeed;

                size = Mathf.Clamp(size, 0.3f, 5f);

                transform.localScale = size * Vector3.one;
            }
        }


    }
}
