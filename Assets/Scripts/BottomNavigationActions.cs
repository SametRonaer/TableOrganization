using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomNavigationActions : MonoBehaviour
{
    [SerializeField]
    Sprite activeIcon;
    [SerializeField]
    Sprite passiveIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        int childCount = transform.parent.childCount;
        for (int i = 0; i< childCount; i++)
        {
            if(gameObject.tag != transform.parent.GetChild(i).gameObject.tag)
            {
            print(transform.parent.GetChild(i).gameObject.tag);
            transform.parent.GetChild(i).gameObject.GetComponent<BottomNavigationActions>().setPassive();
            }
            else
            {
                print(gameObject.tag + " is active");
                setActive();
            }
        }
       // print(gameObject.tag);
    }

    public void setPassive()
    {
        transform.GetChild(0).gameObject.GetComponent<Image>().sprite = passiveIcon;

    }

     void setActive()
    {
        transform.GetChild(0).gameObject.GetComponent<Image>().sprite = activeIcon;

    }
}
