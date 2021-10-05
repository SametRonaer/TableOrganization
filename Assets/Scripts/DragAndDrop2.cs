using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop2 : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    GameObject plate;
    [SerializeField]
    GameObject table;

    float panelHeightRatio;
    float panelHeight;
    float screenHeight = 1600;
    float screenWidth = 900;

    float startX;
    float startZ;
    float tableHeight;
    float tableWidth;

    Vector2 plateInitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        plateInitialPosition = GetComponent<RectTransform>().position;
        panelHeightRatio = panel.GetComponent<RectTransform>().localScale.y;
        panelHeight = screenHeight * panelHeightRatio;
        print(panelHeight);

        tableHeight = table.transform.localScale.z;
        tableWidth = table.transform.localScale.x;

        startX = table.transform.position.x - (tableWidth / 2);
        startZ = table.transform.position.z - (tableHeight / 2);
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
        if(Input.mousePosition.y > (screenHeight- panelHeight))
        {
            //print(Input.mousePosition.y);
            
            //}


        }

    }

    public void EndDrag()
    {
        LocatePlates(Input.mousePosition);
        GetComponent<RectTransform>().position = plateInitialPosition;
    }


    float GetNormalizedY(Vector2 location)
    {
        float outOfPanelFieldHeight = screenHeight - panelHeight;
        float normalizedY = (location.y - outOfPanelFieldHeight )/ panelHeight;
        print(normalizedY);
        return normalizedY;
    }



    public void LocatePlates(Vector2 location)
    {
        print(location);
        float normalizedX = location.x / screenWidth;
        float normalizedY = GetNormalizedY(location);

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
