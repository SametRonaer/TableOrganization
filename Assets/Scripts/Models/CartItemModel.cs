using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartItemModel
{
    public string productName;
    public string productCode;
    public int id;
    public int quantity;
    public float amount;

    public CartItemModel(string productName, string productCode, int id, int quantity, float amount)
    {
        this.productName = productName;
        this.productCode = productCode;
        this.id = id;
        this.quantity = quantity;
        this.amount = amount;
    }
}
