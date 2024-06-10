using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class npcmoving1 : MonoBehaviour
{
    public bool isVertical;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed = 3;
    public float changeDirectionTime = 2f;
    private float changeTimer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveDirection = isVertical ? Vector2.up : Vector2.right;
        changeTimer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer -= Time.deltaTime;
        if(changeTimer <0)
        {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;

        }
        Vector2 position = rb.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rb.MovePosition(position);
        anim.SetFloat("moveX", moveDirection.x);
        anim.SetFloat("moveY", moveDirection.y);

    }
}
