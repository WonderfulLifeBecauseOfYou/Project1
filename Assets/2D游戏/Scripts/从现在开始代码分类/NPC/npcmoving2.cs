using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcmoving2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed = 20;
    private Vector2 vector2;
    private float totalTime = 0;
    public float changeTime = 2;
    public int index = 0;
    private float X = 0;
    private float Y = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move2();
    }
    public void move2()
    {
        totalTime += Time.deltaTime;
        vector2.x = X;
        vector2.y = Y;
        vector2.Normalize();
        rb.velocity = speed * vector2;

        if(totalTime >= changeTime)
        {
            switch (index)
            {
                case 0://左
                    X = -1;
                    Y = 0;
                    index = 1;
                    anim.SetTrigger("lefting");

                    break;
                case 1://下
                    X = 0;
                    Y = -1;
                    index = 2;
                    anim.SetTrigger("downing");
                    break;
                case 2://右
                    X = 1;
                    Y = 0;
                    index = 3;
                    anim.SetTrigger("righting");
                    break;
                case 3://上
                    X = 0;
                    Y = 1;
                    index = 0;
                    anim.SetTrigger("uping");
                    break;
            }
            totalTime = 0;
        }

    }

    /*
    public void Animchange()
    {
        if(index == 0)//上
        {
            anim.SetBool("lefting", false);
            anim.SetBool("righting", false);
            anim.SetBool("uping", true);
            anim.SetBool("downing", false);
        }
        if (index == 1)//左
        {
            anim.SetBool("lefting", true);
            anim.SetBool("righting", false);
            anim.SetBool("uping", false);
            anim.SetBool("downing", false);
        }
        if (index == 2)//下
        {
            anim.SetBool("lefting", false);
            anim.SetBool("righting", false);
            anim.SetBool("uping", false);
            anim.SetBool("downing", true);
        }
        if (index == 3)//右
        {
            anim.SetBool("lefting", false);
            anim.SetBool("righting", true);
            anim.SetBool("uping", false);
            anim.SetBool("downing", false);
        }
    }
    */
}
