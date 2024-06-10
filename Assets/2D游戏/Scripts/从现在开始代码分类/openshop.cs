using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openshop : MonoBehaviour
{
    public GameObject shop;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject introductionbox;
    public GameObject BUY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Openshop()
    {
        shop.SetActive(true);
    }

    public void Shutshop()
    {
        shop.SetActive(false);
        //πÿµÙΩÈ…‹øÚ∫ÕBUY
        introductionbox.SetActive(false);
        BUY.SetActive(false);
    }


    public void openWuqi()
    {
        a.SetActive(true);
        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(false);
        e.SetActive(false);
    }

    public void openKuijia()
    {
        a.SetActive(false);
        b.SetActive(true);
        c.SetActive(false);
        d.SetActive(false);
        e.SetActive(false);
    }
    public void openXiaohaopin()
    {
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(true);
        d.SetActive(false);
        e.SetActive(false);
    }
    public void openJineng()
    {
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(true);
        e.SetActive(false);
    }
    public void openShu()
    {
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(false);
        e.SetActive(true);
    }

}
