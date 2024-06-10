using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public List Mybag;
    public Slot slotPrefab;
    public Text Information;
    public GameObject IntroductionBox;

    [Header("武器")]
    public GameObject slotGrid;
    [Header("防具")]
    public GameObject slotGrid2;
    [Header("消耗品")]
    public GameObject slotGrid3;
    [Header("技能")]
    public GameObject slotGrid4;
    [Header("书籍")]
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
        RefreshItem();
        instance.Information.text = "";
    }


    //买到背包
    public void AddItem(Item item)
    {
        if (!Mybag.list.Contains(item))
        {
            Mybag.list.Add(item);
        }
        else
        {
            item.number += 1;
        }
        RefreshItem();

    }
    public  void ObjectInfo(string description)
    {
        IntroductionBox.SetActive(true);
        instance.Information.text = description;
    }

    public  void CreateNewItem(Item item)
    {
        if (item.style == "武器")
        {
            Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }
        if (item.style == "防具")
        {
            Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid2.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid2.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }
        else if (item.style == "消耗品")
        {
            Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid3.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid3.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }
        else if (item.style == "技能")
        {
            Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid4.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid4.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }
        else if (item.style == "书籍")
        {
            Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid5.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.slotGrid5.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.Image;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.slotNumber.text = item.number.ToString();
        }
    }

    public  void RefreshItem()
    {
        for(int i=0; i<instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);

        }
        for (int i = 0; i < instance.slotGrid2.transform.childCount; i++)
        {
            if (instance.slotGrid2.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid2.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.slotGrid3.transform.childCount; i++)
        {
            if (instance.slotGrid3.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid3.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.slotGrid4.transform.childCount; i++)
        {
            if (instance.slotGrid4.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid4.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.slotGrid5.transform.childCount; i++)
        {
            if (instance.slotGrid5.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid5.transform.GetChild(i).gameObject);
        }
        for (int i=0; i < instance.Mybag.list.Count; i++)
        {
            CreateNewItem(instance.Mybag.list[i]);
        }
    }
    
}
