using TMPro;
using UnityEngine;

using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class JsonReader : MonoBehaviour
{

    public TextAsset textJson;

    private int currentPage = 1;
    private int maxPage = 0;

   [Serializable]  private class Store
    {
        public string playerName;
        public string sellPicture;
        public string playerPicture;
        public string numberOfItems;
        public string sellName;
        public string price;
        public string level;
    }
                                                             // stores data from JSON
   [Serializable] private class StoreList
    {
        public Store[] store;
    }

    private StoreList storeList = new StoreList();


    [Serializable] public class StoreText
    {
        public TextMeshProUGUI playerNameText;
        public Image sellPictureImage;
        public RawImage playerPictureImage;
        public TextMeshProUGUI numberOfItemsText;
        public TextMeshProUGUI sellNameText;
        public TextMeshProUGUI priceText;
        public TextMeshProUGUI levelText;
    }
                                                       //Handle Text in the Store scene
 
     [System.Serializable] public class TextList
    {
        public StoreText[] text;
    }
                                    
    public TextList storeText = new TextList();

    





    public void ShowItems(int currentPage)    // taking info from Store class to TMP and showing it
    {
        int lastItemToShow = currentPage * 6;
        int textToShow = 0;

        
        for (int firstItemToShow = lastItemToShow - 6; firstItemToShow < lastItemToShow; firstItemToShow++)
        {
    
            storeText.text[textToShow].playerNameText.text = storeList.store[firstItemToShow].playerName;
            //storeText.text[textToShow].playerPictureImage.text = storeList.store[firstItemToShow].playerPicture;
            storeText.text[textToShow].numberOfItemsText.text = storeList.store[firstItemToShow].numberOfItems;
            storeText.text[textToShow].sellNameText.text = storeList.store[firstItemToShow].sellName;
            storeText.text[textToShow].priceText.text = storeList.store[firstItemToShow].price;
            storeText.text[textToShow].levelText.text = storeList.store[firstItemToShow].level;


            storeText.text[textToShow].sellPictureImage.sprite = Resources.Load<Sprite>(storeList.store[firstItemToShow].sellPicture);


            StartCoroutine (DownloadImage(textToShow, firstItemToShow));
            
            textToShow++;
        }
    }

    private IEnumerator DownloadImage(int picIndex, int urlIndex)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(storeList.store[urlIndex].playerPicture);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)   // can not download 
        {
            Debug.Log(request.error);
        }
        else
        {
            storeText.text[picIndex].playerPictureImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }

           
    }




    private void FindLastPage(int numberOfItems)
    {
        if (numberOfItems / 6 > 16.0) // if there is more than 100 items to sell
        {
            maxPage = 16;
        }
        else
        {
            maxPage = numberOfItems / 6;
        }
       
        
    }

    private void CheckPages()
    {
        if (maxPage > 0)
        {
            ShowItems(currentPage);  // showing first page
        }
        else
        {
            Debug.Log("No Items in store");
        }
    }

    public void ChangePage(int change)
    {
        if(currentPage + change > maxPage)
        {
            Debug.Log("LastPage!");
        }
        else if (currentPage + change < 1)
        {
            Debug.Log("FirstPage");
        }
        else
        {
            currentPage += change;
            ShowItems(currentPage);
        }
        Debug.Log(currentPage+ "/"+ maxPage);
    }




    private void Start()
    {
        storeList = JsonUtility.FromJson<StoreList>(textJson.text); // readind Json data


        FindLastPage(storeList.store.Length);
        CheckPages();

        EventManager.current.ChangePageEvent += ChangePage;
    }

   




    private void  Update()
    {
  
       
    }
}
