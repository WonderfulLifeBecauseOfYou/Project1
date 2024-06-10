using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMoving : MonoBehaviour
{
    public bool isVertical;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    public float speed = 3;
    public float changeDirectionTime = 2f;
    private float changeTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = isVertical ? Vector2.up : Vector2.left;
        changeTimer = changeDirectionTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        changeTimer -= Time.fixedDeltaTime;
        if (changeTimer < 0)
        {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
            Flip1();
        }
        Vector2 position = rb.position;
        position.x += moveDirection.x * speed * Time.fixedDeltaTime;
        position.y += moveDirection.y * speed * Time.fixedDeltaTime;
        rb.MovePosition(position);
    }
    private void Flip1()
    {
        Vector3 rotation = transform.eulerAngles;
        if (rotation.y == 180f)
        {
            rotation.y = 0f;
        }
        else if (rotation.y == 0f)
        {
            rotation.y = 180f;
        }
        transform.eulerAngles = rotation;
    }
}
