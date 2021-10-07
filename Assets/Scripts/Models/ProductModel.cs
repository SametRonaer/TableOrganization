using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductModel
{
    public string name;
    public string category;
    public float price;
    public string id;
    public string imageUrl;

    public ProductModel(string productId, string productName, string productCategory, string productImageUrl, float productPrice)
    {
        this.id = productId;
        this.name = productName;
        this.category = productCategory;
        this.imageUrl = productImageUrl;
        this.price = productPrice;
    }
}
