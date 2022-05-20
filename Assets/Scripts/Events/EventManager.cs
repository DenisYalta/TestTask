
using System;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    public static EventManager current;
    private void Awake()
    {
        current = this;
    }

    public event Action<int> ChangePageEvent;
       
    public void ChangePageTrigger(int change)
    {
        if (ChangePageEvent != null)
        {
            ChangePageEvent(change);
        }
    }




}
