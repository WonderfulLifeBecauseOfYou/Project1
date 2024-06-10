using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class shopslot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNumber;
   // public ShopManager shopmanager;

    private void Start()
    {
        //hopmanager = GameObject.FindGameObjectWithTag("SHOP").transform.GetChild(0).GetComponent<ShopManager>();
    }
    public void objectclicked()
    {
        if (slotItem == null) return;
        ShopManager.instance  .ObjectInfo(slotItem.info);
        ShopManager.instance.openintroduction();
        ShopManager.instance.ChooseItem(this);
    }

    public void buyItem()
    {
        //ShopManager.instance.Buy(slotItem);
    }


}
