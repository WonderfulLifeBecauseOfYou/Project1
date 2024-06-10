using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectonworld : MonoBehaviour
{
    public Item thisItem;
    public List ObjectList;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddnewItem();
            Destroy(gameObject);
        }
    }

    public void AddnewItem()
    {
        if(!ObjectList.list.Contains(thisItem))
        {
            ObjectList.list.Add(thisItem);
        }
        else{
            thisItem.number += 1;
        }
        if(thisItem.style == "ÎäÆ÷"){
            Manager.instance.RefreshItem();
        }
        
    }
}
