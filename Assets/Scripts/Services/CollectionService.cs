//using Newtonsoft.Json;
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
            Debug.Log("complete!");
          //  byte[] results = www.downloadHandler.data;
          //  StringBuilder sb = new StringBuilder();
          //  foreach (System.Collections.Generic.KeyValuePair<string, string> dict in www.GetResponseHeaders())
          //  {
           //     sb.Append(dict.Key).Append(": \t[").Append(dict.Value).Append("]\n");
          //  }
            string responseString = www.downloadHandler.text;
            print(responseString);
            //var images = JsonConvert.DeserializeObject<List<ImageModel>>(responseString);
        }
    }


    public List<ProductModel> GetCollectionProducts(string id)
    {

        //productModel = new ProductModel();
        //productModel.id = "tabak02";
        //productModel.name = "Ataturk";
        //productModel.category = "Duz Tabak";
        //productModel.imageUrl = "www.tabak.com";
        //productModel.price = 17.40f;

        List<ProductModel> collectionProducts = DummyData.GetProductList();
        //print("Dummy list: " + DummyData.GetProductList().Count);
        return collectionProducts;
       // collectionProducts.Add(new ProductModel());

        //List<Part> parts = new List<Part>();

        //// Add parts to the list.
        //parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
        //parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
    }

}


