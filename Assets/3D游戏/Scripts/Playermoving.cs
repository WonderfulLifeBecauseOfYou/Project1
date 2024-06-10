using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;

public class Playermoving : MonoBehaviour
{
    public float speed = 2;
    public float jumpForce = 5f;
    public bool isjumpping = true;
    public Transform root;
    public Transform FollowedCamera;


    Animator anim;
    private Rigidbody rb;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        playermoving();
        PlayerJump();

    }



    void playermoving()
    {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        FollowedCamera = GameObject.Find("Virtual Camera").transform;//获取相机位置
        var forward = Vector3.ProjectOnPlane(FollowedCamera.forward, Vector3.up);
        var right = Vector3.ProjectOnPlane(FollowedCamera.right, Vector3.up);
        var m = (vertical * forward + horizontal * right).normalized * speed;

        transform.forward = Vector3.Slerp(transform.forward, m, 0.3f);
        anim.SetFloat("MoveSpeed", m.magnitude);

        rb.velocity = new Vector3(m.x, rb.velocity.y, m.z);

    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isjumpping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
       
    }

    private void IsGrounded()
    {
        RaycastHit hit;
        float distance = 0.15f;

        // 检测下方是否有碰撞体
        if (Physics.Raycast(root.position, - Vector3.up, distance))
        {
            isjumpping = true;
        }
        else
        {
            isjumpping = false;
        }
    }

}