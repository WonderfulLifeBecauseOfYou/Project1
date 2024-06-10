using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack1 : MonoBehaviour
{
    Animator animator;
    private bool cooling;
    private bool x;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JinZhanGongJi(x);
        
    }

    public void open()
    {
        x = !x;
    }

    public void JinZhanGongJi(bool x)
    {
        if (Input.GetKeyUp(KeyCode.Space) && cooling==false && x==true)
        {
            animator.SetTrigger("isattack");
            cooling= true;
            Invoke("attackstop", 1f);
        }
    }

    public void attackstop()
    {
        cooling = false;
        animator.SetTrigger("attackover");
    }

}
