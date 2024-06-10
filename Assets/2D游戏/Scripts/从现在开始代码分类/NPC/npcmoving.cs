using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.VFX;
using UnityEngine.UIElements;
using JetBrains.Annotations;
using UnityEngine.UI;

public class npcmoving : MonoBehaviour
{
    public GameObject chatbox;
    public int npcHeathy = 5;
    public int npcFavorLevel = 5;
    public float speed = 10f; //�ƶ��ٶ�
    public Animator animator;
    public Rigidbody2D rb;
    private float stayTime = 0;//��ײ����ʱ��
    private float touchTime = 0;//��ײ�������ִ��ʱ��
    private Vector2 vector2;

    public int npcState = 0;//0:���ߣ�1����ǽ��2���������ˣ�3���Ի���4�����Ҵ�һ���ƣ�5��������һ�ڣ�6����Ӹ��棬7��������

    //�����
    public bool touchPlayer = false;

    //�Ի�
    public GameObject ChatText;
    private bool firsttalk = true;
    //private GameObject chat0;
    [Header("�ı��ļ�")]
    public Text textLabel;
    public TextAsset textFile;
    public int index;
    List<string> textList = new List<string>();

    //���
    public bool isParty = false;//�Ƿ����
    private float partyX = 2;
    private float partyY = 2;


    //��ǽ
    private float changeTime = 0;
    private float randomTime = 0;
    private float[] XDirection = {-1,0,1 };//��ͣ��
    private float[] YDirection = { -1, 0, 1 };//��ͣ��
    private int xIndex = 0;
    private int yIndex = 0;
    private float beforeX = 0;
    private float beforeY = 0;
    private float x = 0;
    private float y = 0;
    private Vector2 v;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //�Ի�
        Getthetext(textFile);
        index = 0;
        //chat0 = ChatText.transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        NPCcontroller();

        if (npcState != 2)
        {
            ChangeAnim();
        }
        else
        {
            animator.SetBool("leftmove", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("rightmove", false);
            animator.SetBool("up", false);
            animator.SetBool("upmove", false);
            animator.SetBool("down", true);
            animator.SetBool("downmove", false);
        }

        if (Input.GetKeyDown(KeyCode.Return) && index == textList.Count)
        {
            chatbox.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            textLabel.text = textList[index];
            index++;
        }
    }


    public void NPCcontroller()
    {
        switch (npcState)
        {
            case 0:
                Normalmove();
                break;
            case 1:
                Touch();
                break;
            case 2:
                touchplayer();
                break;
            case 3:
                Talk();
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                partyMove();
                break;
            case 7:
                break;

        }
    }

    //��������
    public void Normalmove()
    {
        changeTime += Time.deltaTime;
        v.x = x;
        v.y = y;
        v.Normalize();
        rb.velocity = speed * v * Time.deltaTime;
        if(changeTime >= randomTime)
        {
            beforeX = x;
            beforeY = y;
            System.Random random = new System.Random();
            randomTime = random.Next(1,4);
            xIndex = random.Next(0,3);
            yIndex = random.Next(0,3);

            //xyͬʱ�ƶ��������
            while (xIndex != 1 && yIndex != 1)
            {
                xIndex = random.Next(0, 3);
                yIndex = random.Next(0, 3);
            }
            x = XDirection[xIndex];
            y = YDirection[yIndex];
            changeTime = 0;
        }
    }

