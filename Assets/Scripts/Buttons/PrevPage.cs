
using UnityEngine;

public class PrevPage : MonoBehaviour
{
	public void ShowPrevPage()
	{
		EventManager.current.ChangePageTrigger(-1);
	}
}
