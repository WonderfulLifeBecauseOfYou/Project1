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
    public float attackDistance;//��������
    public float followDistance;//׷������

    private float distance;
    private Rigidbody2D rb;
    public float runspeed = 2;

    private bool _isAttacking = false;
    private bool _isWalking = false;
    private bool _isIdleing = false;
    // ��Ӣ���ˣ����Զ�׷����ң������׷��
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
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, moveDirection, followDistance, LayerMask);//��һ���������û�н���׷����Χ
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
            RaycastHit2D hit3 = Physics2D.Raycast(transform.position, moveDirection, attackDistance, LayerMask);//��һ���������û�н��빥����Χ
            Debug.DrawRay(transform.position, moveDirection * attackDistance, Color.green);
            // ��Ϊ���д��Update�У������������á�����һ�������ж�״̬��
            if (hit3.collider != null)
            {
                if (_isAttacking) return;
                _isAttacking = true;
                EnmyLogic2();
            }
        }

    }

    //��ת(ѡ���Է�ת
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

    //��Ϊһ��������ң���ʼ׷��
    private void EnemyLogic1()
    {
        Vector2 targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, runspeed * Time.deltaTime);
        Flip();

    }


    //��Ϊ��������ڹ�����Χ�ڣ���ʼ����
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