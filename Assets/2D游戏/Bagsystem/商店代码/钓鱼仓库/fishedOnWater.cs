using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishedOnWater : MonoBehaviour
{
    public Item fishesItem;
    public List fishStore;
    private Rigidbody2D rb;
    public GameObject judge1;
    public GameObject judge2;
    public GameObject judge3;
    public GameObject judge4;
    public GameObject judge5;
    public GameObject judge6;
    public int level;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        judge1 = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(3).gameObject;
        judge2 = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(4).gameObject;
        judge3 = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(5).gameObject;
        judge4 = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(6).gameObject;
        judge5 = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(7).gameObject;
        judge6 = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(8).gameObject;
    }
    public void AddnewItem()
    {
        if (!fishStore.list.Contains(fishesItem))
        {
            fishStore.list.Add(fishesItem);
        }
        else
        {
            fishesItem.number += 1;
        }
        fishbagManager.instance.RefreshItem();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(level == 1)
            {
                judge1.SetActive(true);
            }
            else if(level == 2)
            {
                judge2.SetActive(true);
            }
            else if (level == 3)
            {
                judge3.SetActive(true);
            }
            else if (level == 4)
            {
                judge4.SetActive(true);
            }
            else if (level == 5)
            {
                judge5.SetActive(true);
            }
            else if (level == 6)
            {
                judge6.SetActive(true);
            }

        }
    }



    public void putinto()
    {
        AddnewItem();
        Destroy(gameObject);
    }
    public void notput()
    {
        Destroy(gameObject);
    }
}
