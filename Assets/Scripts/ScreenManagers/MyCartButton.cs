using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyCartButton : MonoBehaviour
{
    [SerializeField] GameObject services;
    [SerializeField] GameObject priceText;
    float totalPrice;

    private void Start()
    {
    totalPrice =  services.GetComponent<CartSevice>().GetTotalPrice();
        priceText.GetComponent<Text>().text = totalPrice.ToString();
    }


}
