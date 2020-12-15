using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(menuName ="Camera/ConfigData")]
public class CameraConfigData : ScriptableObject
{
    public Vector3 _cameraOffset;
    public float _cameraPitch;
    public float _currentZoom;
    public float _minZoom;
    public float _maxZoom;
    public float _zoomSpeed;
}

public class CameraManager : MonoBehaviour
{
    public Camera playerCamera;
    public CameraConfigData configData;
    public CameraGraphicEffects cameraEffects;
    public CameraRig cameraRig;
    public bool isViewLocked;

    public void Setup()
    {
        cameraEffects = new CameraGraphicEffects();
        cameraRig = new CameraRig();
        isViewLocked = false;
    }

}

public class CameraRig
{
    public void Zoom(CameraConfigData configData)
    {
        configData._currentZoom -= Input.GetAxis("Mouse ScrollWheel") * configData._zoomSpeed;
        configData._currentZoom = Mathf.Clamp(configData._currentZoom, configData._minZoom, configData._maxZoom);
    }

    public void SmoothCameraPosition(CameraConfigData configData,GameObject cameraTarget)
    {
        cameraTarget.transform.position = cameraTarget.transform.position - configData._cameraOffset * configData._currentZoom;
        cameraTarget.transform.LookAt(cameraTarget.transform.position + Vector3.up * configData._cameraPitch);
    }

    public void GetDirectionForwardToCamera(Camera cam, Canvas[] canvases)
    {
        foreach (Canvas canvas in canvases)
        {
            if (canvas.renderMode == RenderMode.WorldSpace)
            {
                canvas.gameObject.transform.forward = -cam.transform.forward;
            }
        }
    }

}

public class CameraGraphicEffects
{
    public void SetPostProcessingEffectOn(Camera cam)
    {
        var postProcessVolume = cam.GetComponent<PostProcessVolume>();
        postProcessVolume.enabled = true;
    }

    public void SetToneGammaValue(Camera cam,float toneAmount)
    {
        ColorGrading colorGrading = null;
        var ppVolume = cam.GetComponent<PostProcessVolume>();
        ppVolume.profile.TryGetSettings(out colorGrading);
        colorGrading.toneCurveGamma.value += toneAmount;
    }

    public void TriggerDeathScreen(Camera cam)
    {
        float value = Mathf.Clamp(Time.deltaTime, 0.0f, 5.0f);
        SetToneGammaValue(cam,value);
    }
}

public interface ICameraFollow
{
    void FollowObject(ICameraFollowed followed);
}

public interface ICameraFollowed
{
    void FocusObject();
}

