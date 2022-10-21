using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlayerComponent : MonoBehaviour
{
    public List<Renderer> shoeRenderer = null;
    public List<Renderer> eyeRenderer = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
