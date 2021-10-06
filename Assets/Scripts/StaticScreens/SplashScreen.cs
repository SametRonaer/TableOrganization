using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] GameObject splashScreen;
    [SerializeField] GameObject loginScreen;
    // Start is called before the first frame update
    void Start()
    {
        print(transform.parent.childCount);
        //loginScreen.SetActive(true);
        //splashScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NavigateNextPage()
    {
        loginScreen.SetActive(true);
        splashScreen.SetActive(false);
    }
}
