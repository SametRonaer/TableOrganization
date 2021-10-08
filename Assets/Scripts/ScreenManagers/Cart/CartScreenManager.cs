using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartScreenManager : MonoBehaviour
{
    [SerializeField]
    GameObject services;
    [SerializeField]
    GameObject firstTile;
    [SerializeField]
    Transform tileList;
    int tileOrder = 0;
    int tileAmount = 2;
    float tileHeight = 400;
    // Start is called before the first frame update
    void Start()
    {

        //services.GetComponent<CartSevice>().AddProductToCart(17);
        float totalPrice = services.GetComponent<CartSevice>().GetTotalPrice();
        print("Total price is: " + totalPrice);
        while (tileOrder< tileAmount)
        {
            GameObject newTile = GetProductTile(tileOrder);
            tileOrder++;
        }
    }

    private GameObject GetProductTile(int productOrder)
    {
        float tileYCoordinate = tileHeight * (productOrder + 1);
        float tileXCoordinate = firstTile.transform.position.x;
        Vector3 tilePosition = new Vector3(tileXCoordinate, tileYCoordinate, 0);
        GameObject newTile = Instantiate(firstTile,tilePosition, firstTile.transform.rotation);
        newTile.transform.parent = firstTile.transform.parent;
        newTile.transform.localScale = firstTile.transform.localScale;
        return newTile;
    }

}
