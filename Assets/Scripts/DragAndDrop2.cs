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

    public GameObject newPlate;
    float panelHeightRatio;
    float panelHeight;
    float screenHeight = 1600;
    float screenWidth = 900;

    float startX;
    float startZ;
    float tableHeight;
    float tableWidth;
    float plateHeight = 0.06f;

    bool plateUp = false;
    GameObject otherPlate;
    GameObject collidedImage;

    Vector2 plateInitialPosition;

   

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
            collidedImage = collision.gameObject;
            print("trigger exit" + collision.name);
            print(collision.gameObject.GetComponent<DragAndDrop2>().newPlate.name);
            otherPlate = collision.gameObject.GetComponent<DragAndDrop2>().newPlate;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        otherPlate = null;
        collidedImage = null;
    }

    public void BeginDrag()
    {
        plateInitialPosition = transform.position;
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
            if(collidedImage != null)
            {
            collidedImage.GetComponent<CapsuleCollider2D>().enabled = false;
                //print("Collided image mesh: "+ collidedImage.GetComponent<DragAndDrop2>().newPlate);
            }
            else
            {
                print("There is no collided object");
            }
        
        }
        transform.parent = initialParentObject.transform;
        GetComponent<RectTransform>().position = plateInitialPosition;
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
            newX = otherPlate.transform.position.x;
            newZ = otherPlate.transform.position.z;
            tableY += plateHeight;
            print("other object available");
        }
        newPlate = Instantiate(plate, new Vector3(newX, tableY, newZ), plate.GetComponent<Transform>().rotation);
        print("Plates located");
    }

    float GetNormalizedY(Vector2 location)
    {
        float outOfPanelFieldHeight = screenHeight - panelHeight;
        float normalizedY =  ((location.y - outOfPanelFieldHeight )/ panelHeight);
        print("Notmalization");
        normalizedY = normalizedY -  1;
        normalizedY = Mathf.Abs(normalizedY);
        print(normalizedY);
        return normalizedY;
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
