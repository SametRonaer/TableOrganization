using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartScreenManager : MonoBehaviour
{
    [SerializeField]
    GameObject services;
    // Start is called before the first frame update
    void Start()
    {
        services.GetComponent<CartSevice>().AddProductToCart(17);
        float totalPrice = services.GetComponent<CartSevice>().GetTotalPrice();
        print("Total price is: " + totalPrice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
