using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    public ARPlaneManager planeManager = null;
    public ARView aRView = null;
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;
    public bool isInstantiated = false;
    public Transform trCam = null;
    public GameObject clone = null;

    
    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
            if (hits.Count > 0)
            {
                if (!isInstantiated)
                {
                    isInstantiated = true;
                    clone = Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                    clone.transform.LookAt(new Vector3(trCam.position.x, clone.transform.position.y,
                        trCam.transform.position.z));
                    aRView.UpdateDistance(clone.transform);
                    //     clone.transform.position = hits[0].pose.position;
                    //     clone.transform.LookAt(new Vector3(trCam.position.x, clone.transform.position.y,
                    //clone.transform.position.z));
                    //     aRView.UpdateDistance(clone.transform);
                }
            }
        }
    }
    private void LateUpdate()
    {
        if (isInstantiated)
        {
            foreach (ARPlane plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            aRView.UpdateDistance(clone.transform);
            
            clone.transform.LookAt(new Vector3(trCam.position.x, clone.transform.position.y,
               trCam.position.z));
        }
    }
}
