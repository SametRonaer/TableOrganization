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
    [SerializeField]
    GameObject puttedPlate;
    [SerializeField]
    GameObject canvas;

    GameObject initialParentObject;

    GameObject newPlate;
    float panelHeightRatio;
    float panelHeight;
    float screenHeight = 1600;
    float screenWidth = 900;

    float startX;
    float startZ;
    float tableHeight;
    float tableWidth;

    bool plateUp = false;
    GameObject otherPlate;

    Vector2 plateInitialPosition;

    public GameObject get3DPlate()
    {
        return newPlate;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialParentObject = gameObject.transform.parent.gameObject;
        plateInitialPosition = GetComponent<RectTransform>().position;
        panelHeightRatio = panel.GetComponent<RectTransform>().localScale.y;
        panelHeight = screenHeight * panelHeightRatio;
        print(panelHeight);

        tableHeight = table.transform.localScale.z;
        tableWidth = table.transform.localScale.x;

        startX = table.transform.position.x - (tableWidth / 2);
        startZ = table.transform.position.z - (tableHeight / 2);
        float tableY = table.GetComponent<Transform>().position.y;
       // plate.GetComponent<Transform>().position = new Vector3(startX, tableY, startZ);
    }

    

    public void DragObjects()
    {
        transform.parent = canvas.transform;
        GetComponent<Transform>().position = Input.mousePosition;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<DragAndDrop2>().isActiveAndEnabled)
        {
            print("trigger exit" + collision.name);
            print(collision.gameObject.GetComponent<DragAndDrop2>().get3DPlate().name);
            plateUp = true;
            otherPlate = collision.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GetComponent<DragAndDrop2>().isActiveAndEnabled)
        {
            //print("trigger exit" + collision.name);
        plateUp = false;
        }
    }

    public void EndDrag()
    {
      

        GameObject newPlateImage;
        if (Input.mousePosition.y > (screenHeight - panelHeight))
        {
        LocatePlates(Input.mousePosition);
         newPlateImage =  Instantiate(this.gameObject, transform.position, transform.rotation);
            newPlateImage.GetComponent<RectTransform>().parent = GetComponent<RectTransform>().parent.gameObject.transform.GetChild(0);
        newPlateImage.GetComponent<DragAndDrop2>().enabled = false;
           
        
        }
        transform.parent = initialParentObject.transform;
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
        float newX = getNewXCoordinate(normalizedY);
        float newZ = getNewZCoordinate(normalizedX);
        if (otherPlate != null)
        {
           tableY += 5f;
            print("other object available");
           // newX = otherPlate.GetComponent<Transform>().position.x;
            //newZ = otherPlate.GetComponent<Transform>().position.z;
        }
        //plate.GetComponent<Transform>().position = new Vector3(newX, tableY, newZ);
       newPlate = Instantiate(plate, new Vector3(newX, tableY, newZ), plate.GetComponent<Transform>().rotation);
       // newPlate.GetComponent<DragAndDrop2>().enabled = false;
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
