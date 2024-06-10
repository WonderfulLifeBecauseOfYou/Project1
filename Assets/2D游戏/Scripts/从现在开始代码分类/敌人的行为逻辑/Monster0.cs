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
    // 友善的敌人。
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _skeletonAnimation = transform.GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //检测到玩家靠近，输出1
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // track 默认是0；animationName 是动画名称，素材里有4个：Attack，Dead，Idle，Walk
            // loop 写true，循环播放
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
