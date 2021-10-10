using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConverter2Dto3D : MonoBehaviour
{
    [SerializeField]
    GameObject plate;
    [SerializeField]
    GameObject canvas;
    //public float baseHeightRectangleTable = 572f;
    //public float baseWidthRectangleTable = 900f;
    
    public float baseStartPointRectangleTable = 924;
    public float baseEndPointRectangleTable = 1496;

    //float baseScreenHeight = 1600;
    float baseScreenWidth = 900;
    
    float canvasScaleFactor;
   
    float currentYStartPoint;
    float currentYEndPoint;
    //float currentScreenHeight;
    //float currentScreenWidth;
    float currentTableWidth;

    bool plateInTheTable = false;
    bool plateAboveOtherPlate = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasScaleFactor = canvas.GetComponent<Canvas>().scaleFactor;
        currentYStartPoint = baseStartPointRectangleTable * canvasScaleFactor; 
        currentYEndPoint = baseEndPointRectangleTable * canvasScaleFactor;
        currentTableWidth = currentYEndPoint - currentYStartPoint;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            print(GetNormalizedYValue());
            print(GetNormalizedXValue());
        }
    }

    //public void GetPlateType()
    //{
    //    print(plate.tag);
    //    print(plate.name);
    //}

    //public void GetPlatePositionInTable(Vector2 platePosition)
    //{
    //    print("Plate position is: " + platePosition);
    //}

    public void SetPlateInTable(bool isInTable)
    {
        plateInTheTable = isInTable;
        print("isInTable: " + isInTable);
    }

    public void SetPlateAboveOtherPlate(GameObject otherPlateImage)
    {
        plateAboveOtherPlate = true;
        print("Plate above other plate: " + true);
        print("othert plate is: " + otherPlateImage.name);
    }

    public void SetPlateDoesNotAboveOtherPlate()
    {
        plateAboveOtherPlate = false;
        print("Plate above other plate: " + false);
    }

    Vector3 GetPlateCoordinatesIn3D()
    {
        return new Vector3(0, 0, 0);
    }

    float GetNormalizedYValue()
    {
        return (Input.mousePosition.y - currentYStartPoint)/ currentTableWidth;
    }

    float GetNormalizedXValue()
    {
        return Input.mousePosition.x / (baseScreenWidth * canvasScaleFactor);
    }
}
