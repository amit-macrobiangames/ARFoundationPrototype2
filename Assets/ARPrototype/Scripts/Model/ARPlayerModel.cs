using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ARFoundation.Prototype.Models
{
    public class ARPlayerModel : MonoBehaviour
    {

        #region --------- PRIVATE VARIABLES ----------
        #region --------- SERIALIZED VARIABLES ----------
        [SerializeField] private List<Renderer> shoeRenderer = null;
        [SerializeField] private List<Renderer> eyeRenderer = null;
        [SerializeField] private string strWalkAnimClip = "";
        [SerializeField] private string strIdleAnimClip = "";
        #endregion
        #region --------- NON-SERIALIZED VARIABLES -------
        private Animator animator = null;
        private bool isWalking = false;
        #endregion
        #endregion

        #region --------- MONOBEHAVIOUR METHODS -------
        private void OnEnable()
        {
            animator = GetComponent<Animator>();
        }
        #endregion

        #region --------- PUBLIC METHODS ----------
        public void StartWalk()
        {
            animator.Play(strWalkAnimClip);
        }
        public void StayIdle() 
        {
            animator.Play(strIdleAnimClip);
        }
        public void ChangeShoeColor(Material mat)
        {
            for (int i = 0; i < shoeRenderer.Count; i++)
            {
                shoeRenderer[i].material = mat;
            }
        }

        public void ChangeEyeColor(Material mat)
        {
            for (int i = 0; i < eyeRenderer.Count; i++)
            {
                eyeRenderer[i].material = mat;
            }
        }
        public bool IsWalking
        {
            get
            {
                return isWalking;
            }
            set
            {
                isWalking = value;
            }
        }
        #endregion

    }
}

