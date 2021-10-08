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
    List<CartItemModel> cartItems;
    // Start is called before the first frame update
    void Start()
    {
        cartItems = CartSevice.GetProductsInCart();
        foreach(CartItemModel c in cartItems)
        {
            AddProductTile(c, tileOrder);
            tileOrder++;
            print(c.productName);
        }
        //services.GetComponent<CartSevice>().AddProductToCart(17);
        //float totalPrice = services.GetComponent<CartSevice>().GetTotalPrice();
       
        //print("Total price is: " + totalPrice);
    }

    private GameObject AddProductTile(CartItemModel cartItem, int productOrder)
    {
        float tileYCoordinate = tileHeight * (productOrder + 1);
        float tileXCoordinate = firstTile.transform.position.x;
        Vector3 tilePosition = new Vector3(tileXCoordinate, tileYCoordinate, 0);
        GameObject newTile = Instantiate(firstTile,tilePosition, firstTile.transform.rotation);
        newTile.transform.localScale = firstTile.transform.localScale;
        //newTile.transform.parent = tileList;
        newTile.transform.parent = firstTile.transform.parent;
        newTile.GetComponent<ListTileManager>().SetProductName(cartItem.productName);
        newTile.GetComponent<ListTileManager>().SetProductQuantity(cartItem.quantity);
        newTile.GetComponent<ListTileManager>().SetProductPrice(cartItem.amount);
        return newTile;
    }

}
