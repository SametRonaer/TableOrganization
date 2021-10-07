using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionScreenManager : MonoBehaviour
{
    [SerializeField] GameObject services;

    // Start is called before the first frame update
    void Start()
    {
        GetCollectionProducts();
    }

    private void GetCollectionProducts()
    {
       // services.GetComponent<CollectionService>().
    }

}
