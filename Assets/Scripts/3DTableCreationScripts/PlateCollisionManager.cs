using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCollisionManager : MonoBehaviour
{
     bool isInTableField = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if((collision.gameObject.tag == "TableImage"))
        {
       // isInTableField = true;
        SendMessage("LocateInTable");
        }

        if(collision.gameObject.tag == "PlateImage")
        {
            GameObject otherPlateImage = collision.gameObject;
            SendMessage("LocateAboveOtherPlate", otherPlateImage);
            print(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TableImage")
        {
            SendMessage("LocateOutsideOfTable");
           // isInTableField = false;

        }

        if(collision.gameObject.tag == "PlateImage")
        {
            SendMessage("DontLocateAboveOtherObject");
        }
    }

}
