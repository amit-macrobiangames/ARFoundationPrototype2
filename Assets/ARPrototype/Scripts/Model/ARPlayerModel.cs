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
        #endregion
        #endregion

        #region --------- PUBLIC METHODS ----------
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
        #endregion

    }
}

