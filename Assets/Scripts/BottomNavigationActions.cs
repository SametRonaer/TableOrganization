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
    [SerializeField]
    GameObject iconScreen;
  
    public void Pressed()
    {
        int childCount = transform.parent.childCount;
        for (int i = 0; i< childCount; i++)
        {
            if(gameObject.tag != transform.parent.GetChild(i).gameObject.tag)
            {
            transform.parent.GetChild(i).gameObject.GetComponent<BottomNavigationActions>().SetPassive();
            transform.parent.GetChild(i).gameObject.GetComponent<BottomNavigationActions>().CloseScreen();
            }
            else
            {
                SetActive();
                OpenScreen();
            }
        }
    }

    public void SetPassive()
    {
        transform.GetChild(0).gameObject.GetComponent<Image>().sprite = passiveIcon;

    }

     void SetActive()
    {
        transform.GetChild(0).gameObject.GetComponent<Image>().sprite = activeIcon;

    }

    public void CloseScreen()
    {
        iconScreen.SetActive(false);
    }

    void OpenScreen()
    {
        iconScreen.SetActive(true);
    }
}
