using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CollectionModel 
{
    public String name;
    public String pageImageUrl;
    public ProductModel[] products = new ProductModel[15];
}
