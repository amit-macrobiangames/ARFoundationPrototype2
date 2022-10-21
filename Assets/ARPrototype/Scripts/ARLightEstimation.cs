using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.ARFoundation;

public class ARLightEstimation : MonoBehaviour
{
    public ARCameraManager arCameraManager;
    Light lights;

    private void Awake()
    {
        lights = GetComponent<Light>();
    }

    private void OnEnable()
    {
        arCameraManager.frameReceived += FrameUpdated;
    }

    private void OnDisable()
    {
        arCameraManager.frameReceived -= FrameUpdated;
    }

    private void FrameUpdated(ARCameraFrameEventArgs arCamFrame)
    {
        if (arCamFrame.lightEstimation.averageBrightness.HasValue)
        {
            lights.intensity = arCamFrame.lightEstimation.averageBrightness.Value;
        }

    }
}
