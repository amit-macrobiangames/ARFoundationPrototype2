using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using ARFoundation.Prototype.View;
using ARFoundation.Prototype.Models;

namespace ARFoundation.Prototype.Controller
{
    public class ARController : MonoBehaviour
    {
        #region --------- PRIVATE VARIABLES ---------
        #region --------- SERIALIZED VARIABLES ---------
        [SerializeField] private ARPlaneManager planeManager = null;
        [SerializeField] private ARView aRView = null;
        [SerializeField] private GameObject objectToPlace;
        [SerializeField] private ARRaycastManager raycastManager;
        [SerializeField] private Transform trCam = null;
        #endregion
        #region --------- NON-SERIALIZED VARIABLES ---------
        private bool isInstantiated = false;
        private GameObject clone = null;
        #endregion
        #endregion

        #region --------- MONOBEHAVIOUR METHODS  ---------

        // Cloning Character After Detecting Touch on Rendered Plane
        private void Update()
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
                        clone.transform.LookAt(new Vector3(trCam.position.x, clone.transform.position.y, trCam.transform.position.z));
                        aRView.UpdateDistance(clone.transform);
                    }
                }
            }
        }
        // Handling Distance And Character Rotation On Movement
        private void LateUpdate()
        {
            if (isInstantiated)
            {
                foreach (ARPlane plane in planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
                aRView.UpdateDistance(clone.transform);
                clone.transform.LookAt(new Vector3(trCam.position.x, clone.transform.position.y, trCam.position.z));
            }
        }
        #endregion
        #region --------- PUBLIC METHODS ---------

        public void ChangeEyeColor(int index)
        {
            Debug.Log("ChangeEyeColor");
            Material mat = aRView.EyeAndShoe.listEyeMat[index];
            clone.GetComponent<ARPlayerModel>().ChangeEyeColor(mat);
        }
        public void ChangeShoeColor(int index)
        {
            Debug.Log("ChangeShoeColor");
            Material mat = aRView.EyeAndShoe.listShoeMat[index];
            clone.GetComponent<ARPlayerModel>().ChangeShoeColor(mat);
        }
        public bool IsInstantiated
        {
            get
            {
                return isInstantiated;
            }
            set
            {
                isInstantiated = value;
            }
        }
        public GameObject ClonedGirl
        {
            get
            {
                return clone;
            }
            set
            {
                clone = value;
            }
        }
        #endregion
    }
}

