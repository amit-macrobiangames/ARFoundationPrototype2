using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EyeAndShoeColor", order = 1)]
public class EyeAndShoeColor : ScriptableObject
{
    public List<Material> listEyeMat = new List<Material>();
    public List<Material> listShoeMat = new List<Material>();
}
