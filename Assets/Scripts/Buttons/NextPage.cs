
using UnityEngine;
using UnityEngine.UI;

public class NextPage : MonoBehaviour
{
    public void ShowNextPage()
    {
        EventManager.current.ChangePageTrigger(1);
    }
}
