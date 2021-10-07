using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSevice : MonoBehaviour
{
    float totalPrice = 112.6f;

    public float GetTotalPrice()
    {
        return totalPrice;
    }

    public void AddProductToCart(int productId)
    {
        totalPrice += 5.5f;
        return;
    }
}
