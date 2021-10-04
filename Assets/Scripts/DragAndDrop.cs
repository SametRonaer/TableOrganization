using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    GameObject table;
    [SerializeField]
    GameObject plate;
    //Vector3 mousePosition;
    float screenHeight = 1600;
    float screenWidth = 900;

    float tableHeight;
    float tableWidth;

    float startX;
    float startZ;
    // Start is called before the first frame update
    void Start()
    {
        tableHeight = table.transform.localScale.z;
        tableWidth = table.transform.localScale.x;

        startX = table.transform.position.x - (tableWidth/2);
        startZ = table.transform.position.z - (tableHeight/2);
        float tableY = table.GetComponent<Transform>().position.y;
        plate.GetComponent<Transform>().position = new Vector3(startX, tableY, startZ);
    }

    // Update is called once per frame
    void Update()
    {
    }


   public void DragObjects()
    {
        GetComponent<Transform>().position = Input.mousePosition;
        //print(Input.mousePosition);
       
    }

    public void LocatePlates()
    {
        float normalizedX = Input.mousePosition.x / screenWidth;
        float normalizedY = Input.mousePosition.y / screenHeight;

        float plateNewZ = normalizedY * tableHeight;
        float plateNewX = normalizedX * tableWidth;
        print("NormalizedX: " + normalizedX + " NormalizedY: " + normalizedY);

        float tableY = table.GetComponent<Transform>().position.y;
        float newX = getNewXCoordinate(normalizedX);
        float newZ = getNewZCoordinate(normalizedY);
        //plate.GetComponent<Transform>().position = new Vector3(newX, tableY, newZ);
        Instantiate(plate, new Vector3(newX, tableY, newZ), Quaternion.identity);
        print("Plates located");
    }

    float getNewXCoordinate(float normalizedX)
    {
       float newX = startX + (normalizedX * tableWidth);
        return newX;
    }

    float getNewZCoordinate(float normalizedY)
    {
        float newZ = startZ + normalizedY * tableHeight;
        return newZ;
    } 

}
