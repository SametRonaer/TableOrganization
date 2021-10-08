using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartItemModel
{
    public string productName;
    public int id;
    public int quantity;
    public float amount;

    public CartItemModel(string productName, int id, int quantity, float amount)
    {
        this.productName = productName;
        this.id = id;
        this.quantity = quantity;
        this.amount = amount;
    }
}
