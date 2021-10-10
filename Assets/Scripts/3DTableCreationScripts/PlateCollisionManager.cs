using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCollisionManager : MonoBehaviour
{
     bool isInTableField = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name);
        if((collision.gameObject.tag == "TableImage"))
        {
       // isInTableField = true;
        SendMessage("LocateInTable");
        SendMessage("SetPlateInTable", true);
            print("Table border start at: "+gameObject.transform.position);
        }

        if(collision.gameObject.tag == "PlateImage")
        {
            GameObject otherPlateImage = collision.gameObject;
            SendMessage("LocateAboveOtherPlate", otherPlateImage);
            SendMessage("SetPlateAboveOtherPlate", otherPlateImage);
            //print(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TableImage")
        {
            SendMessage("LocateOutsideOfTable");
            SendMessage("SetPlateDoesNotAboveOtherPlate");
            print("Table end start at: " + gameObject.transform.position);
            // isInTableField = false;

        }

        if(collision.gameObject.tag == "PlateImage")
        {
            SendMessage("DontLocateAboveOtherObject");
            SendMessage("SetPlateAboveOtherPlate", false);
            //collision.gameObject.GetComponent<SceneConverter2Dto3D>().GetPlateType();
        }
    }

}
