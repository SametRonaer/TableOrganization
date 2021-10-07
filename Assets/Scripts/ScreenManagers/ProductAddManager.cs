using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductAddManager : MonoBehaviour
{
   ProductModel productModel;
    [SerializeField] GameObject services;
    public void AddToCart()
    {
        productModel = new ProductModel("tabak02", "Ataturk", "Duz Tabak", "www.tabak.com", 14.6f);
        services.GetComponent<CartSevice>().AddProductToCart(productModel);
        print("Added to cart");
    }
}
