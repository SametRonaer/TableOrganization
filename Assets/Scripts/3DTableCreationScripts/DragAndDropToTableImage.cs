using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropToTableImage : MonoBehaviour
{
    Vector2 plateInitialPosition;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject scrollView;
    bool isInTableArea = false;
    bool isAboveOtherPlate = false;
    bool isMove = false;
    bool isFirstInstance = true;
    GameObject belowPlateImage;

    private void Start()
    {
        plateInitialPosition = GetComponent<RectTransform>().position;
        if(transform.parent.gameObject != scrollView)
        {
            isFirstInstance = false;
        }
        else{
            isFirstInstance = true;
            print("it is first instance");
        }
    }

    public void BeginDrag()
    { 
        print("Drag happen");
        isMove = true;
        transform.parent = canvas.transform;
    }

    public void DragObjects()
    {
        transform.parent = canvas.transform;
        GetComponent<Transform>().position = Input.mousePosition;

    }

    public void EndDrag()
    {
        if (isInTableArea)
        {
            if (isAboveOtherPlate)
            {
                print("There is other plate");
                print(belowPlateImage);
                if (isFirstInstance)
                {
                    isFirstInstance = false;
                    GameObject newPlate = Instantiate(gameObject, belowPlateImage.transform.position, belowPlateImage.transform.rotation);
                    newPlate.transform.parent = canvas.transform;
                    newPlate.transform.localScale = transform.localScale;
                    isFirstInstance = true;
                    ResetSettings();
                }

            }
            else
            {
                if (isFirstInstance)
                {
                    isFirstInstance = false;
                    GameObject newPlate = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
                    newPlate.transform.parent = canvas.transform;
                    newPlate.transform.localScale = transform.localScale;
                    print("No other plate but in table");
                    isFirstInstance = true;
                    ResetSettings();
                }
                else
                {

                }
            }

            isMove = false;
            
        }
        else
        {
            if (isFirstInstance)
            {
            ResetSettings();
            }
            else
            {
                Destroy(gameObject);
            }
           // GetComponent<RectTransform>().position = plateInitialPosition;
           // print("Outside table");
           // isMove = false;
           //transform.parent = scrollView.transform;
        }
    }

    public void LocateInTable()
    {
        isInTableArea = true;
        //print("Table locater");
    }

    public void LocateOutsideOfTable()
    {
        isInTableArea = false;
    }

    public void LocateAboveOtherPlate(GameObject otherPlateImage)
    {
        if (isMove)
        {
            print("Other plate is: "+ otherPlateImage.name);
            belowPlateImage = otherPlateImage;
            //Instantiate(otherPlateImage, otherPlateImageLocation, otherPlateImage.transform.rotation);
            print(otherPlateImage.transform.localPosition);
            print(gameObject.transform.localPosition);
            isAboveOtherPlate = true;
        }
    }

    public void DontLocateAboveOtherObject()
    {
        isAboveOtherPlate = false;
    }

    public void ResetSettings()
    {
         isInTableArea = false;
         isAboveOtherPlate = false;
         isMove = false;
         belowPlateImage = null;
        transform.parent = scrollView.transform;
        transform.position = plateInitialPosition;
    }
}
