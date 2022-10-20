using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARView : MonoBehaviour
{
    public ARCursor aRCursor = null;
    public EyeAndShoeColor matEyeAndShoe = null;
    public Button btnEye = null;
    public Button btnShoe = null;
    public TextMeshProUGUI txtDistance = null;
    public float fltZDistance = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ChangeEyeAndShoesColor(int i)
    {
        if (aRCursor.isInstantiated)
        {
            if (i == 0)
            {
                ChangeEyeColor(aRCursor.clone);
            }
            else if (i == 1)
            {
                ChangeShoeColor(aRCursor.clone);
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
        fltZDistance = Vector3.Distance(Camera.main.transform.position, obj.position);
        Debug.Log(fltZDistance);
        txtDistance.text = fltZDistance.ToString();
        Vector3 newPos = Camera.main.transform.position;

        if (fltZDistance >= 1.5f)
        {
            obj.position = Vector3.MoveTowards(obj.position, new Vector3(newPos.x, obj.position.y, newPos.z), 1f * Time.deltaTime);
        }
    }
}
