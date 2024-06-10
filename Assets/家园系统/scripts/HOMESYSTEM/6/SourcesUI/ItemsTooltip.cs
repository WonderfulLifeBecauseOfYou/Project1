using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsTooltip : MonoBehaviour
{
    //static instance of the tooltip
    private static ItemsTooltip instance;

    //camera
    [SerializeField] private Camera uiCamera;
    //item holders on the tooltip
    [SerializeField] private List<GameObject> itemHolders;
    [SerializeField] private Slots slots;
    private void Awake()
    {
        //initialize the static instance
        instance = this;
        //disable the object
        transform.parent.gameObject.SetActive(false);
    }

    private void ShowTooltip<T>(GameObject caller, Dictionary<T, int> items)
        where T : Producible
    {
        int i = 0;

        //initialize each item holder with item
        foreach (var itemPair in items)
        {
            itemHolders[i].GetComponent<Distributor>().Initialize(caller.GetComponent<Building>(), itemPair.Key, itemPair.Value);

            i++;
            //check if we're not out of bounds
            if(i >= itemHolders.Count) {break;}
        }

        //position the tooltip
        //subtract the camera position to get the correct position (since the camera can move)
        Vector3 position = caller.transform.position - uiCamera.transform.position;
        //convert the position; first - from local to world, second - from world to screen
        position = uiCamera.WorldToScreenPoint(uiCamera.transform.TransformPoint(position));
        //assign the new position
        transform.position = position;
        
        //set the whole tooltip visible (the script is attached to the child object)
        transform.parent.gameObject.SetActive(true);
    }
    private void ShowTooltip<T>(GameObject caller, List<T> allItems, List<T> itemsQueue)
        where T : Producible
    {
        int i = 0;

        //initialize each item holder with item
        foreach (var item in allItems)
        {
            itemHolders[i].GetComponent<Distributor>().Initialize(caller.GetComponent<PlaceableObject>(), item);

            i++;
            //check if we're not out of bounds
            if (i >= itemHolders.Count)
            {
                break;
            }
        }
        //position the tooltip
        //subtract the camera position to get the correct position (since the camera can move)
        Vector3 position = caller.transform.position - uiCamera.transform.position;
        //convert the position; first - from local to world, second - from world to screen
        position = uiCamera.WorldToScreenPoint(uiCamera.transform.TransformPoint(position));
        //assign the new position
        transform.position = position;

        slots.ShowSlots(caller, itemsQueue);

        //set the whole tooltip visible (the script is attached to the child object)
        transform.parent.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        //disable all item holders
        for (int i = 0; i < itemHolders.Count; i++)
        {
            itemHolders[i].SetActive(false);
        }
        
        //disable the whole tooltip
        transform.parent.gameObject.SetActive(false);
    }
    
    //static tooltip show method
    public static void ShowTooltip_Static<T>(GameObject caller, Dictionary<T, int> items)
        where T : Producible
    {
        instance.ShowTooltip(caller, items);
    }
    public static void ShowTooltip_Static<T>(GameObject caller, List<T> items, List<T> itemsQueue = null)
where T : Producible
    {
        instance.ShowTooltip(caller, items, itemsQueue);
    }

    //static tooltip hide method
    public static void HideTooltip_Static() 
    {
        instance.HideTooltip();
    }
}