    //�ı䶯��
    public void ChangeAnim()
    {
        if (x == -1 && y == 0)//����
        {
            animator.SetBool("leftmove", true);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("rightmove", false);
            animator.SetBool("up", false);
            animator.SetBool("upmove", false);
            animator.SetBool("down", false);
            animator.SetBool("downmove", false);
        }
        else if (x == 1 && y == 0)//����
        {
            animator.SetBool("leftmove", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("rightmove", true);
            animator.SetBool("up", false);
            animator.SetBool("upmove", false);
            animator.SetBool("down", false);
            animator.SetBool("downmove", false);
        }
        else if (x == 0 && y == -1)//����
        {
            animator.SetBool("leftmove", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("rightmove", false);
            animator.SetBool("up", false);
            animator.SetBool("upmove", false);
            animator.SetBool("down", false);
            animator.SetBool("downmove", true);
        }
        else if (x == 0 && y == 1)//����
        {
            animator.SetBool("leftmove", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("rightmove", false);
            animator.SetBool("up", false);
            animator.SetBool("upmove", true);
            animator.SetBool("down", false);
            animator.SetBool("downmove", false);
        }
        else if (x == 0 && y == 0)
        {
            if (beforeX == 0 && beforeY == 0)//ͣ
            {
                animator.SetBool("leftmove", false);
                animator.SetBool("left", false);
                animator.SetBool("right", false);
                animator.SetBool("rightmove", false);
                animator.SetBool("up", false);
                animator.SetBool("upmove", false);
                animator.SetBool("down", true);
                animator.SetBool("downmove", false);
            }
            else if (beforeX == -1 && beforeY == 0)//��ͣ
            {
                animator.SetBool("leftmove", false);
                animator.SetBool("left", true);
                animator.SetBool("right", false);
                animator.SetBool("rightmove", false);
                animator.SetBool("up", false);
                animator.SetBool("upmove", false);
                animator.SetBool("down", false);
                animator.SetBool("downmove", false);
            }
            else if (beforeX == 1 && beforeY == 0)//��ͣ
            {
                animator.SetBool("leftmove", false);
                animator.SetBool("left", false);
                animator.SetBool("right", true);
                animator.SetBool("rightmove", false);
                animator.SetBool("up", false);
                animator.SetBool("upmove", false);
                animator.SetBool("down", false);
                animator.SetBool("downmove", false);
            }
            else if (beforeX == 0 && beforeY == 1)//��ͣ
            {
                animator.SetBool("leftmove", false);
                animator.SetBool("left", false);
                animator.SetBool("right", false);
                animator.SetBool("rightmove", false);
                animator.SetBool("up", true);
                animator.SetBool("upmove", false);
                animator.SetBool("down", false);
                animator.SetBool("downmove", false);
            }
            else if (beforeX == 0 && beforeY == -1)//��ͣ
            {
                animator.SetBool("leftmove", false);
                animator.SetBool("left", false);
                animator.SetBool("right", false);
                animator.SetBool("rightmove", false);
                animator.SetBool("up", false);
                animator.SetBool("upmove", false);
                animator.SetBool("down", true);
                animator.SetBool("downmove", false);

            }

        }
    }





    //-------------��ײ��⣨ǽ��--------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(npcState != 6)
        {
            if (collision.gameObject.tag == "Player")
            {
                npcState = 2;
                rb.bodyType = RigidbodyType2D.Static;
                touchPlayer = true;
            }
            else
            {
                npcState = 1;
            }
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (npcState != 6)
        {
            if (collision.gameObject.tag == "Player")
            {
                npcState = 2;
                rb.bodyType = RigidbodyType2D.Static;
                touchPlayer = true;
            }
            else
            {
                npcState = 1;
            }
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(isParty == true)
        {
            npcState = 6;
        }
        else
        {
            npcState = 0;
        }

        stayTime = 0;
        touchTime = 0;
        //�����
        rb.bodyType = RigidbodyType2D.Dynamic;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        touchPlayer = false;
        //�Ի�
        chatbox.SetActive(false);
        firsttalk = false;
        //chat0.SetActive(false);
    }

    //��ײ
    public void Touch()
    {
        stayTime += Time.deltaTime;
        touchTime += Time.deltaTime;
        if(stayTime <= 2)
        {
            if(touchTime >= 0.3)
            {
                beforeX = x;
                beforeY = y;
                switch (x)
                {
                    case -1:
                        x = 1;
                        break;
                    case 1:
                        x = -1;
                        break;
                }
                switch (y)
                {
                    case -1:
                        y = 1;
                        break;
                    case 1:
                        y = -1;
                        break;
                }
                if (x == 0 && y == 0)
                {
                    while (xIndex != 1 && yIndex != 1)
                    {
                        System.Random random = new System.Random();
                        xIndex = random.Next(0, 3);
                        yIndex = random.Next(0, 3);
                    }
                    x = XDirection[xIndex];
                    y = YDirection[yIndex];
                }
                touchTime = 0;
            }
        }
        npcState = 0;
    }



    //---------------��ײ���-----------
    public void touchplayer()
    {
        rb.bodyType = RigidbodyType2D.Static;
        //E
        if(touchPlayer == true && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //npcState = 3;
        }
        
    }


    //----------------�Ի�----------------
    public void talkstate()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        npcState = 3;
    }
    public void Talk()
    {
        chatbox.SetActive(true);
        
        if (firsttalk == true)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                //print(1);
                //chat0.SetActive(false);
                textLabel.text = textList[index];
                index++;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
            {
                chatbox.SetActive(false);
                index = 0;
                return;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                textLabel.text = textList[index];
                index++;
            }
        }
        if(isParty == true)
        {
            npcState = 6;

        }
        else
        {
            npcState = 3;
        }

    }

    

    void Getthetext(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineDate = file.text.Split('\n');
        foreach(var line in lineDate)
        {
            textList.Add(line);
        }

    }



    //���
    public void Term()
    {
        if(isParty == false)//�������״̬��
        {
            if(npcFavorLevel < 4)//�������
            {
                npcState = 3;
            }
            else//�����
            {
                isParty = true;
                npcState = 6;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }

        }
        else//���״̬��
        {
            //���
            isParty = false;
            npcState = 3;
        }
    }



    //���������
    void partyMove()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        //���λ��
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        //npcλ��
        Transform npc = gameObject.transform;
        float xDistance = System.Math.Abs(player.position.x - npc.position.x);
        float yDistance = System.Math.Abs(player.position.y - npc.position.y);
        float checkX = player.position.x - npc.position.x;
        float checkY = player.position.y - npc.position.y;

        //ֹͣ�ƶ�
        if(xDistance <= partyX && yDistance <= partyY)
        {
            x = 0;
            y = 0;
            vector2.x = x;
            vector2.y = y;
            rb.velocity = speed * vector2 * Time.deltaTime;
        }
        else
        {
            //�������
            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
            {
                x = Input.GetAxisRaw("Horizontal");
                y = Input.GetAxisRaw("Vertical");
                vector2.x = x;
                vector2.y = y;
                vector2.Normalize();
                rb.velocity = speed * vector2 * Time.deltaTime;
            }
            else//�����Ƿ��ڷ�Χ��
            {
                if(xDistance > partyX)
                {
                    beforeX = x;
                    beforeY = y;
                    if(checkX < 0)
                    {
                        x = -1;
                    }
                    else
                    {
                        x = 1;
                    }
                    y = 0;
                    vector2.x = x;
                    vector2.y = y;
                    vector2.Normalize();
                    rb.velocity = speed * vector2 * Time.deltaTime;
                }
                if(yDistance > partyY)
                {
                    beforeX = x;
                    beforeY = y;
                    if (checkY  < 0)
                    {
                        y = -1;
                    }
                    else
                    {
                        y = 1;
                    }
                    x = 0;
                    vector2.x = x;
                    vector2.y = y;
                    vector2.Normalize();
                    rb.velocity = speed * vector2 * Time.deltaTime;
                }
            }
        }

    }


}
