using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListTileManager : MonoBehaviour
{
    [SerializeField]Text productAmountText;
    [SerializeField]Text productColorText;
    [SerializeField]Text productNameText;
    [SerializeField]Text productPriceText;
    [SerializeField]Text selectedQuantityText;

    float productPrice = 17.5f;
    int productQuantity = 1;
    string productName = "Tabak";
    string productColor = "Beyaz";
    string productAmount = "5 Adet";



    // Start is called before the first frame update
    void Start()
    {
        SetProductConfiguration();
    }

    private void SetProductConfiguration()
    {
        productAmountText.text = productAmount;
        productColorText.text = productColor;
        productNameText.text = productName;
        productPriceText.text = productPrice.ToString();
        selectedQuantityText.text = productQuantity.ToString();
    }


    public void IncreaseAmount()
    {
        productQuantity++;
        SetProductConfiguration();
    }
    
    public void DecreaseAmount()
    {
        if(productQuantity != 1)
        {
            productQuantity--;
            SetProductConfiguration();
        }
    }

    public void DeleteProduct()
    {
        print("Deleted");
    }
}
