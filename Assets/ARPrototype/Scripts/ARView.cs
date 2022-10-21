using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARView : MonoBehaviour
{
    public ARController aRController = null;
    public EyeAndShoeColor matEyeAndShoe = null;
    public Button btnEye = null;
    public Button btnShoe = null;
    public TextMeshProUGUI txtDistance = null;
    public float fltZDistance = 0;
    private Vector3 camPos = new Vector3();
    void Start()
    {

    }

    void Update()
    {
        
    }
    public void ChangeEyeAndShoesColor(int i)
    {
        if (aRController.isInstantiated)
        {
            if (i == 0)
            {
                ChangeEyeColor(aRController.clone);
            }
            else if (i == 1)
            {
                ChangeShoeColor(aRController.clone);
            }
        }
    }
    public void ChangeEyeColor(GameObject girl)
    {
        int rndIndex = Random.Range(0, matEyeAndShoe.listEyeMat.Count);
        Material mat = matEyeAndShoe.listEyeMat[rndIndex];
        girl.GetComponent<ARPlayerComponent>().ChangeEyeColor(mat);
    }
    public void ChangeShoeColor(GameObject girl)
    {
        int rndIndex = Random.Range(0, matEyeAndShoe.listShoeMat.Count);
        Material mat = matEyeAndShoe.listShoeMat[rndIndex];
        girl.GetComponent<ARPlayerComponent>().ChangeShoeColor(mat);
    }
    public void UpdateDistance(Transform obj)
    {
        camPos = Camera.main.transform.position;


        //Vector3 differenceDirection = Vector3.forward;
        //fltYDistance = Vector3.Dot(differenceDirection,
        //        camPos - obj.position);
        //if(fltYDistance < 0)
        //{
        //    fltYDistance = fltYDistance * (-1);
        //}
        fltZDistance = Vector3.Distance(new Vector3(camPos.x , obj.position.y, camPos.z), obj.position);
        txtDistance.text = fltZDistance.ToString();
        if (fltZDistance >= 1.5f)
        {
            obj.position = Vector3.MoveTowards(obj.position, new Vector3(camPos.x, obj.position.y, camPos.z), 1f * Time.deltaTime);
        }
    }
}
