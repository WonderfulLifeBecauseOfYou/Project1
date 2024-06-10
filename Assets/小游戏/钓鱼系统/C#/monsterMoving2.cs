using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class monsterMoving2 : MonoBehaviour
{
    public bool O = true;
    public float speed = 10f; //移动速度
    private Rigidbody2D rb;
    private float stayTime = 0;//碰撞持续时间
    private float touchTime = 0;//碰撞变更方向执行时间


    //碰墙
    private float changeTime = 0;
    private float randomTime = 0;
    private float[] XDirection = { -1, 0, 1 };//左停右
    private float[] YDirection = { -1, 0, 1 };//下停上
    private int xIndex = 0;
    private int yIndex = 0;
    private float beforeX = 0;
    private float beforeY = 0;
    private float x = 0;
    private float y = 0;
    private Vector2 v;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Normalmove();
        if(O == true)
        {
            Flip1();
        }
        else
        {
            Flip2();
        }
    }


    public void Normalmove()
    {
        changeTime += Time.deltaTime;
        v.x = x;
        v.y = y;
        v.Normalize();
        rb.velocity = speed * v * Time.deltaTime;
        if (changeTime >= randomTime)
        {
            beforeX = x;
            beforeY = y;
            System.Random random = new System.Random();
            randomTime = random.Next(1, 4);
            xIndex = random.Next(0, 3);
            yIndex = random.Next(0, 3);

            //xy同时移动重新随机
            while (xIndex != 1 && yIndex != 1)
            {
                xIndex = random.Next(0, 3);
                yIndex = random.Next(0, 3);
            }
            x = XDirection[xIndex];
            y = YDirection[yIndex];
            changeTime = 0;
        }
    }


    //碰撞
    public void Touch()
    {
        stayTime += Time.deltaTime;
        touchTime += Time.deltaTime;
        if (stayTime <= 2)
        {
            if (touchTime >= 0.3)
            {
                beforeX = x;
                beforeY = y;
                switch (x)
                {
                    case -1:
                        x = 1;
                        break;
                    case 1:
                        x = -1;
                        break;
                }
                switch (y)
                {
                    case -1:
                        y = 1;
                        break;
                    case 1:
                        y = -1;
                        break;
                }
                if (x == 0 && y == 0)
                {
                    while (xIndex != 1 && yIndex != 1)
                    {
                        System.Random random = new System.Random();
                        xIndex = random.Next(0, 3);
                        yIndex = random.Next(0, 3);
                    }
                    x = XDirection[xIndex];
                    y = YDirection[yIndex];
                }
                touchTime = 0;
            }
        }
        Normalmove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Touch();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Touch();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Normalmove();
        stayTime = 0;
        touchTime = 0;
    }


    private void Flip1()
    {
        if (x >= 0)
        {
            Vector3 rotation = transform.eulerAngles;
            rotation.y = 180f;
            transform.eulerAngles = rotation;
        }
        else
        {
            Vector3 rotation = transform.eulerAngles;
            rotation.y = 0f;
            transform.eulerAngles = rotation;
        }
    }
    private void Flip2()
    {
        if (x >= 0)
        {
            Vector3 rotation = transform.eulerAngles;
            rotation.y = 0f;
            transform.eulerAngles = rotation;
        }
        else
        {
            Vector3 rotation = transform.eulerAngles;
            rotation.y = 180f;
            transform.eulerAngles = rotation;
        }
    }

}
