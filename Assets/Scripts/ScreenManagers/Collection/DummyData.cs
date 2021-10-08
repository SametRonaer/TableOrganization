using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyData : MonoBehaviour
{
   public static string dummyUserName = "samet11@hotmail.com";
   public static string dummyUserPassword = "Samet.1234";
   public static string dummyUserToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFTWFpbCI6InNhbWV0MTFAaG90bWFpbC5jb20iLCJGaXJzdE5hbWUiOiJTYW1ldCIsIkxhc3ROYW1lIjoiUm9uYWVyIiwiRnVsbE5hbWUiOiJTYW1ldCBSb25hZXIiLCJJZCI6IjY5IiwiUGhvbmVOdW1iZXIiOiIwNTA3ODU1MzQ1NiIsIm5iZiI6MTYzMzY5MjI2OSwiZXhwIjoxNjMzNzc4NjY5LCJpYXQiOjE2MzM2OTIyNjl9.4aoddmMPczU1VqroA2EhYX3XFhS8jE3cUDD-WG15Xnc";
   static ProductModel product01 = new ProductModel("Tabak01", "Ataturk", "Plate", "CurvePlate", 15.6f);
   static ProductModel product02 = new ProductModel("Kase", "Ciragan", "CurvePlate", "CurvePlate", 32.3f);
   static ProductModel product03 = new ProductModel("Tabak02", "Ciragan", "Plate", "CurvePlate", 10.1f);

    public static List<ProductModel> productList;
    public static List<CartItemModel> cartItemList;

    public static List<ProductModel> GetProductList()
    {
        productList = new List<ProductModel>();
        productList.Add(product01);
        productList.Add(product02);
        productList.Add(product03);
        return productList;
    }


    public static List<ProductModel> GetCartItemList()
    {
        productList = new List<ProductModel>();
        productList.Add(product01);
        productList.Add(product02);
        productList.Add(product03);
        return productList;
    }
}
