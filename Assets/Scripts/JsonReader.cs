using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JsonReader : MonoBehaviour
{

    public TextAsset textJson;

    public int currentPage = 1;

   [System.Serializable]  public class Store
    {
        public string playerName;
        public string sellPicture;
        public string playerPicture;
        public string numberOfItems;
        public string sellName;
        public string price;
        public string level;
    }
    
   [System.Serializable] public class StoreList
    {
        public Store[] store;
    }

    public StoreList storeList = new StoreList();


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

 
     [System.Serializable] public class TextList
    {
        public StoreText[] text;
    }

    public TextList storeText = new TextList();

    





    public void ShowItems(int currentPage)
    {
        int lastItemToShow = currentPage * 6;
 
        for (int firstItemToShow = lastItemToShow - 6; firstItemToShow < lastItemToShow; firstItemToShow++)
        {
            Debug.Log("123");
            storeText.text[firstItemToShow].playerNameText.text = storeList.store[firstItemToShow].playerName;
            storeText.text[firstItemToShow].sellPictureText.text = storeList.store[firstItemToShow].sellPicture;
            storeText.text[firstItemToShow].playerPictureText.text = storeList.store[firstItemToShow].playerPicture;
            storeText.text[firstItemToShow].numberOfItemsText.text = storeList.store[firstItemToShow].numberOfItems;
            storeText.text[firstItemToShow].sellNameText.text = storeList.store[firstItemToShow].sellName;
            storeText.text[firstItemToShow].priceText.text = storeList.store[firstItemToShow].price;
            storeText.text[firstItemToShow].levelText.text = storeList.store[firstItemToShow].level;

            
        }
    }


    void Start()
    {
        storeList = JsonUtility.FromJson<StoreList>(textJson.text);
        ShowItems(currentPage);
    }

   
    void Update()
    {
  
       // Debug.Log(storeList.store[1].sellName);
    }
}
