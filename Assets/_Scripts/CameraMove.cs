using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera cam;
    private bool zoom;
    private bool rot;
    void Start()
    {

    }

    void Update()
    {

        if (cam.fieldOfView <= 50)
        {
            zoom = false;
        }
        if (cam.fieldOfView >= 65)
        {
            zoom = true;
        }
        if (zoom)
        {
            cam.fieldOfView -= 0.2f;
        }
        else
        {
            cam.fieldOfView += 0.2f;

        }

    }
}
