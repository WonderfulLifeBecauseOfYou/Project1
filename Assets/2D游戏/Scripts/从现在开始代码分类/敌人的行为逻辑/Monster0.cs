using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using System.ComponentModel;

public class Monster0 : MonoBehaviour
{
    private SkeletonAnimation _skeletonAnimation;
    private Rigidbody2D rb;
    // ���Ƶĵ��ˡ�
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _skeletonAnimation = transform.GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //��⵽��ҿ��������1
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // track Ĭ����0��animationName �Ƕ������ƣ��ز�����4����Attack��Dead��Idle��Walk
            // loop дtrue��ѭ������
            _skeletonAnimation.AnimationState.SetAnimation(0, "Walk", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);
        }
    }




}
