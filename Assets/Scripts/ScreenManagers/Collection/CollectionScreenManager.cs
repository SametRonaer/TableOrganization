using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionScreenManager : MonoBehaviour
{
    [SerializeField] GameObject services;
    [SerializeField] GameObject productCell;
    List<ProductModel> productList;

    int cellHeightGap = 650;
    int cellWidhtGap = 520;
    int cellOrder = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetCollectionProducts();
        GetProductCells();
    }

    private void GetCollectionProducts()
    {
        productList = services.GetComponent<CollectionService>().GetCollectionProducts("something");
        print("Product List: "+ productList.Count);
    }

    GameObject GetProductCells()
    {
        int order = 0;
        while (order < productList.Count)
        {
            GameObject newProductCell = Instantiate(productCell, GetNewPositionOfCell(), productCell.transform.rotation);
            newProductCell.transform.parent = productCell.transform.parent;
            newProductCell.transform.localScale = productCell.transform.localScale;
            order++;
        }
       
        print(productCell.GetComponent<Image>().sprite);
       
        return productCell;
    }

    private Vector3 GetNewPositionOfCell()
    {
        float newX = productCell.transform.position.x;
        float newY = productCell.transform.position.y - cellHeightGap;
        if ((cellOrder % 2) != 0)
        {
        newX += cellWidhtGap;

        }
       
        Vector3 newPosition = new Vector3(newX, newY, 0);
        
        cellOrder++;
        return newPosition;
    }
}
