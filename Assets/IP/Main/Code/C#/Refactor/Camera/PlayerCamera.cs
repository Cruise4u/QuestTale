using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera playerCamera;

    public void Start()
    {
        GetCameraComponentByTag("Camera");
    }

    public void GetCameraComponentByTag(string tag)
    {
        int numberOfChilds = gameObject.transform.childCount;
        GameObject[] childObjects = new GameObject[numberOfChilds];
        for(int i = 0; i < childObjects.Length; i++)
        {
            childObjects[i] = gameObject.transform.GetChild(i).gameObject;
            if (childObjects[i].CompareTag(tag))
            {
                playerCamera = childObjects[i].gameObject.GetComponent<Camera>();
            }
        }
    }

    public Ray GetCameraRay()
    {
        //Send a ray througth the camera to the current mouse position..
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        return ray;
    }

    public void Zoom()
    {

    }

    //public Transform focusTarget;
    //public Vector3 offset;

    //public float currentZoom = 3.0f;
    //public float minZoom = 1.0f;
    //public float maxZoom = 5.0f;
    //public float zoomSpeed = 2.5f;
    //public bool isLocked = false;

    //public float pitch = 2.0f;

    //public void Start()
    //{
    //    offset = new Vector3(0, -8f, 6f);
    //}

    //private void Update()
    //{
    //    if (isLocked != true)
    //    {
    //        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    //        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    //    }
    //}

    //private void LateUpdate()
    //{
    //    SmoothCameraPosition(focusTarget);
    //    GetDirectionForwardToCamera();
    //}

    //#region Camera Functionality

    //public void SmoothCameraPosition(Transform target)
    //{
    //    transform.position = target.position - offset * currentZoom;
    //    transform.LookAt(target.position + Vector3.up * pitch);
    //}

    //public void GetDirectionForwardToCamera()
    //{
    //    Camera cam = Camera.main;
    //    foreach (Canvas canvas in FindObjectsOfType<Canvas>())
    //    {
    //        if (canvas.renderMode == RenderMode.WorldSpace)
    //        {
    //            canvas.gameObject.transform.forward = -cam.transform.forward;
    //        }
    //    }
    //}

    //#endregion

    //#region Camera Visual Effects
    //// Graphics
    //public void SetPostProcessingEffectOn()
    //{
    //    Camera camera = FindObjectOfType<Camera>();
    //    var postProcessVolume = camera.GetComponent<PostProcessVolume>();
    //    postProcessVolume.enabled = true;
    //}

    //// Graphics
    //public void SetToneGammaValue(float amount)
    //{
    //    Camera camera = FindObjectOfType<Camera>();

    //    ColorGrading colorGrading = null;

    //    var ppVolume = gameObject.GetComponent<PostProcessVolume>();
    //    ppVolume.profile.TryGetSettings(out colorGrading);
    //    colorGrading.toneCurveGamma.value += amount;
    //}

    //public void TriggerDeathScreen()
    //{
    //    float value = Mathf.Clamp(Time.deltaTime, 0.0f, 5.0f);
    //    SetToneGammaValue(value);
    //}
    //#endregion
}


