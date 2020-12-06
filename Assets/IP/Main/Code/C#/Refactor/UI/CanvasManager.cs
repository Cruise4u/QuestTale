using UnityEngine;

class CanvasManager : MonoBehaviour
{
    public void SetUIDirection(Camera camera)
    {
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.renderMode == RenderMode.WorldSpace)
            {
                canvas.gameObject.transform.forward = -camera.transform.forward;
            }
        }
    }
}
