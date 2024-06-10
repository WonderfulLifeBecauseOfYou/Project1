using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public List Myshop;
    public Text Information;
    public GameObject introductionbox;
    public GameObject BUY;
    private shopslot chooseitem;
    public shopslot slotPrefab;
    public GameObject BuySuccessful;
    private GameObject xx;

    [Header("武器格子")]
    public GameObject slotGrid;
    [Header("防具格子")]
    public GameObject slotGrid2;
    [Header("消耗品格子")]
    public GameObject slotGrid3;
    [Header("技能格子")]
    public GameObject slotGrid4;
    [Header("书籍格子")]
    public GameObject slotGrid5;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        //RefreshItem();
        instance.Information.text = "";
        xx = GameObject.FindGameObjectWithTag("SHOP").transform.GetChild(0).GetChild(0).GetChild(10).gameObject;//"购买成功"的父物体
    }

    public  void ObjectInfo(string description)
    {
        instance.Information.text = description;
    }
    public void ChooseItem(shopslot item)
    {
        chooseitem = item;
    }

    public  void CreateNewItem(Item item)
    {
        
        if (item.style == "武器")
        {
            shopslot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }
        else if(item.style == "防具")
        {
            shopslot newItem = Instantiate(instance.slotPrefab, instance.slotGrid2.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid2.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }
        else if (item.style == "消耗品")
        {
            shopslot newItem = Instantiate(instance.slotPrefab, instance.slotGrid3.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid3.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }
        else if (item.style == "技能")
        {
            shopslot newItem = Instantiate(instance.slotPrefab, instance.slotGrid4.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid4.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }
        else if (item.style == "书籍")
        {
            shopslot newItem = Instantiate(instance.slotPrefab, instance.slotGrid5.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid5.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }

    }
    /*
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            if (instance.slotGrid.transform.GetChild(i).gameObject != null)
            {
                Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            }

        }
        for (int i = 0; i < instance.Myshop.list.Count; i++)
        {
            CreateNewItem(instance.Myshop.list[i]);
        }
    }
    */

    //打开介绍框,购买按键
    public void openintroduction()
    {
        introductionbox.SetActive(true);
        BUY.SetActive(true);
    }

    //买东西,销毁物体
    public  void Buy()
    {
        if(chooseitem.slotItem.style == "消耗品")
        {
            if (chooseitem == null) return;
            Manager.instance.AddItem(chooseitem.slotItem);
        }
        else
        {
            if (chooseitem == null) return;
            instance.Myshop.list.Remove(chooseitem.slotItem);
            Manager.instance.AddItem(chooseitem.slotItem);
            Destroy(chooseitem.gameObject);
        }
        
        GameObject x = Instantiate(BuySuccessful, xx.transform.position, Quaternion.identity);
        x.transform.SetParent(xx.transform);
        Destroy(x, 1f);
    }

}
