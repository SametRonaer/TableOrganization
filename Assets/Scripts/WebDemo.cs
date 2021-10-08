using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class WebDemo : MonoBehaviour
{
    static string imageUrl = "https://dl.polyhaven.org/file/ph-assets/Textures/jpg/2k/weathered_brown_planks/weathered_brown_planks_diff_2k.jpg";
    Texture2D _texture;
    [SerializeField] Material _material;

     void Start()
    {
        // A correct website page.
        // StartCoroutine(GetRequest(imageUrl));


        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
        StartCoroutine(DownloadImage(imageUrl));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //webRequest.SetRequestHeader("content-type", "application/json");
            //webRequest.SetRequestHeader("authorization", "Bearer teryry567 ");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    //webRequest.
                    break;
            }
        }
    }


    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);

        }
        else
        {
            _material.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            print("downloaded");
        }
    }

}
