using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fishslot : MonoBehaviour
{
    public fishslot slotPrefab;
    public Item slotItem;
    public Image slotImage;
    public Text slotNumber;
    public List fishbag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void objectclicked()
    {
        fishbagManager.instance.ObjectInfo(slotItem.info, slotItem.Name, slotItem.Image2);

    }
}