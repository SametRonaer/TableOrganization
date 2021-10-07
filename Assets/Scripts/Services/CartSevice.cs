using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSevice : MonoBehaviour
{
    float totalPrice = 112.6f;
    List<ProductModel> productList = new List<ProductModel>();
    public float GetTotalPrice()
    {
        return totalPrice;
    }

    public void AddProductToCart(ProductModel product)
    {
        productList.Add(product);
        totalPrice += product.price;
        print(totalPrice);
        foreach (ProductModel productItem in productList)
        {
            print(productItem.name);
        }
        return;
    }
}
