using System;
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Ray GetCameraRay(Camera camera)
    {
        //Send a ray througth the camera to the current mouse position..
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        return ray;
    }


}
