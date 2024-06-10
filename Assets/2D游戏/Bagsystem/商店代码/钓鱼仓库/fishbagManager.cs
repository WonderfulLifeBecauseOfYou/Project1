using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fishbagManager : MonoBehaviour
{
    public static fishbagManager instance;
    public List fishbag;
    public fishslot slotPrefab;
    public Text Information;
    public Image picture;
    public Text Name;
    public GameObject IntroductionBox;
    public GameObject slotGrid;


    // Start is called before the first frame update
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
        instance.Name.text = "";
    }

    private void Update()
    {
        
    }
    public void ObjectInfo(string description, string Name, Sprite p)
    {
        IntroductionBox.SetActive(true);
        instance.Information.text = description;
        instance.Name.text = Name;
        instance.picture.sprite = p;
    }

    public void CreateNewItem(Item item)
    {
        fishslot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.Image;
        newItem.transform.localScale = new Vector3(1, 1, 1);
        newItem.slotNumber.text = item.number.ToString();
    }

    
    public void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);

        }
        for (int i = 0; i < instance.fishbag.list.Count; i++)
        {
            CreateNewItem(instance.fishbag.list[i]);
        }

    }

    

    
}
