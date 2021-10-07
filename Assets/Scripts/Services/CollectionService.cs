using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class CollectionService : MonoBehaviour
{
    string carouselImagesUrl = "http://ceyizinisec-lazarus.production.cmosteknoloji.com/api/CarouselImages";
    string fakeApi = "https://jsonplaceholder.typicode.com/todos/1";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetCarouselImages());
    }


    IEnumerator GetCarouselImages()
    {

        UnityWebRequest www = UnityWebRequest.Get(carouselImagesUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
           // Debug.Log(www.downloadHandler.data);
            byte[] results = www.downloadHandler.data;

            StringBuilder sb = new StringBuilder();
            foreach (System.Collections.Generic.KeyValuePair<string, string> dict in www.GetResponseHeaders())
            {
                sb.Append(dict.Key).Append(": \t[").Append(dict.Value).Append("]\n");
            }
            // print("Headers "+sb);
            // Debug.Log(www.downloadHandler.text);
            //ImageModel imageModel = JsonUtility.FromJson<ImageModel>(www.downloadHandler.text);
            //print(imageModel.imagePortrait);
            string responseString = www.downloadHandler.text;
            print(responseString);
           // List<User> userList = JsonConvert.DeserializeObject<List<ImageModel>>(json);
           // JsonCon
           // print(myObject);
            

            //Overwrite the values in the existing class instance "playerInstance". Less memory Allocation
            //JsonUtility.FromJsonOverwrite(jsonString, playerInstance);
            //Debug.Log(playerInstance.playerLoc);
        }
    }

}


