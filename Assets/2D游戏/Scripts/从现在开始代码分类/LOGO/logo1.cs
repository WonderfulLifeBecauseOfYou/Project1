using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logo1 : MonoBehaviour
{
    public GameObject a1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void open1()
    {
        a1.SetActive(true);
        Invoke("Destroya1", 5f);
    }
    private void Destroya1()
    {
        Destroy(a1);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            open1();
        }
        this.gameObject.SetActive(false);
    }
}