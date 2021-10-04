using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutPlates : MonoBehaviour
{
    [SerializeField]
    GameObject plate;
    [SerializeField]
    GameObject tableCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //float x = plate.transform.position.x;
            //float z = plate.transform.position.z;
            print(tableCollider.GetComponent<Transform>().localScale);
            float x = tableCollider.transform.position.x;
            float y = tableCollider.transform.position.y;
            float z = tableCollider.transform.position.z-7;
            plate.GetComponent<Transform>().position = new Vector3(x, y, z);        
        }
    }
}
