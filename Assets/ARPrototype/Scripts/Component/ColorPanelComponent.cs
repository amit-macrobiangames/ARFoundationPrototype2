using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ARFoundation.Prototype.View;
using ARFoundation.Prototype.Controller;

namespace ARFoundation.Prototype.Components
{
    public class ColorPanelComponent : MonoBehaviour
    {

        #region --------- PRIVATE VARIABLES ----------
        #region --------- SERIALIZED VARIABLES ----------
        [SerializeField] private ARView arView = null;
        [SerializeField] private ARController arController = null;
        [SerializeField] private List<Button> colorButtonsEye = null;
        [SerializeField] private List<Button> colorButtonsShoes = null;
        #endregion
        #endregion

        #region --------- MONOBEHAVIOUR METHODS ---------
        private void Start()
        {
            for (int i = 0; i < colorButtonsEye.Count; i++)
            {
                int n = i;
                colorButtonsEye[n].onClick.AddListener(() => EyeColor(n));
                colorButtonsShoes[n].onClick.AddListener(() => ShoeColor(n));
            }
        }
        #endregion

        #region --------- PUBLIC METHODS ----------
        public void EyeColor(int index)
        {
            Debug.Log("Eye: "+ index);
            arController.ChangeEyeColor(index);
        }
        public void ShoeColor(int index)
        {
            Debug.Log("Shoe: " + index);
            arController.ChangeShoeColor(index);
        }
        #endregion

    }
}