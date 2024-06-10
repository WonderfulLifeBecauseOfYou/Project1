using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public GameObject bag;
    public GameObject wuqi;
    public GameObject jineng;
    public GameObject yaopin;
    public GameObject baowu;
    public GameObject xiansuo;
    public GameObject IntroductionBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void weapon()
    {
        bag.SetActive(false);
        wuqi.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void weaponback()
    {
        IntroductionBox.SetActive(false);
        bag.SetActive(true);
        wuqi.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void skill()
    {
        bag.SetActive(false);
        jineng.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void skillback()
    {
        IntroductionBox.SetActive(false);
        bag.SetActive(true);
        jineng.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void drug()
    {
        bag.SetActive(false);
        yaopin.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void drugback()
    {
        IntroductionBox.SetActive(false);
        bag.SetActive(true);
        yaopin.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void treasure()
    {
        bag.SetActive(false);
        baowu.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void treasureback()
    {
        IntroductionBox.SetActive(false);
        bag.SetActive(true);
        baowu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void idea()
    {
        bag.SetActive(false);
        xiansuo.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void ideaback()
    {
        IntroductionBox.SetActive(false);
        bag.SetActive(true);
        xiansuo.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
