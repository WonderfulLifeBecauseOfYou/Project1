using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 控制子弹的移动和碰撞
/// </summary>

public class BulletController : MonoBehaviour
{
    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 子弹的移动
    public void Move(Vector2 moveDirection, float moveForce)
    {
        rbody.AddForce(moveDirection * moveForce);
    }

    /*
    // 碰撞检测（子弹消失）
    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy_behaviour ec = other.collider.GetComponent<Enemy_behaviour>();
        Monster1 a = other.collider.GetComponent<Monster1>();
        Monster2 b = other.collider.GetComponent<Monster2>();
        Monster3 c = other.collider.GetComponent<Monster3>();
        Monster4 d = other.collider.GetComponent<Monster4>();
        if (ec != null)
        {
            ec.BosschangeHealth(-1);
        }
        if (a != null)
        {
            a.GetFight(-1);
        }
        if (b != null)
        {
            b.GetFight(-1);
        }
        if (c != null)
        {
            c.GetFight(-1);
        }
        if (d != null)
        {
            d.GetFight(-1);
        }
        Destroy(this.gameObject);
    }
    */
}
