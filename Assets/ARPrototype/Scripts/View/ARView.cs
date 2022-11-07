using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ARFoundation.Prototype.Models;
using ARFoundation.Prototype.Components;
using ARFoundation.Prototype.Controller;

namespace ARFoundation.Prototype.View
{
    public class ARView : MonoBehaviour
    {

        #region --------- PRIVATE VARIABLES ----------
        #region --------- SERIALIZED VARIABLES ----------
        [SerializeField] private ARController aRController = null;
        [SerializeField] private EyeAndShoeColor matEyeAndShoe = null;
        [SerializeField] private Button btnEye = null;
        [SerializeField] private Button btnShoe = null;
        [SerializeField] private TextMeshProUGUI txtDistance = null;
        [SerializeField] private string strIdleAnimClip = "";
        [SerializeField] private string strWalkAnimClip = "";
        [SerializeField] private GameObject goColorBoxEye = null;
        [SerializeField] private GameObject goColorBoxShoe = null;

        #endregion

        #region --------- NON-SERIALIZED VARIABLES ----------
        private Animator girlAnim = null;
        private float fltZDistance = 0;
        private Vector3 camPos = new Vector3();
        #endregion
        #endregion

        #region ---------- MONOBEHAVIOR METHODS ---------

        private void Start()
        {

            btnEye.onClick.AddListener(() => ChangeEyeAndShoesColor(0));
            btnShoe.onClick.AddListener(() => ChangeEyeAndShoesColor(1));
        }

        #endregion
        #region ---------- PUBLIC METHODS ---------

        // ON-CLICK METHOD TO CHANGE EYE AND SHOE COLOR
        public void ChangeEyeAndShoesColor(int i)
        {
            if (aRController.IsInstantiated)
            {
                if (i == 0)
                {
                    if (goColorBoxEye.activeInHierarchy)
                    {
                        HideBoxes();
                    }
                    else
                    {
                        goColorBoxShoe.SetActive(false);
                        goColorBoxEye.SetActive(true);
                    }
                    //ChangeEyeColor(aRController.ClonedGirl);
                }
                else if (i == 1)
                {
                    if (goColorBoxShoe.activeInHierarchy)
                    {
                        HideBoxes();
                    }
                    else
                    {
                        goColorBoxEye.SetActive(false);
                        goColorBoxShoe.SetActive(true);
                    }
                    //ChangeShoeColor(aRController.ClonedGirl);
                }
            }
        }

        private void HideBoxes()
        {
            goColorBoxEye.SetActive(false);
            goColorBoxShoe.SetActive(false);
        }
        public void UpdateDistance(Transform obj)
        {
            camPos = Camera.main.transform.position;
            fltZDistance = Vector3.Distance(new Vector3(camPos.x, obj.position.y, camPos.z), obj.position);
            txtDistance.text = fltZDistance.ToString();
            if (fltZDistance >= 1.5f)
            {
                HideBoxes();
                StartCoroutine(StartWalk(obj));
            }
            else
            {
                //girlAnim.ResetTrigger("IsWalk");
                //girlAnim.SetTrigger("IsIdle");
                //girlAnim.CrossFade(strWalkAnimClip, 0.5f);
                StopAllCoroutines();
                girlAnim.Play(strIdleAnimClip);
            }
        }
        public IEnumerator StartWalk(Transform girl)
        {
            yield return new WaitForSeconds(2f);
            girl.position = Vector3.MoveTowards(girl.position, new Vector3(camPos.x, girl.position.y, camPos.z), 1f * Time.deltaTime);
            //girlAnim.ResetTrigger("IsIdle");
            //girlAnim.SetTrigger("IsWalk");
            //girlAnim.CrossFade(strIdleAnimClip, 2f);
            girlAnim.Play(strWalkAnimClip);

        }
        public Animator GirlAnimator
        {
            get
            {
                return girlAnim;
            }
            set
            {
                girlAnim = value;
            }
        }
        public EyeAndShoeColor EyeAndShoe
        {
            get
            {
                return matEyeAndShoe;
            }
            set
            {
                matEyeAndShoe = value;
            }
        }

        #endregion

    }
}

