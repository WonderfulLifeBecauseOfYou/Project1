using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
//using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using HeneGames.DialogueSystem;
using System.ComponentModel;

public class Monster5 : MonoBehaviour
{

    private GameObject player;
    public LayerMask LayerMask;
    private SkeletonAnimation _skeletonAnimation;
    private Vector2 moveDirection;
    public float attackDistance;//攻击距离
    public float followDistance;//追击距离

    private float distance;
    private Rigidbody2D rb;
    public float runspeed = 2;

    private bool _isAttacking = false;
    private bool _isWalking = false;
    private bool _isIdleing = false;
    // 精英敌人，会自动追击玩家，被打会追击
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _skeletonAnimation = transform.GetComponent<SkeletonAnimation>();
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        HarmSystem h = gameObject.GetComponent<HarmSystem>();
        if (h.isdie) return;
        distance = Vector2.Distance(transform.position, player.transform.position);
        if(h.currentHealth != h.maxHealth)
        {
            EnemyLogic1();
        }
        if (distance <= followDistance)
        {
            Findplayer();
        }
        else
        {
            if (_isIdleing) return;
            _isIdleing = true;
            TrackEntry track = _skeletonAnimation.AnimationState.SetAnimation(0, "Idle", false);
            track.Complete += ResetAttack;
        }
    }



    public void Findplayer()
    {
        if (distance <= followDistance && distance > attackDistance)
        {
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, moveDirection, followDistance, LayerMask);//这一条看玩家有没有进入追击范围
            Debug.DrawRay(transform.position, moveDirection * followDistance, Color.blue);
            if (hit2.collider != null)
            {
                EnemyLogic1();
                if (_isWalking) return;
                _isWalking = true;
                TrackEntry track = _skeletonAnimation.AnimationState.SetAnimation(0, "Walk", false);
                track.Complete += ResetAttack;
            }
        }
        else if (distance <= attackDistance)
        {
            RaycastHit2D hit3 = Physics2D.Raycast(transform.position, moveDirection, attackDistance, LayerMask);//这一条看玩家有没有进入攻击范围
            Debug.DrawRay(transform.position, moveDirection * attackDistance, Color.green);
            // 因为检测写在Update中，下面会持续调用。增加一个变量判断状态。
            if (hit3.collider != null)
            {
                if (_isAttacking) return;
                _isAttacking = true;
                EnmyLogic2();
            }
        }

    }

    //翻转(选择性翻转
    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > player.transform.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }

    //行为一，发现玩家，开始追击
    private void EnemyLogic1()
    {
        Vector2 targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, runspeed * Time.deltaTime);
        Flip();

    }


    //行为二，玩家在攻击范围内，开始攻击
    public void EnmyLogic2()
    {
        TrackEntry track = _skeletonAnimation.AnimationState.SetAnimation(0, "Attack", false);
        track.Complete += ResetAttack;
    }

    private void ResetAttack(TrackEntry t)
    {
        _isAttacking = false;
        _isWalking = false;
        _isIdleing = false;
    }







}