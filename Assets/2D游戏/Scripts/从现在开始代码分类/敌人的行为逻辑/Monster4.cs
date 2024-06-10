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

public class Monster4 : MonoBehaviour
{

    private GameObject player;
    private Vector2 playerT;
    public LayerMask LayerMask;
    private SkeletonAnimation _skeletonAnimation;
    private Vector2 moveDirection;
    public float attackDistance;//��������
    public float followDistance;//׷������

    private float distance;
    private Rigidbody2D rb;
    public float speed = 7;
    public float runspeed = 2;
    public float changeDirectionTime = 2f;
    private float changeTimer;
    public float waitTime = 2f;
    private float waitTimer;

    private bool _isAttacking = false;
    private bool _isWalking = false;
    private bool _isIdleing = false;
    // ��ͨ���ˣ�һ��ʼ��һֱѲ��(�м��)���Զ�׷����ң���ֻ��һ�ֹ�����ʽ
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        changeTimer = changeDirectionTime;
        waitTimer = waitTime;
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
        Findplayer();
    }



    public void Findplayer()
    {
        if (distance > followDistance)
        {
            EnemyLogic();
        }
        else if (distance <= followDistance && distance > attackDistance)
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


    //��Ϊһ�����˾��䣬��������
    private void EnemyLogic()
    {
        playerT = player.transform.position;
        changeTimer -= Time.deltaTime;
        //����Ѳ��
        if (changeTimer < 0)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer > 0)
            {
                Vector2 position1 = rb.position;
                rb.MovePosition(position1);
                if (_isIdleing) return;
                _isIdleing = true;
                TrackEntry track = _skeletonAnimation.AnimationState.SetAnimation(0, "Idle", false);
                track.Complete += ResetAttack;
            }
            else
            {//��ת
                moveDirection *= -1;
                Flip1();
                changeTimer = changeDirectionTime;
                waitTimer = waitTime;
                //�ƶ�
                Vector2 position = rb.position;
                position.x += moveDirection.x * speed * Time.deltaTime;
                rb.MovePosition(position);
                if (_isWalking) return;
                _isWalking = true;
                TrackEntry track = _skeletonAnimation.AnimationState.SetAnimation(0, "Walk", false);
                track.Complete += ResetAttack;
            }

        }
        else
        {
            //�ƶ�
            Vector2 position = rb.position;
            position.x += moveDirection.x * speed * Time.deltaTime;
            rb.MovePosition(position);
            if (_isWalking) return;
            _isWalking = true;
            TrackEntry track = _skeletonAnimation.AnimationState.SetAnimation(0, "Walk", false);
            track.Complete += ResetAttack;
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

    //һ����ת
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


    //��Ϊ����������ң���ʼ׷��
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