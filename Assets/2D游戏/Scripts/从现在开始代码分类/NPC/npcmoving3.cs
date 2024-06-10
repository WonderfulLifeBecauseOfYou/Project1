using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class npcmoving3 : MonoBehaviour
{
    public bool isVertical;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed = 3;
    public float changeDirectionTime = 2f;
    public float changeTimer;
    public float waitTime = 2f;
    public float waitTimer;
    private bool Right = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveDirection = isVertical ? Vector2.up : Vector2.right;
        changeTimer = changeDirectionTime;
        waitTimer = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            waitTimer -= Time.deltaTime;

            if(waitTimer > 0)
            {
                Vector2 position1 = rb.position;
                rb.MovePosition(position1);
                anim.SetBool("right", Right);
                anim.SetBool("left", !Right);
            }
            else
            {
                anim.SetBool("right", false);
                anim.SetBool("left", false);
                Right = !Right;
                moveDirection *= -1;
                changeTimer = changeDirectionTime;
                waitTimer = waitTime;
                

            }


        }
        else
        {
            Vector2 position = rb.position;
            position.x += moveDirection.x * speed * Time.deltaTime;
            position.y += moveDirection.y * speed * Time.deltaTime;
            rb.MovePosition(position);
            anim.SetFloat("moveX", moveDirection.x);
            anim.SetFloat("moveY", moveDirection.y);
        }
        

    }
}
