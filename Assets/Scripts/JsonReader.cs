using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JsonReader : MonoBehaviour
{

    public TextAsset textJson;

    private int currentPage = 1;

   [System.Serializable]  private class Store
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
   [System.Serializable] private class StoreList
    {
        public Store[] store;
    }

    private StoreList storeList = new StoreList();


    [System.Serializable] public class StoreText
    {
        public TextMeshProUGUI playerNameText;
        public TextMeshProUGUI sellPictureText;
        public TextMeshProUGUI playerPictureText;
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
        
        for (int firstItemToShow = lastItemToShow - 6; firstItemToShow < lastItemToShow; firstItemToShow++)
        {
            storeText.text[firstItemToShow].playerNameText.text = storeList.store[firstItemToShow].playerName;
            storeText.text[firstItemToShow].sellPictureText.text = storeList.store[firstItemToShow].sellPicture;
            storeText.text[firstItemToShow].playerPictureText.text = storeList.store[firstItemToShow].playerPicture;
            storeText.text[firstItemToShow].numberOfItemsText.text = storeList.store[firstItemToShow].numberOfItems;
            storeText.text[firstItemToShow].sellNameText.text = storeList.store[firstItemToShow].sellName;
            storeText.text[firstItemToShow].priceText.text = storeList.store[firstItemToShow].price;
            storeText.text[firstItemToShow].levelText.text = storeList.store[firstItemToShow].level;     
        }
    }


    private void Start()
    {
        storeList = JsonUtility.FromJson<StoreList>(textJson.text); // readind Json data
        ShowItems(currentPage);     // showing first page
    }

   
    private void  Update()
    {
  
       
    }
}
