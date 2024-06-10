using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fishohhkMoving : MonoBehaviour
{
    public Camera cam;
    Vector2 mousePos;
    Rigidbody2D rb;
    Vector2 dirVector;
    Vector2 direction;
    float speed;
    public float speedFactor = 2.0f;
    private GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        dirVector = mousePos - new Vector2(transform.position.x, transform.position.y);
        direction = dirVector.normalized;
        speed = dirVector.magnitude * speedFactor;
        
    }

    private void OnMouseDown()
    {
        //distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
    }
    private void OnMouseDrag()
    {
        //transform.position = mousePos + distance;
        rb.velocity = direction * speed;
        if(rb.velocity.magnitude < 0.1f)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void PutMonsters()
    {
        fishedOnWater monsterController = monster.GetComponent<fishedOnWater>();
        monsterController.putinto();
    }
    public void NotPutMonsters()
    {
        fishedOnWater monsterController = monster.GetComponent<fishedOnWater>();
        monsterController.notput();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        monster = collision.gameObject;
    }



}
