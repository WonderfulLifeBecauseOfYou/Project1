using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsOnshop : MonoBehaviour
{
    public Item shopItem;
    public List shopList;



    private void Start()
    {
        //商店一打开就自动补货
        ShopManager.instance.CreateNewItem(shopItem);
        if (!shopList.list.Contains(shopItem))
        {
            shopList.list.Add(shopItem);
        }
    }

    public void SubtractItem()
    {
        if (shopList.list.Contains(shopItem))
        {
            if(shopItem.number > 1)
            {
                shopItem.number -= 1;
            }
            else
            {
                shopList.list.Remove(shopItem);
            }
            Destroy(shopItem);
        }
        else
        {
            return;
        }

        //Manager.RefreshItem();
    }
}
