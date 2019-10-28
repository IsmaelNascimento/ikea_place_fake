using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ContentAR : System.Object
{
    public GameObject prefabModel;
    public string name;
    public float price;
    public string linkProduct;
    public List<string> colors;
    public List<Sprite> images;

    // TODO
    // Image for 300x150 = Show Content Start
    // Image for 200x250 = Show Medium icon
}