using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyData : MonoBehaviour
{
   static ProductModel product01 = new ProductModel("Tabak01", "Ataturk", "Plate", "CurvePlate", 15.6f);
   static ProductModel product02 = new ProductModel("Kase", "Ciragan", "CurvePlate", "CurvePlate", 32.3f);
   static ProductModel product03 = new ProductModel("Tabak02", "Ciragan", "Plate", "CurvePlate", 10.1f);

    public static List<ProductModel> productList;

    public static List<ProductModel> GetProductList()
    {
        productList = new List<ProductModel>();
        productList.Add(product01);
        productList.Add(product02);
        productList.Add(product03);
        return productList;
    }
}
