using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMemory : MonoBehaviour
{
    public GameObject open1;
    public GameObject open2;
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    private bool yep=false;
    private bool yes = false;
    private Vector3 v;
    private float speed = 3f;
    private float Time = 1f;

    public Vector3 子物体坐标;
    public Vector3 世界坐标;


    public GameObject GOnScene2;

    public GameObject plot1;
    public GameObject plot2;
    public GameObject plot3;
    public GameObject choice;
    public GameObject choice1;
    public GameObject choice2;
    public Item thisItem1;
    public Item thisItem2;
    public List ObjectList;

    public GameObject fire;
    public GameObject wood;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (choice.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                choice.SetActive(false);
                choice1.SetActive(true);
                AddnewItem();
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                choice.SetActive(false);
                choice2.SetActive(true);
                AddnewItem2();
            }
        }
        Redestory();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        世界坐标 = transform.TransformPoint(子物体坐标);
        if (yep)
        {
            move();
        }
        if (yes)
        {
            move2();
        }
        
        
    }

    public void moveCamera1()
    {
        yep = true;
        open1.SetActive(false);
        plot1.SetActive(false);
        plot2.SetActive(true);
        Invoke("openSene2", 10f);
    }


    public void move()
    {
        transform.position = Vector3.SmoothDamp(世界坐标, new Vector3(-15.18213f, 世界坐标.y, 世界坐标.z), ref v, Time, speed);
    }

    public void move2()
    {
        transform.position = Vector3.SmoothDamp(世界坐标, new Vector3(-5.202132f, 世界坐标.y, 世界坐标.z), ref v, 0.2f, speed);
    }
    private void openSene2()
    {
        GOnScene2.SetActive(true);
    }



    public void moveCamera2()
    {
        plot2.SetActive(false);
        plot3.SetActive(true);
        GOnScene2.SetActive(false);
        scene1.SetActive(false);
        scene3.SetActive(true);
        open2.SetActive(false);
        yes = true;
    }





    public void AddnewItem()
    {
        if (!ObjectList.list.Contains(thisItem1))
        {
            ObjectList.list.Add(thisItem1);
        }
        else
        {
            return;
        }
        Manager.instance.RefreshItem();

    }
    public void AddnewItem2()
    {
        if (!ObjectList.list.Contains(thisItem2))
        {
            ObjectList.list.Add(thisItem2);
        }
        else
        {
            return;
        }
        Manager.instance.RefreshItem();

    }

    public void Redestory()
    {
        if(fire.transform.position.y < 16.58618f && fire.activeInHierarchy == true)
        {
            Destroy(fire);
        }
        if (wood.transform.position.y < 16.58618f && wood.activeInHierarchy == true)
        {
            Destroy(wood);
        }
    }
}
